<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Slip_Transfer_Format_Export.aspx.cs" Inherits="MuslimAID.MURABHA.Slip_Transfer_Format_Export" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PCA ::: Slip Transfer Format - CS</title>
</head>
<body style="font-family:Calibri;">
    <form id="form1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" align="left">
            <tr>
                <td align="left"><b>CS - Slip Transfer Format</b></td>
            </tr>
            <tr>
                <td height="10px">
                    <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:DropDownList ID="cmbTransfer" runat="server" AutoPostBack="true"
                        onselectedindexchanged="cmbTransfer_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp; 
                    <asp:Button ID="btnSearch" runat="server" Text="Search" Enabled="false" 
                        onclick="btnSearch_Click" />
                        &nbsp;&nbsp;
                    <asp:Button ID="btnExport" runat="server" Text="Export" 
                        onclick="btnExport_Click" />
                </td>
            </tr>
            <tr>
                <td height="10px"></td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlARep" runat="server">
                        <asp:GridView ID="grvArRep" Font-Size="9pt" runat="server" BorderWidth="0px" RowStyle-BorderStyle="None" SelectedRowStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" PagerStyle-BorderStyle="None" AlternatingRowStyle-BorderStyle="None" BorderStyle="None" RowStyle-VerticalAlign="Top">
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
