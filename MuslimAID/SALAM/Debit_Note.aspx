<%@ Page Language="C#" MasterPageFile="~//SALAM/Salam.Master" AutoEventWireup="true"
    CodeBehind="Debit_Note.aspx.cs" Inherits="MuslimAID.SALAM.Debit_Note" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%=txtDate.ClientID %>").dynDateTime({
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
            $('#datetimepicker1').datetimepicker({ format: 'DD/MM/YYYY' });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle">
            <h4>Micro Debit - Run</h4>
        </div>
        <div class="col-md-6 form-container">
                    <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                    
                    <%--<asp:TextBox ID="txtDate" Width="200px" runat="server"></asp:TextBox>
                    <img src="../Images/calender.png" />--%>
            <div class="form-group">
                <div class="col-md-5">
                    Date</div>
                <div class="col-md-7 input-group">
                    <div class='input-group date' id='datetimepicker1'>
                        <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">
                    &nbsp;</div>
                <div class="col-md-7">
                    <asp:Button ID="btnEndDay" runat="server" Text="Run" CssClass="btn btn-primary" OnClick="btnEndDay_Click" />&nbsp;
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">
                    &nbsp;</div>
                <div class="col-md-7">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
