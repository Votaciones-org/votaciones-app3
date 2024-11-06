using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Runtime.Remoting;

namespace Logic
{
    public class VotosLog
    {
        // Create an instance of the Persistence class to manage the database connection.
        Persistence objVot = new Persistence();

        // Method to show votes from the database.
        public DataSet showVotes()
        {
            return objVot.showVotes();
        }

        // Method to save a new vote
        public bool saveVote(string _nombre, string _apellido, string _cedula, string _opcion)
        {

            return objVot.saveVote(_nombre, _apellido, _cedula, _opcion);
        }

        // Method to update a vote
        public bool updateVote(int _id, string _nombre, string _apellido, string _cedula, string _opcion)
        {

            return objVot.updateVote( _id, _nombre, _apellido, _cedula, _opcion);
        }
    }
}