using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class UsuariosAfkLog
    {
        // Crear una instancia de la clase de datos (Usuarios_afk_dat).
        private Data.Usuarios_afk_dat objAfkDat = new Data.Usuarios_afk_dat();

        // Método para mostrar los usuarios AFK.
        public DataSet showUsuariosAfk()
        {
            return objAfkDat.showUsuariosAfk();
        }

        // Método para guardar un nuevo usuario AFK.
        public bool saveUsuarioAfk(string correo, string contrasena)
        {
            return objAfkDat.saveUsuarioAfk(correo, contrasena);
        }

        // Método para actualizar un usuario AFK.
        public bool updateUsuarioAfk(int id, string correo, string contrasena)
        {
            return objAfkDat.updateUsuarioAfk(id, correo, contrasena);
        }

        // Método para eliminar un usuario AFK.
        public bool deleteUsuarioAfk(int id)
        {
            return objAfkDat.deleteUsuarioAfk(id);
        }

        //// Método para mostrar los votos y usuarios AFK.
        //public DataTable showVotosUsuariosAfkDDL()
        //{
        //    return objAfkDat.UsuarioAfkVotoRepository.SelectVotosUsuariosAfkDDL();
        //}

        //// Método para guardar un voto y un usuario AFK.
        //public bool saveVotoUsuarioAfkDDL(string nombre, string apellido, string cedula, string opcion, string correo, string contrasena)
        //{
        //    objAfkDat.UsuarioAfkVotoRepository.InsertVotoUsuarioAfkDDL(nombre, apellido, cedula, opcion, correo, contrasena);
        //    return true;
        //}

        //// Método para actualizar un voto y un usuario AFK.
        //public bool updateVotoUsuarioAfkDDL(int votoId, string nombre, string apellido, string cedula, string opcion, int usuarioId, string correo, string contrasena)
        //{
        //    objAfkDat.UsuarioAfkVotoRepository.UpdateVotoUsuarioAfkDDL(votoId, nombre, apellido, cedula, opcion, usuarioId, correo, contrasena);
        //    return true;
        //}

        //// Método para eliminar un voto y un usuario AFK.
        //public bool deleteVotoUsuarioAfkDDL(int votoId, int usuarioId)
        //{
        //    objAfkDat.UsuarioAfkVotoRepository.DeleteVotoUsuarioAfkDDL(votoId, usuarioId);
        //    return true;
        //}
    }
}
