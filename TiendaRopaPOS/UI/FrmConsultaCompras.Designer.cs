namespace TiendaRopaPOS.UI
{
    partial class FrmConsultaCompras
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnIrPagos = new System.Windows.Forms.Button();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnBuscar);
            this.panelTop.Controls.Add(this.dtHasta);
            this.panelTop.Controls.Add(this.lblHasta);
            this.panelTop.Controls.Add(this.dtDesde);
            this.panelTop.Controls.Add(this.lblDesde);
            this.panelTop.Controls.Add(this.txtBuscar);
            this.panelTop.Controls.Add(this.lblBuscar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(15, 12, 15, 8);
            this.panelTop.Size = new System.Drawing.Size(948, 65);
            this.panelTop.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(698, 16);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 24);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(585, 20);
            this.dtHasta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(91, 20);
            this.dtHasta.TabIndex = 5;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(548, 22);
            this.lblHasta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 4;
            this.lblHasta.Text = "Hasta";
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(442, 20);
            this.dtDesde.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(91, 20);
            this.dtDesde.TabIndex = 3;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(401, 22);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(38, 13);
            this.lblDesde.TabIndex = 2;
            this.lblDesde.Text = "Desde";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(68, 20);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(316, 20);
            this.txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(17, 22);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(40, 13);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar";
            // 
            // dgvCompras
            // 
            this.dgvCompras.AllowUserToAddRows = false;
            this.dgvCompras.AllowUserToDeleteRows = false;
            this.dgvCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompras.Location = new System.Drawing.Point(0, 65);
            this.dgvCompras.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvCompras.MultiSelect = false;
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.ReadOnly = true;
            this.dgvCompras.RowHeadersWidth = 51;
            this.dgvCompras.RowTemplate.Height = 24;
            this.dgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompras.Size = new System.Drawing.Size(948, 439);
            this.dgvCompras.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnIrPagos);
            this.panelBottom.Controls.Add(this.btnVerDetalle);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 504);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelBottom.Size = new System.Drawing.Size(948, 49);
            this.panelBottom.TabIndex = 2;
            // 
            // btnIrPagos
            // 
            this.btnIrPagos.Location = new System.Drawing.Point(158, 10);
            this.btnIrPagos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIrPagos.Name = "btnIrPagos";
            this.btnIrPagos.Size = new System.Drawing.Size(105, 26);
            this.btnIrPagos.TabIndex = 1;
            this.btnIrPagos.Text = "Registrar pagos";
            this.btnIrPagos.UseVisualStyleBackColor = true;
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Location = new System.Drawing.Point(45, 10);
            this.btnVerDetalle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(90, 26);
            this.btnVerDetalle.TabIndex = 0;
            this.btnVerDetalle.Text = "Ver detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            // 
            // FrmConsultaCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 553);
            this.Controls.Add(this.dgvCompras);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmConsultaCompras";
            this.Text = "Consulta de Compras";
            this.Load += new System.EventHandler(this.FrmConsultaCompras_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnIrPagos;
    }
}