using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TiendaRopaPOS.Clases;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmConfiguracionSistema : Form
    {
        private int idConfiguracion = 0;

        public FrmConfiguracionSistema()
        {
            InitializeComponent();

            this.Load += FrmConfiguracionSistema_Load;
            btnGuardar.Click += btnGuardar_Click;
        }

        private void FrmConfiguracionSistema_Load(object sender, EventArgs e)
        {
            AplicarEstiloVisual();
            AplicarAnimaciones();
            CargarBodegas();
            CargarConfiguracion();
        }

        private void AplicarEstiloVisual()
        {
            txtNombreNegocio.Font = new Font("Segoe UI", 10F);
            txtRucNegocio.Font = new Font("Segoe UI", 10F);
            txtIvaPorcentaje.Font = new Font("Segoe UI", 10F);
            txtRutaRespaldo.Font = new Font("Segoe UI", 10F);
            txtObservacion.Font = new Font("Segoe UI", 10F);

            cbBodegaStockGeneral.Font = new Font("Segoe UI", 10F);
            cbAmbienteSRI.Font = new Font("Segoe UI", 10F);

            grpNegocio.ForeColor = Color.White;
            grpInventario.ForeColor = Color.White;
            grpSri.ForeColor = Color.White;
            grpRespaldo.ForeColor = Color.White;
        }

        private void AplicarAnimaciones()
        {
            btnGuardar.MouseEnter += (s, e) =>
                btnGuardar.BackColor = Color.FromArgb(0, 150, 136);

            btnGuardar.MouseLeave += (s, e) =>
                btnGuardar.BackColor = Color.FromArgb(0, 184, 148);
        }

        private void CargarBodegas()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT IdBodega, Nombre
                    FROM Bodegas
                    WHERE Estado = 1
                    ORDER BY Nombre";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbBodegaStockGeneral.DataSource = dt;
                cbBodegaStockGeneral.DisplayMember = "Nombre";
                cbBodegaStockGeneral.ValueMember = "IdBodega";
            }
        }

        private void CargarConfiguracion()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = "SELECT TOP 1 * FROM ConfiguracionSistema ORDER BY IdConfiguracion";
                SqlCommand cmd = new SqlCommand(query, cn);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    idConfiguracion = Convert.ToInt32(dr["IdConfiguracion"]);
                    txtNombreNegocio.Text = dr["NombreNegocio"]?.ToString() ?? "";
                    txtRucNegocio.Text = dr["RucNegocio"]?.ToString() ?? "";

                    if (dr["IdBodegaStockGeneral"] != DBNull.Value)
                        cbBodegaStockGeneral.SelectedValue = Convert.ToInt32(dr["IdBodegaStockGeneral"]);

                    txtIvaPorcentaje.Text = Convert.ToDecimal(dr["IvaPorcentaje"]).ToString("0.00");
                    cbAmbienteSRI.Text = dr["AmbienteSRI"]?.ToString() ?? "PRUEBAS";
                    txtRutaRespaldo.Text = dr["RutaRespaldo"]?.ToString() ?? "";
                    txtObservacion.Text = dr["Observacion"]?.ToString() ?? "";
                }
                else
                {
                    cbAmbienteSRI.SelectedIndex = 0;
                    txtIvaPorcentaje.Text = "15.00";
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreNegocio.Text))
            {
                MessageBox.Show("Ingrese el nombre del negocio.");
                txtNombreNegocio.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRucNegocio.Text))
            {
                MessageBox.Show("Ingrese el RUC del negocio.");
                txtRucNegocio.Focus();
                return false;
            }

            if (cbBodegaStockGeneral.SelectedValue == null)
            {
                MessageBox.Show("Seleccione la bodega de stock general.");
                cbBodegaStockGeneral.Focus();
                return false;
            }

            if (!decimal.TryParse(txtIvaPorcentaje.Text.Trim(), out decimal iva) || iva < 0)
            {
                MessageBox.Show("Ingrese un IVA válido.");
                txtIvaPorcentaje.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbAmbienteSRI.Text))
            {
                MessageBox.Show("Seleccione el ambiente SRI.");
                cbAmbienteSRI.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            decimal iva = Convert.ToDecimal(txtIvaPorcentaje.Text.Trim());

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query;

                if (idConfiguracion == 0)
                {
                    query = @"
                        INSERT INTO ConfiguracionSistema
                        (
                            NombreNegocio,
                            RucNegocio,
                            IdBodegaStockGeneral,
                            IvaPorcentaje,
                            AmbienteSRI,
                            RutaRespaldo,
                            Observacion,
                            FechaActualizacion
                        )
                        VALUES
                        (
                            @NombreNegocio,
                            @RucNegocio,
                            @IdBodegaStockGeneral,
                            @IvaPorcentaje,
                            @AmbienteSRI,
                            @RutaRespaldo,
                            @Observacion,
                            GETDATE()
                        )";
                }
                else
                {
                    query = @"
                        UPDATE ConfiguracionSistema
                        SET NombreNegocio = @NombreNegocio,
                            RucNegocio = @RucNegocio,
                            IdBodegaStockGeneral = @IdBodegaStockGeneral,
                            IvaPorcentaje = @IvaPorcentaje,
                            AmbienteSRI = @AmbienteSRI,
                            RutaRespaldo = @RutaRespaldo,
                            Observacion = @Observacion,
                            FechaActualizacion = GETDATE()
                        WHERE IdConfiguracion = @IdConfiguracion";
                }

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@NombreNegocio", txtNombreNegocio.Text.Trim());
                cmd.Parameters.AddWithValue("@RucNegocio", txtRucNegocio.Text.Trim());
                cmd.Parameters.AddWithValue("@IdBodegaStockGeneral", cbBodegaStockGeneral.SelectedValue);
                cmd.Parameters.AddWithValue("@IvaPorcentaje", iva);
                cmd.Parameters.AddWithValue("@AmbienteSRI", cbAmbienteSRI.Text.Trim());
                cmd.Parameters.AddWithValue("@RutaRespaldo", txtRutaRespaldo.Text.Trim());
                cmd.Parameters.AddWithValue("@Observacion", txtObservacion.Text.Trim());

                if (idConfiguracion != 0)
                    cmd.Parameters.AddWithValue("@IdConfiguracion", idConfiguracion);

                cmd.ExecuteNonQuery();
            }

            ConfiguracionSistema.IdBodegaStockGeneral = Convert.ToInt32(cbBodegaStockGeneral.SelectedValue);

            MessageBox.Show("Configuración guardada correctamente.");
            CargarConfiguracion();
        }
    }
}