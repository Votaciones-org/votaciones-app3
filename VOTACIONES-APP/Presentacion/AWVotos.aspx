<%@ Page Title="Gestión de Votos" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AWVotos.aspx.cs" Inherits="Presentacion.AWVotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Gestión de Votos</h1>
    <div>
        <!-- Formulario para registrar o actualizar un voto -->
        <div class="form-group">
            <asp:Label ID="LblId" runat="server" Text="" Visible="false"></asp:Label>

            <label for="TBNombre">Nombre:</label>
            <asp:TextBox ID="TBNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="TBApellido">Apellido:</label>
            <asp:TextBox ID="TBApellido" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="TBCedula">Cédula:</label>
            <asp:TextBox ID="TBCedula" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="TBOpcion">Opción:</label>
            <asp:TextBox ID="TBOpcion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <!-- Botones de acción -->
        <div class="btn-group">
            <asp:Button ID="BtnSave" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnSave_Click" />
            <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" CssClass="btn btn-warning" OnClick="BtnUpdate_Click" />
            <asp:Button ID="BtnClear" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="BtnClear_Click" />
        </div>

        <!-- Etiqueta para mostrar mensajes -->
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>

    <div>
        <!-- GridView para listar los votos -->
        <asp:GridView ID="GVVotos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnSelectedIndexChanged="GVVotos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="cedula" HeaderText="Cédula" />
                <asp:BoundField DataField="opcion" HeaderText="Opción" />
                <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>