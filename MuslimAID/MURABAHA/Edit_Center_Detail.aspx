<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Edit_Center_Detail.aspx.cs" Inherits="MuslimAID.MURABAHA.Edit_Center_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container>
    <div class="PageTitle"><h4>MF Application - Edit Center Detail</h4></div>
    <div class="col-md-6 form-container">
        <div class="form-group">
            <div class="col-md-5">Branch Code<span style="color:Red;">*</span></div>
            <div class="col-md-7">
            <asp:DropDownList ID="cmbCityCode" TabIndex="1" CssClass="form-control" runat="server">
                    </asp:DropDownList>
        </div>
    </div>
</div>
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="text-align:left;">
            <tr>
                <td colspan="3" width="860px" class="PageTitle"><b>MF Application - Edit Center Detail</b></td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Branch Code<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Village<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:DropDownList ID="cmbVillages" runat="server" AutoPostBack="true"
                        onselectedindexchanged="cmbVillages_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td width="120px">Center Name<span style="color:Red;">*</span></td>
                <td width="20px" align="left">:</td>
                <td width="720px">
                    <asp:DropDownList ID="cmbCenterName" runat="server" AutoPostBack="true"
                        onselectedindexchanged="cmbCenterName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Leader Name<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtLName" TabIndex="2" Width="300px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Leader Contact No<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtContactNo" TabIndex="3" MaxLength="10" Width="100px" runat="server" onkeydown="return isNumeric(event.keyCode);"
                            onKeypress="javascript:return check(event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Center Day<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:DropDownList ID="cmbCenterDay" runat="server">
                        <asp:ListItem Value="Monday">Monday</asp:ListItem>
                        <asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
                        <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
                        <asp:ListItem Value="Thursday">Thursday</asp:ListItem>
                        <asp:ListItem Value="Friday">Friday</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Label ID="lblMsg2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Root ID<span style="color:Red;">*</span></td>
                <td>:</td>
                <td>
                    <asp:DropDownList ID="cmbRoot" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Edit" Enabled="false" 
                        onclick="btnSubmit_Click" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
