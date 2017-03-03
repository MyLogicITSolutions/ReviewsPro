<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MyReviews.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>Joining Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Join Now</h2>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
                </tr>
            <tr>

                <td><asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label></td>
                 <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>  
                
            </tr>
             <tr>

                <td><asp:Label ID="Label20" runat="server" Text="E-Mail"></asp:Label></td>
                 <td><asp:TextBox ID="txtEmail" TextMode="Email" runat="server"></asp:TextBox></td>  
                
            </tr>
            <tr>

                <td><asp:Label ID="Label7" runat="server" Text="Mobile Number"></asp:Label></td>
                 <td><asp:TextBox ID="txtMobilenumber"   runat="server"></asp:TextBox>
                     
                </td>  
                
            </tr>
            <tr>

                <td><asp:Label ID="Label3" runat="server" Text="Password"></asp:Label></td>
                 <td><asp:TextBox ID="txtPassword" TextMode="Password"  runat="server"></asp:TextBox></td>  
                
            </tr>
            <tr>

                <td><asp:Label ID="Label4" runat="server" Text="Confirm Password"></asp:Label></td>
                 <td><asp:TextBox ID="txtConfirmPassword" TextMode="Password"  runat="server"></asp:TextBox>
                     
                </td>  
                
            </tr>
            <tr>

                <td><asp:Label ID="Label11" runat="server" Text="Gender"></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="ddlGender" runat="server">
                         <asp:ListItem>Male</asp:ListItem>
                         <asp:ListItem>Female</asp:ListItem>
                     </asp:DropDownList>

                 </td>  
                
            </tr>
            
            <tr>

                <td><asp:Label ID="Label6" runat="server" Text="Date of Birth"></asp:Label></td>
                 <td><asp:TextBox ID="txtDob" TextMode="Date"  runat="server"></asp:TextBox>
                     
                </td>  
                
            </tr>
            <tr>

                <td><asp:Label ID="Label8" runat="server" Text="Address"></asp:Label></td>
                 <td><asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server"></asp:TextBox></td>  
                
            </tr>
            <tr>

                <td><asp:Label ID="Label9" runat="server" Text="City"></asp:Label></td>
                 <td><asp:DropDownList ID="DDL3" runat="server">
                         <asp:ListItem>Hyderabad</asp:ListItem>
                           <asp:ListItem>Banglore</asp:ListItem>
                     <asp:ListItem>Pune</asp:ListItem>
                     <asp:ListItem>Chennai</asp:ListItem>
                     <asp:ListItem>Mumbai</asp:ListItem>
                     <asp:ListItem>Delhi</asp:ListItem>
                     <asp:ListItem>Kolkatha</asp:ListItem>
                     </asp:DropDownList></td>  
                
            </tr>
            <tr>

                <td><asp:Label ID="Label10" runat="server" Text="Country"></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DDL1" runat="server">
                         <asp:ListItem>India</asp:ListItem>
                     </asp:DropDownList>

                 </td>  
                
            </tr>
             <tr>
                 <td><asp:Label ID="Label5" runat="server" Text="Upload Profile Picture"></asp:Label></td>
                 <td><asp:FileUpload ID="FileUpload1" runat="server" />
                     <br />
                     <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>--%>
                 </td>
                 
             </tr>
            <tr>
                   <td>
                       <asp:Image ID="Image1" Height="150px" Width="150px" ImageUrl="~/Images/fav_act.jpg" runat="server" />

                   </td>
              </tr> 
             <tr>
                <td><asp:Button ID="Button1" runat="server" Text="register" OnClick="Button1_Click" /></td>
            </tr>
          </table>
        <h1 id="txtResult" runat="server"></h1>
       
    </div>
             
    </form>
</body>
</html>

