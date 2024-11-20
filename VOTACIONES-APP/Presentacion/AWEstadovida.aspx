<%@ Page Title="Gestión de Estado de Vida" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AWEstadoVida.aspx.cs" Inherits="Presentation.AWEstadoVida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Incluir los estilos y scripts necesarios -->
    <link rel="stylesheet" href="Content/bootstrap.min.css">
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" class="container">
    <h1>Gestión de Estado de Vida</h1>

    <div>
        <!-- HiddenField para almacenar el ID del estado de vida seleccionado -->
        <asp:HiddenField ID="HFEstadoVidaId" runat="server" />

        <!-- Campos para ingresar la información del estado de vida -->
        <asp:Label ID="Label1" runat="server" Text="Ingrese el nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Label ID="Label2" runat="server" Text="Ingrese el apellido"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Label ID="Label3" runat="server" Text="Ingrese la cédula"></asp:Label>
        <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Label ID="Label4" runat="server" Text="Estado (Vivo/Defunto)"></asp:Label>
        <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Label ID="Label5" runat="server" Text="Fecha de Defunción (si aplica)"></asp:Label>
        <asp:TextBox ID="txtFechaDefuncion" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <!-- Botones para guardar y actualizar -->
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" Visible="false" CssClass="btn btn-warning" />
        <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
        <br />

        <!-- GridView para mostrar la lista de registros -->
        <asp:GridView ID="GVEstadoVida" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVEstadoVida_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Cedula" HeaderText="Cédula" SortExpression="Cedula" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                <asp:BoundField DataField="FechaDefuncion" HeaderText="Fecha de Defunción" SortExpression="FechaDefuncion" />
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

