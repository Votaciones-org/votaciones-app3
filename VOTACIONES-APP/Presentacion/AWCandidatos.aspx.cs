using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;  // Asegúrate de que esta referencia sea la correcta para tu capa lógica

namespace Presentation
{
    public partial class AWCandidatos : System.Web.UI.Page
    {
        // Instancia de la capa lógica para los candidatos
        CandidatosLog objCand = new CandidatosLog();
        private int _idCandidato;
        private string _nombre, _apellido, _partido, _fechaNacimiento, _propuesta;
        private bool executed = false;

        // Cargar la página y mostrar los candidatos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showCandidatos(); // Cargar todos los candidatos en el GridView
            }
        }

        // Método para mostrar todos los candidatos en el GridView
        private void showCandidatos()
        {
            try
            {
                // Llamada al método de la capa lógica
                DataSet ds = objCand.showCandidatos();

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Asignamos los datos al GridView
                    GVCandidatos.DataSource = ds.Tables[0];
                    GVCandidatos.DataBind();
                }
                else
                {
                    LblMensaje.Text = "No se encontraron candidatos.";
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lo mostramos
                LblMensaje.Text = "Error al cargar los candidatos: " + ex.Message;
            }
        }

        // Limpiar los campos de texto y el campo oculto
        private void clear()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtPartido.Text = "";
            txtFechaNacimiento.Text = "";
            txtPropuesta.Text = "";
            HFCandidatoId.Value = "";
        }

        // Evento para guardar un nuevo candidato
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nombre = txtNombre.Text;
            _apellido = txtApellido.Text;
            _partido = txtPartido.Text;
            _fechaNacimiento = txtFechaNacimiento.Text;
            _propuesta = txtPropuesta.Text;

            // Llamada al método para guardar el candidato
            executed = objCand.saveCandidato(_nombre, _apellido, _partido, _fechaNacimiento, _propuesta);

            if (executed)
            {
                LblMensaje.Text = "Candidato guardado exitosamente!";
                clear(); // Limpiar los campos
                showCandidatos(); // Actualizar el GridView
            }
            else
            {
                LblMensaje.Text = "Error al guardar el candidato!";
            }
        }

        // Evento para actualizar un candidato existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idCandidato = Convert.ToInt32(HFCandidatoId.Value);
            _nombre = txtNombre.Text;
            _apellido = txtApellido.Text;
            _partido = txtPartido.Text;
            _fechaNacimiento = txtFechaNacimiento.Text;
            _propuesta = txtPropuesta.Text;

            // Llamada al método para actualizar el candidato
            executed = objCand.updateCandidato(_idCandidato, _nombre, _apellido, _partido, _fechaNacimiento, _propuesta);

            if (executed)
            {
                LblMensaje.Text = "Candidato actualizado exitosamente!";
                clear(); // Limpiar los campos
                showCandidatos(); // Actualizar el GridView
            }
            else
            {
                LblMensaje.Text = "Error al actualizar el candidato!";
            }
        }

        // Evento cuando se selecciona un candidato desde el GridView
        protected void GVCandidatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener los valores de la fila seleccionada y asignarlos a los campos
            GridViewRow row = GVCandidatos.SelectedRow;
            HFCandidatoId.Value = row.Cells[0].Text; // ID del candidato
            txtNombre.Text = row.Cells[1].Text; // Nombre
            txtApellido.Text = row.Cells[2].Text; // Apellido
            txtPartido.Text = row.Cells[3].Text; // Partido
            txtFechaNacimiento.Text = row.Cells[4].Text; // Fecha de Nacimiento
            txtPropuesta.Text = row.Cells[5].Text; // Propuesta

            // Mostrar el botón de "Actualizar" y ocultar el de "Guardar"
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
        }

        // Evento para eliminar un candidato desde el GridView
        protected void GVCandidatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                _idCandidato = Convert.ToInt32(GVCandidatos.DataKeys[rowIndex].Value);

                // Llamada al método para eliminar el candidato
                executed = objCand.deleteCandidato(_idCandidato);

                if (executed)
                {
                    LblMensaje.Text = "Candidato eliminado exitosamente!";
                    showCandidatos(); // Actualizar el GridView
                }
                else
                {
                    LblMensaje.Text = "Error al eliminar el candidato!";
                }
            }
        }
    }
}

