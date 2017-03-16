/* ~~ Murabaha basic details page ~~ */
$(function() {
    $('#DobCDB').datetimepicker({
        format: 'DD/MM/YYYY',
        defaultDate: new Date()
    }).on('dp.change', function(event) {
        $dob = new Date(event.date);
        $today = new Date();
        $age = Math.floor(($today - $dob) / (365.25 * 24 * 60 * 60 * 1000));
        console.log($dob);
        console.log($today);
        console.log($age);
        $(".lblAge").html($age);
    });

    $('#InspectionCDB').datetimepicker({ format: 'DD/MM/YYYY' });
    $('#dtpNicPassIssueDateCBD').datetimepicker({ format: 'DD/MM/YYYY' });
});

/* ~~ Murabaha business details page ~~ */
var totIn = 0.00; var totPu = 0.00; var totEx = 0.00;
    function calcIncom() {
        $cashIn = $(".txtBIncome").val() === '' ? 0.00 : $(".txtBIncome").val();
        $creditIn = $(".txtCrdtIncome").val() === '' ? 0.00 : $(".txtCrdtIncome").val();
        $otherIn = $(".txtOIncome").val() === '' ? 0.00 : $(".txtOIncome").val();

        totIn = parseFloat($cashIn) + parseFloat($creditIn) + parseFloat($otherIn);
        $(".txtTotalIncome").val(totIn);
        calcPnL(totIn, totPu, totEx);
    }
    
    function calcPurchase() {
        $cashIn = $(".txtDCost").val() === '' ? 0.00 : $(".txtDCost").val();
        $creditIn = $(".txtICost").val() === '' ? 0.00 : $(".txtICost").val();

        totPu = parseFloat($cashIn) + parseFloat($creditIn);
        $(".txtTotPurchase").val(totPu);
        calcPnL(totIn, totPu, totEx);
    }
    
    function calcBEx() {
        $Rent = $(".txtRent").val() === '' ? 0.00 : $(".txtRent").val();
        $wet = $(".txtWET").val() === '' ? 0.00 : $(".txtWET").val();
        $wages = $(".txtWages").val() === '' ? 0.00 : $(".txtWages").val(); 
        $fla = $(".txtFLA").val() === '' ? 0.00 : $(".txtFLA").val();
        $trans = $(".txtTravelTrans").val() === '' ? 0.00 : $(".txtICost").val();
        $repir = $(".txtRepairMain").val() === '' ? 0.00 : $(".txtRepairMain").val();

        totEx = parseFloat($Rent) + parseFloat($wet) + parseFloat($wages) + parseFloat($fla) + parseFloat($trans) + parseFloat($repir);
        $(".txtTExpenses").val(totEx);
        calcPnL(totIn, totPu, totEx);
    }
    
    function calcPnL(totIn, totPu, totEx) {
        totIn = totIn === '' ? 0.00 : totIn;
        totPu = totPu === '' ? 0.00 : totPu;
        totEx = totEx === '' ? 0.00 : totEx;
        console.log("totIn  " + totIn + " totPU " + totPu + " totEx " + totEx);
        $pnl = totIn - (totPu + totEx);
        //console.log($pnl);
        $(".txtPAndL").val($pnl);
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
            console.log($dob);
            console.log($today);
            console.log($age);
            $(".lblAge").html($age);
        });
    });
    
/* ~~ Murabaha Family Appraisals Page ~~*/
    
    

    function calcNetIn() { //calculate monthly net income
        $salWa = $(".txtSalWa").val() === '' ? 0.00 : $(".txtSalWa").val();
        $rentInB = $(".txtRentB").val() === '' ? 0.00 : $(".txtRentB").val();
        $rentInO = $(".txtRentO").val() === '' ? 0.00 : $(".txtRentO").val();

        $(".txtNetIn").val(parseFloat($salWa) + parseFloat($rentInB) + parseFloat($rentInO));
        calcMBI();
    }
    function calcMBI() { 
        $InO = $(".txtInO").val() === '' ? 0.00 : $(".txtInO").val();
        $netIn = $(".txtNetIn").val() === '' ? 0.00 : $(".txtNetIn").val();

        $(".txtFamiIn").val(parseFloat($InO) + parseFloat($netIn));
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

        $total = parseFloat($foodEx) + parseFloat($eduEx) + parseFloat($wetEx) + parseFloat($hsEx) + parseFloat($rentEx) + parseFloat($ofaiEx) + parseFloat($tTranEx) + parseFloat($clothEx) + parseFloat($otherEx)

        $(".txtFExpense").val($total);
        calcNetAnulaIncome();
    }
    function calcNetAnulaIncome(){
        $famiIn = $(".txtFamiIn").val() === '' ? 0.00 : $(".txtFamiIn").val();
        $otherEx = $(".txtFExpense").val() === '' ? 0.00 : $(".txtFExpense").val();
        $(".txtNetAnualFIN").val((parseFloat($famiIn) - parseFloat($otherEx)).toFixed(2));
        $(".txtAmountOPEx").val((parseFloat($(".txtNetAnualFIN").val())/12).toFixed(2));
        $(".txtAmountFEx").val((((parseFloat($(".txtNetAnualFIN").val())/12)*40)/100).toFixed(2));
        $(".txtAmountOPEx").prop('readonly', true);
        $(".txtAmountFEx").prop('readonly', true);
    }
    
    function calcMaxAmountCanBeDisbursed(){
        $(".txtMAD").val(($(".txtAmountFEx").val()* $('.txtFRPriod').val()).toFixed(2));
        $(".txtMAD").prop('readonly', true);
    };