<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true"
    CodeBehind="ChequeBookRegistry.aspx.cs" Inherits="MuslimAID.SALAM.ChequeBookRegistry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Cheque Registry</h4></div>
    <div class="col-md-6 form-container">
        <div class="form-group">
            <div class="col-md-5">Bank Name </div>
            <div class="col-md-7">
            <asp:DropDownList ID="cmbBankName" CssClass="form-control" AutoPostBack="true" TabIndex="1" runat="server"
                        OnSelectedIndexChanged="cmbBankName_SelectedIndexChanged">
                    </asp:DropDownList></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Bank Code </div>
            <div class="col-md-7">
            <asp:TextBox ID="txtBankCode" MaxLength="4" runat="server" Enabled="false" TabIndex="18"
                        CssClass="form-control" onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Branch </div>
            <div class="col-md-7">
            <asp:DropDownList ID="cmbBranch" TabIndex="2" CssClass="form-control" AutoPostBack="true" runat="server"
                        OnSelectedIndexChanged="cmbBranch_SelectedIndexChanged">
                    </asp:DropDownList></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Branch Code </div>
            <div class="col-md-7">
            <asp:TextBox ID="txtBranchCode" Enabled="false" MaxLength="3" runat="server" TabIndex="20" CssClass="numbersOnly form-control"></asp:TextBox></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Account Number </div>
            <div class="col-md-7">
            <asp:TextBox ID="txtAccountNo" MaxLength="20" runat="server" TabIndex="3" CssClass="numbersOnly form-control"></asp:TextBox>
        </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Start Cheque No </div>
            <div class="col-md-7">
            <asp:TextBox ID="txtStartChqNo" MaxLength="10" runat="server" TabIndex="3" CssClass="form-control"></asp:TextBox>
        </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">No of Cheques </div>
            <div class="col-md-7">
            <asp:TextBox ID="txtNoChq" MaxLength="3" runat="server" TabIndex="4" CssClass="form-control" AutoPostBack="True" ontextchanged="txtNoChq_TextChanged"></asp:TextBox>
        </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Last Cheque No </div>
            <div class="col-md-7">
            <asp:Label ID="lblLastDate" runat="server" Text="Label"></asp:Label>
        </div>
        </div>
        
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="5" CssClass="btn btn-primary"
                        onclick="btnSubmit_Click"  />
                    <asp:Label ID="lblLDMsg" runat="server"></asp:Label>
    </div>
</div>
</asp:Content>
