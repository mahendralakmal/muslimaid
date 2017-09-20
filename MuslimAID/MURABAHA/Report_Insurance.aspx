<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Report_Insurance.aspx.cs" Inherits="MuslimAID.MURABHA.Report_Insurance" %>

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
            var prtGrid = document.getElementById('<%=grvCliDeta.ClientID %>');
            prtGrid.border = 1;
            prtGrid.style.fontSize = "10pt";
            prtGrid.style.fontFamily = "Calibri";
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>Insurance Detail CS -  MUSLIM AID MICRO CREDIT (GUARANTEE) LIMITED </div>");
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>Insurance Detail Report</h4></div>
        <div class="col-md-12 form-container row">
            <div class="col-md-3 form-group">
                <div class="col-md-4">Branch</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbCityCode" CssClass="form-control" 
                        TabIndex="0" runat="server" AutoPostBack="true"
                        onselectedindexchanged="cmbCityCode_SelectedIndexChanged">
                                </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Area</div>
                <div class="col-md-8">
                    <asp:DropDownList ID="cmbArea" CssClass="form-control" 
                        TabIndex="0" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="cmbArea_SelectedIndexChanged" >
                                </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Village</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbVillage" CssClass="form-control" 
                        TabIndex="0" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="cmbVillage_SelectedIndexChanged" >
                                </asp:DropDownList></div>
            </div>
        <div class="col-md-3 form-group">
            <div class="col-md-4">Center</div>
            <div class="col-md-8"><asp:DropDownList CssClass="form-control" ID="cmbVillagr" runat="server" Enabled="false">
                                </asp:DropDownList></div>
        </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Date</div>
                <div class="col-md-8"><div class='input-group date' id='datepicker1' name='datepicker1'>
                        <asp:TextBox ID="txtDateFrom" CssClass="form-control" runat="server"
                            TabIndex="9"></asp:TextBox>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">To</div>
                <div class="col-md-8"><div class='input-group date' id='Div1' name='datepicker1'>
                        <asp:TextBox ID="txtDateTo" CssClass="form-control" runat="server"
                            TabIndex="9"></asp:TextBox>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div></div>
            </div>
            <div class="col-md-4 form-group">
                <div class="col-md-3">Facility Code</div>
                <div class="col-md-9"><asp:TextBox ID="txtContraCode" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-12 form-group">
                <asp:Button ID="btnSerch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnSerch_Click" />
                <input type="button" id="btnPrint" class="btn btn-primary" value="Print" onclick="PrintGridData()" />
                <asp:LinkButton ID="View" runat="server" CommandName="View" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        Text="Export Excel" Height="25px" OnClick="View_Click" />
            </div>
            <div class="col-md-12 form-group">
                <asp:Panel ID="pnlClientDetail" runat="server" Visible="false">
                    <asp:GridView ID="grvCliDeta" runat="server" AutoGenerateColumns="false" Font-Size="8pt">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                HeaderStyle-BackColor="#009905">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contract Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contact_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;"
                                        style="text-decoration: underline;">
                                        <%#Eval("contact_code")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="date_time" ItemStyle-VerticalAlign="Top" HeaderText="Date"
                                HeaderStyle-Width="190px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="nic" HeaderText="NIC" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="80px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="full_name" ItemStyle-VerticalAlign="Top" HeaderText="Name"
                                HeaderStyle-Width="190px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="p_address" ItemStyle-VerticalAlign="Top" HeaderText="Address"
                                HeaderStyle-Width="290px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="dateofbirth" ItemStyle-VerticalAlign="Top" HeaderText="Date of Birth"
                                HeaderStyle-Width="190px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="city_code" ItemStyle-VerticalAlign="Top" HeaderText="Branch"
                                HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="format(l.loan_amount,2)" ItemStyle-VerticalAlign="Top"
                                HeaderText="Loan Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="period" ItemStyle-VerticalAlign="Top" HeaderText="Period"
                                HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                           
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
            <div class="col-md-12 form-group">
            <asp:Panel ID="pnlNoData" runat="server" Visible="true">
                <table cellpadding="0" cellspacing="0" border="0" width="860px">
                    <tr>
                        <td width="860px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            </div>
            <div class="col-md-12 form-group">
                <asp:Panel ID="pnlSummery" runat="server" Visible="false">
                    <td>
                        No Of Insurance
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="lblNoIns" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                        Total Amount
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="lblInsAmount" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </asp:Panel>
            </div>
            <div class="col-md-12 form-group">
                <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
                <asp:HiddenField ID="hstrSelectQuery2" runat="server" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
