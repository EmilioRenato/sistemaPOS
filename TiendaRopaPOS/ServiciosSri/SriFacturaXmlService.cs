using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace TiendaRopaPOS.ServiciosSri
{
    public class SriFacturaXmlService
    {
        public string GenerarXmlFactura(SriFacturaDto factura)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8,
                OmitXmlDeclaration = false
            };

            using (StringWriter sw = new StringWriterUtf8())
            using (XmlWriter xw = XmlWriter.Create(sw, settings))
            {
                xw.WriteStartDocument();

                xw.WriteStartElement("factura");
                xw.WriteAttributeString("id", "comprobante");
                xw.WriteAttributeString("version", "1.1.0");

                xw.WriteStartElement("infoTributaria");
                Elem(xw, "ambiente", factura.AmbienteCodigo);
                Elem(xw, "tipoEmision", factura.TipoEmision);
                Elem(xw, "razonSocial", Limpiar(factura.RazonSocial));
                Elem(xw, "nombreComercial", Limpiar(factura.NombreComercial));
                Elem(xw, "ruc", Limpiar(factura.Ruc));
                Elem(xw, "claveAcceso", Limpiar(factura.ClaveAcceso));
                Elem(xw, "codDoc", Limpiar(factura.CodDoc));
                Elem(xw, "estab", Limpiar(factura.Establecimiento));
                Elem(xw, "ptoEmi", Limpiar(factura.PuntoEmision));
                Elem(xw, "secuencial", Limpiar(factura.Secuencial));
                Elem(xw, "dirMatriz", Limpiar(factura.DirMatriz));
                xw.WriteEndElement();

                xw.WriteStartElement("infoFactura");
                Elem(xw, "fechaEmision", factura.FechaEmision.ToString("dd/MM/yyyy"));
                Elem(xw, "dirEstablecimiento", Limpiar(factura.DirEstablecimiento));

                if (!string.IsNullOrWhiteSpace(factura.ContribuyenteEspecial) &&
                    factura.ContribuyenteEspecial.Trim().ToUpper() != "NO")
                {
                    Elem(xw, "contribuyenteEspecial", Limpiar(factura.ContribuyenteEspecial));
                }

                Elem(xw, "obligadoContabilidad", Limpiar(factura.ObligadoContabilidad));
                Elem(xw, "tipoIdentificacionComprador", Limpiar(factura.TipoIdentificacionComprador));
                Elem(xw, "razonSocialComprador", Limpiar(factura.RazonSocialComprador));
                Elem(xw, "identificacionComprador", Limpiar(factura.IdentificacionComprador));
                Elem(xw, "direccionComprador", Limpiar(factura.DireccionComprador));
                Elem(xw, "totalSinImpuestos", F(factura.TotalSinImpuestos));
                Elem(xw, "totalDescuento", F(factura.TotalDescuento));

                xw.WriteStartElement("totalConImpuestos");
                foreach (var imp in factura.TotalConImpuestos)
                {
                    xw.WriteStartElement("totalImpuesto");
                    Elem(xw, "codigo", Limpiar(imp.Codigo));
                    Elem(xw, "codigoPorcentaje", Limpiar(imp.CodigoPorcentaje));
                    Elem(xw, "baseImponible", F(imp.BaseImponible));
                    Elem(xw, "valor", F(imp.Valor));
                    xw.WriteEndElement();
                }
                xw.WriteEndElement();

                Elem(xw, "propina", F(factura.Propina));
                Elem(xw, "importeTotal", F(factura.ImporteTotal));
                Elem(xw, "moneda", Limpiar(factura.Moneda));

                xw.WriteStartElement("pagos");
                foreach (var pago in factura.Pagos)
                {
                    xw.WriteStartElement("pago");
                    Elem(xw, "formaPago", Limpiar(pago.FormaPago));
                    Elem(xw, "total", F(pago.Total));
                    Elem(xw, "plazo", pago.Plazo.ToString());
                    Elem(xw, "unidadTiempo", Limpiar(pago.UnidadTiempo));
                    xw.WriteEndElement();
                }
                xw.WriteEndElement();

                xw.WriteEndElement();

                xw.WriteStartElement("detalles");
                foreach (var det in factura.Detalles)
                {
                    xw.WriteStartElement("detalle");
                    Elem(xw, "codigoPrincipal", Limpiar(det.CodigoPrincipal));
                    Elem(xw, "descripcion", Limpiar(det.Descripcion));
                    Elem(xw, "cantidad", F(det.Cantidad, 2));
                    Elem(xw, "precioUnitario", F(det.PrecioUnitario, 6));
                    Elem(xw, "descuento", F(det.Descuento));
                    Elem(xw, "precioTotalSinImpuesto", F(det.PrecioTotalSinImpuesto));

                    xw.WriteStartElement("impuestos");
                    foreach (var imp in det.Impuestos)
                    {
                        xw.WriteStartElement("impuesto");
                        Elem(xw, "codigo", Limpiar(imp.Codigo));
                        Elem(xw, "codigoPorcentaje", Limpiar(imp.CodigoPorcentaje));
                        Elem(xw, "tarifa", F(imp.Tarifa));
                        Elem(xw, "baseImponible", F(imp.BaseImponible));
                        Elem(xw, "valor", F(imp.Valor));
                        xw.WriteEndElement();
                    }
                    xw.WriteEndElement();

                    xw.WriteEndElement();
                }
                xw.WriteEndElement();

                xw.WriteEndElement();
                xw.WriteEndDocument();
                xw.Flush();

                return sw.ToString();
            }
        }

        private void Elem(XmlWriter xw, string nombre, string valor)
        {
            xw.WriteElementString(nombre, valor ?? "");
        }

        private string F(decimal valor, int decimales = 2)
        {
            string formato = decimales == 6 ? "0.000000" : "0.00";
            return valor.ToString(formato, CultureInfo.InvariantCulture);
        }

        private string Limpiar(string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? "" : texto.Trim();
        }

        private class StringWriterUtf8 : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}