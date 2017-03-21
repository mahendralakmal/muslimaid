<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Recipt_Cancel.aspx.cs" Inherits="MuslimAID.MURABAHA.Recipt_Cancel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Receipt Cancel</h4></div>
    <div class="col-md-6 form-container">
        <div class="form-group">
            <div class="col-md-5">Receipt No</div>
            <div class="col-md-7"><asp:TextBox ID="txtRNo" MaxLength="6" AutoPostBack="true" runat="server" Width="110px" 
                        TabIndex="0" ontextchanged="txtRNo_TextChanged" ></asp:TextBox></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Facility Code</div>
            <div class="col-md-7"><asp:Label ID="lblContractCode" runat="server"></asp:Label> </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">NIC</div>
            <div class="col-md-7"><asp:Label ID="lblNIC" runat="server"></asp:Label></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Name</div>
            <div class="col-md-7"><asp:Label ID="lblName" runat="server"></asp:Label></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Type</div>
            <div class="col-md-7"><asp:Label ID="lblType" runat="server"></asp:Label> </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Amount</div>
            <div class="col-md-7"><asp:Label ID="lblAmount" runat="server"></asp:Label> </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Comment</div>
            <div class="col-md-7"><asp:TextBox ID="txtComment" runat="server" Width="300px" TextMode="MultiLine" Height="75px"></asp:TextBox></div>
        </div>
        <div class="form-group">
            <div class="col-md-5"></div>
            <div class="col-md-7"><asp:Button ID="btnPeied" CssClass="btn btn-primary" runat="server" Enabled="false" TabIndex="3" 
                        Text="cancel" onclick="btnPeied_Click" />&nbsp;</div>
        </div>
        <div class="form-group">
            <div class="col-md-5"></div>
            <div class="col-md-7"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
        </div>
    </div>
</asp:Content>
