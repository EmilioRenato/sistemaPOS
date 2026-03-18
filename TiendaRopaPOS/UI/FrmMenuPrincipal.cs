using System;
using System.Windows.Forms;
using TiendaRopaPOS.Clases;
using TiendaRopaPOS.ServiciosSri;
using TiendaRopaPOS.Sri;

namespace TiendaRopaPOS.UI
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioActivo.Text = "👤 Usuario: " + SesionUsuario.Nombre + " " + SesionUsuario.Apellido;

            bool cargada = ConfiguracionCajaLocal.CargarConfiguracion();

            if (!cargada)
            {
                MessageBox.Show("Esta máquina no tiene punto de emisión configurado.");

                using (FrmConfigCaja frm = new FrmConfigCaja())
                {
                    frm.ShowDialog();
                }

                cargada = ConfiguracionCajaLocal.CargarConfiguracion();

                if (!cargada)
                {
                    MessageBox.Show("Debe configurar un punto de emisión para continuar.");

                    SesionUsuario.CerrarSesion();

                    FrmLogin login = new FrmLogin();
                    login.Show();

                    this.Hide();
                    return;
                }
            }

            MostrarCajaActiva();
            AplicarPermisosMenu();

            // Abrir facturación por defecto solo si tiene permiso
            if (PermisosService.TienePermiso("FACTURACION_VER"))
            {
                if (SesionUsuario.IdCajaEmision <= 0)
                {
                    MessageBox.Show("Esta máquina no tiene punto de emisión configurado.");
                    return;
                }

                SesionVenta.Limpiar();

                using (FrmSeleccionVendedor frmVendedor = new FrmSeleccionVendedor())
                {
                    if (frmVendedor.ShowDialog() == DialogResult.OK)
                    {
                        AbrirFormularioEnPanel(new FrmFacturacion());
                    }
                }
            }
        }

        private void AplicarPermisosMenu()
        {
            usuariosToolStripMenuItem.Visible = PermisosService.TienePermiso("USUARIOS_VER");
            dashboardToolStripMenuItem.Visible = PermisosService.TienePermiso("DASHBOARD_VER");
            configuracionToolStripMenuItem.Visible = PermisosService.TienePermiso("CONFIGURACION_VER");

            productosToolStripMenuItem.Visible = PermisosService.TienePermiso("PRODUCTOS_VER");
            clientesToolStripMenuItem.Visible = PermisosService.TienePermiso("CLIENTES_VER");
            vendedoresToolStripMenuItem.Visible = PermisosService.TienePermiso("VENDEDORES_VER");
            proveedoresToolStripMenuItem.Visible = PermisosService.TienePermiso("PROVEEDORES_VER");

            facturacionToolStripMenuItem.Visible = PermisosService.TienePermiso("FACTURACION_VER");
            consultaDeVentasToolStripMenuItem.Visible = PermisosService.TienePermiso("VENTAS_VER");

            comprasToolStripMenuItem1.Visible = PermisosService.TienePermiso("COMPRAS_VER");
            consultaDeComprasToolStripMenuItem.Visible = PermisosService.TienePermiso("COMPRAS_VER");
            pagoDeComprasToolStripMenuItem.Visible = PermisosService.TienePermiso("PAGOS_COMPRAS_VER");

            inventarioToolStripMenuItem2.Visible = PermisosService.TienePermiso("INVENTARIO_VER");
            kardexToolStripMenuItem.Visible = PermisosService.TienePermiso("KARDEX_VER");

            temporalToolStripMenuItem.Visible = PermisosService.TienePermiso("SRI_ENVIAR");
            temporal2ToolStripMenuItem.Visible = PermisosService.TienePermiso("SRI_RECONSULTAR");
        }

        private void MostrarCajaActiva()
        {
            this.Text = "Sistema ER - Inventario SASA - Caja: " + SesionUsuario.NombreCajaEmision;
            lblCajaActiva.Text = "🏪 Caja activa: " + SesionUsuario.NombreCajaEmision;
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

                this.Hide();
            }
        }

        private void productosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("PRODUCTOS_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Productos.");
                return;
            }

            AbrirFormularioEnPanel(new FrmProductos());
        }

        private void inventarioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("INVENTARIO_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Inventario.");
                return;
            }

            AbrirFormularioEnPanel(new FrmInventario());
        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("CLIENTES_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Clientes.");
                return;
            }

            AbrirFormularioEnPanel(new FrmClientes());
        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("FACTURACION_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Facturación.");
                return;
            }

            if (SesionUsuario.IdCajaEmision <= 0)
            {
                MessageBox.Show("Esta máquina no tiene punto de emisión configurado.");
                return;
            }

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
            if (!PermisosService.TienePermiso("VENTAS_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Consulta de Ventas.");
                return;
            }

            AbrirFormularioEnPanel(new FrmVentasConsulta());
        }

        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("VENDEDORES_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Vendedores.");
                return;
            }

            AbrirFormularioEnPanel(new FrmVendedores());
        }

        private void proveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("PROVEEDORES_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Proveedores.");
                return;
            }

            AbrirFormularioEnPanel(new FrmProveedores());
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("COMPRAS_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Compras.");
                return;
            }

            AbrirFormularioEnPanel(new FrmCompras());
        }

        private void inventarioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("INVENTARIO_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Inventario.");
                return;
            }

            AbrirFormularioEnPanel(new FrmInventario());
        }

        private void consultaDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("COMPRAS_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Consulta de Compras.");
                return;
            }

            AbrirFormularioEnPanel(new FrmConsultaCompras());
        }

        private void pagoDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("PAGOS_COMPRAS_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Pagos de Compras.");
                return;
            }

            AbrirFormularioEnPanel(new FrmPagosCompras());
        }

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("KARDEX_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Kardex.");
                return;
            }

            AbrirFormularioEnPanel(new FrmKardex());
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("USUARIOS_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Usuarios.");
                return;
            }

            AbrirFormularioEnPanel(new FrmUsuarios());
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("DASHBOARD_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder al Dashboard.");
                return;
            }

            AbrirFormularioEnPanel(new FrmDashboard());
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("CONFIGURACION_VER"))
            {
                MessageBox.Show("No tiene permisos para acceder a Configuración.");
                return;
            }

            AbrirFormularioEnPanel(new FrmConfiguracionSistema());
        }

        private void temporalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("SRI_ENVIAR"))
            {
                MessageBox.Show("No tiene permisos para enviar comprobantes al SRI.");
                return;
            }

            try
            {
                int idVenta = 7;
                int idCajaEmision = 2;

                SriFacturaProcesoService procesoService = new SriFacturaProcesoService();
                var resultado = procesoService.ProcesarFactura(idVenta, idCajaEmision);

                SriRecepcionService recepcionService = new SriRecepcionService();
                var recepcion = recepcionService.EnviarComprobante(resultado.RutaXmlFirmado);

                SriFacturaRepository repo = new SriFacturaRepository();
                repo.ActualizarEstadoRecepcion(
                    idVenta,
                    recepcion.Estado,
                    recepcion.Mensaje,
                    recepcion.InformacionAdicional
                );

                SriAutorizacionService autorizacionService = new SriAutorizacionService();
                SriAutorizacionResultado autorizacion = null;

                int intentos = 0;

                while (intentos < 10)
                {
                    System.Threading.Thread.Sleep(3000);

                    autorizacion = autorizacionService.ConsultarAutorizacion(resultado.ClaveAcceso);

                    if (autorizacion != null && !string.IsNullOrWhiteSpace(autorizacion.Estado))
                    {
                        string estado = autorizacion.Estado.Trim().ToUpper();

                        if (estado == "AUTORIZADO" || estado == "NO AUTORIZADO")
                            break;
                    }

                    intentos++;
                }

                if (autorizacion == null)
                    autorizacion = new SriAutorizacionResultado();

                if (string.IsNullOrWhiteSpace(autorizacion.Estado))
                    autorizacion.Estado = "EN PROCESO";

                string numeroAutorizacionMostrar = string.IsNullOrWhiteSpace(autorizacion.NumeroAutorizacion)
                    ? "EN PROCESO"
                    : autorizacion.NumeroAutorizacion;

                repo.ActualizarEstadoAutorizacion(
                    idVenta,
                    autorizacion.Estado,
                    autorizacion.NumeroAutorizacion,
                    autorizacion.FechaAutorizacionTexto,
                    autorizacion.Mensaje,
                    autorizacion.InformacionAdicional,
                    autorizacion.Comprobante
                );

                MessageBox.Show(
                    "RECEPCIÓN:\n" + (recepcion.Estado ?? "") +
                    "\n\nMENSAJE RECEPCIÓN:\n" + (recepcion.Mensaje ?? "") +
                    "\n\nINFO RECEPCIÓN:\n" + (recepcion.InformacionAdicional ?? "SIN INFO") +
                    "\n\n--------------------------------------" +
                    "\n\nAUTORIZACIÓN:\n" + (autorizacion.Estado ?? "SIN RESPUESTA") +
                    "\n\nNÚMERO AUTORIZACIÓN:\n" + numeroAutorizacionMostrar +
                    "\n\nFECHA AUTORIZACIÓN:\n" + (autorizacion.FechaAutorizacionTexto ?? "") +
                    "\n\nMENSAJE AUTORIZACIÓN:\n" + (autorizacion.Mensaje ?? "") +
                    "\n\nINFO AUTORIZACIÓN:\n" + (autorizacion.InformacionAdicional ?? ""),
                    "RESPUESTA SRI",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "ERROR SRI:\n\n" + ex.Message + "\n\n" + ex.StackTrace,
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void temporal2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.TienePermiso("SRI_RECONSULTAR"))
            {
                MessageBox.Show("No tiene permisos para reconsultar autorización SRI.");
                return;
            }

            try
            {
                int idVenta = 7;

                SriFacturaRepository repo = new SriFacturaRepository();
                string claveAcceso = repo.ObtenerClaveAccesoPorVenta(idVenta);

                if (string.IsNullOrWhiteSpace(claveAcceso))
                {
                    MessageBox.Show("No existe clave de acceso para esta venta.");
                    return;
                }

                MessageBox.Show(
                    "VENTA: " + idVenta +
                    "\n\nCLAVE ACCESO:\n" + claveAcceso,
                    "DATOS DE RECONSULTA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                SriAutorizacionService autorizacionService = new SriAutorizacionService();
                SriAutorizacionResultado autorizacion = autorizacionService.ConsultarAutorizacion(claveAcceso);

                if (autorizacion == null)
                    autorizacion = new SriAutorizacionResultado();

                if (string.IsNullOrWhiteSpace(autorizacion.Estado))
                    autorizacion.Estado = "EN PROCESO";

                string numeroAutorizacionMostrar = string.IsNullOrWhiteSpace(autorizacion.NumeroAutorizacion)
                    ? "EN PROCESO"
                    : autorizacion.NumeroAutorizacion;

                repo.ActualizarEstadoAutorizacion(
                    idVenta,
                    autorizacion.Estado,
                    autorizacion.NumeroAutorizacion,
                    autorizacion.FechaAutorizacionTexto,
                    autorizacion.Mensaje,
                    autorizacion.InformacionAdicional,
                    autorizacion.Comprobante
                );

                System.IO.File.WriteAllText(
                    @"C:\FACTURAS\respuesta_autorizacion.xml",
                    autorizacion.XmlRespuesta ?? ""
                );

                MessageBox.Show(
                    "AUTORIZACIÓN:\n" + (autorizacion.Estado ?? "SIN RESPUESTA") +
                    "\n\nNÚMERO AUTORIZACIÓN:\n" + numeroAutorizacionMostrar +
                    "\n\nFECHA AUTORIZACIÓN:\n" + (autorizacion.FechaAutorizacionTexto ?? "") +
                    "\n\nMENSAJE:\n" + (autorizacion.Mensaje ?? "") +
                    "\n\nINFO:\n" + (autorizacion.InformacionAdicional ?? "") +
                    "\n\nXML guardado en:\nC:\\FACTURAS\\respuesta_autorizacion.xml",
                    "RECONSULTA SRI",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "ERROR RECONSULTA SRI:\n\n" + ex.Message,
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}