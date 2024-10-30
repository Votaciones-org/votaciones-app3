using Data;

using System.Data;


namespace Logic
{
    public class Estado_vidaLog
    {         Persistence objEsV = new Persistence();

        public DataSet showEstadoVida()
        {

            return objEsV.showEstadoVida();
        }

        public bool saveEstadoVida(string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            return objEsV.saveEstadoVida(nombre, apellido, cedula, estado, fechaDefuncion);
        }


        public bool updateEstadoVida(int id, string nombre, string apellido, string cedula, string estado, string fechaDefuncion)
        {
            return objEsV.updateEstadoVida(id, nombre, apellido, cedula, estado, fechaDefuncion);
        }

        public bool deleteEstadoVida(int id)
        {
            return objEsV.deleteEstadoVida(id);
        }
    }
}