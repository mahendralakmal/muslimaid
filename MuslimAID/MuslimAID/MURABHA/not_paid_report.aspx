<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="not_paid_report.aspx.cs" Inherits="MuslimAID.MURABHA.not_paid_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%=txtFromDate.ClientID %>").dynDateTime({
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
        $(document).ready(function() {
            $("#<%=txtToDate.ClientID %>").dynDateTime({
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
            <tr>
                <td colspan="9" width="860px" class="PageTitle">Not Paid Report</td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9">
                    <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                        <tr>
                            <td width="90px">
                                From Date
                            </td>
                            <td width="10px" align="left">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" Width="100px" runat="server" MaxLength="12"></asp:TextBox><img
                                    src="../Images/calender.png" />
                            </td>
                            <td width="30px">
                            </td>
                            <td width="90px">
                                To Date
                            </td>
                            <td width="10px" align="left">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" Width="100px" runat="server" MaxLength="12"></asp:TextBox><img
                                    src="../Images/calender.png" />
                            </td>
                            <td width="30px"></td>
                            <td>
                                <asp:Button ID="btnSerch" runat="server" Text="Search" 
                                    onclick="btnSerch_Click"  />                                    
                                <asp:Button ID="btnPrint" runat="server" Text="Print" onclick="btnPrint_Click" 
                                    />                                    
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9" valign="top">
                    <asp:Panel ID="pnlChqDetail" CssClass="pnlChqDetail" runat="server" Visible="true">
                        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                            <tr>
                                <td width="860px">
                                    <asp:GridView ID="gdvMasterSheet" runat="server" AutoGenerateColumns="false" CssClass="MasterSheet" ItemStyle-VerticalAlign="Top">
                                        <Columns>      
                                            <asp:BoundField DataField="FollwUpOfficer" ItemStyle-VerticalAlign="Top" HeaderText="Follw Up Officer" ReadOnly="true" />
                                            <asp:BoundField DataField="Group" ItemStyle-VerticalAlign="Top" HeaderText="Group" ReadOnly="true" />
                                            <asp:BoundField DataField="Center" HeaderText="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ReadOnly="true" />
                                            <asp:BoundField DataField="NoOfCustomer" ItemStyle-VerticalAlign="Top" HeaderText="No Of Customer" HeaderStyle-Width="260px" ItemStyle-HorizontalAlign="Left" ReadOnly="true" />
                                            <asp:BoundField DataField="ClientCode" ItemStyle-VerticalAlign="Top" HeaderText="Client Code" ReadOnly="true" />
                                            <asp:BoundField DataField="FacilityNo" ItemStyle-VerticalAlign="Top" HeaderText="Facility No" ReadOnly="true" />
                                            <asp:BoundField DataField="CustomerName" ItemStyle-VerticalAlign="Top" HeaderText="Customer Name" ReadOnly="true" />
                                            <asp:BoundField DataField="DisbursedAmount" ItemStyle-VerticalAlign="Top" HeaderText="Disbursed Amount" ReadOnly="true" />
                                            <asp:BoundField DataField="TotalPaid" ItemStyle-VerticalAlign="Top" HeaderText="Total Paid" ReadOnly="true" />
                                            <asp:BoundField DataField="TotalCapitalPaid" ItemStyle-VerticalAlign="Top" HeaderText="Total Capital Paid" ReadOnly="true" />
                                            <asp:BoundField DataField="TotalInterestPaid" ItemStyle-VerticalAlign="Top" HeaderText="Total Interest Paid"  ReadOnly="true" />
                                            <asp:BoundField DataField="CapitalOutstanding" ItemStyle-VerticalAlign="Top" HeaderText="Capital Outstanding" ReadOnly="true" />
                                            <asp:BoundField DataField="TotalOutstanding" ItemStyle-VerticalAlign="Top" HeaderText="Total Outstanding" ReadOnly="true" />
                                            <asp:BoundField DataField="TotalArreasAmount" ItemStyle-VerticalAlign="Top" HeaderText="Total ArreasAmount" ReadOnly="true" />
                                            <asp:BoundField DataField="ThisWeekDue" ItemStyle-VerticalAlign="Top" HeaderText="This Week Due" ReadOnly="true" />
                                            <asp:BoundField DataField="ThisWeekCollection" ItemStyle-VerticalAlign="Top" HeaderText="This Week Collection" ReadOnly="true" />
                                            <asp:BoundField DataField="LastPaymentDate" ItemStyle-VerticalAlign="Top" HeaderText="Last Payment Date" ReadOnly="true" />
                                            <asp:BoundField DataField="LastPaymentAmount" ItemStyle-VerticalAlign="Top" HeaderText="Last Payment Amount" ReadOnly="true" />
                                            <asp:BoundField DataField="FacilityStatus" ItemStyle-VerticalAlign="Top" HeaderText="Facility Status" ReadOnly="true" />
                                            <asp:BoundField DataField="ContractActiveDate" ItemStyle-VerticalAlign="Top" HeaderText="Contract Active Date" ReadOnly="true" />
                                            <asp:BoundField DataField="ExpiryDate" ItemStyle-VerticalAlign="Top" HeaderText="Expiry Date" ReadOnly="true" />
                                            <asp:BoundField DataField="Period" ItemStyle-VerticalAlign="Top" HeaderText="Period" ReadOnly="true" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px"></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px">
                    <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                    <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="9">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
