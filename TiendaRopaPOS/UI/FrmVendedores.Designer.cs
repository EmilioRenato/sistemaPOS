namespace TiendaRopaPOS.UI
{
    partial class FrmVendedores
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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.panelFormulario = new System.Windows.Forms.Panel();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.txtComision = new System.Windows.Forms.TextBox();
            this.lblComision = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.lblAlias = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtCodigoVendedor = new System.Windows.Forms.TextBox();
            this.lblCodigoVendedor = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvVendedores = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelFormulario.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnNuevo);
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
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(405, 15);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 24);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(315, 15);
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
            this.txtBuscar.Size = new System.Drawing.Size(226, 20);
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
            // panelFormulario
            // 
            this.panelFormulario.Controls.Add(this.chkEstado);
            this.panelFormulario.Controls.Add(this.txtComision);
            this.panelFormulario.Controls.Add(this.lblComision);
            this.panelFormulario.Controls.Add(this.txtAlias);
            this.panelFormulario.Controls.Add(this.lblAlias);
            this.panelFormulario.Controls.Add(this.txtDocumento);
            this.panelFormulario.Controls.Add(this.lblDocumento);
            this.panelFormulario.Controls.Add(this.txtCodigoVendedor);
            this.panelFormulario.Controls.Add(this.lblCodigoVendedor);
            this.panelFormulario.Controls.Add(this.txtNombre);
            this.panelFormulario.Controls.Add(this.lblNombre);
            this.panelFormulario.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelFormulario.Location = new System.Drawing.Point(0, 57);
            this.panelFormulario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.panelFormulario.Size = new System.Drawing.Size(315, 447);
            this.panelFormulario.TabIndex = 1;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(105, 219);
            this.chkEstado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(56, 17);
            this.chkEstado.TabIndex = 10;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // txtComision
            // 
            this.txtComision.Location = new System.Drawing.Point(105, 179);
            this.txtComision.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(166, 20);
            this.txtComision.TabIndex = 9;
            // 
            // lblComision
            // 
            this.lblComision.AutoSize = true;
            this.lblComision.Location = new System.Drawing.Point(17, 181);
            this.lblComision.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComision.Name = "lblComision";
            this.lblComision.Size = new System.Drawing.Size(49, 13);
            this.lblComision.TabIndex = 8;
            this.lblComision.Text = "Comisión";
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(105, 138);
            this.txtAlias.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(166, 20);
            this.txtAlias.TabIndex = 7;
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(17, 141);
            this.lblAlias.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(29, 13);
            this.lblAlias.TabIndex = 6;
            this.lblAlias.Text = "Alias";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(105, 98);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(166, 20);
            this.txtDocumento.TabIndex = 5;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(17, 100);
            this.lblDocumento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(62, 13);
            this.lblDocumento.TabIndex = 4;
            this.lblDocumento.Text = "Documento";
            // 
            // txtCodigoVendedor
            // 
            this.txtCodigoVendedor.Location = new System.Drawing.Point(105, 57);
            this.txtCodigoVendedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCodigoVendedor.Name = "txtCodigoVendedor";
            this.txtCodigoVendedor.Size = new System.Drawing.Size(166, 20);
            this.txtCodigoVendedor.TabIndex = 3;
            // 
            // lblCodigoVendedor
            // 
            this.lblCodigoVendedor.AutoSize = true;
            this.lblCodigoVendedor.Location = new System.Drawing.Point(17, 59);
            this.lblCodigoVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigoVendedor.Name = "lblCodigoVendedor";
            this.lblCodigoVendedor.Size = new System.Drawing.Size(88, 13);
            this.lblCodigoVendedor.TabIndex = 2;
            this.lblCodigoVendedor.Text = "Código vendedor";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(105, 16);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(166, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(17, 19);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnLimpiar);
            this.panelBotones.Controls.Add(this.btnActualizar);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 504);
            this.panelBotones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelBotones.Size = new System.Drawing.Size(948, 49);
            this.panelBotones.TabIndex = 2;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(225, 10);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(82, 26);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(128, 10);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(82, 26);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(30, 10);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(82, 26);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // dgvVendedores
            // 
            this.dgvVendedores.AllowUserToAddRows = false;
            this.dgvVendedores.AllowUserToDeleteRows = false;
            this.dgvVendedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendedores.Location = new System.Drawing.Point(315, 57);
            this.dgvVendedores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvVendedores.MultiSelect = false;
            this.dgvVendedores.Name = "dgvVendedores";
            this.dgvVendedores.ReadOnly = true;
            this.dgvVendedores.RowHeadersWidth = 51;
            this.dgvVendedores.RowTemplate.Height = 24;
            this.dgvVendedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendedores.Size = new System.Drawing.Size(633, 447);
            this.dgvVendedores.TabIndex = 3;
            // 
            // FrmVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 553);
            this.Controls.Add(this.dgvVendedores);
            this.Controls.Add(this.panelFormulario);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmVendedores";
            this.Text = "Vendedores";
            this.Load += new System.EventHandler(this.FrmVendedores_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFormulario.ResumeLayout(false);
            this.panelFormulario.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel panelFormulario;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.TextBox txtComision;
        private System.Windows.Forms.Label lblComision;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtCodigoVendedor;
        private System.Windows.Forms.Label lblCodigoVendedor;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvVendedores;
    }
}