using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TiendaRopaPOS.Clases;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmConfigCaja : Form
    {
        public FrmConfigCaja()
        {
            InitializeComponent();

            this.Load += FrmConfigCaja_Load;
            btnGuardar.Click += btnGuardar_Click;
        }

        private void FrmConfigCaja_Load(object sender, EventArgs e)
        {
            CargarCajas();
        }

        private void CargarCajas()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        IdBodega,
                        Nombre + ' - Est: ' + ISNULL(Establecimiento,'') + ' / Pto: ' + ISNULL(PuntoEmision,'') AS Caja
                    FROM Bodegas
                    WHERE Estado = 1
                    ORDER BY Nombre";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbCaja.DataSource = dt;
                cbCaja.DisplayMember = "Caja";
                cbCaja.ValueMember = "IdBodega";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbCaja.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una caja.");
                return;
            }

            int idCaja = Convert.ToInt32(cbCaja.SelectedValue);
            string nombreCaja = cbCaja.Text;

            ConfiguracionCajaLocal.GuardarConfiguracion(idCaja, nombreCaja);

            SesionUsuario.IdCajaEmision = idCaja;
            SesionUsuario.NombreCajaEmision = nombreCaja;

            MessageBox.Show("Configuración de caja guardada correctamente.");
            this.Close();
        }
    }
}