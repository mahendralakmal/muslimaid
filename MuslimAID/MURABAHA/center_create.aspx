<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="center_create.aspx.cs" Inherits="MuslimAID.MURABHA.center_create" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>MF Application - Create a Center</h4></div>
    <div class="col-md-6 form-container">
            <div class="form-group">
                <div class="col-md-5">City Code<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:DropDownList ID="cmbCityCode" CssClass="form-control" 
                        TabIndex="1" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="cmbCityCode_SelectedIndexChanged"></asp:DropDownList></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Center ID<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCenterID" CssClass="form-control" 
                        TabIndex="6" MaxLength="10" Width="100px" runat="server" AutoPostBack="True" 
                        ontextchanged="txtCenterID_TextChanged" ></asp:TextBox></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Village<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbVillages" runat="server" TabIndex="2" ></asp:DropDownList></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">CRO<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:DropDownList CssClass="form-control" ID="cmbExecative" runat="server" TabIndex="2" ></asp:DropDownList></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Center Name<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtCenterName" CssClass="form-control" 
                        AutoPostBack="true" TabIndex="3" runat="server" 
                        ontextchanged="txtCenterName_TextChanged"></asp:TextBox></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Leader Name<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox CssClass="form-control" ID="txtLName" TabIndex="4" runat="server"></asp:TextBox></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Leader Contact No<span style="color:Red;">*</span></div>
                <div class="col-md-7"><asp:TextBox ID="txtContactNo" TabIndex="5" MaxLength="10" CssClass="form-control" runat="server" onKeypress="javascript:return check(event);"></asp:TextBox></div>
            </div>
            <div class="form-group">
                <div class="col-md-5">Center Day<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbCenterDay" CssClass="form-control" runat="server" TabIndex="6" >
                        <asp:ListItem Value="MO">Monday</asp:ListItem>
                        <asp:ListItem Value="TU">Tuesday</asp:ListItem>
                        <asp:ListItem Value="WE">Wednsday</asp:ListItem>
                        <asp:ListItem Value="TH">Thursday</asp:ListItem>
                        <asp:ListItem Value="FR">Friday</asp:ListItem>
                        <asp:ListItem Value="SA">Saturday</asp:ListItem>
                        <asp:ListItem Value="SU">Sunday</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>            
            <div class="form-group">
                <div class="col-md-5">Latitude<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtLatitude" CssClass="form-control" TabIndex="6" MaxLength="10" Width="100px" runat="server" ></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group">
                <div class="col-md-5">Longitude<span style="color:Red;">*</span></div>
                <div class="col-md-7">
                <asp:TextBox ID="txtLongitude" CssClass="form-control" TabIndex="6" MaxLength="10" Width="100px" runat="server" ></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" 
                Text="Submit" Enabled="false" TabIndex="11" onclick="btnSubmit_Click"/>
            <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" 
                Text="Update" TabIndex="12" Enabled="False" onclick="btnUpdate_Click"/>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</div>
</asp:Content>
