<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="loan_details.aspx.cs" Inherits="MuslimAID.MURABHA.loan_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
        $("document").ready(function(){
            $('.interest').on('change', function(){calcMarkup();});
            $('.period').on('change', function(){calcMarkup();});      
            $('.txtLDSerCharges').on('change', function(){calcMarkup();});      
            $('.txtRegistrationFee').on('change', function(){calcMarkup();});      
            $('.txtWalfareFee').on('change', function(){calcMarkup();});      
            $('.txtLDOtherCharg').on('change', function(){calcMarkup();});      
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
                    <asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="30" 
                        AutoPostBack="true" runat="server" TabIndex="1"
                        ontextchanged="txtCC_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Facility Amount/ Value<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtLDLAmount" CssClass="numbersOnly form-control loanAmount" MaxLength="12" runat="server" TabIndex="3"  ReadOnly="true" onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Invoice Value<span style="color:Red;"></span></div>
                <div class="col-md-7"><asp:TextBox ID="txtSellPrice" CssClass="numbersOnly form-control invoiceVal" MaxLength="12" runat="server" TabIndex="7"  ReadOnly="true" onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Down Payment<span style="color:Red;"></span></div>
                <div class="col-md-7"><asp:TextBox ID="txtDownPay" CssClass="numbersOnly downpayment form-control" MaxLength="12" runat="server" TabIndex="8"  ReadOnly="true" onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Service or Documentation Charges<span style="color:Red;"></span></div>
                <div class="col-md-7"><asp:TextBox ID="txtLDSerCharges" CssClass="numbersOnly txtLDSerCharges form-control" MaxLength="12" runat="server" TabIndex="9"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Insurance Fee<span style="color:Red;"></span></div>
                <div class="col-md-7"><asp:TextBox ID="txtRegistrationFee" CssClass="numbersOnly txtRegistrationFee form-control" MaxLength="12" runat="server" TabIndex="10"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Welfare or Voluntory Contribution<span style="color:Red;"></span></div>
                <div class="col-md-7"><asp:TextBox ID="txtWalfareFee" CssClass="numbersOnly txtWalfareFee form-control" MaxLength="12" runat="server" TabIndex="11"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other Charges<span style="color:Red;"></span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtLDOtherCharg" CssClass="numbersOnly txtLDOtherCharg form-control" MaxLength="10" runat="server" TabIndex="12"></asp:TextBox>&nbsp;</div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Markup Rate<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtLDIntRate" CssClass="numbersOnly form-control interest" MaxLength="5" runat="server" TabIndex="13"></asp:TextBox>
            </div>
        </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Period<span style="color:Red;"></span></div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbPeriod" CssClass="form-control period" runat="server" TabIndex="14">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Markup Portion<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtLDMInterest" CssClass="numbersOnly form-control interestAmount" MaxLength="9" runat="server" TabIndex="15" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Capital Portion<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="TextBox1" CssClass="numbersOnly form-control capitalPortion" MaxLength="9" runat="server" TabIndex="15" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Installment Value<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtLDMInstoll" CssClass="numbersOnly form-control monthInstall" MaxLength="9" runat="server" TabIndex="16"></asp:TextBox> (Value of Capital Portion + Value of Markup Portion)
                </div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Total Recievable<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtRTotal" CssClass="numbersOnly form-control RTotal" MaxLength="9" runat="server" TabIndex="17"></asp:TextBox>
                    (Service or Documentation Charges + Insurance Fee + Welfare or Voluntory Contribution + Other Charges + Installment Value * Period)
                </div>
            </div>
        </div>        
        <div class="col-md-12">
            <%--<asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" 
                Text="Submit" TabIndex="18" onclick="btnSubmit_Click"/>--%>
            <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" 
                Text="Update" TabIndex="19" onclick="btnUpdate_Click"/>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</div>
</asp:Content>
