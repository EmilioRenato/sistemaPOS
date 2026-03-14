namespace TiendaRopaPOS.Clases
{
    public static class SesionUsuario
    {
        public static int IdUsuario { get; set; }
        public static int IdRol { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static string Usuario { get; set; }

        public static int IdCajaEmision { get; set; }
        public static string NombreCajaEmision { get; set; }

        public static void CerrarSesion()
        {
            IdUsuario = 0;
            IdRol = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Usuario = string.Empty;

            IdCajaEmision = 0;
            NombreCajaEmision = string.Empty;
        }
    }
}