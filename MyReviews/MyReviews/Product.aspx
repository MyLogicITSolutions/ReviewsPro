<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="MyReviews.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <table>
            <tr>
               <td>
                   <asp:Image ID="productImage" runat="server" Height="194px" Width="420px" src="images/image.jpg"/>
                </td>
            </tr>
             <tr>
                <td>
                   <h2 id="productName" runat="server">Product Name</h2>
                </td>
              </tr>
             
             <%-- <asp:GridView ID="listofReviews" runat="server">
             </asp:GridView>--%>
             
              <%--<tr>
                <td>
                   <h4 id="txtuserName" runat="server"></h4>
                    <h5 id="txtDate" runat="server"></h5>
                </td>
              </tr>
             <tr>
                 <td>
                   <p id="txtComments" runat="server"></p>
                     </td>
             </tr>--%>

           </table>             
         <asp:DataList ID="DataList1" runat="server">
             <ItemTemplate>
             <table>
             <tr>
                <td>
                  <%-- <h4 id="txtuserName" text="<%# Eval("FirstName") %>" runat="server"></h4>--%>
                   <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("LastName") %>' />
                     <asp:Label ID="Label3" runat="server" Text='<%# Eval("dor") %>' />
                </td>
              </tr>
             <tr>
                 <td>
                     <asp:Label ID="Label2" runat="server" Text='<%# Eval("comments") %>' />
                   <%--<p id="txtComments" text="<%# Eval("comments") %>" runat="server"></p>--%>
                 </td>
             </tr>
                 </table>
                 </ItemTemplate>
         </asp:DataList>
    </form>
</body>
</html>
