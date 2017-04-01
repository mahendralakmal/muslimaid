<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true" CodeBehind="salam_income_source_1.aspx.cs" Inherits="MuslimAID.SALAM.salam_income_source_1" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>Income Source Type 1</h4></div>
            <div class="col-md-12 form-container row">
                <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Income Source Type 1<span style="color:Red;"> *</span></div>
                    <div class="col-md-7">
                        <asp:TextBox ID="income_type_1" CssClass="form-control" runat="server" AutoPostBack="True"></asp:TextBox></div>
                </div>
                <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click"/>&nbsp;
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:GridView ID="gv_income_source" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" HeaderText=" ID " HeaderStyle-Width="100px"><ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate></asp:TemplateField>
                        <asp:BoundField DataField="income_type" HeaderText="Income Type" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" HeaderStyle-Width="90%" />
                    </Columns>
                </asp:GridView>
            </div>        
        </div>        
    </div>
</asp:Content>
