using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmPagosCompras : Form
    {
        public FrmPagosCompras()
        {
            InitializeComponent();

            this.Load += FrmPagosCompras_Load;
            btnBuscar.Click += btnBuscar_Click;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            dgvComprasPendientes.CellClick += dgvComprasPendientes_CellClick;
            txtBuscar.KeyDown += txtBuscar_KeyDown;

            dgvComprasPendientes.CellFormatting += dgvComprasPendientes_CellFormatting;
        }

        private void FrmPagosCompras_Load(object sender, EventArgs e)
        {
            AplicarEstiloVisual();
            AplicarAnimaciones();

            CargarMetodosPago();
            CargarComprasPendientes();
            txtSaldoPendiente.Text = "0.00";
            txtValorPagar.Text = "0.00";
        }

        private void AplicarEstiloVisual()
        {
            dgvComprasPendientes.EnableHeadersVisualStyles = false;
            dgvComprasPendientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 52, 54);
            dgvComprasPendientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvComprasPendientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvComprasPendientes.ColumnHeadersHeight = 34;

            dgvComprasPendientes.DefaultCellStyle.BackColor = Color.FromArgb(99, 110, 114);
            dgvComprasPendientes.DefaultCellStyle.ForeColor = Color.White;
            dgvComprasPendientes.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvComprasPendientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 82, 84);
            dgvComprasPendientes.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvComprasPendientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 82, 84);
            dgvComprasPendientes.GridColor = Color.FromArgb(178, 190, 195);
            dgvComprasPendientes.BorderStyle = BorderStyle.None;
            dgvComprasPendientes.RowHeadersVisible = false;
            dgvComprasPendientes.RowTemplate.Height = 30;
        }

        private void AplicarAnimaciones()
        {
            btnBuscar.MouseEnter += (s, e) => btnBuscar.BackColor = Color.FromArgb(0, 98, 204);
            btnBuscar.MouseLeave += (s, e) => btnBuscar.BackColor = Color.FromArgb(9, 132, 227);

            btnRegistrarPago.MouseEnter += (s, e) => btnRegistrarPago.BackColor = Color.FromArgb(0, 150, 136);
            btnRegistrarPago.MouseLeave += (s, e) => btnRegistrarPago.BackColor = Color.FromArgb(0, 184, 148);
        }

        private void CargarMetodosPago()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT IdMetodoPago, NombreMetodo
                    FROM MetodosPago
                    WHERE Estado = 1
                    ORDER BY NombreMetodo";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbMetodoPago.DataSource = dt;
                cbMetodoPago.DisplayMember = "NombreMetodo";
                cbMetodoPago.ValueMember = "IdMetodoPago";
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarComprasPendientes();
                e.SuppressKeyPress = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarComprasPendientes();
        }

        private void CargarComprasPendientes()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT
                        c.IdCompra,
                        ISNULL(c.NumeroDocumento,'') AS NumeroDocumento,
                        p.RazonSocial AS Proveedor,
                        c.Total,
                        ISNULL(SUM(pc.ValorPagado),0) AS Pagado,
                        c.Total - ISNULL(SUM(pc.ValorPagado),0) AS SaldoPendiente,
                        c.FechaDocumento,
                        c.FechaVencimiento,
                        CASE WHEN c.Pagada = 1 THEN 'PAGADA' ELSE 'PENDIENTE' END AS EstadoPago
                    FROM Compras c
                    INNER JOIN Proveedores p ON c.IdProveedor = p.IdProveedor
                    LEFT JOIN PagosCompras pc ON c.IdCompra = pc.IdCompra AND pc.Estado = 1
                    WHERE c.Estado = 1
                      AND (
                            ISNULL(c.NumeroDocumento,'') LIKE @Buscar
                            OR p.RazonSocial LIKE @Buscar
                          )
                    GROUP BY
                        c.IdCompra,
                        c.NumeroDocumento,
                        p.RazonSocial,
                        c.Total,
                        c.FechaDocumento,
                        c.FechaVencimiento,
                        c.Pagada
                    HAVING c.Total - ISNULL(SUM(pc.ValorPagado),0) > 0
                    ORDER BY c.IdCompra DESC";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Buscar", "%" + txtBuscar.Text.Trim() + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvComprasPendientes.DataSource = dt;

                if (dgvComprasPendientes.Columns.Contains("IdCompra"))
                    dgvComprasPendientes.Columns["IdCompra"].Visible = false;

                if (dgvComprasPendientes.Columns.Contains("NumeroDocumento"))
                    dgvComprasPendientes.Columns["NumeroDocumento"].HeaderText = "Documento";

                if (dgvComprasPendientes.Columns.Contains("Proveedor"))
                    dgvComprasPendientes.Columns["Proveedor"].HeaderText = "Proveedor";

                if (dgvComprasPendientes.Columns.Contains("SaldoPendiente"))
                    dgvComprasPendientes.Columns["SaldoPendiente"].HeaderText = "Saldo";

                if (dgvComprasPendientes.Columns.Contains("FechaDocumento"))
                    dgvComprasPendientes.Columns["FechaDocumento"].HeaderText = "Fecha";

                if (dgvComprasPendientes.Columns.Contains("FechaVencimiento"))
                    dgvComprasPendientes.Columns["FechaVencimiento"].HeaderText = "Vence";

                if (dgvComprasPendientes.Columns.Contains("EstadoPago"))
                    dgvComprasPendientes.Columns["EstadoPago"].HeaderText = "Pago";

                foreach (string col in new[] { "Total", "Pagado", "SaldoPendiente" })
                {
                    if (dgvComprasPendientes.Columns.Contains(col))
                        dgvComprasPendientes.Columns[col].DefaultCellStyle.Format = "0.00";
                }
            }
        }

        private void dgvComprasPendientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (!dgvComprasPendientes.Columns.Contains("EstadoPago"))
                return;

            var row = dgvComprasPendientes.Rows[e.RowIndex];

            string estadoPago = row.Cells["EstadoPago"].Value?.ToString().Trim().ToUpper() ?? "";
            decimal saldo = 0m;
            DateTime fechaVencimiento = DateTime.MinValue;

            if (row.Cells["SaldoPendiente"].Value != null)
                decimal.TryParse(row.Cells["SaldoPendiente"].Value.ToString(), out saldo);

            if (row.Cells["FechaVencimiento"].Value != null && row.Cells["FechaVencimiento"].Value != DBNull.Value)
                DateTime.TryParse(row.Cells["FechaVencimiento"].Value.ToString(), out fechaVencimiento);

            if (estadoPago == "PAGADA")
            {
                row.DefaultCellStyle.BackColor = Color.Honeydew;
                row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                row.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
                row.DefaultCellStyle.SelectionForeColor = Color.White;
                return;
            }

            if (fechaVencimiento != DateTime.MinValue && fechaVencimiento.Date < DateTime.Today && saldo > 0)
            {
                row.DefaultCellStyle.BackColor = Color.MistyRose;
                row.DefaultCellStyle.ForeColor = Color.DarkRed;
                row.DefaultCellStyle.SelectionBackColor = Color.IndianRed;
                row.DefaultCellStyle.SelectionForeColor = Color.White;
                return;
            }

            row.DefaultCellStyle.BackColor = Color.LemonChiffon;
            row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
            row.DefaultCellStyle.SelectionBackColor = Color.Goldenrod;
            row.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void dgvComprasPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtSaldoPendiente.Text = dgvComprasPendientes.Rows[e.RowIndex].Cells["SaldoPendiente"].Value.ToString();
            txtValorPagar.Text = dgvComprasPendientes.Rows[e.RowIndex].Cells["SaldoPendiente"].Value.ToString();
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (dgvComprasPendientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una compra.");
                return;
            }

            if (cbMetodoPago.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un método de pago.");
                return;
            }

            if (!decimal.TryParse(txtValorPagar.Text.Trim(), out decimal valorPagar) || valorPagar <= 0)
            {
                MessageBox.Show("Ingrese un valor de pago válido.");
                txtValorPagar.Focus();
                return;
            }

            decimal saldoPendiente = Convert.ToDecimal(dgvComprasPendientes.CurrentRow.Cells["SaldoPendiente"].Value);

            if (valorPagar > saldoPendiente)
            {
                MessageBox.Show("El valor a pagar no puede ser mayor al saldo pendiente.");
                return;
            }

            int idCompra = Convert.ToInt32(dgvComprasPendientes.CurrentRow.Cells["IdCompra"].Value);
            int idMetodoPago = Convert.ToInt32(cbMetodoPago.SelectedValue);
            decimal nuevoSaldo = saldoPendiente - valorPagar;

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                using (SqlTransaction tx = cn.BeginTransaction())
                {
                    try
                    {
                        string insertQuery = @"
                            INSERT INTO PagosCompras
                            (
                                IdCompra,
                                IdMetodoPago,
                                FechaPago,
                                ValorPagado,
                                SaldoPendiente,
                                Observacion,
                                Estado
                            )
                            VALUES
                            (
                                @IdCompra,
                                @IdMetodoPago,
                                GETDATE(),
                                @ValorPagado,
                                @SaldoPendiente,
                                '',
                                1
                            )";

                        SqlCommand cmdInsert = new SqlCommand(insertQuery, cn, tx);
                        cmdInsert.Parameters.AddWithValue("@IdCompra", idCompra);
                        cmdInsert.Parameters.AddWithValue("@IdMetodoPago", idMetodoPago);
                        cmdInsert.Parameters.AddWithValue("@ValorPagado", valorPagar);
                        cmdInsert.Parameters.AddWithValue("@SaldoPendiente", nuevoSaldo);
                        cmdInsert.ExecuteNonQuery();

                        if (nuevoSaldo <= 0)
                        {
                            string updateCompra = @"
                                UPDATE Compras
                                SET Pagada = 1
                                WHERE IdCompra = @IdCompra";

                            SqlCommand cmdUpdate = new SqlCommand(updateCompra, cn, tx);
                            cmdUpdate.Parameters.AddWithValue("@IdCompra", idCompra);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        tx.Commit();

                        MessageBox.Show("Pago registrado correctamente.");
                        CargarComprasPendientes();
                        txtSaldoPendiente.Text = "0.00";
                        txtValorPagar.Text = "0.00";
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error al registrar pago: " + ex.Message);
                    }
                }
            }
        }
    }
}