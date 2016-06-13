<%@ Page Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MuslimAID.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!-- /navbar -->
    <div class="account-container">
        <div class="content clearfix">
            <fieldset>
                <form id="Login" class="form-horizontal" action="">
                <h1>
                    Login</h1>
                <div class="login-fields">
                    <p>
                        Please provide your details</p>
                    <div class="field">
                        <label for="username">
                            Username</label>
                        <asp:TextBox ID="txtUsername" runat="server" class="login username-field form-control"
                            placeholder="Username" Width="100%"></asp:TextBox>
                    </div>
                    <!-- /field -->
                    <div class="field">
                        <label for="password">
                            Password:</label>
                        <asp:TextBox ID="txtPassword" runat="server" class="login password-field form-control"
                            placeholder="Password" Width="100%" TextMode="Password"></asp:TextBox>
                    </div>
                    <!-- /password -->
                </div>
                <!-- /login-fields -->
                <div class="login-actions">
                    <span class="login-checkbox">
                        <input id="Field" name="Field" type="checkbox" class="field login-checkbox" value="First Choice"
                            tabindex="4" />
                        <label class="choice" for="Field">
                            Keep me signed in</label>
                    </span>
                    <asp:Button ID="btnSubmit" class="button btn btn-success btn-large" 
                        runat="server" Text="Sign In" onclick="btnSubmit_Click" />                        
                </div>                
                <!-- .actions -->
                </form>
                <asp:Label ID="lblMsgs" runat="server" ForeColor="#FF0066"></asp:Label>
            </fieldset>
        </div>
        <!-- /content -->
    </div>
    <!-- /account-container -->
</asp:Content>
