<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelecionarAgendamento.aspx.cs" Inherits="NET_Sistemas.SelecionarAgendamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </td>
            <td>
                <asp:GridView ID="GridView1" runat="server">
                    <Columns>
                        <asp:BoundField />
                        <asp:CheckBoxField DataField="venda" HeaderText="Vendas não agendadas" 
                            SortExpression="venda" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr> 
    </table><br />
    <br />
    </asp:Content>
