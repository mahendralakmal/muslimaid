<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="AddNatureOfBusiness.aspx.cs" Inherits="MuslimAID.MURABAHA.AddNatureOfBusiness" Title="Add Nature Of Business" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>Add Nature Of Business</h4></div>
        <div class="col-md-6 form-container">
            <div class="form-group">
                <div class="col-md-5">Nature of business<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtNature" CssClass="form-control" 
                        runat="server"></asp:TextBox></div>
            </div>
            
            <div class="form-group">
            <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" 
                Text="Submit" Enabled="true" onclick="btnSubmit_Click"/>&nbsp;
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
