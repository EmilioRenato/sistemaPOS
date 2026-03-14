using System;
using System.Data.SqlClient;
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
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show("Ingrese usuario y clave.");
                return;
            }

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
                    MessageBox.Show("Usuario o clave incorrectos.");
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}