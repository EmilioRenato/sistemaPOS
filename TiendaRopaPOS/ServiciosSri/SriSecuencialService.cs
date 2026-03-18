using System;
using System.Data.SqlClient;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.ServiciosSri
{
    public class SriSecuencialService
    {
        public string ObtenerSiguienteSecuencial(int idBodega, string tipoDocumento)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                using (SqlTransaction tx = cn.BeginTransaction())
                {
                    try
                    {
                        string query = @"
                            UPDATE SecuencialesSri
                            SET SecuencialActual = SecuencialActual + 1,
                                FechaActualizacion = GETDATE()
                            OUTPUT INSERTED.SecuencialActual
                            WHERE IdBodega = @IdBodega
                              AND TipoDocumento = @TipoDocumento
                              AND Estado = 1";

                        SqlCommand cmd = new SqlCommand(query, cn, tx);
                        cmd.Parameters.AddWithValue("@IdBodega", idBodega);
                        cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);

                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                            throw new Exception("No existe secuencial configurado para esa caja y tipo de documento.");

                        tx.Commit();

                        int secuencial = Convert.ToInt32(result);
                        return secuencial.ToString("000000000");
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}