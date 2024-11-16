<%@ Page Title="Gestión de Candidatos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCandidatos.aspx.cs" Inherits="Presentation.WFCandidatos" %>

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
        <asp:GridView ID="GVClientes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVClientes_SelectedIndexChanged" OnRowCommand="GVClientes_RowCommand">
            <Columns>
                <asp:BoundField DataField="can_id" HeaderText="Id" SortExpression="can_id" />
                <asp:BoundField DataField="can_nombre" HeaderText="Nombre" SortExpression="can_nombre" />
                <asp:BoundField DataField="can_apellido" HeaderText="Apellido" SortExpression="can_apellido" />
                <asp:BoundField DataField="can_partido" HeaderText="Partido" SortExpression="can_partido" />
                <asp:BoundField DataField="can_fecha_nacimiento" HeaderText="Fecha de Nacimiento" SortExpression="can_fecha_nacimiento" />
                <asp:BoundField DataField="can_propuesta" HeaderText="Propuesta" SortExpression="can_propuesta" />
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>



