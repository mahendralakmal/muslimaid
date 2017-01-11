<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="loan_details.aspx.cs" Inherits="MuslimAID.MURABHA.loan_details" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Facility Details</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Contract Code<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="12" Enabled="false" AutoPostBack="true" runat="server" TabIndex="0"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Facility Amount/ Value<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtLDLAmount" CssClass="form-control" MaxLength="12" runat="server" AutoPostBack="true" TabIndex="0"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Product type/ Category<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtProdCate" CssClass="form-control" MaxLength="12" runat="server" AutoPostBack="true" TabIndex="0"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Brand<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtBrand" CssClass="form-control" 
                        MaxLength="12" runat="server" AutoPostBack="true" TabIndex="0"  
                        onkeydown="return isNumeric(event.keyCode);" 
                        onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Model No<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtModelNo" CssClass="form-control" MaxLength="12" runat="server" AutoPostBack="true" TabIndex="0"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Selling Price<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtSellPrice" CssClass="form-control" MaxLength="12" runat="server" AutoPostBack="true" TabIndex="0"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Down Payment<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtDownPay" CssClass="form-control" MaxLength="12" runat="server" AutoPostBack="true" TabIndex="0"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Service Charges<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtLDSerCharges" CssClass="form-control" MaxLength="12" runat="server" AutoPostBack="true" TabIndex="0"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Registrtion Fee<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtRegistrationFee" CssClass="form-control" MaxLength="12" runat="server" AutoPostBack="true" TabIndex="0"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Walfare Fee<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtWalfareFee" CssClass="form-control" MaxLength="12" runat="server" AutoPostBack="true" TabIndex="0"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other Charges<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtLDOtherCharg" CssClass="form-control" MaxLength="10" runat="server" TabIndex="3"></asp:TextBox>&nbsp; Eg:(2000.00)<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Price" ValidationExpression="((\d{1,3}(\,\d{3})*)?|(\d+))(\.\d{2})" ControlToValidate="txtLDOtherCharg"></asp:RegularExpressionValidator></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Interest Rate<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtLDIntRate" CssClass="form-control" MaxLength="5" runat="server" Enabled="false" TabIndex="4"></asp:TextBox>&nbsp;
                    Eg:(36)
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Period<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbPeriod" CssClass="form-control" runat="server" TabIndex="5">
                        <asp:ListItem Value="1">1 Month</asp:ListItem>
                        <asp:ListItem Value="2">2 Month</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Monthly Instollment<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtLDMInstoll" CssClass="form-control" MaxLength="9" runat="server" Enabled="False" TabIndex="6" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
        </div>        
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Reason to apply a facility<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtResonToApply" MaxLength="4" CssClass="form-control" 
                        runat="server" TabIndex="10"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <div class="form-group">
                <div class="col-md-12">Any unsettled advances/ facilities available :<span style="color:Red;">* </span>
                    <asp:RadioButton GroupName="rdoUnsetlled" ID="rdoYes" runat="server" /> Yes &nbsp;&nbsp;
                    <asp:RadioButton GroupName="rdoUnsetlled" ID="rdoNo" Checked="true" runat="server" /> No
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <div class="table-back form-group table-responsive">
                <table class="table" width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <th></th>
                        <th class="col-md-3 col-sm-3 col-xs-3">Name of Organization</th>
                        <th class="col-md-2 col-sm-2 col-xs-2">Purpose</th>
                        <th class="col-md-2 col-sm-2 col-xs-2">Facility Amount</th>
                        <th class="col-md-2 col-sm-2 col-xs-2">Outstanding Balance</th>
                        <th class="col-md-2 col-sm-2 col-xs-2">Monthly Installment</th>
                        <th class="col-md-1 col-sm-1 col-xs-1">Remaining no of Installment</th>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtNameOrg1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtPurpos1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtFAmount1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOutstandBal1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtMonthInstal1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRemainInstal1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtNameOrg2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtPurpos2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtFAmount2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOutstandBal2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtMonthInstal2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRemainInstal2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtNameOrg3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtPurpos3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtFAmount3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOutstandBal3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtMonthInstal3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRemainInstal3" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
        </div>
        <%--
        <div class="col-md-12">&nbsp;</div>
        <div class="col-md-12"><h4>Supplier Detils</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Supplier Name<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtSupplier" MaxLength="4" CssClass="form-control" 
                        runat="server" TabIndex="10"></asp:TextBox>
                </div>
            </div>
        </div>         
         <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Supplier Telephone<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtSupplierTelephone" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox></div>
            </div>
         </div>
        <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Supplier Address<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtSupplierAddress" CssClass="form-control" Height="70px" 
                        TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="10"></asp:TextBox>
                </div>
             </div>
         </div>         
         <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Supplier Mobile<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtSupplierMobile" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
             </div>
         </div>--%>
        <div class="col-md-12">
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" 
                Text="Submit" Enabled="false" TabIndex="11" onclick="btnSubmit_Click"/>
            <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" 
                Text="Update" TabIndex="12" Enabled="False" onclick="btnUpdate_Click"/>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</div>
</asp:Content>
