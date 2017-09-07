<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Report_Arrears_Details.aspx.cs" Inherits="MuslimAID.MURABHA.Report_Arrears_Details"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('<%=grvArRep.ClientID %>');
            prtGrid.border = 1;
            prtGrid.style.fontSize = "10pt";
            prtGrid.style.fontFamily = "Calibri";
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'> MUSLIM AID MICRO CREDIT (GUARANTEE) LIMITED  ::: MF</div>");
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
        <div class="PageTitle"><h4>Arrears Details Report</h4></div>
        <div class="col-md-12 form-container row">
            <div class="col-md-3 form-group">
                <div class="col-md-4">Branch</div>
                <div class="col-md-8">
                    <asp:DropDownList ID="cmbCityCode" Width="100px" TabIndex="0" runat="server" CssClass="form-control" AutoPostBack="True" onselectedindexchanged="cmbCityCode_SelectedIndexChanged">
                                </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">MFO</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbRoot" runat="server" CssClass="form-control" Enabled="false">
                                </asp:DropDownList></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Center</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbVillagr" CssClass="form-control" runat="server" Enabled="false">
                                </asp:DropDownList></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Facility Code</div>
                <div class="col-md-8"><asp:TextBox ID="txtContraCode" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox></div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Status</div>
                <div class="col-md-8">
                    <asp:DropDownList CssClass="form-control" ID="cmbStatus" runat="server">
                        <asp:ListItem Value="A">All</asp:ListItem>
                        <asp:ListItem Value="D">Contract to expire</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4 form-group">
                <div class="col-md-5">Arrears Count</div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbACount" CssClass="form-control" runat="server">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="5">4 & Above</asp:ListItem>
                                </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-12 form-group">
                <asp:Button ID="btnSerch" Width="55px" runat="server" Text="Search" OnClick="btnSerch_Click" />
                <input type="button" id="btnPrint" value="Print" onclick="PrintGridData()" />
                <asp:LinkButton ID="View" runat="server" CommandName="View" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Export Excel" Height="25px" OnClick="View_Click" />
            </div>
            <div class="col-md-12 form-group">
                <asp:Panel ID="pnlARep" runat="server">
                    <%--<asp:GridView ID="grvArRep" Font-Size="10pt" runat="server" BorderColor="White" Width="860px" HeaderStyle-BackColor="#006699" onpageindexchanging="grvArRep_PageIndexChanging">
                        <Columns></Columns>
                    </asp:GridView>--%>
                    <asp:GridView ID="grvArRep" Font-Size="8pt" runat="server" AutoGenerateColumns="false"
                        ItemStyle-VerticalAlign="Top">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CRO" ItemStyle-VerticalAlign="Top" HeaderText="CRO" HeaderStyle-Width="80px"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10pt" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="Center" ItemStyle-VerticalAlign="Top" HeaderText="Center"
                                HeaderStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="Group" ItemStyle-VerticalAlign="Top" HeaderText="Group"
                                HeaderStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:TemplateField HeaderText="Facility No" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="100px"
                                ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("Facility No")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;"
                                        style="text-decoration: underline;">
                                        <%#Eval("Facility No")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="contra_code" ItemStyle-VerticalAlign="Top" HeaderText="Contract Code" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />--%>
                            <asp:BoundField DataField="Customer Name" ItemStyle-VerticalAlign="Top" HeaderText="Customer Name"
                                HeaderStyle-Width="180px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="Customer Code" ItemStyle-VerticalAlign="Top" HeaderText="Customer Code"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="80px"
                                HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="Loan Amount" HeaderText="Loan Amount" ItemStyle-VerticalAlign="Top"
                                HeaderStyle-Width="60px" HeaderStyle-BackColor="#006699" ItemStyle-HorizontalAlign="Right"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="Capital Outstanding" ItemStyle-VerticalAlign="Top" HeaderText="Capital Outstanding"
                                HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right"
                                HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="Total Outstanding" ItemStyle-VerticalAlign="Top" HeaderText="Total Outstanding"
                                HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right"
                                HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="Total Arrears" HeaderText="Total Arrears" ItemStyle-VerticalAlign="Top"
                                HeaderStyle-Width="60px" HeaderStyle-BackColor="#006699" ItemStyle-HorizontalAlign="Right"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="Last Payment Amount" HeaderText="Last Payment Amount"
                                ItemStyle-VerticalAlign="Top" HeaderStyle-Width="90px" HeaderStyle-BackColor="#006699"
                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="Last Payment date" HeaderText="Last Payment date" ItemStyle-VerticalAlign="Top"
                                HeaderStyle-Width="100px" HeaderStyle-BackColor="#006699" ItemStyle-HorizontalAlign="Right"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="Facility Status" HeaderText="Facility Status" ItemStyle-VerticalAlign="Top"
                                HeaderStyle-Width="90px" HeaderStyle-BackColor="#006699" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
            <div class="col-md-12 form-group">
                <asp:Panel ID="pnlSummery" runat="server" Visible="false">
                    <td colspan="10" align="left" style="text-align: left;">
                        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                            <tr>
                                <td width="20px">
                                </td>
                                <td width="150px">
                                    No Of Arrears
                                </td>
                                <td width="20px">
                                    :
                                </td>
                                <td width="100px">
                                    <asp:Label ID="lblNoArres" runat="server"></asp:Label>
                                </td>
                                <td width="50px">
                                </td>
                                <td width="100px">
                                    Arrears Amount
                                </td>
                                <td width="20px">
                                    :
                                </td>
                                <td width="400px" align="left">
                                    <asp:Label ID="lblArreAmount" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </asp:Panel>        
            </div>
            <div class="col-md-12 form-group">
                <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
            </div>
            <div class="col-md-12 form-group">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
