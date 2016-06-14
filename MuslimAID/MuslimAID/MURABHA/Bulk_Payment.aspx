<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Bulk_Payment.aspx.cs" Inherits="MuslimAID.MURABHA.Bulk_Payment" Title="Ventura Crystal Investments Ltd ::: Bulk Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
            <tr>
                <td colspan="9" width="860px" class="PageTitle">Weekly Payment - MF</td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr align="left">
                <td width="100px">City Code</td>
                <td width="20px" align="left">:</td>
                <td width="200px">
                    <asp:DropDownList ID="cmbCityCode" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="cmbCityCode_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td width="30px"></td>
                <td width="100px">Society ID</td>
                <td width="20px" align="left">:</td>
                <td width="100px">
                    <asp:DropDownList ID="cmbSocietyID" runat="server">
                    </asp:DropDownList>
                </td>
                <td width="30px"></td>
                <td width="260px" align="left">
                    <asp:Button ID="btnSerch" runat="server" Text="Search" 
                        onclick="btnSerch_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9" valign="top"> 
                    <asp:Panel ID="pnlPayment" runat="server" Visible="false">
                        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="grvPayment" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="contract_code" ItemStyle-VerticalAlign="Top" HeaderText="Contract Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <%--<asp:TemplateField HeaderText="Contract Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contract_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;" style="text-decoration:underline;">
                                                        <%#Eval("contract_code")%>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:BoundField DataField="ca_code" ItemStyle-VerticalAlign="Top" HeaderText="CA Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="nic" ItemStyle-VerticalAlign="Top" HeaderText="NIC" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="initial_name" ItemStyle-VerticalAlign="Top" HeaderText="Name" HeaderStyle-Width="260px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="monthly_instollment" ItemStyle-VerticalAlign="Top" HeaderText="Installment" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:TemplateField HeaderText="Paid Amount" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPaidAmount" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="" HeaderText="Paid Amount" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="180px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />--%>
                                            <asp:BoundField DataField="current_loan_amount" ItemStyle-HorizontalAlign="Right"  ItemStyle-VerticalAlign="Top" HeaderText="Balance" HeaderStyle-Width="100px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" height="10px"></td>
                            </tr>
                            <tr>
                                <td width="530px"></td>
                                <td align="left" width="230px">
                                    <b>
                                        <asp:LinkButton ID="lnkTPayment" runat="server" CssClass="lnk_font_color" onclick="lnkTPayment_Click">Total Payment</asp:LinkButton> :
                                    </b> <asp:Label ID="lblTotalPaied" runat="server"></asp:Label>
                                </td>
                                <td width="100px" align="left">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                                        onclick="btnSubmit_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px">
                    <asp:HiddenField ID="hstrSelectQuery" runat="server" />
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
