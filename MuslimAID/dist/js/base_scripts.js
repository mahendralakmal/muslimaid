//LIVE SITE

/* ~~ Other Family details date time fields ~~ */
function calcUnitCost(unitCost, count, costId){
    alert('cost :'+unitCost+' - count:'+count+' id:'+costId);
    costId.val(parseFloat(unitCost)*parent(count));
}
$(function(){
//    $("#ctl00_ContentPlaceHolder1_txtUnitCost").on('change', function(){
//        calcUnitCost($(this).val(),$("#ctl00_ContentPlaceHolder1_txtNoOfUnits").val(),$("#ctl00_ContentPlaceHolder1_txtTotalCost"));
//    })
//    $("#ctl00_ContentPlaceHolder1_txtNoOfUnits").on('change', function(){
//        calcUnitCost($("#ctl00_ContentPlaceHolder1_txtUnitCost").val(),$(this).val(),$("#ctl00_ContentPlaceHolder1_txtTotalCost"));
//    })
    
    
    $("#ContentPlaceHolder1_txtUnitCost").on('change', function(){
        calcUnitCost($(this).val(),$("#ContentPlaceHolder1_txtNoOfUnits").val(),$("#ContentPlaceHolder1_txtTotalCost"));
    })
    $("#ContentPlaceHolder1_txtNoOfUnits").on('change', function(){
        calcUnitCost($("#ContentPlaceHolder1_txtUnitCost").val(),$(this).val(),$("#ContentPlaceHolder1_txtTotalCost"));
    })
    
});

/* ~~ Other Family details date time fields ~~ */
$(function(){
    for(var i = 1; i<=9;i++)
        $('#DobCDB'+i).datetimepicker({ format: 'DD/MM/YYYY' });
});

if($('#DobCDB').val() != "")
{
    $dob = new Date($('#DobCDB').val());
    $today = new Date();
    $age = Math.floor(($today - $dob) / (365.25 * 24 * 60 * 60 * 1000));
    $(".lblAge").html($age);
}

if($('#sDob').val() != "")
{
    $dob = new Date($('#sDob').val());
    $today = new Date();
    $age = Math.floor(($today - $dob) / (365.25 * 24 * 60 * 60 * 1000));
    $(".lblSoAge").html($age);
}

/* ~~ Murabaha basic details page ~~ */
$(function() {
    $('#DobCDB').datetimepicker({
        format: 'DD/MM/YYYY',
        //defaultDate: new Date()
    }).on('dp.change', function(event) {
        $dob = new Date(event.date);
        $today = new Date();
        $age = Math.floor(($today - $dob) / (365.25 * 24 * 60 * 60 * 1000));
        $(".lblAge").html($age);
    });

    $('#InspectionCDB').datetimepicker({ format: 'DD/MM/YYYY' });
    $('#dtpNicPassIssueDateCBD').datetimepicker({ format: 'DD/MM/YYYY' });
});

