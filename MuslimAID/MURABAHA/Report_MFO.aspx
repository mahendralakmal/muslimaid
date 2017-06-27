<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Report_MFO.aspx.cs" Inherits="MuslimAID.MURABHA.Report_MFO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>CRO Details Report</h4></div>
        <div class="col-md-12 form-container row">
            <div class="col-md-3 form-group">
                <div class="col-md-4">Branch</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbBranch" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="cmbBranch_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3 form-group">
                <div class="col-md-4">MFO</div>
                <div class="col-md-8"><asp:DropDownList ID="cmbRoot" CssClass="form-control" runat="server" TabIndex="5"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3 form-group">
                <asp:Button ID="btnSerch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSerch_Click" />
                <asp:LinkButton ID="View" runat="server" CommandName="View" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        Text="Export Excel" Height="25px" OnClick="View_Click" />
            </div>
            <div class="col-md-12 form-group">                
                <asp:Panel ID="pnlCenterDetail" runat="server">
                        <asp:GridView ID="grvCenDeta" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="b_name" ItemStyle-VerticalAlign="Top" HeaderText="Branch Name"
                                    HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="exe_id" HeaderText="CRO No" ItemStyle-VerticalAlign="Top"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="exe_name" ItemStyle-VerticalAlign="Top" HeaderText="CRO Name"
                                    HeaderStyle-Width="200px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                    HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="EPFNo" ItemStyle-VerticalAlign="Top" HeaderText="EPF No"
                                    HeaderStyle-Width="100px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                    HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="exe_nic" ItemStyle-VerticalAlign="Top" HeaderText="NIC No"
                                    HeaderStyle-Width="100px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                    HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="Designation" ItemStyle-VerticalAlign="Top" HeaderText="Designation"
                                    HeaderStyle-Width="100px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                    HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="Address" ItemStyle-VerticalAlign="Top" HeaderText="Address"
                                    HeaderStyle-Width="200px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                    HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="Mobile_No" ItemStyle-VerticalAlign="Top" HeaderText="MobileNo"
                                    HeaderStyle-Width="100px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                    HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="Land_No" ItemStyle-VerticalAlign="Top" HeaderText="TelephoneNo"
                                    HeaderStyle-Width="100px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                    HeaderStyle-ForeColor="White" ReadOnly="true" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
            </div>
            <div class="col-md-12 form-group">
                <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            
        </div>
    </div>
</asp:Content>
