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


    }
}