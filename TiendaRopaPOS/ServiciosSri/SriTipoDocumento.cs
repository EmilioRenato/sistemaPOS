namespace TiendaRopaPOS.ServiciosSri
{
    public static class SriTiposDocumento
    {
        public const string Factura = "FACTURA";
        public const string NotaCredito = "NOTA_CREDITO";
        public const string Retencion = "RETENCION";
        public const string GuiaRemision = "GUIA_REMISION";

        // códigos SRI para clave de acceso / XML
        public static string ObtenerCodigoSri(string tipoDocumento)
        {
            switch (tipoDocumento)
            {
                case Factura:
                    return "01";
                case NotaCredito:
                    return "04";
                case Retencion:
                    return "07";
                case GuiaRemision:
                    return "06";
                default:
                    throw new System.ArgumentException("Tipo de documento no soportado.");
            }
        }
    }
}