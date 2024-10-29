using System;
using System.Data;

namespace Logic
{
    internal class Persistence
    {
        internal bool deleteCandidatoEliminado(int id)
        {
            throw new NotImplementedException();
        }

        internal bool deleteEstadoVida(int id)
        {
            throw new NotImplementedException();
        }

        internal bool saveCandidatoEliminado(string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            throw new NotImplementedException();
        }

        internal bool saveEstadoVida(string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            throw new NotImplementedException();
        }

        internal DataSet showCandidatosEliminados()
        {
            throw new NotImplementedException();
        }

        internal DataSet showEstadoVida()
        {
            throw new NotImplementedException();
        }

        internal bool updateCandidatoEliminado(int id, string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            throw new NotImplementedException();
        }

        internal bool updateEstadoVida(int id, string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            throw new NotImplementedException();
        }
    }
}