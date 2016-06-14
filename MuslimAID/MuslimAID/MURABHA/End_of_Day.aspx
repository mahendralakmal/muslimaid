<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="End_of_Day.aspx.cs" Inherits="MuslimAID.MURABHA.End_of_Day" Title="Ventura Crystal Investments Ltd ::: CS End of the Day." %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
            <tr>
                <td width="860px" class="PageTitle">Run</td>
            </tr>
            <tr>
                <td height="10px"></td>
            </tr>
            <tr>
                <td width="860px">
                    <asp:Button ID="btnEndDay" runat="server" Text="Run" 
                        onclick="btnEndDay_Click" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
