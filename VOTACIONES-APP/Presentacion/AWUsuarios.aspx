<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AWUsuarios.aspx.cs" Inherits="Presentacion.AWUsuarios" %>

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
</asp:Content>