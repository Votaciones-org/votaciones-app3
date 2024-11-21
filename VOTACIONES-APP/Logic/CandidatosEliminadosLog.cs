using System;
using System.Data;
using Data;
using System.Collections.Generic;

namespace Logic
{
    public class CandidatosEliminadosLog
    {
        CandidatosEliminadosDat objCanEliData = new CandidatosEliminadosDat();

        // Método para obtener todos los candidatos eliminados
        public DataSet showCandidatosEliminados()
        {
            return objCanEliData.showCandidatosEliminados(); //Conexion correcta capa datos
        }

        // Método para guardar un nuevo candidato eliminado
        public bool saveCandidatoEliminado(string nombre, string apellido, string partido, DateTime fechaNacimiento, string propuesta)
        {
           // Convertir fechaNacimiento a una cadena con el formato deseado
            string fechaNacimientoStr = fechaNacimiento.ToString("yyyy-MM-dd");

            return objCanEliData.saveCandidatoEliminado(nombre, apellido, partido, fechaNacimientoStr, propuesta);
        }

        // Método para actualizar un candidato eliminado
        public bool updateCandidatoEliminado(int _id, string nombre, string apellido, string partido, DateTime fechaNacimiento, string propuesta)
        {
            string fechaNacimientoStr = fechaNacimiento.ToString("yyyy-MM-dd");

            return objCanEliData.updateCandidatoEliminado(_id, nombre, apellido, partido, fechaNacimientoStr, propuesta);
        }

        // Método para eliminar un candidato eliminado
        public bool deleteCandidatoEliminado(int _id)
        {

            return objCanEliData.deleteCandidatoEliminado(_id);
        }
    }
}