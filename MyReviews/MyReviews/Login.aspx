﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyReviews.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="username" placeholder="Enter your email id" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="password" placeholder="Enter your password" TextMode="Password" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="btnLogin" />
    
        <br />
    
    </div>
    </form>
</body>
</html>
