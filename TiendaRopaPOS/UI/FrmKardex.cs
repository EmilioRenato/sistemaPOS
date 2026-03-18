using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TiendaRopaPOS.Clases;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.UI
{
    public partial class FrmKardex : Form
    {
        public FrmKardex()
        {
            InitializeComponent();

            btnBuscar.Click += btnBuscar_Click;
            txtBuscar.KeyDown += txtBuscar_KeyDown;

            this.Load += FrmKardex_Load;
        }

        private void FrmKardex_Load(object sender, EventArgs e)
        {
            dtDesde.Value = DateTime.Today.AddMonths(-1);
            dtHasta.Value = DateTime.Today;

            AplicarEstiloVisual();
            AplicarAnimaciones();
            CargarKardex();
        }

        private void AplicarEstiloVisual()
        {
            dgvKardex.EnableHeadersVisualStyles = false;
            dgvKardex.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 52, 54);
            dgvKardex.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKardex.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvKardex.ColumnHeadersHeight = 34;

            dgvKardex.DefaultCellStyle.BackColor = Color.FromArgb(99, 110, 114);
            dgvKardex.DefaultCellStyle.ForeColor = Color.White;
            dgvKardex.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvKardex.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 82, 84);
            dgvKardex.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvKardex.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 82, 84);
            dgvKardex.GridColor = Color.FromArgb(178, 190, 195);
            dgvKardex.BorderStyle = BorderStyle.None;
            dgvKardex.RowHeadersVisible = false;
            dgvKardex.RowTemplate.Height = 30;

            txtBuscar.Font = new Font("Segoe UI", 10F);
            dtDesde.Font = new Font("Segoe UI", 10F);
            dtHasta.Font = new Font("Segoe UI", 10F);
        }

        private void AplicarAnimaciones()
        {
            btnBuscar.MouseEnter += (s, e) => btnBuscar.BackColor = Color.FromArgb(0, 98, 204);
            btnBuscar.MouseLeave += (s, e) => btnBuscar.BackColor = Color.FromArgb(9, 132, 227);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarKardex();
                e.SuppressKeyPress = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarKardex();
        }

        private void CargarKardex()
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT
                        mi.IdMovimiento,
                        mi.FechaMovimiento,
                        p.Codigo,
                        p.Descripcion,
                        mi.TipoMovimiento,
                        mi.Cantidad,
                        mi.CostoUnitario,
                        mi.PrecioUnitario,
                        mi.Referencia,
                        mi.Observacion,
                        b.Nombre AS Bodega
                    FROM MovimientosInventario mi
                    INNER JOIN Productos p ON mi.IdProducto = p.IdProducto
                    INNER JOIN Bodegas b ON mi.IdBodega = b.IdBodega
                    WHERE mi.IdBodega = @IdBodega
                      AND mi.FechaMovimiento >= @Desde
                      AND mi.FechaMovimiento < @Hasta
                      AND (
                            p.Codigo LIKE @Buscar
                            OR p.Descripcion LIKE @Buscar
                            OR mi.TipoMovimiento LIKE @Buscar
                            OR ISNULL(mi.Referencia,'') LIKE @Buscar
                            OR ISNULL(mi.Observacion,'') LIKE @Buscar
                          )
                    ORDER BY mi.FechaMovimiento DESC, mi.IdMovimiento DESC";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdBodega", ConfiguracionSistema.IdBodegaStockGeneral);
                cmd.Parameters.AddWithValue("@Desde", dtDesde.Value.Date);
                cmd.Parameters.AddWithValue("@Hasta", dtHasta.Value.Date.AddDays(1));
                cmd.Parameters.AddWithValue("@Buscar", "%" + txtBuscar.Text.Trim() + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvKardex.DataSource = dt;

                if (dgvKardex.Columns.Contains("IdMovimiento"))
                    dgvKardex.Columns["IdMovimiento"].Visible = false;

                if (dgvKardex.Columns.Contains("FechaMovimiento"))
                    dgvKardex.Columns["FechaMovimiento"].HeaderText = "Fecha";

                if (dgvKardex.Columns.Contains("Codigo"))
                    dgvKardex.Columns["Codigo"].HeaderText = "Código";

                if (dgvKardex.Columns.Contains("Descripcion"))
                    dgvKardex.Columns["Descripcion"].HeaderText = "Producto";

                if (dgvKardex.Columns.Contains("TipoMovimiento"))
                    dgvKardex.Columns["TipoMovimiento"].HeaderText = "Movimiento";

                if (dgvKardex.Columns.Contains("Cantidad"))
                    dgvKardex.Columns["Cantidad"].HeaderText = "Cantidad";

                if (dgvKardex.Columns.Contains("CostoUnitario"))
                    dgvKardex.Columns["CostoUnitario"].HeaderText = "Costo";

                if (dgvKardex.Columns.Contains("PrecioUnitario"))
                    dgvKardex.Columns["PrecioUnitario"].HeaderText = "Precio";

                if (dgvKardex.Columns.Contains("Referencia"))
                    dgvKardex.Columns["Referencia"].HeaderText = "Referencia";

                if (dgvKardex.Columns.Contains("Observacion"))
                    dgvKardex.Columns["Observacion"].HeaderText = "Observación";

                if (dgvKardex.Columns.Contains("Bodega"))
                    dgvKardex.Columns["Bodega"].HeaderText = "Stock";

                if (dgvKardex.Columns.Contains("Cantidad"))
                    dgvKardex.Columns["Cantidad"].DefaultCellStyle.Format = "0.00";

                if (dgvKardex.Columns.Contains("CostoUnitario"))
                    dgvKardex.Columns["CostoUnitario"].DefaultCellStyle.Format = "0.00000";

                if (dgvKardex.Columns.Contains("PrecioUnitario"))
                    dgvKardex.Columns["PrecioUnitario"].DefaultCellStyle.Format = "0.00000";

                lblTotalMovimientos.Text = dt.Rows.Count.ToString();
            }
        }
    }
}