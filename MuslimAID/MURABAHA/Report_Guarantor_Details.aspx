﻿<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Report_Guarantor_Details.aspx.cs" Inherits="MuslimAID.MURABHA.Report_Guarantor_Details" %>

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
            prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>CS Client Basic Details Report - Ventura Crystal Investments Ltd</div>");
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
        <div class="PageTitle"><h4>CS - Guarantor Details Report</h4></div>
        <div class="col-md-12 form-container row">
            <div class="col-md-3 form-group">
                <div class="col-md-4">Branch</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbCityCode" CssClass="form-control" TabIndex="0" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="cmbCityCode_SelectedIndexChanged">
                                </asp:DropDownList></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Area</div>
                <div class="col-md-8">
                    <asp:DropDownList ID="cmbArea" CssClass="form-control" 
                        TabIndex="0" runat="server" 
                        onselectedindexchanged="cmbArea_SelectedIndexChanged" AutoPostBack="True" >
                                </asp:DropDownList></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Village</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbVillage" CssClass="form-control" 
                        TabIndex="0" runat="server" 
                        onselectedindexchanged="cmbVillage_SelectedIndexChanged" 
                        AutoPostBack="True">
                                </asp:DropDownList></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">MFO</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbRoot" CssClass="form-control" 
                        TabIndex="0" runat="server" AutoPostBack="True">
                                </asp:DropDownList></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Center</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbCenter" CssClass="form-control" 
                        TabIndex="0" runat="server" AutoPostBack="True">
                                </asp:DropDownList></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-5">Center Day</div>
                <div class="col-md-7"><asp:DropDownList ID="cmbCenterDay" CssClass="form-control" 
                        runat="server" TabIndex="7" >
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
                <div class="col-md-10">
                    <div class='input-group date' id='datepicker2' name='datepicker2'>
                        <asp:TextBox ID="txtDateTo" CssClass="form-control" runat="server"
                            TabIndex="9"></asp:TextBox>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div>
            <div class="col-md-3 form-group">
                <asp:Button ID="btnSerch" CssClass="btn btn-primary" runat="server" 
                    Text="Search" onclick="btnSerch_Click"  />
                <input type="button" id="Button2" CssClass="btn btn-default" value="Print" onclick="PrintGridData()" />
            </div>
            <div class="col-md-3 form-group">
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="View" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        Text="Export Excel" Height="25px" OnClick="View_Click" />
            </div>
            <div class="col-md-12 form-group" style="overflow:auto; white-space:nowrap">
                <asp:Panel ID="pnlClientDetail" runat="server">
                    <asp:GridView ID="grvCliDeta" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top"
                        Font-Size="8pt">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40px"
                                ItemStyle-VerticalAlign="Top" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Center" ItemStyle-VerticalAlign="Top" HeaderText="Center"
                                HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="team_id" ItemStyle-VerticalAlign="Top" HeaderText="Group"
                                HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="nic" ItemStyle-VerticalAlign="Top" HeaderText="Customer Code"
                                HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Facility No" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="90px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contra_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;"
                                        style="text-decoration: underline;">
                                        <%#Eval("contra_code")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="contra_code" ItemStyle-VerticalAlign="Top" HeaderText="Customer Code" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />--%>
                            <asp:BoundField DataField="full_name" ItemStyle-VerticalAlign="Top" HeaderText="Name"
                                HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="mobile_no" ItemStyle-VerticalAlign="Top" HeaderText="Contact No"
                                HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="promisers_id" ItemStyle-VerticalAlign="Top" HeaderText="Promiser 1"
                                HeaderStyle-Width="80px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="promisers1_contra_code" ItemStyle-VerticalAlign="Top"
                                HeaderText="Contract Code" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="promisers1_full_name" ItemStyle-VerticalAlign="Top" HeaderText="Promiser Name"
                                HeaderStyle-Width="180px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="mobile_no1" ItemStyle-VerticalAlign="Top" HeaderText="Contact No"
                                HeaderStyle-Width="180px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="promiser_id_2" ItemStyle-VerticalAlign="Top" HeaderText="Promiser 2"
                                HeaderStyle-Width="80px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="promisers2_contra_code" ItemStyle-VerticalAlign="Top"
                                HeaderText="Contract Code" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="promisers2_full_name" ItemStyle-VerticalAlign="Top" HeaderText="Promiser Name"
                                HeaderStyle-Width="180px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="mobile_no2" ItemStyle-VerticalAlign="Top" HeaderText="Contact No"
                                HeaderStyle-Width="180px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>
        <div class="col-md-12 form-group"><asp:HiddenField ID="hstrSelectQuery" runat="server" /></div>
        <div class="col-md-12 form-group"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
    </div>
</asp:Content>