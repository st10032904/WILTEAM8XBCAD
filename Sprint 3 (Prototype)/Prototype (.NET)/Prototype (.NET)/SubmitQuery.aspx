<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitQuery.aspx.cs" Inherits="Prototype__.NET_.SubmitQuery" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Submit Query</title>
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
        }

        .form-container {
            background-color: white;
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 20px;
            width: 400px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .form-container h2 {
            color: #4CAF50;
            margin-bottom: 20px;
        }

        .form-container label {
            display: block;
            margin: 10px 0 5px;
            color: #333;
        }

        .form-container input, .form-container textarea, .form-container select {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .form-container button {
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 10px 15px;
            font-size: 16px;
            cursor: pointer;
            border-radius: 4px;
        }

        .form-container button:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-container">
                <h2>Submit a Query</h2>

                <label for="ddlCategory">Category:</label>
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                    <asp:ListItem>Select a Category</asp:ListItem>
                    <asp:ListItem>Academic Issue</asp:ListItem>
                    <asp:ListItem>Administrative Issue</asp:ListItem>
                    <asp:ListItem>Financial Aid</asp:ListItem>
                    
                </asp:DropDownList>

                <label for="txtTitle">Title:</label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Enter the title of your query"></asp:TextBox>

                <label for="txtDescription">Description:</label>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Describe your issue or question"></asp:TextBox>

                <asp:Button ID="btnSubmitQuery" runat="server" Text="Submit Query" CssClass="form-button" OnClick="btnSubmitQuery_Click" />
            </div>
        </div>
    </form>
</body>
</html>
