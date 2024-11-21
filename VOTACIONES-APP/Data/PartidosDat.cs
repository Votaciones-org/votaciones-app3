using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class PartidosDat
    {
        private Persistence objPer = new Persistence(); // Instancia de Persistence para manejar la conexión

        // Método para mostrar los partidos desde la base de datos.
        public DataSet showPartidos()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlConnection Conn = objPer.openConnection();
            if (Conn == null || Conn.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("No se pudo establecer una conexión a la base de datos.");
            }

            MySqlCommand objSelectCmd = new MySqlCommand
            {
                Connection = Conn,
                CommandText = "procSelectPartidos", // Nombre del procedimiento almacenado
                CommandType = CommandType.StoredProcedure
            };

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);

            objPer.closeConnection(Conn);
            return objData;
        }

        // Método para guardar un nuevo partido en la base de datos.
        public bool savePartido(string partidoNombre, string partidoDescripcion, int candidatoId, int eliminadoId)
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
                CommandText = "procInsertPartido", // Nombre del procedimiento almacenado
                CommandType = CommandType.StoredProcedure
            };

            // Agregar parámetros al procedimiento almacenado
            objCommand.Parameters.Add("p_partido_nombre", MySqlDbType.VarString).Value = partidoNombre;
            objCommand.Parameters.Add("p_partido_descripcion", MySqlDbType.VarString).Value = partidoDescripcion;
            objCommand.Parameters.Add("p_candidato_id", MySqlDbType.Int32).Value = candidatoId; // Llave foránea de Candidato
            objCommand.Parameters.Add("p_eliminado_id", MySqlDbType.Int32).Value = eliminadoId; // Llave foránea de Candidatos Eliminados

            try
            {
                rowsAffected = objCommand.ExecuteNonQuery();
                executed = rowsAffected == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el partido: {ex.Message}");
            }

            objPer.closeConnection(connection);
            return executed;
        }

        // Método para actualizar un partido existente.
        public bool updatePartido(int partidoId, string partidoNombre, string partidoDescripcion, int candidatoId, int eliminadoId)
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
                CommandText = "procUpdatePartido", // Nombre del procedimiento almacenado
                CommandType = CommandType.StoredProcedure
            };

            // Agregar parámetros al procedimiento almacenado
            objCommand.Parameters.Add("p_partido_id", MySqlDbType.Int32).Value = partidoId; // Llave primaria
            objCommand.Parameters.Add("p_partido_nombre", MySqlDbType.VarString).Value = partidoNombre;
            objCommand.Parameters.Add("p_partido_descripcion", MySqlDbType.VarString).Value = partidoDescripcion;
            objCommand.Parameters.Add("p_candidato_id", MySqlDbType.Int32).Value = candidatoId; // Llave foránea de Candidato
            objCommand.Parameters.Add("p_eliminado_id", MySqlDbType.Int32).Value = eliminadoId; // Llave foránea de Candidatos Eliminados

            try
            {
                rowsAffected = objCommand.ExecuteNonQuery();
                executed = rowsAffected == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el partido: {ex.Message}");
            }

            objPer.closeConnection(connection);
            return executed;
        }

        // Método para borrar un partido.
        public bool deletePartido(int partidoId)
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
                CommandText = "procDeletePartido", // Nombre del procedimiento almacenado
                CommandType = CommandType.StoredProcedure
            };

            // Agregar parámetro para el procedimiento almacenado
            objCommand.Parameters.Add("p_partido_id", MySqlDbType.Int32).Value = partidoId; // Llave primaria

            try
            {
                rowsAffected = objCommand.ExecuteNonQuery();
                executed = rowsAffected == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el partido: {ex.Message}");
            }

            objPer.closeConnection(connection);
            return executed;
        }
    }
}
