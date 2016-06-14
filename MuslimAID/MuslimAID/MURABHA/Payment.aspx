<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="MuslimAID.MURABHA.Payment" Title="Ventura Crystal Investments Ltd ::: Weekly Installment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PopUP(){
           var win = window.open('Receipt.aspx','Reciept','left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="text-align:left;">
            <tr>
                <td colspan="3" width="860px" class="PageTitle">Pay Weekly Installment</td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td width="130px">Contract Code</td>
                <td width="20px">:</td>
                <td width="710px">
                    <asp:TextBox ID="txtContrCod" MaxLength="12" AutoPostBack="true" runat="server" Width="100px" 
                        TabIndex="0" ontextchanged="txtContrCod_TextChanged" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>NIC</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtNIC" MaxLength="10" Enabled="false" Width="100px" TabIndex="1" ReadOnly="true" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Name</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label> 
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Arrears</td>  
                <td>:</td>
                <td>
                    <asp:Label ID="lblArre" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Full Balance</td>  
                <td>:</td>
                <td>
                    <asp:Label ID="lblFullBala" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Weekly Installment</td>  
                <td>:</td>
                <td>
                    <asp:Label ID="lblMIns" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td>Amount</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtAmount" Width="100px" TabIndex="2" MaxLength="10" runat="server"></asp:TextBox>&nbsp;
                        Eg:(12000.00)
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Price" ValidationExpression="((\d{1,3}(\,\d{3})*)?|(\d+))(\.\d{2})" ControlToValidate="txtAmount"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="10px"></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td>
                    <asp:Button ID="btnPeied" runat="server" Enabled="false" TabIndex="3" 
                        Text="Paied" onclick="btnPeied_Click" />&nbsp;
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
