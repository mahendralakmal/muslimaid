<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Loan_Details.aspx.cs" Inherits="MuslimAID.MURABHA.Loan_Details" Title="Ventura Crystal Investments Ltd ::: Loan Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="text-align:left;">
            <tr>
                <td colspan="7" width="860px" class="PageTitle"><b>MF Application - Facility Details</b></td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td width="160px">Contract Code<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="300px">
                    <asp:TextBox ID="txtCC" Width="100px" MaxLength="12" AutoPostBack="true" 
                        Enabled="false" runat="server" TabIndex="0" ontextchanged="txtCC_TextChanged"></asp:TextBox>
                </td>
                <td width="40px"></td>
                <td width="130px">C. Applicant Code<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="230px">
                    <asp:TextBox ID="txtCACode" Width="100px" MaxLength="10" runat="server" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td width="160px">Facility Amount<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="300px">
                    <asp:TextBox ID="txtLDLAmount" Width="100px" MaxLength="12" runat="server" AutoPostBack="true" 
                        TabIndex="0"  onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);" 
                        ontextchanged="txtLDLAmount_TextChanged"></asp:TextBox>
                </td>
                <td width="40px"></td>
                <td width="130px">Service Charges<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="230px">
                    <asp:TextBox ID="txtLDSerCharges" MaxLength="10" runat="server" Enabled="False" TabIndex="2" Width="100px" 
                        ReadOnly="True" onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td width="160px">Registrtion Fee<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="300px">
                    <asp:TextBox ID="txtRegistrationFee" Width="100px" MaxLength="12" runat="server" ReadOnly="true" 
                        TabIndex="0"  onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);" 
                        ontextchanged="txtLDLAmount_TextChanged"></asp:TextBox>
                </td>
                <td width="40px"></td>
                <td width="130px">Walfare Fee<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="230px">
                    <asp:TextBox ID="txtWalfareFee" MaxLength="10" runat="server" TabIndex="2" Width="100px" 
                        ReadOnly="true" onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Other Charges<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtLDOtherCharg" MaxLength="10" runat="server" TabIndex="3" Width="100px"></asp:TextBox>&nbsp;
                    Eg:(2000.00)
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Price" ValidationExpression="((\d{1,3}(\,\d{3})*)?|(\d+))(\.\d{2})" ControlToValidate="txtLDOtherCharg"></asp:RegularExpressionValidator>
                </td>
                <td></td>
                <td>Interest Rate (%<span style="color:Red;">*</span>)</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtLDIntRate" MaxLength="5" runat="server" Enabled="false" TabIndex="4" 
                        Width="100px"></asp:TextBox>&nbsp;
                    Eg:(36)
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Period<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:DropDownList ID="cmbPeriod" runat="server" TabIndex="5" Enabled="false">
                        <asp:ListItem Value="48">48 Weeks</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
                <td>Weekly Instollment<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtLDMInstoll" MaxLength="9" runat="server" Enabled="False" TabIndex="6" Width="100px"
                        ReadOnly="True"></asp:TextBox>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid Price" ValidationExpression="((\d{1,3}(\,\d{3})*)?|(\d+))(\.\d{2})" ControlToValidate="txtLDMInstoll"></asp:RegularExpressionValidator>--%>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td colspan="7">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td colspan="7" class="PageTitle"><b>Client Banking Details</b></td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Account Name<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtLDAccName" MaxLength="45" runat="server" TabIndex="7" Width="250px"></asp:TextBox>
                </td>
                <td></td>
                <td>Account Number<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtLDANumber" MaxLength="15" runat="server" TabIndex="8" Width="150px" onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Bank Name<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:DropDownList ID="cmbBankName" AutoPostBack="true" TabIndex="9" runat="server" 
                        onselectedindexchanged="cmbBankName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td></td>
                <td>Bank Code<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                     <asp:TextBox ID="txtBankCode" MaxLength="4" runat="server" Enabled="false" TabIndex="10" Width="150px" onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Branch<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:DropDownList ID="cmbBranch" TabIndex="11" AutoPostBack="true" runat="server" 
                        onselectedindexchanged="cmbBranch_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td></td>
                <td>Branch Code<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtBranchCode" Enabled="false" MaxLength="3" runat="server" TabIndex="12" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td colspan="5" align="left">
                    <asp:Button ID="btnLDNext" runat="server" Text="Submit" 
                        TabIndex="11" onclick="btnLDNext_Click" />&nbsp;
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="12" 
                        Enabled="false" onclick="btnUpdate_Click" />&nbsp;
                    <asp:Label ID="lblLDMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
