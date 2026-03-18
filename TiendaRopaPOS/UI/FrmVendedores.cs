using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmVendedores : Form
    {
        private int idVendedorSeleccionado = 0;

        public FrmVendedores()
        {
            InitializeComponent();

            btnBuscar.Click += btnBuscar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            txtBuscar.KeyDown += txtBuscar_KeyDown;
            dgvVendedores.CellClick += dgvVendedores_CellClick;

            this.Load += FrmVendedores_Load;
        }

        private void FrmVendedores_Load(object sender, EventArgs e)
        {
            AplicarEstiloVisual();
            AplicarAnimaciones();
            CargarVendedores();
            LimpiarCampos();
        }

        private void AplicarEstiloVisual()
        {
            dgvVendedores.EnableHeadersVisualStyles = false;
            dgvVendedores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 52, 54);
            dgvVendedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVendedores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvVendedores.ColumnHeadersHeight = 34;

            dgvVendedores.DefaultCellStyle.BackColor = Color.FromArgb(99, 110, 114);
            dgvVendedores.DefaultCellStyle.ForeColor = Color.White;
            dgvVendedores.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvVendedores.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 82, 84);
            dgvVendedores.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvVendedores.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 82, 84);
            dgvVendedores.GridColor = Color.FromArgb(178, 190, 195);
            dgvVendedores.BorderStyle = BorderStyle.None;
            dgvVendedores.RowHeadersVisible = false;
            dgvVendedores.RowTemplate.Height = 30;

            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtCodigoVendedor.Font = new Font("Segoe UI", 10F);
            txtDocumento.Font = new Font("Segoe UI", 10F);
            txtAlias.Font = new Font("Segoe UI", 10F);
            txtComision.Font = new Font("Segoe UI", 10F);
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
                CargarVendedores(txtBuscar.Text.Trim());
                e.SuppressKeyPress = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarVendedores(txtBuscar.Text.Trim());
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
            idVendedorSeleccionado = 0;

            txtNombre.Clear();
            txtCodigoVendedor.Clear();
            txtDocumento.Clear();
            txtAlias.Clear();
            txtComision.Text = "0.00000";
            chkEstado.Checked = true;

            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;

            txtNombre.Focus();
        }

        private void CargarVendedores(string filtro = "")
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT
                        IdVendedor,
                        Nombre,
                        CodigoVendedor,
                        Documento,
                        Alias,
                        Comision,
                        CASE WHEN Estado = 1 THEN 'ACTIVO' ELSE 'INACTIVO' END AS Estado
                    FROM Vendedores
                    WHERE Nombre LIKE @Filtro
                       OR CodigoVendedor LIKE @Filtro
                       OR Documento LIKE @Filtro
                       OR Alias LIKE @Filtro
                    ORDER BY Nombre";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.SelectCommand.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvVendedores.DataSource = dt;

                if (dgvVendedores.Columns.Contains("IdVendedor"))
                    dgvVendedores.Columns["IdVendedor"].Visible = false;

                if (dgvVendedores.Columns.Contains("CodigoVendedor"))
                    dgvVendedores.Columns["CodigoVendedor"].HeaderText = "Código";

                if (dgvVendedores.Columns.Contains("Documento"))
                    dgvVendedores.Columns["Documento"].HeaderText = "Documento";

                if (dgvVendedores.Columns.Contains("Alias"))
                    dgvVendedores.Columns["Alias"].HeaderText = "Alias";

                if (dgvVendedores.Columns.Contains("Comision"))
                    dgvVendedores.Columns["Comision"].HeaderText = "Comisión";

                if (dgvVendedores.Columns.Contains("Comision"))
                    dgvVendedores.Columns["Comision"].DefaultCellStyle.Format = "0.00000";
            }
        }

        private bool ValidarCampos()
        {
            decimal comision;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre.");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCodigoVendedor.Text))
            {
                MessageBox.Show("Ingrese el código del vendedor.");
                txtCodigoVendedor.Focus();
                return false;
            }

            if (!decimal.TryParse(txtComision.Text.Trim(), out comision) || comision < 0)
            {
                MessageBox.Show("Ingrese una comisión válida.");
                txtComision.Focus();
                return false;
            }

            return true;
        }

        private bool ExisteCodigo(string codigo, int idExcluir = 0)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"
                    SELECT COUNT(*)
                    FROM Vendedores
                    WHERE CodigoVendedor = @Codigo
                      AND IdVendedor <> @IdVendedor";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Codigo", codigo.Trim());
                cmd.Parameters.AddWithValue("@IdVendedor", idExcluir);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            if (ExisteCodigo(txtCodigoVendedor.Text))
            {
                MessageBox.Show("Ya existe un vendedor con ese código.");
                txtCodigoVendedor.Focus();
                return;
            }

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"
                    INSERT INTO Vendedores
                    (
                        Nombre,
                        CodigoVendedor,
                        Documento,
                        Alias,
                        Comision,
                        Estado,
                        FechaCreacion
                    )
                    VALUES
                    (
                        @Nombre,
                        @CodigoVendedor,
                        @Documento,
                        @Alias,
                        @Comision,
                        @Estado,
                        GETDATE()
                    )";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@CodigoVendedor", txtCodigoVendedor.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@Documento", txtDocumento.Text.Trim());
                cmd.Parameters.AddWithValue("@Alias", txtAlias.Text.Trim());
                cmd.Parameters.AddWithValue("@Comision", Convert.ToDecimal(txtComision.Text.Trim()));
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Vendedor guardado correctamente.");
            CargarVendedores();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idVendedorSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un vendedor.");
                return;
            }

            if (!ValidarCampos())
                return;

            if (ExisteCodigo(txtCodigoVendedor.Text, idVendedorSeleccionado))
            {
                MessageBox.Show("Ya existe otro vendedor con ese código.");
                txtCodigoVendedor.Focus();
                return;
            }

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"
                    UPDATE Vendedores
                    SET Nombre = @Nombre,
                        CodigoVendedor = @CodigoVendedor,
                        Documento = @Documento,
                        Alias = @Alias,
                        Comision = @Comision,
                        Estado = @Estado
                    WHERE IdVendedor = @IdVendedor";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdVendedor", idVendedorSeleccionado);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@CodigoVendedor", txtCodigoVendedor.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@Documento", txtDocumento.Text.Trim());
                cmd.Parameters.AddWithValue("@Alias", txtAlias.Text.Trim());
                cmd.Parameters.AddWithValue("@Comision", Convert.ToDecimal(txtComision.Text.Trim()));
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Vendedor actualizado correctamente.");
            CargarVendedores();
            LimpiarCampos();
        }

        private void dgvVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            object valorId = dgvVendedores.Rows[e.RowIndex].Cells["IdVendedor"].Value;

            if (valorId == null || valorId == DBNull.Value)
                return;

            if (!int.TryParse(valorId.ToString(), out idVendedorSeleccionado))
                return;

            txtNombre.Text = dgvVendedores.Rows[e.RowIndex].Cells["Nombre"]?.Value?.ToString() ?? "";
            txtCodigoVendedor.Text = dgvVendedores.Rows[e.RowIndex].Cells["CodigoVendedor"]?.Value?.ToString() ?? "";
            txtDocumento.Text = dgvVendedores.Rows[e.RowIndex].Cells["Documento"]?.Value?.ToString() ?? "";
            txtAlias.Text = dgvVendedores.Rows[e.RowIndex].Cells["Alias"]?.Value?.ToString() ?? "";
            txtComision.Text = dgvVendedores.Rows[e.RowIndex].Cells["Comision"]?.Value?.ToString() ?? "0.00000";
            chkEstado.Checked = (dgvVendedores.Rows[e.RowIndex].Cells["Estado"]?.Value?.ToString() ?? "") == "ACTIVO";

            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
        }
    }
}