using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class Usuarios_No_votantesLog
    {
        Usuarios_No_votantesLog objNO = new Usuarios_No_votantesLog();

        public DataSet showUsuariosNoVotantes()
        {
            return objNO.showUsuariosNoVotantes();
        }
        public bool saveUsuarioNoVotante(string nombre, string apellido, string cedula, string opcion)
        {
            return objNO.saveUsuarioNoVotante(nombre, apellido, cedula, opcion);
        }
        public bool updateUsuarioNoVotante(int id, string nombre, string apellido, string cedula, string opcion)
        {
            return objNO.updateUsuarioNoVotante(id,nombre,apellido,cedula,opcion);
        }
        public bool deleteUsuarioNoVotante(int id)
        {
            return objNO.deleteUsuarioNoVotante(id);
        }
        public DataTable showVotosUsuariosNoVotantesDDL()
        {
            return objNO.SelectVotosUsuariosNoVotantesDDL();
        }

        public bool saveUsuarioNoVotante(string nombre, string apellido, string cedula, string opcion)
        {
            objNO.InsertVotoUsuarioNoVotanteDDL(nombre, apellido, cedula, opcion);
            return true;
        }

        public bool updateUsuarioNoVotante(int votoId, string nombre, string apellido, string cedula, string opcion, int usuarioNoId)
        {
            objNO.UpdateVotoUsuarioNoVotanteDDL(votoId, nombre, apellido, cedula, opcion, usuarioNoId);
            return true;
        }

        public bool deleteUsuarioNoVotante(int votoId, int usuarioNoId)
        {
            objNO.DeleteVotoUsuarioNoVotanteDDL(votoId, usuarioNoId);
            return true;
        }
    }
}