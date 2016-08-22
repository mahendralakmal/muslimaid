<%@ Page Language="C#" MasterPageFile="~/MuslimAID.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MuslimAID.WebForm1" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Button" />
    </div>
    <div>
        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
            <asp:ListItem >aaaaaaaa</asp:ListItem>
            <asp:ListItem >aaaaaaaa</asp:ListItem>
            <asp:ListItem >aaaaaaaa</asp:ListItem>
            <asp:ListItem >aaaaaaaa</asp:ListItem>
            <asp:ListItem >aaaaaaaa</asp:ListItem>
        </asp:DropDownList>
    </div>
</asp:Content>
