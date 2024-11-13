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
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();

            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectCandidatos";  // Asegúrate de tener este procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);

            objPer.closeConnection();

            return objData;
        }

        // Método para guardar un nuevo candidato.
        public bool saveCandidato(string _nombre, string _apellido, string _partido, string _fechaNacimiento, string _propuesta)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertCandidato";  // Asegúrate de tener este procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Se agregan parámetros al comando para pasar los valores del candidato.
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
            objSelectCmd.Parameters.Add("p_partido", MySqlDbType.VarString).Value = _partido;
            objSelectCmd.Parameters.Add("p_fecha_nacimiento", MySqlDbType.VarString).Value = _fechaNacimiento;
            objSelectCmd.Parameters.Add("p_propuesta", MySqlDbType.Text).Value = _propuesta;

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
                Console.WriteLine("Error: " + e.ToString());
            }

            objPer.closeConnection();

            return executed;
        }

        // Método para actualizar un candidato existente.
        public bool updateCandidato(int _id, string _nombre, string _apellido, string _partido, string _fechaNacimiento, string _propuesta)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateCandidato";  // Asegúrate de tener este procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Se agregan parámetros al comando para pasar los valores del candidato.
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
            objSelectCmd.Parameters.Add("p_partido", MySqlDbType.VarString).Value = _partido;
            objSelectCmd.Parameters.Add("p_fecha_nacimiento", MySqlDbType.VarString).Value = _fechaNacimiento;
            objSelectCmd.Parameters.Add("p_propuesta", MySqlDbType.Text).Value = _propuesta;

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
                Console.WriteLine("Error: " + e.ToString());
            }

            objPer.closeConnection();

            return executed;
        }

        // Método para borrar un candidato.
        public bool deleteCandidato(int _idCandidato)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteCandidato";  // Asegúrate de tener este procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _idCandidato;

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
                Console.WriteLine("Error: " + e.ToString());
            }

            objPer.closeConnection();

            return executed;
        }
    }
}
