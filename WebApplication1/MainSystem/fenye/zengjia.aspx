<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zengjia.aspx.cs" Inherits="WebZm.MainSystem.fenye.zengjia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            width: 174px;
            height: 48px;
        }
        .style4
        {
            width: 199px;
            height: 48px;
        }
        .style5
        {
            width: 202px;
            height: 48px;
        }
        .style6
        {
            width: 334px;
            height: 48px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td class="style6">    </td>
    <td class="style2"></td>
    <td class="style4"></td>
    <td class="style5"></td>

    </tr>
    <tr>
    <td class="style6">    &nbsp;</td>
    <td class="style2">考生号：</td>
    <td class="style4">
        <asp:TextBox ID="tb_ksh" runat="server"></asp:TextBox>
        </td>
    <td class="style5">&nbsp;</td>

    </tr>
    <tr>
    <td class="style6">    &nbsp;</td>
    <td class="style2">姓名：</td>
    <td class="style4">
        <asp:TextBox ID="tb_xm" runat="server"></asp:TextBox>
        </td>
    <td class="style5">&nbsp;</td>

    </tr>
    <tr>
    <td class="style6">    &nbsp;</td>
    <td class="style2">身份证：</td>
    <td class="style4">
        <asp:TextBox ID="tb_sfz" runat="server"></asp:TextBox>
        </td>
    <td class="style5">&nbsp;</td>

    </tr>
    <tr>
    <td class="style6">    &nbsp;</td>
    <td class="style2">性别：</td>
    <td class="style4">
        <asp:TextBox ID="tb_xb" runat="server"></asp:TextBox>
        </td>
    <td class="style5">&nbsp;</td>

    </tr>
    <tr>
    <td class="style6">    &nbsp;</td>
    <td class="style2">民族：</td>
    <td class="style4">
        <asp:TextBox ID="tb_mz" runat="server"></asp:TextBox>
        </td>
    <td class="style5">&nbsp;</td>

    </tr>
    <tr>
    <td class="style6">    &nbsp;</td>
    <td class="style2">&nbsp;</td>
    <td class="style4">
        <asp:Button ID="tianjia" runat="server" onclick="tianjia_Click" Text="添加" />
&nbsp;
        <asp:Button ID="quxiao" runat="server" Text="取消" />
        </td>
    <td class="style5">&nbsp;</td>

    </tr>
    </table>
    </div>
    </form>
</body>
</html>
