<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Debit_Note.aspx.cs" Inherits="MuslimAID.MURABHA.Debit_Note" Title="Ventura Crystal Investments Ltd ::: Debit Note" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
            <tr>
                <td height="10px"></td>
            </tr>
            <tr>
                <td width="860px" class="PageTitle">Micro Debit - Run</td>
            </tr>
            <tr>
                <td height="10px"></td>
            </tr>
            <tr>
                <td width="860px">
                    <asp:TextBox ID="txtDate" Width="200px" runat="server"></asp:TextBox>
                    <asp:Button ID="btnEndDay" runat="server" Text="Run" 
                        onclick="btnEndDay_Click" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="50px"></td>
            </tr>
        </table>
    </div>
</asp:Content>
