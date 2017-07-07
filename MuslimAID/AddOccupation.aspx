<%@ Page Language="C#" MasterPageFile="~/MuslimAID.Master" AutoEventWireup="true" CodeBehind="AddOccupation.aspx.cs" Inherits="MuslimAID.AddOccupation" Title="Add Occupation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Add Occupation</h4></div>
    <div class="col-md-6 form-container">
        <div class="form-group">
            <div class="col-md-5">Occupation</div>
            <div class="col-md-7">
                <asp:TextBox ID="txtOccupation" runat="server" CssClass="form-control"></asp:TextBox></div>
        </div>
        <asp:Button ID="btnChange" CssClass="btn btn-primary" runat="server" Text="Add" 
            TabIndex="2" onclick="btnChange_Click" />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
    </div>
</asp:Content>
