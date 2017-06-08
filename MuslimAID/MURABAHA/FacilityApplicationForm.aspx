<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="FacilityApplicationForm.aspx.cs" Inherits="MuslimAID.MURABAHA.FacilityApplicationForm" Title="FacilityApplicationForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>Facility Application Form</h4></div>
        <div class="col-md-12 form-container">
            <div class="form-group col-md-6">
                <div class="col-md-5">NIC/Passport/DL No<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtNIC" MaxLength="12" CssClass="form-control" runat="server" 
                        AutoPostBack="true" TabIndex="1"></asp:TextBox>
                    <p>
                    <asp:Label ID="lblMsg0" runat="server" ForeColor="Red"></asp:Label>
                    </p>
                    <asp:HiddenField ID="hidCC" runat="server" />
                    <asp:HiddenField ID="hidCACode" runat="server" />
                </div>
            </div>
            <div class="form-group col-md-6">
                <div class="col-md-5">NIC/Passport/DL Issued Date<span style="color:Red;"> *</span></div>
                    <div class="col-md-7">
                        <div class='input-group date' id='dtpNicPassIssueDateCBD' name='dtpNicPassIssueDateCBD'>
                            <asp:TextBox ID="txtNicIssuDay" MaxLength="10" CssClass="form-control" runat="server" AutoPostBack="true" TabIndex="2"></asp:TextBox>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
            </div>
            
            <hr />
            
            <div class="form-group col-md-6"> 
                <div class="col-md-5">Branch<span style="color:Red;"> *</span></div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbCityCode" CssClass="form-control" TabIndex="3" 
                        runat="server" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
