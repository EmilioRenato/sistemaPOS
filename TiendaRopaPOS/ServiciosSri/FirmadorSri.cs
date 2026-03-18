using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using FirmaXadesNet;
using FirmaXadesNet.Crypto;
using FirmaXadesNet.Signature.Parameters;

namespace TiendaRopaPOS.Sri
{
    public class FirmadorSri
    {
        public string FirmarXml(
            string rutaXml,
            string rutaXmlFirmado,
            string rutaP12,
            string password)
        {
            if (!File.Exists(rutaXml))
                throw new Exception("No existe el XML a firmar.");

            if (!File.Exists(rutaP12))
                throw new Exception("No existe el archivo .p12.");

            X509Certificate2 certificado = new X509Certificate2(
                rutaP12,
                password,
                X509KeyStorageFlags.Exportable |
                X509KeyStorageFlags.MachineKeySet |
                X509KeyStorageFlags.PersistKeySet
            );

            XadesService xadesService = new XadesService();
            SignatureParameters parametros = new SignatureParameters();

            parametros.SignatureMethod = SignatureMethod.RSAwithSHA1;
            parametros.DigestMethod = DigestMethod.SHA1;
            parametros.SigningDate = DateTime.Now;
            parametros.SignaturePackaging = SignaturePackaging.ENVELOPED;

            using (parametros.Signer = new Signer(certificado))
            using (FileStream fs = new FileStream(rutaXml, FileMode.Open, FileAccess.Read))
            {
                var documentoFirmado = xadesService.Sign(fs, parametros);
                documentoFirmado.Save(rutaXmlFirmado);
            }

            return rutaXmlFirmado;
        }
    }
}