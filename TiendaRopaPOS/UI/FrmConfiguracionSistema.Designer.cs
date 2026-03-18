namespace TiendaRopaPOS.UI
{
    partial class FrmConfiguracionSistema
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
            this.panelFormulario = new System.Windows.Forms.Panel();
            this.grpNegocio = new System.Windows.Forms.GroupBox();
            this.txtRucNegocio = new System.Windows.Forms.TextBox();
            this.lblRucNegocio = new System.Windows.Forms.Label();
            this.txtNombreNegocio = new System.Windows.Forms.TextBox();
            this.lblNombreNegocio = new System.Windows.Forms.Label();
            this.grpInventario = new System.Windows.Forms.GroupBox();
            this.cbBodegaStockGeneral = new System.Windows.Forms.ComboBox();
            this.lblBodegaStockGeneral = new System.Windows.Forms.Label();
            this.txtIvaPorcentaje = new System.Windows.Forms.TextBox();
            this.lblIvaPorcentaje = new System.Windows.Forms.Label();
            this.grpSri = new System.Windows.Forms.GroupBox();
            this.cbAmbienteSRI = new System.Windows.Forms.ComboBox();
            this.lblAmbienteSRI = new System.Windows.Forms.Label();
            this.grpRespaldo = new System.Windows.Forms.GroupBox();
            this.txtRutaRespaldo = new System.Windows.Forms.TextBox();
            this.lblRutaRespaldo = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelFormulario.SuspendLayout();
            this.grpNegocio.SuspendLayout();
            this.grpInventario.SuspendLayout();
            this.grpSri.SuspendLayout();
            this.grpRespaldo.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(20, 14, 20, 10);
            this.panelTop.Size = new System.Drawing.Size(900, 65);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(18, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(271, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Configuración del sistema";
            // 
            // panelFormulario
            // 
            this.panelFormulario.AutoScroll = true;
            this.panelFormulario.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.panelFormulario.Controls.Add(this.grpRespaldo);
            this.panelFormulario.Controls.Add(this.grpSri);
            this.panelFormulario.Controls.Add(this.grpInventario);
            this.panelFormulario.Controls.Add(this.grpNegocio);
            this.panelFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormulario.Location = new System.Drawing.Point(0, 65);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelFormulario.Size = new System.Drawing.Size(900, 485);
            this.panelFormulario.TabIndex = 1;
            // 
            // grpNegocio
            // 
            this.grpNegocio.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.grpNegocio.Controls.Add(this.txtRucNegocio);
            this.grpNegocio.Controls.Add(this.lblRucNegocio);
            this.grpNegocio.Controls.Add(this.txtNombreNegocio);
            this.grpNegocio.Controls.Add(this.lblNombreNegocio);
            this.grpNegocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpNegocio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpNegocio.ForeColor = System.Drawing.Color.White;
            this.grpNegocio.Location = new System.Drawing.Point(20, 15);
            this.grpNegocio.Name = "grpNegocio";
            this.grpNegocio.Size = new System.Drawing.Size(840, 110);
            this.grpNegocio.TabIndex = 0;
            this.grpNegocio.TabStop = false;
            this.grpNegocio.Text = "Datos del negocio";
            // 
            // txtRucNegocio
            // 
            this.txtRucNegocio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRucNegocio.Location = new System.Drawing.Point(170, 66);
            this.txtRucNegocio.Name = "txtRucNegocio";
            this.txtRucNegocio.Size = new System.Drawing.Size(220, 25);
            this.txtRucNegocio.TabIndex = 3;
            // 
            // lblRucNegocio
            // 
            this.lblRucNegocio.AutoSize = true;
            this.lblRucNegocio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRucNegocio.ForeColor = System.Drawing.Color.White;
            this.lblRucNegocio.Location = new System.Drawing.Point(35, 69);
            this.lblRucNegocio.Name = "lblRucNegocio";
            this.lblRucNegocio.Size = new System.Drawing.Size(98, 19);
            this.lblRucNegocio.TabIndex = 2;
            this.lblRucNegocio.Text = "RUC negocio";
            // 
            // txtNombreNegocio
            // 
            this.txtNombreNegocio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombreNegocio.Location = new System.Drawing.Point(170, 30);
            this.txtNombreNegocio.Name = "txtNombreNegocio";
            this.txtNombreNegocio.Size = new System.Drawing.Size(420, 25);
            this.txtNombreNegocio.TabIndex = 1;
            // 
            // lblNombreNegocio
            // 
            this.lblNombreNegocio.AutoSize = true;
            this.lblNombreNegocio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNombreNegocio.ForeColor = System.Drawing.Color.White;
            this.lblNombreNegocio.Location = new System.Drawing.Point(35, 33);
            this.lblNombreNegocio.Name = "lblNombreNegocio";
            this.lblNombreNegocio.Size = new System.Drawing.Size(117, 19);
            this.lblNombreNegocio.TabIndex = 0;
            this.lblNombreNegocio.Text = "Nombre negocio";
            // 
            // grpInventario
            // 
            this.grpInventario.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.grpInventario.Controls.Add(this.cbBodegaStockGeneral);
            this.grpInventario.Controls.Add(this.lblBodegaStockGeneral);
            this.grpInventario.Controls.Add(this.txtIvaPorcentaje);
            this.grpInventario.Controls.Add(this.lblIvaPorcentaje);
            this.grpInventario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpInventario.ForeColor = System.Drawing.Color.White;
            this.grpInventario.Location = new System.Drawing.Point(20, 140);
            this.grpInventario.Name = "grpInventario";
            this.grpInventario.Size = new System.Drawing.Size(840, 110);
            this.grpInventario.TabIndex = 1;
            this.grpInventario.TabStop = false;
            this.grpInventario.Text = "Inventario e impuestos";
            // 
            // cbBodegaStockGeneral
            // 
            this.cbBodegaStockGeneral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBodegaStockGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBodegaStockGeneral.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbBodegaStockGeneral.FormattingEnabled = true;
            this.cbBodegaStockGeneral.Location = new System.Drawing.Point(170, 30);
            this.cbBodegaStockGeneral.Name = "cbBodegaStockGeneral";
            this.cbBodegaStockGeneral.Size = new System.Drawing.Size(320, 25);
            this.cbBodegaStockGeneral.TabIndex = 5;
            // 
            // lblBodegaStockGeneral
            // 
            this.lblBodegaStockGeneral.AutoSize = true;
            this.lblBodegaStockGeneral.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBodegaStockGeneral.ForeColor = System.Drawing.Color.White;
            this.lblBodegaStockGeneral.Location = new System.Drawing.Point(35, 33);
            this.lblBodegaStockGeneral.Name = "lblBodegaStockGeneral";
            this.lblBodegaStockGeneral.Size = new System.Drawing.Size(128, 19);
            this.lblBodegaStockGeneral.TabIndex = 4;
            this.lblBodegaStockGeneral.Text = "Bodega general";
            // 
            // txtIvaPorcentaje
            // 
            this.txtIvaPorcentaje.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtIvaPorcentaje.Location = new System.Drawing.Point(170, 67);
            this.txtIvaPorcentaje.Name = "txtIvaPorcentaje";
            this.txtIvaPorcentaje.Size = new System.Drawing.Size(120, 25);
            this.txtIvaPorcentaje.TabIndex = 7;
            // 
            // lblIvaPorcentaje
            // 
            this.lblIvaPorcentaje.AutoSize = true;
            this.lblIvaPorcentaje.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIvaPorcentaje.ForeColor = System.Drawing.Color.White;
            this.lblIvaPorcentaje.Location = new System.Drawing.Point(35, 70);
            this.lblIvaPorcentaje.Name = "lblIvaPorcentaje";
            this.lblIvaPorcentaje.Size = new System.Drawing.Size(106, 19);
            this.lblIvaPorcentaje.TabIndex = 6;
            this.lblIvaPorcentaje.Text = "IVA porcentaje";
            // 
            // grpSri
            // 
            this.grpSri.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.grpSri.Controls.Add(this.cbAmbienteSRI);
            this.grpSri.Controls.Add(this.lblAmbienteSRI);
            this.grpSri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpSri.ForeColor = System.Drawing.Color.White;
            this.grpSri.Location = new System.Drawing.Point(20, 265);
            this.grpSri.Name = "grpSri";
            this.grpSri.Size = new System.Drawing.Size(840, 80);
            this.grpSri.TabIndex = 2;
            this.grpSri.TabStop = false;
            this.grpSri.Text = "Configuración SRI";
            // 
            // cbAmbienteSRI
            // 
            this.cbAmbienteSRI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAmbienteSRI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAmbienteSRI.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbAmbienteSRI.FormattingEnabled = true;
            this.cbAmbienteSRI.Items.AddRange(new object[] {
            "PRUEBAS",
            "PRODUCCION"});
            this.cbAmbienteSRI.Location = new System.Drawing.Point(170, 31);
            this.cbAmbienteSRI.Name = "cbAmbienteSRI";
            this.cbAmbienteSRI.Size = new System.Drawing.Size(180, 25);
            this.cbAmbienteSRI.TabIndex = 9;
            // 
            // lblAmbienteSRI
            // 
            this.lblAmbienteSRI.AutoSize = true;
            this.lblAmbienteSRI.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAmbienteSRI.ForeColor = System.Drawing.Color.White;
            this.lblAmbienteSRI.Location = new System.Drawing.Point(35, 34);
            this.lblAmbienteSRI.Name = "lblAmbienteSRI";
            this.lblAmbienteSRI.Size = new System.Drawing.Size(96, 19);
            this.lblAmbienteSRI.TabIndex = 8;
            this.lblAmbienteSRI.Text = "Ambiente SRI";
            // 
            // grpRespaldo
            // 
            this.grpRespaldo.BackColor = System.Drawing.Color.FromArgb(99, 110, 114);
            this.grpRespaldo.Controls.Add(this.txtRutaRespaldo);
            this.grpRespaldo.Controls.Add(this.lblRutaRespaldo);
            this.grpRespaldo.Controls.Add(this.txtObservacion);
            this.grpRespaldo.Controls.Add(this.lblObservacion);
            this.grpRespaldo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpRespaldo.ForeColor = System.Drawing.Color.White;
            this.grpRespaldo.Location = new System.Drawing.Point(20, 360);
            this.grpRespaldo.Name = "grpRespaldo";
            this.grpRespaldo.Size = new System.Drawing.Size(840, 150);
            this.grpRespaldo.TabIndex = 3;
            this.grpRespaldo.TabStop = false;
            this.grpRespaldo.Text = "Respaldo y notas";
            // 
            // txtRutaRespaldo
            // 
            this.txtRutaRespaldo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRutaRespaldo.Location = new System.Drawing.Point(170, 31);
            this.txtRutaRespaldo.Name = "txtRutaRespaldo";
            this.txtRutaRespaldo.Size = new System.Drawing.Size(500, 25);
            this.txtRutaRespaldo.TabIndex = 11;
            // 
            // lblRutaRespaldo
            // 
            this.lblRutaRespaldo.AutoSize = true;
            this.lblRutaRespaldo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRutaRespaldo.ForeColor = System.Drawing.Color.White;
            this.lblRutaRespaldo.Location = new System.Drawing.Point(35, 34);
            this.lblRutaRespaldo.Name = "lblRutaRespaldo";
            this.lblRutaRespaldo.Size = new System.Drawing.Size(102, 19);
            this.lblRutaRespaldo.TabIndex = 10;
            this.lblRutaRespaldo.Text = "Ruta respaldo";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtObservacion.Location = new System.Drawing.Point(170, 69);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(500, 58);
            this.txtObservacion.TabIndex = 13;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblObservacion.ForeColor = System.Drawing.Color.White;
            this.lblObservacion.Location = new System.Drawing.Point(35, 72);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(93, 19);
            this.lblObservacion.TabIndex = 12;
            this.lblObservacion.Text = "Observación";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(223, 230, 233);
            this.panelBottom.Controls.Add(this.btnGuardar);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 550);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelBottom.Size = new System.Drawing.Size(900, 60);
            this.panelBottom.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 184, 148);
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(25, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 34);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // FrmConfiguracionSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.ClientSize = new System.Drawing.Size(900, 610);
            this.Controls.Add(this.panelFormulario);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmConfiguracionSistema";
            this.Text = "Configuración del sistema";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFormulario.ResumeLayout(false);
            this.grpNegocio.ResumeLayout(false);
            this.grpNegocio.PerformLayout();
            this.grpInventario.ResumeLayout(false);
            this.grpInventario.PerformLayout();
            this.grpSri.ResumeLayout(false);
            this.grpSri.PerformLayout();
            this.grpRespaldo.ResumeLayout(false);
            this.grpRespaldo.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFormulario;
        private System.Windows.Forms.GroupBox grpNegocio;
        private System.Windows.Forms.TextBox txtRucNegocio;
        private System.Windows.Forms.Label lblRucNegocio;
        private System.Windows.Forms.TextBox txtNombreNegocio;
        private System.Windows.Forms.Label lblNombreNegocio;
        private System.Windows.Forms.GroupBox grpInventario;
        private System.Windows.Forms.ComboBox cbBodegaStockGeneral;
        private System.Windows.Forms.Label lblBodegaStockGeneral;
        private System.Windows.Forms.TextBox txtIvaPorcentaje;
        private System.Windows.Forms.Label lblIvaPorcentaje;
        private System.Windows.Forms.GroupBox grpSri;
        private System.Windows.Forms.ComboBox cbAmbienteSRI;
        private System.Windows.Forms.Label lblAmbienteSRI;
        private System.Windows.Forms.GroupBox grpRespaldo;
        private System.Windows.Forms.TextBox txtRutaRespaldo;
        private System.Windows.Forms.Label lblRutaRespaldo;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnGuardar;
    }
}