using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using TiendaRopaPOS.Clases;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmSeleccionVendedor : Form
    {
        public FrmSeleccionVendedor()
        {
            InitializeComponent();

            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;
            txtCodigoVendedor.TextChanged += txtCodigoVendedor_TextChanged;
        }

        private void txtCodigoVendedor_TextChanged(object sender, EventArgs e)
        {
            lblNombreVendedor.Text = "";
            BuscarVendedorVisual();
        }

        private void FrmSeleccionVendedor_Load(object sender, EventArgs e)
        {
            txtCodigoVendedor.Focus();
        }

        private void BuscarVendedorVisual()
        {
            string codigo = txtCodigoVendedor.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
                return;

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string query = @"
                    SELECT TOP 1 IdVendedor, Nombre, CodigoVendedor
                    FROM Vendedores
                    WHERE CodigoVendedor = @Codigo
                      AND Estado = 1";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblNombreVendedor.Text = dr["Nombre"].ToString();
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoVendedor.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese el código del vendedor.");
                txtCodigoVendedor.Focus();
                return;
            }

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string query = @"
                    SELECT TOP 1 IdVendedor, Nombre, CodigoVendedor
                    FROM Vendedores
                    WHERE CodigoVendedor = @Codigo
                      AND Estado = 1";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    SesionVenta.IdVendedor = Convert.ToInt32(dr["IdVendedor"]);
                    SesionVenta.NombreVendedor = dr["Nombre"].ToString();
                    SesionVenta.CodigoVendedor = dr["CodigoVendedor"].ToString();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Código de vendedor no válido.");
                    txtCodigoVendedor.Focus();
                    txtCodigoVendedor.SelectAll();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            SesionVenta.Limpiar();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}