<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true" CodeBehind="client_basic_details.aspx.cs" Inherits="MuslimAID.SALAM.client_basic_details" %>
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
        <div class="PageTitle"><h4>MF Application - Client Basic Details</h4></div>
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
                            <asp:TextBox ID="txtNicIssuDay" MaxLength="10" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="2"></asp:TextBox>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12"></div>
            <div class="col-md-6">
                <div class="form-group">                
                    <div class="col-md-5">Branch<span style="color:Red;"> *</span></div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="cmbCityCode" CssClass="form-control" TabIndex="3" 
                            runat="server" AutoPostBack="true" 
                            onselectedindexchanged="cmbCityCode_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-12"></div>           
            <div class="col-md-12"></div>           
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Root ID<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" TabIndex="4" ID="cmbRoot" runat="server"></asp:DropDownList></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Area<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbVillages" 
                        runat="server" AutoPostBack="true" TabIndex="5"
                        onselectedindexchanged="cmbVillages_SelectedIndexChanged"></asp:DropDownList> </div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Center Name<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbSocietyName" 
                        runat="server" AutoPostBack="true" TabIndex="6"
                        onselectedindexchanged="cmbSocietyName_SelectedIndexChanged"></asp:DropDownList></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Center Code<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtSoNumber" Enabled="false" MaxLength="10" runat="server" TabIndex="7" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div></div>
                        
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Client Photo</div>
                    <div class="col-md-7">
                        <asp:FileUpload ID="fpPhoto" CssClass="form-control" runat="server" TabIndex="8" />
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                       ControlToValidate="fpPhoto"
                       ErrorMessage=".jpg,.png,.jpeg,.gif Files only"
                       ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"></asp:RegularExpressionValidator>--%>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Product Photo<%--<span style="color:Red;"> *</span>--%></div>
                    <div class="col-md-7">
                        <asp:FileUpload ID="fpBBPhoto" CssClass="form-control" runat="server" TabIndex="9" />
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                           ControlToValidate="fpBBPhoto"
                           ErrorMessage=".jpg,.png,.jpeg,.gif Files only"
                           ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"></asp:RegularExpressionValidator>--%>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">                
                    <div class="col-md-5">Province<span style="color:Red;"> *</span></div>
                    <div class="col-md-7">
                        <asp:DropDownList CssClass="form-control" ID="cmbProvince" runat="server" TabIndex="10"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">GS Ward<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtGSWard" MaxLength="45" runat="server" TabIndex="11"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Full Name<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtFullName" MaxLength="100" runat="server" TabIndex="12"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Given Names</div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtGivenName" MaxLength="30" runat="server" TabIndex="13"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Initial with Name<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtInwName" MaxLength="100" runat="server" TabIndex="14"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Other Names</div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtOtherName" MaxLength="30" runat="server" TabIndex="15"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Date of Birth</div>
                <div class="col-md-7">
                    <div class='input-group date' id='DobCDB' name='DobCDB'>
                        <asp:TextBox ID="txtDOB" CssClass="form-control" runat="server"
                            TabIndex="16"></asp:TextBox>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                
                </div>
            </div></div>
            <div class="col-md-6">
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
                    <asp:RadioButton ID="rdoMale" Text="Male" runat="server" TabIndex="17" Checked="True" GroupName="rdoGender" />
                    <asp:RadioButton ID="rdoFeMale" TabIndex="17" Text="Female" runat="server" GroupName="rdoGender" />
                </div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Marital Status<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbMS" CssClass="form-control" runat="server" TabIndex="18">
                        <asp:ListItem Value="S">Single</asp:ListItem>
                        <asp:ListItem Value="M">Married</asp:ListItem>
                        <asp:ListItem Value="d">Divorce</asp:ListItem>
                        <asp:ListItem Value="W">Widow</asp:ListItem>
                        <asp:ListItem Value="I">Widower</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Education</div>
                <div class="col-md-7">
                <asp:DropDownList ID="cmbEducation" CssClass="form-control" runat="server" TabIndex="19">
                    <asp:ListItem Value="P">Primary</asp:ListItem>
                    <asp:ListItem Value="S">Secondary</asp:ListItem>
                    <asp:ListItem Value="U">Undergraduate</asp:ListItem>
                    <asp:ListItem Value="G">Graduate</asp:ListItem>
                </asp:DropDownList></div>
            </div></div>
            <div class="col-md-12">&nbsp;</div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Address as per NIC<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtAddress" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="20"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Current Residential Address</div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtResiAddress" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="21"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Mobile No<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="numbersOnly form-control" ID="txtMobileNo" runat="server" MaxLength="10" TabIndex="22"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Tele No<%--<span style="color:Red;">*</span>--%></div>
                <div class="col-md-7"><asp:TextBox CssClass="numbersOnly form-control" ID="txtTele" runat="server" MaxLength="10" TabIndex="23"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Occupation / Income Source<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtOccupation" runat="server" TabIndex="24"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
                <div class="form-group">                
                    <div class="col-md-5">Inspection Date<span style="color:Red;">*</span></div>
                    <div class="col-md-7">
                        <div class='input-group date' id='InspectionCDB' name="InspectionCDB">
                            <asp:TextBox ID="txtInsDate" CssClass="form-control" runat="server" TabIndex="26"></asp:TextBox>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                        <asp:HiddenField ID="hf1" runat="server" />
                        <asp:HiddenField ID="hf2" runat="server" />
                        <asp:HiddenField ID="hf3" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Enabled="false" 
                    runat="server" Text="Submit" TabIndex="27" onclick="btnSubmit_Click"/>&nbsp;
                <asp:Button ID="btnUpdate" CssClass="btn btn-primary" Enabled="false" 
                    runat="server" Text="Update" 
                        TabIndex="28" onclick="btnUpdate_Click" />
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
