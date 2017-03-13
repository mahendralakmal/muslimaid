<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true" CodeBehind="Settlment.aspx.cs" Inherits="MuslimAID.SALAM.Settlment" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle">
            <h4>Salam - Repayment</h4>
        </div>
        <div class="form-container col-md-12">
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">
                        Contract Code<span style="color: Red;"> *</span></div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCC" MaxLength="12" CssClass="form-control" runat="server" TabIndex="0"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">
                        Expected Selling Price<span style="color: Red;"> *</span></div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtESP" MaxLength="12" CssClass="form-control numbersOnly" runat="server" TabIndex="0"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">
                        Aggreed QTY<span style="color: Red;"> *</span></div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtAQty" MaxLength="12" CssClass="form-control numbersOnly" runat="server" TabIndex="0"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">
                        Received QTY<span style="color: Red;"> *</span></div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtRQty" MaxLength="12" CssClass="form-control numbersOnly" runat="server" TabIndex="0"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">
                        Actual Price<span style="color: Red;"> *</span></div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtAP" MaxLength="12" CssClass="form-control numbersOnly" runat="server" TabIndex="0"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">
                        Sales Procedure<span style="color: Red;"> *</span></div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtSP" MaxLength="12" CssClass="form-control numbersOnly" runat="server" TabIndex="0"></asp:TextBox>
                    </div>
                </div>
            </div>
            </div>
            <div class="col-md-12">
                <asp:Button ID="submit" runat="server" Text="Submit" />
            </div>
        </div>
    </div>
</asp:Content>
