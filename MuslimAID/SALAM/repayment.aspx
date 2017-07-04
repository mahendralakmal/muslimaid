<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true"
    CodeBehind="repayment.aspx.cs" Inherits="MuslimAID.SALAM.repayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
/*~~ SALAM repament ~~*/
$(document).ready(function(){
    function checkVariety(minPrice, maxPrice){
        var lblDetailsInSource1 = $("#ctl00_ContentPlaceHolder1_lblDetailsInSource1");
        
        lblDetailsInSource1.html("");
        if(minPrice > maxPrice){
            lblDetailsInSource1.css("color","red");
            lblDetailsInSource1.html("Variety 1 cannot be greater than Variety Two");
            $(".minPriceExp").focus();
            return false;
        }
        else {
            $(".minPriceExp").val(minPrice);
            $(".minPriceExp").prop("disabled", true);
            
            $(".maxPriceExp").val(maxPrice);
            $(".expUnitPrice").val(maxPrice);
            $(".maxPriceExp").prop("disabled", true);
            $(".expUnitPrice").prop("disabled", true);
            return true
        };
    }
    
    $(".VarietyOne").on('change', function(){
        checkVariety($(this).val(), ($('.VarietyTwo').val() === '')?0:$('.VarietyTwo').val());
    });
    
    $(".VarietyTwo").on('change', function(){
        checkVariety(($('.VarietyOne').val() === '')? 0:$('.VarietyOne').val(), $(this).val());
    });
    
    $(".txtHarvestTotal").on('change', function(){
        $(".txtNumberOfUnits").val($(this).val());
        $(".txtNumberOfUnits").prop("disabled", true);
    }); 
    
    $(".txtHarvestPeriod").on('change', function(){
        $(".period").val($(this).val());
        $(".period").prop("disabled", true);
    }); 
    
    $(".txtAgreedPrice").on('change', function(){
        var lblSellingOpt = $("#ctl00_ContentPlaceHolder1_lblSellingOpt");
        if($(this).val() === ''){
            lblSellingOpt.css("color","red");
            lblSellingOpt.html("Place of selling - Option 01 Agreed Price cannot be empty.");
            $(".txtAgreedPrice").focus();
        }
    });
    
    $(".txtAgreedPrice2").on('change', function(){
        var lblSellingOpt = $("#ctl00_ContentPlaceHolder1_lblSellingOpt");
        if($(this).val() === ''){
            lblSellingOpt.css("color","red");
            lblSellingOpt.html("Place of selling - Option 02 Agreed Price cannot be empty.");
            $(".txtAgreedPrice2").focus();
        }
    }); 
        
    $(".rate").on('change', function(){
        //calculatete for period
        $(".rateForPeriod").val(($(".rate").val()/12)*($(".period").val()));
        //Calculate expected profit
        $(".expProfit").val($(".loanamount").val()*$(".rateForPeriod").val()/100);
        
        $(".rateForPeriod").prop("disabled", true);
        $(".expProfit").prop("disabled", true);        
    });
    //Expected Units
    $(".expSellingPrice").on('change', function(){
        $(".expUnits").val($(".expSellingPrice").val()/$(".expUnitPrice").val());
    });
});
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle">
            <h4>
                Salam - Repayment</h4>
        </div>
        <div class="col-md-12 form-container">
            <div class="PageTitle">
                <h4> Business / Income Generational Activity Details </h4><hr/>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="col-md-5">
                            Facility Code<span style="color: Red;"> *</span></div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtCC" MaxLength="15" CssClass="form-control" runat="server" TabIndex="0" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">&nbsp;</div>
                <%--
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="col-md-5">
                            CA Code<span style="color: Red;"> *</span></div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtCACode" MaxLength="12" CssClass="form-control" runat="server"
                                TabIndex="0"></asp:TextBox>
                        </div>
                    </div>
                </div>
                --%>
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="col-md-5">
                            Financial Amount<span style="color: Red;"> *</span></div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtFinancialAmount" MaxLength="12" CssClass="form-control loanamount numbersOnly" runat="server"
                                TabIndex="0"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
            <div class="col-md-12">
                <div class="form-group">
                    <div class="col-md-5">
                        Income Source (1)<span style="color: Red;"> *</span> : Income Generation activity
                        – Salam facility to be utilized</div>
                    <div class="col-md-7 form-group">
                        <div class="col-md-4">
                            <asp:DropDownList ID="cmbIncomeSource1_a" CssClass="form-control" TabIndex="1" 
                                runat="server" AutoPostBack="true" 
                                onselectedindexchanged="cmbIncomeSource1_a_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div> 
                        <div class="col-md-4">
                            <asp:DropDownList ID="cmbIncomeSource1_b" CssClass="form-control" TabIndex="1" runat="server" AutoPostBack="true" onselectedindexchanged="cmbIncomeSource1_b_SelectedIndexChanged">
                                <asp:ListItem Text="~~Select~~" Value="c0" />
                            
                            </asp:DropDownList>
                        </div> 
                        <div class="col-md-4">
                            <asp:DropDownList ID="cmbIncomeSource1_c" CssClass="form-control" TabIndex="1" runat="server">
                                <asp:ListItem Text="~~Select~~" Value="c0" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <div class="col-md-5">
                        Income Source (2)<span style="color: Red;"> *</span> : Income Generation activity
                        – Secondary</div>
                    <div class="col-md-7 form-group">
                        <div class="col-md-4">
                            <asp:DropDownList ID="cmbIncomeSource2_a" CssClass="form-control" TabIndex="1" 
                                runat="server" AutoPostBack="true" 
                                onselectedindexchanged="cmbIncomeSource2_a_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div> 
                        <div class="col-md-4">
                            <asp:DropDownList ID="cmbIncomeSource2_b" CssClass="form-control" TabIndex="1" runat="server"
                                AutoPostBack="true" 
                                onselectedindexchanged="cmbIncomeSource2_b_SelectedIndexChanged">
                                <asp:ListItem Text="~~Select~~" Value="b0" />
                            </asp:DropDownList>
                        </div> 
                        <div class="col-md-4">
                            <asp:DropDownList ID="cmbIncomeSource2_c" CssClass="form-control" TabIndex="1" runat="server">
                                <asp:ListItem Text="~~Select~~" Value="b0" />                                
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            </div>
            <br />
            <div class="PageTitle">
                <h4>
                    Details of Income Source 1<hr />
                </h4>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-5">
                                Area of Cultivation / Farming (Acres)<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtCultivation_Farming" MaxLength="12" CssClass="form-control numbersOnly" runat="server" TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-5">
                                Experience in Years<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtExperienceInYears" MaxLength="12" CssClass="form-control numbersOnly" runat="server"
                                    TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-5">
                                Harvest – Total<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtHarvestTotal" MaxLength="12" CssClass="form-control txtHarvestTotal numbersOnly" runat="server"
                                    TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-5">
                                No of Seasons in a Year<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtSeasonsInYear" MaxLength="12" CssClass="form-control numbersOnly" runat="server"
                                    TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-5">
                                Type of Variety 1<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtVariety1" MaxLength="12" CssClass="form-control numbersOnly VarietyOne" runat="server" TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-5">
                                Type of Variety 2<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtVariety2" MaxLength="12" CssClass="form-control numbersOnly VarietyTwo" runat="server" TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-5">
                                Harvest Period<span style="color: Red;"> *</span></div>
                            <div class="col-md-5">
                                <asp:TextBox ID="txtHarvestPeriod" MaxLength="12" CssClass="form-control txtHarvestPeriod numbersOnly" runat="server" TabIndex="0"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <span style="color: Black;">Months</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <hr />
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-5">
                                Rain Water<span style="color: Red;"> *</span></div>
                            <div class="col-md-7 form-group">
                                <asp:RadioButton ID="rdoRW_Y" Text="Yes  " runat="server" TabIndex="10" GroupName="rdoRainWater" />
                                <asp:RadioButton ID="rdoRW_N" Text="No" runat="server" TabIndex="11" GroupName="rdoRainWater" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-5">
                                Irrigation Water<span style="color: Red;"> *</span></div>
                            <div class="col-md-7 form-group">
                                <asp:RadioButton ID="rdoIW_Y" Text="Yes  " runat="server" TabIndex="10" GroupName="rdoIrrigationWater" />
                                <asp:RadioButton ID="rdoIW_N" Text="No" runat="server" TabIndex="11" GroupName="rdoIrrigationWater" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-5">
                                Both<span style="color: Red;"> *</span></div>
                            <div class="col-md-7 form-group">
                                <asp:RadioButton ID="rdoB_Y" Text="Yes  " runat="server" TabIndex="10" GroupName="rdoBoth" />
                                <asp:RadioButton ID="rdoB_N" Text="No" runat="server" TabIndex="11" GroupName="rdoBoth" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-5">
                                Minimum Price Expected<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtMinimumPriceExpected" MaxLength="12" CssClass="form-control numbersOnly minPriceExp" runat="server" TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-5">
                                Maximum Price Expected<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtMaximumPriceExpected" MaxLength="12" CssClass="form-control numbersOnly maxPriceExp" runat="server" TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Label ID="lblDetailsInSource1" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="PageTitle">
                <h5>
                    Details of Repayment<hr />
                </h5>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="col-md-5">
                            Type of product<span style="color: Red;"> *</span></div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtTypeOfProducts" CssClass="form-control"
                                    runat="server" TabIndex="0"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="col-md-5">
                            Units<span style="color: Red;"> *</span></div>
                        <div class="col-md-7">
                            <asp:DropDownList ID="cmbUnits" CssClass="form-control units" TabIndex="1" runat="server">
                                <asp:ListItem Text="---Select---" Value="b0" />
                                <asp:ListItem Text="Kg" Value="1" />
                                <asp:ListItem Text="Peaces" Value="2" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="col-md-5">
                            Number of units<span style="color: Red;"> *</span></div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtNumberOfUnits" CssClass="form-control txtNumberOfUnits"
                                    runat="server" TabIndex="0"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="col-md-5">
                            Repayment Period<span style="color: Red;"> *</span></div>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPeriodRepayment" MaxLength="12" CssClass="form-control period numbersOnly" runat="server"
                                TabIndex="0"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <span style="color: Black;">Months</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                            <div class="col-md-5">
                                Condition/ Quality Expected<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtQualityExpected" CssClass="form-control expUnitPrice numbersOnly"
                                    runat="server" TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="PageTitle"><h5>Possible Selling Options<hr /></h5></div>
                <div class="col-md-12"><strong>Place of selling - Option 01</strong></div>
                <div class="col-md-10">
                    <div class="form-group">
                        <div class="col-md-3">Agreed Price (Rs) <span style="color: Red;"> *</span></div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtAgreedPrice" MaxLength="12" CssClass="form-control txtAgreedPrice numbersOnly" runat="server"></asp:TextBox></div>
                        <div class="col-md-1">Discussed</div>
                        <div class="col-md-2">
                            <asp:RadioButton GroupName="rdoSellingOpt1" ID="rdoSellingOpt1Yes" runat="server" Text="Yes " Checked />&nbsp;&nbsp;   
                            <asp:RadioButton GroupName="rdoSellingOpt1" ID="rdoSellingOpt1No" runat="server" Text="No" />
                        </div>
                    </div>
                </div>
                <div class="col-md-12"><strong>Place of selling - Option 02</strong></div>
                <div class="col-md-10">
                    <div class="form-group">
                        <div class="col-md-3">Agreed Price (Rs) <span style="color: Red;"> *</span></div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtAgreedPrice2" MaxLength="12" CssClass="form-control txtAgreedPrice2 numbersOnly" runat="server"></asp:TextBox></div>
                        <div class="col-md-1">Discussed</div>
                        <div class="col-md-2">
                            <asp:RadioButton GroupName="rdoSellingOpt2" ID="rdoSellingOpt2Yes" runat="server" Text="Yes " Checked />&nbsp;&nbsp;   
                            <asp:RadioButton GroupName="rdoSellingOpt2" ID="rdoSellingOpt2No" runat="server" Text="No" />
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Label ID="lblSellingOpt" runat="server" ></asp:Label>
                </div>
            </div>
            
            <div class="col-md-12">
                <div class="PageTitle"><h5>General<hr /></h5></div>
                <div class="col-md-10">
                    <div class="form-group">
                        <div class="col-md-5">Client is associated with Farmer Association </div>                        
                        <div class="col-md-2">
                            <asp:RadioButton GroupName="rdoGeneral1" ID="rdoGeneral1Yes" runat="server" Text="Yes " Checked />&nbsp;&nbsp;   
                            <asp:RadioButton GroupName="rdoGeneral1" ID="rdoGeneral1No" runat="server" Text="No" />
                        </div>
                    </div>
                </div>
                <div class="col-md-10">
                    <div class="form-group">
                        <div class="col-md-5">Any Insurance for the cultivation / Farming</div>                        
                        <div class="col-md-2">
                            <asp:RadioButton GroupName="rdoGeneral2" ID="rdoGeneral2Yes" runat="server" Text="Yes " Checked />&nbsp;&nbsp;   
                            <asp:RadioButton GroupName="rdoGeneral2" ID="rdoGeneral2No" runat="server" Text="No" />
                        </div>
                    </div>
                </div>
                <div class="col-md-10">
                    <div class="form-group">
                        <div class="col-md-3">If Yes - Insurer and Details</div>                        
                        <div class="col-md-6">
                            <asp:TextBox ID="txtInsurerDetails" runat="server" CssClass="form-control" 
                                Height="100px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            
            
            <div class="col-md-12">
                <div class="PageTitle"><h5>Details of Assets<hr /></h5></div>
                <div class="col-md-12">
                    <div class="form-group">
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <td>No</td>
                                    <td>Type Of The Asset</td>
                                    <td>Value</td>
                                    <td>Source</td>
                                    <td>Status</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td><asp:DropDownList runat="server" ID="cmbAssetType1" CssClass="form-control">
                                        <asp:ListItem Value="L" Text="Land"></asp:ListItem>
                                        <asp:ListItem Value="H" Text="House"></asp:ListItem>
                                        <asp:ListItem Value="M" Text="Machine"></asp:ListItem>
                                        <asp:ListItem Value="V" Text="Vehical"></asp:ListItem>
                                        <asp:ListItem Value="S" Text="Live Stock"></asp:ListItem>
                                        <asp:ListItem Value="O" Text="Other"></asp:ListItem>                                        
                                    </asp:DropDownList></td>
                                    <td><asp:TextBox runat="server" ID="txtValue1" CssClass="form-control"></asp:TextBox></td>
                                    <td>
                                        <asp:RadioButton ID="rdoOther1" runat="server" GroupName="incomeSource1" Text="Other" />
                                        <asp:RadioButton ID="rdoGift1" runat="server" GroupName="incomeSource1" Text="Gift" />
                                        <asp:RadioButton ID="rdoIncome1" runat="server" GroupName="incomeSource1" Text="Income" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="rdoF1" runat="server" GroupName="statusIn1" Text="Fully Functioning"/>
                                        <asp:RadioButton ID="rdoP1" runat="server" GroupName="statusIn1" Text="Partial Functioning"/>
                                        <asp:RadioButton ID="RdoI1" runat="server" GroupName="statusIn1" Text="Inactive" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td><asp:DropDownList runat="server" ID="cmbAssetType2" CssClass="form-control">
                                        <asp:ListItem Value="L" Text="Land"></asp:ListItem>
                                        <asp:ListItem Value="H" Text="House"></asp:ListItem>
                                        <asp:ListItem Value="M" Text="Machine"></asp:ListItem>
                                        <asp:ListItem Value="V" Text="Vehical"></asp:ListItem>
                                        <asp:ListItem Value="S" Text="Live Stock"></asp:ListItem>
                                        <asp:ListItem Value="O" Text="Other"></asp:ListItem>
                                    </asp:DropDownList></td>
                                    <td><asp:TextBox runat="server" ID="txtValue2" CssClass="form-control"></asp:TextBox></td>
                                    <td>
                                        <asp:RadioButton ID="rdoOther2" runat="server" GroupName="incomeSource2" Text="Other" />
                                        <asp:RadioButton ID="rdoGift2" runat="server" GroupName="incomeSource2" Text="Gift" />
                                        <asp:RadioButton ID="rdoIncome2" runat="server" GroupName="incomeSource2" Text="Income" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="rdoF2" runat="server" GroupName="statusIn2" Text="Fully Functioning"/>
                                        <asp:RadioButton ID="rdoP2" runat="server" GroupName="statusIn2" Text="Partial Functioning"/>
                                        <asp:RadioButton ID="rdoI2" runat="server" GroupName="statusIn2" Text="Inactive" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>3</td>
                                    <td><asp:DropDownList runat="server" ID="cmbAssetType3" CssClass="form-control">
                                    <asp:ListItem Value="L" Text="Land"></asp:ListItem>
                                        <asp:ListItem Value="H" Text="House"></asp:ListItem>
                                        <asp:ListItem Value="M" Text="Machine"></asp:ListItem>
                                        <asp:ListItem Value="V" Text="Vehical"></asp:ListItem>
                                        <asp:ListItem Value="S" Text="Live Stock"></asp:ListItem>
                                        <asp:ListItem Value="O" Text="Other"></asp:ListItem>
                                    </asp:DropDownList></td>
                                    <td><asp:TextBox runat="server" ID="txtValue3" CssClass="form-control"></asp:TextBox></td>
                                    <td>
                                        <asp:RadioButton ID="rdoOther3" runat="server" GroupName="incomeSource3" Text="Other" />
                                        <asp:RadioButton ID="rdoGift3" runat="server" GroupName="incomeSource3" Text="Gift" />
                                        <asp:RadioButton ID="rdoIncome3" runat="server" GroupName="incomeSource3" Text="Income" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="rdoF3" runat="server" GroupName="statusIn3" Text="Fully Functioning"/>
                                        <asp:RadioButton ID="rdoP3" runat="server" GroupName="statusIn3" Text="Partial Functioning"/>
                                        <asp:RadioButton ID="rdoI3" runat="server" GroupName="statusIn3" Text="Inactive" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>4</td>
                                    <td><asp:DropDownList runat="server" ID="cmbAssetType4" CssClass="form-control">
                                        <asp:ListItem Value="L" Text="Land"></asp:ListItem>
                                        <asp:ListItem Value="H" Text="House"></asp:ListItem>
                                        <asp:ListItem Value="M" Text="Machine"></asp:ListItem>
                                        <asp:ListItem Value="V" Text="Vehical"></asp:ListItem>
                                        <asp:ListItem Value="S" Text="Live Stock"></asp:ListItem>
                                        <asp:ListItem Value="O" Text="Other"></asp:ListItem>
                                    </asp:DropDownList></td>
                                    <td><asp:TextBox runat="server" ID="txtValue4" CssClass="form-control"></asp:TextBox></td>
                                    <td>
                                        <asp:RadioButton ID="rdoOther4" runat="server" GroupName="incomeSource4" Text="Other" />
                                        <asp:RadioButton ID="rdoGif4" runat="server" GroupName="incomeSource4" Text="Gift" />
                                        <asp:RadioButton ID="rdoIncome4" runat="server" GroupName="incomeSource4" Text="Income" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="rdoF4" runat="server" GroupName="statusIn4" Text="Fully Functioning" />
                                        <asp:RadioButton ID="rdoP4" runat="server" GroupName="statusIn4" Text="Partial Functioning" />
                                        <asp:RadioButton ID="rdoI4" runat="server" GroupName="statusIn4" Text="Inactive" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>5</td>
                                    <td><asp:DropDownList runat="server" ID="cmbAssetType5" CssClass="form-control">
                                        <asp:ListItem Value="L" Text="Land"></asp:ListItem>
                                        <asp:ListItem Value="H" Text="House"></asp:ListItem>
                                        <asp:ListItem Value="M" Text="Machine"></asp:ListItem>
                                        <asp:ListItem Value="V" Text="Vehical"></asp:ListItem>
                                        <asp:ListItem Value="S" Text="Live Stock"></asp:ListItem>
                                        <asp:ListItem Value="O" Text="Other"></asp:ListItem>
                                    </asp:DropDownList></td>
                                    <td><asp:TextBox runat="server" ID="txtValue5" CssClass="form-control"></asp:TextBox></td>
                                    <td>
                                        <asp:RadioButton ID="rdoOther5" runat="server" GroupName="incomeSource5" Text="Other" />
                                        <asp:RadioButton ID="rdoGif5" runat="server" GroupName="incomeSource5" Text="Gift" />
                                        <asp:RadioButton ID="rdoIncome5" runat="server" GroupName="incomeSource5" Text="Income" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="rdoF5" runat="server" GroupName="statusIn5" Text="Fully Functioning" />
                                        <asp:RadioButton ID="rdoP5" runat="server" GroupName="statusIn5" Text="Partial Functioning" />
                                        <asp:RadioButton ID="rdoI5" runat="server" GroupName="statusIn5" Text="Inactive" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            
            <div class="col-md-12">
                <div class="PageTitle"><h5>Savings and Insurance<hr /></h5></div>
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <td>Type</td>
                            <td></td>
                            <td>Amount</td>
                            <td>Institution</td>
                            <td>Remarks</td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Regular Savings</td>
                            <td>
                                <asp:RadioButton GroupName="rdoSIRS" ID="rdoSIRSYes1" runat="server" text="&nbsp; Yes &nbsp;"/>
                                <asp:RadioButton GroupName="rdoSIRS" ID="rdoSIRSNo1" runat="server" text="&nbsp; No &nbsp;" />
                            </td>
                            <td><asp:TextBox ID="rdoSIRSAmmount1" CssClass="form-control numbersOnly" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="rdoSIRSInstitution1" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="rdoSIRSRemarks1" CssClass="form-control" TextMode="MultiLine" Height="50px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Fixed Savings</td>
                            <td>
                                <asp:RadioButton GroupName="rdoSIFS" ID="rdoSIFSYes1" runat="server" text="&nbsp; Yes &nbsp;"/>
                                <asp:RadioButton GroupName="rdoSIFS" ID="rdoSIFSNo1" runat="server" text="&nbsp; No &nbsp;" />
                            </td>
                            <td><asp:TextBox ID="rdoSIFSAmmount1" CssClass="form-control numbersOnly" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="rdoSIFSInstitution1" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="rdoSIFSRemarks1" CssClass="form-control" TextMode="MultiLine" Height="50px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Seettu</td>
                            <td>
                                <asp:RadioButton GroupName="rdoSISeettu" ID="rdoSISeettuYes1" runat="server" text="&nbsp; Yes &nbsp;"/>
                                <asp:RadioButton GroupName="rdoSISeettu" ID="rdoSISeettuNo1" runat="server" text="&nbsp; No &nbsp;" />
                            </td>
                            <td><asp:TextBox ID="rdoSISeettuAmmount1" CssClass="form-control numbersOnly" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="rdoSISeettuInstitution1" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="rdoSISeettuRemarks1" CssClass="form-control" TextMode="MultiLine" Height="50px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Insurance - Life</td>
                            <td>
                                <asp:RadioButton GroupName="rdoSIIL" ID="rdoSIILYes1" runat="server" text="&nbsp; Yes &nbsp;"/>
                                <asp:RadioButton GroupName="rdoSIIL" ID="rdoSIILNo1" runat="server" text="&nbsp; No &nbsp;" />
                            </td>
                            <td><asp:TextBox ID="rdoSIILAmmount1" CssClass="form-control numbersOnly" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="rdoSIILInstitution1" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="rdoSIILRemarks1" CssClass="form-control" TextMode="MultiLine" Height="50px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Insurance - Medical</td>
                            <td>
                                <asp:RadioButton GroupName="rdoSIIM" ID="rdoSIIMYes1" runat="server" text="&nbsp; Yes &nbsp;"/>
                                <asp:RadioButton GroupName="rdoSIIM" ID="rdoSIIMNo1" runat="server" text="&nbsp; No &nbsp;" />
                            </td>
                            <td><asp:TextBox ID="rdoSIIMAmmount1" CssClass="form-control numbersOnly" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="rdoSIIMInstitution1" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="rdoSIIMRemarks1" CssClass="form-control" TextMode="MultiLine" Height="50px" runat="server"></asp:TextBox></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            
            <div class="col-md-12">
                <div class="PageTitle"><h4>Details of Income Source 2<hr /></h4></div>
                <div class="col-md-10 form-group">
                    <div class="col-md-5">Total Monthly Income (Rs.)</div>
                    <div class="col-md-4"><asp:TextBox CssClass="form-control" ID="txtMonthlyIncome" runat="server"></asp:TextBox></div>
                </div>
                <div class="col-md-10 form-group">
                    <div class="col-md-5">Total Monthly Expenses - Business (Rs.)</div>
                    <div class="col-md-4"><asp:TextBox CssClass="form-control" ID="txtMonthlyExpenceB" runat="server"></asp:TextBox></div>
                </div>
                <div class="col-md-10 form-group">
                    <div class="col-md-5">Total Monthly Expenses - Family (Rs.)</div>
                    <div class="col-md-4"><asp:TextBox CssClass="form-control" ID="txtMonthlyExpenceF" runat="server"></asp:TextBox></div>
                </div>
                <div class="col-md-10 form-group">
                    <div class="col-md-5">Additional Income if any (Rs.)</div>
                    <div class="col-md-4"><asp:TextBox CssClass="form-control" ID="txtAdditionalIn" runat="server"></asp:TextBox></div>
                </div>
                <div class="col-md-10 form-group">
                    <div class="col-md-5">Cash Balance - Month (Rs.)</div>
                    <div class="col-md-4"><asp:TextBox CssClass="form-control" ID="txtCashBalance" runat="server"></asp:TextBox></div>
                </div>
            </div>
            
            <div class="col-md-12">
                <div class="PageTitle"><h5>Loans And Advances<hr /></h5></div>
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <td>No</td>
                            <td style="width:150px;">Amount Granted</td>
                            <td>Institution</td>
                            <td>Name of the institution</td>
                            <td>Reason</td>
                            <td style="width:150px;">Outstanding Amount</td>
                            <td style="width:75px;">Type of the facility</td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td><asp:TextBox CssClass="form-control" ID="txtAmountG1" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RadioButton ID="rdoMF1" runat="server" text="MF"/>
                                <asp:RadioButton ID="rdoFC1" runat="server" text="FC"/>
                                <asp:RadioButton ID="rdoBN1" runat="server" text="BN"/>
                                <asp:RadioButton ID="rdoOT1" runat="server" text="OT"/>
                            </td>
                            <td><asp:TextBox CssClass="form-control" ID="txtNameOfInstitue1" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox CssClass="form-control" ID="txtResone1" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox CssClass="form-control" ID="txtOutstanding1" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RadioButton ID="rdoIS1" runat="server" text="MF"/>
                                <asp:RadioButton ID="rdoNI1" runat="server" text="FC"/>
                            </td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td><asp:TextBox CssClass="form-control" ID="txtAmountG2" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RadioButton ID="rdoMF2" runat="server" text="MF"/>
                                <asp:RadioButton ID="rdoFC2" runat="server" text="FC"/>
                                <asp:RadioButton ID="rdoBN2" runat="server" text="BN"/>
                                <asp:RadioButton ID="rdoOT2" runat="server" text="OT"/>
                            </td>
                            <td><asp:TextBox CssClass="form-control" ID="txtNameOfInstitue2" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox CssClass="form-control" ID="txtResone2" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox CssClass="form-control" ID="txtOutstanding2" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RadioButton ID="rdoIS2" runat="server" text="MF"/>
                                <asp:RadioButton ID="rdoNI2" runat="server" text="FC"/>
                            </td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td><asp:TextBox CssClass="form-control" ID="txtAmountG3" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RadioButton ID="rdoMF3" runat="server" text="MF"/>
                                <asp:RadioButton ID="rdoFC3" runat="server" text="FC"/>
                                <asp:RadioButton ID="rdoBN3" runat="server" text="BN"/>
                                <asp:RadioButton ID="rdoOT3" runat="server" text="OT"/>
                            </td>
                            <td><asp:TextBox CssClass="form-control" ID="txtNameOfInstitue3" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox CssClass="form-control" ID="txtResone3" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox CssClass="form-control" ID="txtOutstanding3" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RadioButton ID="rdoIS3" runat="server" text="MF"/>
                                <asp:RadioButton ID="rdoNI3" runat="server" text="FC"/>
                            </td>
                        </tr>
                        <tr>
                            <td>4</td>
                            <td><asp:TextBox CssClass="form-control" ID="txtAmount4" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RadioButton ID="rdoM4" runat="server" text="MF"/>
                                <asp:RadioButton ID="rdoFC4" runat="server" text="FC"/>
                                <asp:RadioButton ID="rdoBN4" runat="server" text="BN"/>
                                <asp:RadioButton ID="rdoOT4" runat="server" text="OT"/>
                            </td>
                            <td><asp:TextBox CssClass="form-control" ID="txtNameOfInstitue4" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox CssClass="form-control" ID="txtResone4" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox CssClass="form-control" ID="txtOutstanding4" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RadioButton ID="rdoIS4" runat="server" text="MF"/>
                                <asp:RadioButton ID="rdoNI4" runat="server" text="FC"/>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            
            <div class="col-md-12"><hr /></div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                            <div class="col-md-5">
                                Expected Price per Unit<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtExpectedPricePerUnit" MaxLength="12" CssClass="form-control expUnitPrice numbersOnly"
                                    runat="server" TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                            <div class="col-md-5">
                                Annual Rate<span style="color: Red;"> *</span></div>
                            <div class="col-md-5">
                                <asp:TextBox ID="txtAnnualRate" MaxLength="12" CssClass="form-control rate numbersOnly" runat="server"
                                    TabIndex="0"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <span style="color: Black;">%</span>
                            </div>
                        </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                            <div class="col-md-5">
                                Rate for Period<span style="color: Red;"> *</span></div>
                            <div class="col-md-5">
                                <asp:TextBox ID="txtRatePeriod" MaxLength="12" CssClass="form-control rateForPeriod numbersOnly" runat="server"
                                    TabIndex="0"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <span style="color: Black;">%</span>
                            </div>
                        </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                            <div class="col-md-5">
                                Expected Profit<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtExpectedProfit" MaxLength="12" CssClass="form-control expProfit numbersOnly" runat="server"
                                    TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                            <div class="col-md-5">
                                Expected Selling Price<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtExpectedSellingPrice" MaxLength="12" CssClass="form-control expSellingPrice numbersOnly"
                                    runat="server" TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group">
                            <div class="col-md-5">
                                Expected Unit<span style="color: Red;"> *</span></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtExpectedUnit" MaxLength="12" CssClass="form-control expUnits numbersOnly" runat="server"
                                    TabIndex="0"></asp:TextBox>
                            </div>
                        </div>
                </div>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Enabled="false" runat="server"
                    Text="Submit" TabIndex="17" OnClick="btnSubmit_Click" />&nbsp;
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
