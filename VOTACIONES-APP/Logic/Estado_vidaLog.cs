using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class Estado_vidaLog
    {

        Persistence objEsVi = new Persistence();

        public DataSet showEstadoVida()
        {

            return objEsVi.showEstadoVida();
        }

        public bool saveEstadoVida(string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {

            return objEsVi.saveEstadoVida(nombre, apellido, cedula, estado, fechaDefuncion);
        }


        public bool updateEstadoVida(int id, string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            ;
            return objEsVi.updateEstadoVida(id, nombre, apellido, cedula, estado, fechaDefuncion);
        }

        public bool deleteEstadoVida(int id)
        {

            return objEsVi.deleteEstadoVida(id);
        }
    }
}