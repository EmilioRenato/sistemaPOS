using System;
using System.Data.SqlClient;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.Clases
{
    public static class PermisosService
    {
        public static bool TienePermiso(string codigoPermiso)
        {
            try
            {
                if (SesionUsuario.IdRol <= 0)
                    return false;

                using (SqlConnection cn = new Conexion().ObtenerConexion())
                {
                    string query = @"
                        SELECT COUNT(*)
                        FROM RolesPermisos rp
                        INNER JOIN Permisos p ON rp.IdPermiso = p.IdPermiso
                        WHERE rp.IdRol = @IdRol
                          AND rp.Estado = 1
                          AND p.Estado = 1
                          AND p.CodigoPermiso = @CodigoPermiso";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRol", SesionUsuario.IdRol);
                    cmd.Parameters.AddWithValue("@CodigoPermiso", codigoPermiso.Trim().ToUpper());

                    cn.Open();

                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                    return cantidad > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}