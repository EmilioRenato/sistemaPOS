using System.Data.SqlClient;

namespace TiendaRopaPOS.Datos
{
    public class Conexion
    {
        private string cadena = "Server=localhost;Database=TiendaRopaDB_V4(Pruebas);Trusted_Connection=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}