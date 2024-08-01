<%@ Page Title="System Configuration" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SystemConfig.aspx.cs" Inherits="info.SystemConfig" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            text-align: center;
        }
        .form-container {
            max-width: 600px;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            color: #007bff;
            margin-bottom: 20px;
        }
        label {
            display: block;
            margin-bottom: 8px;
        }
        select, input[type="text"], textarea {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .btn {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            border-radius: 4px;
            cursor: pointer;
        }
        .btn:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        <h1>System Configuration</h1>
        <label for="DeviceName">Device Name:</label>
        <asp:TextBox ID="DeviceName" runat="server"></asp:TextBox>
        <br />
        <label for="Processor">Processor:</label>
        <asp:DropDownList ID="Processor" runat="server"></asp:DropDownList>
        <br />
        <label for="InstalledRAM">Installed RAM:</label>
        <asp:DropDownList ID="InstalledRAM" runat="server"></asp:DropDownList>
        <br />
        <label for="SystemType">System Type:</label>
        <asp:DropDownList ID="SystemType" runat="server"></asp:DropDownList>
        <br />
        <label for="SystemVersion">Version:</label>
        <asp:DropDownList ID="SystemVersion" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" CssClass="btn" />
    </div>
</asp:Content>
