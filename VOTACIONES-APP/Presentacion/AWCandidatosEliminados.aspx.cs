using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;



namespace Presentation
{
    public partial class AWCandidatosEliminados : System.Web.UI.Page
    {
        // Instancia de la capa lógica para los candidatos eliminados
        CandidatosEliminadosLog objCand = new CandidatosEliminadosLog();
        

        // Cargar la página y mostrar los candidatos eliminados
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showCandidatosEliminados(); // Cargar los candidatos eliminados en el GridView
            }
        }

        // Método para mostrar todos los candidatos eliminados en el GridView
        private void showCandidatosEliminados()
        {
            try
            {
                // Llamada al método de la capa lógica
                DataSet ds = objCand.showCandidatosEliminados();

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Asignamos los datos al GridView
                    GVCandidatosEliminados.DataSource = ds.Tables[0];
                    GVCandidatosEliminados.DataBind();
                }
                else
                {
                    LblMsj.Text = "No se encontraron candidatos eliminados.";
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lo mostramos
                LblMsj.Text = "Error al cargar los candidatos eliminados: " + ex.Message;
            }
        }

        // Evento cuando se selecciona un candidato eliminado desde el GridView
        protected void GVCandidatosEliminados_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener los valores de la fila seleccionada y asignarlos a los campos
            GridViewRow row = GVCandidatosEliminados.SelectedRow;
            LblId.Text = row.Cells[0].Text; // ID del candidato
            TBNombre.Text = row.Cells[1].Text; // Nombre
            TBApellido.Text = row.Cells[2].Text; // Apellido
            TBPartido.Text = row.Cells[3].Text; // Partido
            TBFechaNacimiento.Text = row.Cells[4].Text; // Fecha de Nacimiento
            TBPropuesta.Text = row.Cells[5].Text; // Propuesta
        }
    }
}

