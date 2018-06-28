<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" GridLines="Both" DataSourceID="srcMovies">
    <ItemTemplate>
        <h1><%#DataBinder.Eval(Container.DataItem,"Title") %></h1> <!-- 为种绑定数据的方法与上面一种是一样的，只是写法不同 -->
        <b>Directed by:</b><%#Eval("Director") %>
            <br />
        <b>Description:</b><%#Eval("Description") %>
    </ItemTemplate>
</asp:DataList>  
    </div>
    </form>
</body>
</html>
