using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class CandidatosEliminadosDat
    {
        // Instancia de la clase Persistence para manejar las conexiones.
        private Persistence objPer = new Persistence();

        // Método para mostrar los candidatos eliminados desde la base de datos.
        public DataSet showCandidatosEliminados()
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
                Connection = Conn,
                CommandText = "procSelectCandidatosEliminados", // Nombre del procedimiento almacenado
                CommandType = CommandType.StoredProcedure
            };

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData); // Llenar el DataSet con los datos

            objPer.closeConnection(Conn); // Cerrar la conexión después de ejecutar
            return objData; // Retornar los datos
        }

        // Método para guardar un candidato eliminado.
        public bool saveCandidatoEliminado(string _nombre, string _apellido, string _partido, string _fechaNacimiento, string _propuesta)
        {
            bool executed = false;
            int rowsAffected;

            // Abrir la conexión antes de configurar el comando
            MySqlConnection connection = objPer.openConnection();
            if (connection == null || connection.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("No se pudo establecer una conexión a la base de datos.");
            }

            MySqlCommand objCommand = new MySqlCommand
            {
                Connection = connection,
                CommandText = "procInsertCandidatoEliminado", // Nombre del procedimiento almacenado
                CommandType = CommandType.StoredProcedure
            };

            // Agregar parámetros para el procedimiento almacenado
            objCommand.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
            objCommand.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
            objCommand.Parameters.Add("p_partido", MySqlDbType.VarString).Value = _partido;
            objCommand.Parameters.Add("p_fecha_nacimiento", MySqlDbType.VarString).Value = _fechaNacimiento;
            objCommand.Parameters.Add("p_propuesta", MySqlDbType.Text).Value = _propuesta;

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
                Console.WriteLine($"Error al guardar el candidato eliminado: {ex.Message}");
            }

            objPer.closeConnection(connection); // Cerrar la conexión
            return executed; // Retornar el resultado
        }

        // Método para actualizar un candidato eliminado.
        public bool updateCandidatoEliminado(int _id, string _nombre, string _apellido, string _partido, string _fechaNacimiento, string _propuesta)
        {
            bool executed = false;
            int rowsAffected;

            // Abrir la conexión antes de configurar el comando
            MySqlConnection connection = objPer.openConnection();
            if (connection == null || connection.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("No se pudo establecer una conexión a la base de datos.");
            }

            MySqlCommand objCommand = new MySqlCommand
            {
                Connection = connection,
                CommandText = "procUpdateCandidatoEliminado", // Nombre del procedimiento almacenado
                CommandType = CommandType.StoredProcedure // Definir procedimiento almacenado
            };

            // Agregar parámetros para el procedimiento almacenado
            objCommand.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
            objCommand.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
            objCommand.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
            objCommand.Parameters.Add("p_partido", MySqlDbType.VarString).Value = _partido;
            objCommand.Parameters.Add("p_fecha_nacimiento", MySqlDbType.VarString).Value = _fechaNacimiento;
            objCommand.Parameters.Add("p_propuesta", MySqlDbType.Text).Value = _propuesta;

            try
            {
                rowsAffected = objCommand.ExecuteNonQuery(); // Ejecutar el comando
                if (rowsAffected == 1) //Si la operacion fue exitosa
                {
                    executed = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el candidato eliminado: {ex.Message}"); //Manejo de errores
            }

            objPer.closeConnection(connection); // Cerrar la conexión
            return executed; // Retornar el resultado
        }

        // Método para eliminar un candidato eliminado.
        public bool deleteCandidatoEliminado(int _idCandidato)
        {
            bool executed = false;
            int rowsAffected;

            // Abrir la conexión antes de configurar el comando
            MySqlConnection connection = objPer.openConnection();
            if (connection == null || connection.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("No se pudo establecer una conexión a la base de datos.");
            }

            MySqlCommand objCommand = new MySqlCommand
            {
                Connection = connection,
                CommandText = "procDeleteCandidatoEliminado", // Nombre del procedimiento almacenado
                CommandType = CommandType.StoredProcedure
            };

            // Agregar parámetro para el procedimiento almacenado
            objCommand.Parameters.Add("p_id", MySqlDbType.Int32).Value = _idCandidato;

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
                Console.WriteLine($"Error al eliminar el candidato eliminado: {ex.Message}");
            }

            objPer.closeConnection(connection); // Cerrar la conexión
            return executed; // Retornar el resultado
        }
    }
}