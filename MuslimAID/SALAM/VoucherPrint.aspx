<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true"
    CodeBehind="VoucherPrint.aspx.cs" Inherits="MuslimAID.SALAM.VoucherPrint" %>

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

    <style type="text/css">
        .style1
        {
            width: 641px;
        }
        .style2
        {
            width: 251px;
        }
        .style3
        {
            width: 76px;
        }
        .style4
        {
            width: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Voucher Printing</h4></div>
    <div class="col-md-9 form-container">
     <asp:Panel ID="pnlVoucherDetail" runat="server" Visible="true">
        <div class="form-group">
            <div class="col-md-5">Branch <span style="color: Red;">*</span></div>
            <div class="col-md-7">
                <asp:DropDownList ID="cmbBranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbBranch_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-5">Society No <span style="color: Red;">*</span></div>
            <div class="col-md-7">
                <asp:DropDownList ID="cmdSocietyNo" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div><div class="form-group">
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnSearch_Click" /></div>    
        
        <div class="form-group">
             <asp:GridView ID="grvChequAppr" runat="server" AutoGenerateColumns="false" OnRowCommand="grvChequAppr_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                                HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Facility Code" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contra_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;"
                                                        style="text-decoration: underline;">
                                                        <%#Eval("contra_code")%>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="initial_name" HeaderText="Name" HeaderStyle-Width="200px"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="chequ_no" HeaderText="Cheque No" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="period" HeaderText="Period" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                                ReadOnly="true" />
                                            <asp:BoundField DataField="loan_amount" HeaderText="Loan Amount" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="110px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:BoundField DataField="interest_amount" HeaderText="Total Interest" HeaderStyle-Width="110px"
                                                ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White"
                                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                                            <asp:TemplateField HeaderStyle-ForeColor="#009905" HeaderStyle-Width="100px" HeaderStyle-BorderColor="White">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="View" runat="server" CommandName="View" class="btn btn-info"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="View" Height="25px"
                                                        Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
        </div>   
         
        <div class="form-group">
            <div class="col-md-5">Facility Code</div>
            <div class="col-md-7">
                <asp:TextBox ID="txtContraCode" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSerch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnSerch_Click" />
                <asp:Button ID="btnPrint" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="btnPrint_Click" />
                <input id="btnPrint0" class="btn btn-primary" onclick="PrintGridData()" type="button" value="Print" />
        </div>
        
        <div class="form-group">
            <asp:HiddenField ID="hstrSelectQuery" runat="server" />
            <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        </asp:Panel>
      
    <asp:Panel ID="pnlVoucher" runat="server" Visible="true">
        <div align="center" id="prt">
            <table id="tblVoucher" cellpadding="0" cellspacing="0" border="0px" width="804px" class="tblVoucher"
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
                    <td width = "281px">
                    </td>
                    <td width= "76px">
                        Voucher No
                    </td>
                    <td class="style4">
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
                        <asp:Label ID="lblNIC" runat="server"></asp:Label>
                    </td>
                    <td width = "281px">
                    </td>
                    <td width = "76px">
                    </td>
                    <td class="style4">
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
                    <td width = "281px">
                    </td>
                    <td width = "76px">
                        User ID
                    </td>
                    <td class="style4">
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
                    <td colspan="7" width="800px" align="center">
                        <asp:GridView ID="grdVoucherBody" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top"
                            ShowHeader="False" Width="800px">
                            <Columns>
                                <asp:BoundField DataField="ChequeNo" ItemStyle-VerticalAlign="Top" HeaderText="Cheque No"
                                    HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true">
                                    <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FacilityNo" ItemStyle-VerticalAlign="Top" HeaderText="Facility No"
                                    HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                    ReadOnly="true">
                                    <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
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
                        <asp:Label ID="Label1" runat="server" Text="Debit" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:GridView ID="grdApproval" runat="server" Height="120px" ShowHeader="False" Width="800px"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="p1" HeaderText="p1" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Bold="true"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="140px" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true">
                                    <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="140px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="p2" HeaderText="p2" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Bold="true"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="140px" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true">
                                    <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="140px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="p3" HeaderText="p3" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Bold="true"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="140px" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true">
                                    <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="140px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="p4" HeaderText="p4" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Bold="true"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="140px" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true">
                                    <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="140px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="p5" HeaderText="p5" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Bold="true"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="140px" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true">
                                    <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="140px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="p6" HeaderText="p6" ItemStyle-VerticalAlign="Top" HeaderStyle-Font-Bold="true"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="160px" HeaderStyle-BackColor="#009905"
                                    HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true">
                                    <HeaderStyle BackColor="#009905" BorderColor="White" ForeColor="White" Width="160px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="7" height="5px">
                    </td>
                </tr>
                <tr>
                    <td colspan="7" height="5px" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Received" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="7" height="10px">
                        <table border="0px">
                            <tr>
                                <td colspan="4" height="10px">
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
    <div align="center">
    </div>
</asp:Content>
