<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Report_Center_details.aspx.cs" Inherits="MuslimAID.MURABHA.Report_Center_details"
    Title="Center Report" %>

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
            var prtGrid = document.getElementById('<%=grvCenDeta.ClientID %>');
            prtGrid.border = 1;
            prtGrid.style.fontSize = "10pt";
            prtGrid.style.fontFamily = "Calibri";
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>CS Center Details Report -  MUSLIM AID MICRO CREDIT (GUARANTEE) LIMITED </div>");
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
        <div class="PageTitle">
            <h4>Center Details Report</h4>
        </div>
        <div class="col-md-12 form-container row">
            <div class="col-md-3 form-group">
                <div class="col-md-4">City</div>
                <div class="col-md-8">
                    <asp:DropDownList ID="cmbBranch" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbBranch_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Area</div>
                <div class="col-md-8">
                    <asp:DropDownList ID="cmbArea" CssClass="form-control" 
                        TabIndex="0" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="cmbArea_SelectedIndexChanged" >
                                </asp:DropDownList></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Village</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbVillage" CssClass="form-control" 
                        TabIndex="0" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="cmbVillage_SelectedIndexChanged">
                                </asp:DropDownList></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Center Name</div>
                <div class="col-md-8">
                    <asp:DropDownList ID="cmbCenterName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbSocietyName_SelectedIndexChanged" CssClass="form-control" TabIndex="3"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Center ID</div>
                <div class="col-md-8"><asp:TextBox ID="txtCenterID" runat="server" MaxLength="4" ReadOnly="true" CssClass="form-control"></asp:TextBox></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Center Day</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbCenterDay" CssClass="form-control" runat="server" TabIndex="7" >
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="MO">Monday</asp:ListItem>
                        <asp:ListItem Value="TU">Tuesday</asp:ListItem>
                        <asp:ListItem Value="WE">Wednsday</asp:ListItem>
                        <asp:ListItem Value="TH">Thursday</asp:ListItem>
                        <asp:ListItem Value="FR">Friday</asp:ListItem>
                        <asp:ListItem Value="SA">Saturday</asp:ListItem>
                        <asp:ListItem Value="SU">Sunday</asp:ListItem>
                    </asp:DropDownList></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">MFO</div>
                <div class="col-md-8">
                    <asp:DropDownList ID="cmbRoot" runat="server" TabIndex="5" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6 form-group"></div>
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
                <div class="col-md-4">to</div>
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
                <asp:Button ID="btnSerch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSerch_Click" />
                <input type="button" id="btnPrint" value="Print" class="btn btn-default" onclick="PrintGridData()" />
            </div>
            <div class="col-md-12 pull-right">
                <asp:LinkButton ID="View" runat="server" CommandName="View" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Export Excel" Height="25px" OnClick="View_Click" />
            </div>
            <div class="col-md-12">
                    <asp:Panel ID="pnlCenterDetail" runat="server">
                        <asp:GridView ID="grvCenDeta" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top" CssClass="table">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="idcenter_details" ItemStyle-VerticalAlign="Top" HeaderText="Center ID"
                                    HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="center_name" ItemStyle-VerticalAlign="Top" HeaderText="Center Name"
                                    HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="b_name" ItemStyle-VerticalAlign="Top" HeaderText="City Name"
                                    HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                    
                                <asp:BoundField DataField="area" ItemStyle-VerticalAlign="Top" HeaderText="Area"
                                    HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                    
                                <asp:BoundField DataField="villages" HeaderText="Village" ItemStyle-VerticalAlign="Top"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="180px" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="leader_name" ItemStyle-VerticalAlign="Top" HeaderText="Leader Name"
                                    HeaderStyle-Width="280px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                    HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="conta_no" ItemStyle-VerticalAlign="Top" HeaderText="Contact No"
                                    HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="exe_name" ItemStyle-VerticalAlign="Top" HeaderText="CRO Name"
                                    HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                    <asp:BoundField DataField="center_day" ItemStyle-VerticalAlign="Top" HeaderText="Center Day"
                                    HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
            </div>
            <div class="col-md-12">
                <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
