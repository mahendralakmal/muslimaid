<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true"
    CodeBehind="family_appraisal.aspx.cs" Inherits="MuslimAID.SALAM.family_appraisal"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../dist/js/base_scripts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Salam - Family Appraisal</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Contract Code <span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="12" AutoPostBack="true" Enabled="false" runat="server" TabIndex="0" ></asp:TextBox></div>
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
                <div class="col-md-7"><asp:TextBox ID="txtSalWages" onchange="calcNetIn()" CssClass="form-control txtSalWa" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent income - Building</div>
                <div class="col-md-7"><asp:TextBox ID="txtRentBuildingIn" onchange="calcNetIn()" CssClass="form-control txtRentB" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent income – Others</div>
                <div class="col-md-7"><asp:TextBox ID="txtRentInOther" onchange="calcNetIn()" CssClass="form-control txtRentO" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Net Income from Business</div>
                <div class="col-md-7"><asp:TextBox ID="txtNetBusinesIn" CssClass="form-control txtNetIn" Enabled="false" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other income</div>
                <div class="col-md-7"><asp:TextBox ID="txtInO" onchange="calcMBI()" CssClass="form-control txtInO" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Annual Family Income</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtFamilyIn" Enabled="false" CssClass="form-control txtFamiIn" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Expenses (BE)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Food</div>
                <div class="col-md-7"><asp:TextBox ID="txtFoodEx" CssClass="form-control txtFood" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Education</div>
                <div class="col-md-7"><asp:TextBox ID="txtEduEx" CssClass="form-control txtEdu" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Water, Electricity & Telephone</div>
                <div class="col-md-7"><asp:TextBox ID="txtWETEx" CssClass="form-control txtWET" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Health & Sanitation</div>
                <div class="col-md-7"><asp:TextBox ID="txtHSEx" CssClass="form-control txtHS" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent payments</div>
                <div class="col-md-7"><asp:TextBox ID="txtRenPayEx" CssClass="form-control txtRenPay" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other facility/advance installments</div>
                <div class="col-md-7"><asp:TextBox ID="txtOFAIEx" CssClass="form-control txtOFAI" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Travel & Transport</div>
                <div class="col-md-7"><asp:TextBox ID="txtTTransEx" CssClass="form-control txtTTrans" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Clothes</div>
                <div class="col-md-7"><asp:TextBox ID="txtClothsEx" CssClass="form-control txtCloths" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Others</div>
                <div class="col-md-7"><asp:TextBox ID="txtOthersEx" CssClass="form-control txtOthers" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Annual Family Expenses</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtFExpense" Enabled="false" CssClass="form-control txtFExpense" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12">&nbsp;<hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Net annual family income</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtNetAnualFIn" Enabled="false" onchange="calcNetAnulaIncome()" CssClass="form-control txtNetAnualFIN" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Amount that can be used for other purposes (monthly)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtAmountOPEx" Enabled="true" CssClass="form-control txtAmountOPEx" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum amount payable for the facility (monthly/ weekly)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtAmountFEx" Enabled="true" CssClass="form-control txtAmountFEx" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Facility Repayment period (months/weeks)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtFRPriod" Enabled="true" CssClass="form-control txtFRPriod" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum amount can be disbursed</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtMAD" Enabled="true" CssClass="form-control txtMAD" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum disbursable amount according to the institutional policy</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtMDAAIP" Enabled="true" CssClass="form-control txtMDAAIP" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Requested amount as per the sfacility application</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtRAPSA" Enabled="true" CssClass="form-control txtRAPSA" runat="server" TabIndex="8"></asp:TextBox></div>
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
