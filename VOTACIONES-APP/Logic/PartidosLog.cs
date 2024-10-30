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
<<<<<<< HEAD
    {
        Persistence objPart = new Persistence();

=======

    {        
        Persistence objPart = new Persistence();


>>>>>>> 9cc09343b2dea2c78f8895ab9a9e349672bc826b
        public DataSet showPartidos()
        {
            return objPart.showPartidos();
        }

<<<<<<< HEAD
        public bool savePartido(string nombrePartido, string descripcion)
        {
            
            return objPart.savePartido(nombrePartido, descripcion);
        }

        public bool updatePartido(int id, string nombrePartido, string descripcion)
        {
           
            return objPart.updatePartido(id, nombrePartido, descripcion);
        }
       
=======

        public bool savePartido(string nombrePartido, string descripcion)
        {

            return objPart.savePartido(nombrePartido, descripcion);
        }


        public bool updatePartido(int id, string nombrePartido, string descripcion)
        {

            return objPart.updatePartido(id, nombrePartido, descripcion);
        }


>>>>>>> 9cc09343b2dea2c78f8895ab9a9e349672bc826b
        public bool deletePartido(int id)
        {
            return objPart.deletePartido(id);
        }
    }
}