<<<<<<< HEAD
<<<<<<< HEAD
﻿using Data;
using Logic;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class AWUsuariosAFK : System.Web.UI.Page
    {
        // Creamos una instancia de la clase UsuariosAfkLog para interactuar con la capa de negocio
        UsuariosAfkLog objAfkLog = new UsuariosAfkLog();
        UsuariosLog objusu = new UsuariosLog();
        CandidatosLog objCanLog = new CandidatosLog();
        UsuariosAfkLog objAfkDat = new UsuariosAfkLog();  // Corregido el nombre de la clase a UsuariosAfkDat.
        Usuarios_No_votantesLog objNO = new Usuarios_No_votantesLog();
        private int _idUsuario;
        private string _correo, _contrasena;
        private bool executed = false;

        // Cargar la página por primera vez
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showUsuariosAfk(); // Método para cargar todos los usuarios AFK
            }
        }

        // Método para mostrar los usuarios AFK en el GridView
        private void showUsuariosAfk()
        {
            try
            {
                // Obtenemos los usuarios AFK desde la capa de negocio
                DataSet ds = objAfkLog.showUsuariosAfk();

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Si hay datos, los asignamos al GridView
                    GVUsuariosAFK.DataSource = ds.Tables[0];  // Usamos la primera tabla del DataSet
                    GVUsuariosAFK.DataBind();
                }
                else
                {
                    // Si no hay datos, mostramos un mensaje
                    LblMsj.Text = "No se encontraron usuarios AFK.";
                }
            }
            catch (Exception ex)
            {
                // Capturamos cualquier error y lo mostramos
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

            // Llamada a la función de la capa de negocio para guardar el usuario AFK
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

            // Llamada a la función de la capa de negocio para actualizar el usuario AFK
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

        // Evento para seleccionar una fila del GridView y cargar sus datos en los campos
        protected void GVUsuariosAFK_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Asignar el ID del usuario AFK a un campo oculto (HiddenField)
            HfUsuarioId.Value = GVUsuariosAFK.SelectedRow.Cells[0].Text;
            // Asignar los valores de las celdas seleccionadas a los campos de texto
            TBCorreo.Text = GVUsuariosAFK.SelectedRow.Cells[1].Text;
            TBContrasena.Text = GVUsuariosAFK.SelectedRow.Cells[2].Text;
        }

        // Evento para eliminar un usuario AFK
        protected void GVUsuariosAFK_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                _idUsuario = Convert.ToInt32(GVUsuariosAFK.DataKeys[rowIndex].Value);

                // Llamada a la función de la capa de negocio para eliminar el usuario AFK
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
=======
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class AWUsuariosAFK : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
<<<<<<< HEAD
}
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
}
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
