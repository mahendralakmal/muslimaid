<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="family_details.aspx.cs" Inherits="MuslimAID.MURABHA.family_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Family Details</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Facility Code <span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="30" 
                        AutoPostBack="true" runat="server" TabIndex="1" 
                        ontextchanged="txtCC_TextChanged"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Name</div>
                <div class="col-md-7"><asp:TextBox ID="txtSoName" CssClass="form-control" MaxLength="100" runat="server" TabIndex="3"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse NIC</div>
                <div class="col-md-7"><asp:TextBox ID="txtNIC" CssClass="form-control" 
                        MaxLength="12" runat="server" TabIndex="4"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse NIC Issued Date</div>
                <div class="col-md-7">
                    <div class='input-group date' id='datetimepicker1' name='datetimepicker1'>
                        <asp:TextBox ID="txtNicIssuedDate" TabIndex="5" CssClass="form-control" runat="server" ></asp:TextBox>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
            </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Date of Birth</div>
                <div class="col-md-7">
                    <div class='input-group date' id='sDob' name='sDob'>
                        <asp:TextBox ID="txtDOB" TabIndex="6" CssClass="form-control sDob" runat="server"></asp:TextBox>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                    </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Age</div>
                <div class="col-md-7">
                <!-- <asp:TextBox ID="txtAge" CssClass="form-control" MaxLength="10" runat="server" TabIndex="2" Enabled="false"></asp:TextBox> -->
            <asp:Label CssClass="form-control lblAge" ID="lblAge" runat="server"></asp:Label>
        </div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Gender</div>
                <div class="col-md-7">
                    <asp:RadioButton ID="rdoMale" Text="Male" runat="server" TabIndex="7" GroupName="rdoGender" />
                    <asp:RadioButton ID="rdoFeMale" TabIndex="8" Text="Female" runat="server" Checked="True"  GroupName="rdoGender"/>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Contact No</div>
                <div class="col-md-7"><asp:TextBox ID="txtContact" TabIndex="9" CssClass="numbersOnly form-control" MaxLength="10" runat="server"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Relationship with the Applicant</div>
                <div class="col-md-7"><asp:TextBox ID="txtRelation" CssClass="form-control" MaxLength="10" runat="server" TabIndex="10"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Spouse Income</div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtSIncome" CssClass="numbersOnly form-control" MaxLength="8" runat="server" TabIndex="11" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Occupation / Income Source</div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbOccupa" CssClass="form-control" runat="server" TabIndex="12">
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
                <div class="col-md-5">No of Family Members</div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtNoFMembers" CssClass="form-control numbersOnly" MaxLength="2" runat="server" TabIndex="13" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Education</div>
                <div class="col-md-7">
                    
                    <asp:DropDownList ID="cmbEducation" CssClass="form-control" runat="server" TabIndex="14">
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
                <div class="col-md-5">No of Dependants <span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtDepen" CssClass="numbersOnly form-control" MaxLength="2" runat="server" TabIndex="15"  onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other F. Member Income</div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtFMIncome" CssClass="numbersOnly form-control" MaxLength="8" runat="server" TabIndex="16" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Moveable Properties</div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtMProperty" CssClass="numbersOnly form-control" MaxLength="8" runat="server" TabIndex="17" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Immoveable Properties</div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtIProperty" CssClass="numbersOnly form-control" MaxLength="8" runat="server" TabIndex="18" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Savings</div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtSaving" CssClass="numbersOnly form-control" MaxLength="8" runat="server" TabIndex="19" onKeypress="javascript:return check(event);"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-12"><hr /></div>
        <div class="col-md-12">
            <div class="table-back form-group">
                <div class="col-md-12 text-center"><h3>Family Details</h3></div>
                <table class="" width="100%" cellpadding="0" cellspacing="0" TabIndex="20">
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
                        <td><asp:TextBox TabIndex="21" CssClass="form-control" ID="txtName1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="22" CssClass="form-control" ID="txtRelation1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="23" CssClass="form-control numbersOnly" ID="txtAge1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="24" CssClass="form-control" ID="txtOcc1" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="25" CssClass="form-control" ID="txtInCome1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td><asp:TextBox TabIndex="26" CssClass="form-control" ID="txtName2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="27" CssClass="form-control" ID="txtRelation2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="28" CssClass="form-control numbersOnly" ID="txtAge2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="29" CssClass="form-control" ID="txtOcc2" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="30" CssClass="form-control" ID="txtInCome2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td><asp:TextBox TabIndex="31" CssClass="form-control" ID="txtName3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="32" CssClass="form-control" ID="txtRelation3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="33" CssClass="form-control numbersOnly" ID="txtAge3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="34" CssClass="form-control" ID="txtOcc3" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="35" CssClass="form-control" ID="txtInCome3" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>4</td>
                        <td><asp:TextBox TabIndex="36" CssClass="form-control" ID="txtName4" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="37" CssClass="form-control" ID="txtRelation4" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="38" CssClass="form-control numbersOnly" ID="txtAge4" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="39" CssClass="form-control" ID="txtOcc4" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="40" CssClass="form-control" ID="txtInCome4" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>5</td>
                        <td><asp:TextBox TabIndex="41" CssClass="form-control" ID="txtName5" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="42" CssClass="form-control" ID="txtRelation5" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="43" CssClass="form-control numbersOnly" ID="txtAge5" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="44" CssClass="form-control" ID="txtOcc5" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="45" CssClass="form-control" ID="txtInCome5" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>6</td>
                        <td><asp:TextBox TabIndex="46" CssClass="form-control" ID="txtName6" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="47" CssClass="form-control" ID="txtRelation6" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="48" CssClass="form-control numbersOnly" ID="txtAge6" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="49" CssClass="form-control" ID="txtOcc6" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="50" CssClass="form-control" ID="txtInCome6" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>7</td>
                        <td><asp:TextBox TabIndex="51" CssClass="form-control" ID="txtName7" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="52" CssClass="form-control" ID="txtRelation7" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="53" CssClass="form-control numbersOnly" ID="txtAge7" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="54" CssClass="form-control" ID="txtOcc7" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="55" CssClass="form-control" ID="txtInCome7" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>8</td>
                        <td><asp:TextBox TabIndex="56" CssClass="form-control" ID="txtName8" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="57" CssClass="form-control" ID="txtRelation8" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="58" CssClass="form-control numbersOnly" ID="txtAge8" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="59" CssClass="form-control" ID="txtOcc8" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="60" CssClass="form-control" ID="txtInCome8" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>9</td>
                        <td><asp:TextBox TabIndex="61" CssClass="form-control" ID="txtName9" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="62" CssClass="form-control" ID="txtRelation9" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="63" CssClass="form-control numbersOnly" ID="txtAge9" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="64" CssClass="form-control" ID="txtOcc9" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="65" CssClass="form-control" ID="txtInCome9" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>10</td>
                        <td><asp:TextBox TabIndex="66" CssClass="form-control" ID="txtName10" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="67" CssClass="form-control" ID="txtRelation10" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="68" CssClass="form-control numbersOnly" ID="txtAge10" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="69" CssClass="form-control" ID="txtOcc10" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox TabIndex="70" CssClass="form-control" ID="txtInCome10" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="col-md-12">
            <asp:Button ID="btnSubmit" TabIndex="71" CssClass="btn btn-primary" runat="server" 
                Text="Submit" Enabled="true" onclick="btnSubmit_Click"/>
            <asp:Button ID="btnUpdate" TabIndex="72" CssClass="btn btn-primary" runat="server" 
                Text="Update" Enabled="False" onclick="btnUpdate_Click"/>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</div>
</asp:Content>
