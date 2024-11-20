using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class AWCandidatos_eliminados : System.Web.UI.Page
    {
        // Lista estática para simular los candidatos eliminados
        private static List<Candidato> candidatosEliminados = new List<Candidato>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCandidatosEliminados();
            }
        }

        // Simula la carga de candidatos eliminados
        private void CargarCandidatosEliminados()
        {
            try
            {
                GVCandidatosEliminados.DataSource = candidatosEliminados;
                GVCandidatosEliminados.DataBind();
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error al cargar los candidatos eliminados: " + ex.Message;
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Guardar un nuevo candidato
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevoCandidato = new Candidato
                {
                    Id = candidatosEliminados.Count + 1, // Asignar un ID único
                    Nombre = TBNombre.Text,
                    Apellido = TBApellido.Text,
                    Partido = TBPartido.Text,
                    FechaNacimiento = DateTime.Parse(TBFechaNacimiento.Text),
                    Propuesta = TBPropuesta.Text
                };

                candidatosEliminados.Add(nuevoCandidato);
                LblMsj.Text = "Candidato guardado exitosamente.";
                LblMsj.ForeColor = System.Drawing.Color.Green;
                CargarCandidatosEliminados();
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error al guardar el candidato: " + ex.Message;
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Actualizar un candidato
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(LblId.Text);
                var candidatoActualizado = candidatosEliminados.Find(c => c.Id == id);

                if (candidatoActualizado != null)
                {
                    candidatoActualizado.Nombre = TBNombre.Text;
                    candidatoActualizado.Apellido = TBApellido.Text;
                    candidatoActualizado.Partido = TBPartido.Text;
                    candidatoActualizado.FechaNacimiento = DateTime.Parse(TBFechaNacimiento.Text);
                    candidatoActualizado.Propuesta = TBPropuesta.Text;

                    LblMsj.Text = "Candidato actualizado exitosamente.";
                    LblMsj.ForeColor = System.Drawing.Color.Green;
                    CargarCandidatosEliminados();
                }
                else
                {
                    LblMsj.Text = "Candidato no encontrado.";
                    LblMsj.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error al actualizar el candidato: " + ex.Message;
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Eliminar un candidato
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(LblId.Text, out int id))
                {
                    var candidatoAEliminar = candidatosEliminados.Find(c => c.Id == id);
                    if (candidatoAEliminar != null)
                    {
                        candidatosEliminados.Remove(candidatoAEliminar);
                        LblMsj.Text = "Candidato eliminado exitosamente.";
                        LblMsj.ForeColor = System.Drawing.Color.Green;
                        CargarCandidatosEliminados();
                    }
                    else
                    {
                        LblMsj.Text = "Candidato no encontrado.";
                        LblMsj.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    LblMsj.Text = "ID inválido.";
                    LblMsj.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error al eliminar el candidato: " + ex.Message;
                LblMsj.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Seleccionar un candidato desde la GridView
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

    // Clase Candidato (puedes colocarla en otro archivo si lo prefieres)
    public class Candidato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Partido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Propuesta { get; set; }
    }
}

