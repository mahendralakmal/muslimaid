<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="business_details.aspx.cs" Inherits="MuslimAID.MURABHA.business_details"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Business Details</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Facility Code<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCC" CssClass="form-control" 
                        MaxLength="15" AutoPostBack="true" Enabled="false" runat="server" TabIndex="1" 
                        ontextchanged="txtCC_TextChanged" ></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12">
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Business Name<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtBuss" CssClass="form-control" runat="server" TabIndex="3"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Duration In Business<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbPeriod" runat="server" TabIndex="4">
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
                <div class="col-md-7"><asp:TextBox ID="txtBisAddress" CssClass="form-control" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="5"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Business Population<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:DropDownList CssClass="form-control" TabIndex="6" ID="cmbBPopulation" runat="server">
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
                <div class="col-md-7"><asp:TextBox ID="txtBNature" CssClass="form-control" runat="server" TabIndex="7" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Key Person involved in the business<span style="color:Red;">*</span></div>
                <div class="col-md-7">                    
                    <asp:DropDownList CssClass="form-control" TabIndex="8" ID="cmbKeyPerson" runat="server">
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
                <div class="col-md-7"><asp:TextBox ID="txtNoOfPpl" CssClass="numbersOnly form-control" runat="server" TabIndex="9" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Business Registration No (if available)</div>
                <div class="col-md-7"><asp:TextBox ID="txtBRNo" CssClass="form-control" runat="server" TabIndex="10" AutoPostBack="false"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Contact No (Office)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtOffContact" MaxLength="10" CssClass="numbersOnly form-control" runat="server" TabIndex="11" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Annual Business Income (ABI)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Sales (Cash)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtBIncome" onchange="calcIncom()" CssClass="form-control txtBIncome" runat="server" TabIndex="12" AutoPostBack="false" ontextchanged="txtBIncome_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Sales (Credit)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCrdtIncome" onchange="calcIncom()" CssClass="form-control txtCrdtIncome" 
                        runat="server" TabIndex="13" AutoPostBack="false" 
                        ontextchanged="txtCrdtIncome_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other Sales (Business)</div>
                <div class="col-md-7"><asp:TextBox ID="txtOIncome" onchange="calcIncom()" CssClass="numbersOnly form-control txtOIncome" 
                        runat="server" TabIndex="14" AutoPostBack="false" 
                        ontextchanged="txtOIncome_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Sales</strong><span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox TabIndex="15" CssClass="numbersOnly form-control txtTotalIncome" Enabled="false" ID="txtTotalIncome" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hidtxtTotalIncome" runat="server" />
                </div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Annual Business Expenses (ABE)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Purchases (Cash)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtDCost" onchange="calcPurchase()" CssClass="numbersOnly form-control txtDCost" 
                        runat="server" TabIndex="16" AutoPostBack="false" 
                        ontextchanged="txtDCost_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Purchases (Credit)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtICost" onchange="calcPurchase()" CssClass="form-control txtICost" 
                        runat="server" TabIndex="17" AutoPostBack="false" 
                        ontextchanged="txtICost_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Purchases</strong><span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox TabIndex="18" CssClass="form-control txtTotPurchase" ID="txtTotPurchase" Enabled="false" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hidtxtTotPurchase" runat="server" />
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Gross Profit</strong><span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox TabIndex="18" CssClass="form-control txtGrossProfit" ID="txtGrossProfit" Enabled="false" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hidGross" runat="server" />
                </div>
            </div>
        </div>
        <div class="col-lg-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent</div>
                <div class="col-md-7"><asp:TextBox CssClass="numbersOnly form-control txtRent" ID="txtRent" 
                        runat="server" TabIndex="19" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtRent_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Water/ Electricity & Telephone</div>
                <div class="col-md-7"><asp:TextBox CssClass="numbersOnly form-control txtWET" ID="txtWET" 
                        runat="server" TabIndex="20" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtWET_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Wages</div>
                <div class="col-md-7"><asp:TextBox CssClass="numbersOnly form-control txtWages" ID="txtWages" 
                        runat="server" TabIndex="21" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtWages_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Facility/ Lease/ Advance Rental</div>
                <div class="col-md-7"><asp:TextBox CssClass="numbersOnly form-control txtFLA" ID="txtFLA" 
                        runat="server" TabIndex="22" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtFLA_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Travel & Transport</div>
                <div class="col-md-7"><asp:TextBox CssClass="numbersOnly form-control txtTravelTrans" ID="txtTravelTrans" 
                        runat="server" TabIndex="23" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtTravelTrans_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Repair & Maintenance</div>
                <div class="col-md-7"><asp:TextBox CssClass="numbersOnly form-control txtRepairMain" ID="txtRepairMain" 
                        runat="server" TabIndex="24" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtRepairMain_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Total Business Expense<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox CssClass="form-control txtTExpenses" TabIndex="25" ID="txtTExpenses" Enabled="false" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hidtxtTExpenses" runat="server" />
                    <%--<asp:Label CssClass="form-control" ID="lblTExpenses" runat="server"></asp:Label>--%>
                </div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Net Profit<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox CssClass="form-control txtPAndL" TabIndex="26" ID="txtPAndL" Enabled="false" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hidtxtPAndL" runat="server" />
                <%--<asp:Label CssClass="form-control" ID="lblPAndL" runat="server"></asp:Label>--%>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" 
                Text="Submit" TabIndex="27" onclick="btnSubmit_Click"/>
            <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" 
                Text="Update" TabIndex="28" onclick="btnUpdate_Click"/>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</div>
</asp:Content>