/* ~~ business details page ~~ */
var totIn = 0.00; var totPu = 0.00; var totEx = 0.00; var gp = 0.00;
    function calcIncom() {
        $(".txtTotalIncome").val(0);
        //$("#ctl00_ContentPlaceHolder1_hidtxtTotalIncome").val(0);
        $("#ContentPlaceHolder1_hidtxtTotalIncome").val(0);
        $cashIn = $(".txtBIncome").val() === '' ? 0.00 : $(".txtBIncome").val();
        $creditIn = $(".txtCrdtIncome").val() === '' ? 0.00 : $(".txtCrdtIncome").val();
        $otherIn = $(".txtOIncome").val() === '' ? 0.00 : $(".txtOIncome").val();

        totIn = parseFloat($cashIn) + parseFloat($creditIn) + parseFloat($otherIn);
        console.log(totIn);
        $(".txtTotalIncome").val(totIn);
        //$("#ctl00_ContentPlaceHolder1_hidtxtTotalIncome").val(totIn);
        $("#ContentPlaceHolder1_hidtxtTotalIncome").val(totIn);
        calcGP();
        calcPnL();
    }
    
    function calcPurchase() {
        $(".txtTotPurchase").val(0);
        //$("#ctl00_ContentPlaceHolder1_hidtxtTotPurchase").val(0);
        $("#ContentPlaceHolder1_hidtxtTotPurchase").val(0);
        
        $cashIn = $(".txtDCost").val() === '' ? 0.00 : $(".txtDCost").val();
        $creditIn = $(".txtICost").val() === '' ? 0.00 : $(".txtICost").val();
        totPu = 0.00;
        totPu = parseFloat($cashIn) + parseFloat($creditIn);
        console.log('pu: '+totPu);
        $(".txtTotPurchase").val(totPu);
        //$("#ctl00_ContentPlaceHolder1_hidtxtTotPurchase").val(totPu);
        $("#ContentPlaceHolder1_hidtxtTotPurchase").val(totPu);
        
        calcGP();
        calcPnL();
    }
    
    function calcGP(){
//        $(".txtGrossProfit").val(0);
//        $("#ctl00_ContentPlaceHolder1_hidGross").val(0);      
//        gp = parseFloat($("#ctl00_ContentPlaceHolder1_hidtxtTotalIncome").val() === ''?0.00 : $("#ctl00_ContentPlaceHolder1_hidtxtTotalIncome").val()) - parseFloat($("#ctl00_ContentPlaceHolder1_hidtxtTotPurchase").val()===''?0.00:$("#ctl00_ContentPlaceHolder1_hidtxtTotPurchase").val());
//        $("#ct100_ContentPlaceHolder1_hidGross").val(gp);
        
        $("#ContentPlaceHolder1_hidGross").val(0);
        gp = parseFloat($("#ContentPlaceHolder1_hidtxtTotalIncome").val() === ''?0.00 : $("#ContentPlaceHolder1_hidtxtTotalIncome").val()) - parseFloat($("#ContentPlaceHolder1_hidtxtTotPurchase").val()===''?0.00:$("#ContentPlaceHolder1_hidtxtTotPurchase").val());
        console.log('gp: '+gp);
        $(".txtGrossProfit").val(gp);
        $("#ContentPlaceHolder1_hidGross").val(gp);
    }
    
    function calcBEx() {
        $(".txtTExpenses").val(0);
        $Rent = $(".txtRent").val() === '' ? 0.00 : $(".txtRent").val();
        $wet = $(".txtWET").val() === '' ? 0.00 : $(".txtWET").val();
        $wages = $(".txtWages").val() === '' ? 0.00 : $(".txtWages").val(); 
        $fla = $(".txtFLA").val() === '' ? 0.00 : $(".txtFLA").val();
        $trans = $(".txtTravelTrans").val() === '' ? 0.00 : $(".txtTravelTrans").val();
        $repir = $(".txtRepairMain").val() === '' ? 0.00 : $(".txtRepairMain").val();
        

        totEx = parseFloat($Rent) + parseFloat($wet) + parseFloat($wages) + parseFloat($fla) + parseFloat($trans) + parseFloat($repir);
        $(".txtTExpenses").val(totEx);
//        $("#ctl00_ContentPlaceHolder1_hidtxtTExpenses").val(totEx);
        $("#ContentPlaceHolder1_hidtxtTExpenses").val(totEx);
        calcPnL();
    }
    
    function calcPnL() {
        $(".txtPAndL").val(0);
        $pnl = $(".txtGrossProfit").val() - $(".txtTExpenses").val();
        $(".txtPAndL").val($pnl);
//        $("#ct100_ContentPlaceHolder1_hidtxtPAndL").val($pnl);
        $("#ContentPlaceHolder1_hidtxtPAndL").val($pnl);
    }
    
/* ~~ Murabaha Family Details Page ~~*/
    $(function() {
        $('#datetimepicker1').datetimepicker({ format: 'DD/MM/YYYY' });
        $('#sDob').datetimepicker({
            format: 'DD/MM/YYYY'
        }).on('dp.change', function(event) {
            console.log('hi');
            $dob = new Date(event.date);
            $today = new Date();
            $age = Math.floor(($today - $dob) / (365.25 * 24 * 60 * 60 * 1000));
            $(".lblSoAge").html($age);
        });
    });
    
