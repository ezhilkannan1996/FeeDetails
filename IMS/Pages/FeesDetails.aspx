<%@ Page Title="Fees Details" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="FeesDetails.aspx.cs" Inherits="IMS.Pages.FeesDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container1">
        <div class="row row-header">
            <div class="col-xs-12">
                <h1>Fees Details</h1>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="LabelReceiptId">Receipt ID:</label>
                            <asp:Label ID="LabelReceiptIdText" runat="server" CssClass="form-control-static"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="LabelStudentList">Select Student:</label>
                            <asp:DropDownList ID="DrpDwnStudentList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DrpDwnStudentList_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="LabelCourseList">Select Course:</label>
                            <asp:DropDownList ID="DrpDwnCourseList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DrpDwnCourseList_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="LabelDate">Date:</label>
                            <asp:Label ID="LabelDateText" runat="server" CssClass="form-control-static"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="LabelAmount">Amount:</label>
                            <div class="input-group">
                                <asp:TextBox ID="TxtAmountPaid" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="TxtAmountPaid_TextChanged" Width="226px"></asp:TextBox>
                                
                            </div>
                            <asp:Label ID="LabelAmountText" runat="server" CssClass="form-control-static"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="ButtonSubmit_Click" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <asp:GridView ID="FeeDetailsGrid" runat="server" CssClass="table table-bordered"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <style>
        /* Global Styles */

        body {
            font-family: Arial, sans-serif;
            background-color: #f8f8f8;
        }

        .container1 {
            margin-top: 50px;
        }

        .row-header {
            background-color: #222;
            color: #fff;
            padding: 20px;
           
        }
        .row{
            margin-right:1px;
            margin-left:1px;
        }

        .panel {
            border-radius: 0;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        .panel-body {
            padding: 20px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .btn-aligning {
            display: inline-block;
            margin-right: 10px;
        }

        /* Specific Styles */

        h1 {
            font-size: 28px;
            margin-top: 8px;
        }

        .label-receipt-id,
        .label-student-list,
        .label-course-list,
        .label-date,
        .label-amount {
            font-weight: bold;
            margin-bottom: 5px;
        }

        .form-control-static {
            padding-top: 7px;
            padding-bottom: 7px;
            min-height: 34px;
            border: none;
            background-color: transparent;
        }

        .input-group-addon {
            padding: 7px;
            background-color: #f8f8f8;
            border: none;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

            .table th,
            .table td {
                padding: 8px;
                border: 1px solid #ddd;
            }

            .table th {
                background-color: #f9f9f9;
                font-weight: bold;
            }

        .btn-primary {
            background-color: #337ab7;
            border-color: #2e6da4;
        }

            .btn-primary:hover,
            .btn-primary:focus {
                background-color: #286090;
                border-color: #204d74;
            }
    </style>
</asp:Content>
