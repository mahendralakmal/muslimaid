<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="Reschedule.aspx.cs" Inherits="MuslimAID.MURABAHA.Reschedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Loan Re-Schedule</h4></div>
    <div class="form-container row col-lg-10 col-md-10 ">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">
                    Facility Code
                </div>
                <div class="col-md-5">
                    <asp:TextBox ID="txtCC" CssClass="form-control
                    " runat="server" MaxLength="15"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnSerch" CssClass="btn btn-primary" runat="server" Text="Serch" 
                        onclick="btnSerch_Click" />
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <asp:Panel ID="pnlSummery" runat="server">
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Facility Code
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblConCode" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Total Current Balance
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblTotCurrentBalance" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                    <div class="col-md-5">
                        Name
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblName" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-6 form-group">
                   <div class="col-md-5">
                       Due Installment
                   </div>
                   <div class="col-md-7">
                       <asp:Label ID="lblDueInstallment" CssClass="form-control" runat="server"></asp:Label>
                   </div>
                </div>
                <div class="col-md-6 form-group">
                   <div class="col-md-5">
                       Loan Amount
                   </div>
                   <div class="col-md-7">
                       <asp:Label ID="lblLoanAmou" CssClass="form-control" runat="server"></asp:Label>
                   </div>
                </div>
                <div class="col-md-6 form-group">
                   <div class="col-md-5">
                       Over Payment
                   </div>
                   <div class="col-md-7">
                       <asp:Label ID="lblOverPayment" CssClass="form-control" runat="server"></asp:Label>
                   </div>
                </div>
                <div class="col-md-6 form-group">
                   <div class="col-md-5">
                       Interest Amount
                   </div>
                   <div class="col-md-7">
                       <asp:Label ID="lblIAmount" CssClass="form-control" runat="server"></asp:Label>
                   </div>
                </div>
                <div class="col-md-6 form-group">
                   <div class="col-md-5">
                       Total Arreas
                   </div>
                   <div class="col-md-7">
                       <asp:Label ID="lblTotalArreas" CssClass="form-control" runat="server"></asp:Label>
                   </div>
                </div>
                <div class="col-md-6 form-group">
                   <div class="col-md-5">
                       Period
                   </div>
                   <div class="col-md-7">
                       <asp:Label ID="lblPeriod" CssClass="form-control" runat="server"></asp:Label>
                   </div>
                </div>
                <div class="col-md-6 form-group">
                   <div class="col-md-5">
                       	Total Default
                   </div>
                   <div class="col-md-7">
                       <asp:Label ID="lblTotalDefault" CssClass="form-control" runat="server"></asp:Label>
                   </div>
                </div>
                <div class="col-md-6 form-group">
                   <div class="col-md-5">
                       Granting Date
                   </div>
                   <div class="col-md-7">
                       <asp:Label ID="lblGrantDate" CssClass="form-control" runat="server"></asp:Label>
                   </div>
                </div>
                <div class="col-md-7">
                    <div class="form-group">
                       <div class="col-md-4">
                           Loan stock
                       </div>
                       <div class="col-md-6">
                           <asp:Label ID="lblLoanStock" CssClass="form-control" runat="server"></asp:Label>
                       </div>
                    </div>
                    <div class="form-group">
                       <div class="col-md-4">
                           Future Capital
                       </div>
                       <div class="col-md-6">
                           <asp:Label ID="lblFutureCapital" CssClass="form-control" runat="server"></asp:Label>
                       </div>
                    </div>
                    <div class="form-group">
                       <div class="col-md-4">
                           Future Interest
                       </div>
                       <div class="col-md-6">
                           <asp:Label ID="lblFutureInterest" CssClass="form-control" runat="server"></asp:Label>
                       </div>
                    </div>
                    <div class="form-group">
                       <div class="col-md-4">
                           Re-schedule Period
                       </div>
                       <div class="col-md-6">
                           <asp:TextBox ID="txtReschedulePeriod" runat="server" MaxLength="15" CssClass="form-control" 
                                    AutoPostBack="True" ontextchanged="txtReschedulePeriod_TextChanged" 
                                    TabIndex="2"></asp:TextBox>
                       </div>
                    </div>
                    <div class="form-group">
                       <div class="col-md-4">
                           Re-schedule Interest Rate
                       </div>
                       <div class="col-md-6">
                           <asp:TextBox ID="txtRSInterestRate" runat="server" MaxLength="15"  CssClass="form-control"
                                    AutoPostBack="True" ontextchanged="txtRSInterestRate_TextChanged" TabIndex="3"></asp:TextBox>
                       </div>
                    </div>
                    <div class="form-group">
                       <div class="col-md-4">
                           Re-schedule Loan Amount
                       </div>
                       <div class="col-md-6">
                           <asp:TextBox ID="txtRSLoanAmount" runat="server" MaxLength="15" TabIndex="4" CssClass="form-control"></asp:TextBox>
                       </div>
                    </div>
                    <div class="form-group">
                       <div class="col-md-4">
                           Re-schedule Loan Installment
                       </div>
                       <div class="col-md-6">
                            <asp:TextBox ID="txtRSLoanInstallment" runat="server" MaxLength="15"  CssClass="form-control"
                                    TabIndex="5"></asp:TextBox>
                       </div>
                    </div>
                </div>
                <div class="col-md-12">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Enabled="False" CssClass="btn btn-primary" 
                                onclick="btnSubmit_Click" TabIndex="6" />
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                            <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                            <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
                </div>
            </asp:Panel>
        </div>
    </div>
</div>
    <%--<table cellpadding="0" cellspacing="0" border="0" width="860px" align="left" style="font-family: Calibri;
        font-size: 10pt; text-align: left;">
        <tr>
            <td colspan="3" height="10px">
            </td>
        </tr>
        <tr>
            <td colspan="3" width="860px" class="PageTitle">
                Loan Re-Schedule
            </td>
        </tr>
        <tr>
            <td colspan="3" height="10px">
            </td>
        </tr>
        <tr>
            <td width="100px">
                Facility Code
            </td>
            <td width="20px">
                :
            </td>
            <td width="740px">
                <asp:TextBox ID="txtCC" runat="server" MaxLength="15" TabIndex="1"></asp:TextBox>
                <asp:Button ID="btnSerch" runat="server" Text="Serch" 
                    onclick="btnSerch_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3" height="10px">
            </td>
        </tr>
    </table>--%>
    <div align="center" id="cusSumme">
    </div>
</asp:Content>