/* ~~ Murabaha Family Appraisals Page ~~*/
    
    
    //calculate monthly net income
    function calcNetIn() { 
        $salWa = $(".txtSalWa").val() === '' ? 0.00 : $(".txtSalWa").val();
        $rentInB = $(".txtRentB").val() === '' ? 0.00 : $(".txtRentB").val();
        $rentInO = $(".txtRentO").val() === '' ? 0.00 : $(".txtRentO").val();
       // $netIn = $("#ctl00_ContentPlaceHolder1_hidNetIn").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_hidNetIn").val();
        $netIn = $("#ContentPlaceHolder1_hidNetIn").val() === '' ? 0.00 : $("#ContentPlaceHolder1_hidNetIn").val();
        $InO = $(".txtInO").val() === '' ? 0.00 : $(".txtInO").val();

        calcTotalAnulaIncome($salWa,$rentInB,$rentInO,$netIn, $InO);
    }
    
    //Calculate Total Annual Family Income
    function calcTotalAnulaIncome($salWa,$rentInB,$rentInO,$netIn, $InO) { 
        $().val()
        $(".txtFamiIn").val(parseFloat($salWa) + parseFloat($rentInB) + parseFloat($rentInO) + parseFloat($netIn)+ parseInt($InO));
        calcNetAnulaIncome();
    }
    function calcMExpenses() {
        $foodEx = $(".txtFood").val() === '' ? 0.00 : $(".txtFood").val();
        $eduEx = $(".txtEdu").val() === '' ? 0.00 : $(".txtEdu").val();
        $wetEx = $(".txtWET").val() === '' ? 0.00 : $(".txtWET").val();
        $hsEx = $(".txtHS").val() === '' ? 0.00 : $(".txtHS").val();
        $rentEx = $(".txtRenPay").val() === '' ? 0.00 : $(".txtRenPay").val();
        $ofaiEx = $(".txtOFAI").val() === '' ? 0.00 : $(".txtOFAI").val();
        $tTranEx = $(".txtTTrans").val() === '' ? 0.00 : $(".txtTTrans").val();
        $clothEx = $(".txtCloths").val() === '' ? 0.00 : $(".txtCloths").val();
        $otherEx = $(".txtOthers").val() === '' ? 0.00 : $(".txtOthers").val();
        
        $total = parseFloat($foodEx)+parseFloat($eduEx)+parseFloat($wetEx)+parseFloat($hsEx)+parseFloat($rentEx)+parseFloat($ofaiEx)+parseFloat($tTranEx)+parseFloat($clothEx)+parseFloat($otherEx);
        
        console.log($total);
        $(".txtFExpense").val($total);
        calcNetAnulaIncome();
    }
    function calcNetAnulaIncome(){
        $famiIn = $(".txtFamiIn").val() === '' ? 0.00 : $(".txtFamiIn").val();
        $otherEx = $(".txtFExpense").val() === '' ? 0.00 : $(".txtFExpense").val();
        console.log($famiIn);
        console.log($otherEx);
        $(".txtNetAnualFIN").val((parseFloat($famiIn) - parseFloat($otherEx)).toFixed(2));
        $(".txtAmountOPEx").val((parseFloat($(".txtNetAnualFIN").val())/12).toFixed(2));
        $(".txtAmountFEx").val((((parseFloat($(".txtNetAnualFIN").val())/12)*40)/100).toFixed(2));
        $(".txtAmountOPEx").prop('readonly', true);
        $(".txtAmountFEx").prop('readonly', true);
        calcMaxAmountCanBeDisbursed();
    }
    
    function calcMaxAmountCanBeDisbursed(){
        $(".txtMAD").val(($(".txtAmountFEx").val()* $('.txtFRPriod').val()).toFixed(2));
        $(".txtMAD").prop('readonly', true);
    };
    
    function calcMarkup(){
        var FA = $(".loanAmount").val(); //Facility Amount
        var IV = $(".invoiceVal").val(); //Invoice Value
        var IR = $(".interest").val(); //Interest rate
        var P = $(".period").val(); //Period
        if(IV > FA)
            $(".downpayment").val(IV - FA); //Down payment
        else 
            $(".downpayment").val("0.00");

        var AM = parseFloat((FA*IR)/100);//Calculate annual Markup amount
        var MM = parseFloat(AM/12);//Calculate monthly Markup amount
        var MC = parseFloat(FA/P) //Calculate monthly capital amount
          
        $('.interestAmount').val((MM).toFixed(2));
        $('.capitalPortion').val((MC).toFixed(2));
        $('.monthInstall').val((MC+MM).toFixed(2));
        var A = parseFloat($('.txtLDSerCharges').val());
        var B = parseFloat($('.txtWalfareFee').val());
        var C = parseFloat($('.txtRegistrationFee').val());
        var D = parseFloat($('.txtLDOtherCharg').val());
        var E = parseFloat($('.downpayment').val());
        $('.RTotal').val((A+B+C+D+E+((MC+MM)*P)).toFixed(2));
    }

