using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        public DataSet showVotes()
        {
            throw new NotImplementedException();
        }

        public bool saveVote(string nombre, string apellido, string cedula, string opcion)
        {
            throw new NotImplementedException();
        }

        public bool updateVote(int id, string nombre, string apellido, string cedula, string opcion)
        {
            throw new NotImplementedException();
        }

        public DataSet showPartidos()
        {
            throw new NotImplementedException();
        }

        public bool savePartido(string nombrePartido, string descripcion)
        {
            throw new NotImplementedException();
        }

        public bool updatePartido(int id, string nombrePartido, string descripcion)
        {
            throw new NotImplementedException();
        }

        public bool deletePartido(int id)
        {
            throw new NotImplementedException();
        }

        public DataSet showEstadoVida()
        {
            throw new NotImplementedException();
        }

        public bool saveEstadoVida(string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            throw new NotImplementedException();
        }

        public bool updateEstadoVida(int id, string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            throw new NotImplementedException();
        }

        public bool deleteEstadoVida(int id)
        {
            throw new NotImplementedException();
        }

        public DataSet showCandidatosEliminados()
        {
            throw new NotImplementedException();
        }

        public bool saveCandidatoEliminado(string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            throw new NotImplementedException();
        }

        public bool updateCandidatoEliminado(int id, string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            throw new NotImplementedException();
        }

        public bool deleteCandidatoEliminado(int id)
        {
            throw new NotImplementedException();
        }
    }
}