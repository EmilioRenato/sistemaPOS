using System;
using System.Collections.Generic;

namespace TiendaRopaPOS.ServiciosSri
{
    public class SriFacturaDto
    {
        public int IdVenta { get; set; }

        public string AmbienteCodigo { get; set; }          // 1 pruebas, 2 producción
        public string TipoEmision { get; set; } = "1";
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string Ruc { get; set; }
        public string ClaveAcceso { get; set; }
        public string CodDoc { get; set; } = "01";
        public string Establecimiento { get; set; }
        public string PuntoEmision { get; set; }
        public string Secuencial { get; set; }
        public string DirMatriz { get; set; }
        public string DirEstablecimiento { get; set; }
        public string ContribuyenteEspecial { get; set; }
        public string ObligadoContabilidad { get; set; }

        public DateTime FechaEmision { get; set; }

        public string TipoIdentificacionComprador { get; set; }
        public string RazonSocialComprador { get; set; }
        public string IdentificacionComprador { get; set; }
        public string DireccionComprador { get; set; }

        public decimal TotalSinImpuestos { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal Propina { get; set; } = 0m;
        public decimal ImporteTotal { get; set; }
        public string Moneda { get; set; } = "DOLAR";

        public List<SriFacturaImpuestoTotalDto> TotalConImpuestos { get; set; } = new List<SriFacturaImpuestoTotalDto>();
        public List<SriFacturaDetalleDto> Detalles { get; set; } = new List<SriFacturaDetalleDto>();
        public List<SriPagoDto> Pagos { get; set; } = new List<SriPagoDto>();
    }

    public class SriFacturaImpuestoTotalDto
    {
        public string Codigo { get; set; }          // IVA = 2
        public string CodigoPorcentaje { get; set; } // 0, 2, 4...
        public decimal BaseImponible { get; set; }
        public decimal Valor { get; set; }
    }

    public class SriFacturaDetalleDto
    {
        public string CodigoPrincipal { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal PrecioTotalSinImpuesto { get; set; }
        public List<SriFacturaImpuestoDetalleDto> Impuestos { get; set; } = new List<SriFacturaImpuestoDetalleDto>();
    }

    public class SriFacturaImpuestoDetalleDto
    {
        public string Codigo { get; set; }
        public string CodigoPorcentaje { get; set; }
        public decimal Tarifa { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal Valor { get; set; }
    }

    public class SriPagoDto
    {
        public string FormaPago { get; set; }
        public decimal Total { get; set; }
        public int Plazo { get; set; }
        public string UnidadTiempo { get; set; }
    }
}