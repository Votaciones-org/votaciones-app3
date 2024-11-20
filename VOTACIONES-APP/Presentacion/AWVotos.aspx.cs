using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class AWVotos : System.Web.UI.Page
    {

        VotosLog objVot = new VotosLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadVotes(); // Cargar los votos al cargar la página
            }
        }

        // Método para cargar los votos en el GridView
        private void LoadVotes()
        {
            DataSet votos = objVot.showVotes();
            if (votos != null)
            {
                GVVotos.DataSource = votos.Tables[0];
                GVVotos.DataBind();
            }
            else
            {
                LblMsj.Text = "Error al cargar los votos.";
            }
        }

        // Método para guardar un nuevo voto
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string nombre = TBNombre.Text.Trim();
            string apellido = TBApellido.Text.Trim();
            string cedula = TBCedula.Text.Trim();
            string opcion = TBOpcion.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(opcion))
            {
                LblMsj.Text = "Todos los campos son obligatorios.";
                return;
            }

            bool success = objVot.saveVote(nombre, apellido, cedula, opcion);
            LblMsj.Text = success ? "Voto guardado correctamente." : "Error al guardar el voto.";

            if (success) LoadVotes(); // Recargar la tabla si la operación fue exitosa
        }

        // Método para actualizar un voto existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LblId.Text))
            {
                LblMsj.Text = "Seleccione un voto para actualizar.";
                return;
            }

            int id = int.TryParse(LblId.Text, out id) ? id : 0;
            string nombre = TBNombre.Text.Trim();
            string apellido = TBApellido.Text.Trim();
            string cedula = TBCedula.Text.Trim();
            string opcion = TBOpcion.Text.Trim();

            if (id == 0 || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(opcion))
            {
                LblMsj.Text = "Todos los campos son obligatorios y el ID debe ser válido.";
                return;
            }

            bool success = objVot.updateVote(id, nombre, apellido, cedula, opcion);
            LblMsj.Text = success ? "Voto actualizado correctamente." : "Error al actualizar el voto.";

            if (success) LoadVotes(); // Recargar la tabla si la operación fue exitosa
        }

        // Método para seleccionar un voto desde el GridView
        protected void GVVotos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GVVotos.SelectedRow;

            if (row != null)
            {
                LblId.Text = row.Cells[0].Text; // ID del voto
                TBNombre.Text = row.Cells[1].Text; // Nombre
                TBApellido.Text = row.Cells[2].Text; // Apellido
                TBCedula.Text = row.Cells[3].Text; // Cédula
                TBOpcion.Text = row.Cells[4].Text; // Opción

                LblMsj.Text = "Voto seleccionado para actualizar.";
            }
        }
    }
}