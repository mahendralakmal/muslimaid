<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="create_sub_center.aspx.cs" Inherits="MuslimAID.MURABAHA.create_sub_center" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Create a Sub Center</h4></div>
    <div class="col-md-6 form-container">
        <div class="form-group">
            <div class="col-md-5">Center Code<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:DropDownList ID="cmbCenterCode" CssClass="form-control" 
                        TabIndex="1" runat="server"></asp:DropDownList></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Name<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtSCName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
        </div>
        <div class="form-group">
            <div class="col-md-12">
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" 
                    runat="server" Text="Submit" onclick="btnSubmit_Click" />               
                <asp:Label ID="lblMsg" runat="server"></asp:Label>                    
            </div>
        </div>
    </div>
</div>
</asp:Content>
