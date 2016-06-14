<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Basic_Details_Report.aspx.cs" Inherits="MuslimAID.MURABHA.Basic_Details_Report" Title="Ventura Crystal Investments Ltd ::: Basic Details Report" %>
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
    prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>CS Client Basic Details Report - Ventura Crystal Investments Ltd</div>");
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
                <td colspan="9" width="860px" class="PageTitle">CS - Client Basic Details Report</td>
            </tr>
            <tr>
                <td colspan="9" height="10px"></td>
            </tr>
            <tr>
                <td colspan="9">
                    <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                        <tr>
                            <td>CRO : </td>
                            <td><asp:DropDownList ID="ddlCro" Width="100px" TabIndex="0" runat="server">
                                </asp:DropDownList></td>
                            <td>Center : </td>
                            <td><asp:DropDownList ID="ddlCenter" Width="100px" TabIndex="0" runat="server">
                                </asp:DropDownList></td>
                            <%--<td>Branch Code : </td>
                            <td width="100px">
                                <asp:DropDownList ID="cmbCityCode" Width="100px" TabIndex="0" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td width="10px"></td>
                            <td width="90px">Contract Code</td>
                            <td width="10px" align="left">:</td>
                            <td>
                                <asp:TextBox ID="txtContraCode" Width="100px" runat="server" MaxLength="12"></asp:TextBox>
                            </td>--%>
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
                <td colspan="9">
                    <asp:Panel ID="pnlClientDetail" runat="server">
                        <asp:GridView ID="grvCliDeta" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top" Font-Size="8pt">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GROUP" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("GROUP")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;" style="text-decoration:underline;">
                                            <%#Eval("GROUP")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="contract_code" ItemStyle-VerticalAlign="Top" HeaderText="Contract Code" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />--%>
                                <asp:BoundField DataField="contra_code" ItemStyle-VerticalAlign="Top" HeaderText="Customer Code" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="full_name" ItemStyle-VerticalAlign="Top" HeaderText="Name" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="p_address" ItemStyle-VerticalAlign="Top" HeaderText="Address" HeaderStyle-Width="260px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="land_no" ItemStyle-VerticalAlign="Top" HeaderText="Contact No" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="" ItemStyle-VerticalAlign="Top" HeaderText="Spouse Name" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="" ItemStyle-VerticalAlign="Top" HeaderText="Spouse Contact No" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
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
                <td colspan="9">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
