<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Add_Village.aspx.cs" Inherits="MuslimAID.MURABHA.Add_Village" Title="Ventura Crystal Investments ltd ::: Add Village" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>MF Application - Add Village</h4></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">City Code *</div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbCityCode" TabIndex="1" runat="server"></asp:DropDownList></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Village *</div>
                <div class="col-md-7"><asp:TextBox ID="txtVillage" CssClass="form-control" runat="server" Width="200px" AutoPostBack="true"></asp:TextBox></div>
            </div>
            <div class="form-group">
                <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Submit" Enabled="false"/>&nbsp;
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
