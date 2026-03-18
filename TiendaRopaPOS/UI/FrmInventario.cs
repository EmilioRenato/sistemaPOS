using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TiendaRopaPOS.Clases;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmInventario : Form
    {
        private int idInventarioSeleccionado = 0;

        public FrmInventario()
        {
            InitializeComponent();

            btnBuscar.Click += btnBuscar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            dgvInventario.CellClick += dgvInventario_CellClick;
            txtBuscar.KeyDown += txtBuscar_KeyDown;

            this.Load += FrmInventario_Load;
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            AplicarEstiloVisual();
            AplicarAnimaciones();
            CargarProductos();
            CargarBodegaStockGeneral();
            CargarInventario();
            LimpiarCampos();
        }

        private void AplicarEstiloVisual()
        {
            dgvInventario.EnableHeadersVisualStyles = false;
            dgvInventario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 52, 54);
            dgvInventario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInventario.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvInventario.ColumnHeadersHeight = 34;

            dgvInventario.DefaultCellStyle.BackColor = Color.FromArgb(99, 110, 114);
            dgvInventario.DefaultCellStyle.ForeColor = Color.White;
            dgvInventario.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvInventario.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 82, 84);
            dgvInventario.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvInventario.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 82, 84);
            dgvInventario.GridColor = Color.FromArgb(178, 190, 195);
            dgvInventario.BorderStyle = BorderStyle.None;
            dgvInventario.RowHeadersVisible = false;
            dgvInventario.RowTemplate.Height = 30;

            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtStock.Font = new Font("Segoe UI", 10F);
            txtUltimoCosto.Font = new Font("Segoe UI", 10F);
            txtPrecioVenta.Font = new Font("Segoe UI", 10F);

            cbProducto.Font = new Font("Segoe UI", 10F);
            cbBodega.Font = new Font("Segoe UI", 10F);
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

        private void CargarProductos()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT IdProducto, Codigo + ' - ' + Descripcion AS Producto
                    FROM Productos
                    WHERE Estado = 1
                    ORDER BY Descripcion";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbProducto.DataSource = dt;
                cbProducto.DisplayMember = "Producto";
                cbProducto.ValueMember = "IdProducto";
                cbProducto.SelectedIndex = -1;
            }
        }

        private void CargarBodegaStockGeneral()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT IdBodega, Nombre
                    FROM Bodegas
                    WHERE IdBodega = @IdBodega";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.SelectCommand.Parameters.AddWithValue("@IdBodega", ConfiguracionSistema.IdBodegaStockGeneral);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cbBodega.DataSource = dt;
                cbBodega.DisplayMember = "Nombre";
                cbBodega.ValueMember = "IdBodega";

                if (cbBodega.Items.Count > 0)
                    cbBodega.SelectedIndex = 0;

                cbBodega.Enabled = false;
            }
        }

        private void CargarInventario(string filtro = "")
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        i.IdInventario,
                        p.Codigo,
                        p.Descripcion,
                        b.Nombre AS Bodega,
                        i.Stock,
                        i.UltimoCosto,
                        i.PrecioVenta,
                        CASE WHEN i.Estado = 1 THEN 'ACTIVO' ELSE 'INACTIVO' END AS Estado
                    FROM Inventario i
                    INNER JOIN Productos p ON i.IdProducto = p.IdProducto
                    INNER JOIN Bodegas b ON i.IdBodega = b.IdBodega
                    WHERE i.IdBodega = @IdBodega
                      AND (
                            p.Codigo LIKE @Filtro
                            OR p.Descripcion LIKE @Filtro
                            OR b.Nombre LIKE @Filtro
                          )
                    ORDER BY p.Descripcion";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.SelectCommand.Parameters.AddWithValue("@IdBodega", ConfiguracionSistema.IdBodegaStockGeneral);
                da.SelectCommand.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvInventario.DataSource = dt;
                dgvInventario.AutoGenerateColumns = true;

                if (dgvInventario.Columns.Contains("IdInventario"))
                    dgvInventario.Columns["IdInventario"].Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInventario(txtBuscar.Text.Trim());
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarInventario(txtBuscar.Text.Trim());
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
            idInventarioSeleccionado = 0;

            cbProducto.SelectedIndex = -1;

            if (cbBodega.Items.Count > 0)
                cbBodega.SelectedIndex = 0;

            txtStock.Text = "0.00";
            txtUltimoCosto.Text = "0.00000";
            txtPrecioVenta.Text = "0.00000";
            chkEstado.Checked = true;

            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;

            cbProducto.Focus();
        }

        private bool ValidarCampos()
        {
            decimal stock, costo, precio;

            if (cbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto.");
                cbProducto.Focus();
                return false;
            }

            if (!decimal.TryParse(txtStock.Text.Trim(), out stock) || stock < 0)
            {
                MessageBox.Show("Ingrese un stock válido.");
                txtStock.Focus();
                return false;
            }

            if (!decimal.TryParse(txtUltimoCosto.Text.Trim(), out costo) || costo < 0)
            {
                MessageBox.Show("Ingrese un costo válido.");
                txtUltimoCosto.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecioVenta.Text.Trim(), out precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio de venta válido.");
                txtPrecioVenta.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string verificar = @"
                    SELECT COUNT(*)
                    FROM Inventario
                    WHERE IdProducto = @IdProducto AND IdBodega = @IdBodega";

                SqlCommand cmdVerificar = new SqlCommand(verificar, cn);
                cmdVerificar.Parameters.AddWithValue("@IdProducto", cbProducto.SelectedValue);
                cmdVerificar.Parameters.AddWithValue("@IdBodega", ConfiguracionSistema.IdBodegaStockGeneral);

                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("Ya existe inventario para ese producto en el stock general.");
                    return;
                }

                string query = @"
                    INSERT INTO Inventario
                    (IdProducto, IdBodega, Stock, UltimoCosto, PrecioVenta, Estado, FechaActualizacion)
                    VALUES
                    (@IdProducto, @IdBodega, @Stock, @UltimoCosto, @PrecioVenta, @Estado, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdProducto", cbProducto.SelectedValue);
                cmd.Parameters.AddWithValue("@IdBodega", ConfiguracionSistema.IdBodegaStockGeneral);
                cmd.Parameters.AddWithValue("@Stock", Convert.ToDecimal(txtStock.Text.Trim()));
                cmd.Parameters.AddWithValue("@UltimoCosto", Convert.ToDecimal(txtUltimoCosto.Text.Trim()));
                cmd.Parameters.AddWithValue("@PrecioVenta", Convert.ToDecimal(txtPrecioVenta.Text.Trim()));
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Inventario guardado correctamente.");
            CargarInventario();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idInventarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un registro.");
                return;
            }

            if (!ValidarCampos())
                return;

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string verificar = @"
                    SELECT COUNT(*)
                    FROM Inventario
                    WHERE IdProducto = @IdProducto
                      AND IdBodega = @IdBodega
                      AND IdInventario <> @IdInventario";

                SqlCommand cmdVerificar = new SqlCommand(verificar, cn);
                cmdVerificar.Parameters.AddWithValue("@IdProducto", cbProducto.SelectedValue);
                cmdVerificar.Parameters.AddWithValue("@IdBodega", ConfiguracionSistema.IdBodegaStockGeneral);
                cmdVerificar.Parameters.AddWithValue("@IdInventario", idInventarioSeleccionado);

                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("Ya existe otro registro con ese producto en el stock general.");
                    return;
                }

                string query = @"
                    UPDATE Inventario
                    SET IdProducto = @IdProducto,
                        IdBodega = @IdBodega,
                        Stock = @Stock,
                        UltimoCosto = @UltimoCosto,
                        PrecioVenta = @PrecioVenta,
                        Estado = @Estado,
                        FechaActualizacion = GETDATE()
                    WHERE IdInventario = @IdInventario";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdInventario", idInventarioSeleccionado);
                cmd.Parameters.AddWithValue("@IdProducto", cbProducto.SelectedValue);
                cmd.Parameters.AddWithValue("@IdBodega", ConfiguracionSistema.IdBodegaStockGeneral);
                cmd.Parameters.AddWithValue("@Stock", Convert.ToDecimal(txtStock.Text.Trim()));
                cmd.Parameters.AddWithValue("@UltimoCosto", Convert.ToDecimal(txtUltimoCosto.Text.Trim()));
                cmd.Parameters.AddWithValue("@PrecioVenta", Convert.ToDecimal(txtPrecioVenta.Text.Trim()));
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Inventario actualizado correctamente.");
            CargarInventario();
            LimpiarCampos();
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvInventario.Rows[e.RowIndex].Cells["IdInventario"] == null ||
                dgvInventario.Rows[e.RowIndex].Cells["IdInventario"].Value == null ||
                dgvInventario.Rows[e.RowIndex].Cells["IdInventario"].Value == DBNull.Value)
                return;

            int.TryParse(
                dgvInventario.Rows[e.RowIndex].Cells["IdInventario"].Value.ToString(),
                out idInventarioSeleccionado
            );

            if (idInventarioSeleccionado == 0)
                return;

            string codigo = dgvInventario.Rows[e.RowIndex].Cells["Codigo"]?.Value?.ToString() ?? "";
            string descripcion = dgvInventario.Rows[e.RowIndex].Cells["Descripcion"]?.Value?.ToString() ?? "";
            string textoProducto = codigo + " - " + descripcion;

            cbProducto.Text = textoProducto;

            if (cbBodega.Items.Count > 0)
                cbBodega.SelectedIndex = 0;

            txtStock.Text = dgvInventario.Rows[e.RowIndex].Cells["Stock"]?.Value?.ToString() ?? "0.00";
            txtUltimoCosto.Text = dgvInventario.Rows[e.RowIndex].Cells["UltimoCosto"]?.Value?.ToString() ?? "0.00000";
            txtPrecioVenta.Text = dgvInventario.Rows[e.RowIndex].Cells["PrecioVenta"]?.Value?.ToString() ?? "0.00000";
            chkEstado.Checked = (dgvInventario.Rows[e.RowIndex].Cells["Estado"]?.Value?.ToString() ?? "") == "ACTIVO";

            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
        }
    }
}