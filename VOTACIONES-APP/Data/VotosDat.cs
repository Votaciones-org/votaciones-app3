using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class VotosDat
    {
        private readonly Persistence objPer = new Persistence(); // Instancia de Persistence para manejar la conexión

        // Método para mostrar los votos desde la base de datos.
        public DataSet ShowVotes()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            // Abrir la conexión antes de configurar el comando
            MySqlConnection connection = objPer.openConnection();
            if (connection == null || connection.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("No se pudo establecer una conexión a la base de datos.");
            }

            MySqlCommand objCommand = new MySqlCommand
            {
                Connection = connection,
                CommandText = "spSelectVotes", // Procedimiento almacenado para seleccionar votos
                CommandType = CommandType.StoredProcedure
            };

            objAdapter.SelectCommand = objCommand;
            objAdapter.Fill(objData); // Llenar el DataSet con los datos

            objPer.closeConnection(connection); // Cerrar la conexión después de ejecutar
            return objData; // Retornar los datos
        }

        // Método para guardar un nuevo voto.
        public bool SaveVote(string nombre, string apellido, string cedula, string opcion)
        {
            bool executed = false;
            int rowsAffected;

            MySqlConnection connection = objPer.openConnection();
            if (connection == null || connection.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("No se pudo establecer una conexión a la base de datos.");
            }

            MySqlCommand objCommand = new MySqlCommand
            {
                Connection = connection,
                CommandText = "spInsertVote", // Procedimiento almacenado para insertar un voto
                CommandType = CommandType.StoredProcedure
            };

            // Agregar parámetros
            objCommand.Parameters.Add("p_nombre", MySqlDbType.VarChar).Value = nombre;
            objCommand.Parameters.Add("p_apellido", MySqlDbType.VarChar).Value = apellido;
            objCommand.Parameters.Add("p_cedula", MySqlDbType.VarChar).Value = cedula;
            objCommand.Parameters.Add("p_opcion", MySqlDbType.VarChar).Value = opcion;

            try
            {
                rowsAffected = objCommand.ExecuteNonQuery(); // Ejecutar el comando
                if (rowsAffected == 1)
                {
                    executed = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el voto: {ex.Message}"); // Manejo de errores
            }

            objPer.closeConnection(connection); // Cerrar la conexión
            return executed; // Retornar el resultado
        }

        // Método para actualizar un voto existente.
        public bool UpdateVote(int id, string nombre, string apellido, string cedula, string opcion)
        {
            bool executed = false;
            int rowsAffected;

            MySqlConnection connection = objPer.openConnection();
            if (connection == null || connection.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("No se pudo establecer una conexión a la base de datos.");
            }

            MySqlCommand objCommand = new MySqlCommand
            {
                Connection = connection,
                CommandText = "spUpdateVote", // Procedimiento almacenado para actualizar un voto
                CommandType = CommandType.StoredProcedure
            };

            // Agregar parámetros
            objCommand.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objCommand.Parameters.Add("p_nombre", MySqlDbType.VarChar).Value = nombre;
            objCommand.Parameters.Add("p_apellido", MySqlDbType.VarChar).Value = apellido;
            objCommand.Parameters.Add("p_cedula", MySqlDbType.VarChar).Value = cedula;
            objCommand.Parameters.Add("p_opcion", MySqlDbType.VarChar).Value = opcion;

            try
            {
                rowsAffected = objCommand.ExecuteNonQuery(); // Ejecutar el comando
                if (rowsAffected == 1)
                {
                    executed = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el voto: {ex.Message}"); // Manejo de errores
            }

            objPer.closeConnection(connection); // Cerrar la conexión
            return executed; // Retornar el resultado
        }

        // Método para eliminar un voto.
        public bool DeleteVote(int id)
        {
            bool executed = false;
            int rowsAffected;

            MySqlConnection connection = objPer.openConnection();
            if (connection == null || connection.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("No se pudo establecer una conexión a la base de datos.");
            }

            MySqlCommand objCommand = new MySqlCommand
            {
                Connection = connection,
                CommandText = "spDeleteVote", // Procedimiento almacenado para eliminar un voto
                CommandType = CommandType.StoredProcedure
            };

            // Agregar parámetros
            objCommand.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;

            try
            {
                rowsAffected = objCommand.ExecuteNonQuery(); // Ejecutar el comando
                if (rowsAffected == 1)
                {
                    executed = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el voto: {ex.Message}"); // Manejo de errores
            }

            objPer.closeConnection(connection); // Cerrar la conexión
            return executed; // Retornar el resultado
        }

        public DataSet showVotes()
        {
            throw new NotImplementedException();
        }

        public bool saveVote(string nombre, string apellido, string cedula, string opcion)
        {
            throw new NotImplementedException();
        }

        public bool deleteVote(int id)
        {
            throw new NotImplementedException();
        }

        public bool updateVote(int id, string nombre, string apellido, string cedula, string opcion)
        {
            throw new NotImplementedException();
        }
    }
}