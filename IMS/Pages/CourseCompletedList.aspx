<%@ Page Title="Course Completed List" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="CourseCompletedList.aspx.cs" Inherits="IMS.Pages.CourseCompletedList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="card shadow border-0 mt-4">
    <div class="card-header bg-secondary bg-gradient ml-0 py-3">
        <div class="row">
            <div class="col-12 text-center">
                <h1 class="text-white py-2">Course Completed List</h1>
            </div>
        </div>
      
    </div>
            <div class="card-body p-4 justify-content-center">
                  <div class="border p-3 margin-top:3% ">
                      <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="true" Text="Fetch records"  GroupName  ="select" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="White"  /><br>
                      <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="true" Text="Limit records "  GroupName="select" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="White" OnCheckedChanged="RadioButton2_CheckedChanged" /><br>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:TextBox ID="TextBox1" TextMode="Date"   CssClass="justify-content-end" runat="server" Width="283px" Font-Size="Medium"></asp:TextBox>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="Label1" runat="server" Text="To" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="10px" Width="75px"></asp:Label>
                           <asp:TextBox ID="TextBox3" TextMode="Date"  CssClass="justify-content-end" runat="server" Width="325px" Font-Size="Medium">To</asp:TextBox>
                            <br />
                            </div>
                  </div>
             <div class="row pt-2 justify-content-center">
                    <div class="col-6 col-md-3 ">
                       <asp:Button ID="Button1" CssClass="btn btn-outline-success form-control siz" runat="server" Text="Search" OnClick="Button1_Click" Width="577px" />
                    </div>
                 </div>
                
            </div>

            
             <div class="row p-6 align-content-center">
    <asp:GridView ID="GridView1" runat="server" AllowCustomPaging="True" AllowPaging="True" CellPadding="4" Font-Bold="False" Font-Names="Calibri" Font-Overline="False" Font-Size="Medium" ForeColor="#000066" GridLines="None" Height="553px" Width="1359px">
        <AlternatingRowStyle BackColor="White" BorderStyle="Solid" />
        <EditRowStyle BackColor="#7C6F57" />
        <EmptyDataRowStyle ForeColor="White" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" BorderStyle="Dashed" Font-Bold="True" Font-Size="Small" ForeColor="White" HorizontalAlign="Justify" VerticalAlign="Middle" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
                 </asp:GridView>
          </div>
</div>
    

</asp:Content>