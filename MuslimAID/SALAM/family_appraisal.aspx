<%@ Page Language="C#" MasterPageFile="~SALAM/Salam.Master" AutoEventWireup="true"
    CodeBehind="family_appraisal.aspx.cs" Inherits="MuslimAID.SALAM.family_appraisal"
    Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    
    function calcNetIn() {
        $salWa = $("#ctl00_ContentPlaceHolder1_txtSalWa").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtSalWa").val();
        $rentInB = $("#ctl00_ContentPlaceHolder1_txtRentB").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtRentB").val();
        $rentInO = $("#ctl00_ContentPlaceHolder1_txtRentO").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtRentO").val();

        $("#ctl00_ContentPlaceHolder1_txtNetIn").val(parseFloat($salWa) + parseFloat($rentInB) + parseFloat($rentInO));
        calcMBI();
    }
    function calcMBI() {
        $InO = $("#ctl00_ContentPlaceHolder1_txtInO").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtInO").val();
        $netIn = $("#ctl00_ContentPlaceHolder1_txtNetIn").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtNetIn").val();

        $("#ctl00_ContentPlaceHolder1_txtFamiIn").val(parseFloat($InO) + parseFloat($netIn));
    }
    function calcMExpenses() {
        $foodEx = $("#ctl00_ContentPlaceHolder1_txtFood").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtFood").val();
        $eduEx = $("#ctl00_ContentPlaceHolder1_txtEdu").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtEdu").val();
        $wetEx = $("#ctl00_ContentPlaceHolder1_txtWET").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtWET").val();
        $hsEx = $("#ctl00_ContentPlaceHolder1_txtHS").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtHS").val();
        $rentEx = $("#ctl00_ContentPlaceHolder1_txtRenPay").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtRenPay").val();
        $ofaiEx = $("#ctl00_ContentPlaceHolder1_txtOFAI").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtOFAI").val();
        $tTranEx = $("#ctl00_ContentPlaceHolder1_txtTTrans").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtTTrans").val();
        $clothEx = $("#ctl00_ContentPlaceHolder1_txtCloths").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtCloths").val();
        $otherEx = $("#ctl00_ContentPlaceHolder1_txtOthers").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtOthers").val();

        $total = parseFloat($foodEx) + parseFloat($eduEx) + parseFloat($wetEx) + parseFloat($hsEx) + parseFloat($rentEx) + parseFloat($ofaiEx) + parseFloat($tTranEx) + parseFloat($clothEx) + parseFloat($otherEx)

        $("#ctl00_ContentPlaceHolder1_txtFExpense").val($total);
        calcNetAnulaIncome();
    }
    function calcNetAnulaIncome(){
        $famiIn = $("#ctl00_ContentPlaceHolder1_txtFamiIn").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtFamiIn").val();
        $otherEx = $("#ctl00_ContentPlaceHolder1_txtFExpense").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtFExpense").val();
        $("#ctl00_ContentPlaceHolder1_txtNetAnualFIN").val(parseFloat($InO) + parseFloat($netIn));
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Family Appraisal</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Contract CodecmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="12" AutoPostBack="true" Enabled="false" runat="server" TabIndex="0" ></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">C. Applicant CodecmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtCACode" CssClass="form-control" MaxLength="10" runat="server" TabIndex="1"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Business Income (BI)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Salary & WagescmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtSalWages" onchange="calcNetIn()" CssClass="form-control
                " runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent income - BuildingcmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtRentBuildingIn" onchange="calcNetIn()" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent income – OtherscmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtRentInOther" onchange="calcNetIn()" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Net Income from BusinesscmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtNetBusinesIn" CssClass="form-control" Enabled="false" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other incomecmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtInO" onchange="calcMBI()" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Annual Family Income</strong>cmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtFamilyIn" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Expenses (BE)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">FoodcmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtFoodEx" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">EducationcmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtEduEx" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Water, Electricity & TelephonecmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtWETEx" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Health & SanitationcmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtHSEx" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent paymentscmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtRenPayEx" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other facility/advance installmentscmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtOFAIEx" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Travel & TransportcmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtTTransEx" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Clothes</div>
                <div class="col-md-7"><asp:TextBox ID="txtClothsEx" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">OtherscmdVehicle</div>
                <div class="col-md-7"><asp:TextBox ID="txtOthersEx" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Annual Family Expenses</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtFExpense" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12">&nbsp;<hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Net annual family income</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtNetAnualFIn" Enabled="false" onchange="calcNetAnulaIncome()" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Amount that can be used for other purposes (monthly)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtAmountOPEx" Enabled="true" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum amount payable for the facility (monthly/ weekly)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtAmountFEx" Enabled="true" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Facility Repayment period (months/weeks)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtFRPriod" Enabled="true" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum amount can be disbursed</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtMAD" Enabled="true" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum disbursable amount according to the institutional policy</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtMDAAIP" Enabled="true" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Requested amount as per the sfacility application</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtRAPSA" Enabled="true" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
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
