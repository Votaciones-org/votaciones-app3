using System;
using System.Data;

using Data;  // Importa el espacio de nombres de la capa de datos

using System.Linq;
using System.Web;
 

namespace Logic
{
    public class Usuarios_No_votantesLog
    {

        // Se crea una instancia de la clase de la capa de datos para interactuar con la base de datos.
        private UsuariosNoVotantesDat objNO = new UsuariosNoVotantesDat();

  
        public DataSet ShowUsuariosNoVotantes()
        {
            return objNO.showUsuariosNoVotantes();
        }

        public bool SaveUsuarioNoVotante(string nombre, string apellido, string cedula, string opcion)
        {
            return objNO.saveUsuarioNoVotante(nombre, apellido, cedula, opcion);
        }

        public bool UpdateUsuarioNoVotante(int id, string nombre, string apellido, string cedula, string opcion)
        {
            return objNO.updateUsuarioNoVotante(id, nombre, apellido, cedula, opcion);
        }


        public bool DeleteUsuarioNoVotante(int id)
        {
            return objNO.deleteUsuarioNoVotante(id);
        }

    }
}


