using Data;
using System;
using System.Data;

namespace Logic
{
    public class UsuariosAfkLog
    {
<<<<<<< HEAD
<<<<<<< HEAD
        // Crear una instancia de la clase de datos (UsuariosAfkDat).
        private UsuariosAfkDat objAfkDat = new UsuariosAfkDat();  // Corregido el nombre de la clase a UsuariosAfkDat.
=======
        // Crear una instancia de la clase de datos (Usuarios_afk_dat).
        private Data.Usuarios_afk_dat objAfkDat = new Data.Usuarios_afk_dat();
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
        // Crear una instancia de la clase de datos (Usuarios_afk_dat).
        private Data.Usuarios_afk_dat objAfkDat = new Data.Usuarios_afk_dat();
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378

        // Método para mostrar los usuarios AFK.
        public DataSet showUsuariosAfk()
        {
<<<<<<< HEAD
<<<<<<< HEAD
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

=======
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
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
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
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
