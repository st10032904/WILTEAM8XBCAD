<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitQuery.aspx.cs" Inherits="Prototype__.NET_.SubmitQuery" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Submit Query</title>
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
            width: 400px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            text-align: center;
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

        .form-container .back-button {
            background-color: #f4f4f4;
            color: #333;
            border: 1px solid #ccc;
        }

        .form-container .back-button:hover {
            background-color: #ddd;
        }
    </style>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div class="form-container">
                <h2>Submit Query</h2>
                <label for="ddlQueryType">Query Type:</label>
                <asp:DropDownList ID="ddlQueryType" runat="server">
                    <asp:ListItem Text="Select Query Type" Value=""></asp:ListItem>
                    <asp:ListItem Text="Academic" Value="Academic"></asp:ListItem>
                    <asp:ListItem Text="Finances" Value="Finances"></asp:ListItem>
                    <asp:ListItem Text="Housing" Value="Housing"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                </asp:DropDownList>

                <label for="txtTitle">Title:</label>
                <asp:TextBox ID="txtTitle" runat="server" placeholder="Enter Title"></asp:TextBox>

                <label for="txtDescription">Description:</label>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4" placeholder="Describe your query"></asp:TextBox>

                <asp:Button ID="btnSubmitQuery" runat="server" Text="Submit" OnClick="btnSubmitQuery_Click" />

                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="back-button" OnClick="btnBack_Click" />
            </div>
        </form>
    </div>
</body>
</html>
