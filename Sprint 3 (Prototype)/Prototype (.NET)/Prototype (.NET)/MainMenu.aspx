<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="Prototype__.NET_.MainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Menu</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
            background-color: #f4f4f4;
        }

        h1 {
            text-align: center;
            color: #4CAF50;
        }

        .container {
            display: flex;
            justify-content: center;
            flex-wrap: wrap;
        }

        .menu-item {
            background-color: white;
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 20px;
            margin: 10px;
            width: 250px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        .menu-item h3 {
            color: #333;
        }

        .menu-item button {
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 10px 15px;
            font-size: 14px;
            cursor: pointer;
            border-radius: 4px;
        }

        .menu-item button:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Main Menu</h1>
        <div class="container">
            <div class="menu-item">
                <h3>Submit a Query</h3>
                <asp:Button ID="btnSubmitQuery" runat="server" Text="Submit Query" OnClick="btnSubmitQuery_Click" />
            </div>

            <div class="menu-item">
                <h3>Status Tracking</h3>
                <asp:Button ID="btnTrackStatus" runat="server" Text="Track Status" OnClick="btnTrackStatus_Click" />
            </div>

            <div class="menu-item">
                <h3>Upload Documents</h3>
                <asp:Button ID="btnUploadDocs" runat="server" Text="Upload" OnClick="btnUploadDocs_Click" />
            </div>

            <div class="menu-item">
                <h3>Knowledge Base</h3>
                <asp:Button ID="btnKnowledgeBase" runat="server" Text="Browse FAQs" OnClick="btnKnowledgeBase_Click" />
            </div>

            <div class="menu-item">
                <h3>Analytics & Reporting</h3>
                <asp:Button ID="btnAnalytics" runat="server" Text="View Reports" OnClick="btnAnalytics_Click" />
            </div>
        </div>
    </form>
</body>
</html>
