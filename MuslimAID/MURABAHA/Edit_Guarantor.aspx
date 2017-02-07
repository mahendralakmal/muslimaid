<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Edit_Guarantor.aspx.cs" Inherits="MuslimAID.MURABAHA.Edit_Guarantor"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Map Guarantors</h4></div>
    <div class="col-md-6 form-container">
        <asp:HiddenField ID="hidBranch" runat="server" />
        <asp:HiddenField ID="hidSoID" runat="server" />
        <asp:HiddenField ID="hidCACode" runat="server" />
        <div class="form-group">
            <div class="col-md-5">Contract Code <span style="color:Red;">*</span></div>
            <div class="col-md-7"><asp:TextBox ID="txtCCode" runat="server" CssClass="form-control" AutoPostBack="true" 
                        ontextchanged="txtCCode_TextChanged" TabIndex="1"></asp:TextBox></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Team ID <span style="color:Red;">*</span></div>
            <div class="col-md-7"><asp:TextBox ID="txtTeamID" runat="server" CssClass="form-control" MaxLength="2" TabIndex="2"></asp:TextBox></div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Guarantor 01 <span style="color:Red;">*</span></div>
            <div class="col-md-7">
                <%--<div class="col-md-5"><asp:TextBox ID="txtGura" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox></div>
                <div class="col-md-7">--%>
                <asp:TextBox ID="txtGuara1" runat="server" CssClass="form-control" MaxLength="15" TabIndex="3"></asp:TextBox></div>
            <%--</div>--%>
        </div>
        <div class="form-group">
            <div class="col-md-5">Guarantor 02 <span style="color:Red;">*</span></div>
            <div class="col-md-7">
                <%--<div class="col-md-5"><asp:TextBox ID="txtGura2Fron" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox></div>
                <div class="col-md-7">--%><asp:TextBox ID="txtGuara2" MaxLength="15" runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox></div>
            <%--</div>--%>
        </div>
        <asp:Button ID="btnChange" runat="server" Text="Edit" TabIndex="5" 
                        onclick="btnChange_Click" CssClass="btn btn-primary"/>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
</div>
</asp:Content>