//    
    /************************************************************************************/
    /************************************************************************************/
    /************************************************************************************/
    
//TESTING SITE
    
///* ~~ Other Family details date time fields ~~ */
//function calcUnitCost(unitCost, count, costId){
//    alert('cost :'+unitCost+' - count:'+count+' id:'+costId);
//    costId.val(parseFloat(unitCost)*parent(count));
//}
//$(function(){
//    $("#ctl00_ContentPlaceHolder1_txtUnitCost").on('change', function(){
//        calcUnitCost($(this).val(),$("#ctl00_ContentPlaceHolder1_txtNoOfUnits").val(),$("#ctl00_ContentPlaceHolder1_txtTotalCost"));
//    })
//    $("#ctl00_ContentPlaceHolder1_txtNoOfUnits").on('change', function(){
//        calcUnitCost($("#ctl00_ContentPlaceHolder1_txtUnitCost").val(),$(this).val(),$("#ctl00_ContentPlaceHolder1_txtTotalCost"));
//    })
//    
//});

///* ~~ Other Family details date time fields ~~ */
//$(function(){
//    for(var i = 1; i<=9;i++)
//        $('#DobCDB'+i).datetimepicker({ format: 'DD/MM/YYYY' });
//});

//if($('#DobCDB').val() != "")
//{
//    $dob = new Date($('#DobCDB').val());
//    $today = new Date();
//    $age = Math.floor(($today - $dob) / (365.25 * 24 * 60 * 60 * 1000));
//    $(".lblAge").html($age);
//}

//if($('#sDob').val() != "")
//{
//    $dob = new Date($('#sDob').val());
//    $today = new Date();
//    $age = Math.floor(($today - $dob) / (365.25 * 24 * 60 * 60 * 1000));
//    $(".lblSoAge").html($age);
//}

///* ~~ Murabaha basic details page ~~ */
//$(function() {
//    $('#DobCDB').datetimepicker({
//        format: 'DD/MM/YYYY',
//        //defaultDate: new Date()
//    }).on('dp.change', function(event) {
//        $dob = new Date(event.date);
//        $today = new Date();
//        $age = Math.floor(($today - $dob) / (365.25 * 24 * 60 * 60 * 1000));
//        $(".lblAge").html($age);
//    });

//    $('#InspectionCDB').datetimepicker({ format: 'DD/MM/YYYY' });
//    $('#dtpNicPassIssueDateCBD').datetimepicker({ format: 'DD/MM/YYYY' });
//});

///* ~~ business details page ~~ */
//var totIn = 0.00; var totPu = 0.00; var totEx = 0.00; var gp = 0.00;
//    function calcIncom() {
//        $(".txtTotalIncome").val(0);
//        $("#ctl00_ContentPlaceHolder1_hidtxtTotalIncome").val(0);
//        $cashIn = $(".txtBIncome").val() === '' ? 0.00 : $(".txtBIncome").val();
//        $creditIn = $(".txtCrdtIncome").val() === '' ? 0.00 : $(".txtCrdtIncome").val();
//        $otherIn = $(".txtOIncome").val() === '' ? 0.00 : $(".txtOIncome").val();

