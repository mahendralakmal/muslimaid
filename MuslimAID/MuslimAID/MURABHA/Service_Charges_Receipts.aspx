<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Service_Charges_Receipts.aspx.cs" Inherits="MuslimAID.MURABHA.Service_Charges_Receipts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ventura Crystal Investments Ltd ::: CS Service Charges Receipt</title>
    <script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../js/calendar-en.min.js" type="text/javascript"></script>
    <link href="../CSS/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/DateTimeTasks.js"></script>
    
    <link rel="stylesheet" href="../CSS/print.css" type="text/css" media="print"/>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDate.ClientID %>").dynDateTime({
                showsTime: false,
                ifFormat: "%Y-%m-%d",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <script type='text/javascript'>
        function prnt(){
            var prtGrid = document.getElementById('<%=pnlReceiptPreview.ClientID %>');
            //var prtGrid = document.getElementById('invoice');
            prtGrid.style.fontSize="9pt";
            prtGrid.style.fontFamily="Calibri";
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=400,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            //prtwin.document.write('MF Receipt ::: Ventura Crystal Investments Ltd');
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
    <div align="center">
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
                    <td>Date</td>
                    <td width="10px" align="center">:</td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" Width="80px"></asp:TextBox><img src="../Images/calender.png" />
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
        
        <asp:Panel ID="pnlReceiptPreview" runat="server" Visible="false">
            <asp:Repeater ID="repInvoice" runat="server">
                <ItemTemplate>
                    <div id="invoice" class="print">
                        <table cellpadding="0" cellspacing="0" border="0" width="400px" align="left" style="font-size:9pt; font-family:Calibri; text-align:left;">
                            <tr>
                                <td valign="top" colspan="7" align="center">
                                    <b>Ventura Crystal Investments Ltd</b><br />
                                    Capital Supply Facillity - Receipt
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" height="12px"></td>
                            </tr>
                            <tr>
                                <td width="100px">Center</td>
                                <td width="20px">:</td>
                                <td>
                                    <%#Eval("b_name")%>
                                    <%--<asp:Label ID="lblCenter" runat="server"></asp:Label>--%>
                                </td>
                                <td width="15px"></td>
                                <td width="50px">No</td>
                                <td width="20px">:</td>
                                <td>
                                    <%#Eval("contract_code")%>
                                    <%--<asp:Label ID="lblContrNo" runat="server"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" height="5px"></td>
                            </tr>
                            <tr>
                                <td>Date</td>
                                <td>:</td>
                                <td>
                                    <%#Eval("date_time")%>
                                    <%--<asp:Label ID="lblDate" runat="server"></asp:Label>--%>
                                </td>
                                <td width="15px"></td>
                                <td>Rcp No</td>
                                <td>:</td>
                                <td>
                                    <%#Eval("idmicro_service_charges")%>
                                    <%--<asp:Label ID="lblRecNo" runat="server"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" height="5px"></td>
                            </tr>
                            <tr>
                                <td>REF</td>
                                <td>:</td>
                                <td colspan="5">
                                    CS Service & Insurance
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" height="5px"></td>
                            </tr>
                            <tr>
                                <td>Type</td>
                                <td>:</td>
                                <td colspan="5">
                                    Documentation,Welfare,Registration, Legal & Insurance Charges
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
                                    <%#Eval("nic")%>
                                    <%--<asp:Label ID="lblNIC" runat="server"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" height="10px"></td>
                            </tr>
                            <tr>
                                <td>Documentation, Legal</td>
                                <td valign="top">:</td>
                                <td valign="top" colspan="5">
                                    Rs.<%#Eval("document_amount", "{0:N2}")%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" height="5px"></td>
                            </tr>
                            <tr>
                                <td>Insurance</td>
                                <td>:</td>
                                <td colspan="5">
                                    Rs.<%#Eval("insurance_amount", "{0:N2}")%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" height="5px"></td>
                            </tr>
                            <tr>
                                <td>Registration Fee</td>
                                <td>:</td>
                                <td colspan="5">
                                    Rs.<%#Eval("registration_fee", "{0:N2}")%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" height="5px"></td>
                            </tr>
                            <tr>
                                <td>Welfare Fee</td>
                                <td>:</td>
                                <td colspan="5">
                                    Rs.<%#Eval("welfair_fee", "{0:N2}")%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" height="10px"></td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    Received a sum of Rs.<%#Eval("total_amount", "{0:N2}")%> <%--<asp:Label ID="lblAmou" runat="server"></asp:Label>--%> In Cash.<br />
                                    <%--<asp:Label ID="lblAmouText" runat="server"></asp:Label>--%>
                                    <%#Eval("total_amount_text")%> Rupees Only.
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" height="10px"></td>
                            </tr>
                            <tr>
                                <td valign="top">From</td>
                                <td valign="top">:</td>
                                <td colspan="5">
                                    <%#Eval("initial_name")%><%--<asp:Label ID="lblName" runat="server"></asp:Label>--%><br />
                                    <%#Eval("p_address")%><%--<asp:Label ID="lblAddrss" runat="server"></asp:Label>--%>
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
                                <td valign="top">Total</td>
                                <td valign="top">:</td>
                                <td colspan="5">
                                    Rs.<%#Eval("total_amount", "{0:N2}")%>
                                    <%--<asp:Label ID="lblTotal" runat="server"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" height="25px"></td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    Cashier(<%#Eval("last_name")%><%--<asp:Label ID="lblCasName" runat="server"></asp:Label>--%>)
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" height="5px"></td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <hr />
                                </td>
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
                            <tr>
                                <td colspan="7" height="90px"></td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </asp:Panel>
    </div>
    <div align="right">
        <input type="button" id="btnPrint" value="Print" onclick="prnt()" />
    </div>
    </form>
</body>
</html>
