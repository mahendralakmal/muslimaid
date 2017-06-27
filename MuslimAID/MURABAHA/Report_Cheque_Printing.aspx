<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Report_Cheque_Printing.aspx.cs" Inherits="MuslimAID.MURABHA.Report_Cheque_Printing"%>

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
            var prtGrid = document.getElementById('<%=grvChqDeta.ClientID %>');
            prtGrid.border = 1;
            prtGrid.style.fontSize = "10pt";
            prtGrid.style.fontFamily = "Calibri";
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>CS Cheque Printing Details Report - Ventura Crystal Investments Ltd</div>");
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
        <div class="PageTitle"><h4>Cheque Printing Details Report</h4></div>
        <div class="col-md-12 form-container row">
            <div class="col-md-3 form-group">
                <div class="col-md-4">Branch</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbCityCode" CssClass="form-control" TabIndex="0" runat="server" OnSelectedIndexChanged="cmbCityCode_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-5 form-group">
                <div class="col-md-3">Facility Code</div>
                <div class="col-md-9"><asp:TextBox ID="txtContraCode" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox></div>
            </div>
            <div class="col-md-4 form-group">
                <div class="col-md-3">Center</div>
                <div class="col-md-9">
                    <asp:DropDownList ID="cmbVillagr" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
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
                <div class="col-md-4">To</div>
                <div class="col-md-8">
                    <div class=input-group date' id='datepicker2' name='datepicker2'>
                        <asp:TextBox ID="txtDateTo" CssClass="form-control" runat="server"
                            TabIndex="9"></asp:TextBox>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-5">Cheque No</div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtChequeNo" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-2">To</div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtToChequeNo" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-12"></div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">MFO</div>
                <div class="col-md-8">
                    <asp:DropDownList ID="cmbCRO" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-5 form-group">
                <asp:Button ID="btnSerch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSerch_Click" />
                <input type="button" id="btnPrint" value="Print" class="btn btn-primary" onclick="PrintGridData()" />
                <asp:LinkButton ID="View" runat="server" CommandName="View" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Export Excel" Height="25px" OnClick="View_Click" />
            </div>
            <div class="col-md-12 form-group">
                <asp:Panel ID="pnlChqDetail" runat="server" Visible="false">
                    <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                        <tr>
                            <td colspan="3" width="860px">
                                <asp:GridView ID="grvChqDeta" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top"
                                    Font-Size="8pt">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="chequ_no" ItemStyle-VerticalAlign="Top" HeaderText="Chq No"
                                            HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                        <asp:TemplateField HeaderText="Contract Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                            <ItemTemplate>
                                                <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contract_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;"
                                                    style="text-decoration: underline;">
                                                    <%#Eval("contract_code")%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="society_id" ItemStyle-VerticalAlign="Top" HeaderText="Center"
                                            HeaderStyle-Width="130px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                        <asp:BoundField DataField="root_id" ItemStyle-VerticalAlign="Top" HeaderText="CRO"
                                            HeaderStyle-Width="130px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                        <asp:BoundField DataField="amount" ItemStyle-VerticalAlign="Top" HeaderText="Chq Amount"
                                            HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                        <asp:BoundField DataField="chq_name" ItemStyle-VerticalAlign="Top" HeaderText="Chq Name"
                                            HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                        <asp:BoundField DataField="chq_date" HeaderText="Chq Date" ItemStyle-VerticalAlign="Top"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                        <asp:BoundField DataField="date_time" ItemStyle-VerticalAlign="Top" HeaderText="Printed Date Time"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                        <asp:BoundField DataField="user_nic" ItemStyle-VerticalAlign="Top" HeaderText="Printed User"
                                            HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                No of Chq Count :
                                <asp:Label ID="lblChqCount" runat="server"></asp:Label>
                            </td>
                            <td width="30px">
                            </td>
                            <td>
                                Total Chq Amount :
                                <asp:Label ID="lblChqAmount" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <div class="col-md-12 form-group">                
                <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>
 </asp:Content>
