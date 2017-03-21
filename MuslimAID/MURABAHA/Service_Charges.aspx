<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Service_Charges.aspx.cs" Inherits="MuslimAID.MURABAHA.Service_Charges" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Down Payment - MF</h4></div>
    <div class="col-md-6 form-container">
        <div class="form-group">
            <div class="col-md-5">Branch Code</div>
            <div class="col-md-7">
                    <asp:DropDownList ID="cmbCityCode" CssClass="form-control" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="cmbCityCode_SelectedIndexChanged">
                    </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Society ID</div>
            <div class="col-md-7">
                    <asp:DropDownList CssClass="form-control" ID="cmbSocietyID" runat="server">
                    </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-5"></div>
            <div class="col-md-7">
                    <asp:Button ID="btnSerch" CssClass="btn btn-primary" runat="server" Text="Search" 
                        onclick="btnSerch_Click" />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Panel ID="pnlPayment" runat="server" Visible="false">
                <div class="form-group">
                    <asp:GridView ID="grvPayment" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="contract_code" ItemStyle-VerticalAlign="Top" HeaderText="Facility Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="ca_code" ItemStyle-VerticalAlign="Top" HeaderText="CA Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="nic" ItemStyle-VerticalAlign="Top" HeaderText="NIC" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="initial_name" ItemStyle-VerticalAlign="Top" HeaderText="Name" HeaderStyle-Width="280px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="service_charges" ItemStyle-VerticalAlign="Top" HeaderText="Service Charges" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="registration_fee" HeaderText="Registration Fee" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="walfare_fee" HeaderText="Walfare Fee" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="other_charges" HeaderText="Other Charges" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkPayment" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                </div>
                <div classs="form-group">
                <b><asp:LinkButton ID="lnkTPayment" runat="server" CssClass="lnk_font_color" onclick="lnkTPayment_Click">Total Payment</asp:LinkButton> :</b> <asp:Label ID="lblTotalPaied" runat="server"></asp:Label>
                </div>
                <div classs="form-group"><asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" /></div>
            </asp:Panel>
        </div>
        
        <div class="form-group">
            <asp:HiddenField ID="hstrSelectQuery" runat="server" />
        </div>
        <div class="form-group">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</div>
</asp:Content>
