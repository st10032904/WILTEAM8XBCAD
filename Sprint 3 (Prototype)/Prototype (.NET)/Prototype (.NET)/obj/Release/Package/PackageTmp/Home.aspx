<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Prototype__.NET_.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .container {
            text-align: center;
        }

        .button {
            display: inline-block;
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 15px 25px;
            font-size: 18px;
            cursor: pointer;
            border-radius: 4px;
            text-decoration: none;
            margin: 10px;
        }

        .button:hover {
            background-color: #45a049;
        }

        .header {
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h1>Welcome to the University Query System</h1>
            </div>
            <a href="Register.aspx" class="button">Register</a>
            <a href="Login.aspx" class="button">Login</a>
            <a href="StaffLogin.aspx" class="button">Staff Login</a>
        </div>
    </form>
</body>
</html>
