<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Recipt_Cancel.aspx.cs" Inherits="MuslimAID.MURABHA.Recipt_Cancel" Title="Ventura Crystal Investments Ltd ::: Receipt Cancel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="text-align:left;">
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td colspan="3" width="860px" class="PageTitle">Receipt Cansel</td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td width="100px">Receipt No <span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="740px">
                    <asp:TextBox ID="txtRNo" MaxLength="6" AutoPostBack="true" runat="server" Width="110px" 
                        TabIndex="0" ontextchanged="txtRNo_TextChanged" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Contract Code</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblContractCode" runat="server"></asp:Label> 
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>NIC</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblNIC" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Name</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label> 
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Type</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblType" runat="server"></asp:Label> 
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Amount</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblAmount" runat="server"></asp:Label> 
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td valign="top">Comment <span style="color:Red;">*</span></td>
                <td valign="top">:</td>
                <td>
                    <asp:TextBox ID="txtComment" runat="server" Width="300px" TextMode="MultiLine" Height="75px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td>
                    <asp:Button ID="btnPeied" runat="server" Enabled="false" TabIndex="3" 
                        Text="Cansel" onclick="btnPeied_Click" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="30px"></td>
            </tr>
        </table>
    </div>
</asp:Content>
