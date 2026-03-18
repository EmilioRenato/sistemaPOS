using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmDetalleCompra : Form
    {
        private readonly int idCompra;

        private string numeroDocumento = "";
        private string proveedor = "";
        private string fechaTexto = "";

        private decimal subtotal = 0m;
        private decimal descuento = 0m;
        private decimal iva = 0m;
        private decimal total = 0m;

        private DataTable dtImpresion = new DataTable();
        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog previewDialog1 = new PrintPreviewDialog();

        public FrmDetalleCompra(int compra)
        {
            InitializeComponent();
            idCompra = compra;

            this.Load += FrmDetalleCompra_Load;
            btnImprimir.Click += btnImprimir_Click;

            printDocument1.PrintPage += printDocument1_PrintPage;
            previewDialog1.Document = printDocument1;
            previewDialog1.Width = 1000;
            previewDialog1.Height = 700;
        }

        private void FrmDetalleCompra_Load(object sender, EventArgs e)
        {
            AplicarEstiloVisual();
            AplicarAnimaciones();
            CargarCabeceraCompra();
            CargarDetalleCompra();
        }

        private void AplicarEstiloVisual()
        {
            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 52, 54);
            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDetalle.ColumnHeadersHeight = 34;

            dgvDetalle.DefaultCellStyle.BackColor = Color.FromArgb(99, 110, 114);
            dgvDetalle.DefaultCellStyle.ForeColor = Color.White;
            dgvDetalle.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvDetalle.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 82, 84);
            dgvDetalle.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 82, 84);
            dgvDetalle.GridColor = Color.FromArgb(178, 190, 195);
            dgvDetalle.BorderStyle = BorderStyle.None;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.RowTemplate.Height = 30;
        }

        private void AplicarAnimaciones()
        {
            btnImprimir.MouseEnter += (s, e) => btnImprimir.BackColor = Color.FromArgb(0, 98, 204);
            btnImprimir.MouseLeave += (s, e) => btnImprimir.BackColor = Color.FromArgb(9, 132, 227);
        }

        private void CargarCabeceraCompra()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT TOP 1
                        c.NumeroDocumento,
                        c.FechaDocumento,
                        p.RazonSocial AS Proveedor,
                        c.Subtotal,
                        c.Descuento,
                        c.Iva,
                        c.Total
                    FROM Compras c
                    INNER JOIN Proveedores p ON c.IdProveedor = p.IdProveedor
                    WHERE c.IdCompra = @IdCompra";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdCompra", idCompra);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    numeroDocumento = dr["NumeroDocumento"] == DBNull.Value ? "" : dr["NumeroDocumento"].ToString();
                    proveedor = dr["Proveedor"] == DBNull.Value ? "" : dr["Proveedor"].ToString();
                    fechaTexto = dr["FechaDocumento"] == DBNull.Value
                        ? ""
                        : Convert.ToDateTime(dr["FechaDocumento"]).ToString("dd/MM/yyyy");

                    subtotal = dr["Subtotal"] == DBNull.Value ? 0m : Convert.ToDecimal(dr["Subtotal"]);
                    descuento = dr["Descuento"] == DBNull.Value ? 0m : Convert.ToDecimal(dr["Descuento"]);
                    iva = dr["Iva"] == DBNull.Value ? 0m : Convert.ToDecimal(dr["Iva"]);
                    total = dr["Total"] == DBNull.Value ? 0m : Convert.ToDecimal(dr["Total"]);

                    lblNumeroDocumento.Text = "Documento compra: " + (string.IsNullOrWhiteSpace(numeroDocumento) ? "-" : numeroDocumento);
                    lblProveedor.Text = "Proveedor: " + (string.IsNullOrWhiteSpace(proveedor) ? "-" : proveedor);
                    lblFecha.Text = "Fecha: " + (string.IsNullOrWhiteSpace(fechaTexto) ? "-" : fechaTexto);

                    lblSubtotalValor.Text = subtotal.ToString("0.00");
                    lblDescuentoValor.Text = descuento.ToString("0.00");
                    lblIvaValor.Text = iva.ToString("0.00");
                    lblTotalValor.Text = total.ToString("0.00");
                }
            }
        }

        private void CargarDetalleCompra()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT
                        p.Codigo,
                        p.Descripcion,
                        dc.Cantidad,
                        dc.CostoUnitario,
                        dc.Descuento,
                        dc.IvaLinea,
                        dc.TotalLinea
                    FROM DetalleCompras dc
                    INNER JOIN Productos p ON dc.IdProducto = p.IdProducto
                    WHERE dc.IdCompra = @IdCompra
                    ORDER BY dc.IdDetalleCompra";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdCompra", idCompra);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtImpresion = dt.Copy();
                dgvDetalle.DataSource = dt;

                if (dgvDetalle.Columns.Contains("Codigo"))
                    dgvDetalle.Columns["Codigo"].HeaderText = "Código";

                if (dgvDetalle.Columns.Contains("Descripcion"))
                    dgvDetalle.Columns["Descripcion"].HeaderText = "Producto";

                if (dgvDetalle.Columns.Contains("Cantidad"))
                    dgvDetalle.Columns["Cantidad"].HeaderText = "Cant.";

                if (dgvDetalle.Columns.Contains("CostoUnitario"))
                    dgvDetalle.Columns["CostoUnitario"].HeaderText = "Costo";

                if (dgvDetalle.Columns.Contains("Descuento"))
                    dgvDetalle.Columns["Descuento"].HeaderText = "Desc.";

                if (dgvDetalle.Columns.Contains("IvaLinea"))
                    dgvDetalle.Columns["IvaLinea"].HeaderText = "IVA";

                if (dgvDetalle.Columns.Contains("TotalLinea"))
                    dgvDetalle.Columns["TotalLinea"].HeaderText = "Total";

                if (dgvDetalle.Columns.Contains("Cantidad"))
                    dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "0.00";

                if (dgvDetalle.Columns.Contains("CostoUnitario"))
                    dgvDetalle.Columns["CostoUnitario"].DefaultCellStyle.Format = "0.00000";

                if (dgvDetalle.Columns.Contains("Descuento"))
                    dgvDetalle.Columns["Descuento"].DefaultCellStyle.Format = "0.00";

                if (dgvDetalle.Columns.Contains("IvaLinea"))
                    dgvDetalle.Columns["IvaLinea"].DefaultCellStyle.Format = "0.00";

                if (dgvDetalle.Columns.Contains("TotalLinea"))
                    dgvDetalle.Columns["TotalLinea"].DefaultCellStyle.Format = "0.00";
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            previewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fontTitulo = new Font("Arial", 14, FontStyle.Bold);
            Font fontNormal = new Font("Arial", 10, FontStyle.Regular);
            Font fontNegrita = new Font("Arial", 10, FontStyle.Bold);

            int y = 35;
            int x = 40;

            e.Graphics.DrawString("DETALLE DE COMPRA", fontTitulo, Brushes.Black, x, y);
            y += 35;

            e.Graphics.DrawString("Documento: " + (string.IsNullOrWhiteSpace(numeroDocumento) ? "-" : numeroDocumento), fontNormal, Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Proveedor: " + (string.IsNullOrWhiteSpace(proveedor) ? "-" : proveedor), fontNormal, Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Fecha: " + (string.IsNullOrWhiteSpace(fechaTexto) ? "-" : fechaTexto), fontNormal, Brushes.Black, x, y);
            y += 30;

            e.Graphics.DrawString("Código", fontNegrita, Brushes.Black, x, y);
            e.Graphics.DrawString("Producto", fontNegrita, Brushes.Black, x + 90, y);
            e.Graphics.DrawString("Cant", fontNegrita, Brushes.Black, x + 410, y);
            e.Graphics.DrawString("Costo", fontNegrita, Brushes.Black, x + 480, y);
            e.Graphics.DrawString("Total", fontNegrita, Brushes.Black, x + 580, y);

            y += 20;
            e.Graphics.DrawLine(Pens.Black, x, y, 760, y);
            y += 10;

            foreach (DataRow row in dtImpresion.Rows)
            {
                string codigo = row["Codigo"].ToString();
                string descripcion = row["Descripcion"].ToString();
                string cantidad = Convert.ToDecimal(row["Cantidad"]).ToString("0.00");
                string costo = Convert.ToDecimal(row["CostoUnitario"]).ToString("0.00");
                string totalLinea = Convert.ToDecimal(row["TotalLinea"]).ToString("0.00");

                e.Graphics.DrawString(codigo, fontNormal, Brushes.Black, x, y);
                e.Graphics.DrawString(descripcion, fontNormal, Brushes.Black, x + 90, y);
                e.Graphics.DrawString(cantidad, fontNormal, Brushes.Black, x + 410, y);
                e.Graphics.DrawString(costo, fontNormal, Brushes.Black, x + 480, y);
                e.Graphics.DrawString(totalLinea, fontNormal, Brushes.Black, x + 580, y);

                y += 20;
            }

            y += 10;
            e.Graphics.DrawLine(Pens.Black, x, y, 760, y);
            y += 20;

            e.Graphics.DrawString("SUBTOTAL: " + subtotal.ToString("0.00"), fontNormal, Brushes.Black, x + 470, y);
            y += 20;
            e.Graphics.DrawString("DESCUENTO: " + descuento.ToString("0.00"), fontNormal, Brushes.Black, x + 470, y);
            y += 20;
            e.Graphics.DrawString("IVA: " + iva.ToString("0.00"), fontNormal, Brushes.Black, x + 470, y);
            y += 25;
            e.Graphics.DrawString("TOTAL: " + total.ToString("0.00"), fontTitulo, Brushes.Black, x + 470, y);
        }
    }
}