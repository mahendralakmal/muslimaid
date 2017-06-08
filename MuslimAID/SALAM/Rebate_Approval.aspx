<%@ Page Language="C#" MasterPageFile="~/SALAM/Salam.Master" AutoEventWireup="true" CodeBehind="Rebate_Approval.aspx.cs" Inherits="MuslimAID.SALAM.Rebate_Approval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="PageTitle"><h4>Rebate Approval Details</h4></div>
    <div class="form-container row col-lg-10 col-md-10 ">
        <div class="form-group">
            <asp:GridView ID="grvRebaAppr" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="grvRebaAppr_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="contra_code" HeaderText="Facility Code" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="arrears" HeaderText="Arrears" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="90px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="in_amount" HeaderText="Interest Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="prio" HeaderText="Period" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="new_inte_rate" HeaderText="Interest Rate" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="min_amount" HeaderText="Amount" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="new_loan_bala" HeaderText="New Closing Balance" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#009905" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:TemplateField HeaderStyle-ForeColor="#009905" HeaderStyle-Width="80px" HeaderStyle-BorderColor="White">
                                <ItemTemplate>
                                    <a ref="#" onclick="javascript:w=window.open(&#039;Approved_rebate.aspx?ConCode=<%#Eval("contra_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=520px,height=300px,scrollbars=no,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;" style="text-decoration:underline;">
                                        Approval
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
        </div>
        <div class="form-group">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</div>
</asp:Content>
