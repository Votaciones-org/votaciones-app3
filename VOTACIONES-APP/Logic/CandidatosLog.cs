<<<<<<< HEAD
<<<<<<< HEAD
﻿using Data;  
using System;
=======
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
﻿using Data;
using System;
using System.Collections.Generic;
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
using System.Data;

namespace Logic
{
    public class CandidatosLog
    {
<<<<<<< HEAD
<<<<<<< HEAD
        // Usamos la clase CandidatoDat para la lógica de acceso a la base de datos
        CandidatoDat objCanData = new CandidatoDat();  // Asegúrate de que el nombre de la clase sea CandidatoDat, no Candidatos_dat
=======
        // Usamos la clase Candidatos_dat para la lógica de acceso a la base de datos
        Candidatos_dat objCanData = new Candidatos_dat();
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
        // Usamos la clase Candidatos_dat para la lógica de acceso a la base de datos
        Candidatos_dat objCanData = new Candidatos_dat();
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378

        // Método para mostrar todos los candidatos
        public DataSet showCandidatos()
        {
<<<<<<< HEAD
<<<<<<< HEAD
            return objCanData.showCandidatos();  // Llamada correcta a la capa de datos
=======
            return objCanData.showCandidatos();
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
            return objCanData.showCandidatos();
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
        }

        // Método para guardar un nuevo candidato
        public bool saveCandidato(string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            return objCanData.saveCandidato(nombre, apellido, partido, fechaNacimiento, propuesta);  // Llamada correcta
=======
            return objCanData.saveCandidato(nombre, apellido, partido, fechaNacimiento, propuesta);
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
            return objCanData.saveCandidato(nombre, apellido, partido, fechaNacimiento, propuesta);
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
        }

        // Método para actualizar un candidato
        public bool updateCandidato(int idCandidato, string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            return objCanData.updateCandidato(idCandidato, nombre, apellido, partido, fechaNacimiento, propuesta);  // Llamada correcta
=======
            return objCanData.updateCandidato(idCandidato, nombre, apellido, partido, fechaNacimiento, propuesta);
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
            return objCanData.updateCandidato(idCandidato, nombre, apellido, partido, fechaNacimiento, propuesta);
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
        }

        // Método para eliminar un candidato
        public bool deleteCandidato(int idCandidato)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            return objCanData.deleteCandidato(idCandidato);  // Llamada correcta
=======
            return objCanData.deleteCandidato(idCandidato);
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
            return objCanData.deleteCandidato(idCandidato);
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
        }
        // Método para mostrar los votos y candidatos en formato de lista desplegable (DDL)
        //public DataSet SelectVotosCandidatosDDL()
        //{
        //    return objCanData.SelectVotosCandidatosDDL();
        //}
        //// Método para guardar un voto y candidato en el DDL
        //public bool saveVotoCandidatoDDL(string nombre, string apellido, string cedula, string opcion, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
        //{
        //    objCanData.InsertVotoCandidatoDDL(nombre, apellido, cedula, opcion, canNombre, canApellido, canPartido, canFechaNacimiento, canPropuesta);
        //    return true;
        //}

<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
        //// Método para actualizar un voto y candidato en el DDL
        //public bool updateVotoCandidatoDDL(int votoId, string nombre, string apellido, string cedula, string opcion, int candidatoId, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
        //{
        //    objCanData.UpdateVotoCandidatoDDL(votoId, nombre, apellido, cedula, opcion, candidatoId, canNombre, canApellido, canPartido, canFechaNacimiento, canPropuesta);
        //    return true;
        //}

        //// Método para eliminar un voto y candidato en el DDL
        //public bool DeleteVotoCandidatoDDL(int votoId, int candidatoId)
        //{
        //    objCanData.DeleteVotoCandidatoDDL(votoId, candidatoId);
        //    return true;
        //}
<<<<<<< HEAD
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378

        //public DataSet SelectVotosCandidatosDDL()
        //{
        //    return objCanData.SelectVotosCandidatosDDL();  // Llamada de método si se requiere.
        //}
        
        //public bool saveVotoCandidatoDDL(string nombre, string apellido, string cedula, string opcion, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
        //{
        //    objCanData.InsertVotoCandidatoDDL(nombre, apellido, cedula, opcion, canNombre, canApellido, canPartido, canFechaNacimiento, canPropuesta);
        //    return true;
        //}
        //public bool updateVotoCandidatoDDL(int votoId, string nombre, string apellido, string cedula, string opcion, int candidatoId, string canNombre, string canApellido, string canPartido, string canFechaNacimiento, string canPropuesta)
        //{
        //    objCanData.UpdateVotoCandidatoDDL(votoId, nombre, apellido, cedula, opcion, candidatoId, canNombre, canApellido, canPartido, canFechaNacimiento, canPropuesta);
        //    return true;
        //}
        //public bool DeleteVotoCandidatoDDL(int votoId, int candidatoId)
        //{
        //    objCanData.DeleteVotoCandidatoDDL(votoId, candidatoId);
        //    return true;
        //}
    }
}
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
