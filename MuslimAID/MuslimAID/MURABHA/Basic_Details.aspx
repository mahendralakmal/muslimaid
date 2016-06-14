<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Basic_Details.aspx.cs" Inherits="MuslimAID.MURABHA.Basic_Details" Title="Ventura Crystal Investments Ltd ::: Basic Details" %>
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="text-align:left;">
            <tr>
                <td colspan="7" width="860px" class="PageTitle"><b>MF Application - Client Basic Details</b></td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td width="160px">NIC/Passport No/DL<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="300px" align="left">
                    <asp:TextBox ID="txtNIC" Width="120px" MaxLength="10" runat="server" AutoPostBack="true" 
                        TabIndex="0" ontextchanged="txtNIC_TextChanged"></asp:TextBox>
                </td>
                <td width="40px">
                    <asp:HiddenField ID="hidCC" runat="server" />
                    <asp:HiddenField ID="hidCACode" runat="server" />
                </td>
                <td width="130px"></td>
                <td width="20px"></td>
                <td width="230px">
                     
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td width="160px">City Code<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="300px" align="left">
                    <asp:DropDownList ID="cmbCityCode" TabIndex="1" runat="server" 
                        AutoPostBack="true" onselectedindexchanged="cmbCityCode_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td width="40px">
                </td>
                <td width="130px">Root ID<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="230px">
                    <asp:DropDownList ID="cmbRoot" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Village<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:DropDownList ID="cmbVillages" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="cmbVillages_SelectedIndexChanged">
                    </asp:DropDownList> 
                </td>
                <td width="130px">W.I Society Name<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td>
                    <asp:DropDownList ID="cmbSocietyName" runat="server" AutoPostBack="true"
                        onselectedindexchanged="cmbSocietyName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Society Number<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtSoNumber" Width="30px" Enabled="false" MaxLength="10" runat="server" TabIndex="3" onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);"></asp:TextBox> 
                </td>
                <td width="130px">C.A. Code<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td>
                    <asp:TextBox ID="txtCACode1" runat="server" Enabled="false" Width="40px"></asp:TextBox>
                    <asp:TextBox ID="txtCACode" runat="server" AutoPostBack="true" Width="20px" 
                        ontextchanged="txtCACode_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Group ID<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                     <asp:TextBox ID="txtGroupID" runat="server" AutoPostBack="true" 
                        ontextchanged="txtGroupID_TextChanged"></asp:TextBox>
                </td>
                <td width="130px"></td>
                <td width="20px"></td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Promiser 01<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtPromiserID1" runat="server" Width="40px" Enabled="false"></asp:TextBox>
                    <asp:TextBox ID="txtPromiserID" runat="server" AutoPostBack="true" Width="20px"
                        ontextchanged="txtPromiserID_TextChanged"></asp:TextBox> 
                </td>
                <td width="130px">Promiser 02<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td>
                    <asp:TextBox ID="txtPromiser02" runat="server" Width="40px" Enabled="false"></asp:TextBox>
                    <asp:TextBox ID="txtPromiser02_02" runat="server" AutoPostBack="true" Width="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td width="160px" valign="top">Client Photo<span style="color:Red;">*</span></td>
                <td width="20px" valign="top">:</td>
                <td width="300px" align="left">
                    <asp:FileUpload ID="fpPhoto" runat="server" TabIndex="3" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
               ControlToValidate="fpPhoto"
               ErrorMessage=".jpg,.png,.jpeg,.gif Files only"
               ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"></asp:RegularExpressionValidator>
                </td>
                <td width="40px">
                </td>
                <td width="130px" valign="top">Bank Book Photo<span style="color:Red;">*</span></td>
                <td width="20px" valign="top">:</td>
                <td width="230px">
                    <asp:FileUpload ID="fpBBPhoto" runat="server" TabIndex="4" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
               ControlToValidate="fpBBPhoto"
               ErrorMessage=".jpg,.png,.jpeg,.gif Files only"
               ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Province<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:DropDownList ID="cmbProvince" runat="server" TabIndex="4">
                    </asp:DropDownList>
                </td>
                <td width="130px">GS Ward<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td>
                    <asp:TextBox ID="txtGSWard" Width="130px" MaxLength="45" runat="server" TabIndex="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Full Name<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtFullName" Width="300px" MaxLength="100" runat="server" TabIndex="6"></asp:TextBox>
                </td>
                <td width="130px">Given Names</td>
                <td width="20px">:</td>
                <td>
                    <asp:TextBox ID="txtGivenName" Width="200px" MaxLength="30" runat="server" TabIndex="7"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="10px"></td>
            </tr>
            <tr>
                <td>Initial with Name<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtInwName" Width="300px" MaxLength="100" runat="server" TabIndex="8"></asp:TextBox>
                </td>
                <td width="130px">Other Names</td>
                <td width="20px">:</td>
                <td>
                    <asp:TextBox ID="txtOtherName" Width="200px" MaxLength="30" runat="server" TabIndex="9"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Marital Status<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:RadioButton ID="rdoMarried" Text="Married" runat="server" TabIndex="10" Checked="True" GroupName="rdoSingle" /><asp:RadioButton ID="rdoSingle" TabIndex="11"
                                        Text="Single" runat="server" />
                </td>
                <td width="130px">Education</td>
                <td width="20px">:</td>
                <td>
                    <asp:DropDownList ID="cmbEducation" runat="server" TabIndex="12">
                        <asp:ListItem>Primary</asp:ListItem>
                        <asp:ListItem>Secondary</asp:ListItem>
                        <asp:ListItem>Undergraduate</asp:ListItem>
                        <asp:ListItem>Graduate</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Telephone No<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtTNo" runat="server" MaxLength="10" TabIndex="13"></asp:TextBox>
                </td>
                <td width="130px">Mobile No<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td>
                    <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" TabIndex="14"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td valign="top">Permanet Address<span style="color:Red;">*</span></td>
                <td valign="top">:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtAddress" Width="300px" CssClass="addressText" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="15"></asp:TextBox>
                </td>
                <td width="130px" valign="top">Inspection Date<span style="color:Red;">*</span></td>
                <td width="20px" valign="top">:</td>
                <td valign="top">
                    <asp:TextBox ID="txtInsDate" runat="server" TabIndex="16"></asp:TextBox><img src="../Images/calender.png" />
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px">
                    <asp:HiddenField ID="hf1" runat="server" />
                    <asp:HiddenField ID="hf2" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td colspan="5" align="left">
                    <asp:Button ID="btnSubmit" Enabled="false" runat="server" Text="Submit" TabIndex="17" 
                        onclick="btnSubmit_Click" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
