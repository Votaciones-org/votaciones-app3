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

            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procSelectUsuariosNoVotantes"; // Procedimiento almacenado para seleccionar los usuarios
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);

            objPer.closeConnection();

            return objData;
        }

        // Método para guardar un nuevo usuario no votante
        public bool saveUsuarioNoVotante(string _nombre, string _apellido, string _cedula, string _opcion)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertUsuarioNoVotante"; // Procedimiento almacenado para insertar un nuevo usuario
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
            objSelectCmd.Parameters.Add("p_cedula", MySqlDbType.VarString).Value = _cedula;
            objSelectCmd.Parameters.Add("p_opcion", MySqlDbType.VarString).Value = _opcion;

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

        // Método para actualizar un usuario no votante
        public bool updateUsuarioNoVotante(int _id, string _nombre, string _apellido, string _cedula, string _opcion)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateUsuarioNoVotante"; // Procedimiento almacenado para actualizar un usuario
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
            objSelectCmd.Parameters.Add("p_cedula", MySqlDbType.VarString).Value = _cedula;
            objSelectCmd.Parameters.Add("p_opcion", MySqlDbType.VarString).Value = _opcion;

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

        // Método para eliminar un usuario no votante
        public bool deleteUsuarioNoVotante(int _idUsuario)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteVotoUsuarioNoVotanteDDL"; // Procedimiento almacenado para eliminar un usuario
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _idUsuario;

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
