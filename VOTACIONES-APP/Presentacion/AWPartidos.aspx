<%@ Page Title="Partidos y Candidatos" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFPartidos.aspx.cs" Inherits="Presentation.WFPartidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <!-- Formulario para gestión de partidos -->
        <h3>Gestión de Partidos</h3>
        <asp:Label ID="LblPartidoId" runat="server" Text="" Visible="false"></asp:Label>
        
        <asp:Label ID="LblNombrePartido" runat="server" Text="Nombre del Partido:"></asp:Label>
        <asp:TextBox ID="TBNombrePartido" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LblDescripcion" runat="server" Text="Descripción:"></asp:Label>
        <asp:TextBox ID="TBDescripcion" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
        <br />

        <asp:Button ID="BtnSavePartido" runat="server" Text="Guardar Partido" OnClick="BtnSavePartido_Click" />
        <asp:Button ID="BtnUpdatePartido" runat="server" Text="Actualizar Partido" OnClick="BtnUpdatePartido_Click" />
        <asp:Button ID="BtnDeletePartido" runat="server" Text="Eliminar Partido" OnClick="BtnDeletePartido_Click" />
        <br />

        <asp:Label ID="LblMsjPartido" runat="server" Text=""></asp:Label>
    </div>
    
    <div>
        <asp:GridView ID="GVPartidos" runat="server" CssClass="table" AutoGenerateColumns="False" OnSelectedIndexChanged="GVPartidos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="nombrePartido" HeaderText="Nombre del Partido" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    
    <!-- Formulario para asignación de candidatos a partidos -->
    <h3>Asignación de Candidatos a Partidos</h3>
    <div>
        <asp:Label ID="LblCandidatoId" runat="server" Text="" Visible="false"></asp:Label>

        <asp:Label ID="LblPartidoDDL" runat="server" Text="Seleccione Partido:"></asp:Label>
        <asp:DropDownList ID="DDLPartido" runat="server"></asp:DropDownList>
        <br />

        <asp:Label ID="LblNombreCandidato" runat="server" Text="Nombre del Candidato:"></asp:Label>
        <asp:TextBox ID="TBNombreCandidato" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="LblApellidoCandidato" runat="server" Text="Apellido del Candidato:"></asp:Label>
        <asp:TextBox ID="TBApellidoCandidato" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="BtnSaveCandidato" runat="server" Text="Guardar Candidato" OnClick="BtnSaveCandidato_Click" />
        <asp:Button ID="BtnUpdateCandidato" runat="server" Text="Actualizar Candidato" OnClick="BtnUpdateCandidato_Click" />
        <asp:Button ID="BtnDeleteCandidato" runat="server" Text="Eliminar Candidato" OnClick="BtnDeleteCandidato_Click" />
        <br />

        <asp:Label ID="LblMsjCandidato" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>