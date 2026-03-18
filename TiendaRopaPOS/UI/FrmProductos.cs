using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmProductos : Form
    {
        private int idProductoSeleccionado = 0;

        public FrmProductos()
        {
            InitializeComponent();

            btnBuscar.Click += btnBuscar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            dgvProductos.CellClick += dgvProductos_CellClick;
            txtBuscar.KeyDown += txtBuscar_KeyDown;

            this.Load += FrmProductos_Load;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            AplicarEstiloVisual();
            AplicarAnimaciones();
            CargarUnidades();
            CargarCategorias();
            CargarProductos();
            LimpiarCampos();
        }

        private void AplicarEstiloVisual()
        {
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 52, 54);
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvProductos.ColumnHeadersHeight = 34;

            dgvProductos.DefaultCellStyle.BackColor = Color.FromArgb(99, 110, 114);
            dgvProductos.DefaultCellStyle.ForeColor = Color.White;
            dgvProductos.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 82, 84);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 82, 84);
            dgvProductos.GridColor = Color.FromArgb(178, 190, 195);
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowTemplate.Height = 30;

            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtCodigo.Font = new Font("Segoe UI", 10F);
            txtDescripcion.Font = new Font("Segoe UI", 10F);
            txtReferencia.Font = new Font("Segoe UI", 10F);
            txtPrecioBase.Font = new Font("Segoe UI", 10F);

            cbUnidad.Font = new Font("Segoe UI", 10F);
            cbCategoria.Font = new Font("Segoe UI", 10F);
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

        private void CargarUnidades()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string query = "SELECT IdUnidad, NombreUnidad FROM Unidades WHERE Estado = 1 ORDER BY NombreUnidad";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbUnidad.DataSource = dt;
                cbUnidad.DisplayMember = "NombreUnidad";
                cbUnidad.ValueMember = "IdUnidad";
                cbUnidad.SelectedIndex = -1;
            }
        }

        private void CargarCategorias()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string query = "SELECT IdCategoria, NombreCategoria FROM Categorias WHERE Estado = 1 ORDER BY NombreCategoria";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbCategoria.DataSource = dt;
                cbCategoria.DisplayMember = "NombreCategoria";
                cbCategoria.ValueMember = "IdCategoria";
                cbCategoria.SelectedIndex = -1;
            }
        }

        private void CargarProductos(string filtro = "")
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        p.IdProducto,
                        p.Codigo,
                        p.Descripcion,
                        p.Referencia,
                        u.NombreUnidad AS Unidad,
                        ISNULL(c.NombreCategoria, '') AS Categoria,
                        p.PrecioBase,
                        CASE WHEN p.Estado = 1 THEN 'ACTIVO' ELSE 'INACTIVO' END AS Estado
                    FROM Productos p
                    INNER JOIN Unidades u ON p.IdUnidad = u.IdUnidad
                    LEFT JOIN Categorias c ON p.IdCategoria = c.IdCategoria
                    WHERE p.Codigo LIKE @Filtro
                       OR p.Descripcion LIKE @Filtro
                       OR p.Referencia LIKE @Filtro
                    ORDER BY p.Descripcion";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.SelectCommand.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvProductos.DataSource = dt;
                dgvProductos.AutoGenerateColumns = true;

                if (dgvProductos.Columns.Contains("IdProducto"))
                    dgvProductos.Columns["IdProducto"].Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProductos(txtBuscar.Text.Trim());
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarProductos(txtBuscar.Text.Trim());
                e.SuppressKeyPress = true;
            }
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
            idProductoSeleccionado = 0;

            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtReferencia.Clear();
            txtPrecioBase.Text = "0.00";

            cbUnidad.SelectedIndex = -1;
            cbCategoria.SelectedIndex = -1;

            chkEstado.Checked = true;

            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;

            txtCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string verificar = "SELECT COUNT(*) FROM Productos WHERE Codigo = @Codigo";
                SqlCommand cmdVerificar = new SqlCommand(verificar, cn);
                cmdVerificar.Parameters.AddWithValue("@Codigo", txtCodigo.Text.Trim());

                cn.Open();
                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("Ya existe un producto con ese código.");
                    return;
                }

                string query = @"
                    INSERT INTO Productos
                    (IdUnidad, IdCategoria, Codigo, Descripcion, Referencia, PrecioBase, Estado, FechaCreacion)
                    VALUES
                    (@IdUnidad, @IdCategoria, @Codigo, @Descripcion, @Referencia, @PrecioBase, @Estado, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@IdUnidad", cbUnidad.SelectedValue);
                if (cbCategoria.SelectedIndex == -1)
                    cmd.Parameters.AddWithValue("@IdCategoria", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdCategoria", cbCategoria.SelectedValue);

                cmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text.Trim());
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text.Trim());
                cmd.Parameters.AddWithValue("@Referencia", txtReferencia.Text.Trim());
                cmd.Parameters.AddWithValue("@PrecioBase", Convert.ToDecimal(txtPrecioBase.Text.Trim()));
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Producto guardado correctamente.");
            CargarProductos();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            if (!ValidarCampos())
                return;

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string verificar = @"
                    SELECT COUNT(*) 
                    FROM Productos 
                    WHERE Codigo = @Codigo AND IdProducto <> @IdProducto";

                SqlCommand cmdVerificar = new SqlCommand(verificar, cn);
                cmdVerificar.Parameters.AddWithValue("@Codigo", txtCodigo.Text.Trim());
                cmdVerificar.Parameters.AddWithValue("@IdProducto", idProductoSeleccionado);

                cn.Open();
                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("Ya existe otro producto con ese código.");
                    return;
                }

                string query = @"
                    UPDATE Productos
                    SET IdUnidad = @IdUnidad,
                        IdCategoria = @IdCategoria,
                        Codigo = @Codigo,
                        Descripcion = @Descripcion,
                        Referencia = @Referencia,
                        PrecioBase = @PrecioBase,
                        Estado = @Estado
                    WHERE IdProducto = @IdProducto";

                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@IdProducto", idProductoSeleccionado);
                cmd.Parameters.AddWithValue("@IdUnidad", cbUnidad.SelectedValue);

                if (cbCategoria.SelectedIndex == -1)
                    cmd.Parameters.AddWithValue("@IdCategoria", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdCategoria", cbCategoria.SelectedValue);

                cmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text.Trim());
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text.Trim());
                cmd.Parameters.AddWithValue("@Referencia", txtReferencia.Text.Trim());
                cmd.Parameters.AddWithValue("@PrecioBase", Convert.ToDecimal(txtPrecioBase.Text.Trim()));
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Producto actualizado correctamente.");
            CargarProductos();
            LimpiarCampos();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (!dgvProductos.Columns.Contains("IdProducto"))
                return;

            object valorId = dgvProductos.Rows[e.RowIndex].Cells["IdProducto"].Value;

            if (valorId == null || valorId == DBNull.Value)
                return;

            if (!int.TryParse(valorId.ToString(), out idProductoSeleccionado))
                return;

            txtCodigo.Text = dgvProductos.Rows[e.RowIndex].Cells["Codigo"]?.Value?.ToString() ?? "";
            txtDescripcion.Text = dgvProductos.Rows[e.RowIndex].Cells["Descripcion"]?.Value?.ToString() ?? "";
            txtReferencia.Text = dgvProductos.Rows[e.RowIndex].Cells["Referencia"]?.Value?.ToString() ?? "";
            txtPrecioBase.Text = dgvProductos.Rows[e.RowIndex].Cells["PrecioBase"]?.Value?.ToString() ?? "0.00";

            cbUnidad.Text = dgvProductos.Rows[e.RowIndex].Cells["Unidad"]?.Value?.ToString() ?? "";
            cbCategoria.Text = dgvProductos.Rows[e.RowIndex].Cells["Categoria"]?.Value?.ToString() ?? "";

            chkEstado.Checked = (dgvProductos.Rows[e.RowIndex].Cells["Estado"]?.Value?.ToString() ?? "") == "ACTIVO";

            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
        }

        private bool ValidarCampos()
        {
            decimal precio;

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Ingrese código.");
                txtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese descripción.");
                txtDescripcion.Focus();
                return false;
            }

            if (cbUnidad.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una unidad.");
                cbUnidad.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecioBase.Text.Trim(), out precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio base válido.");
                txtPrecioBase.Focus();
                return false;
            }

            return true;
        }
    }
}