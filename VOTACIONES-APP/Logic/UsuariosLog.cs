using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class UsuariosLog
    {
        UsuariosLog objusu = new UsuariosLog();

        public DataSet showUsuarios()
        {
            return objusu.showUsuarios();
        }
        public bool saveUsuario(string correo, string contrasena)
        {
            return objusu.saveUsuario(correo, contrasena);
        }
        public bool updateUsuario(int id, string correo, string contrasena)
        {
            return objusu.updateUsuario(id,correo,contrasena);
        }
        public bool deleteUsuario(int id)
        {
            return objusu.deleteUsuario(id);
        }
        public DataTable showVotosUsuariosDDL()
    {
        return objusu.SelectVotosUsuariosDDL();
    }

    public bool saveVotoUsuarioDDL(string nombre, string apellido, string cedula, string opcion, string correo, string contrasena)
    {
        objusu.InsertVotoUsuarioDDL(nombre, apellido, cedula, opcion, correo, contrasena);
        return true;
    }

    public bool updateVotoUsuarioDDL(int votoId, string nombre, string apellido, string cedula, string opcion, int usuarioId, string correo, string contrasena)
    {
        objusu.UpdateVotoUsuarioDDL(votoId, nombre, apellido, cedula, opcion, usuarioId, correo, contrasena);
        return true;
    }

    public bool deleteVotoUsuarioDDL(int votoId, int usuarioId)
    {
        objusu.DeleteVotoUsuarioDDL(votoId, usuarioId);
        return true;
    }

    }
}