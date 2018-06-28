<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shanchu.aspx.cs" Inherits="WebZm.MainSystem.fenye.shanchu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 261px;
            height: 38px;
        }
        .style2
        {
            width: 221px;
            height: 38px;
        }
        .style3
        {
            width: 208px;
            height: 38px;
        }
        .style4
        {
            width: 379px;
            height: 38px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td class="style4"></td>
    <td class="style3">请输入考生号：</td>
    <td class="style2">
        <asp:TextBox ID="tb_ksh" runat="server"></asp:TextBox>
        </td>
    <td class="style1"></td>

    </tr>
    <tr>
    <td class="style4">&nbsp;</td>
    <td class="style3">请输入姓名：</td>
    <td class="style2">
        <asp:TextBox ID="tb_xm" runat="server"></asp:TextBox>
        </td>
    <td class="style1">&nbsp;</td>

    </tr>
    <tr>
    <td class="style4">&nbsp;</td>
    <td class="style3">请输入身份证</td>
    <td class="style2">
        <asp:TextBox ID="tb_sfz" runat="server"></asp:TextBox>
        </td>
    <td class="style1">&nbsp;</td>

    </tr>
    <tr>
    <td class="style4">&nbsp;</td>
    <td class="style3">&nbsp;&nbsp;&nbsp;&nbsp; </td>
    <td class="style2">
        <asp:Button ID="shanchu1" runat="server" onclick="shanchu1_Click" Text="删除" 
            Width="74px" />
&nbsp;
        <asp:Button ID="fanhui" runat="server" Text="返回" Width="76px" />
        </td>
    <td class="style1">&nbsp;</td>

    </tr>
    </table>
    </div>
    </form>
</body>
</html>
