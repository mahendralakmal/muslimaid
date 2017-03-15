<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Full_Details.aspx.cs" Inherits="MuslimAID.SALAM.Full_Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" media="all" href="../CSS/external.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="800px">
            <tr>
                <td width="800px" class="main_title"><b> MUSLIM AID MICRO CREDIT (GUARANTEE) LIMITED </b></td>
            </tr>
            <tr>
                <td class="sub_title">
                    MF Full Details - (Contract Code <asp:Label ID="lblCC" runat="server"></asp:Label> / Capital Aplicant Code <asp:Label ID="lblCACode" runat="server"></asp:Label>)
                </td>
            </tr>
            <tr>
                <td height="10px"></td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" width="800px">
            <tr>
                <td width="20px"></td>
                <td width="760px" valign="top">
                    <table cellpadding="0" cellspacing="0" border="0" width="760px" style="text-align:left;">
                        <tr>
                            <td colspan="3" width="760px" align="center">
                                <asp:Panel ID="pnlNoImg" runat="server" Visible="false">
                                    <asp:Label ID="lblImgMsg" runat="server"></asp:Label>
                                </asp:Panel>
                                <asp:Panel ID="pnlImg" runat="server" Visible="false">
                                    <asp:Repeater ID="rpImg" runat="server">
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="width:760px;" align="center">
                                                        <img src='<%#Eval("cli_photo") %>' alt="" width="100px" height="120px" />
                                                            &nbsp;&nbsp;
                                                        <img src='<%#Eval("bb_photo") %>' alt="" width="100px" height="120px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left"><b>Client Basic Details</b></td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Name</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>NIC</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblNIC" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>Acc Name</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblAccName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>Acc No</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblAccNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>Bank Name</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblBankName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>Branch</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblBranch" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>Address</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>Mobile Number</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblMobNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>Land Number</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblLandNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>Education</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblEducation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>Marital Status</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblMStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>Inspection Date</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblInsDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="20px"></td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left"><b>Promiser Details</b></td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">ID</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblProID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Name</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblProName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>NIC</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblProNIC" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>Address</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblProAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td>Mobile Number</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblProMob" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left"><b>Family Details</b></td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Spouse NIC</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblSpouseNIC" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Mobile No</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Spouse Name</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblSName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Spouse Occupation</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblOccupation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Dependers</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblSDenders" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Spouse Income</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblSIncome" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Other Member Income</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblOMemIncoem" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Moveable Property</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblMovProperty" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Immoveable Property</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblImmPrope" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Saving</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblSaving" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left"><b>Business Details</b></td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Business Name</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblBName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Business Duration</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblBDuration" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Business Address</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblBAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Business Income</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblBIncome" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Business Other Income</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblBOIncome" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Business Total Income</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblBTIncome" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Business Direct Cost</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblBDCost" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Business Indirect Cost</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblBICost" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Business Other Expenses</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblBOExpenses" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Business Total Expenses</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblBTExpenses" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Business P & L</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblBPL" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Business Family Expenses</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblFExpenses" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Net Income</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblNetIncome" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left"><b>Loan Details</b></td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Loan Amount</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblLAmount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Service Charge</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblSCharge" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Other Charge</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblOCharge" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                                                <tr>
                            <td width="180px">Welfare Fee</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblWelfareFee" runat="server"></asp:Label>
                            </td>
                        </tr>
                                                <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                                                <tr>
                            <td width="180px">Registration Fee</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblRegistrationFee" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Interest Rate</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblIRate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Interest Amount</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblIAmount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Period</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblPeriod" runat="server"></asp:Label> Week
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px"></td>
                        </tr>
                        <tr>
                            <td width="180px">Weekly Installment</td>
                            <td width="15px">:</td>
                            <td width="565px">
                                <asp:Label ID="lblWInstallment" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10px">
                                <asp:HiddenField ID="hstrSelectQueryImg" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                Auto Printed.
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="20px"></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
