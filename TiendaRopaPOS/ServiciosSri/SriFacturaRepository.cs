using System;
using System.Data.SqlClient;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.Sri
{
    public class SriFacturaRepository
    {
        public void GuardarProcesoInicial(
            int idVenta,
            string claveAcceso,
            string secuencial,
            string rutaXml,
            string rutaXmlFirmado)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string existeQuery = @"
                    SELECT COUNT(*)
                    FROM FacturasElectronicas
                    WHERE IdVenta = @IdVenta";

                SqlCommand cmdExiste = new SqlCommand(existeQuery, cn);
                cmdExiste.Parameters.AddWithValue("@IdVenta", idVenta);

                int existe = Convert.ToInt32(cmdExiste.ExecuteScalar());

                string query;

                if (existe > 0)
                {
                    query = @"
                        UPDATE FacturasElectronicas
                        SET ClaveAcceso = @ClaveAcceso,
                            Secuencial = @Secuencial,
                            RutaXml = @RutaXml,
                            RutaXmlFirmado = @RutaXmlFirmado,
                            EstadoSRI = 'FIRMADO',
                            MensajeSRI = 'XML generado y firmado correctamente'
                        WHERE IdVenta = @IdVenta";
                }
                else
                {
                    query = @"
                        INSERT INTO FacturasElectronicas
                        (
                            IdVenta,
                            ClaveAcceso,
                            Secuencial,
                            RutaXml,
                            RutaXmlFirmado,
                            EstadoSRI,
                            MensajeSRI,
                            FechaCreacion
                        )
                        VALUES
                        (
                            @IdVenta,
                            @ClaveAcceso,
                            @Secuencial,
                            @RutaXml,
                            @RutaXmlFirmado,
                            'FIRMADO',
                            'XML generado y firmado correctamente',
                            GETDATE()
                        )";
                }

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                cmd.Parameters.AddWithValue("@ClaveAcceso", claveAcceso);
                cmd.Parameters.AddWithValue("@Secuencial", secuencial);
                cmd.Parameters.AddWithValue("@RutaXml", rutaXml);
                cmd.Parameters.AddWithValue("@RutaXmlFirmado", rutaXmlFirmado);

                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarEstadoRecepcion(
            int idVenta,
            string estadoSri,
            string mensajeSri,
            string infoSri)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"
                    UPDATE FacturasElectronicas
                    SET EstadoSRI = @EstadoSRI,
                        MensajeSRI = @MensajeSRI
                    WHERE IdVenta = @IdVenta";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                cmd.Parameters.AddWithValue("@EstadoSRI", (estadoSri ?? "") + " " + (infoSri ?? ""));
                cmd.Parameters.AddWithValue("@MensajeSRI", mensajeSri ?? "");

                cmd.ExecuteNonQuery();
            }
        }

        public string ObtenerClaveAccesoPorVenta(int idVenta)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"
            SELECT TOP 1 ClaveAcceso
            FROM FacturasElectronicas
            WHERE IdVenta = @IdVenta";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);

                object result = cmd.ExecuteScalar();

                return result == null || result == DBNull.Value
                    ? ""
                    : result.ToString();
            }
        }

        public void ActualizarEstadoAutorizacion(
            int idVenta,
            string estadoSri,
            string numeroAutorizacion,
            string fechaAutorizacionTexto,
            string mensajeSri,
            string infoSri,
            string xmlAutorizado)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"
                    UPDATE FacturasElectronicas
                    SET EstadoSRI = @EstadoSRI,
                        NumeroAutorizacion = @NumeroAutorizacion,
                        FechaAutorizacion = @FechaAutorizacion,
                        MensajeSRI = @MensajeSRI,
                        RutaXmlAutorizado = @RutaXmlAutorizado
                    WHERE IdVenta = @IdVenta";

                DateTime fechaAutorizacion;
                object fechaObj = DBNull.Value;

                if (DateTime.TryParse(fechaAutorizacionTexto, out fechaAutorizacion))
                    fechaObj = fechaAutorizacion;

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                cmd.Parameters.AddWithValue("@EstadoSRI",estadoSri ?? "");
                cmd.Parameters.AddWithValue("@NumeroAutorizacion", string.IsNullOrWhiteSpace(numeroAutorizacion) ? (object)DBNull.Value : numeroAutorizacion);
                cmd.Parameters.AddWithValue("@FechaAutorizacion", fechaObj);
                cmd.Parameters.AddWithValue("@MensajeSRI",(mensajeSri ?? "") + " " + (infoSri ?? ""));
                cmd.Parameters.AddWithValue("@RutaXmlAutorizado", string.IsNullOrWhiteSpace(xmlAutorizado) ? (object)DBNull.Value : xmlAutorizado);

                cmd.ExecuteNonQuery();
            }
        }
    }
}