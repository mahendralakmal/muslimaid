<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="DateRangeReport.aspx.cs" Inherits="MuslimAID.MURABHA.DateRangeReport" %>

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
                <td colspan="9" width="860px" class="PageTitle">
                    Date Range For The Report
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px">
                </td>
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
                            <td width="30px">
                            </td>
                            <td>
                                <asp:Button ID="btnSerch" runat="server" Text="Search" OnClick="btnSerch_Click" />
                                <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px">
                </td>
            </tr>
            <tr>
                <td colspan="9" valign="top">
                    <asp:Panel ID="pnlChqDetail" runat="server" Visible="true">
                        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                            <tr>
                                <td width="860px">
                                    <asp:GridView ID="gdvVoucher" runat="server" AutoGenerateColumns="false" AllowPaging="true">
                                        <Columns>
                                        <asp:BoundField ItemStyle-Width="100px" DataField="FollwUpOfficer" HeaderText="Follw Up Officer" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="Group" HeaderText="Group" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="Center" HeaderText="Center" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="NoofCustomer" HeaderText="No of Customer" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CustomerCode" HeaderText="Customer Code" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="CustomerName" HeaderText="Customer Name" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="DisburedAmount" HeaderText="Disbured Amount" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="WEEK_01" HeaderText="Week 1" ItemStyle-HorizontalAlign="Right"/>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="WEEK_02" HeaderText="Week 2" ItemStyle-HorizontalAlign="Right"/>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="WEEK_03" HeaderText="Week 3" ItemStyle-HorizontalAlign="Right"/>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="WEEK_04" HeaderText="Week 4" ItemStyle-HorizontalAlign="Right"/>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
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
