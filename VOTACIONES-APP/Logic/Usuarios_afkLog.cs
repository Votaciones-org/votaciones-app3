using Data;
using System;
using System.Data;

namespace Logic
{
    public class UsuariosAfkLog
    {

        // Crear una instancia de la clase de datos (UsuariosAfkDat).
        private UsuariosAfkDat objAfkDat = new UsuariosAfkDat();  // Corregido el nombre de la clase a UsuariosAfkDat.

       

        // Método para mostrar los usuarios AFK.
        public DataSet showUsuariosAfk()
        {

            return objAfkDat.showUsuariosAfk();  // Llamando al método correcto de la capa de datos.
        }

        // Método para guardar un nuevo usuario AFK.
        public bool saveUsuariosAfk(string correo, string contrasena)
        {
            return objAfkDat.saveUsuariosAfk(correo, contrasena);  // Llamando al método correcto de la capa de datos.
        }

        // Método para actualizar un usuario AFK.
        public bool updateUsuariosAfk(int id, string correo, string contrasena)
        {
            return objAfkDat.updateUsuariosAfk(id, correo, contrasena);  // Llamando al método correcto de la capa de datos.
        }

        // Método para eliminar un usuario AFK.
        public bool deleteUsuariosAfk(int id)
        {
            return objAfkDat.deleteUsuariosAfk(id);  // Llamando al método correcto de la capa de datos.
        }
    }
}