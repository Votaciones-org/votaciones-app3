using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class Candidatos_eliminadosLog
    {
        Persistence objCanEl = new Persistence();

        public DataSet showCandidatosEliminados()
        {

            return objCanEl.showCandidatosEliminados();
        }

        public bool saveCandidatoEliminado(string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {

            return objCanEl.saveCandidatoEliminado(nombre, apellido, partido, fechaNacimiento, propuesta);
        }

        public bool updateCandidatoEliminado(int id, string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {

            return objCanEl.updateCandidatoEliminado(id, nombre, apellido, partido, fechaNacimiento, propuesta);
        }

        public bool deleteCandidatoEliminado(int id)
        {

            return objCanEl.deleteCandidatoEliminado(id);
        }
    }
}