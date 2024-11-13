<<<<<<< HEAD
<<<<<<< HEAD
﻿<%@ Page Title="Gestión de Usuarios AFK" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AWUsuariosAFK.aspx.cs" Inherits="Presentation.AWUsuariosAFK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí puedes agregar cualquier contenido que quieras dentro del <head> -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Usuarios AFK</h1>
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

        <!-- GridView para mostrar la lista de usuarios AFK -->
        <asp:GridView ID="GVUsuariosAFK" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVUsuariosAFK_SelectedIndexChanged" CssClass="gridview" OnRowCommand="GVUsuariosAFK_RowCommand">
            <Columns>
                <asp:BoundField DataField="af_id" HeaderText="ID" SortExpression="af_id" />
                <asp:BoundField DataField="af_correo" HeaderText="Correo" SortExpression="af_correo" />
                <asp:BoundField DataField="af_contrasena" HeaderText="Contraseña" SortExpression="af_contrasena" />
                <asp:BoundField DataField="af_fechaCierre" HeaderText="Fecha de Cierre" SortExpression="af_fechaCierre" DataFormatString="{0:dd/MM/yyyy}" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnSeleccionar" runat="server" CommandName="Select" Text="Seleccionar" OnClientClick="return confirm('¿Está seguro de seleccionar este usuario?');" />
                        <asp:Button ID="btnEliminar" runat="server" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Está seguro de eliminar este usuario?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>




=======
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AWUsuariosAFK.aspx.cs" Inherits="Presentacion.AWUsuariosAFK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Formulario de Cierre de Usuario AFK</h2>

        <label for="af_correo">Correo Electrónico:</label>
        <input type="email" id="af_correo" name="af_correo" required>
        <br><br>

        <label for="af_contrasena">Contraseña:</label>
        <input type="password" id="af_contrasena" name="af_contrasena" required>
        <br><br>

        <input type="hidden" name="af_fechaCierre" value="<?php echo date('Y-m-d H:i:s'); ?>">

        <button type="submit">Cerrar Sesión</button>
                <asp:GridView ID="GVProducts" runat="server"></asp:GridView>

</asp:Content>
<<<<<<< HEAD
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
