<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="agreement.aspx.cs" Inherits="MuslimAID.MURABHA.agreement" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function PopUPCA(){
       var win = window.open('../Agreement/Micro/ca1.aspx','ca1','left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
    }
    
    function PopUPCA2(){
       var win = window.open('../Agreement/Micro/ca2.aspx','ca2','left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>MF Application - Agreement</h4></div>
        <div class="col-md-6 form-container">
            <div class="form-group">
                <div class="col-md-5">Contract Code</div>
                <div class="col-md-7"><asp:TextBox ID="txtCC" runat="server" AutoPostBack="true" MaxLength="12" cssCl CssClass="form-control"></asp:TextBox></div>
            </div>
            <div class="form-group">
                <asp:Panel ID="pnlAgree" runat="server" Visible="false">
                    <div class="col-md-12"><asp:LinkButton ID="lnkPage1" CssClass="lnk_font_color" runat="server">Agreement Page 01</asp:LinkButton></div>
                    <div class="col-md-12"><asp:LinkButton ID="lnkPage2" CssClass="lnk_font_color" runat="server">Agreement Page 02</asp:LinkButton></div>
                </asp:Panel>
                <asp:Panel ID="pnlNoAgree" runat="server" Visible="false">
                    <div class="col-md-12"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
