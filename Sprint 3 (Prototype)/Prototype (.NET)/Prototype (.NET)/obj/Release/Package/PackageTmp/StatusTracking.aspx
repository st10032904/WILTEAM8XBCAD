<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatusTracking.aspx.cs" Inherits="Prototype__.NET_.StatusTracking" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Status Tracking</title>
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
        }

        .form-container {
            background-color: white;
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 20px;
            width: 600px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        .form-container h2 {
            color: #4CAF50;
            margin-bottom: 20px;
        }

        .form-container table {
            width: 100%;
            border-collapse: collapse;
        }

        .form-container table th, .form-container table td {
            border: 1px solid #ddd;
            padding: 8px;
        }

        .form-container table th {
            background-color: #4CAF50;
            color: white;
        }

        .form-container table td {
            text-align: left;
        }

        .message {
            color: red;
        }

        .form-container .back-button {
            background-color: #f4f4f4;
            color: #333;
            border: 1px solid #ccc;
            margin-top: 20px;
        }

        .form-container .back-button:hover {
            background-color: #ddd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-container">
                <h2>Your Queries</h2>
                <asp:GridView ID="GridViewQueries" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="QueryId" HeaderText="Query ID" />
                        <asp:BoundField DataField="QueryType" HeaderText="Type" />
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="CreatedAt" HeaderText="Created At" DataFormatString="{0:MM/dd/yyyy}" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="back-button" OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>
