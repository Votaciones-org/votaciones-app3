<<<<<<< HEAD
<<<<<<< HEAD
﻿<%@ Page Title="Gestión de Usuarios" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFUsuarios.aspx.cs" Inherits="Presentation.WFUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí puedes agregar cualquier contenido que quieras dentro del <head> -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Usuarios</h1>
    <div>
        <!-- HiddenField para almacenar el ID del usuario seleccionado -->
        <asp:HiddenField ID="HfUsuarioId" runat="server" />

        <!-- Campos para ingresar la información del usuario -->
        <asp:Label ID="Label1" runat="server" Text="Ingrese el correo del usuario"></asp:Label>
        <asp:TextBox ID="TBCorreo" runat="server" placeholder="Correo" />
        <br />

        <asp:Label ID="Label2" runat="server" Text="Ingrese la contraseña del usuario"></asp:Label>
        <asp:TextBox ID="TBContrasena" runat="server" TextMode="Password" placeholder="Contraseña" />
        <br />

        <!-- Botones para guardar y actualizar -->
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <br />

        <!-- Label para mostrar mensajes -->
        <asp:Label ID="LblMsj" runat="server" ForeColor="Red" />
        <br />

        <!-- GridView para mostrar la lista de usuarios -->
        <asp:GridView ID="GVUsuarios" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVUsuarios_SelectedIndexChanged" CssClass="gridview">
            <Columns>
                <asp:BoundField DataField="usu_id" HeaderText="ID" SortExpression="usu_id" />
                <asp:BoundField DataField="usu_correo" HeaderText="Correo" SortExpression="usu_correo" />
                <asp:BoundField DataField="usu_contrasena" HeaderText="Contraseña" SortExpression="usu_contrasena" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Seleccionar" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

=======
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AWUsuarios.aspx.cs" Inherits="Presentacion.AWUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Formulario de Registro de Usuario</h2>
        <label for="usu_correo">Correo Electrónico:</label>
        <input type="email" id="usu_correo" name="usu_correo" required>
        <br><br>

        <label for="usu_contrasena">Contraseña:</label>
        <input type="password" id="usu_contrasena" name="usu_contrasena" required>
        <br><br>

        <input type="hidden" name="usu_fechaInicioSecion" value="<?php echo date('Y-m-d H:i:s'); ?>">

        <button type="submit">Registrar</button>
            <asp:GridView ID="GVProducts" runat="server"></asp:GridView>
<<<<<<< HEAD
</asp:Content>
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
</asp:Content>
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
