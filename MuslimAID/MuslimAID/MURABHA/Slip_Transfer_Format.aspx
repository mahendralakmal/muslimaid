<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Slip_Transfer_Format.aspx.cs" Inherits="MuslimAID.MURABHA.Slip_Transfer_Format" Title="Ventura Crystal Investments Ltd ::: Slip Transfer Format" %>
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
    var prtGrid = document.getElementById('<%=grvCliDeta.ClientID %>');
    prtGrid.border = 1;
    prtGrid.style.fontSize="10pt";
    prtGrid.style.fontFamily="Calibri";
    var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
    prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>CS Slip Transfer Format - Ventura Crystal Investments Ltd</div>");
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
                <td colspan="9" width="860px" class="PageTitle">CS - Slip Transfer Format</td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9">
                    <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                        <tr>
                            <td>Branch Code : </td>
                            <td width="100px">
                                <asp:DropDownList ID="cmbCityCode" Width="100px" TabIndex="0" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td width="10px"></td>
                            <td width="30px">Date</td>
                            <td width="20px">:</td>
                            <td>
                                <asp:TextBox ID="txtDateFrom" runat="server" Width="65px" MaxLength="10"></asp:TextBox><img src="../Images/calender.png" /> 
                                &nbsp;&nbsp; To &nbsp;&nbsp; 
                                <asp:TextBox ID="txtDateTo" runat="server" Width="65px" MaxLength="10"></asp:TextBox><img src="../Images/calender.png" /> 
                                
                            </td>
                            <td width="30px"></td>
                            <td align="left" width="320px">
                                <asp:Button ID="btnSerch" runat="server" Text="Search" onclick="btnSerch_Click" />
                                    <input type="button" id="btnPrint" value="Print" onclick="PrintGridData()" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9">
                    <asp:Panel ID="pnlClientDetail" runat="server">
                        <asp:GridView ID="grvCliDeta" runat="server" Font-Size="8pt" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Contract Code" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contract_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;" style="text-decoration:underline;">
                                            <%#Eval("contract_code")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:BoundField DataField="contract_code" ItemStyle-VerticalAlign="Top" HeaderText="Contract Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="nic" ItemStyle-VerticalAlign="Top" HeaderText="NIC" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="initial_name" HeaderText="Name" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="180px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="acc_number" ItemStyle-VerticalAlign="Top" HeaderText="Acc No" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="BankName" ItemStyle-VerticalAlign="Top" HeaderText="Bank" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="BranchName" ItemStyle-VerticalAlign="Top" HeaderText="Branch" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="FORMAT(l.loan_amount,2)" ItemStyle-VerticalAlign="Top" HeaderText="Loan Amount" HeaderStyle-Width="75px" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="Charges" ItemStyle-VerticalAlign="Top" HeaderText="Charges" HeaderStyle-Width="55px" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="Transfer_amount" ItemStyle-VerticalAlign="Top" HeaderText="Transfer Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:TemplateField HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkvalue" runat="server" OnCheckedChanged="chkdele" Checked="true" AutoPostBack="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px">
                    <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="9" align="right">
                    <asp:LinkButton ID="lnkTPayment" runat="server" CssClass="lnk_font_color" onclick="lnkTPayment_Click">Total Transfer Amount</asp:LinkButton> :
                    <asp:Label ID="lblTotal" runat="server" Text="0.00"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9" align="left">
                    <asp:DropDownList ID="cmbBank" runat="server" AutoPostBack="true"
                        onselectedindexchanged="cmbBank_SelectedIndexChanged"></asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="cmbBranch" AutoPostBack="true" runat="server" 
                        onselectedindexchanged="cmbBranch_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="cmbAccNo" runat="server">
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnExport" runat="server" Enabled="false" Text="Export" 
                        onclick="btnExport_Click" />
                        <a ref="#" onclick="javascript:w=window.open(&#039;Slip_Transfer_Format_Export.aspx&#039;,&#039;popup&#039;,&#039;target=_blank,width=1000px,height=600px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;" style="text-decoration:underline;">
                        Export Excel
                    </a>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
