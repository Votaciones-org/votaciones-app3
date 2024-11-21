using Data;  
using System;
using System.Collections.Generic;

using System.Data;

namespace Logic
{
    public class CandidatosLog
    {

        // Usamos la clase CandidatoDat para la lógica de acceso a la base de datos
        CandidatoDat objCanData = new CandidatoDat();  // Asegúrate de que el nombre de la clase sea CandidatoDat, no Candidatos_dat

        // Método para mostrar todos los candidatos
        public DataSet showCandidatos()
        {

            return objCanData.showCandidatos();  // Llamada correcta a la capa de datos

            
        }

        // Método para guardar un nuevo candidato
        public bool saveCandidato(string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {

            return objCanData.saveCandidato(nombre, apellido, partido, fechaNacimiento, propuesta);  // Llamada correcta


        }

        // Método para actualizar un candidato
        public bool updateCandidato(int idCandidato, string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {

            return objCanData.updateCandidato(idCandidato, nombre, apellido, partido, fechaNacimiento, propuesta);  // Llamada correcta

            
        }

        // Método para eliminar un candidato
        public bool deleteCandidato(int idCandidato)
        {

            return objCanData.DeleteCandidato(idCandidato);  // Llamada correcta

        }   

        }
}

