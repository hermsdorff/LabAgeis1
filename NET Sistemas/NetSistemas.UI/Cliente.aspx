<%@ Page Title="Venda" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Cliente.aspx.cs" Inherits="NET_Sistemas.Cliente" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style4
    {
        text-align: right;
        width: 7%;
    }
    .style7
    {
        width: 148px;
    }
        .style10
        {
            width: 29px;
        }
        .style11
        {
            width: 540px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Cliente
    </h2>
    <br />
    <table class="style1">
        <tr>
            <td class="style4">
                Nome:</td>
            <td class="style7">
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </td>
            <td class="style4">
                Tipo:</td>
            <td class="style11">
                <asp:DropDownList ID="ddlTipo" runat="server">
                    <asp:ListItem Value="F">Fisica</asp:ListItem>
                    <asp:ListItem Value="J">Juridica</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                CPF/CNPJ:
            </td>
            <td class="style7">
                <asp:TextBox ID="txtCPFCNPJ" runat="server"></asp:TextBox>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Logradouro:
            </td>
            <td class="style7">
                <asp:TextBox ID="txtLogradouro" runat="server"></asp:TextBox>
            </td>
            <td class="style4">
                Número:</td>
            <td class="style11">
                <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Bairro:</td>
            <td class="style7">
                <asp:TextBox ID="txtBairro" runat="server"></asp:TextBox>
            </td>
            <td class="style4">
                Complemento:</td>
            <td class="style11">
                <asp:TextBox ID="txtComplemento" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                CEP:</td>
            <td class="style7">
                <asp:TextBox ID="txtCEP" runat="server"></asp:TextBox>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Cidade:</td>
            <td class="style7">
                <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Estado:</td>
            <td class="style7">
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem Value="AC">Acre</asp:ListItem>
                    <asp:ListItem Value="AL">Alagoas</asp:ListItem>
                    <asp:ListItem Value="AP">Amapá</asp:ListItem>
                    <asp:ListItem Value="AM">Amazonas</asp:ListItem>
                    <asp:ListItem Value="BA">Bahia</asp:ListItem>
                    <asp:ListItem Value="CE">Ceará</asp:ListItem>
                    <asp:ListItem Value="DF">Distrito Federal</asp:ListItem>
                    <asp:ListItem Value="ES">Espírito Santo</asp:ListItem>
                    <asp:ListItem Value="GO">Goiás</asp:ListItem>
                    <asp:ListItem Value="MA">Maranhão</asp:ListItem>
                    <asp:ListItem Value="MT">Mato Grosso</asp:ListItem>
                    <asp:ListItem Value="MS">Mato Grosso do Sul</asp:ListItem>
                    <asp:ListItem Value="MG">Minas Gerais</asp:ListItem>
                    <asp:ListItem Value="PA">Pará</asp:ListItem>
                    <asp:ListItem Value="PB">Paraíba</asp:ListItem>
                    <asp:ListItem Value="PR">Paraná</asp:ListItem>
                    <asp:ListItem Value="PE">Pernambuco</asp:ListItem>
                    <asp:ListItem Value="PI">Piauí</asp:ListItem>
                    <asp:ListItem Value="RJ">Rio de Janeiro</asp:ListItem>
                    <asp:ListItem Value="RN">Rio Grande do Norte</asp:ListItem>
                    <asp:ListItem Value="RS">Rio Grande do Sul</asp:ListItem>
                    <asp:ListItem Value="RO">Rondônia</asp:ListItem>
                    <asp:ListItem Value="RR">Roraima</asp:ListItem>
                    <asp:ListItem Value="SC">Santa Catarina</asp:ListItem>
                    <asp:ListItem Value="SP">São Paulo</asp:ListItem>
                    <asp:ListItem Value="SE">Sergipe</asp:ListItem>
                    <asp:ListItem Value="TO">Tocantins</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
        </tr>
        </table>
    <p>
        &nbsp;<asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
            onclick="btnSalvar_Click" />
&nbsp;<asp:Button ID="btnNovo" runat="server" Text="Novo" onclick="btnNovo_Click" />
        <asp:HiddenField ID="txtidcliente" runat="server" />
    </p>
    <p>
                <asp:GridView ID="grvClientes" runat="server" AutoGenerateColumns="False" 
                    onrowcommand="grvClientes_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="NOME" HeaderText="NOME" />
                        <asp:BoundField DataField="CPJCNPJ" HeaderText="CPJ/CNPJ" />
                        <asp:BoundField DataField="TIPOPESSOA" HeaderText="TIPOPESSOA" />
                        <asp:TemplateField HeaderText="Ação">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdCliente") %>' />
                                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CommandName="excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdCliente") %>' OnClientClick="return confirm('Deseja realmente excluir este registro?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        <br />
    </p>
</asp:Content>
