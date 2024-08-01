<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="EmployeeDetailsTabulation.aspx.cs" Inherits="info.EmployeeDetailsTabulation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            color: #333; /* Text color */
        }
        .container h1 {
            color: #333; /* Heading color */
            text-align: center;
            margin-bottom: 20px;
        }
        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .table th, .table td {
            border: 1px solid #ccc;
            padding: 8px;
            text-align: left;
        }
        .table th {
            background-color: #007bff;
            color: #fff;
        }
    </style>

    <div class="container">
        <h1>Employee Details with System Configurations</h1>
        <asp:GridView ID="EmployeeDetailsGridView" runat="server" AutoGenerateColumns="False" CssClass="table">
            <Columns>
                <asp:BoundField DataField="DeviceID" HeaderText="Device ID" />
                <asp:BoundField DataField="DeviceName" HeaderText="Device Name" />
                <asp:BoundField DataField="Processor" HeaderText="Processor" />
                <asp:BoundField DataField="InstalledRAM" HeaderText="Installed RAM" />
                <asp:BoundField DataField="SystemType" HeaderText="System Type" />
                <asp:BoundField DataField="SystemVersion" HeaderText="SystemVersion" />
                <asp:BoundField DataField="IPAddress" HeaderText="IP Address" />
                <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
