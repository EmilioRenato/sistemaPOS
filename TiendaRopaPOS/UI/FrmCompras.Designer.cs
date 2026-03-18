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
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
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
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(15, 12, 15, 8);
            this.panelTop.Size = new System.Drawing.Size(1100, 90);
            this.panelTop.TabIndex = 0;
            // 
            // chkPagada
            // 
            this.chkPagada.AutoSize = true;
            this.chkPagada.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkPagada.ForeColor = System.Drawing.Color.White;
            this.chkPagada.Location = new System.Drawing.Point(895, 23);
            this.chkPagada.Margin = new System.Windows.Forms.Padding(2);
            this.chkPagada.Name = "chkPagada";
            this.chkPagada.Size = new System.Drawing.Size(76, 23);
            this.chkPagada.TabIndex = 8;
            this.chkPagada.Text = "Pagada";
            this.chkPagada.UseVisualStyleBackColor = true;
            // 
            // txtDiasCredito
            // 
            this.txtDiasCredito.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiasCredito.Location = new System.Drawing.Point(720, 21);
            this.txtDiasCredito.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiasCredito.Name = "txtDiasCredito";
            this.txtDiasCredito.ReadOnly = true;
            this.txtDiasCredito.Size = new System.Drawing.Size(105, 25);
            this.txtDiasCredito.TabIndex = 7;
            // 
            // lblDiasCredito
            // 
            this.lblDiasCredito.AutoSize = true;
            this.lblDiasCredito.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiasCredito.ForeColor = System.Drawing.Color.White;
            this.lblDiasCredito.Location = new System.Drawing.Point(622, 24);
            this.lblDiasCredito.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiasCredito.Name = "lblDiasCredito";
            this.lblDiasCredito.Size = new System.Drawing.Size(89, 19);
            this.lblDiasCredito.TabIndex = 6;
            this.lblDiasCredito.Text = "Días crédito";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNumeroDocumento.Location = new System.Drawing.Point(440, 21);
            this.txtNumeroDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(160, 25);
            this.txtNumeroDocumento.TabIndex = 5;
            // 
            // lblNumeroDocumento
            // 
            this.lblNumeroDocumento.AutoSize = true;
            this.lblNumeroDocumento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNumeroDocumento.ForeColor = System.Drawing.Color.White;
            this.lblNumeroDocumento.Location = new System.Drawing.Point(300, 24);
            this.lblNumeroDocumento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumeroDocumento.Name = "lblNumeroDocumento";
            this.lblNumeroDocumento.Size = new System.Drawing.Size(138, 19);
            this.lblNumeroDocumento.TabIndex = 4;
            this.lblNumeroDocumento.Text = "Número documento";
            // 
            // cbBodegaCompra
            // 
            this.cbBodegaCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBodegaCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBodegaCompra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbBodegaCompra.FormattingEnabled = true;
            this.cbBodegaCompra.Location = new System.Drawing.Point(440, 55);
            this.cbBodegaCompra.Margin = new System.Windows.Forms.Padding(2);
            this.cbBodegaCompra.Name = "cbBodegaCompra";
            this.cbBodegaCompra.Size = new System.Drawing.Size(200, 25);
            this.cbBodegaCompra.TabIndex = 3;
            // 
            // lblBodegaCompra
            // 
            this.lblBodegaCompra.AutoSize = true;
            this.lblBodegaCompra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBodegaCompra.ForeColor = System.Drawing.Color.White;
            this.lblBodegaCompra.Location = new System.Drawing.Point(300, 58);
            this.lblBodegaCompra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBodegaCompra.Name = "lblBodegaCompra";
            this.lblBodegaCompra.Size = new System.Drawing.Size(97, 19);
            this.lblBodegaCompra.TabIndex = 2;
            this.lblBodegaCompra.Text = "Stock general";
            // 
            // cbProveedor
            // 
            this.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbProveedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(90, 21);
            this.cbProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(190, 25);
            this.cbProveedor.TabIndex = 1;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProveedor.ForeColor = System.Drawing.Color.White;
            this.lblProveedor.Location = new System.Drawing.Point(17, 24);
            this.lblProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(73, 19);
            this.lblProveedor.TabIndex = 0;
            this.lblProveedor.Text = "Proveedor";
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(223, 230, 233);
            this.panelBotones.Controls.Add(this.btnQuitarFila);
            this.panelBotones.Controls.Add(this.btnLimpiarCompra);
            this.panelBotones.Controls.Add(this.btnGuardarCompra);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBotones.Location = new System.Drawing.Point(0, 90);
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
            this.btnQuitarFila.Location = new System.Drawing.Point(270, 10);
            this.btnQuitarFila.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(105, 32);
            this.btnQuitarFila.TabIndex = 2;
            this.btnQuitarFila.Text = "🗑 Quitar";
            this.btnQuitarFila.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarCompra
            // 
            this.btnLimpiarCompra.BackColor = System.Drawing.Color.FromArgb(253, 203, 110);
            this.btnLimpiarCompra.FlatAppearance.BorderSize = 0;
            this.btnLimpiarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarCompra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarCompra.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiarCompra.Location = new System.Drawing.Point(150, 10);
            this.btnLimpiarCompra.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiarCompra.Name = "btnLimpiarCompra";
            this.btnLimpiarCompra.Size = new System.Drawing.Size(100, 32);
            this.btnLimpiarCompra.TabIndex = 1;
            this.btnLimpiarCompra.Text = "🧹 Limpiar";
            this.btnLimpiarCompra.UseVisualStyleBackColor = false;
            // 
            // btnGuardarCompra
            // 
            this.btnGuardarCompra.BackColor = System.Drawing.Color.FromArgb(0, 184, 148);
            this.btnGuardarCompra.FlatAppearance.BorderSize = 0;
            this.btnGuardarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCompra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarCompra.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCompra.Location = new System.Drawing.Point(30, 10);
            this.btnGuardarCompra.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarCompra.Name = "btnGuardarCompra";
            this.btnGuardarCompra.Size = new System.Drawing.Size(100, 32);
            this.btnGuardarCompra.TabIndex = 0;
            this.btnGuardarCompra.Text = "💾 Guardar";
            this.btnGuardarCompra.UseVisualStyleBackColor = false;
            // 
            // dgvDetalleCompra
            // 
            this.dgvDetalleCompra.AllowUserToAddRows = false;
            this.dgvDetalleCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleCompra.BackgroundColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.dgvDetalleCompra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalleCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleCompra.Location = new System.Drawing.Point(0, 145);
            this.dgvDetalleCompra.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetalleCompra.MultiSelect = false;
            this.dgvDetalleCompra.Name = "dgvDetalleCompra";
            this.dgvDetalleCompra.RowHeadersVisible = false;
            this.dgvDetalleCompra.RowHeadersWidth = 51;
            this.dgvDetalleCompra.RowTemplate.Height = 24;
            this.dgvDetalleCompra.Size = new System.Drawing.Size(1100, 415);
            this.dgvDetalleCompra.TabIndex = 2;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.panelBottom.Controls.Add(this.lblTotalCompra);
            this.panelBottom.Controls.Add(this.lblTextoTotal);
            this.panelBottom.Controls.Add(this.lblIvaCompra);
            this.panelBottom.Controls.Add(this.lblTextoIva);
            this.panelBottom.Controls.Add(this.lblDescuentoCompra);
            this.panelBottom.Controls.Add(this.lblTextoDescuento);
            this.panelBottom.Controls.Add(this.lblSubtotalCompra);
            this.panelBottom.Controls.Add(this.lblTextoSubtotal);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 560);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelBottom.Size = new System.Drawing.Size(1100, 90);
            this.panelBottom.TabIndex = 3;
            // 
            // lblTotalCompra
            // 
            this.lblTotalCompra.BackColor = System.Drawing.Color.White;
            this.lblTotalCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCompra.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalCompra.Location = new System.Drawing.Point(930, 24);
            this.lblTotalCompra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalCompra.Name = "lblTotalCompra";
            this.lblTotalCompra.Size = new System.Drawing.Size(136, 32);
            this.lblTotalCompra.TabIndex = 7;
            this.lblTotalCompra.Text = "0.00";
            this.lblTotalCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoTotal
            // 
            this.lblTextoTotal.AutoSize = true;
            this.lblTextoTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTextoTotal.ForeColor = System.Drawing.Color.White;
            this.lblTextoTotal.Location = new System.Drawing.Point(875, 29);
            this.lblTextoTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoTotal.Name = "lblTextoTotal";
            this.lblTextoTotal.Size = new System.Drawing.Size(48, 21);
            this.lblTextoTotal.TabIndex = 6;
            this.lblTextoTotal.Text = "Total";
            // 
            // lblIvaCompra
            // 
            this.lblIvaCompra.BackColor = System.Drawing.Color.White;
            this.lblIvaCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIvaCompra.Location = new System.Drawing.Point(710, 29);
            this.lblIvaCompra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIvaCompra.Name = "lblIvaCompra";
            this.lblIvaCompra.Size = new System.Drawing.Size(100, 24);
            this.lblIvaCompra.TabIndex = 5;
            this.lblIvaCompra.Text = "0.00";
            this.lblIvaCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoIva
            // 
            this.lblTextoIva.AutoSize = true;
            this.lblTextoIva.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTextoIva.ForeColor = System.Drawing.Color.White;
            this.lblTextoIva.Location = new System.Drawing.Point(675, 31);
            this.lblTextoIva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoIva.Name = "lblTextoIva";
            this.lblTextoIva.Size = new System.Drawing.Size(30, 19);
            this.lblTextoIva.TabIndex = 4;
            this.lblTextoIva.Text = "IVA";
            // 
            // lblDescuentoCompra
            // 
            this.lblDescuentoCompra.BackColor = System.Drawing.Color.White;
            this.lblDescuentoCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescuentoCompra.Location = new System.Drawing.Point(490, 29);
            this.lblDescuentoCompra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescuentoCompra.Name = "lblDescuentoCompra";
            this.lblDescuentoCompra.Size = new System.Drawing.Size(100, 24);
            this.lblDescuentoCompra.TabIndex = 3;
            this.lblDescuentoCompra.Text = "0.00";
            this.lblDescuentoCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoDescuento
            // 
            this.lblTextoDescuento.AutoSize = true;
            this.lblTextoDescuento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTextoDescuento.ForeColor = System.Drawing.Color.White;
            this.lblTextoDescuento.Location = new System.Drawing.Point(405, 31);
            this.lblTextoDescuento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoDescuento.Name = "lblTextoDescuento";
            this.lblTextoDescuento.Size = new System.Drawing.Size(81, 19);
            this.lblTextoDescuento.TabIndex = 2;
            this.lblTextoDescuento.Text = "Descuento";
            // 
            // lblSubtotalCompra
            // 
            this.lblSubtotalCompra.BackColor = System.Drawing.Color.White;
            this.lblSubtotalCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubtotalCompra.Location = new System.Drawing.Point(250, 29);
            this.lblSubtotalCompra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtotalCompra.Name = "lblSubtotalCompra";
            this.lblSubtotalCompra.Size = new System.Drawing.Size(100, 24);
            this.lblSubtotalCompra.TabIndex = 1;
            this.lblSubtotalCompra.Text = "0.00";
            this.lblSubtotalCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoSubtotal
            // 
            this.lblTextoSubtotal.AutoSize = true;
            this.lblTextoSubtotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTextoSubtotal.ForeColor = System.Drawing.Color.White;
            this.lblTextoSubtotal.Location = new System.Drawing.Point(180, 31);
            this.lblTextoSubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextoSubtotal.Name = "lblTextoSubtotal";
            this.lblTextoSubtotal.Size = new System.Drawing.Size(66, 19);
            this.lblTextoSubtotal.TabIndex = 0;
            this.lblTextoSubtotal.Text = "Subtotal";
            // 
            // FrmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.dgvDetalleCompra);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmCompras";
            this.Text = "Compras";
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