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
    <asp:TextBox ID="txtNome" runat="server" Width="400px" MaxLength="45"></asp:TextBox>
</td>
</tr>

<tr>
<td>
    <asp:Label ID="Label2" runat="server" Text="Descrição:"></asp:Label>
</td>

<td>
    <asp:TextBox ID="txtDescricao" runat="server" Width="400px" Height="100px" 
        TextMode="MultiLine" MaxLength="45"></asp:TextBox>
</td>
</tr>

<tr>
<td>
    <asp:Label ID="Label3" runat="server" Text="Valor:"></asp:Label>
</td>

<td>
    <asp:TextBox ID="txtValor" runat="server" Width="200px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" onclick="btnSalvar_Click" 
        Width="55px" />
</td>
<td>
    <asp:Button ID="btnNovo" runat="server" Text="Novo" Width="80px" onclick="btnNovo_Click"/>
&nbsp;&nbsp;
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
        onclick="btnCancelar_Click" />
</td>
</tr>

</table>
        <asp:HiddenField ID="txtIdPacote" runat="server" />
    <p>
                <asp:GridView ID="grvPacote" runat="server" AutoGenerateColumns="False" 
                    onrowcommand="grvPacote_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="NOMEPACOTE" HeaderText="Nome" />
                        <asp:BoundField DataField="DESCPACOTE" HeaderText="Descrição" />
                        <asp:BoundField DataField="VALORPACOTE" HeaderText="Valor" />
                        <asp:TemplateField HeaderText="Ação">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDPACOTES") %>' />
                                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CommandName="excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDPACOTES") %>' OnClientClick="return confirm('Deseja realmente excluir este registro?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        <br />
    </p>
</asp:Content>
