using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class AWCandidatos_eliminados : System.Web.UI.Page
    {

            private CandidatosService _candidatosService;

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    CargarCandidatosEliminados();
                }
            }

            private void CargarCandidatosEliminados()
            {
                // Aquí se llama a la capa de lógica para obtener los candidatos eliminados
                var candidatosEliminados = _candidatosService.ObtenerCandidatosEliminados();
                GVCandidatosEliminados.DataSource = candidatosEliminados;
                GVCandidatosEliminados.DataBind();
            }

            protected void BtnSave_Click(object sender, EventArgs e)
            {
                var nuevoCandidato = new Candidato
                {
                    Nombre = TBNombre.Text,
                    Apellido = TBApellido.Text,
                    Partido = TBPartido.Text,
                    FechaNacimiento = DateTime.Parse(TBFechaNacimiento.Text),
                    Propuesta = TBPropuesta.Text
                };

                _candidatosService.AgregarCandidato(nuevoCandidato);
                LblMsj.Text = "Candidato guardado exitosamente.";
                CargarCandidatosEliminados();
            }

            protected void BtnUpdate_Click(object sender, EventArgs e)
            {
                var candidatoActualizado = new Candidato
                {
                    Id = int.Parse(LblId.Text),
                    Nombre = TBNombre.Text,
                    Apellido = TBApellido.Text,
                    Partido = TBPartido.Text,
                    FechaNacimiento = DateTime.Parse(TBFechaNacimiento.Text),
                    Propuesta = TBPropuesta.Text
                };

                _candidatosService.ActualizarCandidato(candidatoActualizado);
                LblMsj.Text = "Candidato actualizado exitosamente.";
                CargarCandidatosEliminados();
            }

            protected void BtnDelete_Click(object sender, EventArgs e)
            {
                if (int.TryParse(LblId.Text, out int id))
                {
                    _candidatosService.EliminarCandidato(id);
                    LblMsj.Text = "Candidato eliminado exitosamente.";
                    CargarCandidatosEliminados();
                }
            }

            protected void GVCandidatosEliminados_SelectedIndexChanged(object sender, EventArgs e)
            {
                GridViewRow filaSeleccionada = GVCandidatosEliminados.SelectedRow;
                LblId.Text = filaSeleccionada.Cells[0].Text; // Asumiendo que la ID está en la primera celda
                TBNombre.Text = filaSeleccionada.Cells[1].Text;
                TBApellido.Text = filaSeleccionada.Cells[2].Text;
                TBPartido.Text = filaSeleccionada.Cells[3].Text;
                TBFechaNacimiento.Text = filaSeleccionada.Cells[4].Text;
                TBPropuesta.Text = filaSeleccionada.Cells[5].Text;
            }
        }
}