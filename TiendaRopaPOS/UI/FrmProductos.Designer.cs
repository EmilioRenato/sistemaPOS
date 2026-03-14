namespace TiendaRopaPOS.UI
{
    partial class FrmProductos
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
            this.txtPrecioBase = new System.Windows.Forms.TextBox();
            this.lblPrecioBase = new System.Windows.Forms.Label();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cbUnidad = new System.Windows.Forms.ComboBox();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelFormulario.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
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
            this.panelFormulario.Controls.Add(this.txtPrecioBase);
            this.panelFormulario.Controls.Add(this.lblPrecioBase);
            this.panelFormulario.Controls.Add(this.cbCategoria);
            this.panelFormulario.Controls.Add(this.lblCategoria);
            this.panelFormulario.Controls.Add(this.cbUnidad);
            this.panelFormulario.Controls.Add(this.lblUnidad);
            this.panelFormulario.Controls.Add(this.txtReferencia);
            this.panelFormulario.Controls.Add(this.lblReferencia);
            this.panelFormulario.Controls.Add(this.txtDescripcion);
            this.panelFormulario.Controls.Add(this.lblDescripcion);
            this.panelFormulario.Controls.Add(this.txtCodigo);
            this.panelFormulario.Controls.Add(this.lblCodigo);
            this.panelFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFormulario.Location = new System.Drawing.Point(0, 70);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelFormulario.Size = new System.Drawing.Size(1180, 190);
            this.panelFormulario.TabIndex = 1;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Location = new System.Drawing.Point(900, 130);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(63, 20);
            this.chkEstado.TabIndex = 12;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // txtPrecioBase
            // 
            this.txtPrecioBase.Location = new System.Drawing.Point(620, 127);
            this.txtPrecioBase.Name = "txtPrecioBase";
            this.txtPrecioBase.Size = new System.Drawing.Size(220, 22);
            this.txtPrecioBase.TabIndex = 11;
            // 
            // lblPrecioBase
            // 
            this.lblPrecioBase.AutoSize = true;
            this.lblPrecioBase.Location = new System.Drawing.Point(520, 130);
            this.lblPrecioBase.Name = "lblPrecioBase";
            this.lblPrecioBase.Size = new System.Drawing.Size(79, 16);
            this.lblPrecioBase.TabIndex = 10;
            this.lblPrecioBase.Text = "Precio base";
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(220, 127);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(220, 24);
            this.cbCategoria.TabIndex = 9;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(100, 130);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(64, 16);
            this.lblCategoria.TabIndex = 8;
            this.lblCategoria.Text = "Categoría";
            // 
            // cbUnidad
            // 
            this.cbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnidad.FormattingEnabled = true;
            this.cbUnidad.Location = new System.Drawing.Point(900, 50);
            this.cbUnidad.Name = "cbUnidad";
            this.cbUnidad.Size = new System.Drawing.Size(180, 24);
            this.cbUnidad.TabIndex = 7;
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Location = new System.Drawing.Point(840, 53);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(50, 16);
            this.lblUnidad.TabIndex = 6;
            this.lblUnidad.Text = "Unidad";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(620, 50);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(180, 22);
            this.txtReferencia.TabIndex = 5;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(520, 53);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(73, 16);
            this.lblReferencia.TabIndex = 4;
            this.lblReferencia.Text = "Referencia";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(220, 87);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(580, 22);
            this.txtDescripcion.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(100, 90);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(79, 16);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(220, 50);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(220, 22);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(100, 53);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(53, 16);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código";
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnLimpiar);
            this.panelBotones.Controls.Add(this.btnActualizar);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBotones.Location = new System.Drawing.Point(0, 260);
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
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(0, 320);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(1180, 400);
            this.dgvProductos.TabIndex = 3;
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelFormulario);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmProductos";
            this.Size = new System.Drawing.Size(1180, 720);
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.FrmProductos_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFormulario.ResumeLayout(false);
            this.panelFormulario.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel panelFormulario;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.TextBox txtPrecioBase;
        private System.Windows.Forms.Label lblPrecioBase;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cbUnidad;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvProductos;
    }
}