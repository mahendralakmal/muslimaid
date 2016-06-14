<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Promisers_Details.aspx.cs" Inherits="MuslimAID.MURABHA.Promisers_Details" Title="Ventura Crystal Investments Ltd ::: Promisers Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="text-align:left;">
            <tr>
                <td colspan="7" width="860px" class="PageTitle"><b>MF Application - Promisers Details</b></td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td width="160px">Contract Code<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="300px">
                    <asp:TextBox ID="txtCC" Width="100px" MaxLength="10" Enabled="false" runat="server" TabIndex="0"></asp:TextBox>
                </td>
                <td width="40px"></td>
                <td width="130px">C. Applicant Code<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td width="230px">
                    <asp:TextBox ID="txtCACode" Width="100px" MaxLength="10" Enabled="false" runat="server" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td width="160px">Promisers NIC<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td colspan="4" align="left">
                    <asp:TextBox ID="txtNIC" Width="100px" MaxLength="10" runat="server" TabIndex="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td width="160px">Full Name<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td colspan="4" align="left">
                    <asp:TextBox ID="txtName" Width="100px" MaxLength="10" runat="server" TabIndex="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Marital Status<span style="color:Red;">*</span></td>
                <td>:</td>
                <td align="left" colspan="2">
                    <asp:RadioButton ID="rdoMarried" Text="Married" runat="server" TabIndex="3" Checked="True" GroupName="rdoSingle" /><asp:RadioButton ID="rdoSingle" TabIndex="11"
                                        Text="Single" runat="server" />
                </td>
                <td>GS Ward<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtGSWard" Width="130px" MaxLength="45" runat="server" TabIndex="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Telephone No<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtTNo" runat="server" TabIndex="5"></asp:TextBox>
                </td>
                <td width="130px">Mobile No<span style="color:Red;">*</span></td>
                <td width="20px">:</td>
                <td>
                    <asp:TextBox ID="txtMobileNo" runat="server" TabIndex="6"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td valign="top">Permanet Address<span style="color:Red;">*</span></td>
                <td valign="top">:</td>
                <td colspan="5" align="left">
                    <asp:TextBox ID="txtAddress" Width="280px" CssClass="addressText" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="7"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Business/Self Employment<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtBuss" Width="150px" runat="server" TabIndex="8"></asp:TextBox>
                </td>
                <td>Duration In Business<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:DropDownList ID="cmbPeriod" runat="server" TabIndex="9">
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
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td valign="top">Business Address<span style="color:Red;">*</span></td>
                <td valign="top">:</td>
                <td colspan="5" align="left">
                    <asp:TextBox ID="txtBisAddress" Width="280px" CssClass="addressText" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="10"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td colspan="5" align="left">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Enabled="false" TabIndex="11" />
                    &nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="12" 
                        Enabled="False" />
                    &nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
