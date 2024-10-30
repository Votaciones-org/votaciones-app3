using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class Usuarios_dat
    {
        // Create an instance of the Persistence class to handle database connections.
        Persistence objPer = new Persistence();

        // Method to show users from the database.
        public DataSet showUsuarios()
        {
            // Create a MySQL data adapter.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            // Create a DataSet to store the results of the query.
            DataSet objData = new DataSet();
            // Create a MySQL command to select users using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            // Set the connection of the command using the openConnection() method from Persistence.
            objSelectCmd.Connection = objPer.openConnection();
            // Specify the name of the stored procedure to execute.
            objSelectCmd.CommandText = "spSelectUsuarios"; // Adjust this to your stored procedure name.
            // Indicate that this is a stored procedure.
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            // Set the select command of the data adapter.
            objAdapter.SelectCommand = objSelectCmd;
            // Fill the DataSet with the results of the query.
            objAdapter.Fill(objData);
            // Close the connection after obtaining the data.
            objPer.closeConnection();
            // Return the DataSet containing the users.
            return objData;
        }

        // Method to save a new user.
        public bool saveUsuario(string correo, string contrasena)
        {
            // Initialize a variable to indicate if the operation was successful.
            bool executed = false;
            int row;

            // Create a MySQL command to insert a new user using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertUsuario"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the user.
            objSelectCmd.Parameters.Add("p_correo", MySqlDbType.VarString).Value = correo;
            objSelectCmd.Parameters.Add("p_contrasena", MySqlDbType.VarString).Value = contrasena;

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

        // Method to update a user.
        public bool updateUsuario(int id, string correo, string contrasena)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to update a user using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateUsuario"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the user.
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objSelectCmd.Parameters.Add("p_correo", MySqlDbType.VarString).Value = correo;
            objSelectCmd.Parameters.Add("p_contrasena", MySqlDbType.VarString).Value = contrasena;

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

        // Method to delete a user.
        public bool deleteUsuario(int id)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to delete a user using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDeleteUsuario"; // Adjust this to your stored procedure name.
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
        public class UsuarioVotoRepository
        {
            private string connectionString = "tu_cadena_de_conexion"; // Reemplaza con tu cadena de conexión

            // Insertar Voto y Usuario
            public void InsertVotoUsuarioDDL(string nombre, string apellido, string cedula, string opcion, string correo, string contrasena)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insertar el usuario
                            using (var command = new SqlCommand("INSERT INTO tbl_usuarios (usu_correo, usu_contrasena) VALUES (@correo, @contrasena); SELECT SCOPE_IDENTITY();", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@correo", correo);
                                command.Parameters.AddWithValue("@contrasena", contrasena);
                                var usuarioId = Convert.ToInt32(command.ExecuteScalar());

                                // Insertar el voto
                                using (var votoCommand = new SqlCommand("INSERT INTO tbl_votos (vo_nombre, vo_apellido, vo_cedula, vo_opcion) VALUES (@nombre, @apellido, @cedula, @opcion)", connection, transaction))
                                {
                                    votoCommand.Parameters.AddWithValue("@nombre", nombre);
                                    votoCommand.Parameters.AddWithValue("@apellido", apellido);
                                    votoCommand.Parameters.AddWithValue("@cedula", cedula);
                                    votoCommand.Parameters.AddWithValue("@opcion", opcion);
                                    votoCommand.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw; // Maneja la excepción según sea necesario
                        }
                    }
                }
            }

            // Actualizar Voto y Usuario
            public void UpdateVotoUsuarioDDL(int votoId, string nombre, string apellido, string cedula, string opcion, int usuarioId, string correo, string contrasena)
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

                            // Actualizar el usuario
                            using (var command = new SqlCommand("UPDATE tbl_usuarios SET usu_correo = @correo, usu_contrasena = @contrasena WHERE usu_id = @usuarioId", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@correo", correo);
                                command.Parameters.AddWithValue("@contrasena", contrasena);
                                command.Parameters.AddWithValue("@usuarioId", usuarioId);
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw; // Maneja la excepción según sea necesario
                        }
                    }
                }
            }

            // Mostrar Votos y Usuarios
            public DataTable SelectVotosUsuariosDDL()
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("SELECT u.usu_id, u.usu_correo, v.vo_id, v.vo_nombre, v.vo_apellido, v.vo_cedula, v.vo_opcion, v.vo_fecha_envio FROM tbl_usuarios u LEFT JOIN tbl_votos v ON u.usu_id = v.vo_id", connection))
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

            // Eliminar Voto y Usuario
            public void DeleteVotoUsuarioDDL(int votoId, int usuarioId)
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

                            // Eliminar el usuario
                            using (var command = new SqlCommand("DELETE FROM tbl_usuarios WHERE usu_id = @usuarioId", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@usuarioId", usuarioId);
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw; // Maneja la excepción según sea necesario
                        }
                    }
                }
            }
        }


    }
}