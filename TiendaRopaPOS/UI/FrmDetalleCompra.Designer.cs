namespace TiendaRopaPOS.UI
{
    partial class FrmDetalleCompra
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
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblNumeroDocumento = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblTotalTexto = new System.Windows.Forms.Label();
            this.lblIvaValor = new System.Windows.Forms.Label();
            this.lblIvaTexto = new System.Windows.Forms.Label();
            this.lblDescuentoValor = new System.Windows.Forms.Label();
            this.lblDescuentoTexto = new System.Windows.Forms.Label();
            this.lblSubtotalValor = new System.Windows.Forms.Label();
            this.lblSubtotalTexto = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.panelTop.Controls.Add(this.btnImprimir);
            this.panelTop.Controls.Add(this.lblProveedor);
            this.panelTop.Controls.Add(this.lblNumeroDocumento);
            this.panelTop.Controls.Add(this.lblFecha);
            this.panelTop.Controls.Add(this.lblSubtitulo);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(18, 14, 18, 10);
            this.panelTop.Size = new System.Drawing.Size(980, 120);
            this.panelTop.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(9, 132, 227);
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(840, 18);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(110, 34);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "🖨 Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProveedor.ForeColor = System.Drawing.Color.White;
            this.lblProveedor.Location = new System.Drawing.Point(20, 93);
            this.lblProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(80, 17);
            this.lblProveedor.TabIndex = 4;
            this.lblProveedor.Text = "Proveedor: -";
            // 
            // lblNumeroDocumento
            // 
            this.lblNumeroDocumento.AutoSize = true;
            this.lblNumeroDocumento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNumeroDocumento.ForeColor = System.Drawing.Color.White;
            this.lblNumeroDocumento.Location = new System.Drawing.Point(20, 71);
            this.lblNumeroDocumento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumeroDocumento.Name = "lblNumeroDocumento";
            this.lblNumeroDocumento.Size = new System.Drawing.Size(134, 17);
            this.lblNumeroDocumento.TabIndex = 3;
            this.lblNumeroDocumento.Text = "Documento compra: -";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(350, 71);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(50, 17);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha: -";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 45);
            this.lblSubtitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(205, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Consulta de productos de la compra";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(18, 14);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(153, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Detalle compra";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 120);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.RowHeadersWidth = 51;
            this.dgvDetalle.RowTemplate.Height = 24;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(980, 370);
            this.dgvDetalle.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.panelBottom.Controls.Add(this.lblTotalValor);
            this.panelBottom.Controls.Add(this.lblTotalTexto);
            this.panelBottom.Controls.Add(this.lblIvaValor);
            this.panelBottom.Controls.Add(this.lblIvaTexto);
            this.panelBottom.Controls.Add(this.lblDescuentoValor);
            this.panelBottom.Controls.Add(this.lblDescuentoTexto);
            this.panelBottom.Controls.Add(this.lblSubtotalValor);
            this.panelBottom.Controls.Add(this.lblSubtotalTexto);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 490);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(980, 80);
            this.panelBottom.TabIndex = 2;
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.BackColor = System.Drawing.Color.White;
            this.lblTotalValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.Location = new System.Drawing.Point(815, 21);
            this.lblTotalValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(130, 32);
            this.lblTotalValor.TabIndex = 7;
            this.lblTotalValor.Text = "0.00";
            this.lblTotalValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalTexto
            // 
            this.lblTotalTexto.AutoSize = true;
            this.lblTotalTexto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalTexto.ForeColor = System.Drawing.Color.White;
            this.lblTotalTexto.Location = new System.Drawing.Point(760, 27);
            this.lblTotalTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalTexto.Name = "lblTotalTexto";
            this.lblTotalTexto.Size = new System.Drawing.Size(48, 21);
            this.lblTotalTexto.TabIndex = 6;
            this.lblTotalTexto.Text = "Total";
            // 
            // lblIvaValor
            // 
            this.lblIvaValor.BackColor = System.Drawing.Color.White;
            this.lblIvaValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIvaValor.Location = new System.Drawing.Point(580, 26);
            this.lblIvaValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIvaValor.Name = "lblIvaValor";
            this.lblIvaValor.Size = new System.Drawing.Size(100, 24);
            this.lblIvaValor.TabIndex = 5;
            this.lblIvaValor.Text = "0.00";
            this.lblIvaValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIvaTexto
            // 
            this.lblIvaTexto.AutoSize = true;
            this.lblIvaTexto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIvaTexto.ForeColor = System.Drawing.Color.White;
            this.lblIvaTexto.Location = new System.Drawing.Point(545, 28);
            this.lblIvaTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIvaTexto.Name = "lblIvaTexto";
            this.lblIvaTexto.Size = new System.Drawing.Size(30, 19);
            this.lblIvaTexto.TabIndex = 4;
            this.lblIvaTexto.Text = "IVA";
            // 
            // lblDescuentoValor
            // 
            this.lblDescuentoValor.BackColor = System.Drawing.Color.White;
            this.lblDescuentoValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescuentoValor.Location = new System.Drawing.Point(340, 26);
            this.lblDescuentoValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescuentoValor.Name = "lblDescuentoValor";
            this.lblDescuentoValor.Size = new System.Drawing.Size(100, 24);
            this.lblDescuentoValor.TabIndex = 3;
            this.lblDescuentoValor.Text = "0.00";
            this.lblDescuentoValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescuentoTexto
            // 
            this.lblDescuentoTexto.AutoSize = true;
            this.lblDescuentoTexto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescuentoTexto.ForeColor = System.Drawing.Color.White;
            this.lblDescuentoTexto.Location = new System.Drawing.Point(255, 28);
            this.lblDescuentoTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescuentoTexto.Name = "lblDescuentoTexto";
            this.lblDescuentoTexto.Size = new System.Drawing.Size(81, 19);
            this.lblDescuentoTexto.TabIndex = 2;
            this.lblDescuentoTexto.Text = "Descuento";
            // 
            // lblSubtotalValor
            // 
            this.lblSubtotalValor.BackColor = System.Drawing.Color.White;
            this.lblSubtotalValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubtotalValor.Location = new System.Drawing.Point(105, 26);
            this.lblSubtotalValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtotalValor.Name = "lblSubtotalValor";
            this.lblSubtotalValor.Size = new System.Drawing.Size(100, 24);
            this.lblSubtotalValor.TabIndex = 1;
            this.lblSubtotalValor.Text = "0.00";
            this.lblSubtotalValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotalTexto
            // 
            this.lblSubtotalTexto.AutoSize = true;
            this.lblSubtotalTexto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalTexto.ForeColor = System.Drawing.Color.White;
            this.lblSubtotalTexto.Location = new System.Drawing.Point(35, 28);
            this.lblSubtotalTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtotalTexto.Name = "lblSubtotalTexto";
            this.lblSubtotalTexto.Size = new System.Drawing.Size(66, 19);
            this.lblSubtotalTexto.TabIndex = 0;
            this.lblSubtotalTexto.Text = "Subtotal";
            // 
            // FrmDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.ClientSize = new System.Drawing.Size(980, 570);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDetalleCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Compra";
            this.Load += new System.EventHandler(this.FrmDetalleCompra_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblNumeroDocumento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Label lblTotalTexto;
        private System.Windows.Forms.Label lblIvaValor;
        private System.Windows.Forms.Label lblIvaTexto;
        private System.Windows.Forms.Label lblDescuentoValor;
        private System.Windows.Forms.Label lblDescuentoTexto;
        private System.Windows.Forms.Label lblSubtotalValor;
        private System.Windows.Forms.Label lblSubtotalTexto;
    }
}