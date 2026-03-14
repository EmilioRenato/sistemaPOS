namespace TiendaRopaPOS.UI
{
    partial class FrmProveedores
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panelForm = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRUC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.txtBuscar);
            this.panelTop.Controls.Add(this.btnBuscar);
            this.panelTop.Controls.Add(this.btnNuevo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(284, 60);
            this.panelTop.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(80, 18);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(250, 20);
            this.txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(350, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(450, 15);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo";
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.label2);
            this.panelForm.Controls.Add(this.txtRazon);
            this.panelForm.Controls.Add(this.label3);
            this.panelForm.Controls.Add(this.txtRUC);
            this.panelForm.Controls.Add(this.label4);
            this.panelForm.Controls.Add(this.txtTelefono);
            this.panelForm.Controls.Add(this.label5);
            this.panelForm.Controls.Add(this.txtEmail);
            this.panelForm.Controls.Add(this.label6);
            this.panelForm.Controls.Add(this.txtDireccion);
            this.panelForm.Controls.Add(this.chkEstado);
            this.panelForm.Controls.Add(this.btnGuardar);
            this.panelForm.Controls.Add(this.btnActualizar);
            this.panelForm.Controls.Add(this.btnLimpiar);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelForm.Location = new System.Drawing.Point(0, 60);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(400, 201);
            this.panelForm.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Razón Social";
            // 
            // txtRazon
            // 
            this.txtRazon.Location = new System.Drawing.Point(140, 35);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(200, 20);
            this.txtRazon.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "RUC";
            // 
            // txtRUC
            // 
            this.txtRUC.Location = new System.Drawing.Point(140, 75);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(200, 20);
            this.txtRUC.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(140, 115);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);
            this.txtTelefono.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(20, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(140, 155);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(20, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(140, 195);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 20);
            this.txtDireccion.TabIndex = 9;
            // 
            // chkEstado
            // 
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Location = new System.Drawing.Point(140, 240);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(104, 24);
            this.chkEstado.TabIndex = 10;
            this.chkEstado.Text = "Activo";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(20, 300);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(130, 300);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 12;
            this.btnActualizar.Text = "Actualizar";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(260, 300);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProveedores.Location = new System.Drawing.Point(400, 60);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(0, 201);
            this.dgvProveedores.TabIndex = 0;
            // 
            // FrmProveedores
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmProveedores";
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.FrmProveedores_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelForm;

        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;

        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.TextBox txtRUC;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDireccion;

        private System.Windows.Forms.CheckBox chkEstado;

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnLimpiar;

        private System.Windows.Forms.DataGridView dgvProveedores;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}