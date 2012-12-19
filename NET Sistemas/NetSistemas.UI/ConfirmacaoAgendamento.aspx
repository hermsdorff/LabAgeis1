<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacaoAgendamento.aspx.cs" Inherits="NET_Sistemas.ConfirmacaoAgendamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: right;
            width: 81px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
    <tr>
        <td class="style2">
            Funcionário:
        </td>
        <td>
            <asp:DropDownList ID="ddlFuncionario" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style2">
            Data:</td>
        <td>
            <asp:TextBox ID="txtData" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">
            Horário:</td>
        <td>
            <asp:TextBox ID="txtHorario" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnAgendar" runat="server" onclick="btnAgendar_Click" 
                Text="Agendar" />
        </td>
    </tr>
</table>
</asp:Content>
