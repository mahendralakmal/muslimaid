<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="RemoveChequeBookHistry.aspx.cs" Inherits="MuslimAID.MURABAHA.RemoveChequeBookHistry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="text-align: left;">
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td colspan="3" width="860px" class="PageTitle">
                    Cheque Removal
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td>
                    Cheque
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="cmbChqNo" AutoPostBack="true" TabIndex="1" runat="server" OnSelectedIndexChanged="cmbChqNo_SelectedIndexChanged" Width="110px" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td width="100px">
                    Cheque No<span style="color: Red;">*</span>
                </td>
                <td width="20px">
                    :
                </td>
                <td width="740px">
                    <asp:TextBox ID="txtRNo" MaxLength="15" AutoPostBack="true" runat="server" Width="110px"
                        TabIndex="0" OnTextChanged="txtRNo_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td>
                    Create User
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:Label ID="lblNIC" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td>
                    Create Date
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:Label ID="lblChequeDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td>
                    Account No
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:Label ID="lblAccountNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Comment <span style="color: Red;">*</span>
                </td>
                <td valign="top">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtComment" runat="server" Width="300px" TextMode="MultiLine" Height="75px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
                <td>
                    <asp:Button ID="btnPeied" runat="server" Enabled="false" TabIndex="3" Text="Remove"
                        OnClick="btnPeied_Click" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="30px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
