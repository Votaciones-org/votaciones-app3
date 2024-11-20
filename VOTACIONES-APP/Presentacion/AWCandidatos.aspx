<%@ Page Title="Gestión de Candidatos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AWCandidatos.aspx.cs" Inherits="Presentation.AWCandidatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Aquí puedes agregar cualquier contenido que quieras dentro del <head> -->
    
    <link rel="stylesheet" href="Content/bootstrap.min.css">
<script src="Scripts/bootstrap.min.js"></script>
<script src="Scripts/jquery-1.9.1.min.js"></script> 
   

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" class="container">
    <h1>Gestión de Candidatos</h1>
    <div>
        <!-- HiddenField para almacenar el ID del candidato seleccionado -->
        <asp:HiddenField ID="HFCandidatoId" runat="server" />

        <!-- Campos para ingresar la información del candidato -->
        <asp:Label ID="Label1" runat="server" Text="Ingrese el nombre del candidato"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label2" runat="server" Text="Ingrese el apellido del candidato"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label3" runat="server" Text="Ingrese el partido político"></asp:Label>
        <asp:TextBox ID="txtPartido" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label4" runat="server" Text="Ingrese la fecha de nacimiento"></asp:Label>
        <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label5" runat="server" Text="Ingrese la propuesta del candidato"></asp:Label>
        <asp:TextBox ID="txtPropuesta" runat="server"></asp:TextBox>
        <br />

       
        
        <!-- Botones para guardar y actualizar -->
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" Visible="false" />
        <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
        <br />

        <!-- GridView para mostrar la lista de candidatos -->
        <asp:GridView ID="GVCandidatos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVCandidatos_SelectedIndexChanged" OnRowCommand="GVCandidatos_RowCommand">
            <Columns>
                <asp:BoundField DataField="candidato_id" HeaderText="ID" SortExpression="candidato_id" />
                <asp:BoundField DataField="candidato_nombre" HeaderText="Nombre" SortExpression="candidato_nombre" />
                <asp:BoundField DataField="candidato_apellido" HeaderText="Apellido" SortExpression="candidato_apellido" />
                <asp:BoundField DataField="candidato_partido" HeaderText="Partido" SortExpression="candidato_partido" />
                <asp:BoundField DataField="candidato_fecha_nacimiento" HeaderText="Fecha de Nacimiento" SortExpression="candidato_fecha_nacimiento" />
                <asp:BoundField DataField="candidato_propuesta" HeaderText="Propuesta" SortExpression="candidato_propuesta" />
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>





