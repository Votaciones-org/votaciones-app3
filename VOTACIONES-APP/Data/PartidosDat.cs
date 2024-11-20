using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class PartidosDat
    {
        private readonly string _connectionString = "tu_cadena_de_conexion"; // Reemplázala con la cadena de conexión.

        // Método para obtener todos los partidos con sus candidatos
        public DataTable GetPartidosWithCandidatos()
        {
            DataTable dataTable = new DataTable();
            string query = @"
                SELECT 
                    p.partido_id, 
                    p.partido_nombre, 
                    p.partido_descripcion, 
                    c.candidato_id, 
                    c.candidato_nombre, 
                    c.candidato_apellido, 
                    c.candidato_fecha_nacimiento, 
                    c.candidato_propuesta
                FROM 
                    Partidos p
                INNER JOIN 
                    Candidatos c ON p.partido_id = c.partido_id";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    // Log or handle the error as needed
                    throw new Exception("Error al obtener partidos con candidatos: " + ex.Message);
                }
            }

            return dataTable;
        }

        // Método para insertar un nuevo partido
        public int InsertPartido(string partidoName, string partidoDescription, SqlTransaction transaction)
        {
            string query = @"
                INSERT INTO Partidos (partido_nombre, partido_descripcion) 
                VALUES (@partidoName, @partidoDescription); 
                SELECT SCOPE_IDENTITY();"; // Obtiene el ID del nuevo partido

            using (SqlCommand cmd = new SqlCommand(query, transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@partidoName", partidoName);
                cmd.Parameters.AddWithValue("@partidoDescription", partidoDescription);

                try
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el partido: " + ex.Message);
                }
            }
        }

        // Método para insertar un nuevo candidato
        public void InsertCandidato(int partidoId, string candidatoName, string candidatoSurname, DateTime candidatoBirthDate, string candidatoProposal, SqlTransaction transaction)
        {
            string query = @"
                INSERT INTO Candidatos (partido_id, candidato_nombre, candidato_apellido, candidato_fecha_nacimiento, candidato_propuesta) 
                VALUES (@partidoId, @candidatoName, @candidatoSurname, @candidatoBirthDate, @candidatoProposal);";

            using (SqlCommand cmd = new SqlCommand(query, transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@partidoId", partidoId);
                cmd.Parameters.AddWithValue("@candidatoName", candidatoName);
                cmd.Parameters.AddWithValue("@candidatoSurname", candidatoSurname);
                cmd.Parameters.AddWithValue("@candidatoBirthDate", candidatoBirthDate);
                cmd.Parameters.AddWithValue("@candidatoProposal", candidatoProposal);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el candidato: " + ex.Message);
                }
            }
        }

        // Método para actualizar un partido
        public void UpdatePartido(int partidoId, string partidoName, string partidoDescription, SqlTransaction transaction)
        {
            string query = @"
                UPDATE Partidos 
                SET partido_nombre = @partidoName, partido_descripcion = @partidoDescription
                WHERE partido_id = @partidoId;";

            using (SqlCommand cmd = new SqlCommand(query, transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@partidoName", partidoName);
                cmd.Parameters.AddWithValue("@partidoDescription", partidoDescription);
                cmd.Parameters.AddWithValue("@partidoId", partidoId);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el partido: " + ex.Message);
                }
            }
        }

        // Método para actualizar un candidato
        public void UpdateCandidato(int candidatoId, string candidatoName, string candidatoSurname, DateTime candidatoBirthDate, string candidatoProposal, SqlTransaction transaction)
        {
            string query = @"
                UPDATE Candidatos 
                SET candidato_nombre = @candidatoName, candidato_apellido = @candidatoSurname, 
                    candidato_fecha_nacimiento = @candidatoBirthDate, candidato_propuesta = @candidatoProposal
                WHERE candidato_id = @candidatoId;";

            using (SqlCommand cmd = new SqlCommand(query, transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@candidatoName", candidatoName);
                cmd.Parameters.AddWithValue("@candidatoSurname", candidatoSurname);
                cmd.Parameters.AddWithValue("@candidatoBirthDate", candidatoBirthDate);
                cmd.Parameters.AddWithValue("@candidatoProposal", candidatoProposal);
                cmd.Parameters.AddWithValue("@candidatoId", candidatoId);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el candidato: " + ex.Message);
                }
            }
        }

        // Método para eliminar un candidato
        public void DeleteCandidato(int candidatoId, SqlTransaction transaction)
        {
            string query = "DELETE FROM Candidatos WHERE candidato_id = @candidatoId;";

            using (SqlCommand cmd = new SqlCommand(query, transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@candidatoId", candidatoId);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el candidato: " + ex.Message);
                }
            }
        }

        // Método para eliminar un partido
        public void DeletePartido(int partidoId, SqlTransaction transaction)
        {
            string query = "DELETE FROM Partidos WHERE partido_id = @partidoId;";

            using (SqlCommand cmd = new SqlCommand(query, transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@partidoId", partidoId);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el partido: " + ex.Message);
                }
            }
        }
    }
}