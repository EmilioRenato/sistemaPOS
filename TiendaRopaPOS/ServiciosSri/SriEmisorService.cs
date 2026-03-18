using System;
using System.Data.SqlClient;
using TiendaRopaPOS.Datos;

namespace TiendaRopaPOS.ServiciosSri
{
    public class SriEmisorDto
    {
        public int IdBodega { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string NombreComercial { get; set; }
        public string Establecimiento { get; set; }
        public string PuntoEmision { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Ciudad { get; set; }
        public string Email { get; set; }
        public string Ambiente { get; set; }
        public string FirmaElectronica { get; set; }
        public string PasswordFirma { get; set; }
        public string LlevaContabilidad { get; set; }
        public string ContribuyenteEspecial { get; set; }
        public string AgenteRetencion { get; set; }
        public string Rimpe { get; set; }
    }

    public class SriEmisorService
    {
        public SriEmisorDto ObtenerEmisorPorCaja(int idBodega)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                string query = @"
                    SELECT TOP 1
                        IdBodega,
                        Nombre,
                        RUC,
                        NombreComercial,
                        Establecimiento,
                        PuntoEmision,
                        Direccion1,
                        Direccion2,
                        Ciudad,
                        Email,
                        Ambiente,
                        FirmaElectronica,
                        PasswordFirma,
                        LlevaContabilidad,
                        ContribuyenteEspecial,
                        AgenteRetencion,
                        Rimpe
                    FROM Bodegas
                    WHERE IdBodega = @IdBodega
                      AND Estado = 1";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdBodega", idBodega);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                    throw new Exception("No se encontró la caja / punto de emisión.");

                return new SriEmisorDto
                {
                    IdBodega = Convert.ToInt32(dr["IdBodega"]),
                    Nombre = dr["Nombre"]?.ToString() ?? "",
                    Ruc = dr["RUC"]?.ToString() ?? "",
                    NombreComercial = dr["NombreComercial"]?.ToString() ?? "",
                    Establecimiento = dr["Establecimiento"]?.ToString() ?? "",
                    PuntoEmision = dr["PuntoEmision"]?.ToString() ?? "",
                    Direccion1 = dr["Direccion1"]?.ToString() ?? "",
                    Direccion2 = dr["Direccion2"]?.ToString() ?? "",
                    Ciudad = dr["Ciudad"]?.ToString() ?? "",
                    Email = dr["Email"]?.ToString() ?? "",
                    Ambiente = dr["Ambiente"]?.ToString() ?? "PRUEBAS",
                    FirmaElectronica = dr["FirmaElectronica"]?.ToString() ?? "",
                    PasswordFirma = dr["PasswordFirma"]?.ToString() ?? "",
                    LlevaContabilidad = dr["LlevaContabilidad"]?.ToString() ?? "NO",
                    ContribuyenteEspecial = dr["ContribuyenteEspecial"]?.ToString() ?? "NO",
                    AgenteRetencion = dr["AgenteRetencion"]?.ToString() ?? "NO",
                    Rimpe = dr["Rimpe"]?.ToString() ?? "NO"
                };
            }
        }

        public string ObtenerCodigoAmbienteSri(string ambienteTexto)
        {
            string amb = (ambienteTexto ?? "").Trim().ToUpper();
            return amb == "PRODUCCION" ? "2" : "1";
        }
    }
}