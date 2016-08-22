<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true" CodeBehind="add_cro.aspx.cs" Inherits="MuslimAID.SALAM.add_cro" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Salam - Add CRO</h4></div>
    <div class="col-md-6 form-container">
        <div class="form-group">
            <div class="col-md-5">Branch</div>
            <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbCityCode" runat="server" TabIndex="1" AutoPostBack="True"></asp:DropDownList></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">CRO No</div>
            <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtRootID" runat="server" MaxLength="2" TabIndex="2"></asp:TextBox></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">CRO Name</div>
            <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="TextBox1" MaxLength="100" runat="server" TabIndex="3"></asp:TextBox></div>
        </div>
        <asp:Button ID="btnChange" CssClass="btn btn-primary" runat="server" Text="Add" TabIndex="4" />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
</asp:Content>
