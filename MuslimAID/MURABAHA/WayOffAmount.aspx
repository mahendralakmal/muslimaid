<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="WayOffAmount.aspx.cs" Inherits="MuslimAID.MURABAHA.WayOffAmount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Write Off</h4></div>
    <div class="form-container row col-lg-10 col-md-10 ">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">
                    Facility Code
                </div>
                <div class="col-md-5">
                    <asp:TextBox ID="txtCC" CssClass="form-control
                    " runat="server" MaxLength="15"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnSerch" CssClass="btn btn-primary" runat="server" Text="Serch" 
                        onclick="btnSerch_Click" />
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <asp:Panel ID="pnlSummery" runat="server">
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Facility Code
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblConCode" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Total Current Balance
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblTotCurrentBalance" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Name
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblName" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Due Installment
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblDueInstallment" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Loan Amount
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblLoanAmou" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Over Payment
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblOverPayment" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Interest Amount
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblIAmount" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Total Arreas
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblTotalArreas" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Period
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblPeriod" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Total Default
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblTotalDefault" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Granting Date
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblGrantDate" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                    <div class="col-md-7">
                    <div class="form-group">
                        <div class="col-md-4">
                            Loan stock
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblLoanStock" CssClass="form-control" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4">
                            Future Capital
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblFutureCapital" CssClass="form-control" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4">
                            Future Interest
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblFutureInterest" CssClass="form-control" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4">
                            Write Off Amount
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtInterRebate" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Enabled="False" CssClass="btn btn-primary" onclick="btnConfirm_Click" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
                </div>
        </asp:Panel>

        </div>
    </div>
</div>
</asp:Content>
