using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TiendaRopaPOS.Clases;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            btnIngresar.Click += btnIngresar_Click;
            btnIngresar.MouseEnter += btnIngresar_MouseEnter;
            btnIngresar.MouseLeave += btnIngresar_MouseLeave;

            txtUsuario.TextChanged += txtUsuario_TextChanged;
            txtClave.TextChanged += txtClave_TextChanged;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
            RestaurarEstiloCampos();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            RestaurarEstiloCampos();

            bool hayError = false;

            if (string.IsNullOrWhiteSpace(usuario))
            {
                txtUsuario.BackColor = Color.MistyRose;
                hayError = true;
            }

            if (string.IsNullOrWhiteSpace(clave))
            {
                txtClave.BackColor = Color.MistyRose;
                hayError = true;
            }

            if (hayError)
            {
                MessageBox.Show("Ingrese usuario y clave.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblLoader.Visible = true;
            btnIngresar.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    string query = @"
                        SELECT u.IdUsuario, u.IdRol, u.Nombre, u.Apellido, u.Usuario
                        FROM Usuarios u
                        WHERE u.Usuario = @Usuario
                          AND u.Clave = @Clave
                          AND u.Estado = 1";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Clave", clave);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        SesionUsuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        SesionUsuario.IdRol = Convert.ToInt32(dr["IdRol"]);
                        SesionUsuario.Nombre = dr["Nombre"].ToString();
                        SesionUsuario.Apellido = dr["Apellido"].ToString();
                        SesionUsuario.Usuario = dr["Usuario"].ToString();

                        FrmMenuPrincipal menu = new FrmMenuPrincipal();
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o clave incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally
            {
                lblLoader.Visible = false;
                btnIngresar.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void chkVer_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !chkVer.Checked;
        }

        private void btnIngresar_MouseEnter(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.FromArgb(30, 140, 50);
        }

        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.FromArgb(40, 167, 69);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
                txtUsuario.BackColor = Color.White;
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtClave.Text))
                txtClave.BackColor = Color.White;
        }

        private void RestaurarEstiloCampos()
        {
            txtUsuario.BackColor = Color.White;
            txtClave.BackColor = Color.White;
        }
    }
}