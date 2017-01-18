<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="SettlementRebate.aspx.cs" Inherits="MuslimAID.MURABAHA.SettlementRebate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Settlement & Rebate</h4></div>
    <div class="form-container row col-lg-8 col-md-8 ">
        <div class="col-md-6 form-group">
            <div class="col-md-5">Contract Code</div>
            <div class="col-md-7"><asp:TextBox ID="txtCC" runat="server" AutoPostBack="true" CssClass="form-control"
                        ontextchanged="txtCC_TextChanged"></asp:TextBox></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">NIC</div>
            <div class="col-md-7"><asp:Label ID="lblNIC" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Name</div>
            <div class="col-md-7"><asp:Label ID="lblName" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-8"></div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Loan Amount</div>
            <div class="col-md-7"><asp:Label ID="lblLAmount" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Loan Date</div>
            <div class="col-md-7"><asp:Label ID="lblLoDate" CssClass="form-control" runat="server"></asp:Label> </div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Interest Rate (%)</div>
            <div class="col-md-7"><asp:Label ID="lblIRate" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Interest Amount</div>
            <div class="col-md-7"><asp:Label ID="lblIAmount" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Period</div>
            <div class="col-md-7"><asp:Label ID="lblPeriod" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Pass Period</div>
            <div class="col-md-7"><asp:Label ID="lblPaPeriod" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Installment</div>
            <div class="col-md-7"><asp:Label ID="lblMIns" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Arrears Amount</div>
            <div class="col-md-7"><asp:Label ID="lblArre" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Paid Capital Amount</div>
            <div class="col-md-7"><asp:Label ID="lblCapiAmou" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Paid Interest Amount</div>
            <div class="col-md-7"><asp:Label ID="lblPaInAmou" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Loan Balance</div>
            <div class="col-md-7"><asp:Label ID="lblFullBala" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Future Interest</div>
            <div class="col-md-7"><asp:Label ID="lblIntBalance" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Rebate (%)</div>
            <div class="col-md-7">
                <asp:TextBox ID="txtNewIRate" AutoPostBack="true" MaxLength="5" 
                        runat="server" CssClass="form-control" ontextchanged="txtNewIRate_TextChanged"></asp:TextBox>(Eg:10)
            </div>
        </div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">Deduction Amount</div>
            <div class="col-md-7"><asp:Label ID="lblDeAmont" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-8"></div>
        <div class="col-md-6  form-group">
            <div class="col-md-5">New Balance</div>
            <div class="col-md-7"><asp:Label ID="lblNewBala" CssClass="form-control" runat="server"></asp:Label></div>
        </div>
        <div class="col-lg-11">
        <asp:Button ID="btnRequest" Enabled="false" CssClass="btn btn-primary" runat="server" Text="Request" 
                        onclick="btnRequest_Click" />
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
