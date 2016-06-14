<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Agreement.aspx.cs" Inherits="MuslimAID.MURABHA.Agreement" Title="Ventura Crystal Investments Ltd ::: MF - Agreement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        function PopUPCA(){
           var win = window.open('../Agreement/Micro/ca1.aspx','ca1','left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
        }
        
        function PopUPCA2(){
           var win = window.open('../Agreement/Micro/ca2.aspx','ca2','left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="text-align:left;">
            <tr>
                <td width="860px" class="PageTitle"><b>MF Application - Agreement</b></td>
            </tr>
            <tr>
                <td height="10px"></td>
            </tr>
            <tr>
                <td>Contract Code : 
                    <asp:TextBox ID="txtCC" runat="server" AutoPostBack="true" MaxLength="12" 
                        Width="120px" ontextchanged="txtCC_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="10px"></td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Panel ID="pnlAgree" runat="server" Visible="false">
                        <table cellpadding="0" cellspacing="0" border="0" width="860px">
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkPage1" CssClass="lnk_font_color" runat="server" onclick="lnkPage1_Click">Agreement Page 01</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkPage2" CssClass="lnk_font_color" runat="server" onclick="lnkPage2_Click">Agreement Page 02</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlNoAgree" runat="server" Visible="false">
                        <table cellpadding="0" cellspacing="0" border="0" width="860px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblMsg" runat="server"></asp:Label> 
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
