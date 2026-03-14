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
            this.btnGuardarVenta = new System.Windows.Forms.Button();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
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
            this.panelTop.Size = new System.Drawing.Size(993, 77);
            this.panelTop.TabIndex = 0;
            // 
            // lblVendedorActivo
            // 
            this.lblVendedorActivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVendedorActivo.Location = new System.Drawing.Point(690, 16);
            this.lblVendedorActivo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVendedorActivo.Name = "lblVendedorActivo";
            this.lblVendedorActivo.Size = new System.Drawing.Size(210, 20);
            this.lblVendedorActivo.TabIndex = 7;
            this.lblVendedorActivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(634, 20);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(53, 13);
            this.lblVendedor.TabIndex = 6;
            this.lblVendedor.Text = "Vendedor";
            // 
            // cbBodegaVenta
            // 
            this.cbBodegaVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBodegaVenta.FormattingEnabled = true;
            this.cbBodegaVenta.Location = new System.Drawing.Point(458, 16);
            this.cbBodegaVenta.Margin = new System.Windows.Forms.Padding(2);
            this.cbBodegaVenta.Name = "cbBodegaVenta";
            this.cbBodegaVenta.Size = new System.Drawing.Size(151, 21);
            this.cbBodegaVenta.TabIndex = 5;
            // 
            // lblBodegaVenta
            // 
            this.lblBodegaVenta.AutoSize = true;
            this.lblBodegaVenta.Location = new System.Drawing.Point(409, 20);
            this.lblBodegaVenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBodegaVenta.Name = "lblBodegaVenta";
            this.lblBodegaVenta.Size = new System.Drawing.Size(27, 13);
            this.lblBodegaVenta.TabIndex = 4;
            this.lblBodegaVenta.Text = "P. E";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombreCliente.Location = new System.Drawing.Point(82, 45);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(316, 20);
            this.lblNombreCliente.TabIndex = 3;
            this.lblNombreCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(308, 15);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(75, 24);
            this.btnBuscarCliente.TabIndex = 2;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            // 
            // txtDocumentoCliente
            // 
            this.txtDocumentoCliente.Location = new System.Drawing.Point(82, 18);
            this.txtDocumentoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtDocumentoCliente.Name = "txtDocumentoCliente";
            this.txtDocumentoCliente.Size = new System.Drawing.Size(211, 20);
            this.txtDocumentoCliente.TabIndex = 1;
            // 
            // lblDocumentoCliente
            // 
            this.lblDocumentoCliente.AutoSize = true;
            this.lblDocumentoCliente.Location = new System.Drawing.Point(17, 20);
            this.lblDocumentoCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDocumentoCliente.Name = "lblDocumentoCliente";
            this.lblDocumentoCliente.Size = new System.Drawing.Size(62, 13);
            this.lblDocumentoCliente.TabIndex = 0;
            this.lblDocumentoCliente.Text = "Documento";
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnQuitarFila);
            this.panelBotones.Controls.Add(this.btnLimpiarVenta);
            this.panelBotones.Controls.Add(this.btnGuardarVenta);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBotones.Location = new System.Drawing.Point(0, 77);
            this.panelBotones.Margin = new System.Windows.Forms.Padding(2);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelBotones.Size = new System.Drawing.Size(993, 49);
            this.panelBotones.TabIndex = 1;
            // 
            // btnQuitarFila
            // 
            this.btnQuitarFila.Location = new System.Drawing.Point(285, 10);
            this.btnQuitarFila.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(82, 26);
            this.btnQuitarFila.TabIndex = 2;
            this.btnQuitarFila.Text = "Quitar fila";
            this.btnQuitarFila.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarVenta
            // 
            this.btnLimpiarVenta.Location = new System.Drawing.Point(180, 10);
            this.btnLimpiarVenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiarVenta.Name = "btnLimpiarVenta";
            this.btnLimpiarVenta.Size = new System.Drawing.Size(82, 26);
            this.btnLimpiarVenta.TabIndex = 1;
            this.btnLimpiarVenta.Text = "Limpiar";
            this.btnLimpiarVenta.UseVisualStyleBackColor = true;
            // 
            // btnGuardarVenta
            // 
            this.btnGuardarVenta.Location = new System.Drawing.Point(75, 10);
            this.btnGuardarVenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarVenta.Name = "btnGuardarVenta";
            this.btnGuardarVenta.Size = new System.Drawing.Size(82, 26);
            this.btnGuardarVenta.TabIndex = 0;
            this.btnGuardarVenta.Text = "Guardar";
            this.btnGuardarVenta.UseVisualStyleBackColor = true;
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AllowUserToAddRows = false;
            this.dgvDetalleVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(0, 126);
            this.dgvDetalleVenta.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetalleVenta.MultiSelect = false;
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.RowHeadersWidth = 51;
            this.dgvDetalleVenta.RowTemplate.Height = 24;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(993, 338);
            this.dgvDetalleVenta.TabIndex = 2;
            // 
            // panelBottom
            // 
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
            this.panelBottom.Location = new System.Drawing.Point(0, 464);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelBottom.Size = new System.Drawing.Size(993, 89);
            this.panelBottom.TabIndex = 3;
            // 
            // lblCambio
            // 
            this.lblCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCambio.Location = new System.Drawing.Point(135, 55);
            this.lblCambio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(120, 20);
            this.lblCambio.TabIndex = 14;
            this.lblCambio.Text = "0.00";
            this.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoCambio
            // 
            this.lblTextoCambio.AutoSize = true;
            this.lblTextoCambio.Location = new System.Drawing.Point(17, 58);
            this.lblTextoCambio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoCambio.Name = "lblTextoCambio";
            this.lblTextoCambio.Size = new System.Drawing.Size(42, 13);
            this.lblTextoCambio.TabIndex = 13;
            this.lblTextoCambio.Text = "Cambio";
            // 
            // txtMontoRecibido
            // 
            this.txtMontoRecibido.Location = new System.Drawing.Point(135, 28);
            this.txtMontoRecibido.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoRecibido.Name = "txtMontoRecibido";
            this.txtMontoRecibido.Size = new System.Drawing.Size(121, 20);
            this.txtMontoRecibido.TabIndex = 12;
            // 
            // lblTextoMontoRecibido
            // 
            this.lblTextoMontoRecibido.AutoSize = true;
            this.lblTextoMontoRecibido.Location = new System.Drawing.Point(17, 31);
            this.lblTextoMontoRecibido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoMontoRecibido.Name = "lblTextoMontoRecibido";
            this.lblTextoMontoRecibido.Size = new System.Drawing.Size(77, 13);
            this.lblTextoMontoRecibido.TabIndex = 11;
            this.lblTextoMontoRecibido.Text = "Monto recibido";
            // 
            // rbProforma
            // 
            this.rbProforma.AutoSize = true;
            this.rbProforma.Location = new System.Drawing.Point(516, 58);
            this.rbProforma.Margin = new System.Windows.Forms.Padding(2);
            this.rbProforma.Name = "rbProforma";
            this.rbProforma.Size = new System.Drawing.Size(67, 17);
            this.rbProforma.TabIndex = 10;
            this.rbProforma.Text = "Proforma";
            this.rbProforma.UseVisualStyleBackColor = true;
            // 
            // rbNotaVenta
            // 
            this.rbNotaVenta.AutoSize = true;
            this.rbNotaVenta.Location = new System.Drawing.Point(404, 57);
            this.rbNotaVenta.Margin = new System.Windows.Forms.Padding(2);
            this.rbNotaVenta.Name = "rbNotaVenta";
            this.rbNotaVenta.Size = new System.Drawing.Size(93, 17);
            this.rbNotaVenta.TabIndex = 9;
            this.rbNotaVenta.Text = "Nota de venta";
            this.rbNotaVenta.UseVisualStyleBackColor = true;
            // 
            // rbFactura
            // 
            this.rbFactura.AutoSize = true;
            this.rbFactura.Checked = true;
            this.rbFactura.Location = new System.Drawing.Point(322, 58);
            this.rbFactura.Margin = new System.Windows.Forms.Padding(2);
            this.rbFactura.Name = "rbFactura";
            this.rbFactura.Size = new System.Drawing.Size(61, 17);
            this.rbFactura.TabIndex = 8;
            this.rbFactura.TabStop = true;
            this.rbFactura.Text = "Factura";
            this.rbFactura.UseVisualStyleBackColor = true;
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetodoPago.FormattingEnabled = true;
            this.cbMetodoPago.Location = new System.Drawing.Point(135, 5);
            this.cbMetodoPago.Margin = new System.Windows.Forms.Padding(2);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(166, 21);
            this.cbMetodoPago.TabIndex = 7;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(17, 8);
            this.lblMetodoPago.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(70, 13);
            this.lblMetodoPago.TabIndex = 6;
            this.lblMetodoPago.Text = "Método pago";
            // 
            // lblIva
            // 
            this.lblIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIva.Location = new System.Drawing.Point(698, 28);
            this.lblIva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(90, 20);
            this.lblIva.TabIndex = 5;
            this.lblIva.Text = "0.00";
            this.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoIva
            // 
            this.lblTextoIva.AutoSize = true;
            this.lblTextoIva.Location = new System.Drawing.Point(660, 32);
            this.lblTextoIva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoIva.Name = "lblTextoIva";
            this.lblTextoIva.Size = new System.Drawing.Size(24, 13);
            this.lblTextoIva.TabIndex = 4;
            this.lblTextoIva.Text = "IVA";
            // 
            // lblSubtotalGeneral
            // 
            this.lblSubtotalGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubtotalGeneral.Location = new System.Drawing.Point(698, 5);
            this.lblSubtotalGeneral.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtotalGeneral.Name = "lblSubtotalGeneral";
            this.lblSubtotalGeneral.Size = new System.Drawing.Size(90, 20);
            this.lblSubtotalGeneral.TabIndex = 3;
            this.lblSubtotalGeneral.Text = "0.00";
            this.lblSubtotalGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoSubtotal
            // 
            this.lblTextoSubtotal.AutoSize = true;
            this.lblTextoSubtotal.Location = new System.Drawing.Point(645, 8);
            this.lblTextoSubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoSubtotal.Name = "lblTextoSubtotal";
            this.lblTextoSubtotal.Size = new System.Drawing.Size(46, 13);
            this.lblTextoSubtotal.TabIndex = 2;
            this.lblTextoSubtotal.Text = "Subtotal";
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalGeneral.Location = new System.Drawing.Point(832, 16);
            this.lblTotalGeneral.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(136, 29);
            this.lblTotalGeneral.TabIndex = 1;
            this.lblTotalGeneral.Text = "0.00";
            this.lblTotalGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoTotal
            // 
            this.lblTextoTotal.AutoSize = true;
            this.lblTextoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTextoTotal.Location = new System.Drawing.Point(788, 20);
            this.lblTextoTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoTotal.Name = "lblTextoTotal";
            this.lblTextoTotal.Size = new System.Drawing.Size(49, 20);
            this.lblTextoTotal.TabIndex = 0;
            this.lblTextoTotal.Text = "Total";
            // 
            // FrmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 553);
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
        private System.Windows.Forms.Button btnGuardarVenta;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.Panel panelBottom;
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