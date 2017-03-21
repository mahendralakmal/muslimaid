<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Bulk_Payment.aspx.cs" Inherits="MuslimAID.MURABAHA.Bulk_Payment"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle">
            <h4>Weekly Payment - MF</h4>
        </div>
        <div class="col-md-12 form-container">
            <div class="form-group">
                <div class="col-md-5">
                    Branch Code</div>
                <div class="col-md-7">
                    <asp:DropDownList CssClass="form-control" ID="cmbCityCode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbCityCode_SelectedIndexChanged"
                        Width="200">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">
                    Society ID</div>
                <div class="col-md-7">
                    <asp:DropDownList CssClass="form-control" ID="cmbSocietyID" runat="server" Width="200">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">
                    </div>
                <div class="col-md-7">
                    <asp:Button ID="btnSerch" runat="server" Text="Search" OnClick="btnSerch_Click" />
                </div>
            </div>
            <div class="col-md-12 form-group"></div>
            <div class="form-group">
                <asp:Panel ID="pnlPayment" runat="server" Visible="false">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="grvPayment" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40px"
                                        ItemStyle-VerticalAlign="Top" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                        HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="contract_code" ItemStyle-VerticalAlign="Top" HeaderText="Facility Code"
                                        HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                        HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                    <asp:BoundField DataField="ca_code" ItemStyle-VerticalAlign="Top" HeaderText="CA Code"
                                        HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                        HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                    <asp:BoundField DataField="nic" ItemStyle-VerticalAlign="Top" HeaderText="NIC" HeaderStyle-Width="90px"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                        HeaderStyle-ForeColor="White" ReadOnly="true" />
                                    <asp:BoundField DataField="initial_name" ItemStyle-VerticalAlign="Top" HeaderText="Name"
                                        HeaderStyle-Width="260px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                        HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                    <asp:BoundField DataField="monthly_instollment" ItemStyle-VerticalAlign="Top" HeaderText="Installment"
                                        HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905"
                                        HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                    <asp:TemplateField HeaderText="Paid Amount" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center"
                                        HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPaidAmount" runat="server" Width="100"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="current_loan_amount" ItemStyle-HorizontalAlign="Right"
                                        ItemStyle-VerticalAlign="Top" HeaderText="Balance" HeaderStyle-Width="100px"
                                        HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                        ReadOnly="true" />
                                    <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                        HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemark" runat="server" Width="150" MaxLength="45"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-4">
                                <asp:LinkButton ID="lnkTPayment" runat="server" CssClass="lnk_font_color" OnClick="lnkTPayment_Click">Total Payment</asp:LinkButton>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lblTotalPaied" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
            <div class="col-md-12>
                <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
</asp:Content>
