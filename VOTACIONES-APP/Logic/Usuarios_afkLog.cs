using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class Usuarios_afkLog
    {
        Usuarios_afkLog objAFK = new Usuarios_afkLog();

        public DataSet showUsuariosAfk()
        {
            return objAFK.showUsuariosAfk();
        }
        public bool saveUsuarioAfk(string correo, string contrasena)
        {
            return objAFK.saveUsuarioAfk(correo, contrasena);
        }
        public bool updateUsuarioAfk(int id, string correo, string contrasena)
        {
            return objAFK.updateUsuarioAfk(id,correo, contrasena);
        }
        public bool deleteUsuarioAfk(int id)
        {
            return objAFK.deleteUsuarioAfk(id);
        }
        public DataTable showVotosUsuariosAfkDDL()
        {
            return objAFK.SelectVotosUsuariosAfkDDL();
        }

        public bool saveVotoUsuarioAfkDDL(string nombre, string apellido, string cedula, string opcion, string correo, string contrasena)
        {
            objAFK.InsertVotoUsuarioAfkDDL(nombre, apellido, cedula, opcion, correo, contrasena);
            return true;
        }

        public bool updateVotoUsuarioAfkDDL(int votoId, string nombre, string apellido, string cedula, string opcion, int usuarioId, string correo, string contrasena)
        {
            objAFK.UpdateVotoUsuarioAfkDDL(votoId, nombre, apellido, cedula, opcion, usuarioId, correo, contrasena);
            return true;
        }

        public bool deleteVotoUsuarioAfkDDL(int votoId, int usuarioId)
        {
            objAFK.DeleteVotoUsuarioAfkDDL(votoId, usuarioId);
            return true;
        }
    }
}