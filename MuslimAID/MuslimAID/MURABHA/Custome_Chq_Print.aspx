<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Custome_Chq_Print.aspx.cs" Inherits="MuslimAID.MURABHA.Custome_Chq_Print" Title="Ventura Crystal Investments Ltd ::: Custome Chequ Print" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
            <tr>
                <td width="860px" class="PageTitle">Cheque Details</td>
            </tr>
            <tr>
                <td height="10px"></td>
            </tr>
            <tr>
                <td>Contract Code</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtCC" runat="server" MaxLength="12" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="10px"></td>
            </tr>
            <tr>
                <td>Cheque Name</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="12" Width="120px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
