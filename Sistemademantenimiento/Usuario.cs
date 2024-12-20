using System;
using System.Data.SqlClient;
using SistemaDeMantenimiento.Data;

namespace SistemaDeMantenimiento.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; } = "usuario";
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        
        public static bool VerificarCredenciales(string correo, string contraseña)
        {
            bool esValido = false;
            string consulta = "SELECT COUNT(*) FROM Usuarios WHERE correo = @correo";

            try
            {
                using (SqlCommand comando = new SqlCommand(consulta))
                {
                    comando.Parameters.AddWithValue("@correo", correo);

                    using (SqlDataReader reader = BaseDatos.EjecutarConsulta(comando))
                    {
                        if (reader.Read())
                        {
                            int count = (int)reader[0];
                            if (count > 0)
                            {
                                
                                consulta = "SELECT COUNT(*) FROM Usuarios WHERE correo = @correo AND contraseña = @contraseña";
                                comando.CommandText = consulta;
                                comando.Parameters.AddWithValue("@contraseña", contraseña);

                                using (SqlDataReader passReader = BaseDatos.EjecutarConsulta(comando))
                                {
                                    if (passReader.Read())
                                    {
                                        esValido = (int)passReader[0] > 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar las credenciales: " + ex.Message);
            }

            return esValido;
        }

        
        public static bool ExisteCorreo(string correo)
        {
            bool existe = false;
            string consulta = "SELECT COUNT(*) FROM Usuarios WHERE correo = @correo";

            try
            {
                using (SqlCommand comando = new SqlCommand(consulta))
                {
                    comando.Parameters.AddWithValue("@correo", correo);
                    using (SqlDataReader reader = BaseDatos.EjecutarConsulta(comando))
                    {
                        if (reader.Read())
                        {
                            existe = (int)reader[0] > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar si el correo existe: " + ex.Message);
            }

            return existe;
        }

        public static void RegistrarUsuario(Usuario nuevoUsuario)
        {
            string consulta = "INSERT INTO Usuarios (nombre, correo, contraseña, rol, fecha_creacion) " +
                              "VALUES (@nombre, @correo, @contraseña, @rol, @fecha_creacion)";

            try
            {
                using (SqlCommand comando = new SqlCommand(consulta))
                {
                    comando.Parameters.AddWithValue("@nombre", nuevoUsuario.Nombre);
                    comando.Parameters.AddWithValue("@correo", nuevoUsuario.Correo);
                    comando.Parameters.AddWithValue("@contraseña", nuevoUsuario.Contraseña);
                    comando.Parameters.AddWithValue("@rol", nuevoUsuario.Rol);
                    comando.Parameters.AddWithValue("@fecha_creacion", nuevoUsuario.FechaCreacion);

                    BaseDatos.EjecutarComando(comando); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar usuario: " + ex.Message);
            }
        }
    }
}
