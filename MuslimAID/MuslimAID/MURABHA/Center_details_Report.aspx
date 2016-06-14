<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Center_details_Report.aspx.cs" Inherits="MuslimAID.MURABHA.Center_details_Report" Title="Ventura Crystal Investments Ltd ::: Center Report" %>
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
        $(document).ready(function () {
            $("#<%=txtDateTo.ClientID %>").dynDateTime({
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
    var prtGrid = document.getElementById('<%=grvCenDeta.ClientID %>');
    prtGrid.border = 1;
    prtGrid.style.fontSize="10pt";
    prtGrid.style.fontFamily="Calibri";
    var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
    prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>CS Center Details Report - Ventura Crystal Investments Ltd</div>");
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
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
            <tr>
                <td colspan="9" width="860px" class="PageTitle">CS - Center Details Report</td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9" valign="top">
                    <table cellpadding="0" cellspacing="0" border="0" width="860px">
                        <tr>
                            <td width="120px">Center ID</td>
                            <td width="20px" align="left">:</td>
                            <td width="100px">
                                <asp:TextBox ID="txtCenterID" runat="server" MaxLength="4" Width="50px"></asp:TextBox>
                            </td>
                            <td width="20px"></td>
                            <td>City</td>
                            <td width="20px">:</td>
                            <td width="100px">
                                <asp:DropDownList ID="cmbBranch" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td width="20px"></td>
                            <td width="80px">Center Name</td>
                            <td width="20px">:</td>
                            <td align="left">
                                <asp:TextBox ID="txtCName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="11" height="5px"></td>
                        </tr>
                        <tr>
                            <td colspan="11" valign="top" align="left">
                                <table cellpadding="0" cellspacing="0" border="0" width="860px">
                                    <tr>
                                        <td width="120px">Date Eg:(2014-01-28)</td>
                                        <td width="20px">:</td>
                                        <td width="300px">
                                            <asp:TextBox ID="txtDateFrom" runat="server" Width="95px"></asp:TextBox><img src="../Images/calender.png" /> &nbsp;&nbsp; To &nbsp;&nbsp; <asp:TextBox ID="txtDateTo" runat="server" Width="95px"></asp:TextBox><img src="../Images/calender.png" /> 
                                        </td>
                                        <td width="30px"></td>
                                        <td align="left">
                                            <asp:Button ID="btnSerch" runat="server" Text="Search" onclick="btnSerch_Click" />
                                                <input type="button" id="btnPrint" value="Print" onclick="PrintGridData()" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9">
                    <asp:Panel ID="pnlCenterDetail" runat="server">
                        <asp:GridView ID="grvCenDeta" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="idcenter_details" ItemStyle-VerticalAlign="Top" HeaderText="Center ID" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="center_name" ItemStyle-VerticalAlign="Top" HeaderText="Center Name" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="b_name" ItemStyle-VerticalAlign="Top" HeaderText="City Name" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="villages" HeaderText="Village" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="180px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="leader_name" ItemStyle-VerticalAlign="Top" HeaderText="Leader Name" HeaderStyle-Width="280px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="conta_no" ItemStyle-VerticalAlign="Top" HeaderText="Contact No" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px">
                    <asp:HiddenField ID="hstrSelectQuery" runat="server" />
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
