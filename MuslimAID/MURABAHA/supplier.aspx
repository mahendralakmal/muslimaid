<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="supplier.aspx.cs" Inherits="MuslimAID.MURABAHA.supplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
        <div class="PageTitle"><h4>Murabaha - Suplier</h4></div>
        <div class="col-md-12 form-container">
            <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Facility Code<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtCC" MaxLength="15" CssClass="form-control" runat="server" 
                        AutoPostBack="true" TabIndex="1" Enabled="false" 
                        ontextchanged="txtCC_TextChanged"></asp:TextBox>
                </div>
             </div>
             </div>
            <div class="col-md-12"> 
            
             </div>
             
             <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Supplier Name<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtSupplierName" CssClass="form-control" 
                        runat="server" AutoPostBack="true" TabIndex="3"></asp:TextBox>
                </div>
             </div>
             </div>
            <%--<div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Supplier Category<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:DropDownList ID="cmbSupplierCategory" CssClass="form-control" TabIndex="1" runat="server" AutoPostBack="true">
                </asp:DropDownList></div>
             </div>
             </div>--%>
             
            <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Supplier Address<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtBisAddress" CssClass="form-control" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="4"></asp:TextBox>
                </div>
             </div>
             </div>
             
             <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Supplier Telephone<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtSupplierTelephone" MaxLength="10" CssClass="numbersOnly form-control" 
                        runat="server" AutoPostBack="true" TabIndex="5"></asp:TextBox>
                </div>
             </div>
             </div>
             
             <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Supplier Mobile<span style="color:Red;"> </span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtSupplierMobile" MaxLength="10" CssClass="numbersOnly form-control" 
                        runat="server" AutoPostBack="true" TabIndex="6"></asp:TextBox>
                </div>
             </div>
             </div>
             
             <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Supplier Bank<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:DropDownList ID="cmbSupplierBank" CssClass="form-control" TabIndex="7" 
                        runat="server" AutoPostBack="true" 
                        onselectedindexchanged="cmbSupplierBank_SelectedIndexChanged">
                </asp:DropDownList></div>
             </div>
             </div>
             
             <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Branch<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:DropDownList ID="cmbBnkBranch" CssClass="form-control" TabIndex="8" 
                        runat="server" AutoPostBack="true">
                </asp:DropDownList></div>
             </div>
             </div>
             
             <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Account Number<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtAccountNumber" MaxLength="12" CssClass="numbersOnly form-control" 
                        runat="server" AutoPostBack="true" TabIndex="9"></asp:TextBox>
                </div>
             </div>
             </div>
             
             <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Account Name<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtAccountName" MaxLength="12" CssClass="form-control" 
                        runat="server" AutoPostBack="true" TabIndex="10"></asp:TextBox>
                </div>
             </div>
             </div>
             
             <div class="col-md-12">
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary"
                     runat="server" Text="Submit" TabIndex="11" onclick="btnSubmit_Click"/>&nbsp;
                <asp:Button ID="btnUpdate" CssClass="btn btn-primary"
                     runat="server" Text="Update" TabIndex="13" onclick="btnUpdate_Click"/>&nbsp;
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
             
        </div>
</div>   
</asp:Content>
