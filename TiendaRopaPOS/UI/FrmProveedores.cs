using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            dgvProveedores.CellClick += dgvProveedores_CellClick;
            txtBuscar.KeyDown += txtBuscar_KeyDown;

            this.Load += FrmProveedores_Load;
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            AplicarEstilo();
            AplicarAnimaciones();
            CargarProveedores();
            Limpiar();
        }

        private void AplicarEstilo()
        {
            dgvProveedores.EnableHeadersVisualStyles = false;
            dgvProveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 52, 54);
            dgvProveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvProveedores.ColumnHeadersHeight = 34;

            dgvProveedores.DefaultCellStyle.BackColor = Color.FromArgb(99, 110, 114);
            dgvProveedores.DefaultCellStyle.ForeColor = Color.White;
            dgvProveedores.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvProveedores.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 82, 84);
            dgvProveedores.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 82, 84);
            dgvProveedores.GridColor = Color.FromArgb(178, 190, 195);
            dgvProveedores.BorderStyle = BorderStyle.None;
            dgvProveedores.RowHeadersVisible = false;
            dgvProveedores.RowTemplate.Height = 30;

            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtRazon.Font = new Font("Segoe UI", 10F);
            txtRUC.Font = new Font("Segoe UI", 10F);
            txtTelefono.Font = new Font("Segoe UI", 10F);
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtDireccion.Font = new Font("Segoe UI", 10F);
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

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarProveedores(txtBuscar.Text.Trim());
                e.SuppressKeyPress = true;
            }
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

                if (dgvProveedores.Columns.Contains("IdProveedor"))
                    dgvProveedores.Columns["IdProveedor"].Visible = false;

                if (dgvProveedores.Columns.Contains("RazonSocial"))
                    dgvProveedores.Columns["RazonSocial"].HeaderText = "Razón social";

                if (dgvProveedores.Columns.Contains("RUC"))
                    dgvProveedores.Columns["RUC"].HeaderText = "RUC";

                if (dgvProveedores.Columns.Contains("Telefono"))
                    dgvProveedores.Columns["Telefono"].HeaderText = "Teléfono";

                if (dgvProveedores.Columns.Contains("Email"))
                    dgvProveedores.Columns["Email"].HeaderText = "Email";

                if (dgvProveedores.Columns.Contains("Direccion"))
                    dgvProveedores.Columns["Direccion"].HeaderText = "Dirección";

                if (dgvProveedores.Columns.Contains("Estado"))
                    dgvProveedores.Columns["Estado"].HeaderText = "Estado";
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

            txtRazon.Focus();
        }

        bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtRazon.Text))
            {
                MessageBox.Show("Ingrese razón social.");
                txtRazon.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRUC.Text))
            {
                MessageBox.Show("Ingrese RUC.");
                txtRUC.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

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

                cmd.Parameters.AddWithValue("@Razon", txtRazon.Text.Trim());
                cmd.Parameters.AddWithValue("@RUC", txtRUC.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Proveedor guardado.");
            CargarProveedores();
            Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idProveedor == 0)
            {
                MessageBox.Show("Seleccione un proveedor.");
                return;
            }

            if (!Validar())
                return;

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"
UPDATE Proveedores SET
    RazonSocial = @Razon,
    RUC = @RUC,
    Telefono = @Telefono,
    Email = @Email,
    Direccion = @Direccion,
    Estado = @Estado
WHERE IdProveedor = @Id";

                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@Id", idProveedor);
                cmd.Parameters.AddWithValue("@Razon", txtRazon.Text.Trim());
                cmd.Parameters.AddWithValue("@RUC", txtRUC.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Proveedor actualizado.");
            CargarProveedores();
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProveedores(txtBuscar.Text.Trim());
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
            if (e.RowIndex < 0)
                return;

            object valorId = dgvProveedores.Rows[e.RowIndex].Cells["IdProveedor"].Value;

            if (valorId == null || valorId == DBNull.Value)
                return;

            idProveedor = Convert.ToInt32(valorId);

            txtRazon.Text = dgvProveedores.Rows[e.RowIndex].Cells["RazonSocial"]?.Value?.ToString() ?? "";
            txtRUC.Text = dgvProveedores.Rows[e.RowIndex].Cells["RUC"]?.Value?.ToString() ?? "";
            txtTelefono.Text = dgvProveedores.Rows[e.RowIndex].Cells["Telefono"]?.Value?.ToString() ?? "";
            txtEmail.Text = dgvProveedores.Rows[e.RowIndex].Cells["Email"]?.Value?.ToString() ?? "";
            txtDireccion.Text = dgvProveedores.Rows[e.RowIndex].Cells["Direccion"]?.Value?.ToString() ?? "";

            object valorEstado = dgvProveedores.Rows[e.RowIndex].Cells["Estado"]?.Value;
            if (valorEstado != null && valorEstado != DBNull.Value)
            {
                string textoEstado = valorEstado.ToString().Trim().ToUpper();
                chkEstado.Checked = textoEstado == "TRUE" || textoEstado == "1" || textoEstado == "ACTIVO";
            }
            else
            {
                chkEstado.Checked = false;
            }

            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
        }
    }
}