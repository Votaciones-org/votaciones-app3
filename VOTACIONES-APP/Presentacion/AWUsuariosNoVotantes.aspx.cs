using Data;
using Logic;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class AWFUsuariosNoVotantes : System.Web.UI.Page
    {
        // Instancia de la clase de lógica para interactuar con los usuarios no votantes
        Usuarios_No_votantesLog objNOLog = new Usuarios_No_votantesLog();
        CandidatosLog objCanLog = new CandidatosLog();
        UsuariosAfkLog objAfkDat = new UsuariosAfkLog();
        UsuariosLog objusu = new UsuariosLog();
        Usuarios_No_votantesLog objNO = new Usuarios_No_votantesLog();
        private int _idUsuario;
        private string _nombre, _apellido, _cedula, _opcion;
        private bool executed = false;

        // Cargar la página por primera vez
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showUsuariosNoVotantes(); // Mostrar los usuarios no votantes en el GridView
            }
        }

        // Método para mostrar los usuarios no votantes en el GridView
        private void showUsuariosNoVotantes()
        {
            try
            {
                // Obtener los usuarios no votantes desde la capa de negocio
                DataSet ds = objNOLog.ShowUsuariosNoVotantes();

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Asignar los datos al GridView
                    GVUsuariosNoVotantes.DataSource = ds.Tables[0];
                    GVUsuariosNoVotantes.DataBind();
                }
                else
                {
                    LblMsj.Text = "No se encontraron usuarios no votantes.";
                }
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error al cargar los usuarios: " + ex.Message;
            }
        }

        // Limpiar los campos de entrada
        private void clear()
        {
            no_nombre.Text = "";
            no_apellido.Text = "";
            no_cedula.Text = "";
            no_opcion.Text = "";
        }

        // Evento para guardar un nuevo usuario no votante
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            _nombre = no_nombre.Text;
            _apellido = no_apellido.Text;
            _cedula = no_cedula.Text;
            _opcion = no_opcion.Text;

            // Llamada a la capa de negocio para guardar el usuario
            executed = objNOLog.SaveUsuarioNoVotante(_nombre, _apellido, _cedula, _opcion);

            if (executed)
            {
                LblMsj.Text = "El usuario se guardó exitosamente!";
                clear(); // Limpiar los campos
                showUsuariosNoVotantes(); // Actualizar el listado
            }
            else
            {
                LblMsj.Text = "Error al guardar el usuario!";
            }
        }

        // Evento para actualizar un usuario no votante
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            _idUsuario = Convert.ToInt32(HFIdUsuario.Value); // Obtener el ID del usuario a actualizar
            _nombre = no_nombre.Text;
            _apellido = no_apellido.Text;
            _cedula = no_cedula.Text;
            _opcion = no_opcion.Text;

            // Llamada a la capa de negocio para actualizar el usuario
            executed = objNOLog.UpdateUsuarioNoVotante(_idUsuario, _nombre, _apellido, _cedula, _opcion);

            if (executed)
            {
                LblMsj.Text = "El usuario se actualizó exitosamente!";
                clear(); // Limpiar los campos
                showUsuariosNoVotantes(); // Actualizar el listado
            }
            else
            {
                LblMsj.Text = "Error al actualizar el usuario!";
            }
        }

        // Evento para seleccionar una fila del GridView y cargar sus datos en los campos
        protected void GVUsuariosNoVotantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Asignar el ID del usuario a un campo oculto (HiddenField)
            HFIdUsuario.Value = GVUsuariosNoVotantes.SelectedRow.Cells[0].Text;
            // Asignar los valores de las celdas seleccionadas a los campos de texto
            no_nombre.Text = GVUsuariosNoVotantes.SelectedRow.Cells[1].Text;
            no_apellido.Text = GVUsuariosNoVotantes.SelectedRow.Cells[2].Text;
            no_cedula.Text = GVUsuariosNoVotantes.SelectedRow.Cells[3].Text;
            no_opcion.Text = GVUsuariosNoVotantes.SelectedRow.Cells[4].Text;

            // Mostrar el botón de "Actualizar" y ocultar el de "Guardar"
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
        }

        // Evento para eliminar un usuario no votante
        protected void GVUsuariosNoVotantes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                _idUsuario = Convert.ToInt32(GVUsuariosNoVotantes.DataKeys[rowIndex].Value);

                // Llamada a la capa de negocio para eliminar el usuario
                executed = objNOLog.DeleteUsuarioNoVotante(_idUsuario);

                if (executed)
                {
                    LblMsj.Text = "Usuario eliminado exitosamente!";
                    showUsuariosNoVotantes(); // Actualizar el listado
                }
                else
                {
                    LblMsj.Text = "Error al eliminar el usuario!";
                }
            }
        }
    }
}
