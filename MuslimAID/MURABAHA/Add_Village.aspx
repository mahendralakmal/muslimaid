<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="add_village.aspx.cs" Inherits="MuslimAID.MURABAHA.add_village" Title="Add Village" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>MF Application - Add Village</h4></div>
        <div class="col-md-6 form-container">
            <div class="form-group">
                <div class="col-md-5">Branch Code<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbCityCode" 
                        TabIndex="1" runat="server" 
                        onselectedindexchanged="cmbCityCode_SelectedIndexChanged" 
                        AutoPostBack="True"></asp:DropDownList></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Area Code<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbArea" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Village<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtVillage" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Village Code<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtVillageCode" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
                <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" 
                Text="Submit" Enabled="true" onclick="btnSubmit_Click"/>&nbsp;
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
