using Logic;
using Presentation;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFUsuarios : System.Web.UI.Page
    {
        // Instancia de la capa de lógica para usuarios
        
        CandidatosLog objCanLog = new CandidatosLog();
        UsuariosAfkLog objAfkDat = new UsuariosAfkLog();
        UsuariosLog objusu = new UsuariosLog();
        Usuarios_No_votantesLog objNO = new Usuarios_No_votantesLog();
        private int _id;
        private string _correo, _contrasena;
        private bool executed = false;

        // Cargar la página y mostrar los usuarios
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showUsuarios(); // Cargar todos los usuarios en el GridView
            }
        }

        // Método para mostrar todos los usuarios en el GridView
        private void showUsuarios()
        {
            try
            {
                // Obtenemos los datos de la capa de lógica
                DataSet ds = objusu.showUsuarios();

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Asignamos los datos al GridView
                    GVUsuarios.DataSource = ds.Tables[0];
                    GVUsuarios.DataBind();
                }
                else
                {
                    LblMsj.Text = "No se encontraron usuarios.";
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lo mostramos
                LblMsj.Text = "Error al cargar los usuarios: " + ex.Message;
            }
        }

        // Limpiar los campos de texto y el campo oculto
        private void clear()
        {
            TBCorreo.Text = "";
            TBContrasena.Text = "";
            HfUsuarioId.Value = "";
        }

        // Evento para guardar un nuevo usuario
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _correo = TBCorreo.Text; // Capturamos el correo
            _contrasena = TBContrasena.Text; // Capturamos la contraseña

            // Llamamos al método para guardar el usuario
            executed = objusu.saveUsuario(_correo, _contrasena);

            if (executed)
            {
                LblMsj.Text = "El usuario se guardó exitosamente!";
                clear(); // Limpiar los campos
                showUsuarios(); // Actualizar el GridView
            }
            else
            {
                LblMsj.Text = "Error al guardar el usuario!";
            }
        }

        // Evento para actualizar un usuario existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(HfUsuarioId.Value); // Obtener el ID del usuario seleccionado
            _correo = TBCorreo.Text;
            _contrasena = TBContrasena.Text;

            // Llamamos al método para actualizar el usuario
            executed = objusu.updateUsuario(_id, _correo, _contrasena);

            if (executed)
            {
                LblMsj.Text = "El usuario se actualizó exitosamente!";
                clear(); // Limpiar los campos
                showUsuarios(); // Actualizar el GridView
            }
            else
            {
                LblMsj.Text = "Error al actualizar el usuario!";
            }
        }

        // Evento cuando se selecciona un usuario desde el GridView
        protected void GVUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener los valores de la fila seleccionada y asignarlos a los campos
            GridViewRow row = GVUsuarios.SelectedRow;
            HfUsuarioId.Value = row.Cells[0].Text; // ID del usuario
            TBCorreo.Text = row.Cells[1].Text; // Correo
            TBContrasena.Text = row.Cells[2].Text; // Contraseña

            // Mostrar el botón de "Actualizar" y ocultar el de "Guardar"
            BtnSave.Visible = false;
            BtnUpdate.Visible = true;
        }

        // Evento para eliminar un usuario desde el GridView
        protected void GVUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                _id = Convert.ToInt32(GVUsuarios.DataKeys[rowIndex].Value); // Obtener el ID desde las claves de datos

                // Llamamos al método para eliminar el usuario
                executed = objusu.deleteUsuario(_id);

                if (executed)
                {
                    LblMsj.Text = "Usuario eliminado exitosamente!";
                    showUsuarios(); // Actualizamos el GridView
                }
                else
                {
                    LblMsj.Text = "Error al eliminar el usuario!";
                }
            }
        }
    }
}




