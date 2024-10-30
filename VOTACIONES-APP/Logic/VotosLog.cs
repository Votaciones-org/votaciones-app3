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

<<<<<<< HEAD
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
            
=======

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

>>>>>>> 9cc09343b2dea2c78f8895ab9a9e349672bc826b
            return objVot.updateVote(_id, _nombre, _apellido, _cedula, _opcion);
        }
    }
}