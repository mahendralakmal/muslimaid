<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true"
    CodeBehind="Loan_Cancel.aspx.cs" Inherits="MuslimAID.SALAM.Loan_Cancel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="PageTitle"><h4>Loan Cancel Details</h4></div>
        <div class="col-md-6 form-container">
            <div class="form-group">
                <div class="col-md-5">Facility Code <span style="color: Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtContractCode" runat="server" CssClass="form-control"
                                    ontextchanged="txtContractCode_TextChanged" AutoPostBack="True"></asp:TextBox></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Name </div>
                <div class="col-md-7">
                    <asp:Label ID="lblName" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">NIC </div>
                <div class="col-md-7">
                    <asp:Label ID="lblNIC" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Business Income </div>
                <div class="col-md-7">
                    <asp:Label ID="lblBusinessIncome" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Total Income </div>
                <div class="col-md-7">
                    <asp:Label ID="lblTotalIncome" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Direct Cost </div>
                <div class="col-md-7">
                    <asp:Label ID="lblDirectCost" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Total Expences </div>
                <div class="col-md-7">
                    <asp:Label ID="lblTotalExpences" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Loan Amount </div>
                <div class="col-md-7">
                    <asp:Label ID="lblLoanAmount" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Period </div>
                <div class="col-md-7">
                    <asp:Label ID="lblPeriod" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Interest Rate </div>
                <div class="col-md-7">
                    <asp:Label ID="lblInterestRate" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Loan Approval </div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbApproval" runat="server" TabIndex="0" CssClass="form-control">
                                    <asp:ListItem Value="C">Cancel</asp:ListItem>
                                </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Description </div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtDescription" TabIndex="1" TextMode="MultiLine" CssClass="addressText form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="btnApproved" TabIndex="2" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnApproved_Click" />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
