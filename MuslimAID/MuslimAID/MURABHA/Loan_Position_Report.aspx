<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Loan_Position_Report.aspx.cs" Inherits="MuslimAID.MURABHA.Loan_Position_Report" Title="Ventura Crystal Investments Ltd ::: Loan Position Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function PrintGridData() {
    var prtGrid = document.getElementById('mir');
    prtGrid.border = 1;
    prtGrid.style.fontSize="10pt";
    prtGrid.style.fontFamily="Calibri";
    var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
    prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>One Asia Finance PLC</div>");
    prtwin.document.write(prtGrid.outerHTML);
    prtwin.document.close();
    prtwin.focus();
    prtwin.print();
    prtwin.close();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" id="mir">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="font-family:Calibri; font-size:8pt; text-align:left;">
            <tr>
                <td colspan="9" width="860px" class="PageTitle">CS - Loan Position Report</td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9">
                    <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                            <tr>
                                <td>Company :</td>
                                <td width="10px"></td>
                                <td>
                                    <asp:DropDownList ID="cmbCompany" TabIndex="0" runat="server" Enabled="true">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="PCA">PCA</asp:ListItem>
                                        <asp:ListItem Value="OA">OA</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td width="20px"></td>
                                <td>Branch Code : </td>
                                <td width="10px"></td>
                                <td width="90px">
                                    <asp:DropDownList ID="cmbCityCode" TabIndex="1" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td width="20px"></td>
                                <td width="60px"></td>
                                <td width="100px"></td>
                                <td width="100px"></td>
                                <td>
                                    <asp:Button ID="btnSerch" runat="server" Text="Search" onclick="btnSerch_Click" TabIndex="5"  />
                                        <input type="button" id="btnPrint" TabIndex="6" value="Print" onclick="PrintGridData()" />
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
                    <asp:Panel ID="pnlMIns" runat="server">
                        <asp:GridView ID="grvMIn" Font-Size="8pt" runat="server" HeaderStyle-BackColor="#006699" 
                                HeaderStyle-HorizontalAlign="Center" BorderColor="White" 
                                Width="860px" onrowdatabound="grvMIn_RowDataBound" ItemStyle-VerticalAlign="Top">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9" valign="top">
                    <asp:Panel ID="pnlSummery" runat="server" Visible="false">
                        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="font-family:Calibri; font-size:7pt; text-align:left;">
                            <tr>
                                <td>Loan Disbursement : 
                                    <asp:Label ID="lblLA" runat="server"></asp:Label>
                                </td>
                                <td width="20px"></td>
                                <td>S. Charges : 
                                    <asp:Label ID="lblSC" runat="server"></asp:Label>
                                </td>
                                <td width="20px"></td>
                                <td>Due Amount : 
                                    <asp:Label ID="lblDA" runat="server"></asp:Label>
                                </td>
                                <td width="20px"></td>
                                <td>Paid Amount : 
                                    <asp:Label ID="lblPA" runat="server"></asp:Label>
                                </td>
                                <td width="20px"></td>
                                <td>O. Payment : 
                                    <asp:Label ID="lblOp" runat="server"></asp:Label>
                                </td>
                                <td width="20px"></td>
                                <td>Loan Balance : 
                                    <asp:Label ID="lblLBalance" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="11" height="10px"></td>
                            </tr>
                            <tr>
                                <td colspan="11" align="left">
                                    Recovery Rate : 
                                    <asp:Label ID="lblTRR" runat="server"></asp:Label> %
                                </td>
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
