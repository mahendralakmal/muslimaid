<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewChequDetails.aspx.cs" Inherits="MuslimAID.MURABHA.ViewChequDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Cheque Approval</title>
    <link rel="stylesheet" type="text/css" media="all" href="../CSS/Main.css" />
    <script type="text/javascript" src="../js/DateTimeTasks.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="500px" align="left">
            <tr>
                <td colspan="3" width="500px" class="PageTitle">Chequ Details</td>
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
                <td valign="top">Chequ Number<span style="color:Red;">*</span></td>
                <td valign="top">:</td>
                <td>
                    <asp:DropDownList ID="cmbChqNo" AutoPostBack="true" TabIndex="1" runat="server" onselectedindexchanged="cmbChqNo_SelectedIndexChanged"
                        >
                    </asp:DropDownList>
                    <asp:TextBox ID="txtCNumber" MaxLength="20" TabIndex="0" Width="120px" 
                        runat="server" onkeydown="return isNumeric(event.keyCode);"
                                onKeypress="javascript:return check(event);" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td valign="top">Chequ Amount<span style="color:Red;">*</span></td>
                <td valign="top">:</td>
                <td>
                    <asp:TextBox ID="txtCAmount" runat="server" TabIndex="1" Width="120px" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td valign="top">Chequ Name<span style="color:Red;">*</span></td>
                <td valign="top">:</td>
                <td>
                    <asp:TextBox ID="txtChequName" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td valign="top">Bank Name<span style="color:Red;">*</span></td>
                <td valign="top">:</td>
                <td>
                    <asp:DropDownList ID="cmbBankName" AutoPostBack="true" TabIndex="1" runat="server"
                        OnSelectedIndexChanged="cmbBankName_SelectedIndexChanged" Width="250px">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtBankName" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td valign="top">Account No<span style="color:Red;">*</span></td>
                <td valign="top">:</td>
                <td>
                    <asp:TextBox ID="txtAccNo" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td valign="top">Chequ Date<span style="color:Red;">*</span></td>
                <td valign="top">:</td>
                <td align="left">
                    <asp:TextBox ID="txtDate1" runat="server" MaxLength="1" Width="20px"></asp:TextBox>D
                    <asp:TextBox ID="txtDate2" runat="server" MaxLength="1" Width="20px"></asp:TextBox>D
                    <asp:TextBox ID="txtMonth1" runat="server" MaxLength="1" Width="20px"></asp:TextBox>M
                    <asp:TextBox ID="txtMonth2" runat="server" MaxLength="1" Width="20px"></asp:TextBox>M
                    <asp:TextBox ID="txtYear1" runat="server" MaxLength="1" Width="20px"></asp:TextBox>Y
                    <asp:TextBox ID="txtYear2" runat="server" MaxLength="1" Width="20px"></asp:TextBox>Y
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td valign="top"></td>
                <td valign="top"></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" TabIndex="2" Text="Submit" 
                        onclick="btnSubmit_Click"/>&nbsp;
                    <asp:Label ID="lblCDMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
