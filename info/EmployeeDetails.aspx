<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="info.EmployeeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        h1 {
            font-size: 2em;
            color: #333;
            margin-bottom: 20px;
        }
        label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }
        input[type="text"], select {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            font-size: 1em;
        }
        .button-container {
            margin-top: 20px;
        }
        .btn {
            display: inline-block;
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            text-decoration: none;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        .btn:hover {
            background-color: #0056b3;
        }
    </style>
    <h1>Employee Details</h1>
    <div>
        <label for="DeviceID">Device Name:</label>
        <asp:DropDownList ID="DeviceIDDropDownList" runat="server"></asp:DropDownList>
        <br />
        <label for="IPAddress">IP Address:</label>
        <asp:TextBox ID="IPAddressTextBox" runat="server"></asp:TextBox>
        <br />
        <label for="EmployeeName">Employee Name:</label>
        <asp:TextBox ID="EmployeeNameTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="SaveDetailsButton" runat="server" Text="Save" OnClick="SaveDetailsButton_Click" CssClass="btn" />
    </div>
</asp:Content>
