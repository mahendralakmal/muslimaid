<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Family_Details.aspx.cs" Inherits="MuslimAID.MURABHA.Family_Details" Title="Ventura Crystal Investments Ltd ::: Family Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="text-align:left;">
            <tr>
                <td colspan="7" width="860px" class="PageTitle"><b>MF Application - Family Details</b></td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Contract Code<span style="color:Red;">*</span></td>
                <td>:</td>
                <td width="300px">
                    <asp:TextBox ID="txtCC" Width="100px" MaxLength="12" Enabled="false" AutoPostBack="true"
                        runat="server" TabIndex="0" ontextchanged="txtCC_TextChanged"></asp:TextBox>
                </td>
                <td width="40px"></td>
                <td width="130px">C. Applicant Code<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="230px">
                    <asp:TextBox ID="txtCACode" Width="100px" MaxLength="12" runat="server" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td width="160px">Spouse NIC<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td colspan="4" align="left">
                    <asp:TextBox ID="txtNIC" Width="100px" MaxLength="10" runat="server" TabIndex="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Spouse Name<span style="color:Red;">*</span></td>
                <td>:</td>
                <td width="300px">
                    <asp:TextBox ID="txtSoName" Width="300px" MaxLength="100" runat="server" TabIndex="3"></asp:TextBox>
                </td>
                <td width="40px"></td>
                <td width="130px">Occupation<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="230px">
                    <asp:DropDownList ID="cmbOccupa" runat="server" TabIndex="4">
                        <asp:ListItem>Profession</asp:ListItem>
                        <asp:ListItem>Agriculture</asp:ListItem>
                        <asp:ListItem>Business</asp:ListItem>
                        <asp:ListItem>Self</asp:ListItem>
                        <asp:ListItem>Pensioner</asp:ListItem>
                        <asp:ListItem>Engineer</asp:ListItem>
                        <asp:ListItem>Skilled Worker</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>No of Family Members<span style="color:Red;">*</span></td>
                <td>:</td>
                <td width="300px">
                    <asp:TextBox ID="txtNoFMembers" Width="50px" MaxLength="2" runat="server" TabIndex="5" onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);"></asp:TextBox>
                </td>
                <td width="40px"></td>
                <td width="130px">Education<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="230px">
                    <asp:DropDownList ID="cmbEducation" runat="server" TabIndex="6">
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
                <td>No of Dependers<span style="color:Red;">*</span></td>
                <td>:</td>
                <td width="300px">
                    <asp:TextBox ID="txtDepen" Width="50px" MaxLength="2" runat="server" TabIndex="7" onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);"></asp:TextBox>
                </td>
                <td width="40px"></td>
                <td width="130px">Spouse Income</td>
                <td width="20px">:</td>
                <td width="230px">
                    <asp:TextBox ID="txtSIncome" Width="100px" MaxLength="8" runat="server" TabIndex="8" onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Other F. Member Income</td>
                <td>:</td>
                <td width="300px">
                    <asp:TextBox ID="txtFMIncome" Width="100px" MaxLength="10" runat="server" TabIndex="9" onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);"></asp:TextBox>
                </td>
                <td width="40px"></td>
                <td width="130px">Moveable Property</td>
                <td width="20px">:</td>
                <td width="230px">
                    <asp:TextBox ID="txtMProperty" Width="200px" MaxLength="45" runat="server" TabIndex="10"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Immoveable Property</td>
                <td>:</td>
                <td width="300px">
                    <asp:TextBox ID="txtIProperty" Width="200px" MaxLength="45" runat="server" TabIndex="11"></asp:TextBox>
                </td>
                <td width="40px"></td>
                <td width="130px">Saving</td>
                <td width="20px">:</td>
                <td width="230px">
                    <asp:TextBox ID="txtSaving" Width="100px" MaxLength="10" runat="server" TabIndex="12" onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td colspan="5" align="left">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        TabIndex="13" onclick="btnSubmit_Click" />
                    &nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="14" 
                        Enabled="False" onclick="btnUpdate_Click" />
                    &nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
