using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class Usuarios_no_votantes
    {
        // Create an instance of the Persistence class to handle database connections.
        Persistence objPer = new Persistence();

        // Method to show records from the usuarios_no_votantes table.
        public DataSet showUsuariosNoVotantes()
        {
            // Create a MySQL data adapter.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            // Create a DataSet to store the results of the query.
            DataSet objData = new DataSet();
            // Create a MySQL command to select records using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            // Set the connection of the command using the openConnection() method from Persistence.
            objSelectCmd.Connection = objPer.openConnection();
            // Specify the name of the stored procedure to execute.
            objSelectCmd.CommandText = "spSelectUsuariosNoVotantes"; // Adjust this to your stored procedure name.
            // Indicate that this is a stored procedure.
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            // Set the select command of the data adapter.
            objAdapter.SelectCommand = objSelectCmd;
            // Fill the DataSet with the results of the query.
            objAdapter.Fill(objData);
            // Close the connection after obtaining the data.
            objPer.closeConnection();
            // Return the DataSet containing the records.
            return objData;
        }

        // Method to save a new record in the usuarios_no_votantes table.
        public bool saveUsuarioNoVotante(string nombre, string apellido, string cedula, string opcion)
        {
            // Initialize a variable to indicate if the operation was successful.
            bool executed = false;
            int row;

            // Create a MySQL command to insert a new record using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertUsuariosNoVotantes"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the record.
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = apellido;
            objSelectCmd.Parameters.Add("p_cedula", MySqlDbType.VarString).Value = cedula;
            objSelectCmd.Parameters.Add("p_opcion", MySqlDbType.VarString).Value = opcion;

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

        // Method to update a record in the usuarios_no_votantes table.
        public bool updateUsuarioNoVotante(int id, string nombre, string apellido, string cedula, string opcion)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to update a record using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateUsuariosNoVotantes"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the record.
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = apellido;
            objSelectCmd.Parameters.Add("p_cedula", MySqlDbType.VarString).Value = cedula;
            objSelectCmd.Parameters.Add("p_opcion", MySqlDbType.VarString).Value = opcion;

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

        // Method to delete a record from the usuarios_no_votantes table.
        public bool deleteUsuarioNoVotante(int id)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to delete a record using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDeleteUsuariosNoVotantes"; // Adjust this to your stored procedure name.
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

        public class UsuarioNoVotanteVotoRepository
        {
            private string connectionString = "tu_cadena_de_conexion"; // Reemplaza con tu cadena de conexión

            // Insertar Voto y Usuario No Votante
            public void InsertVotoUsuarioNoVotanteDDL(string nombre, string apellido, string cedula, string opcion)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insertar el usuario no votante
                            using (var command = new SqlCommand("INSERT INTO tbl_usuarios_no_votantes (no_nombre, no_apellido, no_cedula, no_opcion) VALUES (@nombre, @apellido, @cedula, @opcion)", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@nombre", nombre);
                                command.Parameters.AddWithValue("@apellido", apellido);
                                command.Parameters.AddWithValue("@cedula", cedula);
                                command.Parameters.AddWithValue("@opcion", opcion);
                                command.ExecuteNonQuery();
                            }

                            // Insertar el voto asociado al usuario no votante
                            using (var command = new SqlCommand("INSERT INTO tbl_votos (vo_nombre, vo_apellido, vo_cedula, vo_opcion) VALUES (@nombre, @apellido, @cedula, @opcion)", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@nombre", nombre);
                                command.Parameters.AddWithValue("@apellido", apellido);
                                command.Parameters.AddWithValue("@cedula", cedula);
                                command.Parameters.AddWithValue("@opcion", opcion);
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

            // Actualizar Voto y Usuario No Votante
            public void UpdateVotoUsuarioNoVotanteDDL(int votoId, string nombre, string apellido, string cedula, string opcion, int usuarioNoId)
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

                            // Actualizar el usuario no votante
                            using (var command = new SqlCommand("UPDATE tbl_usuarios_no_votantes SET no_nombre = @nombre, no_apellido = @apellido, no_cedula = @cedula, no_opcion = @opcion WHERE no_id = @usuarioNoId", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@nombre", nombre);
                                command.Parameters.AddWithValue("@apellido", apellido);
                                command.Parameters.AddWithValue("@cedula", cedula);
                                command.Parameters.AddWithValue("@opcion", opcion);
                                command.Parameters.AddWithValue("@usuarioNoId", usuarioNoId);
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

            // Mostrar Votos y Usuarios No Votantes
            public DataTable SelectVotosUsuariosNoVotantesDDL()
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("SELECT v.vo_id, v.vo_nombre, v.vo_apellido, v.vo_cedula, v.vo_opcion, v.vo_fecha_envio, u.no_id, u.no_nombre, u.no_apellido, u.no_cedula, u.no_opcion, u.no_fecha_registro FROM tbl_votos v LEFT JOIN tbl_usuarios_no_votantes u ON v.vo_cedula = u.no_cedula", connection))
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

            // Eliminar Voto y Usuario No Votante
            public void DeleteVotoUsuarioNoVotanteDDL(int votoId, int usuarioNoId)
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

                            // Eliminar el usuario no votante solo si no tiene votos asociados
                            using (var command = new SqlCommand("DELETE FROM tbl_usuarios_no_votantes WHERE no_id = @usuarioNoId AND NOT EXISTS (SELECT 1 FROM tbl_votos WHERE vo_id = @votoId)", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@usuarioNoId", usuarioNoId);
                                command.Parameters.AddWithValue("@votoId", votoId);
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