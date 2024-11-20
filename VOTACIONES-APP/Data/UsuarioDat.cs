using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class UsuarioDat
    {
        private Persistence objPer = new Persistence(); // Instancia de Persistence para manejar la conexión

        // Método para mostrar todos los usuarios desde la base de datos.
        public DataSet showUsuarios()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            // Abrir la conexión antes de configurar el comando
            MySqlConnection Conn = objPer.openConnection();
            if (Conn == null || Conn.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("No se pudo establecer una conexión a la base de datos.");
            }

            // Comando SQL para ejecutar el procedimiento almacenado
            MySqlCommand objSelectCmd = new MySqlCommand
            {
                Connection = Conn, // Asignar la conexión correctamente
                CommandText = "procSelectUsuarios",   // Nombre del procedimiento almacenado
                CommandType = CommandType.StoredProcedure // Definir que es un procedimiento almacenado
            };

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData); // Llenar el DataSet con los datos

            objPer.closeConnection(Conn); // Cerrar la conexión después de ejecutar
            return objData; // Retornar los datos
        }

        // Método para guardar un nuevo usuario en la base de datos.
        public bool saveUsuario(string _correo, string _contrasena)
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
                CommandText = "procInsertUsuarios", // Nombre del procedimiento almacenado
                CommandType = CommandType.StoredProcedure // Definir que es un procedimiento almacenado
            };

            // Agregar parámetros al procedimiento almacenado
            objCommand.Parameters.Add("p_correo", MySqlDbType.VarString).Value = _correo;
            objCommand.Parameters.Add("p_contrasena", MySqlDbType.VarString).Value = _contrasena;

            try
            {
                rowsAffected = objCommand.ExecuteNonQuery(); // Ejecutar el comando
                if (rowsAffected == 1) // Si la operación fue exitosa
                {
                    executed = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar usuario: {ex.Message}"); // Manejo de errores
            }

            objPer.closeConnection(connection); // Cerrar la conexión
            return executed; // Retornar el resultado de la operación
        }

        // Método para actualizar un usuario existente.
        public bool updateUsuario(int _id, string _correo, string _contrasena)
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
                CommandText = "procUpdateUsuarios", // Nombre del procedimiento almacenado
                CommandType = CommandType.StoredProcedure // Definir que es un procedimiento almacenado
            };

            // Agregar parámetros para el procedimiento almacenado
            objCommand.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
            objCommand.Parameters.Add("p_correo", MySqlDbType.VarString).Value = _correo;
            objCommand.Parameters.Add("p_contrasena", MySqlDbType.VarString).Value = _contrasena;

            try
            {
                rowsAffected = objCommand.ExecuteNonQuery(); // Ejecutar el comando
                if (rowsAffected == 1) // Si la operación fue exitosa
                {
                    executed = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar usuario: {ex.Message}"); // Manejo de errores
            }

            objPer.closeConnection(connection); // Cerrar la conexión
            return executed; // Retornar el resultado
        }

        // Método para borrar un usuario.
        public bool deleteUsuario(int _idUsuario)
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
                CommandText = "procDeleteUsuarios", // Nombre del procedimiento almacenado
                CommandType = CommandType.StoredProcedure // Definir que es un procedimiento almacenado
            };

            // Agregar parámetro para el procedimiento almacenado
            objCommand.Parameters.Add("p_id", MySqlDbType.Int32).Value = _idUsuario;

            try
            {
                rowsAffected = objCommand.ExecuteNonQuery(); // Ejecutar el comando
                if (rowsAffected == 1) // Si la operación fue exitosa
                {
                    executed = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar usuario: {ex.Message}"); // Manejo de errores
            }

            objPer.closeConnection(connection); // Cerrar la conexión
            return executed; // Retornar el resultado
        }
    }
}



