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

            /* $("#datetimepicker1").on('datetimepicker1.change', function(e) {
                console.log("hi");
                alert($("#txtDOB").val());
            }); */
        });
        
//        function calcBD(obj) {
//            //$dd = $("#ctl00_ContentPlaceHolder1_txtDOB").val();
//            $dob = new Date($("#ctl00_ContentPlaceHolder1_txtDOB").val());
//            $today = new Date();
//            $age = Math.floor(($today - $dob) / (365.25 * 24 * 60 * 60 * 1000));

//            console.log($dob);
//            console.log($today);
//            console.log($age);
//            $("#ctl00_ContentPlaceHolder1_lblAge").html($age);
//        }
    </script>

    <script type="text/javascript">
        $(function() {
            $('#datetimepicker1').datetimepicker({
                format: 'DD/MM/YYYY',
                defaultDate: new Date()
            }).on('dp.change', function(event) {
                console.log('hi');
                //                $dob = new Date($("#ctl00_ContentPlaceHolder1_txtDOB").val());
                $dob = new Date(event.date);
                $today = new Date();
                $age = Math.floor(($today - $dob) / (365.25 * 24 * 60 * 60 * 1000));
                console.log($dob);
                console.log($today);
                console.log($age);
                $("#ctl00_ContentPlaceHolder1_lblAge").html($age);
            });

            $('#datetimepicker2').datetimepicker({ format: 'DD/MM/YYYY' });
        });
    </script>
    
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
                            AutoPostBack="true" TabIndex="0" ontextchanged="txtNIC_TextChanged"></asp:TextBox>
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
                        <!-- <input type='text' class="form-control" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span> -->
                        <asp:TextBox ID="txtNicIssuDay" MaxLength="10" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="0"></asp:TextBox>
                    </div>
                    <!-- <script type="text/javascript">
                        $(function() {
                            $('#datetimepicker1').datetimepicker();
                        });
                    </script> -->
                </div>
            </div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Branch<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbCityCode" CssClass="form-control" TabIndex="1" 
                        runat="server" AutoPostBack="true" 
                        onselectedindexchanged="cmbCityCode_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            </div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Root ID<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbRoot" runat="server"></asp:DropDownList></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Area<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbVillages" 
                        runat="server" AutoPostBack="true" 
                        onselectedindexchanged="cmbVillages_SelectedIndexChanged"></asp:DropDownList> </div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Center Name<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbSocietyName" 
                        runat="server" AutoPostBack="true" 
                        onselectedindexchanged="cmbSocietyName_SelectedIndexChanged"></asp:DropDownList></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Center Code<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtSoNumber" Enabled="false" MaxLength="10" runat="server" TabIndex="3" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div></div>
            
            <%--<div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">C.A. Code<span style="color:Red;"> *</span></div>
                <div class="col-md-3"><asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" Enabled="false"></asp:TextBox></div>
                <div class="col-md-3"><asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" AutoPostBack="true"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Group ID<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtGroupID" runat="server" AutoPostBack="true"></asp:TextBox></div>
            </div></div>
            <div class="col-md-12">&nbsp;</div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Guranter 01<span style="color:Red;"> *</span></div>
                <div class="col-md-3"><asp:TextBox CssClass="form-control" ID="txtPromiserID1" runat="server" Enabled="false"></asp:TextBox></div>
                <div class="col-md-3"><asp:TextBox CssClass="form-control" ID="txtPromiserID" runat="server" AutoPostBack="true"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Guranter 02<span style="color:Red;"> *</span></div>
                <div class="col-md-3"><asp:TextBox CssClass="form-control" ID="txtPromiser02" runat="server" Enabled="false"></asp:TextBox></div>
                <div class="col-md-3"><asp:TextBox CssClass="form-control" ID="txtPromiser02_02" runat="server" AutoPostBack="true"></asp:TextBox></div>
            </div></div>--%>
            
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Client Photo<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:FileUpload ID="fpPhoto" CssClass="form-control" runat="server" TabIndex="3" /><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                   ControlToValidate="fpPhoto"
                   ErrorMessage=".jpg,.png,.jpeg,.gif Files only"
                   ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"></asp:RegularExpressionValidator>
                </div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Product Photo<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:FileUpload ID="fpBBPhoto" CssClass="form-control" runat="server" TabIndex="4" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                       ControlToValidate="fpBBPhoto"
                       ErrorMessage=".jpg,.png,.jpeg,.gif Files only"
                       ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"></asp:RegularExpressionValidator>
                </div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Province<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbProvince" runat="server" TabIndex="4"></asp:DropDownList></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">GS Ward<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtGSWard" MaxLength="45" runat="server" TabIndex="5"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Full Name<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtFullName" MaxLength="100" runat="server" TabIndex="6"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Given Names</div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtGivenName" MaxLength="30" runat="server" TabIndex="7"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Initial with Name<span style="color:Red;"> *</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtInwName" MaxLength="100" runat="server" TabIndex="8"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Other Names</div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtOtherName" MaxLength="30" runat="server" TabIndex="9"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Date of Birth</div>
                <div class="col-md-7">
                    <div class='input-group date' id='datetimepicker1' name='datetimepicker1'>
                        <asp:TextBox ID="txtDOB" CssClass="form-control" runat="server"
                            TabIndex="9"></asp:TextBox>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                
                </div>
            </div></div>
            <div class="col-md-6">
                <div class="form-group">                
                    <div class="col-md-5">Age</div>
                    <div class="col-md-7">
                        <asp:Label CssClass="form-control" ID="lblAge" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Gender</div>
                <div class="col-md-7">
                    <asp:RadioButton ID="rdoMale" Text="Male" runat="server" TabIndex="10" Checked="True" GroupName="rdoGender" />
                    <asp:RadioButton ID="rdoFeMale" TabIndex="11" Text="Female" runat="server" GroupName="rdoGender" />
                </div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Marital Status<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbMS" CssClass="form-control" runat="server" TabIndex="12">
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
                <asp:DropDownList ID="cmbEducation" CssClass="form-control" runat="server" TabIndex="12">
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
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtAddress" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="15"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Current Residential Address<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtResiAddress" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="15"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Mobile No<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtMobileNo" runat="server" MaxLength="10" TabIndex="14"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Tele No<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtTele" runat="server" MaxLength="10" TabIndex="14"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
            <div class="form-group">                
                <div class="col-md-5">Occupation / Income Source<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtOccupation" runat="server" MaxLength="10" TabIndex="14"></asp:TextBox></div>
            </div></div>
            <div class="col-md-6">
                <div class="form-group">                
                    <div class="col-md-5">Inspection Date<span style="color:Red;">*</span></div>
                    <div class="col-md-7">
                        <div class='input-group date' id='datetimepicker2' name="datetimepicker2">
                            <asp:TextBox ID="txtInsDate" CssClass="form-control" runat="server" TabIndex="16"></asp:TextBox>
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
                    runat="server" Text="Submit" TabIndex="17" onclick="btnSubmit_Click"/>&nbsp;
                <asp:Button ID="btnUpdate" CssClass="btn btn-primary" Enabled="false" 
                    runat="server" Text="Update" 
                        TabIndex="31" onclick="btnUpdate_Click" />
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
