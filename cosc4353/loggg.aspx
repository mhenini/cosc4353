<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loggg.aspx.cs" Inherits="cosc4353.loggg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                    <asp:BoundField DataField="confirmPassword" HeaderText="confirmPassword" SortExpression="confirmPassword" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LoginPageConnectionString %>" SelectCommand="SELECT * FROM [UserLog]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
