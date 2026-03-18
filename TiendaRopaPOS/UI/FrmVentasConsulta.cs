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

            AplicarEstiloVisual();
            AplicarAnimaciones();
            CargarVentas();
        }

        private void AplicarEstiloVisual()
        {
            dgvVentas.EnableHeadersVisualStyles = false;
            dgvVentas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 52, 54);
            dgvVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVentas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvVentas.ColumnHeadersHeight = 34;

            dgvVentas.DefaultCellStyle.BackColor = Color.FromArgb(99, 110, 114);
            dgvVentas.DefaultCellStyle.ForeColor = Color.White;
            dgvVentas.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvVentas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 52, 54);
            dgvVentas.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvVentas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 82, 84);
            dgvVentas.GridColor = Color.FromArgb(178, 190, 195);
            dgvVentas.BorderStyle = BorderStyle.None;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.RowTemplate.Height = 30;

            txtBuscar.Font = new Font("Segoe UI", 10F);
            dtDesde.Font = new Font("Segoe UI", 10F);
            dtHasta.Font = new Font("Segoe UI", 10F);
        }

        private void AplicarAnimaciones()
        {
            btnBuscar.MouseEnter += (s, e) => btnBuscar.BackColor = Color.FromArgb(0, 98, 204);
            btnBuscar.MouseLeave += (s, e) => btnBuscar.BackColor = Color.FromArgb(9, 132, 227);

            btnDetalle.MouseEnter += (s, e) => btnDetalle.BackColor = Color.FromArgb(0, 150, 136);
            btnDetalle.MouseLeave += (s, e) => btnDetalle.BackColor = Color.FromArgb(0, 184, 148);

            btnAnular.MouseEnter += (s, e) => btnAnular.BackColor = Color.FromArgb(180, 35, 40);
            btnAnular.MouseLeave += (s, e) => btnAnular.BackColor = Color.FromArgb(214, 48, 49);

            btnReimprimir.MouseEnter += (s, e) => btnReimprimir.BackColor = Color.FromArgb(90, 75, 210);
            btnReimprimir.MouseLeave += (s, e) => btnReimprimir.BackColor = Color.FromArgb(108, 92, 231);
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
                        ISNULL(be.Nombre, '') AS CajaEmision,
                        mp.NombreMetodo AS MetodoPago,
                        v.Subtotal,
                        v.Iva,
                        v.Total,
                        v.FechaCreacion,
                        v.Estado
                    FROM Ventas v
                    INNER JOIN Clientes c ON v.IdCliente = c.IdCliente
                    LEFT JOIN Vendedores ven ON v.IdVendedor = ven.IdVendedor
                    LEFT JOIN Bodegas be ON v.IdCajaEmision = be.IdBodega
                    INNER JOIN MetodosPago mp ON v.IdMetodoPago = mp.IdMetodoPago
                    WHERE v.FechaCreacion >= @Desde
                      AND v.FechaCreacion < @Hasta
                      AND (
                            v.NumeroDocumento LIKE @Buscar
                            OR c.Nombres LIKE @Buscar
                            OR ISNULL(ven.Nombre,'') LIKE @Buscar
                            OR ISNULL(be.Nombre,'') LIKE @Buscar
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

                if (dgvVentas.Columns.Contains("CajaEmision"))
                    dgvVentas.Columns["CajaEmision"].HeaderText = "Caja";

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
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(120, 35, 40);
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(160, 45, 55);
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else if (estado == "PROFORMA")
            {
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(180, 120, 20);
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 150, 30);
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else
            {
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(0, 120, 90);
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                dgvVentas.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 110);
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