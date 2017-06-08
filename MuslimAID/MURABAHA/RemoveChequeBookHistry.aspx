<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="RemoveChequeBookHistry.aspx.cs" Inherits="MuslimAID.MURABAHA.RemoveChequeBookHistry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="PageTitle"><h4>Cheque Removal</h4></div>
    <div class="col-md-6 form-container">
        <div class="form-group">
            <div class="col-md-5">Cheque <span style="color: Red;">*</span></div>
            <div class="col-md-7">
                <asp:DropDownList ID="cmbChqNo" AutoPostBack="true" TabIndex="1" runat="server" OnSelectedIndexChanged="cmbChqNo_SelectedIndexChanged" CssClass="form-control" ></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Cheque No <span style="color: Red;">*</span></div>
            <div class="col-md-7">
                    <asp:TextBox ID="txtRNo" MaxLength="15" AutoPostBack="true" runat="server" CssClass="form-control" TabIndex="0" OnTextChanged="txtRNo_TextChanged"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Create User </div>
            <div class="col-md-7">
                    <asp:Label ID="lblNIC" runat="server"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Create Date </div>
            <div class="col-md-7">
                    <asp:Label ID="lblChequeDate" runat="server"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Account No </div>
            <div class="col-md-7">
                    <asp:Label ID="lblAccountNo" runat="server"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Comment </div>
            <div class="col-md-7">
                    <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine" Height="75px"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-5"> </div>
            <div class="col-md-7">
                    
                    <asp:Button ID="btnPeied" runat="server" Enabled="false" TabIndex="3" Text="Remove"
                        OnClick="btnPeied_Click" CssClass="btn btn-primary" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
