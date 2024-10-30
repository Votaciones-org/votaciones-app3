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

    {        
        Persistence objPart = new Persistence();


        public DataSet showPartidos()
        {
            return objPart.showPartidos();
        }


        public bool savePartido(string nombrePartido, string descripcion)
        {

            return objPart.savePartido(nombrePartido, descripcion);
        }


        public bool updatePartido(int id, string nombrePartido, string descripcion)
        {

            return objPart.updatePartido(id, nombrePartido, descripcion);
        }


        public bool deletePartido(int id)
        {
            return objPart.deletePartido(id);
        }
    }
}