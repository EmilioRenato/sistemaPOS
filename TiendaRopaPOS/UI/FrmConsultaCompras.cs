using System;
using System.Data;
using System.Data.SqlClient;
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
        }

        private void FrmConsultaCompras_Load(object sender, EventArgs e)
        {
            dtDesde.Value = DateTime.Today.AddMonths(-1);
            dtHasta.Value = DateTime.Today;
            CargarCompras();
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

                if (dgvCompras.Columns.Contains("FechaDocumento"))
                    dgvCompras.Columns["FechaDocumento"].HeaderText = "Fecha";

                if (dgvCompras.Columns.Contains("EstadoPago"))
                    dgvCompras.Columns["EstadoPago"].HeaderText = "Pago";

                if (dgvCompras.Columns.Contains("FechaVencimiento"))
                    dgvCompras.Columns["FechaVencimiento"].HeaderText = "Vence";

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