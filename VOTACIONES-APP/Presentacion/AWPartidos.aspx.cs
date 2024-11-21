using Data;
using Presentation;
using System;
using System.Data;
using System.Web.UI.WebControls;



namespace Presentacion
{
    public partial class AWPartidos : System.Web.UI.Page
    {

        PartidosLog objPar = new PartidosLog(); // Instancia de la lógica de negocio para partidos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPartidos(); // Cargar datos de partidos al cargar la página
            }
        }

        private void LoadPartidos()
        {
            try
            {
                // Obtener los datos de partidos desde la base de datos
                DataSet ds = objPar.showPartidos();

                if (ds != null && ds.Tables.Count > 0)
                {

                    // Asignar los datos al GridView
                    GVPartidos.DataSource = ds.Tables[0];
                    GVPartidos.DataBind();
                
                }
            }

            catch (Exception ex)
            {
                LblMsjPartido.Text = $"Error al cargar los partidos: {ex.Message}";
            }
            }

            protected void BtnSavePartido_Click(object sender, EventArgs e)
            {
                try
                {
                    string nombrePartido = TBNombrePartido.Text.Trim();
                    string descripcion = TBDescripcion.Text.Trim();

                    // Guardar el nuevo partido
                    bool result = objPartidosLog.savePartido(nombrePartido, descripcion, 0, 0); // Valores ficticios para candidatoId y eliminadoId

                    if (result)
                    {
                        LblMsjPartido.Text = "Partido guardado correctamente.";
                        ClearFields();
                        LoadPartidos();
                    }
                    else
                    {
                        LblMsjPartido.Text = "Error al guardar el partido.";
                    }
                }
                catch (Exception ex)
                {
                    LblMsjPartido.Text = $"Error: {ex.Message}";
                }
            }

            protected void BtnUpdatePartido_Click(object sender, EventArgs e)
            {
                try
                {
                    if (string.IsNullOrEmpty(LblPartidoId.Text))
                    {
                        LblMsjPartido.Text = "Seleccione un partido para actualizar.";
                        return;
                    }

                    int partidoId = Convert.ToInt32(LblPartidoId.Text);
                    string nombrePartido = TBNombrePartido.Text.Trim();
                    string descripcion = TBDescripcion.Text.Trim();

                    // Actualizar el partido
                    bool result = objPartidosLog.updatePartido(partidoId, nombrePartido, descripcion, 0, 0); // Valores ficticios para candidatoId y eliminadoId

                    if (result)
                    {
                        LblMsjPartido.Text = "Partido actualizado correctamente.";
                        ClearFields();
                        LoadPartidos();
                    }
                    else
                    {
                        LblMsjPartido.Text = "Error al actualizar el partido.";
                    }
                }
                catch (Exception ex)
                {
                    LblMsjPartido.Text = $"Error: {ex.Message}";
                }
            }

            protected void BtnDeletePartido_Click(object sender, EventArgs e)
            {
                try
                {
                    if (string.IsNullOrEmpty(LblPartidoId.Text))
                    {
                        LblMsjPartido.Text = "Seleccione un partido para eliminar.";
                        return;
                    }

                    int partidoId = Convert.ToInt32(LblPartidoId.Text);

                    // Eliminar el partido
                    bool result = objPartidosLog.deletePartido(partidoId);

                    if (result)
                    {
                        LblMsjPartido.Text = "Partido eliminado correctamente.";
                        ClearFields();
                        LoadPartidos();
                    }
                    else
                    {
                        LblMsjPartido.Text = "Error al eliminar el partido.";
                    }
                }
                catch (Exception ex)
                {
                    LblMsjPartido.Text = $"Error: {ex.Message}";
                }
            }

            protected void GVPartidos_SelectedIndexChanged(object sender, EventArgs e)
            {
                try
                {
                    // Obtener la fila seleccionada del GridView
                    GridViewRow row = GVPartidos.SelectedRow;

                    // Asignar los valores a los controles
                    LblPartidoId.Text = row.Cells[1].Text; // ID del partido
                    TBNombrePartido.Text = row.Cells[2].Text; // Nombre del partido
                    TBDescripcion.Text = row.Cells[3].Text; // Descripción
                }
                catch (Exception ex)
                {
                    LblMsjPartido.Text = $"Error al seleccionar el partido: {ex.Message}";
                }
            }

            private void ClearFields()
            {
            // Limpiar campos de entrada y mensajes
            LblPartidoId.Text = string.Empty;
            TBNombrePartido.Text = string.Empty;
            TBDescripcion.Text = string.Empty;
            LblMsjPartido.Text = string.Empty;
            }
        }
    }
