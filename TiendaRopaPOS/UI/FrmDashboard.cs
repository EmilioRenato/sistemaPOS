using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TiendaRopaPOS.Clases;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
            this.Load += FrmDashboard_Load;
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            CargarIndicadores();
            CargarTopProductos();
            CargarCajaActiva();
        }

        private void CargarIndicadores()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                // Ventas hoy
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT COUNT(*)
                    FROM Ventas
                    WHERE CAST(FechaCreacion AS DATE) = CAST(GETDATE() AS DATE)
                      AND Estado IN ('ACTIVA', 'FACTURADA')", cn))
                {
                    lblVentasHoyValor.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                }

                // Total vendido hoy
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT ISNULL(SUM(Total),0)
                    FROM Ventas
                    WHERE CAST(FechaCreacion AS DATE) = CAST(GETDATE() AS DATE)
                      AND Estado IN ('ACTIVA', 'FACTURADA')", cn))
                {
                    lblTotalHoyValor.Text = Convert.ToDecimal(cmd.ExecuteScalar()).ToString("0.00");
                }

                // Compras del mes
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT ISNULL(SUM(Total),0)
                    FROM Compras
                    WHERE YEAR(FechaDocumento) = YEAR(GETDATE())
                      AND MONTH(FechaDocumento) = MONTH(GETDATE())
                      AND Estado = 1", cn))
                {
                    lblComprasMesValor.Text = Convert.ToDecimal(cmd.ExecuteScalar()).ToString("0.00");
                }

                // Cuentas por pagar
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT ISNULL(SUM(c.Total - ISNULL(p.Pagado,0)),0)
                    FROM Compras c
                    OUTER APPLY
                    (
                        SELECT SUM(ValorPagado) AS Pagado
                        FROM PagosCompras pc
                        WHERE pc.IdCompra = c.IdCompra AND pc.Estado = 1
                    ) p
                    WHERE c.Estado = 1
                      AND c.Pagada = 0", cn))
                {
                    lblPorPagarValor.Text = Convert.ToDecimal(cmd.ExecuteScalar()).ToString("0.00");
                }

                // Stock bajo
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT COUNT(*)
                    FROM Inventario
                    WHERE IdBodega = @IdBodega
                      AND Estado = 1
                      AND Stock <= 5", cn))
                {
                    cmd.Parameters.AddWithValue("@IdBodega", ConfiguracionSistema.IdBodegaStockGeneral);
                    lblStockBajoValor.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                }

                // Productos activos
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT COUNT(*)
                    FROM Productos
                    WHERE Estado = 1", cn))
                {
                    lblProductosValor.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                }
            }
        }

        private void CargarCajaActiva()
        {
            lblCajaActivaValor.Text = string.IsNullOrWhiteSpace(SesionUsuario.NombreCajaEmision)
                ? "SIN CONFIGURAR"
                : SesionUsuario.NombreCajaEmision;
        }

        private void CargarTopProductos()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT TOP 5
                        p.Codigo,
                        p.Descripcion,
                        SUM(dv.Cantidad) AS CantidadVendida,
                        SUM(dv.TotalLinea) AS TotalVendido
                    FROM DetalleVentas dv
                    INNER JOIN Productos p ON dv.IdProducto = p.IdProducto
                    INNER JOIN Ventas v ON dv.IdVenta = v.IdVenta
                    WHERE v.Estado IN ('ACTIVA', 'FACTURADA')
                    GROUP BY p.Codigo, p.Descripcion
                    ORDER BY SUM(dv.Cantidad) DESC, SUM(dv.TotalLinea) DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTopProductos.DataSource = dt;

                if (dgvTopProductos.Columns.Contains("Codigo"))
                    dgvTopProductos.Columns["Codigo"].HeaderText = "Código";

                if (dgvTopProductos.Columns.Contains("Descripcion"))
                    dgvTopProductos.Columns["Descripcion"].HeaderText = "Producto";

                if (dgvTopProductos.Columns.Contains("CantidadVendida"))
                    dgvTopProductos.Columns["CantidadVendida"].HeaderText = "Cantidad";

                if (dgvTopProductos.Columns.Contains("TotalVendido"))
                {
                    dgvTopProductos.Columns["TotalVendido"].HeaderText = "Total vendido";
                    dgvTopProductos.Columns["TotalVendido"].DefaultCellStyle.Format = "0.00";
                }
            }
        }

        private void FrmDashboard_Load_1(object sender, EventArgs e)
        {

        }
    }
}