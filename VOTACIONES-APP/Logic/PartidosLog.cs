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
        public DataSet showPartidoCandidatoDDL()
        {
            return objPar.SelectPartidoCandidatoDDL();
        }

        public bool savePartidoCandidatoDDL(string nombre, string apellido, string cedula, string opcion, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
        {
            objPar.InsertPartidoCandidatoDDL(nombre, apellido, cedula, opcion, canNombre, canApellido, canPartido, canFechaNacimiento, canPropuesta);
            return true;
        }

        public bool updatePartidoCandidatoDDL(int partidoId, string nombre, string apellido, string cedula, string opcion, int candidatoId, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
        {
            objPar.UpdatePartidoCandidatoDDL(partidoId, nombre, apellido, cedula, opcion, candidatoId, canNombre, canApellido, canPartido, canFechaNacimiento, canPropuesta);
            return true;
        }

        public bool deletePartidoCandidatoDDL(int partidoId, int candidatoId)
        {
            objPar.DeletePartidoCandidatoDDL(partidoId, candidatoId);
            return true;
        }
    }
}