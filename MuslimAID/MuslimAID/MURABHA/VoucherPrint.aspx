<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="VoucherPrint.aspx.cs" Inherits="MuslimAID.MURABHA.VoucherPrint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
            <tr>
                <td colspan="9" width="860px" class="PageTitle">Voucher Printing</td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9">
                    <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                        <tr>                            
                            <td width="90px">Contract Code</td>
                            <td width="10px" align="left">:</td>
                            <td>
                                <asp:TextBox ID="txtContraCode" Width="100px" runat="server" MaxLength="12"></asp:TextBox>
                            </td>
                            
                            <td width="30px"></td>
                            <td>
                                <asp:Button ID="btnSerch" runat="server" Text="Search" 
                                    onclick="btnSerch_Click"  />                                    
                                <asp:Button ID="btnPrint" runat="server" Text="Print" onclick="btnPrint_Click" 
                                    />                                    
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9" valign="top">
                    <asp:Panel ID="pnlChqDetail" runat="server" Visible="true">
                        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                            <tr>
                                <td width="860px">
                                    <asp:GridView ID="gdvVoucher" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top">
                                        <Columns>                                            
                                            <asp:BoundField DataField="voucher_no" ItemStyle-VerticalAlign="Top" HeaderText="Voucher No" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="contract_code" ItemStyle-VerticalAlign="Top" HeaderText="Contract Code" HeaderStyle-Width="260px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="voucher_date" HeaderText="Coucher Date" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            
                                            <%--<asp:BoundField DataField="mobile_no" ItemStyle-VerticalAlign="Top" HeaderText="Mobile No" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />--%>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px"></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px">
                    <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                    <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="9">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
