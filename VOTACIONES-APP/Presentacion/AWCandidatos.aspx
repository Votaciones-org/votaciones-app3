<<<<<<< HEAD
<<<<<<< HEAD
﻿<%@ Page Title="Gestión de Candidatos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCandidatos.aspx.cs" Inherits="Presentation.WFCandidatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí puedes agregar cualquier contenido que quieras dentro del <head> -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Candidatos</h1>
    <div>
        <!-- HiddenField para almacenar el ID del candidato seleccionado -->
        <asp:HiddenField ID="HFIdCandidato" runat="server" />

        <!-- Campos para ingresar la información del candidato -->
        <asp:Label ID="Label1" runat="server" Text="Ingrese el nombre del candidato"></asp:Label>
        <asp:TextBox ID="can_nombre" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label2" runat="server" Text="Ingrese el apellido del candidato"></asp:Label>
        <asp:TextBox ID="can_apellido" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label3" runat="server" Text="Ingrese el partido político"></asp:Label>
        <asp:TextBox ID="can_partido" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label4" runat="server" Text="Ingrese la fecha de nacimiento"></asp:Label>
        <asp:TextBox ID="can_fecha_nacimiento" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label5" runat="server" Text="Ingrese la propuesta del candidato"></asp:Label>
        <asp:TextBox ID="can_propuesta" runat="server"></asp:TextBox>
        <br />

        <!-- Botones para guardar y actualizar -->
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />

        <!-- GridView para mostrar la lista de candidatos -->
        <asp:GridView ID="GVClientes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVClientes_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="can_id" HeaderText="Id" />
                <asp:BoundField DataField="can_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="can_apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="can_partido" HeaderText="Partido" />
                <asp:BoundField DataField="can_fecha_nacimiento" HeaderText="Fecha de Nacimiento" />
                <asp:BoundField DataField="can_propuesta" HeaderText="Propuesta" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>


=======
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
﻿<%@ Page Title="Gestión de Candidatos" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AWCandidatos.aspx.cs" Inherits="Presentation.WFCandidatos" %>

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
<<<<<<< HEAD
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
=======
>>>>>>> 288737810150671c46f9d199d2c7e3f73c1e7378
