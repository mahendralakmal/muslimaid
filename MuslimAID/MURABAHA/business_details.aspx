<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="business_details.aspx.cs" Inherits="MuslimAID.MURABHA.business_details" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Business Details</h4></div>
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
                <div class="col-md-7"><asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" TabIndex="8" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Business Registration No (if available)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtBRNo" CssClass="form-control" runat="server" TabIndex="8" AutoPostBack="true"></asp:TextBox></div>
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
                <div class="col-md-7"><asp:TextBox ID="txtBIncome" CssClass="form-control" runat="server" TabIndex="8" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Sales (Credit)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" TabIndex="8" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other Sales (Business)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtOIncome" CssClass="form-control" runat="server" TabIndex="8" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Sales</strong><span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtTotalIncome" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Business Expenses (BE)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Purchases (Cash)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtDCost" CssClass="form-control" runat="server" TabIndex="8" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Purchases (Credit)<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtICost" CssClass="form-control" runat="server" TabIndex="8" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Purchases</strong><span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtOExpenses" Enabled="false" runat="server" TabIndex="8" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-lg-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtTExpenses" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Water/ Electricity & Telephone<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtPAndL" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Wages<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtFExpenses" runat="server" TabIndex="8" AutoPostBack="true"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Facility/ Lease/ Advance Rental<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtNetIncome" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Travel & Transport<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtTravelTrans" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Repair & Maintenance<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtRepairMain" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Total Business Expense<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="TextBox2" Enabled="false" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Gross Profit<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="TextBox4" Enabled="false" runat="server" TabIndex="8"></asp:TextBox></div>
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
