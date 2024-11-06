using System;
using Logic;
using System.Data;

namespace Presentation
{
    public partial class WFCandidatos : System.Web.UI.Page
    {
        CandidatosLog objCanLog = new CandidatosLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showCandidatos(); // Mostrar los candidatos al cargar la página
            }
        }

        // Método para mostrar todos los candidatos en el GridView
        private void showCandidatos()
        {
            DataSet ds = objCanLog.showCandidatos();
            GVClientes.DataSource = ds;
            GVClientes.DataBind();
        }

        // Método para guardar un nuevo candidato
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = can_nombre.Text;  // Acceder al valor del TextBox
            string apellido = can_apellido.Text;
            string partido = can_partido.Text;
            string fechaNacimiento = can_fecha_nacimiento.Text;
            string propuesta = can_propuesta.Text;

            bool result = objCanLog.saveCandidato(nombre, apellido, partido, fechaNacimiento, propuesta);

            if (result)
            {
                // Mensaje de éxito
                Response.Write("<script>alert('Candidato guardado exitosamente');</script>");
                showCandidatos(); // Recargar los candidatos
            }
            else
            {
                // Mensaje de error
                Response.Write("<script>alert('Error al guardar candidato');</script>");
            }
        }

        // Método para actualizar un candidato
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            // Aquí deberías obtener el ID del candidato a actualizar y pasar los nuevos valores
            // Ejemplo con un ID ficticio:
            int idCandidato = 1; // Esto lo puedes reemplazar por un valor dinámico según el ID del candidato que se está actualizando.
            string nombre = can_nombre.Text;
            string apellido = can_apellido.Text;
            string partido = can_partido.Text;
            string fechaNacimiento = can_fecha_nacimiento.Text;
            string propuesta = can_propuesta.Text;

            bool result = objCanLog.updateCandidato(idCandidato, nombre, apellido, partido, fechaNacimiento, propuesta);

            if (result)
            {
                // Mensaje de éxito
                Response.Write("<script>alert('Candidato actualizado exitosamente');</script>");
                showCandidatos(); // Recargar los candidatos
            }
            else
            {
                // Mensaje de error
                Response.Write("<script>alert('Error al actualizar candidato');</script>");
            }
        }
    }
}
