
using Data;
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
        UsuariosAfkLog objAfkDat = new UsuariosAfkLog();  // Corregido el nombre de la clase a UsuariosAfkDat.
        Usuarios_No_votantesLog objNO = new Usuarios_No_votantesLog();
        UsuariosLog objusu = new UsuariosLog();

        private int _idCandidato;
        private string _nombre, _apellido, _partido, _fechaNacimiento, _propuesta;
        private bool executed = false;

        // Cargar la página por primera vez
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showCandidatos(); // Método para cargar todos los candidatos
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

        // Limpiar los campos de entrada
        private void clear()
        {
            can_nombre.Text = "";
            can_apellido.Text = "";
            can_partido.Text = "";
            can_fecha_nacimiento.Text = "";
            can_propuesta.Text = "";
        }

        // Evento para guardar un nuevo candidato
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            _nombre = can_nombre.Text;
            _apellido = can_apellido.Text;
            _partido = can_partido.Text;
            _fechaNacimiento = can_fecha_nacimiento.Text;
            _propuesta = can_propuesta.Text;

            // Llamada a la función de la capa de negocio para guardar el candidato
            executed = objCanLog.saveCandidato(_nombre, _apellido, _partido, _fechaNacimiento, _propuesta);

            if (executed)
            {
                LblMsj.Text = "El candidato se guardó exitosamente!";
                clear(); // Limpiar los campos
                showCandidatos(); // Actualizar el listado
            }
            else
            {
                LblMsj.Text = "Error al guardar el candidato!";
            }
        }

        // Evento para actualizar un candidato
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            _idCandidato = Convert.ToInt32(HFIdCandidato.Value); // Obtener el ID del candidato a actualizar
            _nombre = can_nombre.Text;
            _apellido = can_apellido.Text;
            _partido = can_partido.Text;
            _fechaNacimiento = can_fecha_nacimiento.Text;
            _propuesta = can_propuesta.Text;

            // Llamada a la función de la capa de negocio para actualizar el candidato
            executed = objCanLog.updateCandidato(_idCandidato, _nombre, _apellido, _partido, _fechaNacimiento, _propuesta);

            if (executed)
            {
                LblMsj.Text = "El candidato se actualizó exitosamente!";
                clear(); // Limpiar los campos
                showCandidatos(); // Actualizar el listado
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
        }

        // Evento para eliminar un candidato
        protected void GVClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                _idCandidato = Convert.ToInt32(GVClientes.DataKeys[rowIndex].Value);

                // Llamada a la función de la capa de negocio para eliminar el candidato
                executed = objCanLog.deleteCandidato(_idCandidato);

                if (executed)
                {
                    LblMsj.Text = "Candidato eliminado exitosamente!";
                    showCandidatos(); // Actualizar el listado
                }
                else
                {
                    LblMsj.Text = "Error al eliminar el candidato!";
                }

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
