<%@ Page Language="C#" MasterPageFile="~/MURABHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Arrears_Report.aspx.cs" Inherits="MuslimAID.MURABHA.Arrears_Report" Title="Ventura Crystal Investments Ltd ::: Micro Arrears Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintGridData() {
        var prtGrid = document.getElementById('ArreDeta');
        prtGrid.border = 1;
        prtGrid.style.fontSize="10pt";
        prtGrid.style.fontFamily="Calibri";
        var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
        prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>Ventura ::: MF</div>");
        prtwin.document.write(prtGrid.outerHTML);
        prtwin.document.close();
        prtwin.focus();
        prtwin.print();
        prtwin.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" id="ArreDeta">
        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="font-family:Calibri; font-size:10pt; text-align:left;">
            <tr>
                <td colspan="10" width="860px" class="PageTitle">CS - Arrears Details Report</td>
            </tr>
            <tr>
                <td colspan="10" height="10px"></td>
            </tr>
            <tr>
                <td colspan="10">
                    <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                        <tr>
                            <td>B. Code : </td>
                            <td width="100px">
                                <asp:DropDownList ID="cmbCityCode" Width="100px" TabIndex="0" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td width="10px"></td>
                            <td width="86px">Contract Code : </td>
                            <td width="80px">
                                <asp:TextBox ID="txtContraCode" Width="80px" runat="server" MaxLength="9"></asp:TextBox>
                            </td>
                            <td width="10px"></td>
                            <td width="50px">Status : </td>
                            <td width="80px">
                                <asp:DropDownList Width="75px" ID="cmbStatus" runat="server">
                                    <asp:ListItem Value="A">All</asp:ListItem>
                                    <asp:ListItem Value="D">Contract to expire</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="10px"></td>
                            <td width="200px">Arrears Count : 
                                <asp:DropDownList ID="cmbACount" Width="80px" runat="server">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">Up to 1</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            
                            <td>
                                <asp:Button ID="btnSerch" Width="55px" runat="server" Text="Search" onclick="btnSerch_Click" 
                                     />
                                    <input type="button" id="btnPrint" value="Print" onclick="PrintGridData()" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="10" height="10px"></td>
            </tr>
            <tr>
                <td colspan="10">
                    <asp:Panel ID="pnlARep" runat="server">
                        <%--<asp:GridView ID="grvArRep" Font-Size="10pt" runat="server" BorderColor="White" Width="860px" HeaderStyle-BackColor="#006699" onpageindexchanging="grvArRep_PageIndexChanging">
                            <Columns></Columns>
                        </asp:GridView>--%>
                        <asp:GridView ID="grvArRep" Font-Size="8pt" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contract Code" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contra_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;" style="text-decoration:underline;">
                                            <%#Eval("contra_code")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="contra_code" ItemStyle-VerticalAlign="Top" HeaderText="Contract Code" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />--%>
                                <asp:BoundField DataField="initial_name" ItemStyle-VerticalAlign="Top" HeaderText="Name" HeaderStyle-Width="160px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10pt" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="p_address" ItemStyle-VerticalAlign="Top" HeaderText="Address" HeaderStyle-Width="240px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="mobile_no" ItemStyle-VerticalAlign="Top" HeaderText="Mobile" HeaderStyle-Width="90px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="FORMAT(l.monthly_instollment,2)" ItemStyle-VerticalAlign="Top" HeaderText="Installment" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="FORMAT(l.arres_amou,2)" ItemStyle-VerticalAlign="Top" HeaderText="Total Arrears" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="FORMAT(l.def,2)" HeaderText="Default" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="60px" HeaderStyle-BackColor="#006699" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="arres_count" ItemStyle-VerticalAlign="Top" HeaderText="Count" HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="DATE_FORMAT(l.due_date, '%Y-%m-%d')" HeaderText="Date" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="100px" HeaderStyle-BackColor="#006699" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                <asp:BoundField DataField="DATE_FORMAT(l.chequ_deta_on, '%Y-%m-%d')" HeaderText="Gra Date" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="90px" HeaderStyle-BackColor="#006699" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="10" height="10px"></td>
            </tr>
            <tr>
                <asp:Panel ID="pnlSummery" runat="server" Visible="false">
                    <td colspan="10" align="left" style="text-align:left;">
                        <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left">
                            <tr>
                                <td width="20px"></td>
                                <td width="150px">No Of Arrears</td>
                                <td width="20px">:</td>
                                <td width="100px">
                                    <asp:Label ID="lblNoArres" runat="server"></asp:Label>
                                </td>
                                <td width="50px"></td>
                                <td width="100px">Arrears Amount</td>
                                <td width="20px">:</td>
                                <td width="400px" align="left">
                                    <asp:Label ID="lblArreAmount" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </asp:Panel>
            </tr>
            <tr>
                <td colspan="10" height="10px">
                    <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                    <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="10">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
