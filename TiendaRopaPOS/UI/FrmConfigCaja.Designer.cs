namespace TiendaRopaPOS.UI
{
    partial class FrmConfigCaja
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
            this.lblCaja = new System.Windows.Forms.Label();
            this.cbCaja = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(22, 28);
            this.lblCaja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(88, 13);
            this.lblCaja.TabIndex = 0;
            this.lblCaja.Text = "Punto de emisión";
            // 
            // cbCaja
            // 
            this.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCaja.FormattingEnabled = true;
            this.cbCaja.Location = new System.Drawing.Point(112, 26);
            this.cbCaja.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbCaja.Name = "cbCaja";
            this.cbCaja.Size = new System.Drawing.Size(211, 21);
            this.cbCaja.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(112, 65);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 26);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FrmConfigCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 122);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cbCaja);
            this.Controls.Add(this.lblCaja);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmConfigCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de Caja";
            this.Load += new System.EventHandler(this.FrmConfigCaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.ComboBox cbCaja;
        private System.Windows.Forms.Button btnGuardar;
    }
}