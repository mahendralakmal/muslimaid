<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="loan_approval.aspx.cs" Inherits="MuslimAID.MURABAHA.loan_approval"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle">
            <h4>MF - Loan Approval Details</h4>
        </div>
        <div class="col-md-12 form-container">
            <div class="form-group">
                <div class="col-md-2">
                    Branch</div>
                <div class="col-md-4">
                    <asp:DropDownList ID="cmbBranch" runat="server" CssClass="form-control" AutoPostBack="true"
                        OnSelectedIndexChanged="cmbBranch_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">
                    Area</div>
                <div class="col-md-4">
                    <asp:DropDownList ID="cmbArea" runat="server" CssClass="form-control" 
                        AutoPostBack="true" onselectedindexchanged="cmbArea_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">
                    Village</div>
                <div class="col-md-4">
                    <asp:DropDownList ID="cmbVillage" runat="server" CssClass="form-control" 
                        AutoPostBack="true" onselectedindexchanged="cmbVillage_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">
                    Center</div>
                <div class="col-md-4">
                    <asp:DropDownList ID="cmdSocietyNo" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">&nbsp;</div>
                <div class="col-md-4">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                        OnClick="btnSearch_Click" />
                </div>
                
            </div>
            <div class="form-group">
                <div class="col-md-12">
                    <asp:GridView ID="grvLoanAppr" runat="server" AutoGenerateColumns="false" CssClass="table">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Facility Code" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contract_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;"
                                            style="text-decoration: underline;">
                                            <%#Eval("contract_code")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ca_code" HeaderText="C.Aplica. Code" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true" />
                                <asp:BoundField DataField="full_name" HeaderText="Name" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true" />
                                <asp:BoundField DataField="nic" HeaderText="NIC" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true" />
                                <asp:BoundField DataField="total_income" HeaderText="Total Income" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true" />
                                <asp:BoundField DataField="total_expenses" HeaderText="Total Expenses" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true" />
                                <asp:BoundField DataField="profit_lost" HeaderText="P AND L" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true" />
                                <%--<asp:BoundField DataField="family_expenses" HeaderText="Family Expences" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="net_income" HeaderText="Net Income" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />--%>
                                <asp:BoundField DataField="loan_amount" HeaderText="Loan Amount" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true" />
                                <asp:BoundField DataField="interest_rate" HeaderText="Interest Rate" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true" />
                                <asp:BoundField DataField="period" HeaderText="Period" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true" />
                                <asp:BoundField DataField="interest_amount" HeaderText="Interest Amount" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true" />
                                <asp:BoundField DataField="monthly_instollment" HeaderText="Installment" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true" />
                                <asp:TemplateField HeaderStyle-ForeColor="#009905" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White">
                                    <ItemTemplate>
                                        <a ref="#" onclick="javascript:w=window.open(&#039;ViewLoanDetails.aspx?ConCode=<%#Eval("contract_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=520px,height=300px,scrollbars=no,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;" style="text-decoration: underline;">Approval & Verification</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-12">
                
                    <asp:Label ID="lblMsg" CssClass="alert-danger" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
