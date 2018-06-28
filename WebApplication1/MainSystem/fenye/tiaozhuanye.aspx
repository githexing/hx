<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tiaozhuanye.aspx.cs" Inherits="WebZm.tiaozhuanye" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            width: 284px;
            height: 81px;
        }
        .style3
        {
            width: 341px;
            height: 81px;
        }
        .style4
        {
            width: 817px;
            height: 81px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width: 1108px">
    <tr>
    <td class="style4"></td>
    <td class="style3"></td>
    <td class="style2"></td>
    </tr>
    
    <tr>
    <td class="style4">&nbsp;</td>
    <td class="style3">
        <asp:Button ID="xiugaimima" runat="server" Height="37px" 
            onclick="xiugaimima_Click" Text="修改信息点此进入" Width="352px" />
        </td>
    <td class="style2">&nbsp;</td>
    </tr>
    
    <tr>
    <td class="style4">&nbsp;</td>
    <td class="style3">
        <asp:Button ID="chaxun" runat="server" Height="40px" onclick="chaxun_Click" 
            Text="查询信息点此进入" Width="353px" />
        </td>
    <td class="style2">&nbsp;</td>
    </tr>
    
    <tr>
    <td class="style4">&nbsp;</td>
    <td class="style3">
        <asp:Button ID="Button3" runat="server" Height="41px" Text="增加信息点此进入" 
            Width="349px" onclick="Button3_Click" />
        </td>
    <td class="style2">&nbsp;</td>
    </tr>
    
    <tr>
    <td class="style4">&nbsp;</td>
    <td class="style3">
        <asp:Button ID="Button4" runat="server" Height="38px" Text="删除信息点此进入" 
            Width="349px" onclick="Button4_Click" />
        </td>
    <td class="style2">&nbsp;</td>
    </tr>
    
    </table>
    </div>
    </form>
</body>
</html>
