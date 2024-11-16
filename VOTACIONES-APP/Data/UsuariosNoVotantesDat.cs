using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class UsuariosNoVotantesDat
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistence objPer = new Persistence();

        // Método para mostrar los usuarios no votantes desde la base de datos.
        public DataSet showUsuariosNoVotantes()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();

            try
            {
                // Asegúrate de que la conexión se haya abierto correctamente
                MySqlConnection connection = objPer.openConnection();

                if (connection == null || connection.State != ConnectionState.Open)
                {
                    Console.WriteLine("Error: No se pudo abrir la conexión.");
                    return objData;
                }

                // Asignar la conexión al comando
                objSelectCmd.Connection = connection;
                objSelectCmd.CommandText = "procSelectUsuariosNoVotantes"; // Procedimiento almacenado para seleccionar los usuarios
                objSelectCmd.CommandType = CommandType.StoredProcedure;

                // Asociamos el comando al adaptador
                objAdapter.SelectCommand = objSelectCmd;

                // Llenamos el DataSet con los datos
                objAdapter.Fill(objData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los usuarios no votantes: " + ex.Message);
            }
            finally
            {
                // Asegúrate de cerrar la conexión después de usarla
                objPer.closeConnection();
            }

            return objData;
        }

        // Método para guardar un nuevo usuario no votante
        public bool saveUsuarioNoVotante(string _nombre, string _apellido, string _cedula, string _opcion)
        {
            bool executed = false;
            int row;
            MySqlConnection connection = null;

            try
            {
                // Intentamos abrir la conexión
                connection = objPer.openConnection();

                if (connection == null || connection.State != ConnectionState.Open)
                {
                    Console.WriteLine("Error: No se pudo abrir la conexión.");
                    return executed;
                }

                MySqlCommand objSelectCmd = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = "procInsertUsuarioNoVotante", // Procedimiento almacenado para insertar un nuevo usuario
                    CommandType = CommandType.StoredProcedure
                };

                objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
                objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
                objSelectCmd.Parameters.Add("p_cedula", MySqlDbType.VarString).Value = _cedula;
                objSelectCmd.Parameters.Add("p_opcion", MySqlDbType.VarString).Value = _opcion;

                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al guardar el usuario no votante: " + e.ToString());
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    objPer.closeConnection();
                }
            }

            return executed;
        }

        // Método para actualizar un usuario no votante
        public bool updateUsuarioNoVotante(int _id, string _nombre, string _apellido, string _cedula, string _opcion)
        {
            bool executed = false;
            int row;
            MySqlConnection connection = null;

            try
            {
                connection = objPer.openConnection();

                if (connection == null || connection.State != ConnectionState.Open)
                {
                    Console.WriteLine("Error: No se pudo abrir la conexión.");
                    return executed;
                }

                MySqlCommand objSelectCmd = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = "procUpdateUsuarioNoVotante", // Procedimiento almacenado para actualizar un usuario
                    CommandType = CommandType.StoredProcedure
                };

                objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
                objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
                objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
                objSelectCmd.Parameters.Add("p_cedula", MySqlDbType.VarString).Value = _cedula;
                objSelectCmd.Parameters.Add("p_opcion", MySqlDbType.VarString).Value = _opcion;

                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al actualizar el usuario no votante: " + e.ToString());
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    objPer.closeConnection();
                }
            }

            return executed;
        }

        // Método para eliminar un usuario no votante
        public bool deleteUsuarioNoVotante(int _idUsuario)
        {
            bool executed = false;
            int row;
            MySqlConnection connection = null;

            try
            {
                connection = objPer.openConnection();

                if (connection == null || connection.State != ConnectionState.Open)
                {
                    Console.WriteLine("Error: No se pudo abrir la conexión.");
                    return executed;
                }

                MySqlCommand objSelectCmd = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = "procDeleteVotoUsuarioNoVotanteDDL", // Procedimiento almacenado para eliminar un usuario
                    CommandType = CommandType.StoredProcedure
                };

                objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _idUsuario;

                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar el usuario no votante: " + e.ToString());
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    objPer.closeConnection();
                }
            }

            return executed;
        }
    }
}
