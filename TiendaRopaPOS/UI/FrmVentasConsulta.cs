using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmVentasConsulta : Form
    {
        public FrmVentasConsulta()
        {
            InitializeComponent();

            this.Load += FrmVentasConsulta_Load;
            btnBuscar.Click += btnBuscar_Click;
            btnDetalle.Click += btnDetalle_Click;
            btnAnular.Click += btnAnular_Click;
            btnReimprimir.Click += btnReimprimir_Click;
            txtBuscar.KeyDown += txtBuscar_KeyDown;

            dgvVentas.CellFormatting += dgvVentas_CellFormatting;
            dgvVentas.SelectionChanged += dgvVentas_SelectionChanged;
        }

        private void FrmVentasConsulta_Load(object sender, EventArgs e)
        {
            dtDesde.Value = DateTime.Today;
            dtHasta.Value = DateTime.Today;

            CargarVentas();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarVentas();
                e.SuppressKeyPress = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void CargarVentas()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT
                        v.IdVenta,
                        v.NumeroDocumento,
                        v.TipoDocumento,
                        c.Nombres AS Cliente,
                        ISNULL(ven.Nombre, '') AS Vendedor,
                        mp.NombreMetodo AS MetodoPago,
                        v.Subtotal,
                        v.Iva,
                        v.Total,
                        v.FechaCreacion,
                        v.Estado
                    FROM Ventas v
                    INNER JOIN Clientes c ON v.IdCliente = c.IdCliente
                    LEFT JOIN Vendedores ven ON v.IdVendedor = ven.IdVendedor
                    INNER JOIN MetodosPago mp ON v.IdMetodoPago = mp.IdMetodoPago
                    WHERE v.FechaCreacion >= @Desde
                      AND v.FechaCreacion < @Hasta
                      AND (
                            v.NumeroDocumento LIKE @Buscar
                            OR c.Nombres LIKE @Buscar
                            OR ISNULL(ven.Nombre,'') LIKE @Buscar
                            OR v.TipoDocumento LIKE @Buscar
                            OR v.Estado LIKE @Buscar
                          )
                    ORDER BY v.IdVenta DESC";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Desde", dtDesde.Value.Date);
                cmd.Parameters.AddWithValue("@Hasta", dtHasta.Value.Date.AddDays(1));
                cmd.Parameters.AddWithValue("@Buscar", "%" + txtBuscar.Text.Trim() + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvVentas.DataSource = dt;

                if (dgvVentas.Columns.Contains("IdVenta"))
                    dgvVentas.Columns["IdVenta"].Visible = false;

                if (dgvVentas.Columns.Contains("NumeroDocumento"))
                    dgvVentas.Columns["NumeroDocumento"].HeaderText = "Documento";

                if (dgvVentas.Columns.Contains("TipoDocumento"))
                    dgvVentas.Columns["TipoDocumento"].HeaderText = "Tipo";

                if (dgvVentas.Columns.Contains("Cliente"))
                    dgvVentas.Columns["Cliente"].HeaderText = "Cliente";

                if (dgvVentas.Columns.Contains("Vendedor"))
                    dgvVentas.Columns["Vendedor"].HeaderText = "Vendedor";

                if (dgvVentas.Columns.Contains("MetodoPago"))
                    dgvVentas.Columns["MetodoPago"].HeaderText = "Pago";

                if (dgvVentas.Columns.Contains("FechaCreacion"))
                    dgvVentas.Columns["FechaCreacion"].HeaderText = "Fecha";

                if (dgvVentas.Columns.Contains("Estado"))
                    dgvVentas.Columns["Estado"].HeaderText = "Estado";

                if (dgvVentas.Columns.Contains("Subtotal"))
                    dgvVentas.Columns["Subtotal"].DefaultCellStyle.Format = "0.00";

                if (dgvVentas.Columns.Contains("Iva"))
                    dgvVentas.Columns["Iva"].DefaultCellStyle.Format = "0.00";

                if (dgvVentas.Columns.Contains("Total"))
                    dgvVentas.Columns["Total"].DefaultCellStyle.Format = "0.00";
            }

            ActualizarBotonesSegunEstado();
        }

        private void dgvVentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvVentas.Rows[e.RowIndex].Cells["Estado"].Value == null)
                return;

            string estado = dgvVentas.Rows[e.RowIndex].Cells["Estado"].Value.ToString().Trim().ToUpper();

            if (estado == "ANULADA")
            {
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.IndianRed;
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else if (estado == "PROFORMA")
            {
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Goldenrod;
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else
            {
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Honeydew;
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonesSegunEstado();
        }

        private void ActualizarBotonesSegunEstado()
        {
            if (dgvVentas.CurrentRow == null)
            {
                btnDetalle.Enabled = false;
                btnAnular.Enabled = false;
                btnReimprimir.Enabled = false;
                return;
            }

            btnDetalle.Enabled = true;
            btnReimprimir.Enabled = true;

            string estado = dgvVentas.CurrentRow.Cells["Estado"].Value?.ToString().Trim().ToUpper() ?? "";
            btnAnular.Enabled = estado != "ANULADA";
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta.");
                return;
            }

            int idVenta = Convert.ToInt32(dgvVentas.CurrentRow.Cells["IdVenta"].Value);

            FrmDetalleVenta frm = new FrmDetalleVenta(idVenta, false);
            frm.ShowDialog();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta.");
                return;
            }

            int idVenta = Convert.ToInt32(dgvVentas.CurrentRow.Cells["IdVenta"].Value);
            string numeroDocumento = dgvVentas.CurrentRow.Cells["NumeroDocumento"].Value.ToString();
            string tipoDocumento = dgvVentas.CurrentRow.Cells["TipoDocumento"].Value.ToString().Trim().ToUpper();
            string estado = dgvVentas.CurrentRow.Cells["Estado"].Value.ToString().Trim().ToUpper();

            if (estado == "ANULADA")
            {
                MessageBox.Show("La venta ya está anulada.");
                return;
            }

            DialogResult r = MessageBox.Show(
                $"¿Desea anular el documento {numeroDocumento}?",
                "Confirmar anulación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection cn = new Conexion().ObtenerConexion())
                {
                    cn.Open();

                    using (SqlTransaction tx = cn.BeginTransaction())
                    {
                        try
                        {
                            if (tipoDocumento != "PROFORMA")
                            {
                                DataTable detalle = ObtenerDetalleVenta(cn, tx, idVenta);

                                foreach (DataRow row in detalle.Rows)
                                {
                                    int idProducto = Convert.ToInt32(row["IdProducto"]);
                                    int idBodega = Convert.ToInt32(row["IdBodega"]);
                                    decimal cantidad = Convert.ToDecimal(row["Cantidad"]);
                                    decimal precioUnitario = Convert.ToDecimal(row["PrecioUnitario"]);

                                    DevolverInventario(cn, tx, idProducto, idBodega, cantidad);
                                    InsertarMovimientoReverso(cn, tx, idProducto, idBodega, cantidad, precioUnitario, numeroDocumento, tipoDocumento);
                                }
                            }

                            MarcarVentaComoAnulada(cn, tx, idVenta);

                            tx.Commit();

                            MessageBox.Show("Venta anulada correctamente.");
                            CargarVentas();
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                            MessageBox.Show("Error al anular: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
            }
        }

        private DataTable ObtenerDetalleVenta(SqlConnection cn, SqlTransaction tx, int idVenta)
        {
            string query = @"
                SELECT
                    IdProducto,
                    IdBodega,
                    Cantidad,
                    PrecioUnitario
                FROM DetalleVentas
                WHERE IdVenta = @IdVenta";

            SqlCommand cmd = new SqlCommand(query, cn, tx);
            cmd.Parameters.AddWithValue("@IdVenta", idVenta);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        private void DevolverInventario(SqlConnection cn, SqlTransaction tx, int idProducto, int idBodega, decimal cantidad)
        {
            string query = @"
                UPDATE Inventario
                SET Stock = Stock + @Cantidad,
                    FechaActualizacion = GETDATE()
                WHERE IdProducto = @IdProducto
                  AND IdBodega = @IdBodega";

            SqlCommand cmd = new SqlCommand(query, cn, tx);
            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            cmd.Parameters.AddWithValue("@IdBodega", idBodega);

            int filas = cmd.ExecuteNonQuery();

            if (filas == 0)
                throw new Exception("No se encontró inventario para devolver stock.");
        }

        private void InsertarMovimientoReverso(
            SqlConnection cn,
            SqlTransaction tx,
            int idProducto,
            int idBodega,
            decimal cantidad,
            decimal precioUnitario,
            string numeroDocumento,
            string tipoDocumento)
        {
            string query = @"
                INSERT INTO MovimientosInventario
                (
                    IdProducto,
                    IdBodega,
                    TipoMovimiento,
                    Cantidad,
                    CostoUnitario,
                    PrecioUnitario,
                    FechaMovimiento,
                    Referencia,
                    Observacion
                )
                VALUES
                (
                    @IdProducto,
                    @IdBodega,
                    @TipoMovimiento,
                    @Cantidad,
                    NULL,
                    @PrecioUnitario,
                    GETDATE(),
                    @Referencia,
                    @Observacion
                )";

            SqlCommand cmd = new SqlCommand(query, cn, tx);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            cmd.Parameters.AddWithValue("@IdBodega", idBodega);
            cmd.Parameters.AddWithValue("@TipoMovimiento", "ENTRADA");
            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
            cmd.Parameters.AddWithValue("@PrecioUnitario", precioUnitario);
            cmd.Parameters.AddWithValue("@Referencia", numeroDocumento);
            cmd.Parameters.AddWithValue("@Observacion", "ANULACION " + tipoDocumento);

            cmd.ExecuteNonQuery();
        }

        private void MarcarVentaComoAnulada(SqlConnection cn, SqlTransaction tx, int idVenta)
        {
            string query = @"
                UPDATE Ventas
                SET Estado = 'ANULADA',
                    Observacion = 'ANULADA ' + CONVERT(VARCHAR(19), GETDATE(), 120)
                WHERE IdVenta = @IdVenta";

            SqlCommand cmd = new SqlCommand(query, cn, tx);
            cmd.Parameters.AddWithValue("@IdVenta", idVenta);
            cmd.ExecuteNonQuery();
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta.");
                return;
            }

            int idVenta = Convert.ToInt32(dgvVentas.CurrentRow.Cells["IdVenta"].Value);

            FrmDetalleVenta frm = new FrmDetalleVenta(idVenta, true);
            frm.ShowDialog();
        }
        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}