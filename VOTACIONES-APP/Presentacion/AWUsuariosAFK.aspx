<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AWUsuariosAFK.aspx.cs" Inherits="Presentacion.AWUsuariosAFK" %>
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
