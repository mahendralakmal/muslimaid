<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Business_Details.aspx.cs" Inherits="MuslimAID.MURABHA.Business_Details" Title="Ventura Crystal Investments Ltd ::: Business Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="text-align:left;">
            <tr>
                <td colspan="7" width="860px" class="PageTitle"><b>MF Application - Business Details</b></td>
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
                <td>Business Name</td>
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
                <td valign="top">Business Address</td>
                <td valign="top">:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtBisAddress" Width="280px" CssClass="addressText" Height="70px" TextMode="MultiLine" MaxLength="150" runat="server" TabIndex="10"></asp:TextBox>
                </td>
                <td valign="top">Bissiness Population<span style="color:Red;">*</span></td>
                <td valign="top">:</td>
                <td valign="top">
                    <asp:DropDownList ID="cmbBPopulation" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Stabilize</asp:ListItem>
                        <asp:ListItem>Strong</asp:ListItem>
                        <asp:ListItem>Growing</asp:ListItem>
                        <asp:ListItem>Potential to grow</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Business Income<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtBIncome" Width="100px" runat="server" TabIndex="8" AutoPostBack="true" OnTextChanged="txtBIncome_TextChanged"></asp:TextBox>
                </td>
                <td>Other Income<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtOIncome" Width="100px" runat="server" TabIndex="8" AutoPostBack="true" OnTextChanged="txtOIncome_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Total Income<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="5" align="left">
                    <asp:TextBox ID="txtTotalIncome" Width="100px" Enabled="false" runat="server" TabIndex="8"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Direct Cost<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtDCost" Width="100px" runat="server" TabIndex="8" AutoPostBack="true" OnTextChanged="txtDCost_TextChanged"></asp:TextBox>
                </td>
                <td>Indirect Cost<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtICost" Width="100px" runat="server" TabIndex="8" AutoPostBack="true" OnTextChanged="txtICost_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Other Expenses<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtOExpenses" Width="100px" runat="server" TabIndex="8" AutoPostBack="true" OnTextChanged="txtOExpenses_TextChanged"></asp:TextBox>
                </td>
                <td>Total Expenses<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtTExpenses" Width="100px" Enabled="false" runat="server" TabIndex="8"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Business P and L<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="2" align="left">
                    <asp:TextBox ID="txtPAndL" Width="100px" Enabled="false" runat="server" TabIndex="8"></asp:TextBox>
                </td>
                <td>Family Expenses<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtFExpenses" Width="100px" runat="server" TabIndex="8" AutoPostBack="true" OnTextChanged="txtFExpenses_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td>Net Cash in Hand<span style="color:Red;">*</span></td>
                <td>:</td>
                <td colspan="5" align="left">
                    <asp:TextBox ID="txtNetIncome" Width="100px" Enabled="false" runat="server" TabIndex="8"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" height="10px"></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td colspan="5" align="left">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Enabled="false" TabIndex="11" OnClick="btnSubmit_Click" />
                    &nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="12" 
                        Enabled="False" onclick="btnUpdate_Click" />
                    &nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
