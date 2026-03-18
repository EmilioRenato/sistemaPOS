using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace TiendaRopaPOS.Sri
{
    public class SriRecepcionService
    {
        private const string UrlRecepcionPruebas =
            "https://celcer.sri.gob.ec/comprobantes-electronicos-ws/RecepcionComprobantesOffline";

        public SriRecepcionResultado EnviarComprobante(string rutaXmlFirmado)
        {
            if (!File.Exists(rutaXmlFirmado))
                throw new Exception("No existe el XML firmado.");

            byte[] xmlBytes = File.ReadAllBytes(rutaXmlFirmado);
            string xmlBase64 = Convert.ToBase64String(xmlBytes);

            string soap = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ec=""http://ec.gob.sri.ws.recepcion"">
  <soapenv:Header/>
  <soapenv:Body>
    <ec:validarComprobante>
      <xml>{xmlBase64}</xml>
    </ec:validarComprobante>
  </soapenv:Body>
</soapenv:Envelope>";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UrlRecepcionPruebas);
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8";
            request.Accept = "text/xml";
            request.Timeout = 60000;
            request.Headers.Add("SOAPAction", "\"\"");

            byte[] data = Encoding.UTF8.GetBytes(soap);
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string xmlRespuesta = reader.ReadToEnd();
                    return ParsearRespuestaRecepcion(xmlRespuesta);
                }
            }
            catch (WebException ex)
            {
                string errorXml = "";

                if (ex.Response != null)
                {
                    using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        errorXml = reader.ReadToEnd();
                    }
                }

                return new SriRecepcionResultado
                {
                    Estado = "ERROR_HTTP",
                    Mensaje = ex.Message,
                    InformacionAdicional = errorXml,
                    XmlRespuesta = errorXml
                };
            }
        }

        private SriRecepcionResultado ParsearRespuestaRecepcion(string xmlRespuesta)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlRespuesta);

            return new SriRecepcionResultado
            {
                Estado = ObtenerValorNodo(doc, "estado"),
                Mensaje = ObtenerValorNodo(doc, "mensaje"),
                Identificador = ObtenerValorNodo(doc, "identificador"),
                InformacionAdicional = ObtenerValorNodo(doc, "informacionAdicional"),
                XmlRespuesta = xmlRespuesta
            };
        }

        private string ObtenerValorNodo(XmlDocument doc, string nombreNodo)
        {
            XmlNodeList nodos = doc.GetElementsByTagName(nombreNodo);
            if (nodos.Count > 0 && nodos[0] != null)
                return nodos[0].InnerText;

            return "";
        }
    }

    public class SriRecepcionResultado
    {
        public string Estado { get; set; }
        public string Mensaje { get; set; }
        public string Identificador { get; set; }
        public string InformacionAdicional { get; set; }
        public string XmlRespuesta { get; set; }
    }
}