<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MyReviews.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" Height="186px" Width="185px" />
        <asp:GridView ID="gridView" runat="server" AlternatingRowStyle-BackColor="WhiteSmoke" AutoGenerateEditButton ></asp:GridView>
    </div>
    </form>
</body>
</html>
