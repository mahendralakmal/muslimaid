<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Cheque_Printing_Report.aspx.cs" Inherits="MuslimAID.MURABHA.Cheque_Printing_Report" Title="Ventura Crystal Investments Ltd ::: Cheque Printing Details Report" %>
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
    var prtGrid = document.getElementById('<%=grvChqDeta.ClientID %>');
    prtGrid.border = 1;
    prtGrid.style.fontSize="10pt";
    prtGrid.style.fontFamily="Calibri";
    var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
    prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>CS Cheque Printing Details Report - Ventura Crystal Investments Ltd</div>");
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
                <td colspan="9" width="860px" class="PageTitle">CS - Cheque Printing Details Report</td>
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
                            <td width="90px">Contract Code</td>
                            <td width="10px" align="left">:</td>
                            <td>
                                <asp:TextBox ID="txtContraCode" Width="100px" runat="server" MaxLength="12"></asp:TextBox>
                            </td>
                            <td width="20px"></td>
                            <td width="30px">Date</td>
                            <td width="20px">:</td>
                            <td>
                                <asp:TextBox ID="txtDateFrom" runat="server" Width="65px" MaxLength="10"></asp:TextBox><img src="../Images/calender.png" /> 
                                &nbsp;&nbsp; To &nbsp;&nbsp; 
                                <asp:TextBox ID="txtDateTo" runat="server" Width="65px" MaxLength="10"></asp:TextBox><img src="../Images/calender.png" /> 
                                
                            </td>
                            <td width="30px"></td>
                            <td>
                                <asp:Button ID="btnSerch" runat="server" Text="Search" 
                                    onclick="btnSerch_Click"  />
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
                <td colspan="9" valign="top">
                    <asp:Panel ID="pnlChqDetail" runat="server" Visible="false">
                        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                            <tr>
                                <td colspan="3" width="860px">
                                    <asp:GridView ID="grvChqDeta" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contract Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contract_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;" style="text-decoration:underline;">
                                                        <%#Eval("contract_code")%>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="contract_code" ItemStyle-VerticalAlign="Top" HeaderText="Contract Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />--%>
                                            <asp:BoundField DataField="format(d.amount,2)" ItemStyle-VerticalAlign="Top" HeaderText="Chq Amount" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="chequ_no" ItemStyle-VerticalAlign="Top" HeaderText="Chq No" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="chq_name" ItemStyle-VerticalAlign="Top" HeaderText="Chq Name" HeaderStyle-Width="260px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="chq_date" HeaderText="Chq Date" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="date_time" ItemStyle-VerticalAlign="Top" HeaderText="Date Time" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <%--<asp:BoundField DataField="mobile_no" ItemStyle-VerticalAlign="Top" HeaderText="Mobile No" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />--%>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" height="10px"></td>
                            </tr>
                            <tr>
                                <td>No of Chq Count :
                                    <asp:Label ID="lblChqCount" runat="server"></asp:Label>
                                </td>
                                <td width="30px"></td>
                                <td>
                                    Total Chq Amount : 
                                    <asp:Label ID="lblChqAmount" runat="server"></asp:Label>
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
