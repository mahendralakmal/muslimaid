<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chequ_Print.aspx.cs" Inherits="MuslimAID.SALAM.Chequ_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('prt');
            //prtGrid.border = 1;
            //prtGrid.style.fontSize="12pt";
            prtGrid.style.fontFamily = "Calibri";
            var prtwin = window.open('', 'PrintGridViewData', 'left=0px,top=0px,right=0px,bottom=0px,width=672.755906px,height=340.15748px,tollbar=0,scrollbars=1,status=0,resizable=1');
            //prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'> MUSLIM AID MICRO CREDIT (GUARANTEE) LIMITED </div>");
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>

    <script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/pos.js"></script>

</head>
<body style="font-family: Calibri; font-size: 10pt;">
    <form id="form1" runat="server">
    <div align="center" id="prt">
        <table cellpadding="0" cellspacing="0" border="0px" width="816px">
            <tr>
                <td align="left">
                    <table cellpadding="0" cellspacing="0" border="0px" width="672.755906px">
                        <tr>
                            <td colspan="10" width="672.755906px" height="3.779528px">
                            </td>
                            <%--<td colspan="10" width="672.755906px" height="15.77952px">
                            </td>--%>
                        </tr>
                        <tr>
                            <td width="545.2362px" height="22.677165px">
                            </td>
                            <td width="22.677165px" height="22.677165px" align="left">
                                <asp:Label ID="lblDay1" runat="server"></asp:Label>
                            </td>
                            <td width="32.677165px" height="22.677165px" align="center">
                                <asp:Label ID="lblDay2" runat="server"></asp:Label>
                            </td>
                            <td width="22.677165px" height="22.677165px" align="center">
                                <asp:Label ID="lblMonth1" runat="server"></asp:Label>
                            </td>
                            <td width="32.677165px" height="22.677165px" align="center">
                                <asp:Label ID="lblMonth2" runat="server"></asp:Label>
                            </td>
                            <td width="22.677165px" height="22.677165px">
                            </td>
                            <td width="45.574803px" height="22.677165px">
                            </td>
                            <td width="22.677165px" height="22.677165px" align="left">
                                <asp:Label ID="lblYear1" runat="server"></asp:Label>
                            </td>
                            <td width="22.677165px" height="22.677165px" align="left">
                                <asp:Label ID="lblYear2" runat="server"></asp:Label>
                            </td>
                            <td width="0.67716px" height="22.677165px">
                            </td>
                        </tr>
                        <tr>
                            <%--<td colspan="10" width="672.755906px" height="3px">
                            </td>--%>
                            <td colspan="10" width="672.755906px" height="15.77952px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10" valign="top">
                                <table cellpadding="0" cellspacing="0" border="0" width="672.755906px">
                                    <tr>
                                        <td colspan="3" height="20.23622px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="49.133858px" height="45.354331px">
                                        </td>
                                        <td width="585.826772px" align="left" valign="top">
                                            ***<asp:Label ID="lblName" runat="server"></asp:Label>***
                                        </td>
                                        <td width="37.795276px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10" valign="top">
                                <table cellpadding="0" cellspacing="0" border="0" width="672.755906px">
                                    <tr>
                                        <td width="411.968504px" valign="top">
                                            <table cellpadding="0" cellspacing="0" border="0" width="411.968504px">
                                                <tr>
                                                    <td width="68.031496px" height="64.251969px">
                                                    </td>
                                                    <td width="343.937008" valign="top" align="left" height="64.251969px">
                                                        ***<asp:Label ID="lblAmountText" runat="server"></asp:Label>
                                                        Only***
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                        <td width="411.968504px" height="26.456693px"></td>
                                    </tr>--%>
                                            </table>
                                        </td>
                                        <td width="34.015748px">
                                        </td>
                                        <td width="196.535433px" valign="top">
                                            <table cellpadding="0" cellspacing="0" border="0" width="196.535433pxpx">
                                                <tr>
                                                    <td height="10px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="196.535433px" height="49.133858px" valign="middle" align="center">
                                                        ***<asp:Label ID="lblAmount" runat="server"></asp:Label>***
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="30.23623px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div align="right">
        <input type="button" id="btnPrint" value="Print" onclick="PrintGridData()" />
    </div>
    </form>
</body>
</html>
