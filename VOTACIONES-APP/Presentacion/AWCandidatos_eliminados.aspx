<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AWCandidatos_eliminados.aspx.cs" Inherits="Presentacion.AWCandidatos_eliminados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <!-- Labels y cajas de texto para cada atributo del candidato -->
        <asp:Label ID="LblId" runat="server" Text="" Visible="false"></asp:Label>
        
        <asp:Label ID="LblNombre" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LblApellido" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="TBApellido" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LblPartido" runat="server" Text="Partido:"></asp:Label>
        <asp:TextBox ID="TBPartido" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
        <asp:TextBox ID="TBFechaNacimiento" runat="server" TextMode="Date" AutoPostBack="true"></asp:TextBox>
        <br />

        <asp:Label ID="LblPropuesta" runat="server" Text="Propuesta:"></asp:Label>
        <asp:TextBox ID="TBPropuesta" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
        <br />

        <!-- Botones de acción para Guardar, Actualizar, y Eliminar -->
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Button ID="BtnDelete" runat="server" Text="Eliminar" OnClick="BtnDelete_Click" />
        <br />

        <!-- Etiqueta para mensajes -->
        <asp:Label ID="LblMsj" runat="server" Text="" ForeColor="Green"></asp:Label>
    </div>
    
    <div>
        <!-- GridView para mostrar la lista de candidatos eliminados -->
        <asp:GridView ID="GVCandidatosEliminados" runat="server" CssClass="table" AutoGenerateColumns="False" OnSelectedIndexChanged="GVCandidatosEliminados_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:BoundField DataField="apellido" HeaderText="Apellido" SortExpression="apellido" />
                <asp:BoundField DataField="partido" HeaderText="Partido" SortExpression="partido" />
                <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha de Nacimiento" SortExpression="fechaNacimiento" />
                <asp:BoundField DataField="propuesta" HeaderText="Propuesta" SortExpression="propuesta" />
                <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

