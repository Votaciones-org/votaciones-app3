using Logic;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFCandidatos : System.Web.UI.Page
    {
        // Creamos una instancia de la clase CandidatosLog para interactuar con la capa de negocio
        CandidatosLog objCanLog = new CandidatosLog();

        private int _idCandidato;
        private string _nombre, _apellido, _partido, _fechaNacimiento, _propuesta;
        private bool executed = false;

        // Cargar la página por primera vez
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showCandidatos(); // Cargar todos los candidatos al inicio
            }
        }

        // Método para mostrar los candidatos en el GridView
        private void showCandidatos()
        {
            try
            {
                // Obtenemos los candidatos desde la capa de negocio
                DataSet ds = objCanLog.showCandidatos();

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Si hay datos, los asignamos al GridView
                    GVClientes.DataSource = ds.Tables[0];  // Usamos la primera tabla del DataSet
                    GVClientes.DataBind();
                }
                else
                {
                    // Si no hay datos, mostramos un mensaje
                    LblMsj.Text = "No se encontraron candidatos.";
                }
            }
            catch (Exception ex)
            {
                // Capturamos cualquier error y lo mostramos
                LblMsj.Text = "Error al cargar los candidatos: " + ex.Message;
            }
        }

        // Método para limpiar los campos de entrada
        private void clear()
        {
            // Limpiar los campos del formulario
            can_nombre.Text = "";
            can_apellido.Text = "";
            can_partido.Text = "";
            can_fecha_nacimiento.Text = "";
            can_propuesta.Text = "";

            // Ocultar el botón de actualización después de guardar
            btnActualizar.Visible = false;
        }

        // Evento para guardar un nuevo candidato
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener datos de los campos de texto
            _nombre = can_nombre.Text;
            _apellido = can_apellido.Text;
            _partido = can_partido.Text;
            _fechaNacimiento = can_fecha_nacimiento.Text;
            _propuesta = can_propuesta.Text;

            // Llamar al método de la capa de negocio para guardar el candidato
            executed = objCanLog.saveCandidato(_nombre, _apellido, _partido, _fechaNacimiento, _propuesta);

            if (executed)
            {
                LblMsj.Text = "El candidato se guardó exitosamente!";
                clear(); // Limpiar los campos
                showCandidatos(); // Actualizar la lista de candidatos
            }
            else
            {
                LblMsj.Text = "Error al guardar el candidato!";
            }
        }

        // Evento para actualizar un candidato
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            // Obtener los datos del candidato para la actualización
            _idCandidato = Convert.ToInt32(HFIdCandidato.Value); // Obtener el ID del candidato a actualizar
            _nombre = can_nombre.Text;
            _apellido = can_apellido.Text;
            _partido = can_partido.Text;
            _fechaNacimiento = can_fecha_nacimiento.Text;
            _propuesta = can_propuesta.Text;

            // Llamar al método de la capa de negocio para actualizar el candidato
            executed = objCanLog.updateCandidato(_idCandidato, _nombre, _apellido, _partido, _fechaNacimiento, _propuesta);

            if (executed)
            {
                LblMsj.Text = "El candidato se actualizó exitosamente!";
                clear(); // Limpiar los campos
                showCandidatos(); // Actualizar la lista de candidatos
            }
            else
            {
                LblMsj.Text = "Error al actualizar el candidato!";
            }
        }

        // Evento para seleccionar una fila del GridView y cargar sus datos en los campos
        protected void GVClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Asignar el ID del candidato a un campo oculto (HiddenField)
            HFIdCandidato.Value = GVClientes.SelectedRow.Cells[0].Text;

            // Asignar los valores de las celdas seleccionadas a los campos de texto
            can_nombre.Text = GVClientes.SelectedRow.Cells[1].Text;
            can_apellido.Text = GVClientes.SelectedRow.Cells[2].Text;
            can_partido.Text = GVClientes.SelectedRow.Cells[3].Text;
            can_fecha_nacimiento.Text = GVClientes.SelectedRow.Cells[4].Text;
            can_propuesta.Text = GVClientes.SelectedRow.Cells[5].Text;

            // Mostrar el botón de actualización cuando se selecciona un candidato
            btnActualizar.Visible = true;
        }

        // Evento para eliminar un candidato
        protected void GVClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                _idCandidato = Convert.ToInt32(GVClientes.DataKeys[rowIndex].Value);

                // Llamar al método de la capa de negocio para eliminar el candidato
                executed = objCanLog.deleteCandidato(_idCandidato);

                if (executed)
                {
                    LblMsj.Text = "Candidato eliminado exitosamente!";
                    showCandidatos(); // Actualizar la lista de candidatos
                }
                else
                {
                    LblMsj.Text = "Error al eliminar el candidato!";
                }
            }
        }
    }
}
