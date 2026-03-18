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
            this.lblTitulo = new System.Windows.Forms.Label();
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
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.btnBuscar);
            this.panelTop.Controls.Add(this.txtBuscar);
            this.panelTop.Controls.Add(this.lblBuscar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(15, 12, 15, 8);
            this.panelTop.Size = new System.Drawing.Size(1100, 82);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(18, 10);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(180, 28);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Pagos de compras";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(9, 132, 227);
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(520, 43);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "🔎 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(85, 46);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(410, 25);
            this.txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.ForeColor = System.Drawing.Color.White;
            this.lblBuscar.Location = new System.Drawing.Point(18, 49);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 19);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar";
            // 
            // dgvComprasPendientes
            // 
            this.dgvComprasPendientes.AllowUserToAddRows = false;
            this.dgvComprasPendientes.AllowUserToDeleteRows = false;
            this.dgvComprasPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprasPendientes.BackgroundColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.dgvComprasPendientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvComprasPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComprasPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComprasPendientes.Location = new System.Drawing.Point(0, 82);
            this.dgvComprasPendientes.Margin = new System.Windows.Forms.Padding(2);
            this.dgvComprasPendientes.MultiSelect = false;
            this.dgvComprasPendientes.Name = "dgvComprasPendientes";
            this.dgvComprasPendientes.ReadOnly = true;
            this.dgvComprasPendientes.RowHeadersVisible = false;
            this.dgvComprasPendientes.RowHeadersWidth = 51;
            this.dgvComprasPendientes.RowTemplate.Height = 24;
            this.dgvComprasPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprasPendientes.Size = new System.Drawing.Size(1100, 468);
            this.dgvComprasPendientes.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(223, 230, 233);
            this.panelBottom.Controls.Add(this.btnRegistrarPago);
            this.panelBottom.Controls.Add(this.txtSaldoPendiente);
            this.panelBottom.Controls.Add(this.lblSaldoPendiente);
            this.panelBottom.Controls.Add(this.cbMetodoPago);
            this.panelBottom.Controls.Add(this.lblMetodoPago);
            this.panelBottom.Controls.Add(this.txtValorPagar);
            this.panelBottom.Controls.Add(this.lblValorPagar);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 550);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelBottom.Size = new System.Drawing.Size(1100, 100);
            this.panelBottom.TabIndex = 2;
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.BackColor = System.Drawing.Color.FromArgb(0, 184, 148);
            this.btnRegistrarPago.FlatAppearance.BorderSize = 0;
            this.btnRegistrarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarPago.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarPago.Location = new System.Drawing.Point(900, 24);
            this.btnRegistrarPago.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(150, 34);
            this.btnRegistrarPago.TabIndex = 6;
            this.btnRegistrarPago.Text = "💵 Registrar pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = false;
            // 
            // txtSaldoPendiente
            // 
            this.txtSaldoPendiente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSaldoPendiente.Location = new System.Drawing.Point(720, 29);
            this.txtSaldoPendiente.Margin = new System.Windows.Forms.Padding(2);
            this.txtSaldoPendiente.Name = "txtSaldoPendiente";
            this.txtSaldoPendiente.ReadOnly = true;
            this.txtSaldoPendiente.Size = new System.Drawing.Size(150, 25);
            this.txtSaldoPendiente.TabIndex = 5;
            // 
            // lblSaldoPendiente
            // 
            this.lblSaldoPendiente.AutoSize = true;
            this.lblSaldoPendiente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSaldoPendiente.Location = new System.Drawing.Point(600, 32);
            this.lblSaldoPendiente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSaldoPendiente.Name = "lblSaldoPendiente";
            this.lblSaldoPendiente.Size = new System.Drawing.Size(111, 19);
            this.lblSaldoPendiente.TabIndex = 4;
            this.lblSaldoPendiente.Text = "Saldo pendiente";
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetodoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMetodoPago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbMetodoPago.FormattingEnabled = true;
            this.cbMetodoPago.Location = new System.Drawing.Point(365, 29);
            this.cbMetodoPago.Margin = new System.Windows.Forms.Padding(2);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(200, 25);
            this.cbMetodoPago.TabIndex = 3;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMetodoPago.Location = new System.Drawing.Point(255, 32);
            this.lblMetodoPago.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(96, 19);
            this.lblMetodoPago.TabIndex = 2;
            this.lblMetodoPago.Text = "Método pago";
            // 
            // txtValorPagar
            // 
            this.txtValorPagar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtValorPagar.Location = new System.Drawing.Point(90, 29);
            this.txtValorPagar.Margin = new System.Windows.Forms.Padding(2);
            this.txtValorPagar.Name = "txtValorPagar";
            this.txtValorPagar.Size = new System.Drawing.Size(136, 25);
            this.txtValorPagar.TabIndex = 1;
            // 
            // lblValorPagar
            // 
            this.lblValorPagar.AutoSize = true;
            this.lblValorPagar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblValorPagar.Location = new System.Drawing.Point(17, 32);
            this.lblValorPagar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValorPagar.Name = "lblValorPagar";
            this.lblValorPagar.Size = new System.Drawing.Size(79, 19);
            this.lblValorPagar.TabIndex = 0;
            this.lblValorPagar.Text = "Valor pagar";
            // 
            // FrmPagosCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.dgvComprasPendientes);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label lblTitulo;
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