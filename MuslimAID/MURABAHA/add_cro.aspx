<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="add_cro.aspx.cs" Inherits="MuslimAID.MURABAHA.add_cro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Add MFO</h4></div>
    <div class="col-md-6 form-container">
        <div class="form-group">
            <div class="col-md-5">Branch</div>
            <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbCityCode" runat="server" TabIndex="1"></asp:DropDownList></div>
        </div>
        <%--<div class="form-group">
            <div class="col-md-5">Executive No</div>
            <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtRootID" runat="server" MaxLength="2" TabIndex="2"></asp:TextBox></div>
        </div>--%>
        <div class="form-group">
            <div class="col-md-5">Officer Name</div>
            <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtRootName" 
                    MaxLength="100" runat="server" TabIndex="2" 
                    ontextchanged="txtRootName_TextChanged"></asp:TextBox></div>
        </div>
        <asp:Button ID="btnChange" CssClass="btn btn-primary" runat="server" Text="Add" 
            TabIndex="3" onclick="btnChange_Click" />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
    </div>
</asp:Content>
