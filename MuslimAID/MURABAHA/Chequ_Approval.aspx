<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true"
    CodeBehind="Chequ_Approval.aspx.cs" Inherits="MuslimAID.MURABAHA.Chequ_Approval"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle">
            <h4>
                Cheque Approval</h4>
        </div>
        <div class="col-md-6 form-container">
            <div class="form-group">
                <div class="col-md-5">
                    Branch</div>
                <div class="col-md-7">
                    <asp:DropDownList ID="cmbBranch" runat="server" CssClass="form-control" AutoPostBack="true"
                        OnSelectedIndexChanged="cmbBranch_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">
                    Society No</div>
                <div class="col-md-7">
                    <asp:DropDownList CssClass="form-control" ID="cmdSocietyNo" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">&nbsp;</div>
                <div class="col-md-7">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search"
                        OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-12">
                    <asp:GridView ID="grvChequAppr" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contract Code" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contra_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;"
                                        style="text-decoration: underline;">
                                        <%#Eval("contra_code")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="initial_name" HeaderText="Name" HeaderStyle-Width="200px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="period" HeaderText="Period" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White"
                                ReadOnly="true" />
                            <asp:BoundField DataField="loan_amount" HeaderText="Loan Amount" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="110px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="interest_amount" HeaderText="Total Interest" HeaderStyle-Width="110px"
                                ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White"
                                HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:TemplateField HeaderStyle-ForeColor="#006699" HeaderStyle-Width="100px" HeaderStyle-BorderColor="White">
                                <ItemTemplate>
                                    <a ref="#" onclick="javascript:w=window.open(&#039;ViewChequDetails.aspx?ConCode=<%#Eval("contra_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=520px,height=300px,scrollbars=no,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;"
                                        style="text-decoration: underline;">Click Here </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-12">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
