<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Cash_Book.aspx.cs" Inherits="MuslimAID.MURABHA.Cash_Book" Title="Ventura Crystal Investments Ltd ::: Cash Book - MF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDateFrom.ClientID %>").dynDateTime({
                showsTime: false,
                ifFormat: "%Y-%m-%d",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDateTo.ClientID %>").dynDateTime({
                showsTime: false,
                ifFormat: "%Y-%m-%d",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <script type="text/javascript">
    function PrintGridData() {
    var prtGrid = document.getElementById('<%=grvInstaDeta.ClientID %>');
    prtGrid.border = 1;
    prtGrid.style.fontSize="10pt";
    prtGrid.style.fontFamily="Calibri";
    var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
    prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>MF Client Basic Details Report - Ventura Crystal Investments Ltd</div>");
    prtwin.document.write(prtGrid.outerHTML);
    prtwin.document.close();
    prtwin.focus();
    prtwin.print();
    prtwin.close();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
            <tr>
                <td colspan="9" width="860px" class="PageTitle">Cash Book - MF</td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td width="100px">Status</td>
                <td width="20px" align="left">:</td>
                <td>
                    <asp:DropDownList ID="cmbStatus" runat="server">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>Approved</asp:ListItem>
                        <asp:ListItem>Unapproved</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td width="30px"></td>
                <td width="120px">Date Eg:(2014-01-28)</td>
                <td width="20px">:</td>
                <td>
                    <asp:TextBox ID="txtDateFrom" runat="server" Width="95px"></asp:TextBox><img src="../Images/calender.png" /> &nbsp;&nbsp; To &nbsp;&nbsp; <asp:TextBox ID="txtDateTo" runat="server" Width="95px"></asp:TextBox><img src="../Images/calender.png" /> 
                    
                </td>
                <td width="30px"></td>
                <td>
                    <asp:Button ID="btnSerch" runat="server" Text="Search" 
                        onclick="btnSerch_Click"  />
                        <input type="button" id="btnPrint" value="Print" onclick="PrintGridData()" />
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9" valign="top">
                    <table cellpadding="0" cellspacing="0" border="0" width="860px">
                        <tr>
                            <td width="420px" valign="top">
                                <asp:Panel ID="pnlInstaDeta" runat="server">
                                    <asp:GridView ID="grvInstaDeta" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="grvInstaDeta_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="date_time" HeaderStyle-Width="170px" ItemStyle-VerticalAlign="Top" HeaderText="Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="idpais_history" HeaderStyle-Width="100px" ItemStyle-VerticalAlign="Top" HeaderText="Rec.No." ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="paied_amount" HeaderStyle-Width="120px" ItemStyle-VerticalAlign="Top" HeaderText="Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                            <td width="20px"></td>
                            <td width="420px" valign="top">
                                <asp:Panel ID="pnlLoanDeta" runat="server">
                                    <asp:GridView ID="grvLoanDeta" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="grvLoanDeta_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="chequ_deta_on" HeaderStyle-Width="200px" ItemStyle-VerticalAlign="Top" HeaderText="Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="chequ_no" HeaderStyle-Width="100px" ItemStyle-VerticalAlign="Top" HeaderText="Cheque No." ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="chequ_amount" HeaderStyle-Width="120px" ItemStyle-VerticalAlign="Top" HeaderText="Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px">
                    <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                    <asp:HiddenField ID="hstrSelectQuery2" runat="server" />
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
