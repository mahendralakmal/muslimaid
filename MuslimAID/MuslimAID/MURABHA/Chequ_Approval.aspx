<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Chequ_Approval.aspx.cs" Inherits="MuslimAID.MURABHA.Chequ_Approval" Title="Ventura Crystal Investments Ltd ::: Chequ Approval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
            <tr>
                <td width="860px" class="PageTitle">Cheque Approval</td>
            </tr>
            <tr>
                <td height="10px"></td>
            </tr>
            <tr>
                <td align="left">
                    Society No : 
                    <asp:DropDownList ID="cmdSocietyNo" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" 
                        onclick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td height="10px"></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grvChequAppr" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contract Code" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contra_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;" style="text-decoration:underline;">
                                        <%#Eval("contra_code")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="contra_code" HeaderText="Contract Code" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />--%>
                            <asp:BoundField DataField="period" HeaderText="Period" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="loan_amount" HeaderText="Loan Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="110px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="interest_amount" HeaderText="Total Interest" HeaderStyle-Width="110px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:TemplateField HeaderStyle-ForeColor="#006699" HeaderStyle-Width="100px" HeaderStyle-BorderColor="White">
                                <ItemTemplate>
                                    <a ref="#" onclick="javascript:w=window.open(&#039;ViewChequDetails.aspx?ConCode=<%#Eval("contra_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=520px,height=300px,scrollbars=no,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;" style="text-decoration:underline;">
                                        Click Here
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td height="10px"></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
