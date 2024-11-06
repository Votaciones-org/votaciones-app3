using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient ;
using System.Linq;
using System.Web;

namespace Data
{
    public class Persistence
    {
        MySqlConnection _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        public MySqlConnection openConnection()
        {
            try
            {
                _connection.Open();
                return _connection;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones más detallado
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
                return null;
            }
        }

        public void closeConnection()
        {
            _connection.Close();
        }

        public DataSet SelectPartidoCandidatoDDL()
        {
            throw new NotImplementedException();
        }

        public void InsertPartidoCandidatoDDL(string nombre, string apellido, string cedula, string opcion, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
        {
            throw new NotImplementedException();
        }

        public void UpdatePartidoCandidatoDDL(int votoId, string nombre, string apellido, string cedula, string opcion, int candidatoId, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
        {
            throw new NotImplementedException();
        }

        public void DeletePartidoCandidatoDDL(int votoId, int candidatoId)
        {
            throw new NotImplementedException();
        }
    }
}