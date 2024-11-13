using System;
using System.Data;
<<<<<<< HEAD
using Data;  // Importa el espacio de nombres de la capa de datos
=======
using System.Linq;
using System.Web;
using Data;  // Import the Data namespace where the 'Usuarios_no_votantes' class is defined.
<<<<<<< HEAD
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378

namespace Logic
{
    public class Usuarios_No_votantesLog
    {
<<<<<<< HEAD
<<<<<<< HEAD
        // Se crea una instancia de la clase de la capa de datos para interactuar con la base de datos.
        private UsuariosNoVotantesDat objNO = new UsuariosNoVotantesDat();

        // Método para mostrar los usuarios no votantes desde la base de datos.
=======
        // Create an instance of the Data layer's class to interact with the database.
        private Usuarios_no_votantes objNO = new Usuarios_no_votantes();

        // Method to show records from the usuarios_no_votantes table.
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
        // Create an instance of the Data layer's class to interact with the database.
        private Usuarios_no_votantes objNO = new Usuarios_no_votantes();

        // Method to show records from the usuarios_no_votantes table.
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
        public DataSet ShowUsuariosNoVotantes()
        {
            return objNO.showUsuariosNoVotantes();
        }

<<<<<<< HEAD
<<<<<<< HEAD
        // Método para guardar un nuevo usuario no votante.
=======
        // Method to save a new usuario_no_votante record.
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
        // Method to save a new usuario_no_votante record.
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
        public bool SaveUsuarioNoVotante(string nombre, string apellido, string cedula, string opcion)
        {
            return objNO.saveUsuarioNoVotante(nombre, apellido, cedula, opcion);
        }

<<<<<<< HEAD
<<<<<<< HEAD
        // Método para actualizar un usuario no votante existente.
=======
        // Method to update an existing usuario_no_votante record.
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
        // Method to update an existing usuario_no_votante record.
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
        public bool UpdateUsuarioNoVotante(int id, string nombre, string apellido, string cedula, string opcion)
        {
            return objNO.updateUsuarioNoVotante(id, nombre, apellido, cedula, opcion);
        }

<<<<<<< HEAD
<<<<<<< HEAD
        // Método para eliminar un usuario no votante.
=======
        // Method to delete a usuario_no_votante record.
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
        // Method to delete a usuario_no_votante record.
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
        public bool DeleteUsuarioNoVotante(int id)
        {
            return objNO.deleteUsuarioNoVotante(id);
        }
<<<<<<< HEAD
<<<<<<< HEAD
    }
}

=======
        // Method to show votos and usuarios_no_votantes (a combined view).
        //public DataTable ShowVotosUsuariosNoVotantesDDL()
        //{
        //    return objNO.showVotosUsuariosNoVotantesDDL();
        //}

        //// Method to save a vote and associate it with a usuario_no_votante.
        //public bool SaveVotoUsuarioNoVotante(string nombre, string apellido, string cedula, string opcion)
        //{
        //    try
        //    {
        //        objNO.UsuarioNoVotanteVotoRepository insertRepo = new objNO.UsuarioNoVotanteVotoRepository();
        //        insertRepo.InsertVotoUsuarioNoVotanteDDL(nombre, apellido, cedula, opcion);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log exception or handle error.
        //        Console.WriteLine($"Error: {ex.Message}");
        //        return false;
        //    }
        //}

        //// Method to update a vote and the associated usuario_no_votante.
        //public bool UpdateVotoUsuarioNoVotante(int votoId, string nombre, string apellido, string cedula, string opcion, int usuarioNoId)
        //{
        //    try
        //    {
        //        objNO.UsuarioNoVotanteVotoRepository updateRepo = new objNO.UsuarioNoVotanteVotoRepository();
        //        updateRepo.UpdateVotoUsuarioNoVotanteDDL(votoId, nombre, apellido, cedula, opcion, usuarioNoId);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log exception or handle error.
        //        Console.WriteLine($"Error: {ex.Message}");
        //        return false;
        //    }
        //}

        //// Method to delete a vote and its associated usuario_no_votante.
        //public bool DeleteVotoUsuarioNoVotante(int votoId, int usuarioNoId)
        //{
        //    try
        //    {
        //        objNO.UsuarioNoVotanteVotoRepository deleteRepo = new objNO.UsuarioNoVotanteVotoRepository();
        //        deleteRepo.DeleteVotoUsuarioNoVotanteDDL(votoId, usuarioNoId);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log exception or handle error.
        //        Console.WriteLine($"Error: {ex.Message}");
        //        return false;
        //    }
        //}
    }
}
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
        // Method to show votos and usuarios_no_votantes (a combined view).
        //public DataTable ShowVotosUsuariosNoVotantesDDL()
        //{
        //    return objNO.showVotosUsuariosNoVotantesDDL();
        //}

        //// Method to save a vote and associate it with a usuario_no_votante.
        //public bool SaveVotoUsuarioNoVotante(string nombre, string apellido, string cedula, string opcion)
        //{
        //    try
        //    {
        //        objNO.UsuarioNoVotanteVotoRepository insertRepo = new objNO.UsuarioNoVotanteVotoRepository();
        //        insertRepo.InsertVotoUsuarioNoVotanteDDL(nombre, apellido, cedula, opcion);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log exception or handle error.
        //        Console.WriteLine($"Error: {ex.Message}");
        //        return false;
        //    }
        //}

        //// Method to update a vote and the associated usuario_no_votante.
        //public bool UpdateVotoUsuarioNoVotante(int votoId, string nombre, string apellido, string cedula, string opcion, int usuarioNoId)
        //{
        //    try
        //    {
        //        objNO.UsuarioNoVotanteVotoRepository updateRepo = new objNO.UsuarioNoVotanteVotoRepository();
        //        updateRepo.UpdateVotoUsuarioNoVotanteDDL(votoId, nombre, apellido, cedula, opcion, usuarioNoId);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log exception or handle error.
        //        Console.WriteLine($"Error: {ex.Message}");
        //        return false;
        //    }
        //}

        //// Method to delete a vote and its associated usuario_no_votante.
        //public bool DeleteVotoUsuarioNoVotante(int votoId, int usuarioNoId)
        //{
        //    try
        //    {
        //        objNO.UsuarioNoVotanteVotoRepository deleteRepo = new objNO.UsuarioNoVotanteVotoRepository();
        //        deleteRepo.DeleteVotoUsuarioNoVotanteDDL(votoId, usuarioNoId);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log exception or handle error.
        //        Console.WriteLine($"Error: {ex.Message}");
        //        return false;
        //    }
        //}
    }
}
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
