using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class UsuarioDat
    {
        private Persistence objPer;

        public UsuarioDat()
        {
            objPer = new Persistence();  // Asegúrate de que Persistence esté correctamente configurado
        }

        // Método común para ejecutar comandos SQL de tipo procedimiento almacenado
        private bool ExecuteNonQuery(string procedureName, MySqlParameter[] parameters)
        {
            bool executed = false;

            try
            {
                using (MySqlConnection conn = objPer.openConnection())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                    {
                        throw new InvalidOperationException("No se pudo establecer una conexión a la base de datos.");
                    }

                    using (MySqlCommand cmd = new MySqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agregar los parámetros al comando
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            executed = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la ejecución del procedimiento {procedureName}: {ex.Message}");
            }

            return executed;
        }

        // Método para mostrar los usuarios desde la base de datos.
        public DataSet showUsuarios()
        {
            DataSet objData = new DataSet();

            try
            {
                using (MySqlConnection conn = objPer.openConnection())
                {
                    if (conn == null || conn.State != ConnectionState.Open)
                    {
                        throw new InvalidOperationException("No se pudo establecer una conexión a la base de datos.");
                    }

                    using (MySqlCommand cmd = new MySqlCommand("procSelectUsuarios", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (MySqlDataAdapter objAdapter = new MySqlDataAdapter(cmd))
                        {
                            objAdapter.Fill(objData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los usuarios: " + ex.Message);
            }

            return objData;
        }

        // Método para guardar un nuevo usuario.
        public bool saveUsuario(string _correo, string _contrasena)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("p_correo", MySqlDbType.VarString) { Value = _correo },
                new MySqlParameter("p_contrasena", MySqlDbType.VarString) { Value = _contrasena }
            };

            return ExecuteNonQuery("procInsertUsuarios", parameters);
        }

        // Método para actualizar un usuario existente.
        public bool updateUsuario(int _id, string _correo, string _contrasena)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("p_id", MySqlDbType.Int32) { Value = _id },
                new MySqlParameter("p_correo", MySqlDbType.VarString) { Value = _correo },
                new MySqlParameter("p_contrasena", MySqlDbType.VarString) { Value = _contrasena }
            };

            return ExecuteNonQuery("procUpdateUsuarios", parameters);
        }

        // Método para borrar un usuario.
        public bool deleteUsuario(int _idUsuario)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("p_id", MySqlDbType.Int32) { Value = _idUsuario }
            };

            return ExecuteNonQuery("procDeleteUsuarios", parameters);
        }
    }
}
