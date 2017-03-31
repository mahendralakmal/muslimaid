<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true" CodeBehind="family_appraisal.aspx.cs" Inherits="MuslimAID.SALAM.family_appraisal"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        $("document").ready(function(){
            $(".txtNetIn").attr("readonly","true");
            $(".txtFamiIn").attr("readonly","true");
            $(".txtFExpense").attr("readonly","true");
            $(".txtNetAnualFIN").attr("readonly","true");
        });
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Family Appraisal</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Facility Code <span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCC" CssClass="form-control" 
                        MaxLength="15" AutoPostBack="true" Enabled="false" runat="server" TabIndex="1" 
                        ontextchanged="txtCC_TextChanged" ></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Annual Business Income (AI)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Salary & Wages <span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtSalWages" onchange="calcNetIn()" CssClass="numbersOnly form-control 
                txtSalWa" runat="server" TabIndex="3"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent income - Building</div>
                <div class="col-md-7"><asp:TextBox ID="txtRentBuildingIn" onchange="calcNetIn()" CssClass="numbersOnly form-control txtRentB" runat="server" TabIndex="4"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent income – Others</div>
                <div class="col-md-7"><asp:TextBox ID="txtRentInOther" onchange="calcNetIn()" CssClass="numbersOnly form-control txtRentO" runat="server" TabIndex="5"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Net Income from Business</div>
                <div class="col-md-7">
                <asp:TextBox ID="txtNetBusinesIn" 
                        CssClass="form-control txtNetIn" runat="server" TabIndex="6"></asp:TextBox>
                <asp:HiddenField ID="hidNetIn" runat="server" />
                        </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other income</div>
                <div class="col-md-7"><asp:TextBox ID="txtInO" onchange="calcNetIn()" CssClass="form-control numbersOnly txtInO" runat="server" TabIndex="6"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Annual Family Income</strong></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtFamilyIn" 
                        CssClass="form-control txtFamiIn" runat="server" TabIndex="7"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Annual Expenses (AE)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Food</div>
                <div class="col-md-7"><asp:TextBox ID="txtFoodEx" CssClass="numbersOnly form-control txtFood" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Education</div>
                <div class="col-md-7"><asp:TextBox ID="txtEduEx" CssClass="numbersOnly form-control txtEdu" onchange="calcMExpenses()" runat="server" TabIndex="9"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Water, Electricity & Telephone</div>
                <div class="col-md-7"><asp:TextBox ID="txtWETEx" CssClass="numbersOnly form-control txtWET" onchange="calcMExpenses()" runat="server" TabIndex="10"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Health & Sanitation</div>
                <div class="col-md-7"><asp:TextBox ID="txtHSEx" CssClass="numbersOnly form-control txtHS" onchange="calcMExpenses()" runat="server" TabIndex="11"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent payments</div>
                <div class="col-md-7"><asp:TextBox ID="txtRenPayEx" CssClass="numbersOnly form-control txtRenPay" onchange="calcMExpenses()" runat="server" TabIndex="12"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other facility/advance installments</div>
                <div class="col-md-7"><asp:TextBox ID="txtOFAIEx" CssClass="numbersOnly form-control txtOFAI" onchange="calcMExpenses()" runat="server" TabIndex="13"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Travel & Transport</div>
                <div class="col-md-7"><asp:TextBox ID="txtTTransEx" CssClass="numbersOnly form-control txtTTrans" onchange="calcMExpenses()" runat="server" TabIndex="14"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Clothes</div>
                <div class="col-md-7"><asp:TextBox ID="txtClothsEx" CssClass="numbersOnly form-control txtCloths" onchange="calcMExpenses()" runat="server" TabIndex="15"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Others</div>
                <div class="col-md-7"><asp:TextBox ID="txtOthersEx" CssClass="numbersOnly form-control txtOthers" onchange="calcMExpenses()" runat="server" TabIndex="16"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Annual Family Expenses</strong></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtFExpense" 
                        CssClass="form-control txtFExpense" runat="server" TabIndex="17"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12">&nbsp;<hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Net annual family income</strong></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtNetAnualFIn" 
                        onchange="calcNetAnulaIncome()" CssClass="form-control txtNetAnualFIN" 
                        runat="server" TabIndex="18"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Amount that can be used for other purposes (monthly)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtAmountOPEx" Enabled="true" CssClass="numbersOnly txtAmountOPEx form-control" runat="server" TabIndex="19"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum amount payable for the facility (monthly/ weekly)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtAmountFEx" Enabled="true" CssClass="numbersOnly txtAmountFEx form-control" runat="server" TabIndex="20"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Facility Repayment period (months/weeks)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtFRPriod" Enabled="true" onchange="calcMaxAmountCanBeDisbursed()" CssClass="numbersOnly txtFRPriod form-control" runat="server" TabIndex="21"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum amount can be disbursed</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtMAD" Enabled="true" CssClass="numbersOnly txtMAD form-control" runat="server" TabIndex="22"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum disbursable amount according to the institutional policy</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtMDAAIP" Enabled="true" CssClass="numbersOnly txtMDAAIP form-control" runat="server" TabIndex="23"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Requested amount as per the facility application</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtRAPSA" Enabled="true" CssClass="numbersOnly txtRAPSA form-control" runat="server" TabIndex="24"></asp:TextBox></div>
            </div>
        </div>
        
        <div class="col-md-12">
        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" 
            Text="Submit" Enabled="true" TabIndex="25" onclick="btnSubmit_Click" />
        <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" 
            Text="Update" TabIndex="26" Enabled="False" onclick="btnUpdate_Click" />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
    </div>
    
    
</div>
</asp:Content>
