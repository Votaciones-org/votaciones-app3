using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class PartidosLog
    {
        PartidosDat _dat = new PartidosDat();

        public DataTable GetPartidosWithCandidatos()
        {

            return _dat.GetPartidosWithCandidatos();
        }

        public bool InsertPartidoCandidato(string partidoName, string partidoDescription, string candidatoName, string candidatoSurname, DateTime candidatoBirthDate, string candidatoProposal)
        {

                return _dat.InsertPartidoCandidato(partidoName, partidoDescription, candidatoName, candidatoSurname, candidatoBirthDate, candidatoProposal);
           
        }

        public bool UpdatePartidoCandidato(int partidoId, string partidoName, string partidoDescription, int candidatoId, string candidatoName, string candidatoSurname, DateTime candidatoBirthDate, string candidatoProposal)
        {

                return _dat.UpdatePartidoCandidato(partidoId, partidoName, partidoDescription, candidatoId, candidatoName, candidatoSurname, candidatoBirthDate, candidatoProposal);
        }

        public bool DeletePartidoCandidato(int partidoId, int candidatoId)
        {

                return _dat.DeletePartidoCandidato(partidoId, candidatoId);
            }
        }
    }

