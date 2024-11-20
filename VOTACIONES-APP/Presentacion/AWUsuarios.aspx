<%@ Page Title="Gestión de Usuarios" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AWUsuarios.aspx.cs" Inherits="Presentation.AWUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí puedes agregar cualquier contenido que quieras dentro del <head> -->
        <link rel="stylesheet" href="Content/bootstrap.min.css">
<script src="Scripts/bootstrap.min.js"></script>
<script src="Scripts/jquery-1.9.1.min.js"></script> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Usuarios</h1>
    <div>
        <!-- HiddenField para almacenar el ID del usuario seleccionado -->
        <asp:HiddenField ID="HfUsuarioId" runat="server" />

        <!-- Campos para ingresar la información del usuario -->
        <asp:Label ID="Label1" runat="server" Text="Ingrese el correo del usuario" AssociatedControlID="TBCorreo" />
        <asp:TextBox ID="TBCorreo" runat="server" placeholder="Correo" />
        <br />

        <asp:Label ID="Label2" runat="server" Text="Ingrese la contraseña del usuario" AssociatedControlID="TBContrasena" />
        <asp:TextBox ID="TBContrasena" runat="server" TextMode="Password" placeholder="Contraseña" />
        <br />

        <!-- Botones para guardar y actualizar -->
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" Visible="false" />
        <br />

        <!-- Label para mostrar mensajes -->
        <asp:Label ID="LblMsj" runat="server" ForeColor="Red" />
        <br />

        <!-- GridView para mostrar la lista de usuarios -->
        <asp:GridView ID="GVUsuarios" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVUsuarios_SelectedIndexChanged" CssClass="gridview" 
                      OnRowCommand="GVUsuarios_RowCommand" DataKeyNames="usu_id">
            <Columns>
                <asp:BoundField DataField="usu_id" HeaderText="ID" SortExpression="usu_id" />
                <asp:BoundField DataField="usu_correo" HeaderText="Correo" SortExpression="usu_correo" />
                <asp:BoundField DataField="usu_contrasena" HeaderText="Contraseña" SortExpression="usu_contrasena" />
               
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
               
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>




