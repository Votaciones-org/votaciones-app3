<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AWUsuariosNoVotantes.aspx.cs" Inherits="Presentacion.AWUsuariosNoVotantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Registro de No Votantes</h2>

            <label for="no_nombre">Nombre:</label>
            <input type="text" id="no_nombre" name="no_nombre" required>

            <label for="no_apellido">Apellido:</label>
            <input type="text" id="no_apellido" name="no_apellido" required>

            <label for="no_cedula">Cédula:</label>
            <input type="text" id="no_cedula" name="no_cedula" required>

            <label for="no_opcion">Opción:</label>
            <input type="text" id="no_opcion" name="no_opcion" required>

            <input type="submit" value="Registrar No Votante">
                    <input type="submit" value="Actualizar No Votante">

                    <asp:GridView ID="GVProducts" runat="server"></asp:GridView>

    </div>

    <!-- Mensaje de confirmación o error -->
    <div class="message">
        <!-- El mensaje se mostrará aquí después de procesar el formulario -->
    </div>
</asp:Content>
