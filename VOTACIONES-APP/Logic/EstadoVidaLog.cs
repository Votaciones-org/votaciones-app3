using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;


namespace Logic
{
    public class EstadoVidaLog
    {
        EstadoVidaDat objEsViData = new EstadoVidaDat(); // Instancia de la capa de datos

        // Método para obtener todos los registros de tbl_estado_vida
        public DataSet showEstadoVida()
        {
            // Llama al método de la capa de datos para obtener registros
            return objEsViData.showEstadoVida();
            
        }

        // Método para guardar un nuevo registro
        public bool AddEstadoVida(string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            // Llama al método de la capa de datos para guardar
            return objEsViData.saveEstadoVida(nombre, apellido, cedula, estado, fechaDefuncion);
           
        }

        // Método para actualizar un registro existente
        public bool UpdateEstadoVida(int _id, string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            // Llama al método de la capa de datos para actualizar
            return objEsViData.updateEstadoVida(_id, nombre, apellido, cedula, estado, fechaDefuncion);
            
        }

        // Método para eliminar un registro existente
        public bool DeleteEstadoVida(int _id)
        {
            // Llama al método de la capa de datos para eliminar
            return objEsViData.deleteEstadoVida(_id);
        }
    }
}