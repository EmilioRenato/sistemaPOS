using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmDetalleCompra : Form
    {
        private readonly int idCompra;

        public FrmDetalleCompra(int compra)
        {
            InitializeComponent();
            idCompra = compra;
            this.Load += FrmDetalleCompra_Load;
        }

        private void FrmDetalleCompra_Load(object sender, EventArgs e)
        {
            CargarDetalleCompra();
        }

        private void CargarDetalleCompra()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT
                        p.Codigo,
                        p.Descripcion,
                        dc.Cantidad,
                        dc.CostoUnitario,
                        dc.Descuento,
                        dc.IvaLinea,
                        dc.TotalLinea
                    FROM DetalleCompras dc
                    INNER JOIN Productos p ON dc.IdProducto = p.IdProducto
                    WHERE dc.IdCompra = @IdCompra
                    ORDER BY dc.IdDetalleCompra";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdCompra", idCompra);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDetalle.DataSource = dt;

                if (dgvDetalle.Columns.Contains("Codigo"))
                    dgvDetalle.Columns["Codigo"].HeaderText = "Código";

                if (dgvDetalle.Columns.Contains("Descripcion"))
                    dgvDetalle.Columns["Descripcion"].HeaderText = "Producto";

                if (dgvDetalle.Columns.Contains("Cantidad"))
                    dgvDetalle.Columns["Cantidad"].HeaderText = "Cant.";

                if (dgvDetalle.Columns.Contains("CostoUnitario"))
                    dgvDetalle.Columns["CostoUnitario"].HeaderText = "Costo";

                if (dgvDetalle.Columns.Contains("IvaLinea"))
                    dgvDetalle.Columns["IvaLinea"].HeaderText = "IVA";

                if (dgvDetalle.Columns.Contains("TotalLinea"))
                    dgvDetalle.Columns["TotalLinea"].HeaderText = "Total";

                if (dgvDetalle.Columns.Contains("Cantidad"))
                    dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "0.00";

                if (dgvDetalle.Columns.Contains("CostoUnitario"))
                    dgvDetalle.Columns["CostoUnitario"].DefaultCellStyle.Format = "0.00000";

                if (dgvDetalle.Columns.Contains("Descuento"))
                    dgvDetalle.Columns["Descuento"].DefaultCellStyle.Format = "0.00";

                if (dgvDetalle.Columns.Contains("IvaLinea"))
                    dgvDetalle.Columns["IvaLinea"].DefaultCellStyle.Format = "0.00";

                if (dgvDetalle.Columns.Contains("TotalLinea"))
                    dgvDetalle.Columns["TotalLinea"].DefaultCellStyle.Format = "0.00";
            }
        }
    }
}