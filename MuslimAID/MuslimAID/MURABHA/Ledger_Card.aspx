<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Ledger_Card.aspx.cs" Inherits="MuslimAID.MURABHA.Ledger_Card" Title="Ventura Crystal Investments Ltd ::: Ledger Card - CS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function PrintGridData() {
    var prtGrid = document.getElementById('cusSumme');
    prtGrid.border = 1;
    prtGrid.style.fontSize="10pt";
    prtGrid.style.fontFamily="Calibri";
    var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
    prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>Ventura - CS Customer Ledger Card</div>");
    prtwin.document.write(prtGrid.outerHTML);
    prtwin.document.close();
    prtwin.focus();
    prtwin.print();
    prtwin.close();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="font-family:Calibri; font-size:10pt; text-align:left;">
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td colspan="3" width="860px" class="PageTitle">CS - Customer Leder Card</td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td width="100px">Contract Code</td>
                <td width="20px">:</td>
                <td width="740px">
                    <asp:TextBox ID="txtCC" runat="server" MaxLength="12"></asp:TextBox>
                    <asp:Button ID="btnSerch" runat="server" onclick="btnSerch_Click" Text="Serch" />
                    <input type="button" id="btnPrint" value="Print" onclick="PrintGridData()" />
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div align="center" id="cusSumme">
            <asp:Panel ID="pnlSummery" runat="server" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="font-family:Calibri; font-size:10pt; text-align:left;">
                    <tr>
                        <td width="100px">Contract Code</td>
                        <td width="20px">:</td>
                        <td width="300px">
                            <asp:Label ID="lblConCode" runat="server"></asp:Label>
                        </td>
                        <td width="20px"></td>
                        <td width="100px">Contract Date</td>
                        <td width="20px">:</td>
                        <td width="300px">
                            <asp:Label ID="lblContrDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px"></td>
                    </tr>
                    <tr>
                        <td>Center Name</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblCenterName" runat="server"></asp:Label>
                        </td>
                        <td width="20px"></td>
                        <td>CRO</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblCRO" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px"></td>
                    </tr>
                    <tr>
                        <td>Name</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                        <td width="20px"></td>
                        <td>Period</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblPeriod" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px"></td>
                    </tr>
                    <tr>
                        <td>Loan Amount</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblLoanAmou" runat="server"></asp:Label>
                        </td>
                        <td width="20px"></td>
                        <td>Installment</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblInstall" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px"></td>
                    </tr>
                    <tr>
                        <td>Interest Amount</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblIAmount" runat="server"></asp:Label>
                        </td>
                        <td width="20px"></td>
                        <td>Agreed Value</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblAValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px"></td>
                    </tr>
                    <tr>
                        <td>No of Due Insta.</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblDueCount" runat="server"></asp:Label>
                        </td>
                        <td width="20px"></td>
                        <td>Status</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px"></td>
                    </tr>
                    <tr>
                        <td>Maturity Date</td>
                        <td>:</td>
                        <td colspan="5" align="left">
                            <asp:Label ID="lblMatuDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px"></td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <asp:GridView ID="grvSumm" runat="server" HeaderStyle-BackColor="#006699" 
                                HeaderStyle-HorizontalAlign="Center" Font-Size="10pt" BorderColor="White" 
                                Width="860px" onrowdatabound="grvSumm_RowDataBound">
                                <Columns></Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px"></td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                            <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Current Balance</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblCuBala" runat="server"></asp:Label>
                        </td>
                        <td></td>
                        <td>Arreas Payment</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="lblArre" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px"></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
