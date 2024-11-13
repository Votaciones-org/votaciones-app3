using Data; // Asegúrate de que la clase Usuarios_dat está en el espacio de nombres Data
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class UsuariosLog
    {
        // Crear la instancia de Usuarios_dat (en lugar de UsuariosLog).
<<<<<<< HEAD
<<<<<<< HEAD
        private UsuarioDat objusu = new UsuarioDat(); // Crear la instancia correcta de la clase que maneja los datos
=======
        private Usuarios_dat objusu = new Usuarios_dat(); // Crear la instancia correcta de la clase que maneja los datos
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
        private Usuarios_dat objusu = new Usuarios_dat(); // Crear la instancia correcta de la clase que maneja los datos
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378

        // Método para mostrar todos los usuarios
        public DataSet showUsuarios()
        {
            return objusu.showUsuarios(); // Llamada correcta al método de la clase Usuarios_dat
        }

        // Método para guardar un nuevo usuario
        public bool saveUsuario(string correo, string contrasena)
        {
            return objusu.saveUsuario(correo, contrasena); // Llamada correcta al método de la clase Usuarios_dat
        }

        // Método para actualizar un usuario
        public bool updateUsuario(int id, string correo, string contrasena)
        {
            return objusu.updateUsuario(id, correo, contrasena); // Llamada correcta al método de la clase Usuarios_dat
        }

        // Método para eliminar un usuario
        public bool deleteUsuario(int id)
        {
            return objusu.deleteUsuario(id); // Llamada correcta al método de la clase Usuarios_dat
        }
        // Método para obtener los votos de los usuarios en formato de lista desplegable (DDL)
        //public DataTable showVotosUsuariosDDL()
        //{
        //    return objusu.showVotosUsuariosDDL(); // Llamada correcta al método de la clase Usuarios_dat
        //}

        //// Método para guardar un voto de un usuario en el DDL
        //public bool saveVotoUsuarioDDL(string nombre, string apellido, string cedula, string opcion, string correo, string contrasena)
        //{
        //    objusu.UsuarioVotoRepository.InsertVotoUsuarioDDL(nombre, apellido, cedula, opcion, correo, contrasena);
        //    return true; // Asumimos que la operación se realiza correctamente
        //}

        //// Método para actualizar un voto de un usuario en el DDL
        //public bool updateVotoUsuarioDDL(int votoId, string nombre, string apellido, string cedula, string opcion, int usuarioId, string correo, string contrasena)
        //{
        //    objusu.UsuarioVotoRepository.UpdateVotoUsuarioDDL(votoId, nombre, apellido, cedula, opcion, usuarioId, correo, contrasena);
        //    return true; // Asumimos que la operación se realiza correctamente
        //}

        //// Método para eliminar un voto de un usuario en el DDL
        //public bool deleteVotoUsuarioDDL(int votoId, int usuarioId)
        //{
        //    objusu.UsuarioVotoRepository.DeleteVotoUsuarioDDL(votoId, usuarioId);
        //    return true; // Asumimos que la operación se realiza correctamente
        //}
    
    }
}
