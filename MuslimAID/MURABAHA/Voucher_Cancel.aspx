<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Voucher_Cancel.aspx.cs" Inherits="MuslimAID.MURABAHA.Voucher_Cancel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('prt');
            //prtGrid.border = 1;
            //prtGrid.style.fontSize="12pt";
            prtGrid.style.fontFamily = "Calibri";
            var prtwin = window.open('', 'PrintGridViewData', 'left=0px,top=0px,right=0px,bottom=0px,width=672.755906px,height=340.15748px,tollbar=0,scrollbars=1,status=0,resizable=1');
            //prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'> MUSLIM AID MICRO CREDIT (GUARANTEE) LIMITED </div>");
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container">
    <div class="PageTitle"><h4>Voucher Cancel</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-7">
            <div class="form-group">
                <div class="col-md-5">Voucher No <span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox CssClass="form-control" ID="txtRNo" MaxLength="15" AutoPostBack="true" runat="server" Width="110px" 
                        TabIndex="0" ontextchanged="txtRNo_TextChanged" ></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-7">
            <div class="form-group">
                <div class="col-md-5">Facility Code</div>
                <div class="col-md-7">
                    <asp:Label ID="lblContractCode" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="col-md-7">
            <div class="form-group">
                <div class="col-md-5">NIC</div>
                <div class="col-md-7">
                    <asp:Label ID="lblNIC" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="col-md-7">
            <div class="form-group">
                <div class="col-md-5">Name</div>
                <div class="col-md-7">
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="col-md-7">
            <div class="form-group">
                <div class="col-md-5">Amount</div>
                <div class="col-md-7">
                    <asp:Label ID="lblAmount" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="col-md-7">
            <div class="form-group">
                <div class="col-md-5">Comment <span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:TextBox CssClass="form-control" ID="txtComment" runat="server" Width="300px" TextMode="MultiLine" Height="75px"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-7">
            <div class="form-group">
                <div class="col-md-12">
                    <asp:Button ID="btnPeied" runat="server" Enabled="false" TabIndex="3" 
                        Text="Cancel" onclick="btnPeied_Click" />&nbsp;
                        <input id="btnPrint0" onclick="PrintGridData()" type="button" value="Print" />
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <asp:Panel ID="pnlVoucher" runat="server" Visible="true">
                <div align="center" id="prt">
                    <table id="tblVoucher" cellpadding="0" cellspacing="0" border="0px" width="860px"
                        align="left">
                        <tr>
                            <td colspan="7" align="center">
                                <asp:Label ID="lblComName" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" align="center">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" align="center">
                                <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Paid To
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblPaidTo" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                                Voucher No
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblVoucherNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Date
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                                User ID
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblUserID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" width="860px" align="center">
                                <asp:GridView ID="grdVoucherBody" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top"
                                    ShowHeader="False" Width="860px">
                                    <Columns>
                                        <asp:BoundField DataField="ChequeNo" ItemStyle-VerticalAlign="Top" HeaderText="Cheque No"
                                            HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                            ReadOnly="true">
                                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FacilityNo" ItemStyle-VerticalAlign="Top" HeaderText="Facility No"
                                            HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                            ReadOnly="true">
                                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="600px"
                                            HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                            ReadOnly="true">
                                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="600px" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="100px"
                                            HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                            ReadOnly="true">
                                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="100px" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle BorderStyle="Inset" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" height="10px" align="left">
                                <asp:Label ID="Label2" runat="server" Text="Debit" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <asp:GridView ID="grdApproval" runat="server" Height="100px" ShowHeader="False" Width="860px"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="p1" HeaderText="p1" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Bold="true"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="140px" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true">
                                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="140px" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="140px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="p2" HeaderText="p2" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Bold="true"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="140px" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true">
                                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="140px" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="140px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="p3" HeaderText="p3" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Bold="true"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="140px" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true">
                                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="140px" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="140px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="p4" HeaderText="p4" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Bold="true"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="140px" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true">
                                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="140px" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="140px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="p5" HeaderText="p5" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Bold="true"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="140px" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true">
                                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="140px" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="140px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="p6" HeaderText="p6" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Bold="true"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="160px" HeaderStyle-BackColor="#009905"
                                            HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true">
                                            <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="160px" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="160px" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" height="10px" align="left">
                                <asp:Label ID="Label3" runat="server" Text="Received" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" height="60px">
                                <table border="0px">
                                    <tr>
                                        <td colspan="4" height="60px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="210px" height="10px">
                                            ____________________
                                        </td>
                                        <td width="210px">
                                            ____________________
                                        </td>
                                        <td width="210px">
                                            ____________________
                                        </td>
                                        <td width="210px">
                                            ____________________
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10px">
                                            Date
                                        </td>
                                        <td>
                                            Signature
                                        </td>
                                        <td>
                                            Name
                                        </td>
                                        <td>
                                            N.I.C. No
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
