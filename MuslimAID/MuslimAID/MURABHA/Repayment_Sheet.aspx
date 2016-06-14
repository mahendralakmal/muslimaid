<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Repayment_Sheet.aspx.cs" Inherits="MuslimAID.MURABHA.Repayment_Sheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ventura Crystal Investments Ltd ::: CS - Repayment Sheet</title>
    
    <script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../js/calendar-en.min.js" type="text/javascript"></script>
    <link href="../CSS/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/DateTimeTasks.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    
    <script type="text/javascript">
        function PrintGridData() {
        var prtGrid = document.getElementById('<%=pnlViewData.ClientID %>');
        prtGrid.border = "1px";
        prtGrid.style.fontSize="10pt";
        prtGrid.style.fontFamily="Calibri";
        var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
        //prtwin.document.write("<div style='font-size:10pt;font-family:Calibri;'>Ventura Crystal Investments Ltd - PRBF - Repayment Sheet</div>");
        prtwin.document.write(prtGrid.outerHTML);
        prtwin.document.close();
        prtwin.focus();
        prtwin.print();
        prtwin.close();
        }
    </script>
</head>
<body style="font-family:Calibri; font-size:10pt;">
    <form id="form1" runat="server">
    <div align="center" id="RepaySheet">
        <asp:Panel ID="pnlSearch" runat="server" Visible="true">
            <table cellpadding="0" cellspacing="0" border="0" align="left">
                <tr align="left">
                    <td>City Code</td>
                    <td width="10px" align="center">:</td>
                    <td>
                        <asp:DropDownList ID="cmbCityCode" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="cmbCityCode_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td width="10px"></td>
                    <td>Society ID</td>
                    <td width="10px" align="center">:</td>
                    <td>
                        <asp:DropDownList ID="cmbSocietyID" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td width="10px"></td>
                    <td>
                        <asp:Button ID="btnSerch" runat="server" Text="Search" 
                            onclick="btnSerch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="13" height="10px"></td>
                </tr>
                <tr align="left">
                    <td>CRO</td>
                    <td width="10px" align="center">:</td>
                    <td>
                        <asp:DropDownList ID="cmbRoot" runat="server" Enabled="false">
                        </asp:DropDownList>
                    </td>
                    <td width="10px"></td>
                    <td>Date</td>
                    <td width="10px" align="center">:</td>
                    <td>
                        <asp:TextBox ID="txtDate" MaxLength="10" runat="server"></asp:TextBox>(1990-12-25)<img src="../Images/calender.png" />
                    </td>
                    <td width="10px"></td>
                    <td>
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="13" height="10px"></td>
                </tr>
                <tr>
                    <td colspan="13">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="13" height="10px"></td> 
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlViewData" runat="server" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" width="1000px">
                <tr>
                    <td colspan="4" height="10px"></td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <b>Ventura Crystal Investments Ltd - CS - Repayment Sheet</b><br />
                        <asp:Label ID="lblBranchCode" runat="server"></asp:Label> - <asp:Label ID="lblSocietyName" runat="server"></asp:Label>
                        ( <asp:Label ID="lblDate" runat="server"></asp:Label> )
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="10px"></td>
                </tr>
                <tr>
                    <td colspan="4" valign="top">
                        <asp:Panel ID="pnlRepaySheet" runat="server">
                            <asp:GridView ID="grvRepaySheet" runat="server" AutoGenerateColumns="true" Font-Size="9pt" BorderWidth="1px" BorderColor="Black" Width="1000px">
                                <Columns>
                                    
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="20px"></td>
                </tr>
            <tr>
                <td width="200px"></td>
                <td width="100px" align="left">Page Total</td>
                <td width="240px"></td>
                <td align="left">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" height="10px"></td>
            </tr>
            <tr>
                <td width="200px"></td>
                <td width="100px" align="left">Total</td>
                <td width="240px"></td>
                <td align="left">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" height="10px"></td>
            </tr>
            <tr>
                <td width="200px"></td>
                <td width="100px" align="left">Slip Number</td>
                <td width="240px"></td>
                <td align="left">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" height="10px"></td>
            </tr>
            <tr>
                <td width="200px"></td>
                <td width="100px" align="left">Root Manager</td>
                <td width="240px"></td>
                <td align="left">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" height="10px"></td>
            </tr>
            <tr>
                <td width="200px"></td>
                <td width="100px" align="left">Cashier</td>
                <td width="240px"></td>
                <td align="left">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" height="10px"></td>
            </tr>
            <tr>
                <td width="200px"></td>
                <td width="100px" align="left">Manager</td>
                <td width="240px"></td>
                <td align="left">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" height="10px"></td>
            </tr>
            <tr>
                <td width="200px"></td>
                <td width="100px" align="left">Regional Manager</td>
                <td width="240px"></td>
                <td align="left">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" height="10px"></td>
            </tr>
            <tr>
                <td width="200px"></td>
                <td width="100px" align="left">Top Management</td>
                <td width="240px"></td>
                <td align="left">
                    <hr />
                </td>
            </tr>
            </table>
        </asp:Panel>
    </div>
    <div align="right">
        <input type="button" id="btnPrint" value="Print" onclick="PrintGridData()" />
    </div>
    </form>
</body>
</html>
