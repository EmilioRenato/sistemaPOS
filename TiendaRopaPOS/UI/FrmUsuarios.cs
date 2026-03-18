using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmUsuarios : Form
    {
        private int idUsuarioSeleccionado = 0;

        public FrmUsuarios()
        {
            InitializeComponent();

            btnBuscar.Click += btnBuscar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            txtBuscar.KeyDown += txtBuscar_KeyDown;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;

            this.Load += FrmUsuarios_Load;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            AplicarEstiloVisual();
            AplicarAnimaciones();
            CargarRoles();
            CargarUsuarios();
            LimpiarCampos();
        }

        private void AplicarEstiloVisual()
        {
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 52, 54);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvUsuarios.ColumnHeadersHeight = 34;

            dgvUsuarios.DefaultCellStyle.BackColor = Color.FromArgb(99, 110, 114);
            dgvUsuarios.DefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 82, 84);
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 82, 84);
            dgvUsuarios.GridColor = Color.FromArgb(178, 190, 195);
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.RowTemplate.Height = 30;

            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtApellido.Font = new Font("Segoe UI", 10F);
            txtUsuario.Font = new Font("Segoe UI", 10F);
            txtClave.Font = new Font("Segoe UI", 10F);
            cbRol.Font = new Font("Segoe UI", 10F);
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

        private void CargarRoles()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT IdRol, NombreRol
                    FROM Roles
                    WHERE Estado = 1
                    ORDER BY NombreRol";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbRol.DataSource = dt;
                cbRol.DisplayMember = "NombreRol";
                cbRol.ValueMember = "IdRol";
                cbRol.SelectedIndex = -1;
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarUsuarios(txtBuscar.Text.Trim());
                e.SuppressKeyPress = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuarios(txtBuscar.Text.Trim());
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
            idUsuarioSeleccionado = 0;

            cbRol.SelectedIndex = -1;
            txtNombre.Clear();
            txtApellido.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            chkEstado.Checked = true;

            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;

            cbRol.Focus();
        }

        private void CargarUsuarios(string filtro = "")
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT
                        u.IdUsuario,
                        r.NombreRol,
                        u.Nombre,
                        u.Apellido,
                        u.Usuario,
                        CASE WHEN u.Estado = 1 THEN 'ACTIVO' ELSE 'INACTIVO' END AS Estado
                    FROM Usuarios u
                    INNER JOIN Roles r ON u.IdRol = r.IdRol
                    WHERE u.Nombre LIKE @Filtro
                       OR u.Apellido LIKE @Filtro
                       OR u.Usuario LIKE @Filtro
                       OR r.NombreRol LIKE @Filtro
                    ORDER BY u.Nombre, u.Apellido";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.SelectCommand.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvUsuarios.DataSource = dt;

                if (dgvUsuarios.Columns.Contains("IdUsuario"))
                    dgvUsuarios.Columns["IdUsuario"].Visible = false;

                if (dgvUsuarios.Columns.Contains("NombreRol"))
                    dgvUsuarios.Columns["NombreRol"].HeaderText = "Rol";
            }
        }

        private bool ValidarCampos()
        {
            if (cbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rol.");
                cbRol.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre.");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Ingrese el usuario.");
                txtUsuario.Focus();
                return false;
            }

            if (idUsuarioSeleccionado == 0 && string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Ingrese la clave.");
                txtClave.Focus();
                return false;
            }

            return true;
        }

        private bool ExisteUsuario(string usuario, int idExcluir = 0)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"
                    SELECT COUNT(*)
                    FROM Usuarios
                    WHERE Usuario = @Usuario
                      AND IdUsuario <> @IdUsuario";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Usuario", usuario.Trim());
                cmd.Parameters.AddWithValue("@IdUsuario", idExcluir);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            if (ExisteUsuario(txtUsuario.Text))
            {
                MessageBox.Show("Ya existe un usuario con ese nombre.");
                txtUsuario.Focus();
                return;
            }

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"
                    INSERT INTO Usuarios
                    (
                        IdRol,
                        Nombre,
                        Apellido,
                        Usuario,
                        Clave,
                        Estado,
                        FechaCreacion
                    )
                    VALUES
                    (
                        @IdRol,
                        @Nombre,
                        @Apellido,
                        @Usuario,
                        @Clave,
                        @Estado,
                        GETDATE()
                    )";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdRol", cbRol.SelectedValue);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text.Trim());
                cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text.Trim());
                cmd.Parameters.AddWithValue("@Clave", txtClave.Text.Trim());
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Usuario guardado correctamente.");
            CargarUsuarios();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            if (!ValidarCampos())
                return;

            if (ExisteUsuario(txtUsuario.Text, idUsuarioSeleccionado))
            {
                MessageBox.Show("Ya existe otro usuario con ese nombre.");
                txtUsuario.Focus();
                return;
            }

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"
                    UPDATE Usuarios
                    SET IdRol = @IdRol,
                        Nombre = @Nombre,
                        Apellido = @Apellido,
                        Usuario = @Usuario,
                        Estado = @Estado
                    WHERE IdUsuario = @IdUsuario";

                if (!string.IsNullOrWhiteSpace(txtClave.Text.Trim()))
                {
                    query = @"
                        UPDATE Usuarios
                        SET IdRol = @IdRol,
                            Nombre = @Nombre,
                            Apellido = @Apellido,
                            Usuario = @Usuario,
                            Clave = @Clave,
                            Estado = @Estado
                        WHERE IdUsuario = @IdUsuario";
                }

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuarioSeleccionado);
                cmd.Parameters.AddWithValue("@IdRol", cbRol.SelectedValue);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text.Trim());
                cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text.Trim());
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                if (!string.IsNullOrWhiteSpace(txtClave.Text.Trim()))
                    cmd.Parameters.AddWithValue("@Clave", txtClave.Text.Trim());

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Usuario actualizado correctamente.");
            CargarUsuarios();
            LimpiarCampos();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string usuario = dgvUsuarios.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT TOP 1 *
                    FROM Usuarios
                    WHERE Usuario = @Usuario";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Usuario", usuario);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    idUsuarioSeleccionado = Convert.ToInt32(dr["IdUsuario"]);
                    cbRol.SelectedValue = Convert.ToInt32(dr["IdRol"]);
                    txtNombre.Text = dr["Nombre"].ToString();
                    txtApellido.Text = dr["Apellido"].ToString();
                    txtUsuario.Text = dr["Usuario"].ToString();
                    txtClave.Text = "";
                    chkEstado.Checked = Convert.ToBoolean(dr["Estado"]);

                    btnGuardar.Enabled = false;
                    btnActualizar.Enabled = true;
                }
            }
        }
    }
}