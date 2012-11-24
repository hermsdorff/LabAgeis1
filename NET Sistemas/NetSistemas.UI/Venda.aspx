<%@ Page Title="Venda" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Venda.aspx.cs" Inherits="NET_Sistemas.Venda" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            text-align: left;
        }
    .style4
    {
        text-align: right;
        width: 7%;
    }
    .style6
    {
        width: 75%;
    }
    .style7
    {
        width: 148px;
    }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Pedido
    </h2>
    <br />
    <table class="style1">
        <tr>
            <td class="style4">
        Cliente:</td>
            <td class="style7">
        <asp:DropDownList runat="server" ID="ddlCliente">
        </asp:DropDownList>
            &nbsp;<asp:Button ID="btnNovoCliente" runat="server" Text="Incluir +" 
                    onclick="btnNovo_Click" CausesValidation="False" />
            </td>
            <td rowspan="5" valign="top" class="style6">
                <asp:GridView ID="grvPedidos" runat="server" AutoGenerateColumns="False" 
                    onrowcommand="grvPedidos_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Cliente" DataField="NOMECLIENTE" />
                        <asp:BoundField HeaderText="Pacote" DataField="NOMEPACOTE" />
                        <asp:BoundField HeaderText="Valor" DataField="VALORVENDA" />
                        <asp:BoundField HeaderText="Vencimento" DataField="DATAVENCIMENTOFATURA" />
                        <asp:TemplateField HeaderText="Ação">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idVenda") %>' CausesValidation="false" />
                                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CommandName="excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idVenda") %>' OnClientClick="return confirm('Deseja realmente excluir este registro?')" CausesValidation="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style4">
        Pacote:
            </td>
            <td class="style7">
                <asp:DropDownList ID="ddlPacote" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Vencimento:
            </td>
            <td class="style7">
                <asp:TextBox ID="txtVencimento" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtVencimento" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ControlToValidate="txtVencimento" 
                    ErrorMessage="Data Inválida! A data tem que ser maior que hoje e no máximo daqui a um ano!" 
                    ForeColor="#990000" 
                    ToolTip="Data Inválida! A data tem que ser maior que hoje e no máximo daqui a um ano!" 
                    Type="Date">*</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Status</td>
            <td class="style7">
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="A">Ativo</asp:ListItem>
                    <asp:ListItem Value="C">Cancelado</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                Observação:<br />
                <asp:TextBox ID="txtObservacao" runat="server" Height="96px" 
                    TextMode="MultiLine" Width="198px"></asp:TextBox>
                <asp:HiddenField ID="HiddenFieldCliente" runat="server" />
            </td>
        </tr>
        </table>
    <p>
        &nbsp;<asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
            onclick="btnSalvar_Click" />
&nbsp;<asp:Button ID="btnNovo" runat="server" Text="Novo" onclick="btnNovo_Click" 
            CausesValidation="False" />
        <br />
    </p>
</asp:Content>
