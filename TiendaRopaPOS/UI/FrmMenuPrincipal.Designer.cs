namespace TiendaRopaPOS.UI
{
    partial class FrmMenuPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temporalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temporal2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maestrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagoDeComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.kardexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblCajaActiva = new System.Windows.Forms.Label();
            this.lblUsuarioActivo = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panelSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(57, 62, 70);
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Emoji", 9.5F);
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.maestrosToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.inventarioToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 25);
            this.menuStrip1.TabIndex = 0;
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesionToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.configuracionToolStripMenuItem,
            this.temporalToolStripMenuItem,
            this.temporal2ToolStripMenuItem});
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(78, 21);
            this.archivoToolStripMenuItem.Text = "📁 Archivo";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.cerrarSesionToolStripMenuItem.Text = "🔒 Cerrar sesión";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.usuariosToolStripMenuItem.Text = "👤 Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.dashboardToolStripMenuItem.Text = "📊 Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.configuracionToolStripMenuItem.Text = "⚙️ Configuración";
            this.configuracionToolStripMenuItem.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
            // 
            // temporalToolStripMenuItem
            // 
            this.temporalToolStripMenuItem.Name = "temporalToolStripMenuItem";
            this.temporalToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.temporalToolStripMenuItem.Text = "🧪 Temporal";
            this.temporalToolStripMenuItem.Click += new System.EventHandler(this.temporalToolStripMenuItem_Click);
            // 
            // temporal2ToolStripMenuItem
            // 
            this.temporal2ToolStripMenuItem.Name = "temporal2ToolStripMenuItem";
            this.temporal2ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.temporal2ToolStripMenuItem.Text = "🔄 Reconsulta SRI";
            this.temporal2ToolStripMenuItem.Click += new System.EventHandler(this.temporal2ToolStripMenuItem_Click);
            // 
            // maestrosToolStripMenuItem
            // 
            this.maestrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.vendedoresToolStripMenuItem,
            this.proveedoresToolStripMenuItem});
            this.maestrosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.maestrosToolStripMenuItem.Name = "maestrosToolStripMenuItem";
            this.maestrosToolStripMenuItem.Size = new System.Drawing.Size(90, 21);
            this.maestrosToolStripMenuItem.Text = "🗂️ Maestros";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.productosToolStripMenuItem.Text = "📦 Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click_1);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.clientesToolStripMenuItem.Text = "🧑 Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click_1);
            // 
            // vendedoresToolStripMenuItem
            // 
            this.vendedoresToolStripMenuItem.Name = "vendedoresToolStripMenuItem";
            this.vendedoresToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.vendedoresToolStripMenuItem.Text = "🧾 Vendedores";
            this.vendedoresToolStripMenuItem.Click += new System.EventHandler(this.vendedoresToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.proveedoresToolStripMenuItem.Text = "🏭 Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click_1);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturacionToolStripMenuItem,
            this.consultaDeVentasToolStripMenuItem});
            this.ventasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.ventasToolStripMenuItem.Text = "🛒 Ventas";
            // 
            // facturacionToolStripMenuItem
            // 
            this.facturacionToolStripMenuItem.Name = "facturacionToolStripMenuItem";
            this.facturacionToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.facturacionToolStripMenuItem.Text = "🧾 Facturación";
            this.facturacionToolStripMenuItem.Click += new System.EventHandler(this.facturacionToolStripMenuItem_Click);
            // 
            // consultaDeVentasToolStripMenuItem
            // 
            this.consultaDeVentasToolStripMenuItem.Name = "consultaDeVentasToolStripMenuItem";
            this.consultaDeVentasToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.consultaDeVentasToolStripMenuItem.Text = "📋 Consulta de ventas";
            this.consultaDeVentasToolStripMenuItem.Click += new System.EventHandler(this.consultaDeVentasToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprasToolStripMenuItem1,
            this.consultaDeComprasToolStripMenuItem,
            this.pagoDeComprasToolStripMenuItem});
            this.comprasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
            this.comprasToolStripMenuItem.Text = "💳 Compras";
            // 
            // comprasToolStripMenuItem1
            // 
            this.comprasToolStripMenuItem1.Name = "comprasToolStripMenuItem1";
            this.comprasToolStripMenuItem1.Size = new System.Drawing.Size(197, 22);
            this.comprasToolStripMenuItem1.Text = "🛍️ Compras";
            this.comprasToolStripMenuItem1.Click += new System.EventHandler(this.comprasToolStripMenuItem1_Click);
            // 
            // consultaDeComprasToolStripMenuItem
            // 
            this.consultaDeComprasToolStripMenuItem.Name = "consultaDeComprasToolStripMenuItem";
            this.consultaDeComprasToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.consultaDeComprasToolStripMenuItem.Text = "📋 Consulta de compras";
            this.consultaDeComprasToolStripMenuItem.Click += new System.EventHandler(this.consultaDeComprasToolStripMenuItem_Click);
            // 
            // pagoDeComprasToolStripMenuItem
            // 
            this.pagoDeComprasToolStripMenuItem.Name = "pagoDeComprasToolStripMenuItem";
            this.pagoDeComprasToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.pagoDeComprasToolStripMenuItem.Text = "💰 Pago de compras";
            this.pagoDeComprasToolStripMenuItem.Click += new System.EventHandler(this.pagoDeComprasToolStripMenuItem_Click);
            // 
            // inventarioToolStripMenuItem1
            // 
            this.inventarioToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioToolStripMenuItem2,
            this.kardexToolStripMenuItem});
            this.inventarioToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.inventarioToolStripMenuItem1.Name = "inventarioToolStripMenuItem1";
            this.inventarioToolStripMenuItem1.Size = new System.Drawing.Size(92, 21);
            this.inventarioToolStripMenuItem1.Text = "📚 Inventario";
            // 
            // inventarioToolStripMenuItem2
            // 
            this.inventarioToolStripMenuItem2.Name = "inventarioToolStripMenuItem2";
            this.inventarioToolStripMenuItem2.Size = new System.Drawing.Size(150, 22);
            this.inventarioToolStripMenuItem2.Text = "📦 Inventario";
            this.inventarioToolStripMenuItem2.Click += new System.EventHandler(this.inventarioToolStripMenuItem2_Click);
            // 
            // kardexToolStripMenuItem
            // 
            this.kardexToolStripMenuItem.Name = "kardexToolStripMenuItem";
            this.kardexToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.kardexToolStripMenuItem.Text = "📈 Kardex";
            this.kardexToolStripMenuItem.Click += new System.EventHandler(this.kardexToolStripMenuItem_Click);
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.panelSuperior.Controls.Add(this.lblCajaActiva);
            this.panelSuperior.Controls.Add(this.lblUsuarioActivo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 25);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1100, 38);
            this.panelSuperior.TabIndex = 1;
            // 
            // lblCajaActiva
            // 
            this.lblCajaActiva.AutoSize = true;
            this.lblCajaActiva.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCajaActiva.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblCajaActiva.Location = new System.Drawing.Point(12, 10);
            this.lblCajaActiva.Name = "lblCajaActiva";
            this.lblCajaActiva.Size = new System.Drawing.Size(86, 19);
            this.lblCajaActiva.TabIndex = 0;
            this.lblCajaActiva.Text = "🏪 Caja activa";
            // 
            // lblUsuarioActivo
            // 
            this.lblUsuarioActivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuarioActivo.AutoSize = true;
            this.lblUsuarioActivo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioActivo.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblUsuarioActivo.Location = new System.Drawing.Point(780, 10);
            this.lblUsuarioActivo.Name = "lblUsuarioActivo";
            this.lblUsuarioActivo.Size = new System.Drawing.Size(105, 19);
            this.lblUsuarioActivo.TabIndex = 1;
            this.lblUsuarioActivo.Text = "👤 Usuario activo";
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.White;
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 63);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1100, 587);
            this.panelContenedor.TabIndex = 2;
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenuPrincipal";
            this.Text = "Sistema ER - Inventario SASA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temporalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temporal2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maestrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultaDeComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagoDeComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem kardexToolStripMenuItem;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblCajaActiva;
        private System.Windows.Forms.Label lblUsuarioActivo;
        private System.Windows.Forms.Panel panelContenedor;
    }
}