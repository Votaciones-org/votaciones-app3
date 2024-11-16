<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AWVotos.aspx.cs" Inherits="Presentacion.AWVotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <!-- Etiquetas y cajas de texto para cada atributo del voto -->
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

        <asp:Label ID="LblOpcion" runat="server" Text="Opción:"></asp:Label>
        <asp:TextBox ID="TBOpcion" runat="server"></asp:TextBox>
        <br />

        <!-- Botones de acción para Guardar y Actualizar -->
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <br />

        <!-- Etiqueta para mensajes -->
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
    </div>
    
    <div>
        <!-- GridView para mostrar la lista de votos -->
        <asp:GridView ID="GVVotos" runat="server" CssClass="table" AutoGenerateColumns="False" OnSelectedIndexChanged="GVVotos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="cedula" HeaderText="Cédula" />
                <asp:BoundField DataField="opcion" HeaderText="Opción" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
