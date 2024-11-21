using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class PartidosLog
    {
        PartidosDat objPar = new PartidosDat(); // Instancia de Persistence para manejar la conexión

        // Método para mostrar los partidos desde la base de datos.
        public DataSet showPartidos()
        {

            return objPar.showPartidos();
        }

        // Método para guardar un nuevo partido en la base de datos.
        public bool savePartido(string partidoNombre, string partidoDescripcion, int candidatoId, int eliminadoId)
        {

            return objPar.savePartido(partidoNombre, partidoDescripcion, candidatoId, eliminadoId);
        }

        // Método para actualizar un partido existente.
        public bool updatePartido(int partidoId, string partidoNombre, string partidoDescripcion, int candidatoId, int eliminadoId)
        {

            return objPar.updatePartido(partidoId, partidoNombre, partidoDescripcion, candidatoId, eliminadoId);
                
        }

        // Método para borrar un partido.
        public bool deletePartido(int partidoId)
        {
            return objPar.deletePartido(partidoId);
        }
    }
}
