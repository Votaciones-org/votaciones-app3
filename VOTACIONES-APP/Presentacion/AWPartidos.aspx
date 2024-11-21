<%@ Page Title="Partidos y Candidatos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AWPartidos.aspx.cs" Inherits="Presentation.AWPartidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí puedes agregar cualquier contenido que quieras dentro del <head> -->
    <link rel="stylesheet" href="Content/bootstrap.min.css">
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.9.1.min.js"></script>    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" class="container">
    <div class="form-container">
        <h2>Gestión de Partidos</h2>

        <!-- Oculto para mantener el ID del partido seleccionado -->
        <asp:Label ID="LblPartidoId" runat="server" Text="" Visible="false"></asp:Label>

        <label for="TBNombrePartido">Nombre del Partido:</label>
        <asp:TextBox ID="TBNombrePartido" runat="server"></asp:TextBox>

        <label for="TBDescripcion">Descripción:</label>
        <asp:TextBox ID="TBDescripcion" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>

        <div class="action-buttons">
            <asp:Button ID="BtnSavePartido" runat="server" Text="Guardar Partido" CssClass="btn" OnClick="BtnSavePartido_Click" />
            <asp:Button ID="BtnUpdatePartido" runat="server" Text="Actualizar Partido" CssClass="btn" OnClick="BtnUpdatePartido_Click" />
            <asp:Button ID="BtnDeletePartido" runat="server" Text="Eliminar Partido" CssClass="btn" OnClick="BtnDeletePartido_Click" />
        </div>

        <asp:Label ID="LblMsjPartido" runat="server" CssClass="message"></asp:Label>
    </div>

    <div class="grid-container">
        <asp:GridView ID="GVPartidos" runat="server" CssClass="table" AutoGenerateColumns="False" OnSelectedIndexChanged="GVPartidos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="partido_id" HeaderText="ID" />
                <asp:BoundField DataField="partido_nombre" HeaderText="Nombre del Partido" />
                <asp:BoundField DataField="partido_descripcion" HeaderText="Descripción" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>