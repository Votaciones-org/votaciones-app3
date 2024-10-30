using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class Candidatos_dat
    {
        Persistence objPer = new Persistence();

        // Method to show all candidates
        public DataSet showCandidatos()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectCandidatos"; // Stored procedure to get all candidates
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Method to save a new candidate
        public bool saveCandidato(string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertCandidato"; // Stored procedure for inserting a candidate
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = apellido;
            objSelectCmd.Parameters.Add("p_partido", MySqlDbType.VarString).Value = partido;
            objSelectCmd.Parameters.Add("p_fecha_nacimiento", MySqlDbType.VarString).Value = fechaNacimiento;
            objSelectCmd.Parameters.Add("p_propuesta", MySqlDbType.Text).Value = propuesta;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Method to update a candidate
        public bool updateCandidato(int idCandidato, string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateCandidato"; // Stored procedure for updating a candidate
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = idCandidato;
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = apellido;
            objSelectCmd.Parameters.Add("p_partido", MySqlDbType.VarString).Value = partido;
            objSelectCmd.Parameters.Add("p_fecha_nacimiento", MySqlDbType.VarString).Value = fechaNacimiento;
            objSelectCmd.Parameters.Add("p_propuesta", MySqlDbType.Text).Value = propuesta;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Method to delete a candidate
        public bool deleteCandidato(int idCandidato)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDeleteCandidato"; // Stored procedure for deleting a candidate
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = idCandidato;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        public class VotoCandidatoRepository
        {
            private string connectionString = "tu_cadena_de_conexion"; 

            // Insertar Voto y Candidato
            public void InsertVotoCandidatoDDL(string nombre, string apellido, string cedula, string opcion,
                string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insertar el candidato
                            using (var command = new SqlCommand("INSERT INTO tbl_candidatos (can_nombre, can_apellido, can_partido, can_fecha_nacimiento, can_propuesta) VALUES (@canNombre, @canApellido, @canPartido, @canFechaNacimiento, @canPropuesta); SELECT SCOPE_IDENTITY();", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@canNombre", canNombre);
                                command.Parameters.AddWithValue("@canApellido", canApellido);
                                command.Parameters.AddWithValue("@canPartido", canPartido);
                                command.Parameters.AddWithValue("@canFechaNacimiento", canFechaNacimiento);
                                command.Parameters.AddWithValue("@canPropuesta", canPropuesta);

                                var candidatoId = Convert.ToInt32(command.ExecuteScalar());

                                // Insertar el voto asociado al candidato
                                using (var votoCommand = new SqlCommand("INSERT INTO tbl_votos (vo_nombre, vo_apellido, vo_cedula, vo_opcion, can_id) VALUES (@nombre, @apellido, @cedula, @opcion, @candidatoId)", connection, transaction))
                                {
                                    votoCommand.Parameters.AddWithValue("@nombre", nombre);
                                    votoCommand.Parameters.AddWithValue("@apellido", apellido);
                                    votoCommand.Parameters.AddWithValue("@cedula", cedula);
                                    votoCommand.Parameters.AddWithValue("@opcion", opcion);
                                    votoCommand.Parameters.AddWithValue("@candidatoId", candidatoId);
                                    votoCommand.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw; // O maneja la excepción según sea necesario
                        }
                    }
                }
            }

            // Actualizar Voto y Candidato
            public void UpdateVotoCandidatoDDL(int votoId, string nombre, string apellido, string cedula, string opcion,
                int candidatoId, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Actualizar el voto
                            using (var command = new SqlCommand("UPDATE tbl_votos SET vo_nombre = @nombre, vo_apellido = @apellido, vo_cedula = @cedula, vo_opcion = @opcion WHERE vo_id = @votoId", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@nombre", nombre);
                                command.Parameters.AddWithValue("@apellido", apellido);
                                command.Parameters.AddWithValue("@cedula", cedula);
                                command.Parameters.AddWithValue("@opcion", opcion);
                                command.Parameters.AddWithValue("@votoId", votoId);
                                command.ExecuteNonQuery();
                            }

                            // Actualizar el candidato
                            using (var command = new SqlCommand("UPDATE tbl_candidatos SET can_nombre = @canNombre, can_apellido = @canApellido, can_partido = @canPartido, can_fecha_nacimiento = @canFechaNacimiento, can_propuesta = @canPropuesta WHERE can_id = @candidatoId", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@canNombre", canNombre);
                                command.Parameters.AddWithValue("@canApellido", canApellido);
                                command.Parameters.AddWithValue("@canPartido", canPartido);
                                command.Parameters.AddWithValue("@canFechaNacimiento", canFechaNacimiento);
                                command.Parameters.AddWithValue("@canPropuesta", canPropuesta);
                                command.Parameters.AddWithValue("@candidatoId", candidatoId);
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw; // O maneja la excepción según sea necesario
                        }
                    }
                }
            }

            // Mostrar Votos y Candidatos
            public DataTable SelectVotosCandidatosDDL()
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("SELECT v.vo_id, v.vo_nombre, v.vo_apellido, v.vo_cedula, v.vo_opcion, v.vo_fecha_envio, c.can_id, c.can_nombre, c.can_apellido, c.can_partido, c.can_fecha_nacimiento, c.can_propuesta FROM tbl_votos v LEFT JOIN tbl_candidatos c ON v.can_id = c.can_id", connection))
                    {
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            var dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }

            // Eliminar Voto y Candidato
            public void DeleteVotoCandidatoDDL(int votoId, int candidatoId)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Eliminar el voto
                            using (var command = new SqlCommand("DELETE FROM tbl_votos WHERE vo_id = @votoId", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@votoId", votoId);
                                command.ExecuteNonQuery();
                            }

                            // Eliminar el candidato si no tiene votos asociados
                            using (var command = new SqlCommand("DELETE FROM tbl_candidatos WHERE can_id = @candidatoId AND NOT EXISTS (SELECT 1 FROM tbl_votos WHERE can_id = @candidatoId)", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@candidatoId", candidatoId);
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw; // O maneja la excepción según sea necesario
                        }
                    }
                }
            }
        }


    }
}