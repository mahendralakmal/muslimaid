<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="supplier.aspx.cs" Inherits="MuslimAID.MURABAHA.supplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $("document").ready(function(){
            
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>Murabaha - Suplier</h4></div>
        <div class="col-md-12 form-container">
            <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Facility Code<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtCC" MaxLength="30" CssClass="form-control" runat="server" 
                        AutoPostBack="true" TabIndex="1" Enabled="false" 
                        ontextchanged="txtCC_TextChanged"></asp:TextBox>
                </div>
             </div>
             </div>
            <div class="col-md-12"> 
            <hr />
            </div>
             
            <div class="col-md-6"> 
                <div class="form-group">
                    <div class="col-md-5">Supplier Name<span style="color:Red;"> *</span></div>
                    <div class="col-md-7">
                    <asp:TextBox ID="txtSupplierName" CssClass="form-control" 
                            runat="server" AutoPostBack="true" TabIndex="2"></asp:TextBox>
                    </div>
                 </div>
             </div>
            <div class="col-md-12"></div> 
            <div class="col-md-6"> 
                <div class="form-group">
                    <div class="col-md-5">Supplier Type</div>
                    <div class="col-md-7">
                        <asp:RadioButton ID="rdoIndividual" value="individual" TabIndex="3" 
                            runat="server" Text="Individual" 
                            GroupName="suplier_type" CssClass="radio radio-inline" AutoPostBack="true" 
                            oncheckedchanged="rdoIndividual_CheckedChanged" /> 
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="rdoBusines" value="business" TabIndex="4" runat="server" Text="Business" 
                            GroupName="suplier_type" CssClass="radio radio-inline" AutoPostBack="true" 
                            oncheckedchanged="rdoBusines_CheckedChanged" />
                    </div>
                </div>
             </div> 
            <div class="col-md-12"></div> 
            <div class="col-md-6" id="divBusiness"> 
                <div class="form-group">
                    <div class="col-md-5">BR No</div>
                    <div class="col-md-7">
                    <asp:TextBox ID="txtBrNo" CssClass="form-control" 
                            runat="server" TabIndex="5"></asp:TextBox>
                    </div>
                 </div>
             </div> 
            <div class="col-md-6"> 
                <div class="form-group" id="divIndividual">
                    <div class="col-md-5">NIC</div>
                    <div class="col-md-7">
                    <asp:TextBox ID="txtNIC" MaxLength="12" CssClass="form-control" 
                            runat="server" TabIndex="6"></asp:TextBox>
                    </div>
                 </div>
             </div>
            <%--<div class="col-md-6"> 
                <div class="form-group" id="div1">
                    <div class="col-md-5">Name you prefer to print on cheque</div>
                    <div class="col-md-7">
                    <asp:TextBox ID="txtNameOnChecque" CssClass="form-control" MaxLength="50"
                            runat="server" TabIndex="7"></asp:TextBox>
                    </div>
                 </div>
             </div>--%>
            <div class="col-md-6"> 
                <div class="form-group">
                    <div class="col-md-5">Contact Person<span style="color:Red;"> *</span></div>
                    <div class="col-md-7">
                    <asp:TextBox ID="txtContactPerson" CssClass="form-control" 
                            runat="server" TabIndex="7"></asp:TextBox>
                    </div>
                 </div>
             </div>
            <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Business Address<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtBisAddress" CssClass="form-control" Height="80px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="8"></asp:TextBox>
                </div>
             </div>
             </div>
             
            <div class="col-md-6"> 
                <div class="form-group">
                    <div class="col-md-5">Telephone</div>
                    <div class="col-md-7">
                    <asp:TextBox ID="txtTelephone" MaxLength="10" CssClass="numbersOnly form-control" 
                            runat="server" TabIndex="9"></asp:TextBox>
                    </div>
                 </div>
             </div>
             
            <div class="col-md-6"> 
                <div class="form-group">
                    <div class="col-md-5">Mobile</div>
                    <div class="col-md-7">
                    <asp:TextBox ID="txtMobile" MaxLength="10" CssClass="numbersOnly form-control" 
                            runat="server" TabIndex="10"></asp:TextBox>
                    </div>
                 </div>
             </div>
             
            <div class="col-md-6"> 
                <div class="form-group">
                    <div class="col-md-5">Invoice Value<span style="color:Red;"> *</span></div>
                    <div class="col-md-7">
                    <asp:TextBox ID="txtInvoiceValue" MaxLength="10" CssClass="numbersOnly form-control" 
                            runat="server" TabIndex="11"></asp:TextBox>
                    </div>
                 </div>
             </div>
             <div class="col-md-12">
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary"
                     runat="server" Text="Submit" TabIndex="12" onclick="btnSubmit_Click"/>&nbsp;
                <asp:Button ID="btnUpdate" CssClass="btn btn-primary"
                     runat="server" Text="Update" Enabled="false" TabIndex="13" onclick="btnUpdate_Click"/>&nbsp;
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
             
        </div>
</div>   
</asp:Content>
