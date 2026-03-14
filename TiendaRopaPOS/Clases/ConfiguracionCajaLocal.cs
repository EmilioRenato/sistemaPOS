using System;
using System.IO;

namespace TiendaRopaPOS.Clases
{
    public static class ConfiguracionCajaLocal
    {
        private static readonly string RutaArchivo = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "config_caja.txt"
        );

        public static void GuardarConfiguracion(int idCajaEmision, string nombreCajaEmision)
        {
            string contenido = idCajaEmision + "|" + nombreCajaEmision;
            File.WriteAllText(RutaArchivo, contenido);
        }

        public static bool ExisteConfiguracion()
        {
            return File.Exists(RutaArchivo);
        }

        public static bool CargarConfiguracion()
        {
            try
            {
                if (!File.Exists(RutaArchivo))
                    return false;

                string contenido = File.ReadAllText(RutaArchivo).Trim();

                if (string.IsNullOrWhiteSpace(contenido))
                    return false;

                string[] partes = contenido.Split('|');

                if (partes.Length < 2)
                    return false;

                SesionUsuario.IdCajaEmision = Convert.ToInt32(partes[0]);
                SesionUsuario.NombreCajaEmision = partes[1];

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void LimpiarConfiguracion()
        {
            if (File.Exists(RutaArchivo))
                File.Delete(RutaArchivo);

            SesionUsuario.IdCajaEmision = 0;
            SesionUsuario.NombreCajaEmision = string.Empty;
        }
    }
}