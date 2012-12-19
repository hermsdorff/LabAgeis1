<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelecionarAgendamento.aspx.cs" Inherits="NET_Sistemas.SelecionarAgendamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr>
            <td>
                Selecione uma data:</td>
            <td colspan="2">
                <asp:TextBox ID="TxtData" runat="server" Enabled="False" 
                 Width="102px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Button ID="BtnMenos" runat="server" onclick="BtnMenos_Click" Text="&lt;" 
                    Width="43px" />
            </td>
            <td>
                <asp:Button ID="BtnMais" runat="server" onclick="BtnMais_Click" Text="&gt;" 
                    Width="43px" />
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="08:00 a 09:59">
                <ItemTemplate>
                    <asp:LinkButton ID="LnkBtnSelecionar" runat="server">(Selecionar...)</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="10:00 a 11:59">
            <ItemTemplate>
                    <asp:LinkButton ID="LnkBtnSelecionar2" runat="server">(Selecionar...)</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="14:00 a 15:59">
            <ItemTemplate>
                    <asp:LinkButton ID="LnkBtnSelecionar3" runat="server">(Selecionar...)</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="16:00 a 17:59">
            <ItemTemplate>
                    <asp:LinkButton ID="LnkBtnSelecionar4" runat="server">(Selecionar...)</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
