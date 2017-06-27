<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Report_Ledger_Card.aspx.cs" Inherits="MuslimAID.MURABHA.Report_Ledger_Card" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('cusSumme');
            prtGrid.border = 1;
            prtGrid.style.fontSize = "10pt";
            prtGrid.style.fontFamily = "Calibri";
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>Ventura - CS Customer Ledger Card</div>");
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
        <div class="PageTitle"><h4>CS - Customer Leder Card</h4></div>
        <div class="col-md-12 form-container row">
            <div class="col-md-8 form-group">
                <div class="col-md-2">Facility Code</div>
                <div class="col-md-5"><asp:TextBox ID="txtCC" MaxLength="30" runat="server" CssClass="form-control"></asp:TextBox></div>
                <asp:Button ID="btnSerch" runat="server" OnClick="btnSerch_Click" Text="Serch" />
                <input type="button" id="btnPrint" value="Print" onclick="PrintGridData()" />
            </div>
            <div class="col-md-8 form-group">
                <div class="col-md-2">NIC</div>
                <div class="col-md-5"><asp:TextBox ID="txtNIC" runat="server" MaxLength="15" CssClass="form-control" OnTextChanged="txtNIC_TextChanged"
                        AutoPostBack="True"></asp:TextBox></div>
            </div>
            <div class="col-md-8 form-group">
                <div class="col-md-2">Name</div>
                <div class="col-md-5"><asp:TextBox ID="txtName" runat="server" MaxLength="50" CssClass="form-control" 
                        AutoPostBack="True" ontextchanged="txtName_TextChanged"></asp:TextBox></div>
            </div>
            <div class="col-md-12 form-group">
                <asp:GridView ID="gdvFacility" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False"
                        AllowPaging="True" OnRowCommand="gdvFacility_RowCommand">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="150px" DataField="loan_approved_on" HeaderText="Date" />
                            <asp:BoundField ItemStyle-Width="100px" DataField="contra_code" HeaderText="Facility No" />
                            <asp:BoundField ItemStyle-Width="100px" DataField="loan_amount" HeaderText="Loan Amount" />
                            <asp:BoundField ItemStyle-Width="200px" DataField="full_name" HeaderText="Name" />
                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="10px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="View" runat="server" CommandName="View" class="btn btn-info"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="View" Height="25px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
            </div>
            <div class="col-md-12 form-group"><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
            <div class="col-md-12 form-group">
                            <asp:Panel ID="pnlSummery" runat="server" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="font-family: Calibri;
                    font-size: 10pt; text-align: left;">
                    <tr>
                        <td width="100px">
                            Contract Code
                        </td>
                        <td width="20px">
                            :
                        </td>
                        <td width="300px">
                            <asp:Label ID="lblConCode" runat="server"></asp:Label>
                        </td>
                        <td width="20px">
                        </td>
                        <td width="100px">
                            Contract Date
                        </td>
                        <td width="20px">
                            :
                        </td>
                        <td width="300px">
                            <asp:Label ID="lblContrDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Center Name
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblCenterName" runat="server"></asp:Label>
                        </td>
                        <td width="20px">
                        </td>
                        <td>
                            CRO
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblCRO" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Name
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                        <td width="20px">
                        </td>
                        <td>
                            Period
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblPeriod" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Loan Amount
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblLoanAmou" runat="server"></asp:Label>
                        </td>
                        <td width="20px">
                        </td>
                        <td>
                            Installment
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblInstall" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Interest Amount
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblIAmount" runat="server"></asp:Label>
                        </td>
                        <td width="20px">
                        </td>
                        <td>
                            Agreed Value
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblAValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            No of Due Insta.
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblDueCount" runat="server"></asp:Label>
                        </td>
                        <td width="20px">
                        </td>
                        <td>
                            Status
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Maturity Date
                        </td>
                        <td>
                            :
                        </td>
                        <td colspan="5" align="left">
                            <asp:Label ID="lblMatuDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <asp:GridView ID="grvSumm" runat="server" HeaderStyle-BackColor="#006699" HeaderStyle-HorizontalAlign="Center"
                                Font-Size="10pt" BorderColor="White" Width="860px" OnRowDataBound="grvSumm_RowDataBound">
                                <Columns>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                            <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Current Balance
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblCuBala" runat="server"></asp:Label>
                        </td>
                        <td>
                        </td>
                        <td>
                            Arreas Payment
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblArre" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" height="10px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
