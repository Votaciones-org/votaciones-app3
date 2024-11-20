<%@ Page Title="Gestión de Candidatos Eliminados" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AWCandidatosEliminados.aspx.cs" Inherits="Presentation.AWCandidatosEliminados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí se pueden agregar estilos adicionales si es necesario -->
        <link rel="stylesheet" href="Content/bootstrap.min.css">
<script src="Scripts/bootstrap.min.js"></script>
<script src="Scripts/jquery-1.9.1.min.js"></script> 

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Gestión de Candidatos Eliminados</h1>

        <!-- Etiquetas y TextBoxes para los datos del candidato eliminado -->
        <asp:Label ID="LblId" runat="server" Text="ID:" Visible="false"></asp:Label>
        <asp:Label ID="LblNombre" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TBNombre" runat="server" ReadOnly="True"></asp:TextBox>
        <br />

        <asp:Label ID="LblApellido" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="TBApellido" runat="server" ReadOnly="True"></asp:TextBox>
        <br />

        <asp:Label ID="LblPartido" runat="server" Text="Partido:"></asp:Label>
        <asp:TextBox ID="TBPartido" runat="server" ReadOnly="True"></asp:TextBox>
        <br />

        <asp:Label ID="LblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
        <asp:TextBox ID="TBFechaNacimiento" runat="server" TextMode="Date" ReadOnly="True"></asp:TextBox>
        <br />

        <asp:Label ID="LblPropuesta" runat="server" Text="Propuesta:"></asp:Label>
        <asp:TextBox ID="TBPropuesta" runat="server" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
        <br />

        <!-- Etiqueta para mostrar mensajes -->
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>

    <div>
        <!-- GridView para mostrar los candidatos eliminados -->
        <asp:GridView ID="GVCandidatosEliminados" runat="server" CssClass="table" AutoGenerateColumns="False" OnSelectedIndexChanged="GVCandidatosEliminados_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:BoundField DataField="apellido" HeaderText="Apellido" SortExpression="apellido" />
                <asp:BoundField DataField="partido" HeaderText="Partido" SortExpression="partido" />
                <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha de Nacimiento" SortExpression="fechaNacimiento" />
                <asp:BoundField DataField="propuesta" HeaderText="Propuesta" SortExpression="propuesta" />
                <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

