using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class Partidos_dat
    {
        // Create an instance of the Persistence class to handle database connections.
        Persistence objPer = new Persistence();

        // Method to show parties from the database.
        public DataSet showPartidos()
        {
            // Create a MySQL data adapter.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            // Create a DataSet to store the results of the query.
            DataSet objData = new DataSet();
            // Create a MySQL command to select parties using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            // Set the connection of the command using the openConnection() method from Persistence.
            objSelectCmd.Connection = objPer.openConnection();
            // Specify the name of the stored procedure to execute.
            objSelectCmd.CommandText = "spSelectPartidos"; // Adjust this to your stored procedure name.
            // Indicate that this is a stored procedure.
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            // Set the select command of the data adapter.
            objAdapter.SelectCommand = objSelectCmd;
            // Fill the DataSet with the results of the query.
            objAdapter.Fill(objData);
            // Close the connection after obtaining the data.
            objPer.closeConnection();
            // Return the DataSet containing the parties.
            return objData;
        }

        // Method to save a new party.
        public bool savePartido(string nombrePartido, string descripcion)
        {
            // Initialize a variable to indicate if the operation was successful.
            bool executed = false;
            int row;

            // Create a MySQL command to insert a new party using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertPartido"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the party.
            objSelectCmd.Parameters.Add("p_nombre_partido", MySqlDbType.VarString).Value = nombrePartido;
            objSelectCmd.Parameters.Add("p_descripcion", MySqlDbType.Text).Value = descripcion;

            try
            {
                // Execute the command and get the number of affected rows.
                row = objSelectCmd.ExecuteNonQuery();
                // If one row is inserted successfully, set executed to true.
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                // Log the error if an exception occurs during command execution.
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            // Return the value of executed to indicate if the operation was successful.
            return executed;
        }

        // Method to update a party.
        public bool updatePartido(int id, string nombrePartido, string descripcion)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to update a party using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdatePartido"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the party.
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objSelectCmd.Parameters.Add("p_nombre_partido", MySqlDbType.VarString).Value = nombrePartido;
            objSelectCmd.Parameters.Add("p_descripcion", MySqlDbType.Text).Value = descripcion;

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

        // Method to delete a party (if needed).
        public bool deletePartido(int id)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to delete a party using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDeletePartido"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;

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

        public class PartidoCandidatoRepository
        {
            private string connectionString = "tu_cadena_de_conexion";

            // Insertar Partido y Candidato
            public void InsertPartidoCandidatoDDL(string nombrePartido, string descripcion, string canNombre, string canApellido, DateTime canFechaNacimiento, string canPropuesta)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Llamar al procedimiento almacenado para insertar el partido
                            int partidoId;
                            using (var command = new SqlCommand("procInsertPartidoDDL", connection, transaction))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@v_nombre_partido", nombrePartido);
                                command.Parameters.AddWithValue("@v_descripcion", descripcion);

                                // Ejecución y recuperación del ID
                                command.Parameters.Add("@partidoId", SqlDbType.Int).Direction = ParameterDirection.Output;
                                command.ExecuteNonQuery();

                                partidoId = Convert.ToInt32(command.Parameters["@partidoId"].Value);
                            }

                            // Llamar al procedimiento almacenado para insertar el candidato
                            using (var candidatoCommand = new SqlCommand("procInsertCandidatoDDL", connection, transaction))
                            {
                                candidatoCommand.CommandType = CommandType.StoredProcedure;
                                candidatoCommand.Parameters.AddWithValue("@v_nombre", canNombre);
                                candidatoCommand.Parameters.AddWithValue("@v_apellido", canApellido);
                                candidatoCommand.Parameters.AddWithValue("@v_partido_id", partidoId);
                                candidatoCommand.Parameters.AddWithValue("@v_fecha_nacimiento", canFechaNacimiento);
                                candidatoCommand.Parameters.AddWithValue("@v_propuesta", canPropuesta);

                                // Ejecutar el comando
                                candidatoCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            // Log o manejar la excepción como sea necesario
                            throw new Exception("Error al insertar partido y candidato", ex);
                        }
                    }
                }
            }

            // Actualizar partido y Candidato
            public void UpdatePartidoCandidatoDDL(int partidoId, string nombre, string apellido, string cedula, string opcion,
                int candidatoId, string canNombre, string canApellido, string canPartido, DateTime canFechaNacimiento, string canPropuesta)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Actualizar el partido
                            using (var command = new SqlCommand("UPDATE tbl_partidos SET vo_nombre = @nombre, vo_apellido = @apellido, vo_cedula = @cedula, vo_opcion = @opcion WHERE vo_id = @partidoId", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@nombre", nombre);
                                command.Parameters.AddWithValue("@apellido", apellido);
                                command.Parameters.AddWithValue("@cedula", cedula);
                                command.Parameters.AddWithValue("@opcion", opcion);
                                command.Parameters.AddWithValue("@partidoId", partidoId);
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
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Error al actualizar candidato", ex);
                        }
                    }
                }
            }

            // Mostrar partidos y Candidatos
            public DataTable SelectPartidoCandidatoDDL()
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT v.vo_id, v.vo_nombre, v.vo_apellido, v.vo_cedula, v.vo_opcion, v.vo_fecha_envio, c.can_id, c.can_nombre, c.can_apellido, c.can_partido, c.can_fecha_nacimiento, c.can_propuesta FROM tbl_partidos v LEFT JOIN tbl_candidatos c ON v.can_id = c.can_id", connection))
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

            // Eliminar partido y Candidato
            public void DeletePartidoCandidatoDDL(int partidoId, int candidatoId)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Eliminar el voto
                            using (var command = new SqlCommand("DELETE FROM tbl_partidos WHERE vo_id = @partidoId", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@votoId", partidoId);
                                command.ExecuteNonQuery();
                            }

                            // Eliminar el candidato si no tiene partidos asociados
                            using (var command = new SqlCommand("DELETE FROM tbl_candidatos WHERE can_id = @candidatoId AND NOT EXISTS (SELECT 1 FROM tbl_votos WHERE can_id = @candidatoId)", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@candidatoId", candidatoId);
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Error al eliminar partido y candidato", ex);
                        }
                    }
                }
            }
        }
        
    }
}