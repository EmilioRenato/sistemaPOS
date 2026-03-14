namespace TiendaRopaPOS.UI
{
    partial class FrmPagosCompras
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
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvComprasPendientes = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.txtSaldoPendiente = new System.Windows.Forms.TextBox();
            this.lblSaldoPendiente = new System.Windows.Forms.Label();
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.txtValorPagar = new System.Windows.Forms.TextBox();
            this.lblValorPagar = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasPendientes)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnBuscar);
            this.panelTop.Controls.Add(this.txtBuscar);
            this.panelTop.Controls.Add(this.lblBuscar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(15, 12, 15, 8);
            this.panelTop.Size = new System.Drawing.Size(948, 57);
            this.panelTop.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(338, 15);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 24);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(68, 18);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(248, 20);
            this.txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(17, 20);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(40, 13);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar";
            // 
            // dgvComprasPendientes
            // 
            this.dgvComprasPendientes.AllowUserToAddRows = false;
            this.dgvComprasPendientes.AllowUserToDeleteRows = false;
            this.dgvComprasPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprasPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComprasPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComprasPendientes.Location = new System.Drawing.Point(0, 57);
            this.dgvComprasPendientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvComprasPendientes.MultiSelect = false;
            this.dgvComprasPendientes.Name = "dgvComprasPendientes";
            this.dgvComprasPendientes.ReadOnly = true;
            this.dgvComprasPendientes.RowHeadersWidth = 51;
            this.dgvComprasPendientes.RowTemplate.Height = 24;
            this.dgvComprasPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprasPendientes.Size = new System.Drawing.Size(948, 398);
            this.dgvComprasPendientes.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnRegistrarPago);
            this.panelBottom.Controls.Add(this.txtSaldoPendiente);
            this.panelBottom.Controls.Add(this.lblSaldoPendiente);
            this.panelBottom.Controls.Add(this.cbMetodoPago);
            this.panelBottom.Controls.Add(this.lblMetodoPago);
            this.panelBottom.Controls.Add(this.txtValorPagar);
            this.panelBottom.Controls.Add(this.lblValorPagar);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 455);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelBottom.Size = new System.Drawing.Size(948, 98);
            this.panelBottom.TabIndex = 2;
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.Location = new System.Drawing.Point(802, 20);
            this.btnRegistrarPago.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(112, 26);
            this.btnRegistrarPago.TabIndex = 6;
            this.btnRegistrarPago.Text = "Registrar pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = true;
            // 
            // txtSaldoPendiente
            // 
            this.txtSaldoPendiente.Location = new System.Drawing.Point(638, 23);
            this.txtSaldoPendiente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSaldoPendiente.Name = "txtSaldoPendiente";
            this.txtSaldoPendiente.ReadOnly = true;
            this.txtSaldoPendiente.Size = new System.Drawing.Size(136, 20);
            this.txtSaldoPendiente.TabIndex = 5;
            // 
            // lblSaldoPendiente
            // 
            this.lblSaldoPendiente.AutoSize = true;
            this.lblSaldoPendiente.Location = new System.Drawing.Point(548, 25);
            this.lblSaldoPendiente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSaldoPendiente.Name = "lblSaldoPendiente";
            this.lblSaldoPendiente.Size = new System.Drawing.Size(84, 13);
            this.lblSaldoPendiente.TabIndex = 4;
            this.lblSaldoPendiente.Text = "Saldo pendiente";
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetodoPago.FormattingEnabled = true;
            this.cbMetodoPago.Location = new System.Drawing.Point(338, 23);
            this.cbMetodoPago.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(166, 21);
            this.cbMetodoPago.TabIndex = 3;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(255, 25);
            this.lblMetodoPago.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(70, 13);
            this.lblMetodoPago.TabIndex = 2;
            this.lblMetodoPago.Text = "Método pago";
            // 
            // txtValorPagar
            // 
            this.txtValorPagar.Location = new System.Drawing.Point(90, 23);
            this.txtValorPagar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtValorPagar.Name = "txtValorPagar";
            this.txtValorPagar.Size = new System.Drawing.Size(136, 20);
            this.txtValorPagar.TabIndex = 1;
            // 
            // lblValorPagar
            // 
            this.lblValorPagar.AutoSize = true;
            this.lblValorPagar.Location = new System.Drawing.Point(17, 25);
            this.lblValorPagar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValorPagar.Name = "lblValorPagar";
            this.lblValorPagar.Size = new System.Drawing.Size(61, 13);
            this.lblValorPagar.TabIndex = 0;
            this.lblValorPagar.Text = "Valor pagar";
            // 
            // FrmPagosCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 553);
            this.Controls.Add(this.dgvComprasPendientes);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmPagosCompras";
            this.Text = "Pagos Compras";
            this.Load += new System.EventHandler(this.FrmPagosCompras_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasPendientes)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DataGridView dgvComprasPendientes;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TextBox txtValorPagar;
        private System.Windows.Forms.Label lblValorPagar;
        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.TextBox txtSaldoPendiente;
        private System.Windows.Forms.Label lblSaldoPendiente;
        private System.Windows.Forms.Button btnRegistrarPago;
    }
}