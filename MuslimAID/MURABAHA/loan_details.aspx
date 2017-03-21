<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="loan_details.aspx.cs" Inherits="MuslimAID.MURABHA.loan_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
        $("document").ready(function(){
            $('.period').on('change', function(){
                var LA = $(".loanAmount").val(); //Facility Amount
                var IR = $(".interest").val(); //Interest rate
                var P = $(".period").val(); //Period
                var DP = $(".downpayment").val(); //Down payment
                
                var IA = parseFloat(((LA-DP)*IR)/100); //Calculate interest amount
                var MI = (parseFloat(LA-DP) + IA)/P; //Calculate monthly installment
                
                $('.interestAmount').val(IA);
                $('.monthInstall').val(MI);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Facility Details</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Facility Code<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="15" AutoPostBack="true" runat="server" TabIndex="1"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Capital Applicant Code<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCACode" CssClass="form-control" MaxLength="15" AutoPostBack="true" runat="server" TabIndex="2"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Facility Amount/ Value<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtLDLAmount" CssClass="numbersOnly form-control loanAmount" MaxLength="12" runat="server" TabIndex="3"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Product type/ Category<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtProdCate" CssClass="form-control" MaxLength="12" runat="server" TabIndex="4"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Brand<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtBrand" CssClass="form-control" 
                        MaxLength="12" runat="server" TabIndex="5"  
                        onkeydown="return isNumeric(event.keyCode);" 
                        onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Model No<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtModelNo" CssClass="numbersOnly form-control" MaxLength="12" runat="server" TabIndex="6"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Selling Price<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtSellPrice" CssClass="numbersOnly form-control" MaxLength="12" runat="server" TabIndex="7"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Down Payment<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtDownPay" CssClass="numbersOnly downpayment form-control" MaxLength="12" runat="server" TabIndex="8"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Service Charges<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtLDSerCharges" CssClass="numbersOnly form-control" MaxLength="12" runat="server" TabIndex="9"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Registrtion Fee<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtRegistrationFee" CssClass="numbersOnly form-control" MaxLength="12" runat="server" TabIndex="10"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Walfare Fee<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtWalfareFee" CssClass="numbersOnly form-control" MaxLength="12" runat="server" TabIndex="11"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other Charges<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtLDOtherCharg" CssClass="numbersOnly form-control" MaxLength="10" runat="server" TabIndex="12"></asp:TextBox>&nbsp;</div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Interest Rate<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtLDIntRate" CssClass="numbersOnly form-control interest" MaxLength="5" runat="server" TabIndex="13"></asp:TextBox>&nbsp;
                    Eg:(36)
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Period<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbPeriod" CssClass="form-control period" runat="server" TabIndex="14">
                        <asp:ListItem Value="0">Select Period</asp:ListItem>
                        <asp:ListItem Value="1">1 Month</asp:ListItem>
                        <asp:ListItem Value="2">2 Month</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Monthly Interest Amount<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtLDMInterest" CssClass="numbersOnly form-control interestAmount" MaxLength="9" runat="server" TabIndex="15"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Monthly Instollment<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtLDMInstoll" CssClass="numbersOnly form-control monthInstall" MaxLength="9" runat="server" TabIndex="16"></asp:TextBox>
                </div>
            </div>
        </div>        
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Reason to apply a facility<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtResonToApply" CssClass="form-control" 
                        runat="server" TabIndex="17"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <div class="form-group">
                <div class="col-md-12">Any unsettled advances/ facilities available :<span style="color:Red;">* </span>
                    <asp:RadioButton GroupName="rdoUnsetlled" TabIndex="18" ID="rdoYes" runat="server" /> Yes &nbsp;&nbsp;
                    <asp:RadioButton GroupName="rdoUnsetlled" TabIndex="19" ID="rdoNo" Checked="true" runat="server" /> No
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
                        <td><asp:TextBox CssClass="numbersOnly form-control" ID="txtFAmount1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOutstandBal1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtMonthInstal1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRemainInstal1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtNameOrg2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtPurpos2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="numbersOnly form-control" ID="txtFAmount2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOutstandBal2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtMonthInstal2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRemainInstal2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtNameOrg3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtPurpos3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="numbersOnly form-control" ID="txtFAmount3" runat="server"></asp:TextBox></td>
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
                <div class="col-md-7"><asp:TextBox ID="txtSupplierTelephone" MaxLength="12" CssClass="form-control" runat="server" TabIndex="0"></asp:TextBox></div>
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
                <asp:TextBox ID="txtSupplierMobile" MaxLength="12" CssClass="form-control" runat="server" TabIndex="0"></asp:TextBox>
                </div>
             </div>
         </div>--%>
        <div class="col-md-12">
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" 
                Text="Submit" TabIndex="11" onclick="btnSubmit_Click"/>
            <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" 
                Text="Update" TabIndex="12" onclick="btnUpdate_Click"/>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</div>
</asp:Content>
