<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="family_details.aspx.cs" Inherits="MuslimAID.MURABHA.family_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="../dist/js/base_scripts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Family Details</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Contract Code<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="12" Enabled="false" AutoPostBack="true" runat="server" TabIndex="0"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">C. Applicant Code<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCACode" CssClass="form-control" MaxLength="12" runat="server" TabIndex="1"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Name<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtSoName" CssClass="form-control" MaxLength="100" runat="server" TabIndex="3"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse NIC<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtNIC" CssClass="form-control" 
                        MaxLength="12" runat="server" TabIndex="2"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse NIC Issued Date<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <div class='input-group date' id='datetimepicker1' name='datetimepicker1'>
                        <asp:TextBox ID="txtNicIssuedDate" CssClass="form-control" runat="server" ></asp:TextBox>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
            </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Date of Birth<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <div class='input-group date' id='sDob' name='sDob'>
                        <asp:TextBox ID="txtDOB" CssClass="form-control sDob" runat="server"></asp:TextBox>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                    </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Age<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                <!-- <asp:TextBox ID="txtAge" CssClass="form-control" MaxLength="10" runat="server" TabIndex="2" Enabled="false"></asp:TextBox> -->
            <asp:Label CssClass="form-control lblAge" ID="lblAge" runat="server"></asp:Label>
        </div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Gender<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:RadioButton ID="rdoMale" Text="Male" runat="server" TabIndex="10" Checked="True" GroupName="rdoGender" />
                    <asp:RadioButton ID="rdoFeMale" TabIndex="11" Text="Female" runat="server" GroupName="rdoGender"/>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Contact No</div>
                <div class="col-md-7"><asp:TextBox ID="txtContact" CssClass="form-control" MaxLength="10" runat="server" TabIndex="2"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Relationship with the Applicant<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtRelation" CssClass="form-control" MaxLength="10" runat="server" TabIndex="2"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Income<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtSIncome" CssClass="form-control" MaxLength="8" runat="server" TabIndex="8" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Occupation / Income Source<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbOccupa" CssClass="form-control" runat="server" TabIndex="4">
                        <asp:ListItem>Profession</asp:ListItem>
                        <asp:ListItem>Agriculture</asp:ListItem>
                        <asp:ListItem>Business</asp:ListItem>
                        <asp:ListItem>Self</asp:ListItem>
                        <asp:ListItem>Pensioner</asp:ListItem>
                        <asp:ListItem>Engineer</asp:ListItem>
                        <asp:ListItem>Skilled Worker</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">No of Family Members<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtNoFMembers" CssClass="form-control" MaxLength="2" runat="server" TabIndex="5" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Education<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    
                    <asp:DropDownList ID="cmbEducation" CssClass="form-control" runat="server" TabIndex="6">
                        <asp:ListItem>Primary</asp:ListItem>
                        <asp:ListItem>Secondary</asp:ListItem>
                        <asp:ListItem>Undergraduate</asp:ListItem>
                        <asp:ListItem>Graduate</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">No of Dependants<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtDepen" CssClass="form-control" MaxLength="2" runat="server" TabIndex="7"  onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <%--<div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Income Source<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtSIncome" CssClass="form-control" MaxLength="8" runat="server" TabIndex="8" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>--%>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other F. Member Income</div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtFMIncome" CssClass="form-control" MaxLength="8" runat="server" TabIndex="8" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Moveable Properties</div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtMProperty" CssClass="form-control" MaxLength="8" runat="server" TabIndex="8" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Immoveable Properties</div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtIProperty" CssClass="form-control" MaxLength="8" runat="server" TabIndex="8" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Savings</div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtSaving" CssClass="form-control" MaxLength="8" runat="server" TabIndex="8" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-12"><hr /></div>
        <div class="col-md-12">
            <div class="table-back form-group">
                <div class="col-md-12 text-center"><h3>Family Details</h3></div>
                <table class="" width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <th></th>
                        <th class="col-md-3">Name</th>
                        <th class="col-md-3">Relationship to applicant</th>
                        <th class="col-md-1">Age</th>
                        <th class="col-md-3">Occupation</th>
                        <th class="col-md-2">Income (Monthly)</th>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtName1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRelation1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtAge1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOcc1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtInCome1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtName2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRelation2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtAge2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOcc2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtInCome2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtName3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRelation3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtAge3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOcc3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtInCome3" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>4</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtName4" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRelation4" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtAge4" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOcc4" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtInCome4" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>5</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtName5" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRelation5" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtAge5" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOcc5" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtInCome5" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>6</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtName6" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRelation6" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtAge6" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOcc6" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtInCome6" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>7</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtName7" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRelation7" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtAge7" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOcc7" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtInCome7" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>8</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtName8" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRelation8" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtAge8" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOcc8" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtInCome8" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>9</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtName9" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRelation9" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtAge9" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOcc9" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtInCome9" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>10</td>
                        <td><asp:TextBox CssClass="form-control" ID="txtName10" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtRelation10" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtAge10" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtOcc10" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox CssClass="form-control" ID="txtInCome10" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="col-md-12">
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" 
                Text="Submit" Enabled="true" TabIndex="11" onclick="btnSubmit_Click"/>
            <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" 
                Text="Update" TabIndex="12" Enabled="False" onclick="btnUpdate_Click"/>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</div>
</asp:Content>
