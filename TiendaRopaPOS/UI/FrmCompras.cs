using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TiendaRopaPOS.Clases;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmCompras : Form
    {
        private DataTable dtDetalle = new DataTable();
        private readonly List<string> codigosProductos = new List<string>();

        public FrmCompras()
        {
            InitializeComponent();

            this.Load += FrmCompras_Load;

            btnGuardarCompra.Click += btnGuardarCompra_Click;
            btnLimpiarCompra.Click += btnLimpiarCompra_Click;
            btnQuitarFila.Click += btnQuitarFila_Click;

            cbProveedor.SelectedIndexChanged += cbProveedor_SelectedIndexChanged;

            dgvDetalleCompra.CellEndEdit += dgvDetalleCompra_CellEndEdit;
            dgvDetalleCompra.EditingControlShowing += dgvDetalleCompra_EditingControlShowing;
            dgvDetalleCompra.KeyDown += dgvDetalleCompra_KeyDown;
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarBodegas();
            CargarCodigosProductos();
            ConfigurarDetalleCompra();
            LimpiarCompra();
        }

        private void CargarProveedores()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT IdProveedor, RazonSocial
                    FROM Proveedores
                    WHERE Estado = 1
                    ORDER BY RazonSocial";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbProveedor.DataSource = dt;
                cbProveedor.DisplayMember = "RazonSocial";
                cbProveedor.ValueMember = "IdProveedor";
            }
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

                cbBodegaCompra.DataSource = dt;
                cbBodegaCompra.DisplayMember = "Nombre";
                cbBodegaCompra.ValueMember = "IdBodega";
            }
        }

        private void CargarCodigosProductos()
        {
            codigosProductos.Clear();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = "SELECT Codigo FROM Productos WHERE Estado = 1 ORDER BY Codigo";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    codigosProductos.Add(dr["Codigo"].ToString());
                }
            }
        }

        private void ConfigurarDetalleCompra()
        {
            dtDetalle = new DataTable();

            dtDetalle.Columns.Add("IdProducto", typeof(int));
            dtDetalle.Columns.Add("Codigo", typeof(string));
            dtDetalle.Columns.Add("Descripcion", typeof(string));
            dtDetalle.Columns.Add("Cantidad", typeof(decimal));
            dtDetalle.Columns.Add("CostoUnitario", typeof(decimal));
            dtDetalle.Columns.Add("Descuento", typeof(decimal));
            dtDetalle.Columns.Add("IvaLinea", typeof(decimal));
            dtDetalle.Columns.Add("TotalLinea", typeof(decimal));

            dgvDetalleCompra.DataSource = dtDetalle;

            dgvDetalleCompra.AllowUserToAddRows = false;
            dgvDetalleCompra.AllowUserToDeleteRows = false;
            dgvDetalleCompra.MultiSelect = false;
            dgvDetalleCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvDetalleCompra.Columns.Contains("IdProducto"))
                dgvDetalleCompra.Columns["IdProducto"].Visible = false;

            dgvDetalleCompra.Columns["Descripcion"].ReadOnly = true;
            dgvDetalleCompra.Columns["TotalLinea"].ReadOnly = true;

            dgvDetalleCompra.Columns["Codigo"].HeaderText = "Código";
            dgvDetalleCompra.Columns["Descripcion"].HeaderText = "Producto";
            dgvDetalleCompra.Columns["Cantidad"].HeaderText = "Cant.";
            dgvDetalleCompra.Columns["CostoUnitario"].HeaderText = "Costo";
            dgvDetalleCompra.Columns["Descuento"].HeaderText = "Desc";
            dgvDetalleCompra.Columns["IvaLinea"].HeaderText = "IVA";
            dgvDetalleCompra.Columns["TotalLinea"].HeaderText = "Total";

            dgvDetalleCompra.Columns["Cantidad"].DefaultCellStyle.Format = "0.00";
            dgvDetalleCompra.Columns["CostoUnitario"].DefaultCellStyle.Format = "0.00000";
            dgvDetalleCompra.Columns["Descuento"].DefaultCellStyle.Format = "0.00";
            dgvDetalleCompra.Columns["IvaLinea"].DefaultCellStyle.Format = "0.00";
            dgvDetalleCompra.Columns["TotalLinea"].DefaultCellStyle.Format = "0.00";
        }

        private void LimpiarCompra()
        {
            txtNumeroDocumento.Clear();
            chkPagada.Checked = false;
            txtDiasCredito.Text = "0";

            dtDetalle.Rows.Clear();
            AgregarFilaVaciaSiNoExiste();
            CalcularTotales();

            if (cbProveedor.Items.Count > 0)
                cbProveedor.SelectedIndex = 0;

            if (cbBodegaCompra.Items.Count > 0)
                cbBodegaCompra.SelectedIndex = 0;
        }

        private void AgregarFilaVaciaSiNoExiste()
        {
            if (dtDetalle.Rows.Count == 0)
            {
                DataRow nueva = dtDetalle.NewRow();
                nueva["Cantidad"] = 1m;
                nueva["CostoUnitario"] = 0m;
                nueva["Descuento"] = 0m;
                nueva["IvaLinea"] = 0m;
                nueva["TotalLinea"] = 0m;
                dtDetalle.Rows.Add(nueva);
                return;
            }

            DataRow ultima = dtDetalle.Rows[dtDetalle.Rows.Count - 1];
            string codigo = ultima["Codigo"] == DBNull.Value ? "" : ultima["Codigo"].ToString().Trim();

            if (!string.IsNullOrWhiteSpace(codigo))
            {
                DataRow nueva = dtDetalle.NewRow();
                nueva["Cantidad"] = 1m;
                nueva["CostoUnitario"] = 0m;
                nueva["Descuento"] = 0m;
                nueva["IvaLinea"] = 0m;
                nueva["TotalLinea"] = 0m;
                dtDetalle.Rows.Add(nueva);
            }
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProveedor.SelectedValue == null)
                return;

            if (!int.TryParse(cbProveedor.SelectedValue.ToString(), out int idProveedor))
                return;

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT DiasCredito
                    FROM Proveedores
                    WHERE IdProveedor = @IdProveedor";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);

                cn.Open();
                object result = cmd.ExecuteScalar();

                txtDiasCredito.Text = result == null ? "0" : result.ToString();
            }
        }

        private void dgvDetalleCompra_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= SoloNumeros_KeyPress;

            string nombreColumna = dgvDetalleCompra.CurrentCell.OwningColumn.Name;

            if (nombreColumna == "Cantidad" || nombreColumna == "CostoUnitario" || nombreColumna == "Descuento" || nombreColumna == "IvaLinea")
            {
                e.Control.KeyPress += SoloNumeros_KeyPress;
            }

            if (nombreColumna == "Codigo" && e.Control is TextBox txt)
            {
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                data.AddRange(codigosProductos.ToArray());

                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.AutoCompleteCustomSource = data;
                txt.CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            if (sender is TextBox txt && e.KeyChar == '.' && txt.Text.Contains("."))
                e.Handled = true;
        }

        private void dgvDetalleCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvDetalleCompra.CurrentCell != null)
            {
                e.SuppressKeyPress = true;
                dgvDetalleCompra.EndEdit();

                int fila = dgvDetalleCompra.CurrentCell.RowIndex;
                string columna = dgvDetalleCompra.CurrentCell.OwningColumn.Name;

                if (columna == "Codigo")
                {
                    CargarProductoEnFila(fila);

                    if (fila < dgvDetalleCompra.Rows.Count)
                    {
                        dgvDetalleCompra.CurrentCell = dgvDetalleCompra.Rows[fila].Cells["Cantidad"];
                        dgvDetalleCompra.BeginEdit(true);
                    }
                }
                else if (columna == "Cantidad" || columna == "CostoUnitario" || columna == "Descuento" || columna == "IvaLinea")
                {
                    RecalcularFila(fila);
                    AgregarFilaVaciaSiNoExiste();
                    CalcularTotales();

                    int ultimaFila = dgvDetalleCompra.Rows.Count - 1;
                    if (ultimaFila >= 0)
                    {
                        dgvDetalleCompra.CurrentCell = dgvDetalleCompra.Rows[ultimaFila].Cells["Codigo"];
                        dgvDetalleCompra.BeginEdit(true);
                    }
                }
            }
        }

        private void dgvDetalleCompra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columna = dgvDetalleCompra.Columns[e.ColumnIndex].Name;

            if (columna == "Codigo")
            {
                CargarProductoEnFila(e.RowIndex);
            }
            else if (columna == "Cantidad" || columna == "CostoUnitario" || columna == "Descuento" || columna == "IvaLinea")
            {
                RecalcularFila(e.RowIndex);
                AgregarFilaVaciaSiNoExiste();
                CalcularTotales();
            }
        }

        private void CargarProductoEnFila(int fila)
        {
            if (fila < 0 || fila >= dtDetalle.Rows.Count)
                return;

            string codigo = dtDetalle.Rows[fila]["Codigo"] == DBNull.Value
                ? ""
                : dtDetalle.Rows[fila]["Codigo"].ToString().Trim();

            if (string.IsNullOrWhiteSpace(codigo))
                return;

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT TOP 1
                        IdProducto,
                        Codigo,
                        Descripcion,
                        PrecioBase
                    FROM Productos
                    WHERE Codigo = @Codigo
                      AND Estado = 1";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dtDetalle.Rows[fila]["IdProducto"] = Convert.ToInt32(dr["IdProducto"]);
                    dtDetalle.Rows[fila]["Codigo"] = dr["Codigo"].ToString();
                    dtDetalle.Rows[fila]["Descripcion"] = dr["Descripcion"].ToString();
                    dtDetalle.Rows[fila]["Cantidad"] = dtDetalle.Rows[fila]["Cantidad"] == DBNull.Value ? 1m : Convert.ToDecimal(dtDetalle.Rows[fila]["Cantidad"]);
                    dtDetalle.Rows[fila]["CostoUnitario"] = Convert.ToDecimal(dr["PrecioBase"]);
                    dtDetalle.Rows[fila]["Descuento"] = dtDetalle.Rows[fila]["Descuento"] == DBNull.Value ? 0m : Convert.ToDecimal(dtDetalle.Rows[fila]["Descuento"]);
                    dtDetalle.Rows[fila]["IvaLinea"] = dtDetalle.Rows[fila]["IvaLinea"] == DBNull.Value ? 0m : Convert.ToDecimal(dtDetalle.Rows[fila]["IvaLinea"]);

                    RecalcularFila(fila);
                    AgregarFilaVaciaSiNoExiste();
                    CalcularTotales();
                }
                else
                {
                    MessageBox.Show("Producto no encontrado.");
                    dtDetalle.Rows[fila]["IdProducto"] = DBNull.Value;
                    dtDetalle.Rows[fila]["Descripcion"] = "";
                    dtDetalle.Rows[fila]["CostoUnitario"] = 0m;
                    dtDetalle.Rows[fila]["TotalLinea"] = 0m;
                }
            }
        }

        private void RecalcularFila(int fila)
        {
            if (fila < 0 || fila >= dtDetalle.Rows.Count)
                return;

            decimal cantidad = 0;
            decimal costo = 0;
            decimal descuento = 0;
            decimal iva = 0;

            decimal.TryParse(dtDetalle.Rows[fila]["Cantidad"]?.ToString(), out cantidad);
            decimal.TryParse(dtDetalle.Rows[fila]["CostoUnitario"]?.ToString(), out costo);
            decimal.TryParse(dtDetalle.Rows[fila]["Descuento"]?.ToString(), out descuento);
            decimal.TryParse(dtDetalle.Rows[fila]["IvaLinea"]?.ToString(), out iva);

            decimal total = (cantidad * costo) - descuento + iva;
            if (total < 0) total = 0;

            dtDetalle.Rows[fila]["TotalLinea"] = total;
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;
            decimal descuento = 0;
            decimal iva = 0;
            decimal total = 0;

            foreach (DataRow row in dtDetalle.Rows)
            {
                if (row["IdProducto"] == DBNull.Value)
                    continue;

                decimal cantidad = Convert.ToDecimal(row["Cantidad"]);
                decimal costo = Convert.ToDecimal(row["CostoUnitario"]);
                decimal desc = Convert.ToDecimal(row["Descuento"]);
                decimal ivaLinea = Convert.ToDecimal(row["IvaLinea"]);
                decimal baseLinea = cantidad * costo;

                subtotal += baseLinea;
                descuento += desc;
                iva += ivaLinea;
                total += Convert.ToDecimal(row["TotalLinea"]);
            }

            lblSubtotalCompra.Text = subtotal.ToString("0.00");
            lblDescuentoCompra.Text = descuento.ToString("0.00");
            lblIvaCompra.Text = iva.ToString("0.00");
            lblTotalCompra.Text = total.ToString("0.00");
        }

        private void btnQuitarFila_Click(object sender, EventArgs e)
        {
            if (dgvDetalleCompra.CurrentRow == null || dgvDetalleCompra.CurrentRow.Index < 0)
                return;

            if (dtDetalle.Rows.Count == 1)
            {
                dtDetalle.Rows.Clear();
                AgregarFilaVaciaSiNoExiste();
            }
            else
            {
                dgvDetalleCompra.Rows.RemoveAt(dgvDetalleCompra.CurrentRow.Index);
            }

            CalcularTotales();
        }

        private void btnLimpiarCompra_Click(object sender, EventArgs e)
        {
            LimpiarCompra();
        }

        private int ObtenerIdUsuarioActual()
        {
            if (SesionUsuario.IdUsuario <= 0)
                return 1;

            return SesionUsuario.IdUsuario;
        }

        private void btnGuardarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                var filasValidas = dtDetalle.AsEnumerable()
                    .Where(r => r["IdProducto"] != DBNull.Value
                             && !string.IsNullOrWhiteSpace(r["Codigo"]?.ToString()))
                    .ToList();

                if (cbProveedor.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un proveedor.");
                    cbProveedor.Focus();
                    return;
                }

                if (cbBodegaCompra.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione una bodega.");
                    cbBodegaCompra.Focus();
                    return;
                }

                if (filasValidas.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un producto.");
                    return;
                }

                decimal subtotal = 0m;
                decimal descuento = 0m;
                decimal iva = 0m;
                decimal total = 0m;

                foreach (DataRow row in filasValidas)
                {
                    decimal cantidad = Convert.ToDecimal(row["Cantidad"]);
                    decimal costo = Convert.ToDecimal(row["CostoUnitario"]);

                    if (cantidad <= 0 || costo < 0)
                    {
                        MessageBox.Show("Hay productos con cantidad o costo inválido.");
                        return;
                    }

                    subtotal += cantidad * costo;
                    descuento += Convert.ToDecimal(row["Descuento"]);
                    iva += Convert.ToDecimal(row["IvaLinea"]);
                    total += Convert.ToDecimal(row["TotalLinea"]);
                }

                int idProveedor = Convert.ToInt32(cbProveedor.SelectedValue);
                int idBodega = TiendaRopaPOS.Clases.ConfiguracionSistema.IdBodegaStockGeneral;
                int idUsuario = ObtenerIdUsuarioActual();

                int diasCredito = 0;
                int.TryParse(txtDiasCredito.Text.Trim(), out diasCredito);

                DateTime fechaDocumento = DateTime.Today;
                DateTime? fechaVencimiento = diasCredito > 0 ? fechaDocumento.AddDays(diasCredito) : (DateTime?)null;

                using (SqlConnection cn = new Conexion().ObtenerConexion())
                {
                    cn.Open();

                    using (SqlTransaction tx = cn.BeginTransaction())
                    {
                        try
                        {
                            int idCompra = InsertarCompra(
                                cn, tx,
                                idProveedor,
                                idUsuario,
                                idBodega,
                                txtNumeroDocumento.Text.Trim(),
                                fechaDocumento,
                                diasCredito,
                                fechaVencimiento,
                                subtotal,
                                descuento,
                                iva,
                                total,
                                chkPagada.Checked
                            );

                            foreach (DataRow row in filasValidas)
                            {
                                int idProducto = Convert.ToInt32(row["IdProducto"]);
                                decimal cantidad = Convert.ToDecimal(row["Cantidad"]);
                                decimal costo = Convert.ToDecimal(row["CostoUnitario"]);
                                decimal descuentoLinea = Convert.ToDecimal(row["Descuento"]);
                                decimal ivaLinea = Convert.ToDecimal(row["IvaLinea"]);
                                decimal totalLinea = Convert.ToDecimal(row["TotalLinea"]);

                                InsertarDetalleCompra(
                                    cn, tx,
                                    idCompra,
                                    idProducto,
                                    cantidad,
                                    costo,
                                    descuentoLinea,
                                    ivaLinea,
                                    totalLinea
                                );

                                SubirInventario(cn, tx, idProducto, idBodega, cantidad, costo);
                                InsertarMovimientoCompra(cn, tx, idProducto, idBodega, cantidad, costo, txtNumeroDocumento.Text.Trim());
                            }

                            tx.Commit();

                            MessageBox.Show("Compra guardada correctamente.");
                            LimpiarCompra();
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                            MessageBox.Show("Error al guardar compra: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
            }
        }

        private int InsertarCompra(
            SqlConnection cn,
            SqlTransaction tx,
            int idProveedor,
            int idUsuario,
            int idBodega,
            string numeroDocumento,
            DateTime fechaDocumento,
            int diasCredito,
            DateTime? fechaVencimiento,
            decimal subtotal,
            decimal descuento,
            decimal iva,
            decimal total,
            bool pagada)
        {
            string query = @"
                INSERT INTO Compras
                (
                    IdProveedor,
                    IdUsuario,
                    IdBodega,
                    NumeroDocumento,
                    FechaDocumento,
                    FechaCreacion,
                    DiasCredito,
                    FechaVencimiento,
                    Subtotal,
                    Descuento,
                    Iva,
                    Total,
                    Pagada,
                    Estado,
                    Observacion
                )
                VALUES
                (
                    @IdProveedor,
                    @IdUsuario,
                    @IdBodega,
                    @NumeroDocumento,
                    @FechaDocumento,
                    GETDATE(),
                    @DiasCredito,
                    @FechaVencimiento,
                    @Subtotal,
                    @Descuento,
                    @Iva,
                    @Total,
                    @Pagada,
                    1,
                    ''
                );

                SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, cn, tx);
            cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@IdBodega", idBodega);
            cmd.Parameters.AddWithValue("@NumeroDocumento", string.IsNullOrWhiteSpace(numeroDocumento) ? (object)DBNull.Value : numeroDocumento);
            cmd.Parameters.AddWithValue("@FechaDocumento", fechaDocumento);
            cmd.Parameters.AddWithValue("@DiasCredito", diasCredito);
            cmd.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento.HasValue ? (object)fechaVencimiento.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Subtotal", subtotal);
            cmd.Parameters.AddWithValue("@Descuento", descuento);
            cmd.Parameters.AddWithValue("@Iva", iva);
            cmd.Parameters.AddWithValue("@Total", total);
            cmd.Parameters.AddWithValue("@Pagada", pagada ? 1 : 0);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void InsertarDetalleCompra(
            SqlConnection cn,
            SqlTransaction tx,
            int idCompra,
            int idProducto,
            decimal cantidad,
            decimal costoUnitario,
            decimal descuento,
            decimal ivaLinea,
            decimal totalLinea)
        {
            string query = @"
                INSERT INTO DetalleCompras
                (
                    IdCompra,
                    IdProducto,
                    Cantidad,
                    CostoUnitario,
                    Descuento,
                    IvaLinea,
                    TotalLinea,
                    Estado,
                    FechaCreacion
                )
                VALUES
                (
                    @IdCompra,
                    @IdProducto,
                    @Cantidad,
                    @CostoUnitario,
                    @Descuento,
                    @IvaLinea,
                    @TotalLinea,
                    1,
                    GETDATE()
                )";

            SqlCommand cmd = new SqlCommand(query, cn, tx);
            cmd.Parameters.AddWithValue("@IdCompra", idCompra);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
            cmd.Parameters.AddWithValue("@CostoUnitario", costoUnitario);
            cmd.Parameters.AddWithValue("@Descuento", descuento);
            cmd.Parameters.AddWithValue("@IvaLinea", ivaLinea);
            cmd.Parameters.AddWithValue("@TotalLinea", totalLinea);

            cmd.ExecuteNonQuery();
        }

        private void SubirInventario(SqlConnection cn, SqlTransaction tx, int idProducto, int idBodega, decimal cantidad, decimal costo)
        {
            string existeQuery = @"
                SELECT COUNT(*)
                FROM Inventario
                WHERE IdProducto = @IdProducto
                  AND IdBodega = @IdBodega";

            SqlCommand cmdExiste = new SqlCommand(existeQuery, cn, tx);
            cmdExiste.Parameters.AddWithValue("@IdProducto", idProducto);
            cmdExiste.Parameters.AddWithValue("@IdBodega", idBodega);

            int existe = Convert.ToInt32(cmdExiste.ExecuteScalar());

            if (existe > 0)
            {
                string updateQuery = @"
                    UPDATE Inventario
                    SET Stock = Stock + @Cantidad,
                        UltimoCosto = @Costo,
                        FechaActualizacion = GETDATE()
                    WHERE IdProducto = @IdProducto
                      AND IdBodega = @IdBodega";

                SqlCommand cmdUpdate = new SqlCommand(updateQuery, cn, tx);
                cmdUpdate.Parameters.AddWithValue("@Cantidad", cantidad);
                cmdUpdate.Parameters.AddWithValue("@Costo", costo);
                cmdUpdate.Parameters.AddWithValue("@IdProducto", idProducto);
                cmdUpdate.Parameters.AddWithValue("@IdBodega", idBodega);

                cmdUpdate.ExecuteNonQuery();
            }
            else
            {
                string insertQuery = @"
                    INSERT INTO Inventario
                    (
                        IdProducto,
                        IdBodega,
                        Stock,
                        UltimoCosto,
                        PrecioVenta,
                        Estado,
                        FechaActualizacion
                    )
                    VALUES
                    (
                        @IdProducto,
                        @IdBodega,
                        @Stock,
                        @UltimoCosto,
                        0,
                        1,
                        GETDATE()
                    )";

                SqlCommand cmdInsert = new SqlCommand(insertQuery, cn, tx);
                cmdInsert.Parameters.AddWithValue("@IdProducto", idProducto);
                cmdInsert.Parameters.AddWithValue("@IdBodega", idBodega);
                cmdInsert.Parameters.AddWithValue("@Stock", cantidad);
                cmdInsert.Parameters.AddWithValue("@UltimoCosto", costo);

                cmdInsert.ExecuteNonQuery();
            }
        }

        private void InsertarMovimientoCompra(
            SqlConnection cn,
            SqlTransaction tx,
            int idProducto,
            int idBodega,
            decimal cantidad,
            decimal costoUnitario,
            string referencia)
        {
            string query = @"
                INSERT INTO MovimientosInventario
                (
                    IdProducto,
                    IdBodega,
                    TipoMovimiento,
                    Cantidad,
                    CostoUnitario,
                    PrecioUnitario,
                    FechaMovimiento,
                    Referencia,
                    Observacion
                )
                VALUES
                (
                    @IdProducto,
                    @IdBodega,
                    'ENTRADA',
                    @Cantidad,
                    @CostoUnitario,
                    NULL,
                    GETDATE(),
                    @Referencia,
                    'COMPRA'
                )";

            SqlCommand cmd = new SqlCommand(query, cn, tx);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            cmd.Parameters.AddWithValue("@IdBodega", idBodega);
            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
            cmd.Parameters.AddWithValue("@CostoUnitario", costoUnitario);
            cmd.Parameters.AddWithValue("@Referencia", string.IsNullOrWhiteSpace(referencia) ? (object)DBNull.Value : referencia);

            cmd.ExecuteNonQuery();
        }
    }
}