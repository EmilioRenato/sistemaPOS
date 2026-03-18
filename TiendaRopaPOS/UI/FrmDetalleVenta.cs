using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmDetalleVenta : Form
    {
        private readonly int idVenta;
        private readonly bool modoReimpresion;

        private string numeroDocumento = "";
        private string cliente = "";
        private string vendedor = "";
        private string metodoPago = "";
        private string totalTexto = "";
        private string tipoDocumento = "";
        private string cajaEmision = "";

        private DataTable dtImpresion = new DataTable();
        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog previewDialog1 = new PrintPreviewDialog();

        public FrmDetalleVenta(int venta, bool reimpresion)
        {
            InitializeComponent();

            idVenta = venta;
            modoReimpresion = reimpresion;

            btnImprimir.Click += btnImprimir_Click;

            printDocument1.PrintPage += printDocument1_PrintPage;
            previewDialog1.Document = printDocument1;
            previewDialog1.Width = 1000;
            previewDialog1.Height = 700;

            this.Load += FrmDetalleVenta_Load;
        }

        private void FrmDetalleVenta_Load(object sender, EventArgs e)
        {
            AplicarEstiloVisual();
            AplicarAnimaciones();
            CargarCabecera();
            CargarDetalleVenta();

            btnImprimir.Visible = modoReimpresion;
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
            btnImprimir.MouseEnter += (s, e) =>
            {
                btnImprimir.BackColor = Color.FromArgb(90, 75, 210);
            };

            btnImprimir.MouseLeave += (s, e) =>
            {
                btnImprimir.BackColor = Color.FromArgb(108, 92, 231);
            };
        }

        private void CargarCabecera()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT TOP 1
                        v.NumeroDocumento,
                        v.TipoDocumento,
                        c.Nombres AS Cliente,
                        ISNULL(ven.Nombre, '') AS Vendedor,
                        ISNULL(be.Nombre, '') AS CajaEmision,
                        mp.NombreMetodo AS MetodoPago,
                        v.Total
                    FROM Ventas v
                    INNER JOIN Clientes c ON v.IdCliente = c.IdCliente
                    LEFT JOIN Vendedores ven ON v.IdVendedor = ven.IdVendedor
                    LEFT JOIN Bodegas be ON v.IdCajaEmision = be.IdBodega
                    INNER JOIN MetodosPago mp ON v.IdMetodoPago = mp.IdMetodoPago
                    WHERE v.IdVenta = @IdVenta";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    numeroDocumento = dr["NumeroDocumento"].ToString();
                    tipoDocumento = dr["TipoDocumento"].ToString().Trim().ToUpper();
                    cliente = dr["Cliente"].ToString();
                    vendedor = dr["Vendedor"].ToString();
                    cajaEmision = dr["CajaEmision"].ToString();
                    metodoPago = dr["MetodoPago"].ToString();
                    totalTexto = Convert.ToDecimal(dr["Total"]).ToString("0.00");

                    lblDocumento.Text = "Documento: " + numeroDocumento + "  (" + tipoDocumento + ")";
                    lblCliente.Text = "Cliente: " + cliente;
                    lblVendedor.Text = "Vendedor: " + vendedor + " | Caja: " + cajaEmision;
                    lblMetodoPago.Text = "Método pago: " + metodoPago;
                    lblTotal.Text = "Total: " + totalTexto;

                    lblTitulo.Text = ObtenerTituloDocumento();
                }
            }
        }

        private string ObtenerTituloDocumento()
        {
            if (tipoDocumento == "FACTURA")
                return "REIMPRESIÓN DE FACTURA";

            if (tipoDocumento == "NOTA DE VENTA")
                return "REIMPRESIÓN DE NOTA DE VENTA";

            if (tipoDocumento == "PROFORMA")
                return "REIMPRESIÓN DE PROFORMA";

            return "REIMPRESIÓN DE DOCUMENTO";
        }

        private void CargarDetalleVenta()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT
                        p.Codigo,
                        p.Descripcion,
                        dv.Cantidad,
                        dv.PrecioUnitario,
                        dv.Descuento,
                        dv.Subtotal,
                        dv.Iva,
                        dv.TotalLinea
                    FROM DetalleVentas dv
                    INNER JOIN Productos p ON dv.IdProducto = p.IdProducto
                    WHERE dv.IdVenta = @IdVenta
                    ORDER BY dv.IdDetalleVenta";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);

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

                if (dgvDetalle.Columns.Contains("PrecioUnitario"))
                    dgvDetalle.Columns["PrecioUnitario"].HeaderText = "P.Unit";

                if (dgvDetalle.Columns.Contains("Descuento"))
                    dgvDetalle.Columns["Descuento"].HeaderText = "Desc";

                if (dgvDetalle.Columns.Contains("TotalLinea"))
                    dgvDetalle.Columns["TotalLinea"].HeaderText = "Total";

                if (dgvDetalle.Columns.Contains("Cantidad"))
                    dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "0.00";

                if (dgvDetalle.Columns.Contains("PrecioUnitario"))
                    dgvDetalle.Columns["PrecioUnitario"].DefaultCellStyle.Format = "0.00000";

                if (dgvDetalle.Columns.Contains("Descuento"))
                    dgvDetalle.Columns["Descuento"].DefaultCellStyle.Format = "0.00";

                if (dgvDetalle.Columns.Contains("Subtotal"))
                    dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "0.00";

                if (dgvDetalle.Columns.Contains("Iva"))
                    dgvDetalle.Columns["Iva"].DefaultCellStyle.Format = "0.00";

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

            int y = 40;
            int x = 40;

            e.Graphics.DrawString(ObtenerTituloDocumento(), fontTitulo, Brushes.Black, x, y);
            y += 35;

            e.Graphics.DrawString("Documento: " + numeroDocumento, fontNormal, Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Tipo: " + tipoDocumento, fontNormal, Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Caja: " + cajaEmision, fontNormal, Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Cliente: " + cliente, fontNormal, Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Vendedor: " + vendedor, fontNormal, Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Método pago: " + metodoPago, fontNormal, Brushes.Black, x, y);
            y += 30;

            e.Graphics.DrawString("Código", fontNegrita, Brushes.Black, x, y);
            e.Graphics.DrawString("Producto", fontNegrita, Brushes.Black, x + 90, y);
            e.Graphics.DrawString("Cant", fontNegrita, Brushes.Black, x + 420, y);
            e.Graphics.DrawString("P.Unit", fontNegrita, Brushes.Black, x + 490, y);
            e.Graphics.DrawString("Total", fontNegrita, Brushes.Black, x + 590, y);

            y += 20;
            e.Graphics.DrawLine(Pens.Black, x, y, 760, y);
            y += 10;

            foreach (DataRow row in dtImpresion.Rows)
            {
                string codigo = row["Codigo"].ToString();
                string descripcion = row["Descripcion"].ToString();
                string cantidad = Convert.ToDecimal(row["Cantidad"]).ToString("0.00");
                string precio = Convert.ToDecimal(row["PrecioUnitario"]).ToString("0.00");
                string totalLinea = Convert.ToDecimal(row["TotalLinea"]).ToString("0.00");

                e.Graphics.DrawString(codigo, fontNormal, Brushes.Black, x, y);
                e.Graphics.DrawString(descripcion, fontNormal, Brushes.Black, x + 90, y);
                e.Graphics.DrawString(cantidad, fontNormal, Brushes.Black, x + 420, y);
                e.Graphics.DrawString(precio, fontNormal, Brushes.Black, x + 490, y);
                e.Graphics.DrawString(totalLinea, fontNormal, Brushes.Black, x + 590, y);

                y += 20;
            }

            y += 10;
            e.Graphics.DrawLine(Pens.Black, x, y, 760, y);
            y += 20;

            e.Graphics.DrawString("TOTAL: " + totalTexto, fontTitulo, Brushes.Black, x + 470, y);
        }
    }
}