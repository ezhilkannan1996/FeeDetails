<%@ Page Title="Fees Details" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="FeesDetails.aspx.cs" Inherits="IMS.Pages.FeesDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row row-header">
            <div class="col-xs-12">
                <h1>Fees Details</h1>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-body" style="padding-left: 5%; font-size: 15px">
                <div class="row">
                    <div class="content">
                        <div>
                            <asp:Label ID="LabelReceiptId" runat="server">Receipt ID :</asp:Label>
                            <asp:Label ID="LabelReceiptIdText" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelStudentList" runat="server" Text="Label">Select Student :</asp:Label>
                            <asp:DropDownList ID="DrpDwnStudentList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DrpDwnStudentList_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div>
                            <asp:Label ID="LabelCourseList" runat="server" Text="Label">Select Course :</asp:Label>
                            <asp:DropDownList ID="DrpDwnCourseList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DrpDwnCourseList_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div>
                            <asp:Label ID="LabelDate" runat="server" Text="Label">Date :</asp:Label>
                            <asp:Label ID="LabelDateText" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelAmount" runat="server" Text="Label">Amount</asp:Label>
                            <asp:TextBox ID="TxtAmountPaid" runat="server"></asp:TextBox>
                            <asp:Label ID="LabelAmountText" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" CssClass="btn btn-primary btn-aligning btn-left-aligning" OnClick="ButtonSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
