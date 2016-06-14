<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Summery.aspx.cs" Inherits="MuslimAID.MURABHA.Summery" Title="Ventura Crystal Investments Ltd ::: CS Summery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                            <td class="border2">&nbsp;<b>Over Payment</b></td>
                            <td class="border3" colspan="3">
                                &nbsp;<asp:Label ID="lblOP" runat="server"></asp:Label>
                            </td>
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
                            <td class="border2">&nbsp;<b>Recovery Ratio (Without O.P)</b></td>
                            <td class="border3">&nbsp;<asp:Label ID="lblRecoveryRatio" Text="0" runat="server"></asp:Label>%</td>
                            <td class="border3">&nbsp;</td>
                            <td class="border3"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
