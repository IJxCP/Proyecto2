using System;
using System.Data.SqlClient;
using SistemaDeMantenimiento.Data;

namespace SistemaDeMantenimiento.Models
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public string NombreEquipo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; } = "Operativo";
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int? IdUsuario { get; set; }

        public static void CrearEquipo(Equipo equipo)
        {
            using (SqlCommand comando = new SqlCommand("INSERT INTO Equipos (nombre_equipo, descripcion, estado, id_usuario) VALUES (@nombre_equipo, @descripcion, @estado, @id_usuario)"))
            {
                comando.Parameters.AddWithValue("@nombre_equipo", equipo.NombreEquipo);
                comando.Parameters.AddWithValue("@descripcion", equipo.Descripcion);
                comando.Parameters.AddWithValue("@estado", equipo.Estado);
                comando.Parameters.AddWithValue("@id_usuario", equipo.IdUsuario.HasValue ? (object)equipo.IdUsuario : DBNull.Value);
                BaseDatos.EjecutarComando(comando);
            }
        }

        public static Equipo ObtenerEquipoPorId(int id)
        {
            Equipo equipo = null;
            using (SqlCommand comando = new SqlCommand("SELECT * FROM Equipos WHERE id_equipo = @id"))
            {
                comando.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = BaseDatos.EjecutarConsulta(comando))
                {
                    if (reader.Read())
                    {
                        equipo = new Equipo
                        {
                            IdEquipo = (int)reader["id_equipo"],
                            NombreEquipo = reader["nombre_equipo"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                            Estado = reader["estado"].ToString(),
                            FechaRegistro = (DateTime)reader["fecha_registro"],
                            IdUsuario = reader["id_usuario"] != DBNull.Value ? (int?)reader["id_usuario"] : null
                        };
                    }
                }
            }
            return equipo;
        }

        public static void ActualizarEquipo(Equipo equipo)
        {
            using (SqlCommand comando = new SqlCommand("UPDATE Equipos SET nombre_equipo = @nombre_equipo, descripcion = @descripcion, estado = @estado, id_usuario = @id_usuario WHERE id_equipo = @id"))
            {
                comando.Parameters.AddWithValue("@nombre_equipo", equipo.NombreEquipo);
                comando.Parameters.AddWithValue("@descripcion", equipo.Descripcion);
                comando.Parameters.AddWithValue("@estado", equipo.Estado);
                comando.Parameters.AddWithValue("@id_usuario", equipo.IdUsuario.HasValue ? (object)equipo.IdUsuario : DBNull.Value);
                comando.Parameters.AddWithValue("@id", equipo.IdEquipo);
                BaseDatos.EjecutarComando(comando);
            }
        }

        public static void EliminarEquipo(int id)
        {
            using (SqlCommand comando = new SqlCommand("DELETE FROM Equipos WHERE id_equipo = @id"))
            {
                comando.Parameters.AddWithValue("@id", id);
                BaseDatos.EjecutarComando(comando);
            }
        }
    }
}
