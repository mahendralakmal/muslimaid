<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="business_details.aspx.cs" Inherits="MuslimAID.MURABHA.business_details"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    var totIn = 0.00; var totPu = 0.00; var totEx = 0.00;
    function calcIncom() {
        $cashIn = $("#ctl00_ContentPlaceHolder1_txtBIncome").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtBIncome").val();
        $creditIn = $("#ctl00_ContentPlaceHolder1_txtCrdtIncome").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtCrdtIncome").val();
        $otherIn = $("#ctl00_ContentPlaceHolder1_txtOIncome").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtOIncome").val();

        totIn = parseFloat($cashIn) + parseFloat($creditIn) + parseFloat($otherIn);
        $("#ctl00_ContentPlaceHolder1_txtTotalIncome").val(totIn);
        calcPnL(totIn, totPu, totEx);
    }
    function calcPurchase() {
        $cashIn = $("#ctl00_ContentPlaceHolder1_txtDCost").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtDCost").val();
        $creditIn = $("#ctl00_ContentPlaceHolder1_txtICost").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtICost").val();

        totPu = parseFloat($cashIn) + parseFloat($creditIn);
        $("#ctl00_ContentPlaceHolder1_txtTotPurchase").val(totPu);
        calcPnL(totIn, totPu, totEx);
    }
    function calcBEx() {
        $Rent = $("#ctl00_ContentPlaceHolder1_txtRent").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtRent").val();
        $wet = $("#ctl00_ContentPlaceHolder1_txtWET").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtWET").val();
        $wages = $("#ctl00_ContentPlaceHolder1_txtWages").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtWages").val(); 
        $fla = $("#ctl00_ContentPlaceHolder1_txtFLA").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtFLA").val();
        $trans = $("#ctl00_ContentPlaceHolder1_txtTravelTrans").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtICost").val();
        $repir = $("#ctl00_ContentPlaceHolder1_txtRepairMain").val() === '' ? 0.00 : $("#ctl00_ContentPlaceHolder1_txtRepairMain").val();

        totEx = parseFloat($Rent) + parseFloat($wet) + parseFloat($wages) + parseFloat($fla) + parseFloat($trans) + parseFloat($repir);
        $("#ctl00_ContentPlaceHolder1_txtTExpenses").val(totEx);
        calcPnL(totIn, totPu, totEx);
    }
    function calcPnL(totIn, totPu, totEx) {
        totIn = totIn === '' ? 0.00 : totIn;
        totPu = totPu === '' ? 0.00 : totPu;
        totEx = totEx === '' ? 0.00 : totEx;
        console.log("totIn  " + totIn + " totPU " + totPu + " totEx " + totEx);
        $pnl = totIn - (totPu + totEx);
        //console.log($pnl);
        $("#ctl00_ContentPlaceHolder1_txtPAndL").val($pnl);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Business Details</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Contract Code<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="12" AutoPostBack="false" Enabled="false" runat="server" TabIndex="0" ></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">C. Applicant Code<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCACode" CssClass="form-control" MaxLength="10" runat="server" TabIndex="1"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Business Name<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtBuss" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Duration In Business<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbPeriod" runat="server" TabIndex="9">
                        <asp:ListItem>Less than 1 year</asp:ListItem>
                        <asp:ListItem>Up to 1 year</asp:ListItem>
                        <asp:ListItem>Up to 2 year</asp:ListItem>
                        <asp:ListItem>Up to 3 year</asp:ListItem>
                        <asp:ListItem>Up to 4 year</asp:ListItem>
                        <asp:ListItem>Up to 5 year</asp:ListItem>
                        <asp:ListItem>Up to 10 year</asp:ListItem>
                        <asp:ListItem>Up to 15 year</asp:ListItem>
                        <asp:ListItem>Up to 20 year</asp:ListItem>
                        <asp:ListItem>Up to 25 year</asp:ListItem>
                        <asp:ListItem>Up to 30 year</asp:ListItem>
                    </asp:DropDownList></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Business Address<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtBisAddress" CssClass="form-control" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="10"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Bissiness Population<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:DropDownList CssClass="form-control" ID="cmbBPopulation" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Stabilize</asp:ListItem>
                        <asp:ListItem>Strong</asp:ListItem>
                        <asp:ListItem>Growing</asp:ListItem>
                        <asp:ListItem>Potential to grow</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Nature of Business<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtBNature" CssClass="form-control" runat="server" TabIndex="8" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Key Person involved in the business<span style="color:Red;">*</span></div>
                <div class="col-md-7">                    
                    <asp:DropDownList CssClass="form-control" ID="cmbKeyPerson" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Husband</asp:ListItem>
                        <asp:ListItem>Wife</asp:ListItem>
                        <asp:ListItem>Son</asp:ListItem>
                        <asp:ListItem>Doughter</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">No of People involved/ employed in the business<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtNoOfPpl" CssClass="form-control" runat="server" TabIndex="8" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Business Registration No (if available)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtBRNo" CssClass="form-control" runat="server" TabIndex="8" AutoPostBack="false"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Contact No (Office)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtOffContact" CssClass="form-control" runat="server" TabIndex="8" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Business Income (BI)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Sales (Cash)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtBIncome" onchange="calcIncom()" CssClass="form-control" 
                        runat="server" TabIndex="8" AutoPostBack="false" 
                        ontextchanged="txtBIncome_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Sales (Credit)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCrdtIncome" onchange="calcIncom()" CssClass="form-control" 
                        runat="server" TabIndex="8" AutoPostBack="false" 
                        ontextchanged="txtCrdtIncome_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other Sales (Business)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtOIncome" onchange="calcIncom()" CssClass="form-control" 
                        runat="server" TabIndex="8" AutoPostBack="false" 
                        ontextchanged="txtOIncome_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Sales</strong><span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox CssClass="form-control" Enabled="false" ID="txtTotalIncome" runat="server"></asp:TextBox>
                    <%--<asp:Label CssClass="form-control" ID="lblTotalIncome" runat="server"></asp:Label>--%>
                </div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Business Expenses (BE)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Purchases (Cash)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtDCost" onchange="calcPurchase()" CssClass="form-control" 
                        runat="server" TabIndex="8" AutoPostBack="false" 
                        ontextchanged="txtDCost_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Purchases (Credit)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtICost" onchange="calcPurchase()" CssClass="form-control" 
                        runat="server" TabIndex="8" AutoPostBack="false" 
                        ontextchanged="txtICost_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Purchases</strong><span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox CssClass="form-control" ID="txtTotPurchase" Enabled="false" runat="server"></asp:TextBox>
                    <%--<asp:Label CssClass="form-control" ID="lblTotPurchase" runat="server"></asp:Label>--%>
                </div>
            </div>
        </div>
        <div class="col-lg-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtRent" 
                        runat="server" TabIndex="8" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtRent_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Water/ Electricity & Telephone<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtWET" 
                        runat="server" TabIndex="8" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtWET_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Wages<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtWages" 
                        runat="server" TabIndex="8" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtWages_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Facility/ Lease/ Advance Rental<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtFLA" 
                        runat="server" TabIndex="8" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtFLA_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Travel & Transport<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtTravelTrans" 
                        runat="server" TabIndex="8" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtTravelTrans_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Repair & Maintenance<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtRepairMain" 
                        runat="server" TabIndex="8" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtRepairMain_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Total Business Expense<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox CssClass="form-control" ID="txtTExpenses" Enabled="false" runat="server"></asp:TextBox>
                    <%--<asp:Label CssClass="form-control" ID="lblTExpenses" runat="server"></asp:Label>--%>
                </div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Gross Profit<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox CssClass="form-control" ID="txtPAndL" Enabled="false" runat="server"></asp:TextBox>
                <%--<asp:Label CssClass="form-control" ID="lblPAndL" runat="server"></asp:Label>--%>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" 
                Text="Submit" Enabled="false" TabIndex="11" onclick="btnSubmit_Click"/>
            <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" 
                Text="Update" TabIndex="12" Enabled="False" onclick="btnUpdate_Click"/>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</div>
</asp:Content>
