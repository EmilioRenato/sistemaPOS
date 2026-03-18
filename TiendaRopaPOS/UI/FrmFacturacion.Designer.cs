namespace TiendaRopaPOS.UI
{
    partial class FrmFacturacion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblModoRapido = new System.Windows.Forms.Label();
            this.lblVendedorActivo = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.cbBodegaVenta = new System.Windows.Forms.ComboBox();
            this.lblBodegaVenta = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtDocumentoCliente = new System.Windows.Forms.TextBox();
            this.lblDocumentoCliente = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnQuitarFila = new System.Windows.Forms.Button();
            this.btnLimpiarVenta = new System.Windows.Forms.Button();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblVentaOk = new System.Windows.Forms.Label();
            this.btnGuardarVenta = new System.Windows.Forms.Button();
            this.lblCambio = new System.Windows.Forms.Label();
            this.lblTextoCambio = new System.Windows.Forms.Label();
            this.txtMontoRecibido = new System.Windows.Forms.TextBox();
            this.lblTextoMontoRecibido = new System.Windows.Forms.Label();
            this.rbProforma = new System.Windows.Forms.RadioButton();
            this.rbNotaVenta = new System.Windows.Forms.RadioButton();
            this.rbFactura = new System.Windows.Forms.RadioButton();
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblTextoIva = new System.Windows.Forms.Label();
            this.lblSubtotalGeneral = new System.Windows.Forms.Label();
            this.lblTextoSubtotal = new System.Windows.Forms.Label();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.lblTextoTotal = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.panelTop.Controls.Add(this.lblModoRapido);
            this.panelTop.Controls.Add(this.lblVendedorActivo);
            this.panelTop.Controls.Add(this.lblVendedor);
            this.panelTop.Controls.Add(this.cbBodegaVenta);
            this.panelTop.Controls.Add(this.lblBodegaVenta);
            this.panelTop.Controls.Add(this.lblNombreCliente);
            this.panelTop.Controls.Add(this.btnBuscarCliente);
            this.panelTop.Controls.Add(this.txtDocumentoCliente);
            this.panelTop.Controls.Add(this.lblDocumentoCliente);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(15, 12, 15, 8);
            this.panelTop.Size = new System.Drawing.Size(1100, 92);
            this.panelTop.TabIndex = 0;
            // 
            // lblModoRapido
            // 
            this.lblModoRapido.AutoSize = true;
            this.lblModoRapido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblModoRapido.ForeColor = System.Drawing.Color.FromArgb(0, 184, 148);
            this.lblModoRapido.Location = new System.Drawing.Point(944, 18);
            this.lblModoRapido.Name = "lblModoRapido";
            this.lblModoRapido.Size = new System.Drawing.Size(117, 15);
            this.lblModoRapido.TabIndex = 8;
            this.lblModoRapido.Text = "⚡ MODO CAJERO";
            // 
            // lblVendedorActivo
            // 
            this.lblVendedorActivo.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblVendedorActivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVendedorActivo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVendedorActivo.ForeColor = System.Drawing.Color.White;
            this.lblVendedorActivo.Location = new System.Drawing.Point(713, 47);
            this.lblVendedorActivo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVendedorActivo.Name = "lblVendedorActivo";
            this.lblVendedorActivo.Size = new System.Drawing.Size(348, 28);
            this.lblVendedorActivo.TabIndex = 7;
            this.lblVendedorActivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVendedor.ForeColor = System.Drawing.Color.White;
            this.lblVendedor.Location = new System.Drawing.Point(630, 52);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(70, 19);
            this.lblVendedor.TabIndex = 6;
            this.lblVendedor.Text = "Vendedor";
            // 
            // cbBodegaVenta
            // 
            this.cbBodegaVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBodegaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBodegaVenta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbBodegaVenta.FormattingEnabled = true;
            this.cbBodegaVenta.Location = new System.Drawing.Point(713, 15);
            this.cbBodegaVenta.Margin = new System.Windows.Forms.Padding(2);
            this.cbBodegaVenta.Name = "cbBodegaVenta";
            this.cbBodegaVenta.Size = new System.Drawing.Size(211, 25);
            this.cbBodegaVenta.TabIndex = 5;
            // 
            // lblBodegaVenta
            // 
            this.lblBodegaVenta.AutoSize = true;
            this.lblBodegaVenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBodegaVenta.ForeColor = System.Drawing.Color.White;
            this.lblBodegaVenta.Location = new System.Drawing.Point(630, 18);
            this.lblBodegaVenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBodegaVenta.Name = "lblBodegaVenta";
            this.lblBodegaVenta.Size = new System.Drawing.Size(34, 19);
            this.lblBodegaVenta.TabIndex = 4;
            this.lblBodegaVenta.Text = "P.E.";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombreCliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNombreCliente.ForeColor = System.Drawing.Color.White;
            this.lblNombreCliente.Location = new System.Drawing.Point(134, 49);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(462, 26);
            this.lblNombreCliente.TabIndex = 3;
            this.lblNombreCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(9, 132, 227);
            this.btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCliente.Location = new System.Drawing.Point(408, 14);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(103, 28);
            this.btnBuscarCliente.TabIndex = 2;
            this.btnBuscarCliente.Text = "🔎 Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            // 
            // txtDocumentoCliente
            // 
            this.txtDocumentoCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDocumentoCliente.Location = new System.Drawing.Point(134, 15);
            this.txtDocumentoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtDocumentoCliente.Name = "txtDocumentoCliente";
            this.txtDocumentoCliente.Size = new System.Drawing.Size(258, 25);
            this.txtDocumentoCliente.TabIndex = 1;
            // 
            // lblDocumentoCliente
            // 
            this.lblDocumentoCliente.AutoSize = true;
            this.lblDocumentoCliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDocumentoCliente.ForeColor = System.Drawing.Color.White;
            this.lblDocumentoCliente.Location = new System.Drawing.Point(17, 18);
            this.lblDocumentoCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDocumentoCliente.Name = "lblDocumentoCliente";
            this.lblDocumentoCliente.Size = new System.Drawing.Size(89, 19);
            this.lblDocumentoCliente.TabIndex = 0;
            this.lblDocumentoCliente.Text = "Documento";
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(223, 230, 233);
            this.panelBotones.Controls.Add(this.btnQuitarFila);
            this.panelBotones.Controls.Add(this.btnLimpiarVenta);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBotones.Location = new System.Drawing.Point(0, 92);
            this.panelBotones.Margin = new System.Windows.Forms.Padding(2);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelBotones.Size = new System.Drawing.Size(1100, 55);
            this.panelBotones.TabIndex = 1;
            // 
            // btnQuitarFila
            // 
            this.btnQuitarFila.BackColor = System.Drawing.Color.FromArgb(214, 48, 49);
            this.btnQuitarFila.FlatAppearance.BorderSize = 0;
            this.btnQuitarFila.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarFila.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuitarFila.ForeColor = System.Drawing.Color.White;
            this.btnQuitarFila.Location = new System.Drawing.Point(180, 10);
            this.btnQuitarFila.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(118, 32);
            this.btnQuitarFila.TabIndex = 2;
            this.btnQuitarFila.Text = "🗑 Quitar fila";
            this.btnQuitarFila.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarVenta
            // 
            this.btnLimpiarVenta.BackColor = System.Drawing.Color.FromArgb(253, 203, 110);
            this.btnLimpiarVenta.FlatAppearance.BorderSize = 0;
            this.btnLimpiarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarVenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarVenta.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiarVenta.Location = new System.Drawing.Point(30, 10);
            this.btnLimpiarVenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiarVenta.Name = "btnLimpiarVenta";
            this.btnLimpiarVenta.Size = new System.Drawing.Size(125, 32);
            this.btnLimpiarVenta.TabIndex = 1;
            this.btnLimpiarVenta.Text = "🧹 Limpiar";
            this.btnLimpiarVenta.UseVisualStyleBackColor = false;
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AllowUserToAddRows = false;
            this.dgvDetalleVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleVenta.BackgroundColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.dgvDetalleVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(0, 147);
            this.dgvDetalleVenta.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetalleVenta.MultiSelect = false;
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.RowHeadersWidth = 51;
            this.dgvDetalleVenta.RowTemplate.Height = 24;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(1100, 343);
            this.dgvDetalleVenta.TabIndex = 2;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.panelBottom.Controls.Add(this.lblVentaOk);
            this.panelBottom.Controls.Add(this.btnGuardarVenta);
            this.panelBottom.Controls.Add(this.lblCambio);
            this.panelBottom.Controls.Add(this.lblTextoCambio);
            this.panelBottom.Controls.Add(this.txtMontoRecibido);
            this.panelBottom.Controls.Add(this.lblTextoMontoRecibido);
            this.panelBottom.Controls.Add(this.rbProforma);
            this.panelBottom.Controls.Add(this.rbNotaVenta);
            this.panelBottom.Controls.Add(this.rbFactura);
            this.panelBottom.Controls.Add(this.cbMetodoPago);
            this.panelBottom.Controls.Add(this.lblMetodoPago);
            this.panelBottom.Controls.Add(this.lblIva);
            this.panelBottom.Controls.Add(this.lblTextoIva);
            this.panelBottom.Controls.Add(this.lblSubtotalGeneral);
            this.panelBottom.Controls.Add(this.lblTextoSubtotal);
            this.panelBottom.Controls.Add(this.lblTotalGeneral);
            this.panelBottom.Controls.Add(this.lblTextoTotal);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 490);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelBottom.Size = new System.Drawing.Size(1100, 120);
            this.panelBottom.TabIndex = 3;
            // 
            // lblVentaOk
            // 
            this.lblVentaOk.AutoSize = true;
            this.lblVentaOk.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVentaOk.ForeColor = System.Drawing.Color.FromArgb(0, 184, 148);
            this.lblVentaOk.Location = new System.Drawing.Point(815, 88);
            this.lblVentaOk.Name = "lblVentaOk";
            this.lblVentaOk.Size = new System.Drawing.Size(0, 19);
            this.lblVentaOk.TabIndex = 16;
            // 
            // btnGuardarVenta
            // 
            this.btnGuardarVenta.BackColor = System.Drawing.Color.FromArgb(0, 184, 148);
            this.btnGuardarVenta.FlatAppearance.BorderSize = 0;
            this.btnGuardarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarVenta.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnGuardarVenta.ForeColor = System.Drawing.Color.White;
            this.btnGuardarVenta.Location = new System.Drawing.Point(910, 18);
            this.btnGuardarVenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarVenta.Name = "btnGuardarVenta";
            this.btnGuardarVenta.Size = new System.Drawing.Size(160, 62);
            this.btnGuardarVenta.TabIndex = 15;
            this.btnGuardarVenta.Text = "💳 PAGAR";
            this.btnGuardarVenta.UseVisualStyleBackColor = false;
            // 
            // lblCambio
            // 
            this.lblCambio.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCambio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCambio.ForeColor = System.Drawing.Color.White;
            this.lblCambio.Location = new System.Drawing.Point(135, 76);
            this.lblCambio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(140, 26);
            this.lblCambio.TabIndex = 14;
            this.lblCambio.Text = "0.00";
            this.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoCambio
            // 
            this.lblTextoCambio.AutoSize = true;
            this.lblTextoCambio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTextoCambio.ForeColor = System.Drawing.Color.White;
            this.lblTextoCambio.Location = new System.Drawing.Point(17, 80);
            this.lblTextoCambio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoCambio.Name = "lblTextoCambio";
            this.lblTextoCambio.Size = new System.Drawing.Size(63, 19);
            this.lblTextoCambio.TabIndex = 13;
            this.lblTextoCambio.Text = "Cambio";
            // 
            // txtMontoRecibido
            // 
            this.txtMontoRecibido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMontoRecibido.Location = new System.Drawing.Point(135, 42);
            this.txtMontoRecibido.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoRecibido.Name = "txtMontoRecibido";
            this.txtMontoRecibido.Size = new System.Drawing.Size(140, 25);
            this.txtMontoRecibido.TabIndex = 12;
            // 
            // txtMontoRecibido
            // 
            this.txtMontoRecibido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMontoRecibido.Location = new System.Drawing.Point(135, 42);
            this.txtMontoRecibido.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoRecibido.Name = "txtMontoRecibido";
            this.txtMontoRecibido.Size = new System.Drawing.Size(140, 25);
            this.txtMontoRecibido.TabIndex = 12;
            // 
            // lblTextoMontoRecibido
            // 
            this.lblTextoMontoRecibido.AutoSize = true;
            this.lblTextoMontoRecibido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTextoMontoRecibido.ForeColor = System.Drawing.Color.White;
            this.lblTextoMontoRecibido.Location = new System.Drawing.Point(17, 46);
            this.lblTextoMontoRecibido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoMontoRecibido.Name = "lblTextoMontoRecibido";
            this.lblTextoMontoRecibido.Size = new System.Drawing.Size(114, 19);
            this.lblTextoMontoRecibido.TabIndex = 11;
            this.lblTextoMontoRecibido.Text = "Monto recibido";
            // 
            // rbProforma
            // 
            this.rbProforma.AutoSize = true;
            this.rbProforma.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbProforma.ForeColor = System.Drawing.Color.White;
            this.rbProforma.Location = new System.Drawing.Point(546, 80);
            this.rbProforma.Margin = new System.Windows.Forms.Padding(2);
            this.rbProforma.Name = "rbProforma";
            this.rbProforma.Size = new System.Drawing.Size(89, 23);
            this.rbProforma.TabIndex = 10;
            this.rbProforma.Text = "Proforma";
            this.rbProforma.UseVisualStyleBackColor = true;
            // 
            // rbNotaVenta
            // 
            this.rbNotaVenta.AutoSize = true;
            this.rbNotaVenta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbNotaVenta.ForeColor = System.Drawing.Color.White;
            this.rbNotaVenta.Location = new System.Drawing.Point(413, 80);
            this.rbNotaVenta.Margin = new System.Windows.Forms.Padding(2);
            this.rbNotaVenta.Name = "rbNotaVenta";
            this.rbNotaVenta.Size = new System.Drawing.Size(110, 23);
            this.rbNotaVenta.TabIndex = 9;
            this.rbNotaVenta.Text = "Nota de venta";
            this.rbNotaVenta.UseVisualStyleBackColor = true;
            // 
            // rbFactura
            // 
            this.rbFactura.AutoSize = true;
            this.rbFactura.Checked = true;
            this.rbFactura.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.rbFactura.ForeColor = System.Drawing.Color.White;
            this.rbFactura.Location = new System.Drawing.Point(324, 80);
            this.rbFactura.Margin = new System.Windows.Forms.Padding(2);
            this.rbFactura.Name = "rbFactura";
            this.rbFactura.Size = new System.Drawing.Size(78, 23);
            this.rbFactura.TabIndex = 8;
            this.rbFactura.TabStop = true;
            this.rbFactura.Text = "Factura";
            this.rbFactura.UseVisualStyleBackColor = true;
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetodoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMetodoPago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbMetodoPago.FormattingEnabled = true;
            this.cbMetodoPago.Location = new System.Drawing.Point(135, 10);
            this.cbMetodoPago.Margin = new System.Windows.Forms.Padding(2);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(202, 25);
            this.cbMetodoPago.TabIndex = 7;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMetodoPago.ForeColor = System.Drawing.Color.White;
            this.lblMetodoPago.Location = new System.Drawing.Point(17, 14);
            this.lblMetodoPago.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(106, 19);
            this.lblMetodoPago.TabIndex = 6;
            this.lblMetodoPago.Text = "Método pago";
            // 
            // lblIva
            // 
            this.lblIva.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIva.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIva.ForeColor = System.Drawing.Color.White;
            this.lblIva.Location = new System.Drawing.Point(650, 43);
            this.lblIva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(120, 26);
            this.lblIva.TabIndex = 5;
            this.lblIva.Text = "0.00";
            this.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoIva
            // 
            this.lblTextoIva.AutoSize = true;
            this.lblTextoIva.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTextoIva.ForeColor = System.Drawing.Color.White;
            this.lblTextoIva.Location = new System.Drawing.Point(607, 47);
            this.lblTextoIva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoIva.Name = "lblTextoIva";
            this.lblTextoIva.Size = new System.Drawing.Size(33, 19);
            this.lblTextoIva.TabIndex = 4;
            this.lblTextoIva.Text = "IVA";
            // 
            // lblSubtotalGeneral
            // 
            this.lblSubtotalGeneral.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.lblSubtotalGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubtotalGeneral.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalGeneral.ForeColor = System.Drawing.Color.White;
            this.lblSubtotalGeneral.Location = new System.Drawing.Point(650, 10);
            this.lblSubtotalGeneral.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtotalGeneral.Name = "lblSubtotalGeneral";
            this.lblSubtotalGeneral.Size = new System.Drawing.Size(120, 26);
            this.lblSubtotalGeneral.TabIndex = 3;
            this.lblSubtotalGeneral.Text = "0.00";
            this.lblSubtotalGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoSubtotal
            // 
            this.lblTextoSubtotal.AutoSize = true;
            this.lblTextoSubtotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTextoSubtotal.ForeColor = System.Drawing.Color.White;
            this.lblTextoSubtotal.Location = new System.Drawing.Point(573, 14);
            this.lblTextoSubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoSubtotal.Name = "lblTextoSubtotal";
            this.lblTextoSubtotal.Size = new System.Drawing.Size(67, 19);
            this.lblTextoSubtotal.TabIndex = 2;
            this.lblTextoSubtotal.Text = "Subtotal";
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.BackColor = System.Drawing.Color.FromArgb(0, 184, 148);
            this.lblTotalGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalGeneral.ForeColor = System.Drawing.Color.White;
            this.lblTotalGeneral.Location = new System.Drawing.Point(778, 18);
            this.lblTotalGeneral.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(120, 49);
            this.lblTotalGeneral.TabIndex = 1;
            this.lblTotalGeneral.Text = "0.00";
            this.lblTotalGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoTotal
            // 
            this.lblTextoTotal.AutoSize = true;
            this.lblTextoTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTextoTotal.ForeColor = System.Drawing.Color.White;
            this.lblTextoTotal.Location = new System.Drawing.Point(781, 85);
            this.lblTextoTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoTotal.Name = "lblTextoTotal";
            this.lblTextoTotal.Size = new System.Drawing.Size(47, 21);
            this.lblTextoTotal.TabIndex = 0;
            this.lblTextoTotal.Text = "Total";
            // 
            // FrmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.ClientSize = new System.Drawing.Size(1100, 610);
            this.Controls.Add(this.dgvDetalleVenta);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmFacturacion";
            this.Text = "Facturación";
            this.Load += new System.EventHandler(this.FrmFacturacion_Load_1);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblModoRapido;
        private System.Windows.Forms.Label lblVendedorActivo;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.ComboBox cbBodegaVenta;
        private System.Windows.Forms.Label lblBodegaVenta;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtDocumentoCliente;
        private System.Windows.Forms.Label lblDocumentoCliente;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnQuitarFila;
        private System.Windows.Forms.Button btnLimpiarVenta;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblVentaOk;
        private System.Windows.Forms.Button btnGuardarVenta;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Label lblTextoCambio;
        private System.Windows.Forms.TextBox txtMontoRecibido;
        private System.Windows.Forms.Label lblTextoMontoRecibido;
        private System.Windows.Forms.RadioButton rbProforma;
        private System.Windows.Forms.RadioButton rbNotaVenta;
        private System.Windows.Forms.RadioButton rbFactura;
        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.Label lblTextoIva;
        private System.Windows.Forms.Label lblSubtotalGeneral;
        private System.Windows.Forms.Label lblTextoSubtotal;
        private System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.Label lblTextoTotal;
    }
}