using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class CandidatosLog
    {
        CandidatosLog objCan = new CandidatosLog();

        public DataSet showCandidatos()
        {
            return objCan.showCandidatos();
        }

        public bool saveCandidato(string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            return objCan.saveCandidato(nombre, apellido, partido, fechaNacimiento, propuesta);
        }
        public bool updateCandidato(int idCandidato, string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            return objCan.updateCandidato(idCandidato,nombre,apellido,partido,fechaNacimiento,propuesta);
        }
        public bool deleteCandidato(int idCandidato)
        {
            return objCan.deleteCandidato(idCandidato);
        }


    }
}