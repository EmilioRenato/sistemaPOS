using System;

namespace TiendaRopaPOS.ServiciosSri
{
    public class SriClaveAccesoService
    {
        public string GenerarClaveAcceso(
            DateTime fechaEmision,
            string tipoDocumento,
            string ruc,
            string ambiente,          // "1" pruebas, "2" producción
            string establecimiento,   // 3 dígitos
            string puntoEmision,      // 3 dígitos
            string secuencial,        // 9 dígitos
            string codigoNumerico,    // 8 dígitos
            string tipoEmision = "1"  // normal
        )
        {
            string fecha = fechaEmision.ToString("ddMMyyyy");
            string codDoc = SriTiposDocumento.ObtenerCodigoSri(tipoDocumento);

            string baseClave =
                fecha +
                codDoc +
                SoloNumeros(ruc, 13) +
                SoloNumeros(ambiente, 1) +
                SoloNumeros(establecimiento, 3) +
                SoloNumeros(puntoEmision, 3) +
                SoloNumeros(secuencial, 9) +
                SoloNumeros(codigoNumerico, 8) +
                SoloNumeros(tipoEmision, 1);

            int dv = CalcularDigitoVerificador(baseClave);
            return baseClave + dv.ToString();
        }

        public int CalcularDigitoVerificador(string clave)
        {
            int factor = 2;
            int suma = 0;

            for (int i = clave.Length - 1; i >= 0; i--)
            {
                suma += (clave[i] - '0') * factor;
                factor++;
                if (factor > 7)
                    factor = 2;
            }

            int mod = suma % 11;
            int digito = 11 - mod;

            if (digito == 11) digito = 0;
            if (digito == 10) digito = 1;

            return digito;
        }

        private string SoloNumeros(string valor, int longitud)
        {
            string limpio = (valor ?? "").Replace(".", "").Replace("-", "").Trim();
            if (limpio.Length > longitud)
                limpio = limpio.Substring(0, longitud);

            return limpio.PadLeft(longitud, '0');
        }

        public string GenerarCodigoNumerico8()
        {
            Random rnd = new Random();
            return rnd.Next(10000000, 99999999).ToString();
        }
    }
}