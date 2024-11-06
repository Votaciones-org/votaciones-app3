<%@ Page Title="Gestión de Candidatos" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AWCandidatos.aspx.cs" Inherits="Presentation.WFCandidatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro y Gestión de Candidatos</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Gestión de Candidatos</h2>

        <form id="formCandidato" runat="server">
            <label for="can_nombre">Nombre:</label>
            <asp:TextBox ID="can_nombre" runat="server" required="true"></asp:TextBox>

            <label for="can_apellido">Apellido:</label>
            <asp:TextBox ID="can_apellido" runat="server" required="true"></asp:TextBox>

            <label for="can_partido">Partido:</label>
            <asp:TextBox ID="can_partido" runat="server" required="true"></asp:TextBox>

            <label for="can_fecha_nacimiento">Fecha de Nacimiento:</label>
            <asp:TextBox ID="can_fecha_nacimiento" runat="server" TextMode="Date" required="true"></asp:TextBox>

            <label for="can_propuesta">Propuesta:</label>
            <asp:TextBox ID="can_propuesta" runat="server" TextMode="MultiLine" Rows="4" required="true"></asp:TextBox>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Candidato" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Candidato" OnClick="btnActualizar_Click" />
        </form>

        <asp:GridView ID="GVClientes" runat="server" AutoGenerateColumns="True"></asp:GridView>

        <div class="message">
            <!-- Mensajes de éxito o error -->
        </div>
    </div>
</asp:Content>
