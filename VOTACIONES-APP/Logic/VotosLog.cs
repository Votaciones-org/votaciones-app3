using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class VotosLog
    {
        Persistence objVot = new Persistence();

        public DataSet showVotes()
        {
            
            return objVot.showVotes();
        }
        
        public bool saveVote(string _nombre, string _apellido, string _cedula, string _opcion)
        {

            return objVot.saveVote(_nombre, _apellido, _cedula, _opcion);
        }
        
        public bool updateVote(int _id, string _nombre, string _apellido, string _cedula, string _opcion)
        {

            return objVot.updateVote(_id, _nombre, _apellido, _cedula, _opcion);
        }
    }
}