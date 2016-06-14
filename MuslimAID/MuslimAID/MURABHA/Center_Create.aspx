<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Center_Create.aspx.cs" Inherits="MuslimAID.MURABHA.Center_Create"
    Title="Ventura Crystal Investments Ltd ::: Create a Center" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="text-align: left;">
            <tr>
                <td colspan="3" width="860px" class="PageTitle">
                    <b>MF Application - Create a Center</b>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td>
                    City Code<span style="color: Red;">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="cmbCityCode" TabIndex="1" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="cmbCityCode_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td>
                    Village<span style="color: Red;">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="cmbVillages" runat="server" TabIndex="2" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td width="120px">
                    Center Name<span style="color: Red;">*</span>
                </td>
                <td width="20px" align="left">
                    :
                </td>
                <td width="720px">
                    <asp:TextBox ID="txtCenterName" Width="300px" AutoPostBack="true" TabIndex="3" runat="server"
                        OnTextChanged="txtCenterName_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td>
                    Leader Name<span style="color: Red;">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtLName" TabIndex="4" Width="300px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td>
                    Leader Contact No<span style="color: Red;">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtContactNo" TabIndex="5" MaxLength="10" Width="100px" runat="server"
                        onkeydown="return isNumeric(event.keyCode);" onKeypress="javascript:return check(event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td>
                    Center Day<span style="color: Red;">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <%--<asp:TextBox ID="txtCenDate" TabIndex="2" Width="100px" runat="server"></asp:TextBox>
                    <img src="../Images/calender.png" />--%>
                    <asp:DropDownList ID="cmbCenterDay" runat="server" TabIndex="6" >
                        <asp:ListItem Value="MO">Monday</asp:ListItem>
                        <asp:ListItem Value="TU">Tuesday</asp:ListItem>
                        <asp:ListItem Value="WE">Wednsday</asp:ListItem>
                        <asp:ListItem Value="TH">Thursday</asp:ListItem>
                        <asp:ListItem Value="FR">Friday</asp:ListItem>
                        <asp:ListItem Value="SA">Saturday</asp:ListItem>
                        <asp:ListItem Value="SU">Sunday</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Enabled="false" OnClick="btnSubmit_Click" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
