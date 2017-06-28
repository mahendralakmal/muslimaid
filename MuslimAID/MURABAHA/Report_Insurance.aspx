<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Report_Insurance.aspx.cs" Inherits="MuslimAID.MURABHA.Report_Insurance" %>
    <div class="container">
        <div class="PageTitle"><h4>Insurance Detail Report</h4></div>
        <div class="col-md-12 form-container row">
            <div class="col-md-3 form-group">
                <div class="col-md-4">Branch</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbCityCode" Width="100px" TabIndex="0" runat="server">
                                </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Facility Code</div>
                <div class="col-md-8"><asp:TextBox ID="txtContraCode" Width="100px" runat="server" MaxLength="15"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">Facility Code</div>
                <div class="col-md-8"><asp:TextBox ID="TextBox1" Width="100px" runat="server" MaxLength="15"></asp:TextBox>
                </div>
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
            <div class="col-md-12 form-group">
                <asp:Button ID="btnSerch" runat="server" Text="Search" OnClick="btnSerch_Click" />
                <input type="button" id="btnPrint" value="Print" onclick="PrintGridData()" />
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
                                    <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contract_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;"
                                        style="text-decoration: underline;">
                                        <%#Eval("contract_code")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="date_time" ItemStyle-VerticalAlign="Top" HeaderText="Date"
                                HeaderStyle-Width="190px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="nic" HeaderText="NIC" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="80px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="initial_name" ItemStyle-VerticalAlign="Top" HeaderText="Name"
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
                            <asp:BoundField DataField="spouse_name" ItemStyle-VerticalAlign="Top" HeaderText="Spouse Name"
                                HeaderStyle-Width="220px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="spouse_nic" ItemStyle-VerticalAlign="Top" HeaderText="Spouse NIC"
                                HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                         <asp:BoundField DataField="Sdateofbirth" ItemStyle-VerticalAlign="Top" HeaderText="Date of Birth"
                                HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                         <asp:BoundField DataField="relationshipx" ItemStyle-VerticalAlign="Top" HeaderText="Relationship"
                                HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
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
