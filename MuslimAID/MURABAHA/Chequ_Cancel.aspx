<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Chequ_Cancel.aspx.cs" Inherits="MuslimAID.MURABAHA.Chequ_Cancel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>Cheque Cancel</h4></div>
        <div class="col-md-6 form-container">
            <div class="form-group">
                <div class="col-md-5">Cheque No</div>
                <div class="col-md-7"><asp:TextBox ID="txtRNo" MaxLength="15" CssClass="form-control" AutoPostBack="true" runat="server" Width="110px" 
                        TabIndex="0" ontextchanged="txtRNo_TextChanged" ></asp:TextBox></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Contract Code</div>
                <div class="col-md-7"><asp:Label ID="lblContractCode" runat="server"></asp:Label></div>
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
                <div class="col-md-5">Amount</div>
                <div class="col-md-7"><asp:Label ID="lblAmount" runat="server"></asp:Label></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Cheque Date</div>
                <div class="col-md-7"><asp:Label ID="lblChequeDate" runat="server"></asp:Label></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Account No</div>
                <div class="col-md-7"><asp:Label ID="lblAccountNo" runat="server"></asp:Label></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Comment</div>
                <div class="col-md-7">
                    <asp:DropDownList ID="txtComment" CssClass="form-control" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="txtComment_SelectedIndexChanged">
                        <asp:ListItem Value="1">Cheque amount is wrong</asp:ListItem>
                        <asp:ListItem Value="2">Payee NIC is wrong</asp:ListItem>
                        <asp:ListItem Value="3">Cheque payee is wrong </asp:ListItem>
                        <asp:ListItem Value="4">Cheque date is wrong</asp:ListItem>
                        <asp:ListItem Value="5">Cheque not crossed</asp:ListItem>
                        <asp:ListItem Value="6">Cheque crossed</asp:ListItem>
                        <asp:ListItem Value="7">Cheque number is wrong</asp:ListItem>
                        <asp:ListItem Value="8">Other</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5"></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtOther" MaxLength="45" AutoPostBack="true" runat="server" Width="165px" 
                        TabIndex="4"  ></asp:TextBox></div>
            </div>
            <div class="form-group">
                <div class="col-md-12">
                    <asp:Button ID="btnPeied" runat="server" Enabled="false" TabIndex="3" 
                        Text="Cancel" onclick="btnPeied_Click" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
