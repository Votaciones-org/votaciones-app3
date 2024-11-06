using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;


namespace Logic
{
    public class Estado_vidaLog
    {
        // Create an instance of the Persistence class to handle database connections.
        Persistence objEsv = new Persistence();

        // Method to show records from the tbl_estado_vida table.
        public DataSet showEstadoVida()
        {
            return objEsv.showEstadoVida();
        }

        // Method to save a new record in the tbl_estado_vida table.
        public bool saveEstadoVida(string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            return objEsv.saveEstadoVida(nombre, apellido, cedula, estado, fechaDefuncion);
        }

        // Method to update a record in the tbl_estado_vida table.
        public bool updateEstadoVida(int id, string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            return objEsv.updateEstadoVida(id, nombre, apellido, cedula, estado, fechaDefuncion);
        }

        // Method to delete a record from the tbl_estado_vida table.
        public bool deleteEstadoVida(int id)
        {
            return objEsv.deleteEstadoVida(id);
        }
    }
}