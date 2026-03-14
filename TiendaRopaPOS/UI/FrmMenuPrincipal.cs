using System;
using System.Windows.Forms;
using TiendaRopaPOS.Clases;

namespace TiendaRopaPOS.UI
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.Load += FrmMenuPrincipal_Load;
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioActivo.Text = "Usuario activo: " + SesionUsuario.Nombre + " " + SesionUsuario.Apellido;
            bool cargada = ConfiguracionCajaLocal.CargarConfiguracion();

            if (!cargada)
            {
                MessageBox.Show("Esta máquina no tiene punto de emisión configurado.");
                FrmConfigCaja frm = new FrmConfigCaja();
                frm.ShowDialog();
            }
        }

        private void AbrirFormularioEnPanel(Form frm)
        {
            panelContenedor.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(frm);
            panelContenedor.Tag = frm;
            frm.Show();
        }


        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Desea cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                SesionUsuario.CerrarSesion();

                FrmLogin login = new FrmLogin();
                login.Show();

                this.Close();
            }
        }


        private void productosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmProductos());
        }

        private void inventarioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmInventario());
        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmClientes());
        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SesionVenta.Limpiar();

            using (FrmSeleccionVendedor frmVendedor = new FrmSeleccionVendedor())
            {
                if (frmVendedor.ShowDialog() == DialogResult.OK)
                {
                    AbrirFormularioEnPanel(new FrmFacturacion());
                }
            }
        }

        private void consultaDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmVentasConsulta());
        }

        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmVendedores());
        }

        private void proveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmProveedores());
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmCompras());
        }

        private void inventarioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmInventario());
        }

        private void consultaDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmConsultaCompras());
        }

        private void pagoDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmPagosCompras());
        }
    }

}