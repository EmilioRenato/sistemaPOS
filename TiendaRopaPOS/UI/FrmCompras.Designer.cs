namespace TiendaRopaPOS.UI
{
    partial class FrmCompras
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.chkPagada = new System.Windows.Forms.CheckBox();
            this.txtDiasCredito = new System.Windows.Forms.TextBox();
            this.lblDiasCredito = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.lblNumeroDocumento = new System.Windows.Forms.Label();
            this.cbBodegaCompra = new System.Windows.Forms.ComboBox();
            this.lblBodegaCompra = new System.Windows.Forms.Label();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnQuitarFila = new System.Windows.Forms.Button();
            this.btnLimpiarCompra = new System.Windows.Forms.Button();
            this.btnGuardarCompra = new System.Windows.Forms.Button();
            this.dgvDetalleCompra = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTotalCompra = new System.Windows.Forms.Label();
            this.lblTextoTotal = new System.Windows.Forms.Label();
            this.lblIvaCompra = new System.Windows.Forms.Label();
            this.lblTextoIva = new System.Windows.Forms.Label();
            this.lblDescuentoCompra = new System.Windows.Forms.Label();
            this.lblTextoDescuento = new System.Windows.Forms.Label();
            this.lblSubtotalCompra = new System.Windows.Forms.Label();
            this.lblTextoSubtotal = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCompra)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.chkPagada);
            this.panelTop.Controls.Add(this.txtDiasCredito);
            this.panelTop.Controls.Add(this.lblDiasCredito);
            this.panelTop.Controls.Add(this.txtNumeroDocumento);
            this.panelTop.Controls.Add(this.lblNumeroDocumento);
            this.panelTop.Controls.Add(this.cbBodegaCompra);
            this.panelTop.Controls.Add(this.lblBodegaCompra);
            this.panelTop.Controls.Add(this.cbProveedor);
            this.panelTop.Controls.Add(this.lblProveedor);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(15, 12, 15, 8);
            this.panelTop.Size = new System.Drawing.Size(1008, 81);
            this.panelTop.TabIndex = 0;
            // 
            // chkPagada
            // 
            this.chkPagada.AutoSize = true;
            this.chkPagada.Location = new System.Drawing.Point(840, 21);
            this.chkPagada.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkPagada.Name = "chkPagada";
            this.chkPagada.Size = new System.Drawing.Size(63, 17);
            this.chkPagada.TabIndex = 8;
            this.chkPagada.Text = "Pagada";
            this.chkPagada.UseVisualStyleBackColor = true;
            // 
            // txtDiasCredito
            // 
            this.txtDiasCredito.Location = new System.Drawing.Point(675, 20);
            this.txtDiasCredito.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDiasCredito.Name = "txtDiasCredito";
            this.txtDiasCredito.ReadOnly = true;
            this.txtDiasCredito.Size = new System.Drawing.Size(91, 20);
            this.txtDiasCredito.TabIndex = 7;
            // 
            // lblDiasCredito
            // 
            this.lblDiasCredito.AutoSize = true;
            this.lblDiasCredito.Location = new System.Drawing.Point(608, 22);
            this.lblDiasCredito.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiasCredito.Name = "lblDiasCredito";
            this.lblDiasCredito.Size = new System.Drawing.Size(65, 13);
            this.lblDiasCredito.TabIndex = 6;
            this.lblDiasCredito.Text = "Días crédito";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(435, 20);
            this.txtNumeroDocumento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(136, 20);
            this.txtNumeroDocumento.TabIndex = 5;
            // 
            // lblNumeroDocumento
            // 
            this.lblNumeroDocumento.AutoSize = true;
            this.lblNumeroDocumento.Location = new System.Drawing.Point(334, 22);
            this.lblNumeroDocumento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumeroDocumento.Name = "lblNumeroDocumento";
            this.lblNumeroDocumento.Size = new System.Drawing.Size(100, 13);
            this.lblNumeroDocumento.TabIndex = 4;
            this.lblNumeroDocumento.Text = "Número documento";
            // 
            // cbBodegaCompra
            // 
            this.cbBodegaCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBodegaCompra.FormattingEnabled = true;
            this.cbBodegaCompra.Location = new System.Drawing.Point(435, 49);
            this.cbBodegaCompra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbBodegaCompra.Name = "cbBodegaCompra";
            this.cbBodegaCompra.Size = new System.Drawing.Size(166, 21);
            this.cbBodegaCompra.TabIndex = 3;
            // 
            // lblBodegaCompra
            // 
            this.lblBodegaCompra.AutoSize = true;
            this.lblBodegaCompra.Location = new System.Drawing.Point(334, 51);
            this.lblBodegaCompra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBodegaCompra.Name = "lblBodegaCompra";
            this.lblBodegaCompra.Size = new System.Drawing.Size(44, 13);
            this.lblBodegaCompra.TabIndex = 2;
            this.lblBodegaCompra.Text = "Bodega";
            // 
            // cbProveedor
            // 
            this.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(90, 20);
            this.cbProveedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(211, 21);
            this.cbProveedor.TabIndex = 1;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(17, 22);
            this.lblProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(56, 13);
            this.lblProveedor.TabIndex = 0;
            this.lblProveedor.Text = "Proveedor";
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnQuitarFila);
            this.panelBotones.Controls.Add(this.btnLimpiarCompra);
            this.panelBotones.Controls.Add(this.btnGuardarCompra);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBotones.Location = new System.Drawing.Point(0, 81);
            this.panelBotones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelBotones.Size = new System.Drawing.Size(1008, 49);
            this.panelBotones.TabIndex = 1;
            // 
            // btnQuitarFila
            // 
            this.btnQuitarFila.Location = new System.Drawing.Point(270, 10);
            this.btnQuitarFila.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(82, 26);
            this.btnQuitarFila.TabIndex = 2;
            this.btnQuitarFila.Text = "Quitar fila";
            this.btnQuitarFila.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarCompra
            // 
            this.btnLimpiarCompra.Location = new System.Drawing.Point(165, 10);
            this.btnLimpiarCompra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiarCompra.Name = "btnLimpiarCompra";
            this.btnLimpiarCompra.Size = new System.Drawing.Size(82, 26);
            this.btnLimpiarCompra.TabIndex = 1;
            this.btnLimpiarCompra.Text = "Limpiar";
            this.btnLimpiarCompra.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCompra
            // 
            this.btnGuardarCompra.Location = new System.Drawing.Point(60, 10);
            this.btnGuardarCompra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardarCompra.Name = "btnGuardarCompra";
            this.btnGuardarCompra.Size = new System.Drawing.Size(82, 26);
            this.btnGuardarCompra.TabIndex = 0;
            this.btnGuardarCompra.Text = "Guardar";
            this.btnGuardarCompra.UseVisualStyleBackColor = true;
            // 
            // dgvDetalleCompra
            // 
            this.dgvDetalleCompra.AllowUserToAddRows = false;
            this.dgvDetalleCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleCompra.Location = new System.Drawing.Point(0, 130);
            this.dgvDetalleCompra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDetalleCompra.MultiSelect = false;
            this.dgvDetalleCompra.Name = "dgvDetalleCompra";
            this.dgvDetalleCompra.RowHeadersWidth = 51;
            this.dgvDetalleCompra.RowTemplate.Height = 24;
            this.dgvDetalleCompra.Size = new System.Drawing.Size(1008, 342);
            this.dgvDetalleCompra.TabIndex = 2;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblTotalCompra);
            this.panelBottom.Controls.Add(this.lblTextoTotal);
            this.panelBottom.Controls.Add(this.lblIvaCompra);
            this.panelBottom.Controls.Add(this.lblTextoIva);
            this.panelBottom.Controls.Add(this.lblDescuentoCompra);
            this.panelBottom.Controls.Add(this.lblTextoDescuento);
            this.panelBottom.Controls.Add(this.lblSubtotalCompra);
            this.panelBottom.Controls.Add(this.lblTextoSubtotal);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 472);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelBottom.Size = new System.Drawing.Size(1008, 81);
            this.panelBottom.TabIndex = 3;
            // 
            // lblTotalCompra
            // 
            this.lblTotalCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalCompra.Location = new System.Drawing.Point(840, 21);
            this.lblTotalCompra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalCompra.Name = "lblTotalCompra";
            this.lblTotalCompra.Size = new System.Drawing.Size(136, 29);
            this.lblTotalCompra.TabIndex = 7;
            this.lblTotalCompra.Text = "0.00";
            this.lblTotalCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoTotal
            // 
            this.lblTextoTotal.AutoSize = true;
            this.lblTextoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTextoTotal.Location = new System.Drawing.Point(788, 25);
            this.lblTextoTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoTotal.Name = "lblTextoTotal";
            this.lblTextoTotal.Size = new System.Drawing.Size(49, 20);
            this.lblTextoTotal.TabIndex = 6;
            this.lblTextoTotal.Text = "Total";
            // 
            // lblIvaCompra
            // 
            this.lblIvaCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIvaCompra.Location = new System.Drawing.Point(645, 26);
            this.lblIvaCompra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIvaCompra.Name = "lblIvaCompra";
            this.lblIvaCompra.Size = new System.Drawing.Size(90, 20);
            this.lblIvaCompra.TabIndex = 5;
            this.lblIvaCompra.Text = "0.00";
            this.lblIvaCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoIva
            // 
            this.lblTextoIva.AutoSize = true;
            this.lblTextoIva.Location = new System.Drawing.Point(615, 29);
            this.lblTextoIva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoIva.Name = "lblTextoIva";
            this.lblTextoIva.Size = new System.Drawing.Size(24, 13);
            this.lblTextoIva.TabIndex = 4;
            this.lblTextoIva.Text = "IVA";
            // 
            // lblDescuentoCompra
            // 
            this.lblDescuentoCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescuentoCompra.Location = new System.Drawing.Point(458, 26);
            this.lblDescuentoCompra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescuentoCompra.Name = "lblDescuentoCompra";
            this.lblDescuentoCompra.Size = new System.Drawing.Size(90, 20);
            this.lblDescuentoCompra.TabIndex = 3;
            this.lblDescuentoCompra.Text = "0.00";
            this.lblDescuentoCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoDescuento
            // 
            this.lblTextoDescuento.AutoSize = true;
            this.lblTextoDescuento.Location = new System.Drawing.Point(394, 29);
            this.lblTextoDescuento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoDescuento.Name = "lblTextoDescuento";
            this.lblTextoDescuento.Size = new System.Drawing.Size(59, 13);
            this.lblTextoDescuento.TabIndex = 2;
            this.lblTextoDescuento.Text = "Descuento";
            // 
            // lblSubtotalCompra
            // 
            this.lblSubtotalCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubtotalCompra.Location = new System.Drawing.Point(270, 26);
            this.lblSubtotalCompra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtotalCompra.Name = "lblSubtotalCompra";
            this.lblSubtotalCompra.Size = new System.Drawing.Size(90, 20);
            this.lblSubtotalCompra.TabIndex = 1;
            this.lblSubtotalCompra.Text = "0.00";
            this.lblSubtotalCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoSubtotal
            // 
            this.lblTextoSubtotal.AutoSize = true;
            this.lblTextoSubtotal.Location = new System.Drawing.Point(218, 29);
            this.lblTextoSubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoSubtotal.Name = "lblTextoSubtotal";
            this.lblTextoSubtotal.Size = new System.Drawing.Size(46, 13);
            this.lblTextoSubtotal.TabIndex = 0;
            this.lblTextoSubtotal.Text = "Subtotal";
            // 
            // FrmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 553);
            this.Controls.Add(this.dgvDetalleCompra);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmCompras";
            this.Text = "Compras";
            this.Load += new System.EventHandler(this.FrmCompras_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCompra)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.CheckBox chkPagada;
        private System.Windows.Forms.TextBox txtDiasCredito;
        private System.Windows.Forms.Label lblDiasCredito;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label lblNumeroDocumento;
        private System.Windows.Forms.ComboBox cbBodegaCompra;
        private System.Windows.Forms.Label lblBodegaCompra;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnQuitarFila;
        private System.Windows.Forms.Button btnLimpiarCompra;
        private System.Windows.Forms.Button btnGuardarCompra;
        private System.Windows.Forms.DataGridView dgvDetalleCompra;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblTotalCompra;
        private System.Windows.Forms.Label lblTextoTotal;
        private System.Windows.Forms.Label lblIvaCompra;
        private System.Windows.Forms.Label lblTextoIva;
        private System.Windows.Forms.Label lblDescuentoCompra;
        private System.Windows.Forms.Label lblTextoDescuento;
        private System.Windows.Forms.Label lblSubtotalCompra;
        private System.Windows.Forms.Label lblTextoSubtotal;
    }
}