<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="BranchAdd.aspx.cs" Inherits="MuslimAID.MURABAHA.BranchAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Add City</h4></div>
    <div class="col-md-6 form-container">
        <div class="form-group">
            <div class="col-md-5">City Code</div>
            <div class="col-md-7"><asp:TextBox ID="txtBranchCode" runat="server" CssClass="form-control" AutoPostBack="true" 
                        TabIndex="1" ontextchanged="txtBranchCode_TextChanged" MaxLength="3"></asp:TextBox></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">City</div>
            <div class="col-md-7"><asp:TextBox ID="txtBranchName" runat="server" CssClass="form-control" AutoPostBack="true" 
                       TabIndex="2" ontextchanged="txtBranchName_TextChanged" MaxLength="45" ></asp:TextBox></div>
        </div>
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" Enabled="false" 
                        onclick="btnSubmit_Click" TabIndex="3" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
    </div>
</asp:Content>
