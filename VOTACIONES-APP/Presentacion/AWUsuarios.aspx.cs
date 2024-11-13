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
    public partial class WFUsuarios : System.Web.UI.Page
    {
        // Instanciamos las clases de la capa lógica para usuarios
        UsuariosLog objusu = new UsuariosLog();
        CandidatosLog objCanLog = new CandidatosLog();
        UsuariosAfkLog objAfkDat = new UsuariosAfkLog();  // Corregido el nombre de la clase a UsuariosAfkDat.
        Usuarios_No_votantesLog objNO = new Usuarios_No_votantesLog();

        private int _id;
        private string _correo, _contrasena;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showUsuarios(); // Se invoca el método para mostrar todos los usuarios
            }
        }

        // Método para mostrar todos los usuarios en un GridView
        private void showUsuarios()
        {
            try
            {
                // Obtenemos los datos de la capa de lógica
                DataSet ds = objusu.showUsuarios();

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Si hay datos, los asignamos al GridView
                    GVUsuarios.DataSource = ds.Tables[0];  // Aseguramos que estamos usando la primera tabla
                    GVUsuarios.DataBind();
                }
                else
                {
                    // Si no hay datos, mostramos un mensaje
                    LblMsj.Text = "No se encontraron usuarios.";
                }
            }
            catch (Exception ex)
            {
                // Capturamos cualquier error y lo mostramos
                LblMsj.Text = "Error al cargar los usuarios: " + ex.Message;
            }
        }

        // Método para limpiar los TextBox y los valores del formulario
        private void clear()
        {
            HfUsuarioId.Value = "";
            TBCorreo.Text = "";
            TBContrasena.Text = "";
        }

        // Evento para guardar un nuevo usuario
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _correo = TBCorreo.Text; // Capturamos el correo ingresado
            _contrasena = TBContrasena.Text; // Capturamos la contraseña

            // Llamamos al método saveUsuario de la capa de lógica
            executed = objusu.saveUsuario(_correo, _contrasena);

            if (executed)
            {
                LblMsj.Text = "El usuario se guardó exitosamente!";
                clear(); // Limpiamos los campos
                showUsuarios(); // Actualizamos la lista de usuarios
            }
            else
            {
                LblMsj.Text = "Error al guardar el usuario!";
            }
        }

        // Evento para actualizar un usuario
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(HfUsuarioId.Value); // Obtenemos el ID del usuario seleccionado
            _correo = TBCorreo.Text;
            _contrasena = TBContrasena.Text;

            executed = objusu.updateUsuario(_id, _correo, _contrasena);

            if (executed)
            {
                LblMsj.Text = "El usuario se actualizó exitosamente!";
                clear();
                showUsuarios(); // Actualizamos la lista de usuarios
            }
            else
            {
                LblMsj.Text = "Error al actualizar el usuario!";
            }
        }

        // Evento para seleccionar un usuario desde el GridView
        protected void GVUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Al seleccionar una fila en el GridView, llenamos los campos de texto
            HfUsuarioId.Value = GVUsuarios.SelectedRow.Cells[0].Text;
            TBCorreo.Text = GVUsuarios.SelectedRow.Cells[1].Text;
            TBContrasena.Text = GVUsuarios.SelectedRow.Cells[2].Text;
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
    public partial class AWUsuarios : System.Web.UI.Page
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
