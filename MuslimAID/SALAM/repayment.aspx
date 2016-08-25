﻿<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true" CodeBehind="repayment.aspx.cs" Inherits="MuslimAID.SALAM.repayment" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
        <div class="PageTitle"><h4>Salam - Repayment</h4></div>
        <div class="col-md-12 form-container">
        <div class="PageTitle"><h5>Business / Income Generational Activity Details<hr/></h5></div>
            <div class="col-md-6"> 
            <div class="form-group">
                <div class="col-md-5">Contract Code<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtContractCode" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0" Enabled="false"></asp:TextBox>
                </div>
            </div>
            </div>
            
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Financial Amount<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtFinancialAmount" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
            
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-12">Income Source (1)<span style="color:Red;"> *</span> : Income Generation activity – Salam facility to be utilized</div>
                <div class="col-md-5">&nbsp;</div>
                <div class="col-md-2">
                    <asp:DropDownList ID="cmbIncomeSource1_a" CssClass="form-control" TabIndex="1" runat="server" AutoPostBack="true">
                    <asp:ListItem Text="---Select---" Value="a0" />
                    <asp:ListItem Text="Agriculture" Value="a1" />
                    <asp:ListItem Text="Trading" Value="a2" />
                    <asp:ListItem Text="Manufacturing" Value="a3" />
                    <asp:ListItem Text="Other" Value="a4" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="cmbIncomeSource1_b" CssClass="form-control" TabIndex="1" runat="server" AutoPostBack="true">
                    <asp:ListItem Text="---Select---" Value="b0" />
                    <asp:ListItem Text="Paddy" Value="b1" />
                    <asp:ListItem Text="Vegetable" Value="b2" />
                    <asp:ListItem Text="Maize" Value="b3" />
                    <asp:ListItem Text="Other" Value="b4" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="cmbIncomeSource1_c" CssClass="form-control" TabIndex="1" runat="server" AutoPostBack="true">
                    <asp:ListItem Text="---Select---" Value="c0" />
                    <asp:ListItem Text="Brick" Value="c1" />
                    <asp:ListItem Text="Cement Blocks" Value="c2" />
                    </asp:DropDownList>
                </div>
            </div>
            </div>
            
            <div class="col-md-12">
            <div class="form-group">                
            <div class="col-md-12">Income Source (2)<span style="color:Red;"> *</span> : Income Generation activity – Secondary</div>
            <div class="col-md-5">&nbsp;</div>
            <div class="col-md-2">
            <asp:DropDownList ID="cmbIncomeSource2_a" CssClass="form-control" TabIndex="1" runat="server" AutoPostBack="true">
            <asp:ListItem Text="---Select---" Value="a0" />
            <asp:ListItem Text="Agriculture" Value="a1" />
            <asp:ListItem Text="Trading" Value="a2" />
            <asp:ListItem Text="Manufacturing" Value="a3" />
            <asp:ListItem Text="Other" Value="a4" />
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <asp:DropDownList ID="cmbIncomeSource2_b" CssClass="form-control" TabIndex="1" runat="server" AutoPostBack="true">
            <asp:ListItem Text="---Select---" Value="b0" />
            <asp:ListItem Text="Paddy" Value="b1" />
            <asp:ListItem Text="Vegetable" Value="b2" />
            <asp:ListItem Text="Maize" Value="b3" />
            <asp:ListItem Text="Other" Value="b4" />
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <asp:DropDownList ID="cmbIncomeSource2_c" CssClass="form-control" TabIndex="1" runat="server" AutoPostBack="true">
            <asp:ListItem Text="---Select---" Value="c0" />
            <asp:ListItem Text="Brick" Value="c1" />
            <asp:ListItem Text="Cement Blocks" Value="c2" />
            </asp:DropDownList>
        </div>
            </div>
            </div>
            
        <div class="PageTitle"><h5>Details of Income Source 1<hr/></h5></div>
        
        <div class="col-md-12">
        <div class="col-md-6">
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Area of Cultivation / Farming<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtCultivation_Farming" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Experience in Years<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtExperienceInYears" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Harvest – Total<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtHarvestTotal" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">No of Seasons in a Year<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtSeasonsInYear" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
        </div>
        
        <div class="col-md-6">
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Type of Variety 1<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtVariety1" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Type of Variety 2<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtVariety2" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Harvest Period<span style="color:Red;"> *</span></div>
                <div class="col-md-5">
                <asp:TextBox ID="txtHarvestPeriod" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
                <div class="col-md-2">
                <span style="color:Black;">Months</span>
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
                <div class="col-md-5">Rain Water<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:RadioButton ID="rdoRW_Y" Text="Y" runat="server" TabIndex="10" GroupName="rdoRainWater" />
                <asp:RadioButton ID="rdoRW_N" Text="N" runat="server" TabIndex="11" GroupName="rdoRainWater" />
                </div>
            </div>
            </div>
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Irrigation Water<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:RadioButton ID="rdoIW_Y" Text="Y" runat="server" TabIndex="10" GroupName="rdoIrrigationWater" />
                <asp:RadioButton ID="rdoIW_N" Text="N" runat="server" TabIndex="11" GroupName="rdoIrrigationWater" />
                </div>
            </div>
            </div>
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Both<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:RadioButton ID="rdoB_Y" Text="Y" runat="server" TabIndex="10" GroupName="rdoBoth" />
                <asp:RadioButton ID="rdoB_N" Text="N" runat="server" TabIndex="11" GroupName="rdoBoth" />
                </div>
            </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Minimum Price Expected<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtMinimumPriceExpected" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Maximum Price Expected<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtMaximumPriceExpected" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
        </div>
        </div>
        
        <div class="PageTitle"><h5>Details of Repayment<hr/></h5></div>
        <div class="col-md-12">
        <div class="col-md-6">
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Units<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:DropDownList ID="cmbUnits" CssClass="form-control" TabIndex="1" runat="server" AutoPostBack="true">
                <asp:ListItem Text="---Select---" Value="b0" />
                <asp:ListItem Text="Kg" Value="1" />
                <asp:ListItem Text="Peaces" Value="2" />
                </asp:DropDownList>
                </div>
            </div>
            </div>
        </div>
        </div>
        <div class="col-md-12">
        <div class="col-md-6">
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Repayment Period<span style="color:Red;"> *</span></div>
                <div class="col-md-5">
                <asp:TextBox ID="txtPeriodRepayment" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
                <div class="col-md-2">
                <span style="color:Black;">Months</span>
                </div>
            </div>
            </div>
        </div>
        </div>
        
        <div class="col-md-12">
        <div class="col-md-6">
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Expected Price per Unit<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtExpectedPricePerUnit" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
        </div>
        </div>
        
        <div class="col-md-12">
        <div class="col-md-6">
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Annual Rate<span style="color:Red;"> *</span></div>
                <div class="col-md-5">
                <asp:TextBox ID="txtAnnualRate" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
                <div class="col-md-2">
                <span style="color:Black;">%</span>
                </div>
            </div>
            </div>
        </div>
        </div>
        
        
        <div class="col-md-12">
        <div class="col-md-6">
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Rate for Period<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtRatePeriod" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
        </div>
        </div>
        <div class="col-md-12">
        <div class="col-md-6">
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Expected Profit<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtExpectedProfit" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
        </div>
        </div>
        <div class="col-md-12">
        <div class="col-md-6">
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Expected Selling Price<span style="color:Red;"> *</span></div>
                <div class="col-md-7">  
                <asp:TextBox ID="txtExpectedSellingPrice" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
        </div>
        </div>
        
        <div class="col-md-12">
        <div class="col-md-6">
            <div class="col-md-12">
            <div class="form-group">                
                <div class="col-md-5">Expected Unit<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtExpectedUnit" MaxLength="12" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                </div>
            </div>
            </div>
        </div>
        </div>
        <div class="col-md-12">
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Enabled="false" runat="server" Text="Submit" TabIndex="17"/>&nbsp;
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
</div>
</div>
</asp:Content>