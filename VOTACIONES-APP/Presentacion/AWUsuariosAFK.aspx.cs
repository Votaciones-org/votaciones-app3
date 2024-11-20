
using Logic;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class AWUsuariosAFK : System.Web.UI.Page
    {
        // Instancias de las clases de la capa de negocio
        UsuariosAfkLog objAfkLog = new UsuariosAfkLog();
        CandidatosLog objCanLog = new CandidatosLog();
        UsuariosAfkLog objAfkDat = new UsuariosAfkLog();
        UsuariosLog objusu = new UsuariosLog();
        Usuarios_No_votantesLog objNO = new Usuarios_No_votantesLog();
        private int _idUsuario;
        private string _correo, _contrasena;
        private bool executed = false;

        // Cargar la página por primera vez
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showUsuariosAfk(); // Cargar los usuarios AFK en el GridView
            }
        }

        // Método para mostrar los usuarios AFK en el GridView
        private void showUsuariosAfk()
        {
            try
            {
                // Obtener los usuarios AFK desde la capa de negocio
                DataSet ds = objAfkLog.showUsuariosAfk();

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Asignar la data al GridView
                    GVUsuariosAFK.DataSource = ds.Tables[0];
                    GVUsuariosAFK.DataBind();
                }
                else
                {
                    LblMsj.Text = "No se encontraron usuarios AFK.";
                }
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error al cargar los usuarios AFK: " + ex.Message;
            }
        }

        // Limpiar los campos de entrada
        private void clear()
        {
            TBCorreo.Text = "";
            TBContrasena.Text = "";
        }

        // Evento para guardar un nuevo usuario AFK
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _correo = TBCorreo.Text;
            _contrasena = TBContrasena.Text;

            // Llamada a la capa de negocio para guardar el usuario AFK
            executed = objAfkLog.saveUsuariosAfk(_correo, _contrasena);

            if (executed)
            {
                LblMsj.Text = "El usuario AFK se guardó exitosamente!";
                clear(); // Limpiar los campos
                showUsuariosAfk(); // Actualizar el listado
            }
            else
            {
                LblMsj.Text = "Error al guardar el usuario AFK!";
            }
        }

        // Evento para actualizar un usuario AFK
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idUsuario = Convert.ToInt32(HfUsuarioId.Value); // Obtener el ID del usuario a actualizar
            _correo = TBCorreo.Text;
            _contrasena = TBContrasena.Text;

            // Llamada a la capa de negocio para actualizar el usuario AFK
            executed = objAfkLog.updateUsuariosAfk(_idUsuario, _correo, _contrasena);

            if (executed)
            {
                LblMsj.Text = "El usuario AFK se actualizó exitosamente!";
                clear(); // Limpiar los campos
                showUsuariosAfk(); // Actualizar el listado
            }
            else
            {
                LblMsj.Text = "Error al actualizar el usuario AFK!";
            }
        }

        // Evento para seleccionar un usuario del GridView y cargar sus datos
        protected void GVUsuariosAFK_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Asignar el ID y los valores del usuario seleccionado a los campos
            GridViewRow row = GVUsuariosAFK.SelectedRow;
            HfUsuarioId.Value = row.Cells[0].Text;
            TBCorreo.Text = row.Cells[1].Text;
            TBContrasena.Text = row.Cells[2].Text;

            // Mostrar el botón de "Actualizar" y ocultar el de "Guardar"
            BtnSave.Visible = false;
            BtnUpdate.Visible = true;
        }

        // Evento para eliminar un usuario AFK
        protected void GVUsuariosAFK_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                _idUsuario = Convert.ToInt32(GVUsuariosAFK.DataKeys[rowIndex].Value);

                // Llamada a la capa de negocio para eliminar el usuario AFK
                executed = objAfkLog.deleteUsuariosAfk(_idUsuario);

                if (executed)
                {
                    LblMsj.Text = "Usuario AFK eliminado exitosamente!";
                    showUsuariosAfk(); // Actualizar el listado
                }
                else
                {
                    LblMsj.Text = "Error al eliminar el usuario AFK!";
                }
            }
        }
    }
}
