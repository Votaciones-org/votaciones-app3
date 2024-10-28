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

    }
}