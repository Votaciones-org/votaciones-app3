<<<<<<< HEAD
<<<<<<< HEAD
﻿<%@ Page Title="Gestión de Usuarios No Votantes" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AWFUsuariosNoVotantes.aspx.cs" Inherits="Presentation.AWFUsuariosNoVotantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí puedes agregar cualquier contenido que quieras dentro del <head> -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Usuarios No Votantes</h1>
    <div>
        <!-- HiddenField para almacenar el ID del usuario seleccionado -->
        <asp:HiddenField ID="HFIdUsuario" runat="server" />

        <!-- Campos para ingresar la información del usuario no votante -->
        <asp:Label ID="Label1" runat="server" Text="Ingrese el nombre del usuario"></asp:Label>
        <asp:TextBox ID="no_nombre" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label2" runat="server" Text="Ingrese el apellido del usuario"></asp:Label>
        <asp:TextBox ID="no_apellido" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label3" runat="server" Text="Ingrese la cédula del usuario"></asp:Label>
        <asp:TextBox ID="no_cedula" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label4" runat="server" Text="Ingrese la opción del usuario"></asp:Label>
        <asp:TextBox ID="no_opcion" runat="server"></asp:TextBox>
        <br />

        <!-- Botones para guardar y actualizar -->
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />

        <!-- GridView para mostrar la lista de usuarios no votantes -->
        <asp:GridView ID="GVUsuariosNoVotantes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVUsuariosNoVotantes_SelectedIndexChanged" OnRowCommand="GVUsuariosNoVotantes_RowCommand">
            <Columns>
                <asp:BoundField DataField="id_usuario" HeaderText="ID Usuario" SortExpression="id_usuario" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:BoundField DataField="apellido" HeaderText="Apellido" SortExpression="apellido" />
                <asp:BoundField DataField="cedula" HeaderText="Cédula" SortExpression="cedula" />
                <asp:BoundField DataField="opcion" HeaderText="Opción" SortExpression="opcion" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>


=======
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AWUsuariosNoVotantes.aspx.cs" Inherits="Presentacion.AWUsuariosNoVotantes" %>
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
<<<<<<< HEAD
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
