using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmProveedores : Form
    {

        int idProveedor = 0;

        public FrmProveedores()
        {
            InitializeComponent();

            Load += FrmProveedores_Load;

            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            dgvProveedores.CellClick += dgvProveedores_CellClick;
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        void CargarProveedores(string filtro = "")
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {

                string query = @"

SELECT
IdProveedor,
RazonSocial,
RUC,
Telefono,
Email,
Direccion,
Estado
FROM Proveedores
WHERE RazonSocial LIKE @filtro
OR RUC LIKE @filtro
ORDER BY RazonSocial";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);

                da.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvProveedores.DataSource = dt;

                dgvProveedores.Columns["IdProveedor"].Visible = false;

            }
        }

        void Limpiar()
        {
            idProveedor = 0;

            txtRazon.Clear();
            txtRUC.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();

            chkEstado.Checked = true;

            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {

                cn.Open();

                string query = @"

INSERT INTO Proveedores
(
RazonSocial,
RUC,
Telefono,
Email,
Direccion,
Estado,
FechaCreacion
)

VALUES
(
@Razon,
@RUC,
@Telefono,
@Email,
@Direccion,
@Estado,
GETDATE()
)";

                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@Razon", txtRazon.Text);

                cmd.Parameters.AddWithValue("@RUC", txtRUC.Text);

                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);

                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);

                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();

            }

            MessageBox.Show("Proveedor guardado");

            CargarProveedores();

            Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {

                cn.Open();

                string query = @"

UPDATE Proveedores SET

RazonSocial=@Razon,
RUC=@RUC,
Telefono=@Telefono,
Email=@Email,
Direccion=@Direccion,
Estado=@Estado

WHERE IdProveedor=@Id";

                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@Id", idProveedor);

                cmd.Parameters.AddWithValue("@Razon", txtRazon.Text);

                cmd.Parameters.AddWithValue("@RUC", txtRUC.Text);

                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);

                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);

                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();

            }

            MessageBox.Show("Proveedor actualizado");

            CargarProveedores();

            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProveedores(txtBuscar.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            idProveedor = Convert.ToInt32(
                dgvProveedores.Rows[e.RowIndex].Cells["IdProveedor"].Value);

            txtRazon.Text =
            dgvProveedores.Rows[e.RowIndex].Cells["RazonSocial"].Value.ToString();

            txtRUC.Text =
            dgvProveedores.Rows[e.RowIndex].Cells["RUC"].Value.ToString();

            txtTelefono.Text =
            dgvProveedores.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();

            txtEmail.Text =
            dgvProveedores.Rows[e.RowIndex].Cells["Email"].Value.ToString();

            txtDireccion.Text =
            dgvProveedores.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();

            chkEstado.Checked =
            Convert.ToBoolean(
            dgvProveedores.Rows[e.RowIndex].Cells["Estado"].Value);

            btnGuardar.Enabled = false;

            btnActualizar.Enabled = true;

        }

    }
}