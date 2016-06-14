<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="MuslimAID.MURABHA.Receipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ventura Crystal Investments Ltd ::: MF Receipt</title>
    <script type='text/javascript'>
        function prnt(){
            var prtGrid = document.getElementById('<%=pnlRec.ClientID %>');
            prtGrid.style.fontSize="9pt";
            prtGrid.style.fontFamily="Calibri";
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=400,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write('MF Receipt ::: Ventura Crystal Investments Ltd');
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
        
    </script>
</head>
<body style="font-family:Calibri; font-size:9pt;">
    <form id="form1" runat="server">
    <div align="center"  id="divRec">
        <asp:Panel ID="pnlRec" runat="server">
            <table cellpadding="0" cellspacing="0" border="0" width="400px" align="left" style="font-size:9pt; font-family:Calibri;">
            <tr>
                <td valign="top" colspan="7" align="center">
                    <b>Ventura Crystal Investments Ltd</b><br />
                    Capital Supply Facillity - Receipt
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td width="100px">Center</td>
                <td width="20px">:</td>
                <td>
                    <asp:Label ID="lblCenter" runat="server"></asp:Label>
                </td>
                <td width="15px"></td>
                <td width="50px">No</td>
                <td width="20px">:</td>
                <td>
                    <asp:Label ID="lblContrNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="5px"></td>
            </tr>
            <tr>
                <td>Date & Time</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                </td>
                <td width="15px"></td>
                <td>Rcp No</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblRecNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="5px"></td>
            </tr>
            <tr>
                <td>REF</td>
                <td>:</td>
                <td colspan="5">
                    CS Recoveries
                </td>
            </tr>
            <tr>
                <td colspan="7" height="5px"></td>
            </tr>
            <tr>
                <td>Type</td>
                <td>:</td>
                <td colspan="5">
                    Rental Payment
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <hr />
                </td>
            </tr>
            <tr>
                <td>NIC</td>
                <td>:</td>
                <td colspan="5">
                    <asp:Label ID="lblNIC" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td colspan="7">
                    Received a sum of Rs.<asp:Label ID="lblAmou" runat="server"></asp:Label> In Cash.<br />
                    <asp:Label ID="lblAmouText" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td valign="top">From</td>
                <td valign="top">:</td>
                <td colspan="5">
                    <asp:Label ID="lblName" runat="server"></asp:Label><br />
                    <asp:Label ID="lblAddrss" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td colspan="7"><b>Details</b></td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td valign="top">Total Rs.</td>
                <td valign="top">:</td>
                <td colspan="5">
                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="20px"></td>
            </tr>
            <tr>
                <td colspan="7">
                    Cashier(<asp:Label ID="lblCasName" runat="server"></asp:Label>)
                </td>
            </tr>
            <tr>
                <td colspan="7" height="5px"></td>
            </tr>
            <tr>
                <td colspan="7" align="center">
                -------------------------------------------------------------------------------------------------------------------
                </td>
            </tr>
            <tr>
                <td colspan="7" height="5px"></td>
            </tr>
            <tr>
                <td colspan="7">
                   <table cellpadding="0" cellspacing="0" border="0" width="400px" align="left" style="font-family:Calibri; font-size:9pt;">
                        <tr>
                            <td width="110px">
                                Arrears
                            </td>
                            <td width="35px"></td>
                            <td width="110px">Full Balance</td>
                            <td width="35px"></td>
                            <td width="110px">Due Date</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblArrears" runat="server"></asp:Label>
                            </td>
                            <td></td>
                            <td>
                                <asp:Label ID="lblFullBal" runat="server"></asp:Label>
                            </td>
                            <td></td>
                            <td>
                                <asp:Label ID="lblDueDa" runat="server"></asp:Label>
                            </td>
                        </tr>
                   </table>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="5px"></td>
            </tr>
            <tr>
                <td colspan="7" align="center">
                    -------------------------------------------------------------------------------------------------------------------
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td colspan="7" align="center" style="font-size:8pt;">
                    Thank You For Your Payment...!
                </td>
            </tr>
            <tr>
                <td colspan="7" align="left" style="font-size:8pt;">
                    No.20, 2/1, 10<sup>th</sup> Lane, Colombo 03, Sri Lanka. Telephone : +94 474 936 006
                </td>
            </tr>
        </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
