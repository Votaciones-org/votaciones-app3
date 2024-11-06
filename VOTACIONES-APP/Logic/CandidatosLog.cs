﻿using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class CandidatosLog
    {
        // Usamos la clase Candidatos_dat para la lógica de acceso a la base de datos
        Candidatos_dat objCanData = new Candidatos_dat();

        // Método para mostrar todos los candidatos
        public DataSet showCandidatos()
        {
            return objCanData.showCandidatos();
        }

        // Método para guardar un nuevo candidato
        public bool saveCandidato(string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            return objCanData.saveCandidato(nombre, apellido, partido, fechaNacimiento, propuesta);
        }

        // Método para actualizar un candidato
        public bool updateCandidato(int idCandidato, string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            return objCanData.updateCandidato(idCandidato, nombre, apellido, partido, fechaNacimiento, propuesta);
        }

        // Método para eliminar un candidato
        public bool deleteCandidato(int idCandidato)
        {
            return objCanData.deleteCandidato(idCandidato);
        }
        // Método para mostrar los votos y candidatos en formato de lista desplegable (DDL)
        //public DataSet SelectVotosCandidatosDDL()
        //{
        //    return objCanData.SelectVotosCandidatosDDL();
        //}
        //// Método para guardar un voto y candidato en el DDL
        //public bool saveVotoCandidatoDDL(string nombre, string apellido, string cedula, string opcion, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
        //{
        //    objCanData.InsertVotoCandidatoDDL(nombre, apellido, cedula, opcion, canNombre, canApellido, canPartido, canFechaNacimiento, canPropuesta);
        //    return true;
        //}

        //// Método para actualizar un voto y candidato en el DDL
        //public bool updateVotoCandidatoDDL(int votoId, string nombre, string apellido, string cedula, string opcion, int candidatoId, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
        //{
        //    objCanData.UpdateVotoCandidatoDDL(votoId, nombre, apellido, cedula, opcion, candidatoId, canNombre, canApellido, canPartido, canFechaNacimiento, canPropuesta);
        //    return true;
        //}

        //// Método para eliminar un voto y candidato en el DDL
        //public bool DeleteVotoCandidatoDDL(int votoId, int candidatoId)
        //{
        //    objCanData.DeleteVotoCandidatoDDL(votoId, candidatoId);
        //    return true;
        //}

    }
}
