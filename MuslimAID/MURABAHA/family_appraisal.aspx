<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="family_appraisal.aspx.cs" Inherits="MuslimAID.MURABAHA.family_appraisal" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Family Appraisal</h4></div>
    <div class="col-md-12 form-container">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Contract Code<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCC" CssClass="form-control" MaxLength="12" AutoPostBack="true" Enabled="false" runat="server" TabIndex="0" ></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">C. Applicant Code<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCACode" CssClass="form-control" MaxLength="10" runat="server" TabIndex="1"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Business Income (BI)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Salary & Wages<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtBuss" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent income - Building<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent income – Others<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Net Income from Business<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox7" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other income<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox8" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Annual Family Income</strong><span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox9" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12"><h4>Monthly Business Income (BI)</h4><hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Food<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox10" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Education<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox11" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Water, Electricity & Telephone<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox12" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Health & Sanitation<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox13" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Rent payments<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox14" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Other facility/advance installments<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox15" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Travel & Transport<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox16" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Clothes<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox17" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5">Others<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox18" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Total Annual Family Expenses</strong></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox19" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-12"></div>
        <div class="col-md-12">&nbsp;<hr /></div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Net annual family income</strong></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox20" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Amount that can be used for other purposes (monthly)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox21" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum amount payable for the facility (monthly/ weekly)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox22" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Facility Repayment period (months/weeks)</strong></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox23" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum amount can be disbursed</strong></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox24" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Maximum disbursable amount according to the institutional policy</strong></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox25" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-5"><strong>Requested amount as per the sfacility application</strong></div>
                <div class="col-md-7"><asp:TextBox ID="TextBox26" Enabled="false" CssClass="form-control" runat="server" TabIndex="8"></asp:TextBox></div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
