<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManterPacotes.aspx.cs" Inherits="NET_Sistemas.ManterPacotes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="Nome:"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtNome" runat="server" Width="400px"></asp:TextBox>
</td>
</tr>

<tr>
<td>
    <asp:Label ID="Label2" runat="server" Text="Descrição:"></asp:Label>
</td>

<td>
    <asp:TextBox ID="txtDescricao" runat="server" Width="400px" Height="100px" 
        TextMode="MultiLine"></asp:TextBox>
</td>
</tr>

<tr>
<td>
    <asp:Label ID="Label3" runat="server" Text="Valor::"></asp:Label>
</td>

<td>
    <asp:TextBox ID="txtValor" runat="server" Width="200px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Button ID="Button1" runat="server" Text="Salvar" onclick="Button1_Click" />
</td>
<td>
    <asp:Button ID="Button2" runat="server" Text="Cancelar" />
</td>
</tr>

</table>
</asp:Content>
