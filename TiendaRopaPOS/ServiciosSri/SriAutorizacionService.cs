using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace TiendaRopaPOS.Sri
{
    public class SriAutorizacionService
    {
        private const string UrlAutorizacionPruebas =
            "https://celcer.sri.gob.ec/comprobantes-electronicos-ws/AutorizacionComprobantesOffline";

        public SriAutorizacionResultado ConsultarAutorizacion(string claveAcceso)
        {
            string soap = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ec=""http://ec.gob.sri.ws.autorizacion"">
  <soapenv:Header/>
  <soapenv:Body>
    <ec:autorizacionComprobante>
      <claveAccesoComprobante>{claveAcceso}</claveAccesoComprobante>
    </ec:autorizacionComprobante>
  </soapenv:Body>
</soapenv:Envelope>";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UrlAutorizacionPruebas);
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
                    return ParsearRespuesta(xmlRespuesta);
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

                return new SriAutorizacionResultado
                {
                    Estado = "ERROR_HTTP",
                    Mensaje = ex.Message,
                    XmlRespuesta = errorXml
                };
            }
        }

        private SriAutorizacionResultado ParsearRespuesta(string xmlRespuesta)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlRespuesta);

            SriAutorizacionResultado resultado = new SriAutorizacionResultado
            {
                XmlRespuesta = xmlRespuesta
            };

            string numeroComprobantes = ObtenerValorNodo(doc, "numeroComprobantes");

            if (numeroComprobantes == "0")
            {
                resultado.Estado = "EN PROCESO";
                resultado.NumeroAutorizacion = "";
                resultado.FechaAutorizacionTexto = "";
                resultado.Mensaje = "El SRI aún no registra autorización para esta clave.";
                resultado.InformacionAdicional = "numeroComprobantes = 0";
                return resultado;
            }

            XmlNodeList autorizaciones = doc.GetElementsByTagName("autorizacion");

            if (autorizaciones.Count > 0)
            {
                XmlNode nodo = autorizaciones[0];

                resultado.Estado = ObtenerValorNodoDesde(nodo, "estado");
                resultado.NumeroAutorizacion = ObtenerValorNodoDesde(nodo, "numeroAutorizacion");
                resultado.FechaAutorizacionTexto = ObtenerValorNodoDesde(nodo, "fechaAutorizacion");
                resultado.Ambiente = ObtenerValorNodoDesde(nodo, "ambiente");
                resultado.Comprobante = ObtenerValorNodoDesde(nodo, "comprobante");

                XmlNodeList mensajes = ((XmlElement)nodo).GetElementsByTagName("mensaje");
                if (mensajes.Count > 0)
                    resultado.Mensaje = mensajes[0].InnerText;

                XmlNodeList info = ((XmlElement)nodo).GetElementsByTagName("informacionAdicional");
                if (info.Count > 0)
                    resultado.InformacionAdicional = info[0].InnerText;
            }
            else
            {
                resultado.Estado = "EN PROCESO";
                resultado.Mensaje = "No existen autorizaciones todavía para esta clave.";
            }

            if (string.IsNullOrWhiteSpace(resultado.Estado))
                resultado.Estado = "EN PROCESO";

            return resultado;
        }

        private string ObtenerValorNodo(XmlDocument doc, string nombreNodo)
        {
            XmlNodeList nodos = doc.GetElementsByTagName(nombreNodo);
            if (nodos.Count > 0 && nodos[0] != null)
                return nodos[0].InnerText;

            return "";
        }

        private string ObtenerValorNodoDesde(XmlNode nodoPadre, string nombreNodo)
        {
            if (nodoPadre == null)
                return "";

            XmlNodeList nodos = ((XmlElement)nodoPadre).GetElementsByTagName(nombreNodo);
            if (nodos.Count > 0 && nodos[0] != null)
                return nodos[0].InnerText;

            return "";
        }
    }

    public class SriAutorizacionResultado
    {
        public string Estado { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string FechaAutorizacionTexto { get; set; }
        public string Ambiente { get; set; }
        public string Comprobante { get; set; }
        public string Mensaje { get; set; }
        public string InformacionAdicional { get; set; }
        public string XmlRespuesta { get; set; }
    }
}