<%@ Page Title="Gestión de Usuarios No Votantes" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFUsuariosNoVotantes.aspx.cs" Inherits="Presentacion4.WFUsuariosNoVotantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí puedes agregar cualquier contenido que quieras dentro del <head> -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Usuarios No Votantes</h1>

    <div>
        <!-- HiddenField para almacenar el ID del usuario seleccionado -->
        <asp:HiddenField ID="HFIdUsuario" runat="server" />

        <asp:Label ID="Label1" runat="server" Text="Ingrese el nombre del usuario"></asp:Label>
        <asp:TextBox ID="no_nombre" runat="server" />
        <br />

        <asp:Label ID="Label2" runat="server" Text="Ingrese el apellido del usuario"></asp:Label>
        <asp:TextBox ID="no_apellido" runat="server" />
        <br />

        <asp:Label ID="Label3" runat="server" Text="Ingrese la cédula del usuario"></asp:Label>
        <asp:TextBox ID="no_cedula" runat="server" />
        <br />

        <asp:Label ID="Label4" runat="server" Text="Ingrese la opción del usuario"></asp:Label>
        <asp:TextBox ID="no_opcion" runat="server" />
        <br />

        <!-- Botones para guardar y actualizar -->
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" Visible="false" />
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="Red" />
        <br />

        <!-- GridView para mostrar la lista de usuarios no votantes -->
        <asp:GridView ID="GVUsuariosNoVotantes" runat="server" AutoGenerateColumns="False" 
            OnSelectedIndexChanged="GVUsuariosNoVotantes_SelectedIndexChanged" 
            OnRowCommand="GVUsuariosNoVotantes_RowCommand" DataKeyNames="id_usuario">
            <Columns>
                <asp:BoundField DataField="id_usuario" HeaderText="ID Usuario" SortExpression="id_usuario" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
