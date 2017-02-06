<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true" CodeBehind="business_details.aspx.cs" Inherits="MuslimAID.SALAM.business_details" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../dist/js/base_scripts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Salam - Business Details</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Contract Code<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="15" AutoPostBack="false" Enabled="false" runat="server" TabIndex="0" ></asp:TextBox></div>
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
                <div class="col-md-7"><asp:TextBox ID="txtBIncome" onchange="calcIncom()" CssClass="form-control txtBIncome" runat="server" TabIndex="8" AutoPostBack="false" ontextchanged="txtBIncome_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Sales (Credit)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCrdtIncome" onchange="calcIncom()" CssClass="form-control txtCrdtIncome" 
                        runat="server" TabIndex="8" AutoPostBack="false" 
                        ontextchanged="txtCrdtIncome_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other Sales (Business)</div>
                <div class="col-md-7"><asp:TextBox ID="txtOIncome" onchange="calcIncom()" CssClass="form-control txtOIncome" 
                        runat="server" TabIndex="8" AutoPostBack="false" 
                        ontextchanged="txtOIncome_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Sales</strong><span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox CssClass="form-control txtTotalIncome" Enabled="false" ID="txtTotalIncome" runat="server"></asp:TextBox>
                    <%--<asp:Label CssClass="form-control" ID="lblTotalIncome" runat="server"></asp:Label>--%>
                </div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Business Expenses (BE)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Purchases (Cash)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtDCost" onchange="calcPurchase()" CssClass="form-control txtDCost" 
                        runat="server" TabIndex="8" AutoPostBack="false" 
                        ontextchanged="txtDCost_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Purchases (Credit)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtICost" onchange="calcPurchase()" CssClass="form-control txtICost" 
                        runat="server" TabIndex="8" AutoPostBack="false" 
                        ontextchanged="txtICost_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Purchases</strong><span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox CssClass="form-control txtTotPurchase" ID="txtTotPurchase" Enabled="false" runat="server"></asp:TextBox>
                    <%--<asp:Label CssClass="form-control" ID="lblTotPurchase" runat="server"></asp:Label>--%>
                </div>
            </div>
        </div>
        <div class="col-lg-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent</div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control txtRent" ID="txtRent" 
                        runat="server" TabIndex="8" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtRent_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Water/ Electricity & Telephone</div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control txtWET" ID="txtWET" 
                        runat="server" TabIndex="8" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtWET_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Wages</div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control txtWages" ID="txtWages" 
                        runat="server" TabIndex="8" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtWages_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Facility/ Lease/ Advance Rental</div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control txtFLA" ID="txtFLA" 
                        runat="server" TabIndex="8" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtFLA_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Travel & Transport</div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control txtTravelTrans" ID="txtTravelTrans" 
                        runat="server" TabIndex="8" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtTravelTrans_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Repair & Maintenance</div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control txtRepairMain" ID="txtRepairMain" 
                        runat="server" TabIndex="8" AutoPostBack="false" onchange="calcBEx()"
                        ontextchanged="txtRepairMain_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Total Business Expense<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox CssClass="form-control txtTExpenses" ID="txtTExpenses" Enabled="false" runat="server"></asp:TextBox>
                    <%--<asp:Label CssClass="form-control" ID="lblTExpenses" runat="server"></asp:Label>--%>
                </div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Gross Profit<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox CssClass="form-control txtPAndL" ID="txtPAndL" Enabled="false" runat="server"></asp:TextBox>
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
