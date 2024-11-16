using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class CandidatoDat
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistence objPer = new Persistence();

        // Método para mostrar los candidatos desde la base de datos.
        public DataSet showCandidatos()
        {
            DataSet objData = new DataSet();

            try
            {
                // Abrir la conexión
                MySqlConnection connection = objPer.OpenConnection();

                // Asegúrate de que la conexión esté abierta antes de crear el comando
                if (connection.State == ConnectionState.Open)
                {
                    using (MySqlCommand objSelectCmd = new MySqlCommand("procSelectCandidatos", connection))
                    {
                        objSelectCmd.CommandType = CommandType.StoredProcedure;

                        // Usar un adaptador para llenar el DataSet
                        using (MySqlDataAdapter objAdapter = new MySqlDataAdapter(objSelectCmd))
                        {
                            objAdapter.Fill(objData);  // Cargar los datos en el DataSet
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No se pudo abrir la conexión.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los candidatos: " + ex.Message);
            }
            finally
            {
                objPer.closeConnection();  // Asegúrate de cerrar la conexión
            }

            return objData;
        }

        // Método para guardar un nuevo candidato.
        public bool saveCandidato(string _nombre, string _apellido, string _partido, string _fechaNacimiento, string _propuesta)
        {
            bool executed = false;

            try
            {
                MySqlConnection connection = objPer.OpenConnection();

                using (MySqlCommand objSelectCmd = new MySqlCommand("procInsertCandidato", connection))
                {
                    objSelectCmd.CommandType = CommandType.StoredProcedure;

                    // Se agregan parámetros al comando para pasar los valores del candidato.
                    objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
                    objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
                    objSelectCmd.Parameters.Add("p_partido", MySqlDbType.VarString).Value = _partido;
                    objSelectCmd.Parameters.Add("p_fecha_nacimiento", MySqlDbType.VarString).Value = _fechaNacimiento;
                    objSelectCmd.Parameters.Add("p_propuesta", MySqlDbType.Text).Value = _propuesta;

                    int row = objSelectCmd.ExecuteNonQuery();
                    if (row == 1)
                    {
                        executed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el candidato: " + ex.Message);
            }
            finally
            {
                objPer.closeConnection();
            }

            return executed;
        }

        // Método para actualizar un candidato existente.
        public bool updateCandidato(int _id, string _nombre, string _apellido, string _partido, string _fechaNacimiento, string _propuesta)
        {
            bool executed = false;

            try
            {
                MySqlConnection connection = objPer.OpenConnection();

                using (MySqlCommand objSelectCmd = new MySqlCommand("procUpdateCandidato", connection))
                {
                    objSelectCmd.CommandType = CommandType.StoredProcedure;

                    // Se agregan parámetros al comando para pasar los valores del candidato.
                    objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
                    objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
                    objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
                    objSelectCmd.Parameters.Add("p_partido", MySqlDbType.VarString).Value = _partido;
                    objSelectCmd.Parameters.Add("p_fecha_nacimiento", MySqlDbType.VarString).Value = _fechaNacimiento;
                    objSelectCmd.Parameters.Add("p_propuesta", MySqlDbType.Text).Value = _propuesta;

                    int row = objSelectCmd.ExecuteNonQuery();
                    if (row == 1)
                    {
                        executed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el candidato: " + ex.Message);
            }
            finally
            {
                objPer.closeConnection();
            }

            return executed;
        }

        // Método para borrar un candidato.
        public bool deleteCandidato(int _idCandidato)
        {
            bool executed = false;

            try
            {
                MySqlConnection connection = objPer.OpenConnection();

                using (MySqlCommand objSelectCmd = new MySqlCommand("procDeleteCandidato", connection))
                {
                    objSelectCmd.CommandType = CommandType.StoredProcedure;
                    objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _idCandidato;

                    int row = objSelectCmd.ExecuteNonQuery();
                    if (row == 1)
                    {
                        executed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el candidato: " + ex.Message);
            }
            finally
            {
                objPer.closeConnection();
            }

            return executed;
        }
    }
}
