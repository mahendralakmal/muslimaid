<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewLoanDetails.aspx.cs" Inherits="MuslimAID.MURABAHA.ViewLoanDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ventura Crystal Investments Ltd ::: Loan Approval</title>
    <link rel="stylesheet" type="text/css" media="all" href="../CSS/Main.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="500px" align="left">
            <tr>
                <td colspan="3" width="500px" class="PageTitle">Loan Approval Details</td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td width="100px">Facility Code<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="380px">
                    <asp:Label ID="lblCC" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Loan Approval<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:DropDownList ID="cmbApproval" runat="server" TabIndex="0">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Next Center Day<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:CheckBox ID="chbNxtCcenterDay" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td valign="top">Description</td>
                <td valign="top">:</td>
                <td>
                    <asp:TextBox ID="txtDescription" TabIndex="1" TextMode="MultiLine" CssClass="addressText" Width="300px" Height="70px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td valign="top"></td>
                <td valign="top"></td>
                <td>
                    <asp:Button ID="btnApproved" TabIndex="2" runat="server" Text="Approved" 
                        onclick="btnApproved_Click" />&nbsp;
                    <asp:Label ID="lblCAMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
