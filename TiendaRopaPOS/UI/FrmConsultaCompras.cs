using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmConsultaCompras : Form
    {
        public FrmConsultaCompras()
        {
            InitializeComponent();

            this.Load += FrmConsultaCompras_Load;
            btnBuscar.Click += btnBuscar_Click;
            btnVerDetalle.Click += btnVerDetalle_Click;
            btnIrPagos.Click += btnIrPagos_Click;
            txtBuscar.KeyDown += txtBuscar_KeyDown;

            dgvCompras.CellFormatting += dgvCompras_CellFormatting;
        }

        private void FrmConsultaCompras_Load(object sender, EventArgs e)
        {
            AplicarEstiloVisual();
            AplicarAnimaciones();

            dtDesde.Value = DateTime.Today.AddMonths(-1);
            dtHasta.Value = DateTime.Today;
            CargarCompras();
        }

        private void AplicarEstiloVisual()
        {
            dgvCompras.EnableHeadersVisualStyles = false;
            dgvCompras.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 52, 54);
            dgvCompras.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCompras.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvCompras.ColumnHeadersHeight = 34;

            dgvCompras.DefaultCellStyle.BackColor = Color.FromArgb(99, 110, 114);
            dgvCompras.DefaultCellStyle.ForeColor = Color.White;
            dgvCompras.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvCompras.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 82, 84);
            dgvCompras.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvCompras.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 82, 84);
            dgvCompras.GridColor = Color.FromArgb(178, 190, 195);
            dgvCompras.BorderStyle = BorderStyle.None;
            dgvCompras.RowHeadersVisible = false;
            dgvCompras.RowTemplate.Height = 30;
        }

        private void AplicarAnimaciones()
        {
            btnBuscar.MouseEnter += (s, e) => btnBuscar.BackColor = Color.FromArgb(0, 98, 204);
            btnBuscar.MouseLeave += (s, e) => btnBuscar.BackColor = Color.FromArgb(9, 132, 227);

            btnVerDetalle.MouseEnter += (s, e) => btnVerDetalle.BackColor = Color.FromArgb(0, 98, 204);
            btnVerDetalle.MouseLeave += (s, e) => btnVerDetalle.BackColor = Color.FromArgb(9, 132, 227);

            btnIrPagos.MouseEnter += (s, e) => btnIrPagos.BackColor = Color.FromArgb(0, 150, 136);
            btnIrPagos.MouseLeave += (s, e) => btnIrPagos.BackColor = Color.FromArgb(0, 184, 148);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarCompras();
                e.SuppressKeyPress = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarCompras();
        }

        private void CargarCompras()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT
                        c.IdCompra,
                        ISNULL(c.NumeroDocumento,'') AS NumeroDocumento,
                        p.RazonSocial AS Proveedor,
                        b.Nombre AS Bodega,
                        c.FechaDocumento,
                        c.Subtotal,
                        c.Descuento,
                        c.Iva,
                        c.Total,
                        c.DiasCredito,
                        c.FechaVencimiento,
                        CASE WHEN c.Pagada = 1 THEN 'PAGADA' ELSE 'PENDIENTE' END AS EstadoPago,
                        CASE WHEN c.Estado = 1 THEN 'ACTIVA' ELSE 'INACTIVA' END AS Estado
                    FROM Compras c
                    INNER JOIN Proveedores p ON c.IdProveedor = p.IdProveedor
                    INNER JOIN Bodegas b ON c.IdBodega = b.IdBodega
                    WHERE c.FechaDocumento >= @Desde
                      AND c.FechaDocumento <= @Hasta
                      AND (
                            ISNULL(c.NumeroDocumento,'') LIKE @Buscar
                            OR p.RazonSocial LIKE @Buscar
                            OR b.Nombre LIKE @Buscar
                          )
                    ORDER BY c.IdCompra DESC";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Desde", dtDesde.Value.Date);
                cmd.Parameters.AddWithValue("@Hasta", dtHasta.Value.Date);
                cmd.Parameters.AddWithValue("@Buscar", "%" + txtBuscar.Text.Trim() + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvCompras.DataSource = dt;

                if (dgvCompras.Columns.Contains("IdCompra"))
                    dgvCompras.Columns["IdCompra"].Visible = false;

                if (dgvCompras.Columns.Contains("NumeroDocumento"))
                    dgvCompras.Columns["NumeroDocumento"].HeaderText = "Documento";

                if (dgvCompras.Columns.Contains("Proveedor"))
                    dgvCompras.Columns["Proveedor"].HeaderText = "Proveedor";

                if (dgvCompras.Columns.Contains("Bodega"))
                    dgvCompras.Columns["Bodega"].HeaderText = "Bodega";

                if (dgvCompras.Columns.Contains("FechaDocumento"))
                    dgvCompras.Columns["FechaDocumento"].HeaderText = "Fecha";

                if (dgvCompras.Columns.Contains("DiasCredito"))
                    dgvCompras.Columns["DiasCredito"].HeaderText = "Días crédito";

                if (dgvCompras.Columns.Contains("EstadoPago"))
                    dgvCompras.Columns["EstadoPago"].HeaderText = "Pago";

                if (dgvCompras.Columns.Contains("FechaVencimiento"))
                    dgvCompras.Columns["FechaVencimiento"].HeaderText = "Vence";

                if (dgvCompras.Columns.Contains("Estado"))
                    dgvCompras.Columns["Estado"].HeaderText = "Estado";

                if (dgvCompras.Columns.Contains("Subtotal"))
                    dgvCompras.Columns["Subtotal"].DefaultCellStyle.Format = "0.00";

                if (dgvCompras.Columns.Contains("Descuento"))
                    dgvCompras.Columns["Descuento"].DefaultCellStyle.Format = "0.00";

                if (dgvCompras.Columns.Contains("Iva"))
                    dgvCompras.Columns["Iva"].DefaultCellStyle.Format = "0.00";

                if (dgvCompras.Columns.Contains("Total"))
                    dgvCompras.Columns["Total"].DefaultCellStyle.Format = "0.00";
            }
        }

        private void dgvCompras_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (!dgvCompras.Columns.Contains("EstadoPago") || dgvCompras.Rows[e.RowIndex].Cells["EstadoPago"].Value == null)
                return;

            string estadoPago = dgvCompras.Rows[e.RowIndex].Cells["EstadoPago"].Value.ToString().Trim().ToUpper();
            string estado = dgvCompras.Columns.Contains("Estado") && dgvCompras.Rows[e.RowIndex].Cells["Estado"].Value != null
                ? dgvCompras.Rows[e.RowIndex].Cells["Estado"].Value.ToString().Trim().ToUpper()
                : "";

            if (estado == "INACTIVA")
            {
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.IndianRed;
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else if (estadoPago == "PAGADA")
            {
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Honeydew;
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else
            {
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LemonChiffon;
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Goldenrod;
                dgvCompras.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvCompras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una compra.");
                return;
            }

            int idCompra = Convert.ToInt32(dgvCompras.CurrentRow.Cells["IdCompra"].Value);

            FrmDetalleCompra frm = new FrmDetalleCompra(idCompra);
            frm.ShowDialog();
        }

        private void btnIrPagos_Click(object sender, EventArgs e)
        {
            FrmPagosCompras frm = new FrmPagosCompras();
            frm.ShowDialog();
        }
    }
}