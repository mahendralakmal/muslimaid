<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Loan_Detail_Report.aspx.cs" Inherits="MuslimAID.MURABHA.Loan_Detail_Report"
    Title="Loan Details Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function() {
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
        $(document).ready(function() {
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
            prtGrid.style.fontSize = "10pt";
            prtGrid.style.fontFamily = "Calibri";
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>CS Loan Detail Report - Ventura</div>");
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
        
        $(function(){
            $('#datepicker1').datetimepicker({ format: 'DD/MM/YYYY' });
            $('#datepicker2').datetimepicker({ format: 'DD/MM/YYYY' });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>CS - Loan Detail Report</h4></div>
    <div class="col-md-12 form-container row">
        <div class="col-md-3 form-group">
            <div class="col-md-5">Branch Code</div>
            <div class="col-md-7"><asp:DropDownList ID="cmbCityCode" CssClass="form-control report_branch" TabIndex="1" runat="server"
                                    AutoPostBack="true" OnSelectedIndexChanged="cmbCityCode_SelectedIndexChanged">
                                </asp:DropDownList></div>
        </div>
        <div class="col-md-3 form-group">
            <div class="col-md-5">Center</div>
            <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbVillagr" runat="server" Enabled="false">
                                </asp:DropDownList></div>
        </div>
        <div class="col-md-3 form-group">
            <div class="col-md-5">MFO</div>
            <div class="col-md-7"><asp:DropDownList ID="cmbRoot" runat="server" Enabled="false" CssClass="form-control">
                                </asp:DropDownList></div>
        </div>
        <div class="col-md-3 form-group">
            <div class="col-md-5">Facility Code</div>
            <div class="col-md-7"><asp:TextBox ID="txtContraCode" CssClass="report_cc form-control" TabIndex="2" runat="server"
                                                MaxLength="15"></asp:TextBox></div>
        </div>
        <div class="col-md-3 form-group">
            <div class="col-md-4">Date</div>
            <div class="col-md-8">
                <div class='input-group date' id='datepicker1' name='datepicker1'>
                    <asp:TextBox ID="txtDateFrom" CssClass="form-control" runat="server"
                        TabIndex="9"></asp:TextBox>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
        </div>
        <div class="col-md-3 form-group">
            <div class="col-md-2">to</div>
            <div class="col-md-8">
                <div class='input-group date' id='datepicker2' name='datepicker2'>
                    <asp:TextBox ID="txtDateTo" CssClass="form-control" runat="server"
                        TabIndex="9"></asp:TextBox>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
        </div>
        <div class="col-md-3 form-group">
            <div class="col-md-5">
                Status :
            </div>
            <div class="col-md-7">
                <asp:DropDownList ID="cmbStatus" runat="server" CssClass="form-control">
                    <asp:ListItem Value="A">All</asp:ListItem>
                    <asp:ListItem Value="N">Pending</asp:ListItem>
                    <asp:ListItem Value="P">Active</asp:ListItem>
                    <asp:ListItem Value="S">Settle</asp:ListItem>
                    <asp:ListItem Value="E">Matured</asp:ListItem>
                    <asp:ListItem Value="C">Cancel</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-3 form-group">
            <asp:Button ID="btnSerch" runat="server" CssClass="btn btn-primary report_btn" Text="Search" TabIndex="5"
                                                OnClick="btnSerch_Click" />
            <input type="button" id="btnPrint" class="report_btn2 btn btn-default" tabindex="6" value="Print"
                                                onclick="PrintGridData()" />
        </div>
        <div class="col-md-12 form-group pull-right">
            <asp:LinkButton ID="View" runat="server" CommandName="View" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Export Excel" Height="25px" OnClick="View_Click" />
        </div>
        <div class="col-md-12 form-group">
            <asp:Panel ID="pnlLoanDeta" runat="server" CssClass="pnlChqDetail">
                <asp:GridView ID="grvLoanDeta" runat="server" AutoGenerateColumns="false" CssClass="table">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                            HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1%>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Facility Code" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contra_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;"
                                    style="text-decoration: underline;">
                                    <%#Eval("contra_code")%>
                                </a>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="center_name" ItemStyle-VerticalAlign="Top" HeaderText="Center Name"
                            ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="initial_name" ItemStyle-VerticalAlign="Top" HeaderText="Name"
                            ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="exe_name" ItemStyle-VerticalAlign="Top" HeaderText="CRO Name"
                            ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="team_id" ItemStyle-VerticalAlign="Top" HeaderText="Group"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="loan_amount" HeaderText="Loan Amount" ItemStyle-VerticalAlign="Top"
                            ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="interest_amount" ItemStyle-VerticalAlign="Top" HeaderText="I. Amount"
                            ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="chequ_deta_on" ItemStyle-VerticalAlign="Top" HeaderText="DisbursedDate"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true" />
                        <asp:BoundField DataField="interest_rate" ItemStyle-VerticalAlign="Top" HeaderText="I. Rate"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IRR" ItemStyle-VerticalAlign="Top" HeaderText="IRR" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                            ReadOnly="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="period" ItemStyle-VerticalAlign="Top" HeaderText="Period"
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="monthly_instollment" ItemStyle-VerticalAlign="Top" HeaderText="Weekly Paymentt"
                            ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="registration_fee" ItemStyle-VerticalAlign="Top" HeaderText="Registration Fee"
                            ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true" Visible="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="service_charges" ItemStyle-VerticalAlign="Top" HeaderText="Service Charge"
                            ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="other_charges" ItemStyle-VerticalAlign="Top" HeaderText="Other Charge"
                            ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true" InsertVisible="True" Visible="False">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField DataField="walfare_fee" ItemStyle-VerticalAlign="Top" HeaderText="Walfare Fee"
                            ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                            HeaderStyle-ForeColor="White" ReadOnly="true">
                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
        <div class="col-md-12 form-group">
            <asp:HiddenField ID="hstrSelectQuery" runat="server" />
            <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <asp:Panel ID="pnlSummery" runat="server" Visible="false">
            <div class="col-md-12 form-group">
                <td colspan="9" align="left" style="text-align: left;">
                    <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                        <tr>
                            <td width="20px">
                            </td>
                            <td width="100px">
                                No Of Contract
                            </td>
                            <td width="20px">
                                :
                            </td>
                            <td width="80px">
                                <asp:Label ID="lblNoContra" runat="server"></asp:Label>
                            </td>
                            <td width="30px">
                            </td>
                            <td width="80px">
                                Disbusment
                            </td>
                            <td width="20px">
                                :
                            </td>
                            <td width="80px" align="left">
                                <asp:Label ID="lblDisb" runat="server"></asp:Label>
                            </td>
                            <td width="30px">
                            </td>
                            <td width="80px">
                                I. Amount
                            </td>
                            <td width="20px">
                                :
                            </td>
                            <td width="80px" align="left">
                                <asp:Label ID="lblIAmount" runat="server"></asp:Label>
                            </td>
                            <td width="30px">
                            </td>
                            <td width="80px">
                                S. Charges
                            </td>
                            <td width="20px">
                                :
                            </td>
                            <td width="80px" align="left">
                                <asp:Label ID="lblSCharges" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </div>
        </asp:Panel>
    </div>
        <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
            <tr>
                <td width="860px" class="PageTitle">
                    
                </td>
            </tr>
            <tr>
                <td height="10px">
                </td>
            </tr>
            <tr>
                <td height="10px">
                </td>
            </tr>
            <tr>
                <td width="860px">
                </td>
            </tr>
            <tr>
                <td height="10px">
                    
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td height="10px">
                </td>
            </tr>
            <tr>
            </tr>
        </table>
    </div>

</div>
</asp:Content>
