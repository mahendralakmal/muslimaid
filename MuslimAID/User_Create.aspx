<%@ Page Language="C#" MasterPageFile="~/MuslimAID.Master" AutoEventWireup="true" CodeBehind="User_Create.aspx.cs" Inherits="MuslimAID.User_Create"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDateOfBirth.ClientID %>").dynDateTime({
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
        $(function() {
            $('#datetimepicker').datetimepicker({ format: 'DD/MM/YYYY' });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>User Create</h4></div>
    <div class="col-md-6 form-container">
        <div class="form-group row">
            <div class="col-md-5">User Name (NIC)<span style="color:Red;">*</span></div>
            <div class="col-md-7">
                    <asp:TextBox ID="txtUserName" MaxLength="12" runat="server" CssClass="form-control"
                        ontextchanged="txtUserName_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-5">Password <span style="color:Red;">*</span></div>
            <div class="col-md-7">
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="45" CssClass="form-control" TextMode="Password"></asp:TextBox>&nbsp;(Max Length 45)
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-5">Confirm Password <span style="color:Red;">*</span></div>
            <div class="col-md-7">
                    <asp:TextBox ID="txtConfirmPass" runat="server" MaxLength="45" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div>
            <hr />
            <h4> Personal Details </h4>
            <br />
        </div>
        <div class="form-group row">
            <div class="col-md-5">Title <span style="color:Red;">*</span></div>
            <div class="col-md-7">
                    <asp:DropDownList ID="cmbTitle" runat="server" CssClass="form-control" TabIndex="3">
                        <asp:ListItem Value="Mr.">Mr.</asp:ListItem>
                        <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
                        <asp:ListItem Value="Miss">Miss.</asp:ListItem>
                    </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-5">First Name <span style="color:Red;">*</span></div>
            <div class="col-md-7">
                    <asp:TextBox ID="txtFirstName" CssClass="form-control" MaxLength="45" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-5">Last Name <span style="color:Red;">*</span></div>
            <div class="col-md-7">
                    <asp:TextBox ID="txtLastName" CssClass="form-control" MaxLength="45" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-5">Address <span style="color:Red;">*</span></div>
            <div class="col-md-7">
                    <asp:TextBox ID="txtAddress" CssClass="form-control" MaxLength="200" Height="100px" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-5">
                Date of Birth </div>
            <div class="col-md-7">
                <div class='input-group date' id='datetimepicker'>
                    <asp:TextBox ID="txtDateOfBirth" CssClass="form-control" runat="server"></asp:TextBox>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-5">Photo Path <span style="color:Red;">*</span></div>
            <div class="col-md-7">
                    <asp:FileUpload ID="fuPhoto" CssClass="form-control" runat="server" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
               ControlToValidate="fuPhoto"
               ErrorMessage=".jpg,.png,.jpeg,.gif Files only"
               ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"></asp:RegularExpressionValidator>
               
                <asp:Label ID="img_path" runat="server"></asp:Label>
                <asp:HiddenField ID="hid_img_path" runat="server" />
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-5">User Type <span style="color:Red;">*</span></div>
            <div class="col-md-7">
                <asp:DropDownList ID="cmbUserType" runat="server" CssClass="form-control">
                    <asp:ListItem Value="">Select user type</asp:ListItem>
                    <asp:ListItem Value="ADM">Admin</asp:ListItem>
                    <asp:ListItem Value="BOD">BOD</asp:ListItem>
                    <asp:ListItem Value="CMG">Chief Manager</asp:ListItem>
                    <asp:ListItem Value="OMG">Operations Manager</asp:ListItem>
                    <asp:ListItem Value="FAO">Finance & Admin Officer</asp:ListItem>
                    <asp:ListItem Value="RMG">Regional Manager</asp:ListItem>
                    <asp:ListItem Value="RFA">Regional Finance & Admin Officer</asp:ListItem>
                    <asp:ListItem Value="BMG">Branch Manager</asp:ListItem>
                    <asp:ListItem Value="BFA">Branch Finance & Admin Officer</asp:ListItem>
                    <asp:ListItem Value="MFO">Micro Finance Officer</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-5">Designation <span style="color:Red;">*</span></div>
            <div class="col-md-7">
                <asp:TextBox ID="txtDesignation" CssClass="form-control" MaxLength="45" runat="server"></asp:TextBox>
                <asp:HiddenField ID="hf1" runat="server" />
            </div>
        </div>
        <div classs="form-group">
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Create" onclick="btnSubmit_Click" />
            <asp:Button ID="btnUpdate" Enabled="false" runat="server" Text="Update" 
                CssClass="btn btn-primary" onclick="btnUpdate_Click" />
            <asp:Button ID="btnDactivate" runat="server" Text="Deactivate" 
                CssClass="btn btn-danger" Enabled="false" onclick="btnDactivate_Click"/>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div>
</div>
</asp:Content>
