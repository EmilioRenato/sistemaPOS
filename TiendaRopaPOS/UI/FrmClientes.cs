using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmClientes : Form
    {
        private int idClienteSeleccionado = 0;

        public FrmClientes()
        {
            InitializeComponent();

            btnBuscar.Click += btnBuscar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            dgvClientes.CellClick += dgvClientes_CellClick;
            txtBuscar.KeyDown += txtBuscar_KeyDown;

            this.Load += FrmClientes_Load;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            AplicarEstiloVisual();
            AplicarAnimaciones();
            CargarClientes();
            LimpiarCampos();
        }

        private void AplicarEstiloVisual()
        {
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 52, 54);
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvClientes.ColumnHeadersHeight = 34;

            dgvClientes.DefaultCellStyle.BackColor = Color.FromArgb(99, 110, 114);
            dgvClientes.DefaultCellStyle.ForeColor = Color.White;
            dgvClientes.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 82, 84);
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 82, 84);
            dgvClientes.GridColor = Color.FromArgb(178, 190, 195);
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.RowTemplate.Height = 30;

            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtDocumento.Font = new Font("Segoe UI", 10F);
            txtNombres.Font = new Font("Segoe UI", 10F);
            txtDireccion.Font = new Font("Segoe UI", 10F);
            txtTelefono.Font = new Font("Segoe UI", 10F);
            txtEmail.Font = new Font("Segoe UI", 10F);
        }

        private void AplicarAnimaciones()
        {
            btnBuscar.MouseEnter += (s, e) => btnBuscar.BackColor = Color.FromArgb(0, 98, 204);
            btnBuscar.MouseLeave += (s, e) => btnBuscar.BackColor = Color.FromArgb(9, 132, 227);

            btnNuevo.MouseEnter += (s, e) => btnNuevo.BackColor = Color.FromArgb(90, 75, 210);
            btnNuevo.MouseLeave += (s, e) => btnNuevo.BackColor = Color.FromArgb(108, 92, 231);

            btnGuardar.MouseEnter += (s, e) => btnGuardar.BackColor = Color.FromArgb(0, 150, 136);
            btnGuardar.MouseLeave += (s, e) => btnGuardar.BackColor = Color.FromArgb(0, 184, 148);

            btnActualizar.MouseEnter += (s, e) => btnActualizar.BackColor = Color.FromArgb(0, 98, 204);
            btnActualizar.MouseLeave += (s, e) => btnActualizar.BackColor = Color.FromArgb(9, 132, 227);

            btnLimpiar.MouseEnter += (s, e) => btnLimpiar.BackColor = Color.FromArgb(250, 177, 19);
            btnLimpiar.MouseLeave += (s, e) => btnLimpiar.BackColor = Color.FromArgb(253, 203, 110);
        }

        private void CargarClientes(string filtro = "")
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        IdCliente,
                        Documento,
                        Nombres,
                        Direccion,
                        Telefono,
                        Email,
                        CASE WHEN Estado = 1 THEN 'ACTIVO' ELSE 'INACTIVO' END AS Estado
                    FROM Clientes
                    WHERE Documento LIKE @Filtro
                       OR Nombres LIKE @Filtro
                       OR Telefono LIKE @Filtro
                    ORDER BY Nombres";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.SelectCommand.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvClientes.DataSource = dt;
                dgvClientes.AutoGenerateColumns = true;

                if (dgvClientes.Columns.Contains("IdCliente"))
                    dgvClientes.Columns["IdCliente"].Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientes(txtBuscar.Text.Trim());
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarClientes(txtBuscar.Text.Trim());
                e.SuppressKeyPress = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            idClienteSeleccionado = 0;

            txtDocumento.Clear();
            txtNombres.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            chkEstado.Checked = true;

            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;

            txtDocumento.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Ingrese nombres.");
                txtNombres.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string verificar = @"
                    SELECT COUNT(*)
                    FROM Clientes
                    WHERE Documento = @Documento
                      AND @Documento <> ''";

                SqlCommand cmdVerificar = new SqlCommand(verificar, cn);
                cmdVerificar.Parameters.AddWithValue("@Documento", txtDocumento.Text.Trim());

                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("Ya existe un cliente con ese documento.");
                    return;
                }

                string query = @"
                    INSERT INTO Clientes
                    (Documento, Nombres, Direccion, Telefono, Email, Estado, FechaCreacion)
                    VALUES
                    (@Documento, @Nombres, @Direccion, @Telefono, @Email, @Estado, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Documento", txtDocumento.Text.Trim());
                cmd.Parameters.AddWithValue("@Nombres", txtNombres.Text.Trim());
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cliente guardado correctamente.");
            CargarClientes();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            if (!ValidarCampos())
                return;

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string verificar = @"
                    SELECT COUNT(*)
                    FROM Clientes
                    WHERE Documento = @Documento
                      AND IdCliente <> @IdCliente
                      AND @Documento <> ''";

                SqlCommand cmdVerificar = new SqlCommand(verificar, cn);
                cmdVerificar.Parameters.AddWithValue("@Documento", txtDocumento.Text.Trim());
                cmdVerificar.Parameters.AddWithValue("@IdCliente", idClienteSeleccionado);

                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("Ya existe otro cliente con ese documento.");
                    return;
                }

                string query = @"
                    UPDATE Clientes
                    SET Documento = @Documento,
                        Nombres = @Nombres,
                        Direccion = @Direccion,
                        Telefono = @Telefono,
                        Email = @Email,
                        Estado = @Estado
                    WHERE IdCliente = @IdCliente";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdCliente", idClienteSeleccionado);
                cmd.Parameters.AddWithValue("@Documento", txtDocumento.Text.Trim());
                cmd.Parameters.AddWithValue("@Nombres", txtNombres.Text.Trim());
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cliente actualizado correctamente.");
            CargarClientes();
            LimpiarCampos();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (!dgvClientes.Columns.Contains("IdCliente"))
                return;

            object valorId = dgvClientes.Rows[e.RowIndex].Cells["IdCliente"].Value;

            if (valorId == null || valorId == DBNull.Value)
                return;

            if (!int.TryParse(valorId.ToString(), out idClienteSeleccionado))
                return;

            txtDocumento.Text = dgvClientes.Rows[e.RowIndex].Cells["Documento"]?.Value?.ToString() ?? "";
            txtNombres.Text = dgvClientes.Rows[e.RowIndex].Cells["Nombres"]?.Value?.ToString() ?? "";
            txtDireccion.Text = dgvClientes.Rows[e.RowIndex].Cells["Direccion"]?.Value?.ToString() ?? "";
            txtTelefono.Text = dgvClientes.Rows[e.RowIndex].Cells["Telefono"]?.Value?.ToString() ?? "";
            txtEmail.Text = dgvClientes.Rows[e.RowIndex].Cells["Email"]?.Value?.ToString() ?? "";
            chkEstado.Checked = (dgvClientes.Rows[e.RowIndex].Cells["Estado"]?.Value?.ToString() ?? "") == "ACTIVO";

            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
        }
    }
}