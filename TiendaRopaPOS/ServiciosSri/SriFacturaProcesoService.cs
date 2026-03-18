using System;
using System.IO;
using System.Text;
using TiendaRopaPOS.ServiciosSri;

namespace TiendaRopaPOS.Sri
{
    public class SriFacturaProcesoService
    {
        private readonly SriFacturaDataService _facturaDataService;
        private readonly SriFacturaXmlService _facturaXmlService;
        private readonly SriSecuencialService _secuencialService;
        private readonly SriClaveAccesoService _claveAccesoService;
        private readonly SriEmisorService _emisorService;
        private readonly FirmadorSri _firmadorSri;
        private readonly SriFacturaRepository _facturaRepository;

        public SriFacturaProcesoService()
        {
            _facturaDataService = new SriFacturaDataService();
            _facturaXmlService = new SriFacturaXmlService();
            _secuencialService = new SriSecuencialService();
            _claveAccesoService = new SriClaveAccesoService();
            _emisorService = new SriEmisorService();
            _firmadorSri = new FirmadorSri();
            _facturaRepository = new SriFacturaRepository();
        }

        public SriFacturaProcesoResultado ProcesarFactura(int idVenta, int idCajaEmision)
        {
            string carpetaBase = @"C:\FACTURAS";
            string carpetaXml = Path.Combine(carpetaBase, "XML");
            string carpetaFirmados = Path.Combine(carpetaBase, "FIRMADOS");

            Directory.CreateDirectory(carpetaBase);
            Directory.CreateDirectory(carpetaXml);
            Directory.CreateDirectory(carpetaFirmados);

            var emisor = _emisorService.ObtenerEmisorPorCaja(idCajaEmision);

            string secuencial = _secuencialService.ObtenerSiguienteSecuencial(
                idCajaEmision,
                SriTiposDocumento.Factura
            );

            string ambienteCodigo = _emisorService.ObtenerCodigoAmbienteSri(emisor.Ambiente);
            string codigoNumerico = _claveAccesoService.GenerarCodigoNumerico8();

            string claveAcceso = _claveAccesoService.GenerarClaveAcceso(
                DateTime.Today,
                SriTiposDocumento.Factura,
                emisor.Ruc,
                ambienteCodigo,
                emisor.Establecimiento,
                emisor.PuntoEmision,
                secuencial,
                codigoNumerico,
                "1"
            );

            var factura = _facturaDataService.ObtenerFacturaParaSri(idVenta);

            factura.ClaveAcceso = claveAcceso;
            factura.Secuencial = secuencial;
            factura.Establecimiento = (emisor.Establecimiento ?? "").PadLeft(3, '0');
            factura.PuntoEmision = (emisor.PuntoEmision ?? "").PadLeft(3, '0');
            factura.Ruc = emisor.Ruc;
            factura.RazonSocial = emisor.NombreComercial;
            factura.NombreComercial = emisor.NombreComercial;
            factura.DirMatriz = ((emisor.Direccion1 ?? "") + " " + (emisor.Direccion2 ?? "")).Trim();
            factura.DirEstablecimiento = factura.DirMatriz;
            factura.ContribuyenteEspecial = emisor.ContribuyenteEspecial;
            factura.ObligadoContabilidad = string.IsNullOrWhiteSpace(emisor.LlevaContabilidad)
                ? "NO"
                : emisor.LlevaContabilidad.ToUpper();
            factura.AmbienteCodigo = ambienteCodigo;

            string xml = _facturaXmlService.GenerarXmlFactura(factura);

            string nombreArchivo = $"FACT_{factura.Establecimiento}{factura.PuntoEmision}_{secuencial}";
            string rutaXml = Path.Combine(carpetaXml, nombreArchivo + ".xml");
            string rutaXmlFirmado = Path.Combine(carpetaFirmados, nombreArchivo + "_firmado.xml");

            File.WriteAllText(rutaXml, xml, Encoding.UTF8);

            rutaXmlFirmado = _firmadorSri.FirmarXml(
                rutaXml,
                rutaXmlFirmado,
                emisor.FirmaElectronica,
                emisor.PasswordFirma
            );

            _facturaRepository.GuardarProcesoInicial(
                idVenta,
                claveAcceso,
                secuencial,
                rutaXml,
                rutaXmlFirmado
            );

            return new SriFacturaProcesoResultado
            {
                IdVenta = idVenta,
                IdCajaEmision = idCajaEmision,
                Secuencial = secuencial,
                ClaveAcceso = claveAcceso,
                RutaXml = rutaXml,
                RutaXmlFirmado = rutaXmlFirmado,
                Exitoso = true,
                Mensaje = "Factura procesada y firmada correctamente."
            };
        }
    }

    public class SriFacturaProcesoResultado
    {
        public int IdVenta { get; set; }
        public int IdCajaEmision { get; set; }
        public string Secuencial { get; set; }
        public string ClaveAcceso { get; set; }
        public string RutaXml { get; set; }
        public string RutaXmlFirmado { get; set; }
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}