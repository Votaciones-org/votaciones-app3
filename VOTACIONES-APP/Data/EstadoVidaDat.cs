using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class EstadoVidaDat
    {
        // Instancia de la clase Persistence para manejar conexiones con la base de datos
        private Persistence objPer = new Persistence();

        // Método para mostrar todos los registros de la tabla tbl_estado_vida
        public DataSet showEstadoVida()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand
            {
                Connection = objPer.openConnection(),
                CommandText = "spSelectEstadoVida", // Procedimiento almacenado
                CommandType = CommandType.StoredProcedure
            };

            objAdapter.SelectCommand = objSelectCmd;

            try
            {
                objAdapter.Fill(objData); // Llenar el DataSet con los resultados
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar registros: {ex.Message}");
            }
            finally
            {
                objPer.closeConnection(); // Cerrar la conexión
            }

            return objData; // Retornar los datos
        }

        // Método para guardar un nuevo registro en la tabla tbl_estado_vida
        public bool saveEstadoVida(string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            bool executed = false;

            MySqlCommand objCommand = new MySqlCommand
            {
                Connection = objPer.openConnection(),
                CommandText = "spInsertEstadoVida", // Procedimiento almacenado
                CommandType = CommandType.StoredProcedure
            };

            // Parámetros del procedimiento almacenado
            objCommand.Parameters.Add("p_nombre", MySqlDbType.VarChar).Value = nombre;
            objCommand.Parameters.Add("p_apellido", MySqlDbType.VarChar).Value = apellido;
            objCommand.Parameters.Add("p_cedula", MySqlDbType.VarChar).Value = cedula;
            objCommand.Parameters.Add("p_estado", MySqlDbType.VarChar).Value = estado;
            objCommand.Parameters.Add("p_fecha_defuncion", MySqlDbType.Date).Value = fechaDefuncion;

            try
            {
                int rows = objCommand.ExecuteNonQuery(); // Ejecutar comando
                executed = rows == 1; // Verificar si se afectó una fila
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar registro: {ex.Message}");
            }
            finally
            {
                objPer.closeConnection(); // Cerrar la conexión
            }

            return executed; // Retornar el resultado
        }

        // Método para actualizar un registro existente en la tabla tbl_estado_vida
        public bool updateEstadoVida(int id, string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            bool executed = false;

            MySqlCommand objCommand = new MySqlCommand
            {
                Connection = objPer.openConnection(),
                CommandText = "spUpdateEstadoVida", // Procedimiento almacenado
                CommandType = CommandType.StoredProcedure
            };

            // Parámetros del procedimiento almacenado
            objCommand.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objCommand.Parameters.Add("p_nombre", MySqlDbType.VarChar).Value = nombre;
            objCommand.Parameters.Add("p_apellido", MySqlDbType.VarChar).Value = apellido;
            objCommand.Parameters.Add("p_cedula", MySqlDbType.VarChar).Value = cedula;
            objCommand.Parameters.Add("p_estado", MySqlDbType.VarChar).Value = estado;
            objCommand.Parameters.Add("p_fecha_defuncion", MySqlDbType.Date).Value = fechaDefuncion;

            try
            {
                int rows = objCommand.ExecuteNonQuery(); // Ejecutar comando
                executed = rows == 1; // Verificar si se afectó una fila
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar registro: {ex.Message}");
            }
            finally
            {
                objPer.closeConnection(); // Cerrar la conexión
            }

            return executed; // Retornar el resultado
        }

        // Método para eliminar un registro de la tabla tbl_estado_vida
        public bool deleteEstadoVida(int id)
        {
            bool executed = false;

            MySqlCommand objCommand = new MySqlCommand
            {
                Connection = objPer.openConnection(),
                CommandText = "spDeleteEstadoVida", // Procedimiento almacenado
                CommandType = CommandType.StoredProcedure
            };

            // Parámetro del procedimiento almacenado
            objCommand.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;

            try
            {
                int rows = objCommand.ExecuteNonQuery(); // Ejecutar comando
                executed = rows == 1; // Verificar si se afectó una fila
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar registro: {ex.Message}");
            }
            finally
            {
                objPer.closeConnection(); // Cerrar la conexión
            }

            return executed; // Retornar el resultado
        }
    }
}