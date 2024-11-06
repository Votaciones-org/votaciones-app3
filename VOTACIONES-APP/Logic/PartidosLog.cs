using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class PartidosLog
    {        // Create an instance of the Persistence class to handle database connections.
        Persistence objPar = new Persistence();

        // Method to show parties from the database.
        public DataSet showPartidos()
        {
            return objPar.showPartidos();
        }

        // Method to save a new party.
        public bool savePartido(string nombrePartido, string descripcion)
        {
            return objPar.savePartido(nombrePartido, descripcion);
        }

        // Method to update a party.
        public bool updatePartido(int id, string nombrePartido, string descripcion)
        {
            return objPar.updatePartido(id, nombrePartido, descripcion);
        }

        // Method to delete a party (if needed).
        public bool deletePartido(int id)
        {
            return objPar.deletePartido(id);
        }
    }
}