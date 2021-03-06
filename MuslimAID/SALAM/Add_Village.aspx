﻿<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true" 
CodeBehind="Add_Village.aspx.cs" Inherits="MuslimAID.SALAM.Add_Village" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>MF Application - Add Area</h4></div>
        <div class="col-md-6 form-container">
            <div class="form-group">
                <div class="col-md-5">City Code<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbCityCode" TabIndex="1" runat="server"></asp:DropDownList></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Area<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtVillage" CssClass="form-control" 
                        runat="server" Width="200px" AutoPostBack="true" 
                        ontextchanged="txtVillage_TextChanged"></asp:TextBox></div>
            </div>
                <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" 
                Text="Submit" Enabled="false" onclick="btnSubmit_Click"/>&nbsp;
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
