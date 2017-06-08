<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Change_CRO.aspx.cs" Inherits="MuslimAID.MURABAHA.Change_CRO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="PageTitle"><h4>MF Application - Change CRO</h4></div>
    <div class="col-md-6 form-container">
        <div class="form-group">
            <div class="col-md-5">Branch <span style="color: Red;">*</span></div>
            <div class="col-md-7">
            <asp:DropDownList ID="cmbCityCode" CssClass="form-control" TabIndex="0" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="cmbCityCode_SelectedIndexChanged">
                    </asp:DropDownList></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Area <span style="color: Red;">*</span></div>
            <div class="col-md-7">
            <asp:DropDownList ID="cmbArea" CssClass="form-control" TabIndex="0" runat="server" 
                    AutoPostBack="True" onselectedindexchanged="cmbArea_SelectedIndexChanged">
                    </asp:DropDownList></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Village <span style="color: Red;">*</span></div>
            <div class="col-md-7">
            <asp:DropDownList ID="cmbVillage" CssClass="form-control" TabIndex="0" 
                    runat="server" AutoPostBack="True" 
                    onselectedindexchanged="cmbVillage_SelectedIndexChanged">
                    </asp:DropDownList></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Center Name <span style="color: Red;">*</span></div>
            <div class="col-md-7"><asp:DropDownList ID="cmbSocietyName" runat="server" 
                    TabIndex="3" CssClass="form-control" 
                    onselectedindexchanged="cmbSocietyName_SelectedIndexChanged" 
                    AutoPostBack="True">
                    </asp:DropDownList></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">MFO <span style="color: Red;">*</span></div>
            <div class="col-md-7"><asp:DropDownList ID="cmbRoot" runat="server" TabIndex="2" CssClass="form-control">
                    </asp:DropDownList></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Change MFO<span style="color: Red;">*</span></div>
            <div class="col-md-7"><asp:DropDownList ID="cmbChangeMfo" runat="server" TabIndex="2" CssClass="form-control">
                    </asp:DropDownList></div>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Enabled="false" OnClick="btnSubmit_Click" CssClass="btn btn-primary" TabIndex="3" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
</div>
</asp:Content>
