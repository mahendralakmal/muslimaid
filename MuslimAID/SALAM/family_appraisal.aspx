﻿<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true" CodeBehind="family_appraisal.aspx.cs" Inherits="MuslimAID.SALAM.family_appraisal"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        $("document").ready(function(){
            $(".txtNetIn").attr("readonly","true");
            $(".txtFamiIn").attr("readonly","true");
            $(".txtFExpense").attr("readonly","true");
            $(".txtNetAnualFIN").attr("readonly","true");
        });
    </script>
    <script type="text/javascript" src="../dist/js/base_scripts.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Salam - Family Appraisal</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Facility Code <span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="15" AutoPostBack="true" Enabled="false" runat="server" TabIndex="0" ></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">C. Applicant Code <span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCACode" CssClass="form-control" MaxLength="10" runat="server" TabIndex="1"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Business Income (BI)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Salary & Wages <span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtSalWages" onchange="calcNetIn()" CssClass="form-control 
                txtSalWa numbersOnly" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent income - Building</div>
                <div class="col-md-7"><asp:TextBox ID="txtRentBuildingIn" onchange="calcNetIn()" CssClass="form-control txtRentB numbersOnly" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent income – Others</div>
                <div class="col-md-7"><asp:TextBox ID="txtRentInOther" onchange="calcNetIn()" CssClass="form-control txtRentO numbersOnly" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Net Income from Business</div>
                <div class="col-md-7"><asp:TextBox ID="txtNetBusinesIn" 
                        CssClass="form-control txtNetIn numbersOnly" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other income</div>
                <div class="col-md-7"><asp:TextBox ID="txtInO" onchange="calcMBI()" CssClass="form-control txtInO numbersOnly" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Annual Family Income</strong></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtFamilyIn" 
                        CssClass="form-control txtFamiIn numbersOnly" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Expenses (BE)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Food</div>
                <div class="col-md-7"><asp:TextBox ID="txtFoodEx" CssClass="form-control txtFood numbersOnly" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Education</div>
                <div class="col-md-7"><asp:TextBox ID="txtEduEx" CssClass="form-control numbersOnly txtEdu" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Water, Electricity & Telephone</div>
                <div class="col-md-7"><asp:TextBox ID="txtWETEx" CssClass="form-control numbersOnly txtWET" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Health & Sanitation</div>
                <div class="col-md-7"><asp:TextBox ID="txtHSEx" CssClass="form-control numbersOnly txtHS" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent payments</div>
                <div class="col-md-7"><asp:TextBox ID="txtRenPayEx" CssClass="form-control numbersOnly txtRenPay" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other facility/advance installments</div>
                <div class="col-md-7"><asp:TextBox ID="txtOFAIEx" CssClass="form-control numbersOnly txtOFAI" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Travel & Transport</div>
                <div class="col-md-7"><asp:TextBox ID="txtTTransEx" CssClass="form-control numbersOnly txtTTrans" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Clothes</div>
                <div class="col-md-7"><asp:TextBox ID="txtClothsEx" CssClass="form-control numbersOnly txtCloths" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Others</div>
                <div class="col-md-7"><asp:TextBox ID="txtOthersEx" CssClass="form-control numbersOnly txtOthers" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Annual Family Expenses</strong></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtFExpense" 
                        CssClass="form-control numbersOnly txtFExpense" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12">&nbsp;<hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Net annual family income</strong></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtNetAnualFIn" 
                        onchange="calcNetAnulaIncome()" CssClass="form-control numbersOnly txtNetAnualFIN" 
                        runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Amount that can be used for other purposes (monthly)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtAmountOPEx" Enabled="true" CssClass="form-control txtAmountOPEx numbersOnly" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum amount payable for the facility (monthly/ weekly)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtAmountFEx" Enabled="true" CssClass="form-control txtAmountFEx numbersOnly" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Facility Repayment period (months/weeks)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtFRPriod" Enabled="true" onchange="calcMaxAmountCanBeDisbursed()" CssClass="form-control txtFRPriod numbersOnly" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum amount can be disbursed</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtMAD" Enabled="true" CssClass="form-control txtMAD numbersOnly" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum disbursable amount according to the institutional policy</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtMDAAIP" Enabled="true" CssClass="form-control txtMDAAIP numbersOnly" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Requested amount as per the facility application</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtRAPSA" Enabled="true" CssClass="form-control txtRAPSA numbersOnly" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        
        <div class="col-md-12">
        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" 
            Text="Submit" Enabled="true" TabIndex="11" onclick="btnSubmit_Click" />
        <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" 
            Text="Update" TabIndex="12" Enabled="False" onclick="btnUpdate_Click" />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
    </div>
    
    
</div>
</asp:Content>
