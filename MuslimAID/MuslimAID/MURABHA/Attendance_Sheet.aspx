<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance_Sheet.aspx.cs" Inherits="MuslimAID.MURABHA.Attendance_Sheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ventura Crystal Investments Ltd ::: CS - Attendance Sheet</title>
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
                        <b>Ventura Crystal Investments Ltd - CS - Attendance Sheet</b><br />
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
                            <asp:GridView ID="grvRepaySheet" runat="server" AutoGenerateColumns="false" Font-Size="9pt" BorderWidth="1px" BorderColor="Black" Width="1000px">
                                <Columns>
                                    <asp:BoundField DataField="contra_code" ItemStyle-Width="100px" HeaderText="Contract code" ItemStyle-HorizontalAlign="Center"  ReadOnly="true" />
                                    <asp:BoundField DataField="initial_name" ItemStyle-Width="200px" HeaderText="Name" ItemStyle-HorizontalAlign="Left" ReadOnly="true" />
                                    <asp:BoundField DataField="" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" ReadOnly="true" />  
                                    <asp:BoundField DataField="" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" ReadOnly="true" />  
                                    <asp:BoundField DataField="" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" ReadOnly="true" />  
                                    <asp:BoundField DataField="" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" ReadOnly="true" />  
                                    <asp:BoundField DataField="" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" ReadOnly="true" />  
                                    <asp:BoundField DataField="" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" ReadOnly="true" />  
                                    <asp:BoundField DataField="" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" ReadOnly="true" />  
                                    <asp:BoundField DataField="" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" ReadOnly="true" /> 
                                    <asp:BoundField DataField="" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" ReadOnly="true" />  
                                    <asp:BoundField DataField="" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" ReadOnly="true" />  
                                    <asp:BoundField DataField="" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" ReadOnly="true" />  
                                    <asp:BoundField DataField="" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" ReadOnly="true" /> 
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
                <td width="10px"></td>
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
                <td></td>
                <td align="left">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" height="10px"></td>
            </tr>
            <tr>
                <td width="200px"></td>
                <td width="100px" align="left">Percentage (%)</td>
                <td></td>
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
                <td></td>
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
                <td></td>
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
                <td></td>
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
                <td></td>
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
