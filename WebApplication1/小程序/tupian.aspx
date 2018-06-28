<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tupian.aspx.cs" Inherits="WebApplication1.小程序.tupian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" Height="136px" Width="106px" />
    

        <asp:Button runat="server" Text="转换" onclick="FileToStream" />
<asp:TextBox ID="message" runat="server" Width="100%" Height="600px" TextMode="MultiLine" Wrap="true"></asp:TextBox>
    </div>
    </form>
</body>
</html>
