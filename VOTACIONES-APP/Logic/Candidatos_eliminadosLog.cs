
using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;


namespace Logic
{
    public class Candidatos_eliminadosLog
    {
        // Create an instance of the Persistence class to handle database connections.
        Persistence objCane = new Persistence();

        // Method to show deleted candidates from the database.
        public DataSet showCandidatosEliminados()
        {
            return objCane.showCandidatosEliminados();
        }

        // Method to save a deleted candidate.
        public bool saveCandidatoEliminado(string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            return objCane.saveCandidatoEliminado(nombre, apellido, partido, fechaNacimiento, propuesta);
        }

        // Method to update a deleted candidate.
        public bool updateCandidatoEliminado(int id, string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            return objCane.updateCandidatoEliminado(id, nombre, apellido, partido, fechaNacimiento, propuesta);
        }

        // Method to delete a candidate from the deleted candidates table (if needed).
        public bool deleteCandidatoEliminado(int id)
        {
            return objCane.deleteCandidatoEliminado(id);
        }
    }
}