//        totIn = parseFloat($cashIn) + parseFloat($creditIn) + parseFloat($otherIn);
//        console.log(totIn);
//        $(".txtTotalIncome").val(totIn);
//        $("#ctl00_ContentPlaceHolder1_hidtxtTotalIncome").val(totIn);
//        calcGP();
//        calcPnL();
//    }
//    
//    function calcPurchase() {
//        $(".txtTotPurchase").val(0);
//        $("#ctl00_ContentPlaceHolder1_hidtxtTotPurchase").val(0);
//        
//        $cashIn = $(".txtDCost").val() === '' ? 0.00 : $(".txtDCost").val();
//        $creditIn = $(".txtICost").val() === '' ? 0.00 : $(".txtICost").val();
//        totPu = 0.00;
//        totPu = parseFloat($cashIn) + parseFloat($creditIn);
//        console.log('pu: '+totPu);
//        $(".txtTotPurchase").val(totPu);
//        $("#ctl00_ContentPlaceHolder1_hidtxtTotPurchase").val(totPu);
//        
//        calcGP();
//        calcPnL();
//    }
//    
//    function calcGP(){
//        $(".txtGrossProfit").val(0);
//        $("#ctl00_ContentPlaceHolder1_hidGross").val(0);      
//        gp = parseFloat($("#ctl00_ContentPlaceHolder1_hidtxtTotalIncome").val() === ''?0.00 : $("#ctl00_ContentPlaceHolder1_hidtxtTotalIncome").val()) - parseFloat($("#ctl00_ContentPlaceHolder1_hidtxtTotPurchase").val()===''?0.00:$("#ctl00_ContentPlaceHolder1_hidtxtTotPurchase").val());
//        console.log('gp: '+gp);
//        $(".txtGrossProfit").val(gp);
//        $("#ct100_ContentPlaceHolder1_hidGross").val(gp);
//    }
//    
//    function calcBEx() {
//        $(".txtTExpenses").val(0);
//        $Rent = $(".txtRent").val() === '' ? 0.00 : $(".txtRent").val();
//        $wet = $(".txtWET").val() === '' ? 0.00 : $(".txtWET").val();
//        $wages = $(".txtWages").val() === '' ? 0.00 : $(".txtWages").val(); 
//        $fla = $(".txtFLA").val() === '' ? 0.00 : $(".txtFLA").val();
//        $trans = $(".txtTravelTrans").val() === '' ? 0.00 : $(".txtTravelTrans").val();
//        $repir = $(".txtRepairMain").val() === '' ? 0.00 : $(".txtRepairMain").val();
//        

//        totEx = parseFloat($Rent) + parseFloat($wet) + parseFloat($wages) + parseFloat($fla) + parseFloat($trans) + parseFloat($repir);
//        $(".txtTExpenses").val(totEx);
//        $("#ctl00_ContentPlaceHolder1_hidtxtTExpenses").val(totEx);
//        calcPnL();
//    }
//    
//    function calcPnL() {
//        $(".txtPAndL").val(0);
//        $pnl = $(".txtGrossProfit").val() - $(".txtTExpenses").val();
//        $(".txtPAndL").val($pnl);
//        $("#ct100_ContentPlaceHolder1_hidtxtPAndL").val($pnl);
//    }
//    
///* ~~ Murabaha Family Details Page ~~*/
//    $(function() {
//        $('#datetimepicker1').datetimepicker({ format: 'DD/MM/YYYY' });
//        $('#sDob').datetimepicker({
//            format: 'DD/MM/YYYY'
//        }).on('dp.change', function(event) {
//            console.log('hi');
//            $dob = new Date(event.date);
//            $today = new Date();
//            $age = Math.floor(($today - $dob) / (365.25 * 24 * 60 * 60 * 1000));
//            $(".lblSoAge").html($age);
//        });
//    });
//    
///* ~~ Murabaha Family Appraisals Page ~~*/
//    
//    
//    //calculate monthly net income
//    function calcNetIn() { 
//        $salWa = $(".txtSalWa").val() === '' ? 0.00 : $(".txtSalWa").val();
//        $rentInB = $(".txtRentB").val() === '' ? 0.00 : $(".txtRentB").val();
//        $rentInO = $(".txtRentO").val() === '' ? 0.00 : $(".txtRentO").val();
//        $netIn = $("#ctl00_ContentPlaceHolder1_hidNetIn").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_hidNetIn").val();
//        $InO = $(".txtInO").val() === '' ? 0.00 : $(".txtInO").val();

