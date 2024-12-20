using System.Data.SqlClient;
using System.Configuration;

namespace SistemaDeMantenimiento.Data
{
    public class BaseDatos
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }

        public static void EjecutarComando(SqlCommand comando)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
            }
        }

        public static SqlDataReader EjecutarConsulta(SqlCommand comando)
        {
            SqlConnection conexion = ObtenerConexion();
            comando.Connection = conexion;
            return comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
    }
}
