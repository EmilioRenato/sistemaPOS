using System;
using System.Data;
using System.Data.SqlClient;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.ServiciosSri
{
    public class SriFacturaDataService
    {
        public SriFacturaDto ObtenerFacturaParaSri(int idVenta)
        {
            SriFacturaDto factura = new SriFacturaDto();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                factura = CargarCabecera(cn, idVenta);
                CargarDetalles(cn, factura);
            }

            return factura;
        }

        private SriFacturaDto CargarCabecera(SqlConnection cn, int idVenta)
        {
            string query = @"
                SELECT TOP 1
                    v.IdVenta,
                    v.FechaDocumento,
                    v.Subtotal,
                    v.Descuento,
                    v.Iva,
                    v.Total,
                    v.ClaveAcceso,
                    v.NumeroDocumento,

                    c.Nombres AS Cliente,
                    ISNULL(c.Documento, '') AS DocumentoCliente,
                    ISNULL(c.Direccion, '') AS DireccionCliente,

                    mp.CodigoSRI,
                    mp.NombreMetodo,

                    b.RUC,
                    b.Nombre,
                    b.NombreComercial,
                    b.Establecimiento,
                    b.PuntoEmision,
                    b.Direccion1,
                    b.Direccion2,
                    b.ContribuyenteEspecial,
                    b.LlevaContabilidad,
                    b.Ambiente

                FROM Ventas v
                INNER JOIN Clientes c ON v.IdCliente = c.IdCliente
                INNER JOIN MetodosPago mp ON v.IdMetodoPago = mp.IdMetodoPago
                INNER JOIN Bodegas b ON v.IdCajaEmision = b.IdBodega
                WHERE v.IdVenta = @IdVenta";

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@IdVenta", idVenta);

            SqlDataReader dr = cmd.ExecuteReader();

            if (!dr.Read())
                throw new Exception("No se encontró la venta para facturación SRI.");

            SriFacturaDto dto = new SriFacturaDto();

            dto.IdVenta = Convert.ToInt32(dr["IdVenta"]);
            dto.FechaEmision = Convert.ToDateTime(dr["FechaDocumento"]);
            dto.ClaveAcceso = dr["ClaveAcceso"]?.ToString() ?? "";

            string numeroDocumento = dr["NumeroDocumento"]?.ToString() ?? "";
            string secuencial = numeroDocumento;

            if (numeroDocumento.Contains("-"))
            {
                string[] partes = numeroDocumento.Split('-');
                secuencial = partes[partes.Length - 1];
            }

            dto.Secuencial = secuencial.PadLeft(9, '0');

            dto.RazonSocial = dr["Nombre"]?.ToString() ?? "";
            dto.NombreComercial = dr["NombreComercial"]?.ToString() ?? "";
            dto.Ruc = dr["RUC"]?.ToString() ?? "";
            dto.Establecimiento = (dr["Establecimiento"]?.ToString() ?? "").PadLeft(3, '0');
            dto.PuntoEmision = (dr["PuntoEmision"]?.ToString() ?? "").PadLeft(3, '0');
            dto.DirMatriz = ((dr["Direccion1"]?.ToString() ?? "") + " " + (dr["Direccion2"]?.ToString() ?? "")).Trim();
            dto.DirEstablecimiento = dto.DirMatriz;
            dto.ContribuyenteEspecial = dr["ContribuyenteEspecial"]?.ToString() ?? "";
            dto.ObligadoContabilidad = (dr["LlevaContabilidad"]?.ToString() ?? "NO").ToUpper();

            string ambiente = (dr["Ambiente"]?.ToString() ?? "PRUEBAS").ToUpper();
            dto.AmbienteCodigo = ambiente == "PRODUCCION" ? "2" : "1";

            dto.RazonSocialComprador = dr["Cliente"]?.ToString() ?? "";
            dto.IdentificacionComprador = dr["DocumentoCliente"]?.ToString() ?? "";
            dto.DireccionComprador = dr["DireccionCliente"]?.ToString() ?? "";

            dto.TipoIdentificacionComprador = ObtenerTipoIdentificacion(dto.IdentificacionComprador);

            dto.TotalSinImpuestos = Convert.ToDecimal(dr["Subtotal"]);
            dto.TotalDescuento = Convert.ToDecimal(dr["Descuento"]);
            dto.ImporteTotal = Convert.ToDecimal(dr["Total"]);

            decimal iva = Convert.ToDecimal(dr["Iva"]);
            if (iva > 0)
            {
                dto.TotalConImpuestos.Add(new SriFacturaImpuestoTotalDto
                {
                    Codigo = "2",
                    CodigoPorcentaje = "2", // IVA 12%
                    BaseImponible = dto.TotalSinImpuestos,
                    Valor = iva
                });
            }
            else
            {
                dto.TotalConImpuestos.Add(new SriFacturaImpuestoTotalDto
                {
                    Codigo = "2",
                    CodigoPorcentaje = "0", // IVA 0%
                    BaseImponible = dto.TotalSinImpuestos,
                    Valor = 0m
                });
            }

            dto.Pagos.Add(new SriPagoDto
            {
                FormaPago = dr["CodigoSRI"]?.ToString() ?? "01",
                Total = dto.ImporteTotal,
                Plazo = 0,
                UnidadTiempo = "dias"
            });

            dr.Close();
            return dto;
        }

        private void CargarDetalles(SqlConnection cn, SriFacturaDto factura)
        {
            string query = @"
                SELECT
                    p.Codigo,
                    p.Descripcion,
                    dv.Cantidad,
                    dv.PrecioUnitario,
                    dv.Descuento,
                    dv.Subtotal,
                    dv.Iva,
                    dv.TotalLinea
                FROM DetalleVentas dv
                INNER JOIN Productos p ON dv.IdProducto = p.IdProducto
                WHERE dv.IdVenta = @IdVenta
                ORDER BY dv.IdDetalleVenta";

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@IdVenta", factura.IdVenta);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                decimal subtotalLinea = Convert.ToDecimal(dr["Subtotal"]);
                decimal ivaLinea = Convert.ToDecimal(dr["Iva"]);

                SriFacturaDetalleDto det = new SriFacturaDetalleDto
                {
                    CodigoPrincipal = dr["Codigo"]?.ToString() ?? "",
                    Descripcion = dr["Descripcion"]?.ToString() ?? "",
                    Cantidad = Convert.ToDecimal(dr["Cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                    Descuento = Convert.ToDecimal(dr["Descuento"]),
                    PrecioTotalSinImpuesto = subtotalLinea
                };

                det.Impuestos.Add(new SriFacturaImpuestoDetalleDto
                {
                    Codigo = "2",
                    CodigoPorcentaje = ivaLinea > 0 ? "2" : "0",
                    Tarifa = ivaLinea > 0 ? 12m : 0m,
                    BaseImponible = subtotalLinea,
                    Valor = ivaLinea
                });

                factura.Detalles.Add(det);
            }

            dr.Close();
        }

        private string ObtenerTipoIdentificacion(string identificacion)
        {
            identificacion = (identificacion ?? "").Trim();

            if (identificacion.Length == 13)
                return "04"; // RUC

            if (identificacion.Length == 10)
                return "05"; // Cédula

            if (identificacion == "9999999999999" || identificacion == "9999999999")
                return "07"; // consumidor final

            return "06"; // pasaporte / otros
        }
    }
}