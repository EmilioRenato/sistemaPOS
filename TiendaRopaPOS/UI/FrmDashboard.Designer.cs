namespace TiendaRopaPOS.UI
{
    partial class FrmDashboard
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelResumen = new System.Windows.Forms.Panel();
            this.panelCaja7 = new System.Windows.Forms.Panel();
            this.lblCajaActivaValor = new System.Windows.Forms.Label();
            this.lblCajaActivaTitulo = new System.Windows.Forms.Label();
            this.panelCaja6 = new System.Windows.Forms.Panel();
            this.lblProductosValor = new System.Windows.Forms.Label();
            this.lblProductosTitulo = new System.Windows.Forms.Label();
            this.panelCaja5 = new System.Windows.Forms.Panel();
            this.lblStockBajoValor = new System.Windows.Forms.Label();
            this.lblStockBajoTitulo = new System.Windows.Forms.Label();
            this.panelCaja4 = new System.Windows.Forms.Panel();
            this.lblPorPagarValor = new System.Windows.Forms.Label();
            this.lblPorPagarTitulo = new System.Windows.Forms.Label();
            this.panelCaja3 = new System.Windows.Forms.Panel();
            this.lblComprasMesValor = new System.Windows.Forms.Label();
            this.lblComprasMesTitulo = new System.Windows.Forms.Label();
            this.panelCaja2 = new System.Windows.Forms.Panel();
            this.lblTotalHoyValor = new System.Windows.Forms.Label();
            this.lblTotalHoyTitulo = new System.Windows.Forms.Label();
            this.panelCaja1 = new System.Windows.Forms.Panel();
            this.lblVentasHoyValor = new System.Windows.Forms.Label();
            this.lblVentasHoyTitulo = new System.Windows.Forms.Label();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dgvTopProductos = new System.Windows.Forms.DataGridView();
            this.lblTopProductos = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelResumen.SuspendLayout();
            this.panelCaja7.SuspendLayout();
            this.panelCaja6.SuspendLayout();
            this.panelCaja5.SuspendLayout();
            this.panelCaja4.SuspendLayout();
            this.panelCaja3.SuspendLayout();
            this.panelCaja2.SuspendLayout();
            this.panelCaja1.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(15, 12, 15, 8);
            this.panelTop.Size = new System.Drawing.Size(1100, 65);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(17, 17);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(128, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Dashboard";
            // 
            // panelResumen
            // 
            this.panelResumen.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.panelResumen.Controls.Add(this.panelCaja7);
            this.panelResumen.Controls.Add(this.panelCaja6);
            this.panelResumen.Controls.Add(this.panelCaja5);
            this.panelResumen.Controls.Add(this.panelCaja4);
            this.panelResumen.Controls.Add(this.panelCaja3);
            this.panelResumen.Controls.Add(this.panelCaja2);
            this.panelResumen.Controls.Add(this.panelCaja1);
            this.panelResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResumen.Location = new System.Drawing.Point(0, 65);
            this.panelResumen.Margin = new System.Windows.Forms.Padding(2);
            this.panelResumen.Name = "panelResumen";
            this.panelResumen.Size = new System.Drawing.Size(1100, 220);
            this.panelResumen.TabIndex = 1;
            // 
            // panelCaja7
            // 
            this.panelCaja7.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.panelCaja7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCaja7.Controls.Add(this.lblCajaActivaValor);
            this.panelCaja7.Controls.Add(this.lblCajaActivaTitulo);
            this.panelCaja7.Location = new System.Drawing.Point(15, 120);
            this.panelCaja7.Margin = new System.Windows.Forms.Padding(2);
            this.panelCaja7.Name = "panelCaja7";
            this.panelCaja7.Size = new System.Drawing.Size(520, 82);
            this.panelCaja7.TabIndex = 6;
            // 
            // lblCajaActivaValor
            // 
            this.lblCajaActivaValor.AutoSize = true;
            this.lblCajaActivaValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCajaActivaValor.ForeColor = System.Drawing.Color.White;
            this.lblCajaActivaValor.Location = new System.Drawing.Point(11, 38);
            this.lblCajaActivaValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCajaActivaValor.Name = "lblCajaActivaValor";
            this.lblCajaActivaValor.Size = new System.Drawing.Size(14, 21);
            this.lblCajaActivaValor.TabIndex = 0;
            this.lblCajaActivaValor.Text = "-";
            // 
            // lblCajaActivaTitulo
            // 
            this.lblCajaActivaTitulo.AutoSize = true;
            this.lblCajaActivaTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCajaActivaTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCajaActivaTitulo.Location = new System.Drawing.Point(11, 13);
            this.lblCajaActivaTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCajaActivaTitulo.Name = "lblCajaActivaTitulo";
            this.lblCajaActivaTitulo.Size = new System.Drawing.Size(162, 17);
            this.lblCajaActivaTitulo.TabIndex = 1;
            this.lblCajaActivaTitulo.Text = "Caja activa en esta máquina";
            // 
            // panelCaja6
            // 
            this.panelCaja6.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.panelCaja6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCaja6.Controls.Add(this.lblProductosValor);
            this.panelCaja6.Controls.Add(this.lblProductosTitulo);
            this.panelCaja6.Location = new System.Drawing.Point(825, 18);
            this.panelCaja6.Margin = new System.Windows.Forms.Padding(2);
            this.panelCaja6.Name = "panelCaja6";
            this.panelCaja6.Size = new System.Drawing.Size(150, 82);
            this.panelCaja6.TabIndex = 5;
            // 
            // lblProductosValor
            // 
            this.lblProductosValor.AutoSize = true;
            this.lblProductosValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblProductosValor.ForeColor = System.Drawing.Color.White;
            this.lblProductosValor.Location = new System.Drawing.Point(11, 35);
            this.lblProductosValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProductosValor.Name = "lblProductosValor";
            this.lblProductosValor.Size = new System.Drawing.Size(26, 30);
            this.lblProductosValor.TabIndex = 0;
            this.lblProductosValor.Text = "0";
            // 
            // lblProductosTitulo
            // 
            this.lblProductosTitulo.AutoSize = true;
            this.lblProductosTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProductosTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblProductosTitulo.Location = new System.Drawing.Point(11, 13);
            this.lblProductosTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProductosTitulo.Name = "lblProductosTitulo";
            this.lblProductosTitulo.Size = new System.Drawing.Size(105, 17);
            this.lblProductosTitulo.TabIndex = 1;
            this.lblProductosTitulo.Text = "Productos activos";
            // 
            // panelCaja5
            // 
            this.panelCaja5.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.panelCaja5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCaja5.Controls.Add(this.lblStockBajoValor);
            this.panelCaja5.Controls.Add(this.lblStockBajoTitulo);
            this.panelCaja5.Location = new System.Drawing.Point(665, 18);
            this.panelCaja5.Margin = new System.Windows.Forms.Padding(2);
            this.panelCaja5.Name = "panelCaja5";
            this.panelCaja5.Size = new System.Drawing.Size(150, 82);
            this.panelCaja5.TabIndex = 4;
            // 
            // lblStockBajoValor
            // 
            this.lblStockBajoValor.AutoSize = true;
            this.lblStockBajoValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStockBajoValor.ForeColor = System.Drawing.Color.White;
            this.lblStockBajoValor.Location = new System.Drawing.Point(11, 35);
            this.lblStockBajoValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStockBajoValor.Name = "lblStockBajoValor";
            this.lblStockBajoValor.Size = new System.Drawing.Size(26, 30);
            this.lblStockBajoValor.TabIndex = 0;
            this.lblStockBajoValor.Text = "0";
            // 
            // lblStockBajoTitulo
            // 
            this.lblStockBajoTitulo.AutoSize = true;
            this.lblStockBajoTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStockBajoTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblStockBajoTitulo.Location = new System.Drawing.Point(11, 13);
            this.lblStockBajoTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStockBajoTitulo.Name = "lblStockBajoTitulo";
            this.lblStockBajoTitulo.Size = new System.Drawing.Size(71, 17);
            this.lblStockBajoTitulo.TabIndex = 1;
            this.lblStockBajoTitulo.Text = "Stock bajo";
            // 
            // panelCaja4
            // 
            this.panelCaja4.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.panelCaja4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCaja4.Controls.Add(this.lblPorPagarValor);
            this.panelCaja4.Controls.Add(this.lblPorPagarTitulo);
            this.panelCaja4.Location = new System.Drawing.Point(505, 18);
            this.panelCaja4.Margin = new System.Windows.Forms.Padding(2);
            this.panelCaja4.Name = "panelCaja4";
            this.panelCaja4.Size = new System.Drawing.Size(150, 82);
            this.panelCaja4.TabIndex = 3;
            // 
            // lblPorPagarValor
            // 
            this.lblPorPagarValor.AutoSize = true;
            this.lblPorPagarValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPorPagarValor.ForeColor = System.Drawing.Color.White;
            this.lblPorPagarValor.Location = new System.Drawing.Point(11, 35);
            this.lblPorPagarValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPorPagarValor.Name = "lblPorPagarValor";
            this.lblPorPagarValor.Size = new System.Drawing.Size(57, 30);
            this.lblPorPagarValor.TabIndex = 0;
            this.lblPorPagarValor.Text = "0.00";
            // 
            // lblPorPagarTitulo
            // 
            this.lblPorPagarTitulo.AutoSize = true;
            this.lblPorPagarTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPorPagarTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPorPagarTitulo.Location = new System.Drawing.Point(11, 13);
            this.lblPorPagarTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPorPagarTitulo.Name = "lblPorPagarTitulo";
            this.lblPorPagarTitulo.Size = new System.Drawing.Size(110, 17);
            this.lblPorPagarTitulo.TabIndex = 1;
            this.lblPorPagarTitulo.Text = "Cuentas por pagar";
            // 
            // panelCaja3
            // 
            this.panelCaja3.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.panelCaja3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCaja3.Controls.Add(this.lblComprasMesValor);
            this.panelCaja3.Controls.Add(this.lblComprasMesTitulo);
            this.panelCaja3.Location = new System.Drawing.Point(345, 18);
            this.panelCaja3.Margin = new System.Windows.Forms.Padding(2);
            this.panelCaja3.Name = "panelCaja3";
            this.panelCaja3.Size = new System.Drawing.Size(150, 82);
            this.panelCaja3.TabIndex = 2;
            // 
            // lblComprasMesValor
            // 
            this.lblComprasMesValor.AutoSize = true;
            this.lblComprasMesValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblComprasMesValor.ForeColor = System.Drawing.Color.White;
            this.lblComprasMesValor.Location = new System.Drawing.Point(11, 35);
            this.lblComprasMesValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComprasMesValor.Name = "lblComprasMesValor";
            this.lblComprasMesValor.Size = new System.Drawing.Size(57, 30);
            this.lblComprasMesValor.TabIndex = 0;
            this.lblComprasMesValor.Text = "0.00";
            // 
            // lblComprasMesTitulo
            // 
            this.lblComprasMesTitulo.AutoSize = true;
            this.lblComprasMesTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblComprasMesTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblComprasMesTitulo.Location = new System.Drawing.Point(11, 13);
            this.lblComprasMesTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComprasMesTitulo.Name = "lblComprasMesTitulo";
            this.lblComprasMesTitulo.Size = new System.Drawing.Size(88, 17);
            this.lblComprasMesTitulo.TabIndex = 1;
            this.lblComprasMesTitulo.Text = "Compras mes";
            // 
            // panelCaja2
            // 
            this.panelCaja2.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.panelCaja2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCaja2.Controls.Add(this.lblTotalHoyValor);
            this.panelCaja2.Controls.Add(this.lblTotalHoyTitulo);
            this.panelCaja2.Location = new System.Drawing.Point(185, 18);
            this.panelCaja2.Margin = new System.Windows.Forms.Padding(2);
            this.panelCaja2.Name = "panelCaja2";
            this.panelCaja2.Size = new System.Drawing.Size(150, 82);
            this.panelCaja2.TabIndex = 1;
            // 
            // lblTotalHoyValor
            // 
            this.lblTotalHoyValor.AutoSize = true;
            this.lblTotalHoyValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalHoyValor.ForeColor = System.Drawing.Color.White;
            this.lblTotalHoyValor.Location = new System.Drawing.Point(11, 35);
            this.lblTotalHoyValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalHoyValor.Name = "lblTotalHoyValor";
            this.lblTotalHoyValor.Size = new System.Drawing.Size(57, 30);
            this.lblTotalHoyValor.TabIndex = 0;
            this.lblTotalHoyValor.Text = "0.00";
            // 
            // lblTotalHoyTitulo
            // 
            this.lblTotalHoyTitulo.AutoSize = true;
            this.lblTotalHoyTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalHoyTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTotalHoyTitulo.Location = new System.Drawing.Point(11, 13);
            this.lblTotalHoyTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalHoyTitulo.Name = "lblTotalHoyTitulo";
            this.lblTotalHoyTitulo.Size = new System.Drawing.Size(112, 17);
            this.lblTotalHoyTitulo.TabIndex = 1;
            this.lblTotalHoyTitulo.Text = "Total vendido hoy";
            // 
            // panelCaja1
            // 
            this.panelCaja1.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.panelCaja1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCaja1.Controls.Add(this.lblVentasHoyValor);
            this.panelCaja1.Controls.Add(this.lblVentasHoyTitulo);
            this.panelCaja1.Location = new System.Drawing.Point(25, 18);
            this.panelCaja1.Margin = new System.Windows.Forms.Padding(2);
            this.panelCaja1.Name = "panelCaja1";
            this.panelCaja1.Size = new System.Drawing.Size(150, 82);
            this.panelCaja1.TabIndex = 0;
            // 
            // lblVentasHoyValor
            // 
            this.lblVentasHoyValor.AutoSize = true;
            this.lblVentasHoyValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblVentasHoyValor.ForeColor = System.Drawing.Color.White;
            this.lblVentasHoyValor.Location = new System.Drawing.Point(11, 35);
            this.lblVentasHoyValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVentasHoyValor.Name = "lblVentasHoyValor";
            this.lblVentasHoyValor.Size = new System.Drawing.Size(26, 30);
            this.lblVentasHoyValor.TabIndex = 0;
            this.lblVentasHoyValor.Text = "0";
            // 
            // lblVentasHoyTitulo
            // 
            this.lblVentasHoyTitulo.AutoSize = true;
            this.lblVentasHoyTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVentasHoyTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblVentasHoyTitulo.Location = new System.Drawing.Point(11, 13);
            this.lblVentasHoyTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVentasHoyTitulo.Name = "lblVentasHoyTitulo";
            this.lblVentasHoyTitulo.Size = new System.Drawing.Size(71, 17);
            this.lblVentasHoyTitulo.TabIndex = 1;
            this.lblVentasHoyTitulo.Text = "Ventas hoy";
            // 
            // panelGrid
            // 
            this.panelGrid.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.panelGrid.Controls.Add(this.dgvTopProductos);
            this.panelGrid.Controls.Add(this.lblTopProductos);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 285);
            this.panelGrid.Margin = new System.Windows.Forms.Padding(2);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(15, 8, 15, 16);
            this.panelGrid.Size = new System.Drawing.Size(1100, 365);
            this.panelGrid.TabIndex = 2;
            // 
            // dgvTopProductos
            // 
            this.dgvTopProductos.AllowUserToAddRows = false;
            this.dgvTopProductos.AllowUserToDeleteRows = false;
            this.dgvTopProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopProductos.BackgroundColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.dgvTopProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopProductos.Location = new System.Drawing.Point(15, 41);
            this.dgvTopProductos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTopProductos.MultiSelect = false;
            this.dgvTopProductos.Name = "dgvTopProductos";
            this.dgvTopProductos.ReadOnly = true;
            this.dgvTopProductos.RowHeadersVisible = false;
            this.dgvTopProductos.RowHeadersWidth = 51;
            this.dgvTopProductos.RowTemplate.Height = 24;
            this.dgvTopProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopProductos.Size = new System.Drawing.Size(1070, 305);
            this.dgvTopProductos.TabIndex = 1;
            // 
            // lblTopProductos
            // 
            this.lblTopProductos.AutoSize = true;
            this.lblTopProductos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTopProductos.ForeColor = System.Drawing.Color.White;
            this.lblTopProductos.Location = new System.Drawing.Point(17, 12);
            this.lblTopProductos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTopProductos.Name = "lblTopProductos";
            this.lblTopProductos.Size = new System.Drawing.Size(170, 20);
            this.lblTopProductos.TabIndex = 0;
            this.lblTopProductos.Text = "Top 5 productos venta";
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelResumen);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDashboard";
            this.Text = "Dashboard";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelResumen.ResumeLayout(false);
            this.panelCaja7.ResumeLayout(false);
            this.panelCaja7.PerformLayout();
            this.panelCaja6.ResumeLayout(false);
            this.panelCaja6.PerformLayout();
            this.panelCaja5.ResumeLayout(false);
            this.panelCaja5.PerformLayout();
            this.panelCaja4.ResumeLayout(false);
            this.panelCaja4.PerformLayout();
            this.panelCaja3.ResumeLayout(false);
            this.panelCaja3.PerformLayout();
            this.panelCaja2.ResumeLayout(false);
            this.panelCaja2.PerformLayout();
            this.panelCaja1.ResumeLayout(false);
            this.panelCaja1.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProductos)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelResumen;
        private System.Windows.Forms.Panel panelCaja1;
        private System.Windows.Forms.Label lblVentasHoyTitulo;
        private System.Windows.Forms.Label lblVentasHoyValor;
        private System.Windows.Forms.Panel panelCaja2;
        private System.Windows.Forms.Label lblTotalHoyTitulo;
        private System.Windows.Forms.Label lblTotalHoyValor;
        private System.Windows.Forms.Panel panelCaja3;
        private System.Windows.Forms.Label lblComprasMesTitulo;
        private System.Windows.Forms.Label lblComprasMesValor;
        private System.Windows.Forms.Panel panelCaja4;
        private System.Windows.Forms.Label lblPorPagarTitulo;
        private System.Windows.Forms.Label lblPorPagarValor;
        private System.Windows.Forms.Panel panelCaja5;
        private System.Windows.Forms.Label lblStockBajoTitulo;
        private System.Windows.Forms.Label lblStockBajoValor;
        private System.Windows.Forms.Panel panelCaja6;
        private System.Windows.Forms.Label lblProductosTitulo;
        private System.Windows.Forms.Label lblProductosValor;
        private System.Windows.Forms.Panel panelCaja7;
        private System.Windows.Forms.Label lblCajaActivaTitulo;
        private System.Windows.Forms.Label lblCajaActivaValor;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Label lblTopProductos;
        private System.Windows.Forms.DataGridView dgvTopProductos;
    }
}