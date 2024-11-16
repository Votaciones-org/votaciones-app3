<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Presentacion.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Mensaje de bienvenida -->
    <asp:Label ID="LblBienvenido" runat="server" Text="Bienvenido a las votaciones" Font-Bold="True" Font-Size="24px" ForeColor="Green" />
</asp:Content>
