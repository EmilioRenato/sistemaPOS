using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmInventario : Form
    {
        private int idInventarioSeleccionado = 0;

        public FrmInventario()
        {
            InitializeComponent();

            this.Load += FrmInventario_Load;

            btnBuscar.Click += btnBuscar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            dgvInventario.CellClick += dgvInventario_CellClick;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarBodegas();
            CargarInventario();
            LimpiarCampos();
        }

        private void CargarProductos()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
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

        private void CargarBodegas()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                string query = @"
                    SELECT IdBodega, Nombre
                    FROM Bodegas
                    WHERE Estado = 1
                    ORDER BY Nombre";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbBodega.DataSource = dt;
                cbBodega.DisplayMember = "Nombre";
                cbBodega.ValueMember = "IdBodega";
                cbBodega.SelectedIndex = -1;
            }
        }

        private void CargarInventario(string filtro = "")
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
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
                    WHERE p.Codigo LIKE @Filtro
                       OR p.Descripcion LIKE @Filtro
                       OR b.Nombre LIKE @Filtro
                    ORDER BY p.Descripcion, b.Nombre";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.SelectCommand.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvInventario.DataSource = dt;
                dgvInventario.AutoGenerateColumns=true;

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
            cbBodega.SelectedIndex = -1;
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

            if (cbBodega.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una bodega.");
                cbBodega.Focus();
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

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string verificar = @"
                    SELECT COUNT(*)
                    FROM Inventario
                    WHERE IdProducto = @IdProducto AND IdBodega = @IdBodega";

                SqlCommand cmdVerificar = new SqlCommand(verificar, cn);
                cmdVerificar.Parameters.AddWithValue("@IdProducto", cbProducto.SelectedValue);
                cmdVerificar.Parameters.AddWithValue("@IdBodega", cbBodega.SelectedValue);

                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("Ya existe inventario para ese producto en esa bodega.");
                    return;
                }

                string query = @"
                    INSERT INTO Inventario
                    (IdProducto, IdBodega, Stock, UltimoCosto, PrecioVenta, Estado, FechaActualizacion)
                    VALUES
                    (@IdProducto, @IdBodega, @Stock, @UltimoCosto, @PrecioVenta, @Estado, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdProducto", cbProducto.SelectedValue);
                cmd.Parameters.AddWithValue("@IdBodega", cbBodega.SelectedValue);
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

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
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
                cmdVerificar.Parameters.AddWithValue("@IdBodega", cbBodega.SelectedValue);
                cmdVerificar.Parameters.AddWithValue("@IdInventario", idInventarioSeleccionado);

                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("Ya existe otro registro con ese producto y bodega.");
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
                cmd.Parameters.AddWithValue("@IdBodega", cbBodega.SelectedValue);
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

            string bodega = dgvInventario.Rows[e.RowIndex].Cells["Bodega"]?.Value?.ToString() ?? "";

            cbProducto.Text = textoProducto;
            cbBodega.Text = bodega;

            txtStock.Text = dgvInventario.Rows[e.RowIndex].Cells["Stock"]?.Value?.ToString() ?? "0.00";
            txtUltimoCosto.Text = dgvInventario.Rows[e.RowIndex].Cells["UltimoCosto"]?.Value?.ToString() ?? "0.00000";
            txtPrecioVenta.Text = dgvInventario.Rows[e.RowIndex].Cells["PrecioVenta"]?.Value?.ToString() ?? "0.00000";
            chkEstado.Checked = (dgvInventario.Rows[e.RowIndex].Cells["Estado"]?.Value?.ToString() ?? "") == "ACTIVO";

            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
        }
    }
}