//        calcTotalAnulaIncome($salWa,$rentInB,$rentInO,$netIn, $InO);
//    }
//    
//    //Calculate Total Annual Family Income
//    function calcTotalAnulaIncome($salWa,$rentInB,$rentInO,$netIn, $InO) { 
//        $().val()
//        $(".txtFamiIn").val(parseFloat($salWa) + parseFloat($rentInB) + parseFloat($rentInO) + parseFloat($netIn)+ parseInt($InO));
//        calcNetAnulaIncome();
//    }
//    function calcMExpenses() {
//        $foodEx = $(".txtFood").val() === '' ? 0.00 : $(".txtFood").val();
//        $eduEx = $(".txtEdu").val() === '' ? 0.00 : $(".txtEdu").val();
//        $wetEx = $(".txtWET").val() === '' ? 0.00 : $(".txtWET").val();
//        $hsEx = $(".txtHS").val() === '' ? 0.00 : $(".txtHS").val();
//        $rentEx = $(".txtRenPay").val() === '' ? 0.00 : $(".txtRenPay").val();
//        $ofaiEx = $(".txtOFAI").val() === '' ? 0.00 : $(".txtOFAI").val();
//        $tTranEx = $(".txtTTrans").val() === '' ? 0.00 : $(".txtTTrans").val();
//        $clothEx = $(".txtCloths").val() === '' ? 0.00 : $(".txtCloths").val();
//        $otherEx = $(".txtOthers").val() === '' ? 0.00 : $(".txtOthers").val();
//        
//        $total = parseFloat($foodEx)+parseFloat($eduEx)+parseFloat($wetEx)+parseFloat($hsEx)+parseFloat($rentEx)+parseFloat($ofaiEx)+parseFloat($tTranEx)+parseFloat($clothEx)+parseFloat($otherEx);
//        
//        console.log($total);
//        $(".txtFExpense").val($total);
//        calcNetAnulaIncome();
//    }
//    function calcNetAnulaIncome(){
//        $famiIn = $(".txtFamiIn").val() === '' ? 0.00 : $(".txtFamiIn").val();
//        $otherEx = $(".txtFExpense").val() === '' ? 0.00 : $(".txtFExpense").val();
//        console.log($famiIn);
//        console.log($otherEx);
//        $(".txtNetAnualFIN").val((parseFloat($famiIn) - parseFloat($otherEx)).toFixed(2));
//        $(".txtAmountOPEx").val((parseFloat($(".txtNetAnualFIN").val())/12).toFixed(2));
//        $(".txtAmountFEx").val((((parseFloat($(".txtNetAnualFIN").val())/12)*40)/100).toFixed(2));
//        $(".txtAmountOPEx").prop('readonly', true);
//        $(".txtAmountFEx").prop('readonly', true);
//        calcMaxAmountCanBeDisbursed();
//    }
//    
//    function calcMaxAmountCanBeDisbursed(){
//        $(".txtMAD").val(($(".txtAmountFEx").val()* $('.txtFRPriod').val()).toFixed(2));
//        $(".txtMAD").prop('readonly', true);
//    };
//    
//    function calcMarkup(){
//        var FA = $(".loanAmount").val(); //Facility Amount
//        var IV = $(".invoiceVal").val(); //Invoice Value
//        var IR = $(".interest").val(); //Interest rate
//        var P = $(".period").val(); //Period
//        if(IV > FA)
//            $(".downpayment").val(IV - FA); //Down payment
//        else 
//            $(".downpayment").val("0.00");

//        var AM = parseFloat((FA*IR)/100);//Calculate annual Markup amount
//        var MM = parseFloat(AM/12);//Calculate monthly Markup amount
//        var MC = parseFloat(FA/P) //Calculate monthly capital amount
//          
//        $('.interestAmount').val((MM).toFixed(2));
//        $('.capitalPortion').val((MC).toFixed(2));
//        $('.monthInstall').val((MC+MM).toFixed(2));
//        var A = parseFloat($('.txtLDSerCharges').val());
//        var B = parseFloat($('.txtWalfareFee').val());
//        var C = parseFloat($('.txtRegistrationFee').val());
//        var D = parseFloat($('.txtLDOtherCharg').val());
//        $('.RTotal').val((A+B+C+D+((MC+MM)*P)).toFixed(2));
//    }