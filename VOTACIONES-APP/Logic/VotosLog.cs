using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Runtime.Remoting;
using MySql.Data.MySqlClient;

namespace Logic
{
    public class VotosLog
    {
        VotosDat objVot = new VotosDat(); // Instancia de Persistence para manejar la conexión

        // Método para mostrar los votos desde la base de datos.
        public DataSet showVotes()
        {

            return objVot.showVotes(); // Retornar los datos
        }

        // Método para guardar un nuevo voto.
        public bool saveVote(string nombre, string apellido, string cedula, string opcion)
        {

            return objVot.saveVote(nombre, apellido, cedula, opcion); // Retornar el resultado
        }

        // Método para actualizar un voto existente.
        public bool updateVote(int id, string nombre, string apellido, string cedula, string opcion)
        {
            return objVot.updateVote(id, nombre, apellido, cedula, opcion); // Retornar el resultado
        }

        // Método para eliminar un voto.
        public bool deleteVote(int id)
        {
            return objVot.deleteVote( id); // Retornar el resultado
        }
    }
}
       
