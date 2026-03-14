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
    public partial class FrmFacturacion : Form
    {
        private DataTable dtDetalle = new DataTable();
        private int idClienteActual = 0;
        private readonly List<string> codigosProductos = new List<string>();

        public FrmFacturacion()
        {
            InitializeComponent();

            this.Load += FrmFacturacion_Load;

            btnBuscarCliente.Click += btnBuscarCliente_Click;
            btnLimpiarVenta.Click += btnLimpiarVenta_Click;
            btnQuitarFila.Click += btnQuitarFila_Click;
            btnGuardarVenta.Click += btnGuardarVenta_Click;

            txtDocumentoCliente.KeyDown += txtDocumentoCliente_KeyDown;
            txtMontoRecibido.TextChanged += txtMontoRecibido_TextChanged;
            cbMetodoPago.SelectedIndexChanged += cbMetodoPago_SelectedIndexChanged;

            dgvDetalleVenta.CellEndEdit += dgvDetalleVenta_CellEndEdit;
            dgvDetalleVenta.EditingControlShowing += dgvDetalleVenta_EditingControlShowing;
            dgvDetalleVenta.KeyDown += dgvDetalleVenta_KeyDown;
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            CargarPuntosEmision();
            CargarMetodosPago();
            CargarCodigosProductos();
            MostrarVendedorActivo();
            ConfigurarDetalleVenta();
            LimpiarVenta();
        }

        private void CargarPuntosEmision()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
            SELECT 
                IdBodega,
                Nombre + ' - Est: ' + ISNULL(Establecimiento,'') + ' / Pto: ' + ISNULL(PuntoEmision,'') AS PuntoEmision
            FROM Bodegas
            WHERE Estado = 1
            ORDER BY Nombre";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbBodegaVenta.DataSource = dt;
                cbBodegaVenta.DisplayMember = "PuntoEmision";
                cbBodegaVenta.ValueMember = "IdBodega";

                if (cbBodegaVenta.Items.Count > 0)
                    cbBodegaVenta.SelectedIndex = 0;
            }
        }

        private void CargarMetodosPago()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT IdMetodoPago, NombreMetodo
                    FROM MetodosPago
                    WHERE Estado = 1
                    ORDER BY NombreMetodo";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbMetodoPago.DataSource = dt;
                cbMetodoPago.DisplayMember = "NombreMetodo";
                cbMetodoPago.ValueMember = "IdMetodoPago";

                if (cbMetodoPago.Items.Count > 0)
                    cbMetodoPago.SelectedIndex = 0;
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

        private void MostrarVendedorActivo()
        {
            lblVendedorActivo.Text = SesionVenta.CodigoVendedor + " - " + SesionVenta.NombreVendedor;
        }

        private void ConfigurarDetalleVenta()
        {
            dtDetalle = new DataTable();

            dtDetalle.Columns.Add("IdProducto", typeof(int));
            dtDetalle.Columns.Add("Codigo", typeof(string));
            dtDetalle.Columns.Add("Descripcion", typeof(string));
            dtDetalle.Columns.Add("Unidad", typeof(string));
            dtDetalle.Columns.Add("Cantidad", typeof(decimal));
            dtDetalle.Columns.Add("Precio", typeof(decimal));
            dtDetalle.Columns.Add("Descuento", typeof(decimal));
            dtDetalle.Columns.Add("Subtotal", typeof(decimal));

            dgvDetalleVenta.DataSource = dtDetalle;
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.AllowUserToDeleteRows = false;
            dgvDetalleVenta.MultiSelect = false;
            dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvDetalleVenta.Columns.Contains("IdProducto"))
                dgvDetalleVenta.Columns["IdProducto"].Visible = false;

            dgvDetalleVenta.Columns["Descripcion"].ReadOnly = true;
            dgvDetalleVenta.Columns["Unidad"].ReadOnly = true;
            dgvDetalleVenta.Columns["Precio"].ReadOnly = true;
            dgvDetalleVenta.Columns["Subtotal"].ReadOnly = true;

            dgvDetalleVenta.Columns["Codigo"].HeaderText = "Código";
            dgvDetalleVenta.Columns["Descripcion"].HeaderText = "Producto";
            dgvDetalleVenta.Columns["Unidad"].HeaderText = "Unidad";
            dgvDetalleVenta.Columns["Cantidad"].HeaderText = "Cant.";
            dgvDetalleVenta.Columns["Precio"].HeaderText = "P.Unit";
            dgvDetalleVenta.Columns["Descuento"].HeaderText = "Desc";
            dgvDetalleVenta.Columns["Subtotal"].HeaderText = "Subtotal";

            dgvDetalleVenta.Columns["Cantidad"].DefaultCellStyle.Format = "0.00";
            dgvDetalleVenta.Columns["Precio"].DefaultCellStyle.Format = "0.00000";
            dgvDetalleVenta.Columns["Descuento"].DefaultCellStyle.Format = "0.00";
            dgvDetalleVenta.Columns["Subtotal"].DefaultCellStyle.Format = "0.00";

            dgvDetalleVenta.Columns["Codigo"].FillWeight = 90;
            dgvDetalleVenta.Columns["Descripcion"].FillWeight = 220;
            dgvDetalleVenta.Columns["Unidad"].FillWeight = 90;
            dgvDetalleVenta.Columns["Cantidad"].FillWeight = 70;
            dgvDetalleVenta.Columns["Precio"].FillWeight = 80;
            dgvDetalleVenta.Columns["Descuento"].FillWeight = 70;
            dgvDetalleVenta.Columns["Subtotal"].FillWeight = 90;
        }

        private void LimpiarVenta()
        {
            txtDocumentoCliente.Clear();
            lblNombreCliente.Text = "";
            idClienteActual = 0;

            dtDetalle.Rows.Clear();
            AgregarFilaVaciaSiNoExiste();

            txtMontoRecibido.Text = "0.00";
            lblCambio.Text = "0.00";

            rbFactura.Checked = true;

            CalcularTotalGeneral();
            ActualizarEstadoMontoRecibido();

            txtDocumentoCliente.Focus();
        }

        private void AgregarFilaVaciaSiNoExiste()
        {
            if (dtDetalle.Rows.Count == 0)
            {
                DataRow nueva = dtDetalle.NewRow();
                nueva["Cantidad"] = 1m;
                nueva["Precio"] = 0m;
                nueva["Descuento"] = 0m;
                nueva["Subtotal"] = 0m;
                dtDetalle.Rows.Add(nueva);
                return;
            }

            DataRow ultima = dtDetalle.Rows[dtDetalle.Rows.Count - 1];
            string codigo = ultima["Codigo"] == DBNull.Value ? "" : ultima["Codigo"].ToString().Trim();

            if (!string.IsNullOrWhiteSpace(codigo))
            {
                DataRow nueva = dtDetalle.NewRow();
                nueva["Cantidad"] = 1m;
                nueva["Precio"] = 0m;
                nueva["Descuento"] = 0m;
                nueva["Subtotal"] = 0m;
                dtDetalle.Rows.Add(nueva);
            }
        }

        private void txtDocumentoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarClientePorDocumento();
                e.SuppressKeyPress = true;
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarClientePorDocumento();
        }

        private void BuscarClientePorDocumento()
        {
            string documento = txtDocumentoCliente.Text.Trim();

            if (string.IsNullOrWhiteSpace(documento))
            {
                MessageBox.Show("Ingrese documento del cliente.");
                txtDocumentoCliente.Focus();
                return;
            }

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT TOP 1 IdCliente, Nombres
                    FROM Clientes
                    WHERE Documento = @Documento
                      AND Estado = 1";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Documento", documento);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    idClienteActual = Convert.ToInt32(dr["IdCliente"]);
                    lblNombreCliente.Text = dr["Nombres"].ToString();
                }
                else
                {
                    dr.Close();

                    DialogResult r = MessageBox.Show(
                        "Cliente no encontrado. ¿Desea crearlo?",
                        "Cliente",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (r == DialogResult.Yes)
                    {
                        FrmClientes frm = new FrmClientes();
                        frm.ShowDialog();
                        BuscarClientePorDocumento();
                    }
                    else
                    {
                        idClienteActual = 0;
                        lblNombreCliente.Text = "";
                    }
                }
            }
        }

        private void btnLimpiarVenta_Click(object sender, EventArgs e)
        {
            LimpiarVenta();
        }

        private void btnQuitarFila_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.CurrentRow == null || dgvDetalleVenta.CurrentRow.Index < 0)
                return;

            if (dtDetalle.Rows.Count == 1)
            {
                dtDetalle.Rows.Clear();
                AgregarFilaVaciaSiNoExiste();
            }
            else
            {
                dgvDetalleVenta.Rows.RemoveAt(dgvDetalleVenta.CurrentRow.Index);
            }

            CalcularTotalGeneral();
        }

        private void dgvDetalleVenta_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= SoloNumeros_KeyPress;

            string nombreColumna = dgvDetalleVenta.CurrentCell.OwningColumn.Name;

            if (nombreColumna == "Cantidad" || nombreColumna == "Descuento")
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

        private void dgvDetalleVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvDetalleVenta.CurrentCell != null)
            {
                e.SuppressKeyPress = true;
                dgvDetalleVenta.EndEdit();

                int fila = dgvDetalleVenta.CurrentCell.RowIndex;
                string columna = dgvDetalleVenta.CurrentCell.OwningColumn.Name;

                if (columna == "Codigo")
                {
                    CargarProductoEnFila(fila);

                    if (fila < dgvDetalleVenta.Rows.Count)
                    {
                        dgvDetalleVenta.CurrentCell = dgvDetalleVenta.Rows[fila].Cells["Cantidad"];
                        dgvDetalleVenta.BeginEdit(true);
                    }
                }
                else if (columna == "Cantidad" || columna == "Descuento")
                {
                    RecalcularFila(fila);
                    AgregarFilaVaciaSiNoExiste();
                    CalcularTotalGeneral();

                    int ultimaFila = dgvDetalleVenta.Rows.Count - 1;
                    if (ultimaFila >= 0)
                    {
                        dgvDetalleVenta.CurrentCell = dgvDetalleVenta.Rows[ultimaFila].Cells["Codigo"];
                        dgvDetalleVenta.BeginEdit(true);
                    }
                }
            }
        }

        private void dgvDetalleVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columna = dgvDetalleVenta.Columns[e.ColumnIndex].Name;

            if (columna == "Codigo")
            {
                CargarProductoEnFila(e.RowIndex);
            }
            else if (columna == "Cantidad" || columna == "Descuento")
            {
                RecalcularFila(e.RowIndex);
                AgregarFilaVaciaSiNoExiste();
                CalcularTotalGeneral();
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
                p.IdProducto,
                p.Codigo,
                p.Descripcion,
                u.NombreUnidad,
                i.PrecioVenta,
                i.Stock
            FROM Inventario i
            INNER JOIN Productos p ON i.IdProducto = p.IdProducto
            INNER JOIN Unidades u ON p.IdUnidad = u.IdUnidad
            WHERE p.Codigo = @Codigo
              AND i.IdBodega = @IdBodega
              AND i.Estado = 1
              AND p.Estado = 1";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@IdBodega", ConfiguracionSistema.IdBodegaStockGeneral);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dtDetalle.Rows[fila]["IdProducto"] = Convert.ToInt32(dr["IdProducto"]);
                    dtDetalle.Rows[fila]["Codigo"] = dr["Codigo"].ToString();
                    dtDetalle.Rows[fila]["Descripcion"] = dr["Descripcion"].ToString();
                    dtDetalle.Rows[fila]["Unidad"] = dr["NombreUnidad"].ToString();
                    dtDetalle.Rows[fila]["Cantidad"] = dtDetalle.Rows[fila]["Cantidad"] == DBNull.Value
                        ? 1m
                        : Convert.ToDecimal(dtDetalle.Rows[fila]["Cantidad"]);
                    dtDetalle.Rows[fila]["Precio"] = Convert.ToDecimal(dr["PrecioVenta"]);
                    dtDetalle.Rows[fila]["Descuento"] = dtDetalle.Rows[fila]["Descuento"] == DBNull.Value
                        ? 0m
                        : Convert.ToDecimal(dtDetalle.Rows[fila]["Descuento"]);

                    RecalcularFila(fila);
                    AgregarFilaVaciaSiNoExiste();
                    CalcularTotalGeneral();
                }
                else
                {
                    MessageBox.Show("Producto no encontrado en el stock general.");
                    dtDetalle.Rows[fila]["IdProducto"] = DBNull.Value;
                    dtDetalle.Rows[fila]["Descripcion"] = "";
                    dtDetalle.Rows[fila]["Unidad"] = "";
                    dtDetalle.Rows[fila]["Precio"] = 0m;
                    dtDetalle.Rows[fila]["Subtotal"] = 0m;
                }
            }
        }

        private void RecalcularFila(int fila)
        {
            if (fila < 0 || fila >= dtDetalle.Rows.Count)
                return;

            decimal cantidad = 0;
            decimal precio = 0;
            decimal descuento = 0;

            decimal.TryParse(dtDetalle.Rows[fila]["Cantidad"]?.ToString(), out cantidad);
            decimal.TryParse(dtDetalle.Rows[fila]["Precio"]?.ToString(), out precio);
            decimal.TryParse(dtDetalle.Rows[fila]["Descuento"]?.ToString(), out descuento);

            decimal subtotal = (cantidad * precio) - descuento;
            if (subtotal < 0) subtotal = 0;

            dtDetalle.Rows[fila]["Subtotal"] = subtotal;
        }

        private void cbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEstadoMontoRecibido();
            CalcularTotalGeneral();
        }

        private void ActualizarEstadoMontoRecibido()
        {
            string metodo = cbMetodoPago.Text.Trim().ToUpper();
            bool esEfectivo = metodo.Contains("EFECTIVO");

            txtMontoRecibido.Enabled = esEfectivo;

            if (!esEfectivo)
            {
                txtMontoRecibido.Text = lblTotalGeneral.Text;
                lblCambio.Text = "0.00";
            }
        }

        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            CalcularCambio();
        }

        private void CalcularTotalGeneral()
        {
            decimal subtotal = 0;
            decimal iva = 0;
            decimal total = 0;

            foreach (DataRow row in dtDetalle.Rows)
            {
                if (row["Subtotal"] != DBNull.Value)
                    subtotal += Convert.ToDecimal(row["Subtotal"]);
            }

            string metodoPago = cbMetodoPago.Text.Trim().ToUpper();

            if (metodoPago.Contains("TARJETA"))
                iva = subtotal * 0.12m;
            else
                iva = 0;

            total = subtotal + iva;

            lblSubtotalGeneral.Text = subtotal.ToString("0.00");
            lblIva.Text = iva.ToString("0.00");
            lblTotalGeneral.Text = total.ToString("0.00");

            if (!txtMontoRecibido.Enabled)
                txtMontoRecibido.Text = total.ToString("0.00");

            CalcularCambio();
        }

        private void CalcularCambio()
        {
            decimal total = 0;
            decimal recibido = 0;

            decimal.TryParse(lblTotalGeneral.Text, out total);
            decimal.TryParse(txtMontoRecibido.Text, out recibido);

            string metodo = cbMetodoPago.Text.Trim().ToUpper();

            if (metodo.Contains("EFECTIVO"))
            {
                decimal cambio = recibido - total;
                if (cambio < 0) cambio = 0;
                lblCambio.Text = cambio.ToString("0.00");
            }
            else
            {
                lblCambio.Text = "0.00";
            }
        }

        private string ObtenerTipoDocumento()
        {
            if (rbProforma.Checked) return "PROFORMA";
            if (rbNotaVenta.Checked) return "NOTA DE VENTA";
            return "FACTURA";
        }

        private int ObtenerIdUsuarioActual()
        {
            if (SesionUsuario.IdUsuario <= 0)
                throw new Exception("No hay usuario activo.");

            return SesionUsuario.IdUsuario;
        }

        private string GenerarNumeroDocumento(string tipoDocumento)
        {
            string prefijo = "DOC";

            if (tipoDocumento == "FACTURA")
                prefijo = "FAC";
            else if (tipoDocumento == "NOTA DE VENTA")
                prefijo = "NV";
            else if (tipoDocumento == "PROFORMA")
                prefijo = "PRO";

            return prefijo + "-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private int InsertarVenta(
    SqlConnection cn,
    SqlTransaction tx,
    string numeroDocumento,
    int idCliente,
    int idUsuario,
    int idVendedor,
    int idMetodoPago,
    int idCajaEmision,
    decimal subtotal,
    decimal descuento,
    decimal iva,
    decimal total,
    string tipoDocumento)
        {
            string query = @"
    INSERT INTO Ventas
    (
        NumeroDocumento,
        IdCliente,
        IdUsuario,
        IdVendedor,
        IdMetodoPago,
        IdBodega,
        IdCajaEmision,
        FechaDocumento,
        FechaCreacion,
        Subtotal,
        Descuento,
        Iva,
        Total,
        Estado,
        TipoDocumento,
        Observacion
    )
    VALUES
    (
        @NumeroDocumento,
        @IdCliente,
        @IdUsuario,
        @IdVendedor,
        @IdMetodoPago,
        @IdBodega,
        @IdCajaEmision,
        CAST(GETDATE() AS DATE),
        GETDATE(),
        @Subtotal,
        @Descuento,
        @Iva,
        @Total,
        @Estado,
        @TipoDocumento,
        @Observacion
    );

    SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, cn, tx);
            cmd.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
            cmd.Parameters.AddWithValue("@IdCliente", idCliente);
            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@IdVendedor", idVendedor == 0 ? (object)DBNull.Value : idVendedor);
            cmd.Parameters.AddWithValue("@IdMetodoPago", idMetodoPago);
            cmd.Parameters.AddWithValue("@IdBodega", ConfiguracionSistema.IdBodegaStockGeneral);
            cmd.Parameters.AddWithValue("@IdCajaEmision", idCajaEmision);
            cmd.Parameters.AddWithValue("@Subtotal", subtotal);
            cmd.Parameters.AddWithValue("@Descuento", descuento);
            cmd.Parameters.AddWithValue("@Iva", iva);
            cmd.Parameters.AddWithValue("@Total", total);
            cmd.Parameters.AddWithValue("@Estado", tipoDocumento == "PROFORMA" ? "PROFORMA" : "ACTIVA");
            cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
            cmd.Parameters.AddWithValue("@Observacion", "");

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void InsertarDetalleVenta(
            SqlConnection cn,
            SqlTransaction tx,
            int idVenta,
            int idProducto,
            int idBodega,
            decimal cantidad,
            decimal precioUnitario,
            decimal descuento,
            decimal subtotal,
            decimal iva,
            decimal totalLinea)
        {
            string query = @"
        INSERT INTO DetalleVentas
        (
            IdVenta,
            IdProducto,
            IdBodega,
            Cantidad,
            PrecioUnitario,
            Descuento,
            Subtotal,
            Iva,
            TotalLinea,
            Estado,
            FechaCreacion
        )
        VALUES
        (
            @IdVenta,
            @IdProducto,
            @IdBodega,
            @Cantidad,
            @PrecioUnitario,
            @Descuento,
            @Subtotal,
            @Iva,
            @TotalLinea,
            1,
            GETDATE()
        )";

            SqlCommand cmd = new SqlCommand(query, cn, tx);
            cmd.Parameters.AddWithValue("@IdVenta", idVenta);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            cmd.Parameters.AddWithValue("@IdBodega", idBodega);
            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
            cmd.Parameters.AddWithValue("@PrecioUnitario", precioUnitario);
            cmd.Parameters.AddWithValue("@Descuento", descuento);
            cmd.Parameters.AddWithValue("@Subtotal", subtotal);
            cmd.Parameters.AddWithValue("@Iva", iva);
            cmd.Parameters.AddWithValue("@TotalLinea", totalLinea);

            cmd.ExecuteNonQuery();
        }

        private void ValidarStock(
            SqlConnection cn,
            SqlTransaction tx,
            int idProducto,
            int idBodega,
            decimal cantidadSolicitada)
        {
            string query = @"
        SELECT Stock
        FROM Inventario
        WHERE IdProducto = @IdProducto
          AND IdBodega = @IdBodega
          AND Estado = 1";

            SqlCommand cmd = new SqlCommand(query, cn, tx);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            cmd.Parameters.AddWithValue("@IdBodega", idBodega);

            object result = cmd.ExecuteScalar();

            if (result == null || result == DBNull.Value)
                throw new Exception("No existe inventario para uno de los productos seleccionados.");

            decimal stockActual = Convert.ToDecimal(result);

            if (stockActual < cantidadSolicitada)
                throw new Exception("Stock insuficiente para uno de los productos.");
        }

        private void DescontarInventario(
            SqlConnection cn,
            SqlTransaction tx,
            int idProducto,
            int idBodega,
            decimal cantidad)
        {
            string query = @"
        UPDATE Inventario
        SET Stock = Stock - @Cantidad,
            FechaActualizacion = GETDATE()
        WHERE IdProducto = @IdProducto
          AND IdBodega = @IdBodega";

            SqlCommand cmd = new SqlCommand(query, cn, tx);
            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            cmd.Parameters.AddWithValue("@IdBodega", idBodega);

            cmd.ExecuteNonQuery();
        }

        private void InsertarMovimientoInventario(
            SqlConnection cn,
            SqlTransaction tx,
            int idProducto,
            int idBodega,
            decimal cantidad,
            decimal precioUnitario,
            string numeroDocumento,
            string tipoDocumento)
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
            @TipoMovimiento,
            @Cantidad,
            NULL,
            @PrecioUnitario,
            GETDATE(),
            @Referencia,
            @Observacion
        )";

            SqlCommand cmd = new SqlCommand(query, cn, tx);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            cmd.Parameters.AddWithValue("@IdBodega", idBodega);
            cmd.Parameters.AddWithValue("@TipoMovimiento", "SALIDA");
            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
            cmd.Parameters.AddWithValue("@PrecioUnitario", precioUnitario);
            cmd.Parameters.AddWithValue("@Referencia", numeroDocumento);
            cmd.Parameters.AddWithValue("@Observacion", tipoDocumento);

            cmd.ExecuteNonQuery();
        }
        private void ImprimirComprobante(int idVenta, string tipoDocumento)
        {
            MessageBox.Show(
                $"Aquí irá la impresión de {tipoDocumento}.\nID Venta: {idVenta}",
                "Impresión",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                var filasValidas = dtDetalle.AsEnumerable()
                    .Where(r => r["IdProducto"] != DBNull.Value
                             && !string.IsNullOrWhiteSpace(r["Codigo"]?.ToString()))
                    .ToList();

                if (idClienteActual == 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente.");
                    txtDocumentoCliente.Focus();
                    return;
                }

                if (cbBodegaVenta.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un punto de emisión.");
                    cbBodegaVenta.Focus();
                    return;
                }

                if (cbMetodoPago.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un método de pago.");
                    cbMetodoPago.Focus();
                    return;
                }

                if (filasValidas.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un producto.");
                    return;
                }

                string metodoPago = cbMetodoPago.Text.Trim().ToUpper();

                decimal subtotal = 0m;
                decimal descuentoTotal = 0m;
                decimal ivaTotal = 0m;
                decimal total = 0m;

                foreach (DataRow row in filasValidas)
                {
                    decimal cantidad = Convert.ToDecimal(row["Cantidad"]);
                    decimal precio = Convert.ToDecimal(row["Precio"]);
                    decimal descuento = Convert.ToDecimal(row["Descuento"]);
                    decimal subtotalLinea = Convert.ToDecimal(row["Subtotal"]);

                    if (cantidad <= 0)
                    {
                        MessageBox.Show("Hay productos con cantidad inválida.");
                        return;
                    }

                    subtotal += subtotalLinea;
                    descuentoTotal += descuento;
                }

                if (metodoPago.Contains("TARJETA"))
                    ivaTotal = subtotal * 0.12m;
                else
                    ivaTotal = 0m;

                total = subtotal + ivaTotal;

                if (metodoPago.Contains("EFECTIVO"))
                {
                    decimal montoRecibido = 0m;
                    decimal.TryParse(txtMontoRecibido.Text.Trim(), out montoRecibido);

                    if (montoRecibido < total)
                    {
                        MessageBox.Show("El monto recibido es menor al total.");
                        txtMontoRecibido.Focus();
                        return;
                    }
                }

                string tipoDocumento = ObtenerTipoDocumento();
                int idCajaEmision = Convert.ToInt32(cbBodegaVenta.SelectedValue);
                int idBodegaStock = ConfiguracionSistema.IdBodegaStockGeneral;
                int idMetodoPago = Convert.ToInt32(cbMetodoPago.SelectedValue);
                int idUsuario = ObtenerIdUsuarioActual();
                int idVendedor = SesionVenta.IdVendedor;
                string numeroDocumento = GenerarNumeroDocumento(tipoDocumento);

                using (SqlConnection cn = new Conexion().ObtenerConexion())
                {
                    cn.Open();

                    using (SqlTransaction tx = cn.BeginTransaction())
                    {
                        try
                        {
                            int idVenta = InsertarVenta(
                                cn, tx,
                                numeroDocumento,
                                idClienteActual,
                                idUsuario,
                                idVendedor,
                                idMetodoPago,
                                idCajaEmision,
                                subtotal,
                                descuentoTotal,
                                ivaTotal,
                                total,
                                tipoDocumento
                            );

                            foreach (DataRow row in filasValidas)
                            {
                                int idProducto = Convert.ToInt32(row["IdProducto"]);
                                decimal cantidad = Convert.ToDecimal(row["Cantidad"]);
                                decimal precio = Convert.ToDecimal(row["Precio"]);
                                decimal descuento = Convert.ToDecimal(row["Descuento"]);
                                decimal subtotalLinea = Convert.ToDecimal(row["Subtotal"]);
                                decimal ivaLinea = 0m;

                                if (metodoPago.Contains("TARJETA"))
                                    ivaLinea = subtotalLinea * 0.12m;

                                decimal totalLinea = subtotalLinea + ivaLinea;

                                InsertarDetalleVenta(
                                    cn, tx,
                                    idVenta,
                                    idProducto,
                                    idBodegaStock,
                                    cantidad,
                                    precio,
                                    descuento,
                                    subtotalLinea,
                                    ivaLinea,
                                    totalLinea
                                );

                                if (tipoDocumento != "PROFORMA")
                                {
                                    ValidarStock(cn, tx, idProducto, idBodegaStock, cantidad);
                                    DescontarInventario(cn, tx, idProducto, idBodegaStock, cantidad);
                                    InsertarMovimientoInventario(
                                        cn, tx,
                                        idProducto,
                                        idBodegaStock,
                                        cantidad,
                                        precio,
                                        numeroDocumento,
                                        tipoDocumento
                                    );
                                }
                            }

                            tx.Commit();

                            DialogResult resultado = MessageBox.Show(
                                $"{tipoDocumento} guardada correctamente.\n\n" +
                                $"Número: {numeroDocumento}\n" +
                                $"Total: {total:0.00}\n\n" +
                                $"¿Desea imprimir el comprobante?",
                                "Documento guardado",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information
                            );

                            if (resultado == DialogResult.Yes)
                            {
                                ImprimirComprobante(idVenta, tipoDocumento);
                            }

                            LimpiarVenta();
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                            MessageBox.Show("Error al guardar la venta: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
            }
        }

        private void FrmFacturacion_Load_1(object sender, EventArgs e)
        {

        }
    }
}