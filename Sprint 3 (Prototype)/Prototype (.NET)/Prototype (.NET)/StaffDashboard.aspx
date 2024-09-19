<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffDashboard.aspx.cs" Inherits="Prototype__.NET_.StaffDashboard" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Dashboard</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
        }

        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            padding: 20px;
        }

        .dashboard-container {
            background-color: white;
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 20px;
            width: 800px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .dashboard-container h2 {
            color: #4CAF50;
            margin-bottom: 20px;
        }

        .dashboard-container table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        .dashboard-container table th, .dashboard-container table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        .dashboard-container table th {
            background-color: #4CAF50;
            color: white;
        }

        .dashboard-container table td {
            text-align: left;
        }

        .dashboard-container button {
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 10px 15px;
            font-size: 16px;
            cursor: pointer;
            border-radius: 4px;
        }

        .dashboard-container button:hover {
            background-color: #45a049;
        }

        .message {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="dashboard-container">
                <h2>Manage Queries</h2>
                <asp:GridView ID="GridViewQueries" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="QueryId" HeaderText="Query ID" />
                        <asp:BoundField DataField="QueryType" HeaderText="Type" />
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="CreatedAt" HeaderText="Created At" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnUpdateStatus" runat="server" Text="Update Status" CommandName="UpdateStatus" CommandArgument='<%# Eval("QueryId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
