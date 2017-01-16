<%@ Page Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MuslimAID.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">

    
    <!-- /navbar -->
    <div class="col-md-4 col-lg-offset-4 account-container">
        <div class="content clearfix">
            <fieldset>
                <form id="Login" class="form-horizontal" action="">
                <h1>
                    Login</h1>
                <div class="login-fields">
                    <p>
                        Please provide your details</p>
                    <div class="form-group">
                        <label for="username">
                            Username</label>
                        <asp:TextBox ID="txtUsername" runat="server" class="login username-field form-control"
                            placeholder="Username" Width="100%"></asp:TextBox>
                    </div>
                    <!-- /field -->
                    <div class="form-group">
                        <label for="password">
                            Password:</label>
                        <asp:TextBox ID="txtPassword" runat="server" class="login password-field form-control"
                            placeholder="Password" Width="100%" TextMode="Password"></asp:TextBox>
                    </div>
                    <!-- /password -->
                </div>
                <!-- /login-fields -->
                <div class="form-group">
                    <span class="login-checkbox">
                        <input id="Field" name="Field" type="checkbox" class="field login-checkbox" value="First Choice"
                            tabindex="4" />
                        <label class="choice" for="Field">
                            Keep me signed in</label>
                    </span>                        
                </div>
                <div class="form-group">
                    <asp:Button ID="btnSubmit" class="btn btn-success" runat="server"
                        Text="Sign In" OnClick="btnSubmit_Click" />
                </div>
                <!-- .actions -->
                </form>
                <asp:Label ID="lblMsgs" runat="server" ForeColor="#FF0066"></asp:Label>
            </fieldset>
        </div>
        <!-- /content -->
    </div>
    <!-- /account-container -->


</div>    
</asp:Content>
