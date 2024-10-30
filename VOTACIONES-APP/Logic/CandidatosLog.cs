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
        public DataSet showVotosCandidatosDDL()
        {
            return objCan.SelectVotosCandidatosDDL();
        }

        public bool saveVotoCandidatoDDL(string nombre, string apellido, string cedula, string opcion, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
        {
            objCan.InsertVotoCandidatoDDL(nombre, apellido, cedula, opcion, canNombre, canApellido, canPartido, canFechaNacimiento, canPropuesta);
            return true;
        }

        public bool updateVotoCandidatoDDL(int votoId, string nombre, string apellido, string cedula, string opcion, int candidatoId, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
        {
            objCan.UpdateVotoCandidatoDDL(votoId, nombre, apellido, cedula, opcion, candidatoId, canNombre, canApellido, canPartido, canFechaNacimiento, canPropuesta);
            return true;
        }

        public bool deleteVotoCandidatoDDL(int votoId, int candidatoId)
        {
            objCan.DeleteVotoCandidatoDDL(votoId, candidatoId);
            return true;
        }

    }
}