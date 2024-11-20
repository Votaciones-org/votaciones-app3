using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class UsuariosAfkDat
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistence objPer = new Persistence();

        // Método para mostrar los usuarios desde la base de datos.
        public DataSet showUsuariosAfk()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            // Verifica si objPer es null antes de intentar usarlo
            if (objPer == null)
            {
                Console.WriteLine("Error: objPer es null.");
                return objData;
            }

            // Intentamos abrir la conexión
            MySqlConnection connection = null;
            try
            {
                connection = objPer.openConnection();

                // Verifica si la conexión está abierta
                if (connection == null || connection.State != ConnectionState.Open)
                {
                    Console.WriteLine("Error: No se pudo abrir la conexión.");
                    return objData;
                }

                MySqlCommand objSelectCmd = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = "procSelectUsuariosAFK",  // Nombre del procedimiento almacenado.
                    CommandType = CommandType.StoredProcedure
                };

                // Asociamos el comando al adaptador
                objAdapter.SelectCommand = objSelectCmd;

                // Llenamos el DataSet con los datos
                objAdapter.Fill(objData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los usuarios AFK: " + ex.Message);
            }
            finally
            {
                // Asegúrate de cerrar la conexión en el bloque finally
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    objPer.closeConnection(connection);  // Pasar la conexión a closeConnection
                }
            }

            return objData;
        }

        // Método para guardar un nuevo usuario
        public bool saveUsuariosAfk(string _correo, string _contrasena)
        {
            bool executed = false;
            int row;
            MySqlConnection connection = null;

            try
            {
                // Abrimos la conexión
                connection = objPer.openConnection();

                // Verifica si la conexión se ha abierto correctamente
                if (connection == null || connection.State != ConnectionState.Open)
                {
                    Console.WriteLine("Error: No se pudo abrir la conexión.");
                    return executed;
                }

                MySqlCommand objSelectCmd = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = "procInsertUsuariosAFK",  // Nombre del procedimiento almacenado.
                    CommandType = CommandType.StoredProcedure
                };

                objSelectCmd.Parameters.Add("p_correo", MySqlDbType.VarString).Value = _correo;
                objSelectCmd.Parameters.Add("p_contrasena", MySqlDbType.VarString).Value = _contrasena;

                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al guardar el usuario: " + e.ToString());
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    objPer.closeConnection(connection);  // Pasar la conexión a closeConnection
                }
            }

            return executed;
        }

        // Método para actualizar un usuario
        public bool updateUsuariosAfk(int _id, string _correo, string _contrasena)
        {
            bool executed = false;
            int row;
            MySqlConnection connection = null;

            try
            {
                connection = objPer.openConnection();

                // Verifica si la conexión se ha abierto correctamente
                if (connection == null || connection.State != ConnectionState.Open)
                {
                    Console.WriteLine("Error: No se pudo abrir la conexión.");
                    return executed;
                }

                MySqlCommand objSelectCmd = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = "procUpdateUsuariosAFK",  // Nombre del procedimiento almacenado.
                    CommandType = CommandType.StoredProcedure
                };

                objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
                objSelectCmd.Parameters.Add("p_correo", MySqlDbType.VarString).Value = _correo;
                objSelectCmd.Parameters.Add("p_contrasena", MySqlDbType.VarString).Value = _contrasena;

                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al actualizar el usuario: " + e.ToString());
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    objPer.closeConnection(connection);  // Pasar la conexión a closeConnection
                }
            }

            return executed;
        }

        // Método para eliminar un usuario
        public bool deleteUsuariosAfk(int _id)
        {
            bool executed = false;
            int row;
            MySqlConnection connection = null;

            try
            {
                connection = objPer.openConnection();

                // Verifica si la conexión se ha abierto correctamente
                if (connection == null || connection.State != ConnectionState.Open)
                {
                    Console.WriteLine("Error: No se pudo abrir la conexión.");
                    return executed;
                }

                MySqlCommand objSelectCmd = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = "procDeleteUsuariosAFK",  // Nombre del procedimiento almacenado.
                    CommandType = CommandType.StoredProcedure
                };

                objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;

                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar el usuario: " + e.ToString());
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    objPer.closeConnection(connection);  // Pasar la conexión a closeConnection
                }
            }

            return executed;
        }
    }
}


