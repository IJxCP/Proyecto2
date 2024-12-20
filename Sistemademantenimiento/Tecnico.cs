using System;
using System.Data.SqlClient;
using SistemaDeMantenimiento.Data;

namespace SistemaDeMantenimiento.Models
{
    public class Tecnico
    {
        public int IdTecnico { get; set; }
        public string NombreTecnico { get; set; }
        public string Especialidad { get; set; }
        public int? IdEquipo { get; set; }

        public static void CrearTecnico(Tecnico tecnico)
        {
            using (SqlCommand comando = new SqlCommand("INSERT INTO Tecnicos (nombre_tecnico, especialidad, id_equipo) VALUES (@nombre_tecnico, @especialidad, @id_equipo)"))
            {
                comando.Parameters.AddWithValue("@nombre_tecnico", tecnico.NombreTecnico);
                comando.Parameters.AddWithValue("@especialidad", tecnico.Especialidad);
                comando.Parameters.AddWithValue("@id_equipo", tecnico.IdEquipo.HasValue ? (object)tecnico.IdEquipo : DBNull.Value);
                BaseDatos.EjecutarComando(comando);
            }
        }

        public static Tecnico ObtenerTecnicoPorId(int id)
        {
            Tecnico tecnico = null;
            using (SqlCommand comando = new SqlCommand("SELECT * FROM Tecnicos WHERE id_tecnico = @id"))
            {
                comando.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = BaseDatos.EjecutarConsulta(comando))
                {
                    if (reader.Read())
                    {
                        tecnico = new Tecnico
                        {
                            IdTecnico = (int)reader["id_tecnico"],
                            NombreTecnico = reader["nombre_tecnico"].ToString(),
                            Especialidad = reader["especialidad"].ToString(),
                            IdEquipo = reader["id_equipo"] != DBNull.Value ? (int?)reader["id_equipo"] : null
                        };
                    }
                }
            }
            return tecnico;
        }

        public static void ActualizarTecnico(Tecnico tecnico)
        {
            using (SqlCommand comando = new SqlCommand("UPDATE Tecnicos SET nombre_tecnico = @nombre_tecnico, especialidad = @especialidad, id_equipo = @id_equipo WHERE id_tecnico = @id"))
            {
                comando.Parameters.AddWithValue("@nombre_tecnico", tecnico.NombreTecnico);
                comando.Parameters.AddWithValue("@especialidad", tecnico.Especialidad);
                comando.Parameters.AddWithValue("@id_equipo", tecnico.IdEquipo.HasValue ? (object)tecnico.IdEquipo : DBNull.Value);
                comando.Parameters.AddWithValue("@id", tecnico.IdTecnico);
                BaseDatos.EjecutarComando(comando);
            }
        }

        public static void EliminarTecnico(int id)
        {
            using (SqlCommand comando = new SqlCommand("DELETE FROM Tecnicos WHERE id_tecnico = @id"))
            {
                comando.Parameters.AddWithValue("@id", id);
                BaseDatos.EjecutarComando(comando);
            }
        }
    }
}
