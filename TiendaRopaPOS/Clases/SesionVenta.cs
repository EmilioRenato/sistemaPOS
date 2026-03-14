namespace TiendaRopaPOS.Clases
{
    public static class SesionVenta
    {
        public static int IdVendedor { get; set; }
        public static string NombreVendedor { get; set; }
        public static string CodigoVendedor { get; set; }

        public static void Limpiar()
        {
            IdVendedor = 0;
            NombreVendedor = string.Empty;
            CodigoVendedor = string.Empty;
        }
    }
}