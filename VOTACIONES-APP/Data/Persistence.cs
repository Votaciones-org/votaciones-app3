using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace Data
{
    public class Persistence
    {
        // Método para abrir la conexión a la base de datos.
        public MySqlConnection openConnection()
        {
            MySqlConnection _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

            try
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open(); // Si la conexión está cerrada, la abrimos
                }
                return _connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar abrir la conexión: {ex.Message}");
                return null;
            }
        }

        // Método para cerrar la conexión a la base de datos.
        public void closeConnection(MySqlConnection _connection)
        {
            try
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close(); // Cerramos la conexión si está abierta
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar cerrar la conexión: {ex.Message}");
            }
        }
    }
}

