namespace TiendaRopaPOS.UI
{
    partial class FrmInventario
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
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.txtUltimoCosto = new System.Windows.Forms.TextBox();
            this.lblUltimoCosto = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.cbBodega = new System.Windows.Forms.ComboBox();
            this.lblBodega = new System.Windows.Forms.Label();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelFormulario.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
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
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.panelTop.Size = new System.Drawing.Size(1180, 70);
            this.panelTop.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(730, 18);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 32);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(610, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 32);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(90, 22);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(500, 22);
            this.txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(23, 25);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(46, 16);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar";
            // 
            // panelFormulario
            // 
            this.panelFormulario.Controls.Add(this.chkEstado);
            this.panelFormulario.Controls.Add(this.txtPrecioVenta);
            this.panelFormulario.Controls.Add(this.lblPrecioVenta);
            this.panelFormulario.Controls.Add(this.txtUltimoCosto);
            this.panelFormulario.Controls.Add(this.lblUltimoCosto);
            this.panelFormulario.Controls.Add(this.txtStock);
            this.panelFormulario.Controls.Add(this.lblStock);
            this.panelFormulario.Controls.Add(this.cbBodega);
            this.panelFormulario.Controls.Add(this.lblBodega);
            this.panelFormulario.Controls.Add(this.cbProducto);
            this.panelFormulario.Controls.Add(this.lblProducto);
            this.panelFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFormulario.Location = new System.Drawing.Point(0, 70);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelFormulario.Size = new System.Drawing.Size(1180, 160);
            this.panelFormulario.TabIndex = 1;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Location = new System.Drawing.Point(900, 103);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(63, 20);
            this.chkEstado.TabIndex = 10;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(620, 100);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(220, 22);
            this.txtPrecioVenta.TabIndex = 9;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(520, 103);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(87, 16);
            this.lblPrecioVenta.TabIndex = 8;
            this.lblPrecioVenta.Text = "Precio venta";
            // 
            // txtUltimoCosto
            // 
            this.txtUltimoCosto.Location = new System.Drawing.Point(220, 100);
            this.txtUltimoCosto.Name = "txtUltimoCosto";
            this.txtUltimoCosto.Size = new System.Drawing.Size(220, 22);
            this.txtUltimoCosto.TabIndex = 7;
            // 
            // lblUltimoCosto
            // 
            this.lblUltimoCosto.AutoSize = true;
            this.lblUltimoCosto.Location = new System.Drawing.Point(100, 103);
            this.lblUltimoCosto.Name = "lblUltimoCosto";
            this.lblUltimoCosto.Size = new System.Drawing.Size(82, 16);
            this.lblUltimoCosto.TabIndex = 6;
            this.lblUltimoCosto.Text = "Último costo";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(900, 40);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(180, 22);
            this.txtStock.TabIndex = 5;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(850, 43);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(40, 16);
            this.lblStock.TabIndex = 4;
            this.lblStock.Text = "Stock";
            // 
            // cbBodega
            // 
            this.cbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBodega.FormattingEnabled = true;
            this.cbBodega.Location = new System.Drawing.Point(620, 40);
            this.cbBodega.Name = "cbBodega";
            this.cbBodega.Size = new System.Drawing.Size(200, 24);
            this.cbBodega.TabIndex = 3;
            // 
            // lblBodega
            // 
            this.lblBodega.AutoSize = true;
            this.lblBodega.Location = new System.Drawing.Point(540, 43);
            this.lblBodega.Name = "lblBodega";
            this.lblBodega.Size = new System.Drawing.Size(55, 16);
            this.lblBodega.TabIndex = 2;
            this.lblBodega.Text = "Bodega";
            // 
            // cbProducto
            // 
            this.cbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProducto.FormattingEnabled = true;
            this.cbProducto.Location = new System.Drawing.Point(220, 40);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(280, 24);
            this.cbProducto.TabIndex = 1;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(100, 43);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(61, 16);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Producto";
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnLimpiar);
            this.panelBotones.Controls.Add(this.btnActualizar);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBotones.Location = new System.Drawing.Point(0, 230);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelBotones.Size = new System.Drawing.Size(1180, 60);
            this.panelBotones.TabIndex = 2;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(380, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(110, 32);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(240, 12);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 32);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(100, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 32);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.Location = new System.Drawing.Point(0, 290);
            this.dgvInventario.MultiSelect = false;
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.RowHeadersWidth = 51;
            this.dgvInventario.RowTemplate.Height = 24;
            this.dgvInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventario.Size = new System.Drawing.Size(1180, 430);
            this.dgvInventario.TabIndex = 3;
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelFormulario);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmInventario";
            this.Size = new System.Drawing.Size(1180, 720);
            this.Text = "Inventario";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFormulario.ResumeLayout(false);
            this.panelFormulario.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel panelFormulario;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.TextBox txtUltimoCosto;
        private System.Windows.Forms.Label lblUltimoCosto;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.ComboBox cbBodega;
        private System.Windows.Forms.Label lblBodega;
        private System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvInventario;
    }
}