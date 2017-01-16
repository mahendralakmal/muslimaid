<%@ Page Language="C#" MasterPageFile="~/MURABAHA/Murabha.Master" AutoEventWireup="true" CodeBehind="arrears_report.aspx.cs" Inherits="MuslimAID.MURABHA.arrears_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('ArreDeta');
            prtGrid.border = 1;
            prtGrid.style.fontSize="10pt";
            prtGrid.style.fontFamily="Calibri";
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write("<div style='font-size:12pt;font-family:Calibri;'>Ventura ::: MF</div>");
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="PageTitle"><h4>MF Application - Arrears Report</h4></div>
        <div class="col-md-7 form-container">
        
                <div class="form-group">
                    <div class="col-md-5">B. Code</div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="cmbCityCode" CssClass="form-control" TabIndex="0" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-5">Contract Code</div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtContraCode" CssClass="form-control" runat="server" MaxLength="9"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-5">Status</div>
                    <div class="col-md-7">
                        <asp:DropDownList CssClass="form-control" ID="cmbStatus" runat="server">
                            <asp:ListItem Value="A">All</asp:ListItem>
                            <asp:ListItem Value="D">Contract to expire</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-5">Arrears Count</div>
                    <div class="col-md-7"> 
                        <asp:DropDownList ID="cmbACount" CssClass="form-control" runat="server">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">Up to 1</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <asp:Button ID="btnSerch" CssClass="btn btn-primary" runat="server" Text="Search"/>
                <input Class="btn btn-primary" type="button" id="btnPrint" value="Print"/>
            
            
                <asp:Panel ID="pnlARep" runat="server">
                    <asp:GridView ID="grvArRep" Font-Size="8pt" runat="server" AutoGenerateColumns="false" ItemStyle-VerticalAlign="Top">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contract Code" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <a ref="#" onclick="javascript:w=window.open(&#039;Full_Details.aspx?ConCode=<%#Eval("contra_code")%>&#039;,&#039;popup&#039;,&#039;target=_blank,width=800px,height=500px,scrollbars=yes,resizable=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=100&#039;);w.focus();return false;" style="text-decoration:underline;">
                                        <%#Eval("contra_code")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="contra_code" ItemStyle-VerticalAlign="Top" HeaderText="Contract Code" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />--%>
                            <asp:BoundField DataField="initial_name" ItemStyle-VerticalAlign="Top" HeaderText="Name" HeaderStyle-Width="160px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10pt" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="p_address" ItemStyle-VerticalAlign="Top" HeaderText="Address" HeaderStyle-Width="240px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="mobile_no" ItemStyle-VerticalAlign="Top" HeaderText="Mobile" HeaderStyle-Width="90px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="FORMAT(l.monthly_instollment,2)" ItemStyle-VerticalAlign="Top" HeaderText="Installment" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="FORMAT(l.arres_amou,2)" ItemStyle-VerticalAlign="Top" HeaderText="Total Arrears" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="FORMAT(l.def,2)" HeaderText="Default" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="60px" HeaderStyle-BackColor="#006699" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="arres_count" ItemStyle-VerticalAlign="Top" HeaderText="Count" HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#006699" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="DATE_FORMAT(l.due_date, '%Y-%m-%d')" HeaderText="Date" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="100px" HeaderStyle-BackColor="#006699" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                            <asp:BoundField DataField="DATE_FORMAT(l.chequ_deta_on, '%Y-%m-%d')" HeaderText="Gra Date" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="90px" HeaderStyle-BackColor="#006699" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="White" ReadOnly="true" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>            
            
            
                <asp:Panel ID="pnlSummery" runat="server" Visible="false">
                    <div class="col-md-5">No Of Arrears</div>
                    <div class="col-md-7"><asp:Label ID="lblNoArres" runat="server"></asp:Label></div>
                    <div class="col-md-5">Arrears Amount</div>
                    <div class="col-md-7"><asp:Label ID="lblArreAmount" runat="server"></asp:Label></div>
                </asp:Panel>        
            
            
                <asp:HiddenField ID="hstrSelectQuery" runat="server" />
                <asp:HiddenField ID="hstrSelectQuery1" runat="server" />
            
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
</asp:Content>
