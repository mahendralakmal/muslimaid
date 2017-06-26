<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="client_basic_details.aspx.cs" Inherits="MuslimAID.MURABHA.client_basic_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%=txtInsDate.ClientID %>").dynDateTime({
                showsTime: false,
                ifFormat: "%Y-%m-%d",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>

    <script type="text/javascript" src="../dist/js/base_scripts.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>Facility Application Form</h4></div>
        <div class="col-md-12 form-container">
            <div class="col-md-6"> 
                <div class="form-group">
                    <div class="col-md-5">NIC/Passport/DL No<span style="color:Red;"> *</span></div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtNIC" MaxLength="12" CssClass="form-control" runat="server" 
                            AutoPostBack="true" TabIndex="1" ontextchanged="txtNIC_TextChanged"></asp:TextBox>
                        <p>
                        <asp:Label ID="lblMsg0" runat="server" ForeColor="Red"></asp:Label>
                        </p>
                        <asp:HiddenField ID="hidCC" runat="server" />
                        <asp:HiddenField ID="hidCACode" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-md-6"> 
                <div class="form-group">
                    <div class="col-md-5">NIC/Passport/DL Issued Date<span style="color:Red;"> *</span></div>
                    <div class="col-md-7">
                        <div class='input-group date' id='dtpNicPassIssueDateCBD' name='dtpNicPassIssueDateCBD'>
                            <asp:TextBox ID="txtNicIssuDay" MaxLength="10" CssClass="form-control" runat="server" TabIndex="2"></asp:TextBox>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12"><hr /></div>
            <div class="col-md-6">
                <div class="form-group">                
                    <div class="col-md-5">Branch<span style="color:Red;"> *</span></div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="cmbBranch" CssClass="form-control" TabIndex="3" 
                            runat="server" AutoPostBack="true" 
                            onselectedindexchanged="cmbBranch_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-12"></div> 
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Area<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:DropDownList CssClass="form-control" ID="cmbArea" 
                        runat="server" AutoPostBack="true" TabIndex="4"
                        onselectedindexchanged="cmbArea_SelectedIndexChanged"></asp:DropDownList> </div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Village<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:DropDownList CssClass="form-control" ID="cmbVillage" 
                        runat="server" AutoPostBack="true" TabIndex="5"
                        onselectedindexchanged="cmbVillage_SelectedIndexChanged"></asp:DropDownList></div>
            </div></div>
            <div class="col-md-12"></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Center<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:DropDownList CssClass="form-control" ID="cmbCenter" 
                        runat="server" AutoPostBack="true" TabIndex="6" 
                        onselectedindexchanged="cmbCenter_SelectedIndexChanged"></asp:DropDownList></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Center Code<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtSoNumber" name="txtSoNumber" TabIndex="7" CssClass="form-control" runat="server"></asp:TextBox></div>
            </div></div>          
            <div class="col-md-6">
                <div class="form-group">                
                    <div class="col-md-5">MFO<span style="color:Red;"> *</span></div>
                    <div class="col-md-7">
                    <asp:DropDownList CssClass="form-control" TabIndex="8" ID="cmbRoot" runat="server"></asp:DropDownList>
                        <asp:HiddenField ID="hidRoot" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-md-12"></div> 
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Facility Code <span style="color:Red;">*</span></div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="30" 
                            AutoPostBack="true" runat="server" TabIndex="9"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-6"><asp:Label ID="upperMsg" CssClass="alert-danger" runat="server"></asp:Label></div>
        </div>
        <div class="col-md-12 form-container">
        <span class="PageTitle"><h4>Information of Applicant</h4></span><br />
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Full Name<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtFullName" MaxLength="100" runat="server" TabIndex="10"></asp:TextBox></div>
            </div></div>
            <div class="col-md-12">&nbsp;</div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Address as per NIC<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtAddress" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="11"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Current Residential Address</div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtResiAddress" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="12"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Tele No<%--<span style="color:Red;">*</span>--%></div>
                <div class="col-md-7"><asp:TextBox CssClass="numbersOnly form-control" ID="txtTele" runat="server" MaxLength="10" TabIndex="13"></asp:TextBox></div>
            </div></div>
            <div class="col-md-12">&nbsp;</div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Name of the Grama Niladhari division<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtGSWard" MaxLength="45" runat="server" TabIndex="14"></asp:TextBox></div>
            </div></div>
            
            <div class="col-md-12"></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Date of Birth</div>
                <div class="col-md-7">
                    <div class='input-group date' id='DobCDB' name='DobCDB'>
                        <asp:TextBox ID="txtDOB" CssClass="form-control" runat="server"
                            TabIndex="15"></asp:TextBox>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div></div>
            <div class="col-md-3">
                <div class="form-group">                
                    <div class="col-md-5">Age</div>
                    <div class="col-md-7">
                        <asp:Label CssClass="form-control lblAge" ID="lblAge" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Gender</div>
                <div class="col-md-7">
                    <asp:RadioButton ID="rdoMale" Text="Male" runat="server" TabIndex="16" Checked="True" GroupName="rdoGender" />
                    <asp:RadioButton ID="rdoFeMale" TabIndex="17" Text="Female" runat="server" GroupName="rdoGender" />
                </div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Marital Status<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbMS" CssClass="form-control" runat="server" TabIndex="17">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="S">Single</asp:ListItem>
                        <asp:ListItem Value="M">Married</asp:ListItem>
                        <asp:ListItem Value="d">Divorce</asp:ListItem>
                        <asp:ListItem Value="W">Widow</asp:ListItem>
                        <asp:ListItem Value="I">Widower</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div></div>
            <div class="col-md-12"></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Occupation / Income source<span style="color:Red;">*</span></div>
                <div class="col-md-7">              
                        <asp:DropDownList ID="cmbOccupation" CssClass="form-control" runat="server" 
                            TabIndex="18" AutoPostBack="True" 
                            onselectedindexchanged="cmbOccupation_SelectedIndexChanged">
                        </asp:DropDownList>
              </div>
            </div></div>
            <div class="col-md-6">
                <div class="form-group">                
                    <div class="col-md-5">Inspection Date<span style="color:Red;">*</span></div>
                    <div class="col-md-7">
                        <div class='input-group date' id='InspectionCDB' name="InspectionCDB">
                            <asp:TextBox ID="txtInsDate" CssClass="form-control" runat="server" TabIndex="19"></asp:TextBox>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                        <asp:HiddenField ID="hf1" runat="server" />
                        <asp:HiddenField ID="hf2" runat="server" />
                        <asp:HiddenField ID="hf3" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-12 form-container">
            <span class="PageTitle"><h4>Information of spouse / Main income holder</h4></span><br />
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Name in full</div>
                    <div class="col-md-7"><asp:TextBox ID="txtSoName" CssClass="form-control" MaxLength="100" runat="server" TabIndex="20"></asp:TextBox></div>
                </div>
            </div>
            <div class="col-md-12"></div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Contact Number(s)</div>
                    <div class="col-md-7"><asp:TextBox ID="txtSoContactNo" CssClass="form-control" MaxLength="100" runat="server" TabIndex="21"></asp:TextBox></div>
                </div>
            </div>
            <div class="col-md-12"></div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Date of Birth</div>
                    <div class="col-md-7">
                        <div class='input-group date' id='sDob' name='sDob'>
                            <asp:TextBox ID="txtSoDOB" TabIndex="22" CssClass="form-control sDob" runat="server"></asp:TextBox>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <div class="col-md-5">Age</div>
                    <div class="col-md-7">
                        <asp:Label CssClass="form-control lblSoAge" ID="lblSoAge" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">NIC Number</div>
                    <div class="col-md-7"><asp:TextBox ID="txtSoNIC" CssClass="form-control" 
                            MaxLength="12" runat="server" TabIndex="23"></asp:TextBox></div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">NIC Issued Date</div>
                    <div class="col-md-7">
                            <div class='input-group date' id='datetimepicker1' name='datetimepicker1'>
                                <asp:TextBox ID="txtSoNicIssuedDate" TabIndex="24" CssClass="form-control" runat="server" ></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12"></div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Gender</div>
                    <div class="col-md-7">
                        <asp:RadioButton ID="rdoSoMale" Text="Male" runat="server" TabIndex="25" Checked="true" GroupName="rdoSoGender" />
                        <asp:RadioButton ID="rdoSoFeMale" TabIndex="26" Text="Female" runat="server" GroupName="rdoSoGender"/>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Relationship with the Applicant</div>
                    <div class="col-md-7">
                        <asp:DropDownList CssClass="form-control" TabIndex="27" ID="cmbRelation" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Son</asp:ListItem>
                            <asp:ListItem>Daughter</asp:ListItem>
                            <asp:ListItem>Siblings</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Occupation / Income Source</div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="cmbOccupa" CssClass="form-control" runat="server" 
                            TabIndex="28" AutoPostBack="True" 
                            onselectedindexchanged="cmbOccupa_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-12 form-container">
            <span class="PageTitle"><h4>Information of Existing Business</h4></span><br />           
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Nature of the business</div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="cmbBNature" CssClass="form-control" runat="server" TabIndex="29">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Business</div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtBusiness" runat="server" TabIndex="30" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Key Person involved in the business<span style="color:Red;">*</span></div>
                    <div class="col-md-7">                    
                        <asp:DropDownList CssClass="form-control" TabIndex="31" ID="cmbKeyPerson" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Son</asp:ListItem>
                            <asp:ListItem>Daughter</asp:ListItem>
                            <asp:ListItem>Siblings</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">No of People involved/ employed in the business<span style="color:Red;">*</span></div>
                    <div class="col-md-7"><asp:TextBox ID="txtNoOfPpl" 
                            CssClass="numbersOnly form-control" runat="server" TabIndex="32"></asp:TextBox></div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Business Address<span style="color:Red;">*</span></div>
                    <div class="col-md-7"><asp:TextBox ID="txtBisAddress" CssClass="form-control" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="33"></asp:TextBox></div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Years of Business<span style="color:Red;">*</span></div>
                    <div class="col-md-7">
                        <asp:DropDownList CssClass="form-control" ID="cmbPeriod" runat="server" TabIndex="34">
                            <asp:ListItem></asp:ListItem>
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
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Business Registration No (if available)</div>
                    <div class="col-md-7"><asp:TextBox ID="txtBRNo" CssClass="form-control" runat="server" TabIndex="35" AutoPostBack="false"></asp:TextBox></div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Contact No</div>
                    <div class="col-md-7"><asp:TextBox ID="txtBContact" CssClass="form-control" runat="server" TabIndex="36" AutoPostBack="false"></asp:TextBox></div>
                </div>
            </div>
        </div>
        <div class="col-md-12 form-container">
            <span class="PageTitle"><h4>Information on Facility Requirment</h4></span><br />
                    
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Reason to apply a facility<span style="color:Red;">*</span></div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtResonToApply" CssClass="form-control" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="36"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Facility Amount/ Value<span style="color:Red;">*</span></div>
                    <div class="col-md-7"><asp:TextBox ID="txtLDLAmount" CssClass="numbersOnly form-control loanAmount" MaxLength="12" runat="server" TabIndex="37"  onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox></div>
                </div>
            </div>
            <div class="col-md-12"></div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-5">Time Period<span style="color:Red;"></span></div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="cmbTmePeriod" CssClass="form-control period" runat="server" TabIndex="38">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <div class="col-md-12">Any unsettled advances/ facilities available :<span style="color:Red;">* </span>
                        <asp:RadioButton GroupName="rdoUnsetlled" CssClass="rdoUnsetlled rdoYes1" 
                            TabIndex="39" ID="rdoYes" runat="server" AutoPostBack="True" 
                            oncheckedchanged="rdoYes_CheckedChanged" /> Yes &nbsp;&nbsp;
                        <asp:RadioButton GroupName="rdoUnsetlled" CssClass="rdoUnsetlled rdoNo1" 
                            TabIndex="40" ID="rdoNo" Checked="true" runat="server" AutoPostBack="True" 
                            oncheckedchanged="rdoNo_CheckedChanged" /> No
                    </div>
                </div>
            </div>
            
            <div class="col-md-12">
                <div class="table-back form-group table-responsive">
                    <table class="table" width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <th></th>
                            <th class="col-md-3 col-sm-3 col-xs-3">Name of Organization</th>
                            <th class="col-md-2 col-sm-2 col-xs-2">Purpose</th>
                            <th class="col-md-2 col-sm-2 col-xs-2">Facility Amount</th>
                            <th class="col-md-2 col-sm-2 col-xs-2">Outstanding Balance</th>
                            <th class="col-md-2 col-sm-2 col-xs-2">Monthly Installment</th>
                            <th class="col-md-1 col-sm-1 col-xs-1">Remaining no of Installment</th>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td><asp:TextBox TabIndex="41" CssClass="form-control" ID="txtNameOrg1" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="42" CssClass="form-control" ID="txtPurpos1" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="43" CssClass="numbersOnly form-control" ID="txtFAmount1" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="44" CssClass="form-control" ID="txtOutstandBal1" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="45" CssClass="form-control" ID="txtMonthInstal1" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="46" CssClass="form-control" ID="txtRemainInstal1" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td><asp:TextBox TabIndex="47" CssClass="form-control" ID="txtNameOrg2" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="48" CssClass="form-control" ID="txtPurpos2" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="49" CssClass="numbersOnly form-control" ID="txtFAmount2" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="50" CssClass="form-control" ID="txtOutstandBal2" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="51" CssClass="form-control" ID="txtMonthInstal2" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="52" CssClass="form-control" ID="txtRemainInstal2" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td><asp:TextBox TabIndex="53" CssClass="form-control" ID="txtNameOrg3" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="54" CssClass="form-control" ID="txtPurpos3" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="55" CssClass="numbersOnly form-control" ID="txtFAmount3" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="56" CssClass="form-control" ID="txtOutstandBal3" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="57" CssClass="form-control" ID="txtMonthInstal3" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="58" CssClass="form-control" ID="txtRemainInstal3" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>    
        <div class="col-md-12 form-container">
            <span class="PageTitle"><h4>Family Details</h4></span><br />
            
            <div class="col-md-12">
                <div class="table-back form-group">
                <%--<div class="col-md-12" title="Yes">
                    <asp:RadioButton ID="rdoOFDy" CssClass="rdoOFDy" runat="server" GroupName="OtherFamilyDetails" 
                        Text="Yes" AutoPostBack="True" oncheckedchanged="rdoOFDy_CheckedChanged" />&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdoOFDn" CssClass="rdoOFDy" runat="server" Checked="true" GroupName="OtherFamilyDetails" 
                        Text="No" AutoPostBack="True" oncheckedchanged="rdoOFDn_CheckedChanged" />
                </div>--%>
                    <table class="" width="100%" cellpadding="0" cellspacing="0" TabIndex="59">
                        <tr>
                            <th></th>
                            <th class="col-md-2">Name</th>
                            <th class="col-md-2">Relationship to applicant</th>
                            <th class="col-md-2">NIC</th>
                            <th class="col-md-2">DOB</th>
                            <th class="col-md-2">Occupation</th>
                            <th class="col-md-2">Income (Monthly)</th>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td><asp:TextBox TabIndex="60" CssClass="form-control" ID="txtName1" runat="server"></asp:TextBox></td>
                            <td>
                        <asp:DropDownList CssClass="form-control" TabIndex="61" ID="cmbRelation1" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Client</asp:ListItem>                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Son</asp:ListItem>
                            <asp:ListItem>Daughter</asp:ListItem>
                            
                        </asp:DropDownList></td>
                            <td><asp:TextBox TabIndex="62" CssClass="form-control" ID="txtNIC1" MaxLength="12" runat="server"></asp:TextBox></td>
                            <td>
                                <div class='input-group date' id='DobCDB1' name='DobCDB1'>
                                    <asp:TextBox TabIndex="63" CssClass="form-control numbersOnly" ID="txtDOB1" MaxLength="10" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </td>
                            <td><asp:TextBox TabIndex="64" CssClass="form-control" ID="txtOcc1" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="65" CssClass="form-control numbersOnly" ID="txtInCome1" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td><asp:TextBox TabIndex="66" CssClass="form-control" ID="txtName2" runat="server"></asp:TextBox></td>
                            <td>
                        <asp:DropDownList CssClass="form-control" TabIndex="67" ID="cmbRelation2" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Client</asp:ListItem>                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Son</asp:ListItem>
                            <asp:ListItem>Daughter</asp:ListItem>
                            
                        </asp:DropDownList></td>
                            <td><asp:TextBox TabIndex="68" CssClass="form-control " ID="txtNIC2" MaxLength="12" runat="server"></asp:TextBox></td>
                            <td>
                                <div class='input-group date' id='DobCDB2' name='DobCDB2'>
                                    <asp:TextBox TabIndex="69" CssClass="form-control numbersOnly" ID="txtDOB2" MaxLength="10" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </td>
                            <td><asp:TextBox TabIndex="70" CssClass="form-control" ID="txtOcc2" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="71" CssClass="form-control numbersOnly" ID="txtInCome2" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td><asp:TextBox TabIndex="72" CssClass="form-control" ID="txtName3" runat="server"></asp:TextBox></td>
                            <td>
                        <asp:DropDownList CssClass="form-control" TabIndex="73" ID="cmbRelation3" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Client</asp:ListItem>                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Son</asp:ListItem>
                            <asp:ListItem>Daughter</asp:ListItem>
                            
                        </asp:DropDownList></td>
                            <td><asp:TextBox TabIndex="74" CssClass="form-control " ID="txtNIC3" MaxLength="12" runat="server"></asp:TextBox></td>
                            <td>
                                <div class='input-group date' id='DobCDB3' name='DobCDB3'>
                                    <asp:TextBox TabIndex="75" CssClass="form-control numbersOnly" ID="txtDOB3" MaxLength="10" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </td>
                            <td><asp:TextBox TabIndex="76" CssClass="form-control" ID="txtOcc3" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="77" CssClass="form-control numbersOnly" ID="txtInCome3" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>4</td>
                            <td><asp:TextBox TabIndex="78" CssClass="form-control" ID="txtName4" runat="server"></asp:TextBox></td>
                            <td>
                        <asp:DropDownList CssClass="form-control" TabIndex="79" ID="cmbRelation4" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Client</asp:ListItem>                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Son</asp:ListItem>
                            <asp:ListItem>Daughter</asp:ListItem>
                            
                        </asp:DropDownList></td>
                            <td><asp:TextBox TabIndex="80" CssClass="form-control " MaxLength="12" ID="txtNIC4" runat="server"></asp:TextBox></td>
                            <td>
                                <div class='input-group date' id='DobCDB4' name='DobCDB4'>
                                    <asp:TextBox TabIndex="81" CssClass="form-control numbersOnly" MaxLength="10" ID="txtDOB4" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </td>
                            <td><asp:TextBox TabIndex="82" CssClass="form-control" ID="txtOcc4" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="83" CssClass="form-control numbersOnly" ID="txtInCome4" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>5</td>
                            <td><asp:TextBox TabIndex="84" CssClass="form-control" ID="txtName5" runat="server"></asp:TextBox></td>
                            <td>
                        <asp:DropDownList CssClass="form-control" TabIndex="85" ID="cmbRelation5" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Client</asp:ListItem>                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Son</asp:ListItem>
                            <asp:ListItem>Daughter</asp:ListItem>
                            
                        </asp:DropDownList></td>
                            <td><asp:TextBox TabIndex="86" CssClass="form-control " MaxLength="12" ID="txtNIC5" runat="server"></asp:TextBox></td>
                            <td>
                                <div class='input-group date' id='DobCDB5' name='DobCDB5'>
                                    <asp:TextBox TabIndex="87" CssClass="form-control numbersOnly" MaxLength="10" ID="txtDOB5" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </td>
                            <td><asp:TextBox TabIndex="88" CssClass="form-control" ID="txtOcc5" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="89" CssClass="form-control numbersOnly" ID="txtInCome5" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>6</td>
                            <td><asp:TextBox TabIndex="90" CssClass="form-control" ID="txtName6" runat="server"></asp:TextBox></td>
                            <td>
                        <asp:DropDownList CssClass="form-control" TabIndex="91" ID="cmbRelation6" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Client</asp:ListItem>                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Son</asp:ListItem>
                            <asp:ListItem>Daughter</asp:ListItem>
                            
                        </asp:DropDownList></td>
                            <td><asp:TextBox TabIndex="92" CssClass="form-control " MaxLength="12" ID="txtNIC6" runat="server"></asp:TextBox></td>
                            <td>
                                <div class='input-group date' id='DobCDB6' name='DobCDB6'>
                                    <asp:TextBox TabIndex="93" CssClass="form-control numbersOnly" MaxLength="10" ID="txtDOB6" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </td>
                            <td><asp:TextBox TabIndex="94" CssClass="form-control" ID="txtOcc6" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="95" CssClass="form-control numbersOnly" ID="txtInCome6" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>7</td>
                            <td><asp:TextBox TabIndex="96" CssClass="form-control" ID="txtName7" runat="server"></asp:TextBox></td>
                            <td>
                        <asp:DropDownList CssClass="form-control" TabIndex="97" ID="cmbRelation7" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Client</asp:ListItem>                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Son</asp:ListItem>
                            <asp:ListItem>Daughter</asp:ListItem>
                            
                        </asp:DropDownList></td>
                            <td><asp:TextBox TabIndex="98" CssClass="form-control " MaxLength="12" ID="txtNIC7" runat="server"></asp:TextBox></td>
                            <td>
                                <div class='input-group date' id='DobCDB7' name='DobCDB7'>
                                    <asp:TextBox TabIndex="99" CssClass="form-control numbersOnly" MaxLength="10" ID="txtDOB7" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </td>
                            <td><asp:TextBox TabIndex="100" CssClass="form-control" ID="txtOcc7" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="101" CssClass="form-control numbersOnly" ID="txtInCome7" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>8</td>
                            <td><asp:TextBox TabIndex="102" CssClass="form-control" ID="txtName8" runat="server"></asp:TextBox></td>
                            <td>
                        <asp:DropDownList CssClass="form-control" TabIndex="103" ID="cmbRelation8" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Client</asp:ListItem>                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Son</asp:ListItem>
                            <asp:ListItem>Daughter</asp:ListItem>
                            
                        </asp:DropDownList></td>
                            <td><asp:TextBox TabIndex="104" CssClass="form-control " MaxLength="12" ID="txtNIC8" runat="server"></asp:TextBox></td>
                            <td>
                                <div class='input-group date' id='DobCDB8' name='DobCDB8'>
                                    <asp:TextBox TabIndex="105" CssClass="form-control numbersOnly" MaxLength="10" ID="txtDOB8" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </td>
                            <td><asp:TextBox TabIndex="106" CssClass="form-control" ID="txtOcc8" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="107" CssClass="form-control numbersOnly" ID="txtInCome8" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>9</td>
                            <td><asp:TextBox TabIndex="108" CssClass="form-control" ID="txtName9" runat="server"></asp:TextBox></td>
                            <td>
                        <asp:DropDownList CssClass="form-control" TabIndex="109" ID="cmbRelation9" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Client</asp:ListItem>                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Son</asp:ListItem>
                            <asp:ListItem>Daughter</asp:ListItem>
                            
                        </asp:DropDownList></td>
                            <td><asp:TextBox TabIndex="110" CssClass="form-control " MaxLength="12" ID="txtNIC9" runat="server"></asp:TextBox></td>
                            <td>
                                <div class='input-group date' id='DobCDB9' name='DobCDB9'>
                                    <asp:TextBox TabIndex="111" CssClass="form-control numbersOnly" MaxLength="10" ID="txtDOB9" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </td>
                            <td><asp:TextBox TabIndex="112" CssClass="form-control" ID="txtOcc9" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox TabIndex="113" CssClass="form-control numbersOnly" ID="txtInCome9" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="col-md-12 form-container">
            <div class="col-md-12">
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Enabled="false" 
                    runat="server" Text="Submit" TabIndex="114" onclick="btnSubmit_Click"/>&nbsp;
                <asp:Button ID="btnUpdate" CssClass="btn btn-primary" Enabled="false" 
                    runat="server" Text="Update" 
                        TabIndex="115" onclick="btnUpdate_Click" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $('#ctl00_ContentPlaceHolder1_txtNicIssuDay').datetimepicker({
            format: 'dd/MM/yyyy hh:mm:ss',
            language: 'pt-BR'
        });
    </script>
</asp:Content>
