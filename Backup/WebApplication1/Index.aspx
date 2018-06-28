<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication1.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<div align="right">当前在线人数：
<asp:Label ID="Label1" runat="server"></asp:Label>
</div>
    <form id="form1" runat="server">
   <div style="margin-top: 10%; 8: ;" >
    <div align="center" style="margin-top: 10px" >
    <h3 style="border-width: medium; border-color: #FFFF00; font-size: 100px; text-decoration: none; font-weight: bold; color: #CC6600; border-top-style: groove; border-bottom-style: groove;">
        \学生信息录入系统/
    </h3>
    </div>
    <div style="margin-top: 50px;" >
    <table align="center" style="border: thick double #FFFF00;">
            <tr >
                <td align="right" style="border: medium groove #FFFF00;">
                    账号：
                </td>
                <td >
                    <asp:TextBox ID="TextBox1" runat="server" TabIndex="1">admin</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right"style="border: medium groove #FFFF00;">
                    密码：
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" TabIndex="2" TextMode="Password">123456</asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="border: medium groove #FFFF00;">
                    校 验 码：
                  <td >  
                      <asp:TextBox ID="TextBox_yanzhengma" runat="server"
                                MaxLength="4" Width="59px" TabIndex="3">1234</asp:TextBox>&nbsp;<img id="img_yanzhengma" runat="server"   alt="看不清，请点击我" onclick="this.src=this.src+'?'"
                        src="YanZhengma.aspx" title="看不清，请点击我" />&nbsp;<a href="javascript:getimgcode()"
                            style="color: #0000FF" tabindex="4">
                      </a></td>
                </td>
            </tr>
            <tr>
                <td colspan="2"  align=center style="border: medium groove #FFFF00;">
                    <asp:RadioButtonList ID="RadioButtonList_xuanze" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow" 
                        onselectedindexchanged="RadioButtonList_xuanze_SelectedIndexChanged" 
                        RepeatColumns="4">
                        <asp:ListItem Value="0">学生</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">老师</asp:ListItem>
                    </asp:RadioButtonList>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" 
                        TabIndex="5" />
                &nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="注册" 
                        TabIndex="6" />
                </td>
            </tr>
            </table>
    </div>
    </div>
    </form>
</body>
</html>
