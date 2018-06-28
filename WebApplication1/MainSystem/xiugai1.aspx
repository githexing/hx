<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xiugai1.aspx.cs" Inherits="WebApplication1.MainSystem.xiugai" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-top: 250px" >
        <table align=center>
            <tr>
                <td align=right>
                   
                    请输入账号：</td>
                <td>
                   
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td align=right>
                   
                    请输入原密码：</td>
                <td>
                   
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td align=right>
                   
                    请输入新密码：</td>
                <td>
                   
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td  align=right>
                   
                    请再次输入密码：</td>
                <td>
                   
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td colspan="2" align=center>
                   
                    <asp:Button ID="Button1" runat="server" Text="提交" onclick="Button1_Click" 
                        style="height: 21px" />
&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="返回" Height="21px" 
                        onclick="Button2_Click" />
                   
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
