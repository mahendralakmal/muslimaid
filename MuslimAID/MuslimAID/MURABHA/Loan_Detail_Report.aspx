<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Loan_Detail_Report.aspx.cs" Inherits="MuslimAID.MURABHA.Loan_Detail_Report" Title="Ventura Crystal Investments Ltd ::: Loan Details Report" %>
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
    var prtGrid = document.getElementById('<%=grvLoanDeta.ClientID %>');
    prtGrid.border = 1;
    prtGrid.style.fontSize="10pt";
    prtGrid.style.fontFamily="Calibri";
    var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
    prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>CS Loan Detail Report - Ventura</div>");
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
                <td colspan="9" width="860px" class="PageTitle">CS - Loan Detail Report</td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9" align="left">
                    <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" class="reprot_search" class="reprot_search">
                        <tr>
                            <td width="50px">Branch Code : </td>
                            <td width="8px"></td>
                            <td width="90px">
                                <asp:DropDownList ID="cmbCityCode" CssClass="report_branch" TabIndex="1" runat="server" AutoPostBack="true" onselectedindexchanged="cmbCityCode_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td width="10px"></td>
                            <td width="40">Village</td>
                            <td width="10px" align="left">:</td>
                            <td width="120px">
                                <asp:DropDownList ID="cmbVillagr" runat="server" Enabled="false">
                                </asp:DropDownList>
                            </td>
                            <td width="10px"></td>
                            <td width="30px">
                                Root
                            </td>
                            <td width="10px" align="left">:</td>
                            <td width="150px">
                                <asp:DropDownList ID="cmbRoot" runat="server" Enabled="false">
                                </asp:DropDownList>
                            </td>
                            <td width="20px"></td>
                        </tr>
                        <tr>
                            <td colspan="11" height="10px"></td>
                        </tr>
                        <tr>
                            <td colspan="11" align="left">
                                <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" class="reprot_search">
                                    <tr align="left">
                                        <td width="75px">Contract Code</td>
                                        <td width="10px" align="left">:</td>
                                        <td width="110px">
                                            <asp:TextBox ID="txtContraCode" CssClass="report_cc" TabIndex="2" runat="server" MaxLength="13"></asp:TextBox>
                                        </td>
                                        <td width="30px">Date</td>
                                        <td width="10px">:</td>
                                        <td width="200px">
                                            <asp:TextBox ID="txtDateFrom" runat="server" CssClass="report_date" TabIndex="3" MaxLength="10"></asp:TextBox><img src="../Images/calender.png" /> 
                                            &nbsp; To &nbsp; 
                                            <asp:TextBox ID="txtDateTo" runat="server" CssClass="report_date" TabIndex="4" Width="65px" MaxLength="10"></asp:TextBox><img src="../Images/calender.png" /> 
                                            
                                        </td>
                                        <td width="20px"></td>
                                        <td width="60px">
                                            Status : 
                                        </td>
                                        <td width="100px">
                                            <asp:DropDownList ID="cmbStatus" runat="server">
                                                <asp:ListItem Value="A">All</asp:ListItem>
                                                <asp:ListItem Value="N">Pending</asp:ListItem>
                                                <asp:ListItem Value="P">Active</asp:ListItem>
                                                <asp:ListItem Value="S">Settle</asp:ListItem>
                                                <asp:ListItem Value="E">Matured</asp:ListItem>
                                                <asp:ListItem Value="C">Cancel</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td width="30px"></td>
                                        <td width="215px" align="left">
                                            <asp:Button ID="btnSerch" runat="server" CssClass="report_btn" Text="Search" TabIndex="5" 
                                                onclick="btnSerch_Click"  />
                                                <input type="button" id="btnPrint" class="report_btn2" TabIndex="6" value="Print" onclick="PrintGridData()" />
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
                <td colspan="9" width="860px">
                    <asp:Panel ID="pnlLoanDeta" runat="server">
                        <asp:GridView ID="grvLoanDeta" Width="860px" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contract Code" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contra_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;" style="text-decoration:underline;">
                                            <%#Eval("contra_code")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="contra_code" ItemStyle-VerticalAlign="Top" HeaderText="Contract Code" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />--%>
                                <asp:BoundField DataField="FORMAT(l.loan_amount,2)" HeaderText="Loan Amount" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="FORMAT(l.service_charges,2)" ItemStyle-VerticalAlign="Top" HeaderText="Service Charge" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="FORMAT(l.other_charges,2)" ItemStyle-VerticalAlign="Top" HeaderText="Other Charge" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="interest_rate" ItemStyle-VerticalAlign="Top" HeaderText="I. Rate" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="FORMAT(l.interest_amount,2)" ItemStyle-VerticalAlign="Top" HeaderText="I. Amount" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="period" ItemStyle-VerticalAlign="Top" HeaderText="Period" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="FORMAT(l.monthly_instollment,2)" ItemStyle-VerticalAlign="Top" HeaderText="Weekly Paymentt" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            </Columns>
                        </asp:GridView>
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
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <asp:Panel ID="pnlSummery" runat="server" Visible="false">
                    <td colspan="9" align="left" style="text-align:left;">
                        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                            <tr>
                                <td width="20px"></td>
                                <td width="100px">No Of Contract</td>
                                <td width="20px">:</td>
                                <td width="80px">
                                    <asp:Label ID="lblNoContra" runat="server"></asp:Label>
                                </td>
                                <td width="30px"></td>
                                <td width="80px">Disbusment</td>
                                <td width="20px">:</td>
                                <td width="80px" align="left">
                                    <asp:Label ID="lblDisb" runat="server"></asp:Label>
                                </td>
                                <td width="30px"></td>
                                <td width="80px">I. Amount</td>
                                <td width="20px">:</td>
                                <td width="80px" align="left">
                                    <asp:Label ID="lblIAmount" runat="server"></asp:Label>
                                </td>
                                <td width="30px"></td>
                                <td width="80px">S. Charges</td>
                                <td width="20px">:</td>
                                <td width="80px" align="left">
                                    <asp:Label ID="lblSCharges" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </asp:Panel>
            </tr>
        </table>
    </div>
</asp:Content>
