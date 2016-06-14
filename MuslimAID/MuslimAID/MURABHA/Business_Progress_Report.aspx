<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Business_Progress_Report.aspx.cs" Inherits="MuslimAID.MURABHA.Business_Progress_Report" Title="Ventura Crystal Investments Ltd ::: Business Progress Report - CS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDateFrom.ClientID %>").dynDateTime({
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
    <script type="text/javascript">
        function PrintGridData() {
        var prtGrid = document.getElementById('Bpd');
        prtGrid.border = 1;
        prtGrid.style.fontSize="10pt";
        prtGrid.style.fontFamily="Calibri";
        var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
        prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>Ventura Crystal Investments Ltd</div>");
        prtwin.document.write(prtGrid.outerHTML);
        prtwin.document.close();
        prtwin.focus();
        prtwin.print();
        prtwin.close();
        }
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" id="Bpd">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="font-family:Calibri; font-size:10pt; text-align:left;">
            <tr>
                <td colspan="5" width="860px" class="PageTitle">CS - Business Progress Report</td>
            </tr>
            <tr>
                <td colspan="5" height="10px"></td>
            </tr>
            <tr>
                <td width="170px">As at Date Eg:(2014-01-28)</td>
                <td width="10px">:</td>
                <td width="360px">
                    <asp:TextBox ID="txtDateFrom" runat="server" Width="75px"></asp:TextBox><img src="../Images/calender.png" /> 
                </td>
                <td width="30px"></td>
                <td>
                    <asp:Button ID="btnSerch" runat="server" Text="Search" 
                        onclick="btnSerch_Click" />&nbsp;
                        <input type="button" id="btnPrint" value="Print" onclick="PrintGridData()" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" height="20px"></td>
            </tr>
            <tr>
                <td colspan="5" valign="top">
                    <table cellpadding="0" cellspacing="0" border="0" width="860px" style="text-align:left;">
                        <tr>
                            <td class="border1" colspan="4" style="background-color:#006699;">&nbsp;<b>Summary of Contract Details</b></td>
                        </tr>
                        <tr>
                            <td class="border2" colspan="4" style="background-color:#006699;">&nbsp;<b>No of Customers</b></td>
                        </tr>
                        <tr>
                            <td class="border2" width="215px">&nbsp;<b>Active</b></td>
                            <td class="border3" width="215px">&nbsp;<b>Settle</b></td>
                            <td class="border3" width="215px">&nbsp;<b>Maturity</b></td>
                            <td class="border3" width="215px">&nbsp;<b>Total</b></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<asp:Label ID="lblActive" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblSettle" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblMatu" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblTotal" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="border2" colspan="4" style="background-color:#006699;">&nbsp;<b>Loan Summery</b></td>
                        </tr>
                        <tr>
                            <td class="border2" width="215px">&nbsp;<b>Loan Detail</b></td>
                            <td class="border3" width="215px">&nbsp;<b>Granted Loan Amount</b></td>
                            <td class="border3" width="215px">&nbsp;<b>Expected Interest Income</b></td>
                            <td class="border3" width="215px">&nbsp;<b>Total</b></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>Total Value</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblGLoanAmount" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblEInterestIncome" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblVTotal" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="border2" colspan="4" style="background-color:#006699;">&nbsp;<b>Due Summery</b></td>
                        </tr>
                        <tr>
                            <td class="border2" width="215px"></td>
                            <td class="border3" width="215px">&nbsp;<b>Capital</b></td>
                            <td class="border3" width="215px">&nbsp;<b>Interest</b></td>
                            <td class="border3" width="215px">&nbsp;<b>Default Interest</b></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>Active Contract</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblDueACapital" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblDueAInterest" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblDueADefault" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>Settle Contract</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblDueSCapital" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblDueSInterest" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblDueSDefault" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>Maturity Contract</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblDueMCapital" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblDueMInterest" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblDueMDefault" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>Total Contract</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblDueTCapital" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblDueTInterest" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblDueTDefault" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="border2" height="10px" colspan="4"></td>
                        </tr>
                        <tr>
                            <td class="border2" colspan="4" style="background-color:#006699;">&nbsp;<b>Collection Summery</b></td>
                        </tr>
                        <tr>
                            <td class="border2" width="215px"></td>
                            <td class="border3" width="215px">&nbsp;<b>Capital</b></td>
                            <td class="border3" width="215px">&nbsp;<b>Interest</b></td>
                            <td class="border3" width="215px">&nbsp;<b>Default Interest</b></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>From Active Contract</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblCollACapital" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblCollAInterest" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblCollADefault" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>From Settle Contract</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblCollSCapital" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblCollSInterest" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblCollSDefault" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>From Maturity Contract</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblCollMCapital" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblCollMInterest" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblCollMDefault" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>From Total Contract</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblCollTCapital" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblCollTInterest" runat="server"></asp:Label></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblCollTDefault" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="border2" colspan="4" style="background-color:#006699;">&nbsp;<b>Other Collection</b></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>Default Interest collection</b></td>
                            <td class="border3" colspan="3">
                                &nbsp;<asp:Label ID="lblOtherDefaultColl" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>Document charges collection</b></td>
                            <td class="border3" colspan="3">
                                &nbsp;<asp:Label ID="lblDocumentCharges" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="border2" height="10px" colspan="4"></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>Recovery Ratio</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblRecoveryRatio" Text="0" runat="server"></asp:Label>%</td>
                            <td class="border3" style="background-color:#006699;">&nbsp;<b>Graph</b></td>
                            <td class="border3"></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>Portfolio Growth</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblPortGrowth" runat="server"></asp:Label></td>
                            <td class="border3" style="background-color:#006699;">&nbsp;<b>Graph</b></td>
                            <td class="border3"></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>Income Growth</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblIncomeGrowth" runat="server"></asp:Label></td>
                            <td class="border3" style="background-color:#006699;">&nbsp;<b>Graph</b></td>
                            <td class="border3"></td>
                        </tr>
                        <tr>
                            <td class="border2" height="10px" colspan="4"></td>
                        </tr>
                        <tr>
                            <td class="border2">&nbsp;<b>Non performing Portfolio</b></td>
                            <td class="border3" colspan="3">
                                &nbsp;<asp:Label ID="lblNonPerfoPort" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
