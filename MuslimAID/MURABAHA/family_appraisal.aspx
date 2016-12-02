<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="family_appraisal.aspx.cs" Inherits="MuslimAID.MURABAHA.family_appraisal" Title="Untitled Page" %>
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
                <div class="col-md-5">Contract Code<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="12" AutoPostBack="true" Enabled="false" runat="server" TabIndex="0" ></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">C. Applicant Code<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCACode" CssClass="form-control" MaxLength="10" runat="server" TabIndex="1"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Business Income (BI)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Salary & Wages<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtSalWa" onchange="calcNetIn()" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent income - Building<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtRentB" onchange="calcNetIn()" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent income – Others<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtRentO" onchange="calcNetIn()" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Net Income from Business<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtNetIn" CssClass="form-control" Enabled="false" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other income<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtInO" onchange="calcMBI()" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Annual Family Income</strong><span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtFamiIn" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Expenses (BE)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Food<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtFood" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Education<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtEdu" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Water, Electricity & Telephone<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtWET" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Health & Sanitation<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtHS" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent payments<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtRenPay" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other facility/advance installments<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtOFAI" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Travel & Transport<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtTTrans" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Clothes<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCloths" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Others<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtOthers" CssClass="form-control" onchange="calcMExpenses()" runat="server" TabIndex="8"></asp:TextBox></div>
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
                <div class="col-md-7"><asp:TextBox ID="txtNetAnualFIN" Enabled="false" onchange="calcNetAnulaIncome()" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Amount that can be used for other purposes (monthly)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtAmountOP" Enabled="true" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum amount payable for the facility (monthly/ weekly)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtMamountF" Enabled="true" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Facility Repayment period (months/weeks)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="txtFRP" Enabled="true" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
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
    </div>
    
    <div class="col-md-12">
        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" 
            Text="Submit" Enabled="true" TabIndex="11" onclick="btnSubmit_Click" />
        <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" 
            Text="Update" TabIndex="12" Enabled="False" onclick="btnUpdate_Click" />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
</div>
</asp:Content>
