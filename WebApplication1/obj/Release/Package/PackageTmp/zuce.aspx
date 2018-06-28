<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="zuce.aspx.cs" Inherits="WebApplication1.zuce" %>

   <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="margin-top: 250px" >
    <table align="center">
    <tr>
    <td>账号：</td>
    <td>
        <asp:TextBox ID="TextBox_yonghu" runat="server" 
            ValidationGroup="ValidationSummary1"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td>密码：</td>
    <td>
        <asp:TextBox ID="TextBox_mima" runat="server" 
            ValidationGroup="ValidationSummary1"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td>确认密码：</td>
    <td>
        <asp:TextBox ID="TextBox_mima1" runat="server" 
            ValidationGroup="ValidationSummary1"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td>身份证号：</td>
    <td>
        <asp:TextBox ID="TextBox_sfz" runat="server" 
            ValidationGroup="ValidationSummary1"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td>姓名：</td>
    <td>
        <asp:TextBox ID="TextBox_xingming" runat="server" 
            ValidationGroup="ValidationSummary1"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td>地址：</td>
    <td>
        <asp:TextBox ID="TextBox_dizhi" runat="server" 
            ValidationGroup="ValidationSummary1"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td>电话：</td>
    <td>
        <asp:TextBox ID="TextBox_dianhua" runat="server" Height="17px" MaxLength="11" 
            ValidationGroup="ValidationSummary1"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td>电子邮件</td>
    <td>
        <asp:TextBox ID="TextBox_youjian" runat="server" 
            ValidationGroup="ValidationSummary1"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td >
                    校 验 码：
                  <td>  <img id="img_yanzhengma" runat="server" alt="看不清，请点击我" onclick="this.src=this.src+'?'"
                        src="YanZhengma.aspx" title="看不清，请点击我" /><asp:TextBox ID="TextBox_yanzhengma" runat="server"
                                MaxLength="4" Width="59px" TabIndex="3"></asp:TextBox>&nbsp;<a href="javascript:getimgcode()"
                            style="color: #0000FF" tabindex="4"></a></td>
                </td></td>
    <td>&nbsp;</td>
    </tr>
    <tr>
    <td colspan="2" align=center >
                    <asp:Button ID="Button1" runat="server" Text="提交" onclick="Button1_Click" 
                        ValidationGroup="ValidationSummary1" />
    &nbsp;
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="返回" />
    <td>&nbsp;</td>
    </tr>
    </table>
    </div>
    </div>
    <div>
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox_yonghu" Display="None" ErrorMessage="账号不能为空" 
            ValidationGroup="ValidationSummary1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TextBox_mima" Display="None" ErrorMessage="密码不能为空" 
            ValidationGroup="ValidationSummary1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="TextBox_mima1" Display="None" ErrorMessage="确认密码不能为空" 
            ValidationGroup="ValidationSummary1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="TextBox_xingming" Display="None" ErrorMessage="姓名不能为空" 
            ValidationGroup="ValidationSummary1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="TextBox_dizhi" Display="None" ErrorMessage="地址不能为空" 
            ValidationGroup="ValidationSummary1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ControlToValidate="TextBox_dianhua" Display="None" ErrorMessage="电话不能为空" 
            ValidationGroup="ValidationSummary1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
            ControlToValidate="TextBox_youjian" Display="None" ErrorMessage="邮件不能为空" 
            ValidationGroup="ValidationSummary1"></asp:RequiredFieldValidator>
    
    </div>
    <div>
    
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="TextBox_yonghu" Display="None" ErrorMessage="账号必须在6-13位" 
            ValidationExpression="\d{6}|\d{7}\d{8}|\d{9}\d{10}|\d{11}\d{12}|\d{13}"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="TextBox_sfz" Display="None" ErrorMessage="身份证请输入15或者18位" 
            ValidationExpression="\d{15}|\d{18}" ValidationGroup="ValidationSummary1"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="TextBox_mima" Display="None" ErrorMessage="密码不能少于6位" 
            
            ValidationExpression="\d{6}|\d{7}\d{8}|\d{9}\d{10}|\d{11}\d{12}|\d{13}|\d{14}|\d{15}|\d{16}|\d{17}" 
            ValidationGroup="ValidationSummary1"></asp:RegularExpressionValidator>
    
    </div>
    <div>
    
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            EnableTheming="True" ShowMessageBox="True" ShowSummary="False" 
            ValidationGroup="ValidationSummary1" />
    
    </div>
    </form>
    </body>
    </html>