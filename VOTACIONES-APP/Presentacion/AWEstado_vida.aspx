<%@ Page Title="Gestión Estado de Vida" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFEstadoVida.aspx.cs" Inherits="Presentation.WFEstadoVida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <!-- Formulario para gestionar el estado de vida -->
        <h3>Gestión de Estado de Vida</h3>
        <asp:Label ID="LblId" runat="server" Text="" Visible="false"></asp:Label>
        
        <asp:Label ID="LblNombre" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LblApellido" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="TBApellido" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LblCedula" runat="server" Text="Cédula:"></asp:Label>
        <asp:TextBox ID="TBCedula" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LblEstado" runat="server" Text="Estado:"></asp:Label>
        <asp:DropDownList ID="DDLEstado" runat="server">
            <asp:ListItem Value="Vivo">Vivo</asp:ListItem>
            <asp:ListItem Value="Fallecido">Fallecido</asp:ListItem>
        </asp:DropDownList>
        <br />

        <asp:Label ID="LblFechaDefuncion" runat="server" Text="Fecha de Defunción:" Visible="false"></asp:Label>
        <asp:TextBox ID="TBFechaDefuncion" runat="server" Visible="false"></asp:TextBox>
        <br />

        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Button ID="BtnDelete" runat="server" Text="Eliminar" OnClick="BtnDelete_Click" />
        <br />

        <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
    </div>
    
    <!-- GridView para mostrar registros -->
    <div>
        <asp:GridView ID="GVEstadoVida" runat="server" CssClass="table" AutoGenerateColumns="False" OnSelectedIndexChanged="GVEstadoVida_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="cedula" HeaderText="Cédula" />
                <asp:BoundField DataField="estado" HeaderText="Estado" />
                <asp:BoundField DataField="fechaDefuncion" HeaderText="Fecha de Defunción" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
