<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="info.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>System and Employee Details</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            text-align: center;
        }
        h1, h2 {
            color: #333;
        }
        #form1 {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome!</h1>
            <h2>Select an option</h2>
            <div class="button-container">
                <asp:Button ID="btnSystemConfig" runat="server" Text="System Configuration" OnClick="btnSystemConfig_Click" CssClass="btn" />
                <asp:Button ID="btnEmployeeDetails" runat="server" Text="Employee Details" OnClick="btnEmployeeDetails_Click" CssClass="btn" />
            </div>
        </div>
    </form>
</body>
</html>
