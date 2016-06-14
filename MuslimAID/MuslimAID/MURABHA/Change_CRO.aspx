<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Change_CRO.aspx.cs" Inherits="MuslimAID.MURABHA.Change_CRO" Title="Ventura Crystal Investments ltd ::: Change CRO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="text-align:left;">
            <tr>
                <td colspan="3" width="860px" class="PageTitle"><b>MF Application - Change CRO</b></td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td width="80px">City Code<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="760px">
                    <asp:Label ID="lblBranch" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Contract Code<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtCC" runat="server" Width="100px" AutoPostBack="true" 
                        ontextchanged="txtCC_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td width="80px">CRO<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="760px">
                    <asp:DropDownList ID="cmbRoot" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Enabled="false" 
                        onclick="btnSubmit_Click" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
