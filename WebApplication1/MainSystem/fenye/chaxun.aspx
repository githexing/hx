<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chaxun.aspx.cs" Inherits="WebZm.MainSystem.fenye.chaxun" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            height: 60px;
        }
        .style4
        {
            width: 247px;
            height: 60px;
        }
        .style5
        {
        }
        .style6
        {
            width: 203px;
            height: 60px;
        }
        .style7
        {
            height: 60px;
            width: 177px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="height: 265px">
    <tr>
    <td class="style5">&nbsp;请输入你所需要查询的姓名：</td>
    <td class="style7">
        <asp:TextBox ID="tb_xm" runat="server"></asp:TextBox>
        </td>
    <td class="style6"></td>
    <td class="style4"></td>

    </tr>
    <tr>
    <td class="style5">请输入你所需要查询的身份证：</td>
    <td class="style3" colspan="2">
        <asp:TextBox ID="tb_sfz" runat="server" Width="220px"></asp:TextBox>
        </td>
    <td class="style4">&nbsp;</td>

    </tr>
    <tr>
    <td class="style5">&nbsp;</td>
    <td class="style7">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="查询" 
            Width="175px" />
        </td>
    <td class="style6">&nbsp;</td>
    <td class="style4">&nbsp;</td>

    </tr>
    <tr>
    <td class="style5" colspan="4">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="912px" onselectedindexchanged="GridView1_SelectedIndexChanged" 
            AutoGenerateEditButton="True" AutoGenerateSelectButton="True">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("xuhao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("xuhao") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考生号">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("kaoshenghao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("kaoshenghao") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("xingming") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("xingming") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="性别">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("xingbie") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("xingbie") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="身份证">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("shenfenzheng") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("shenfenzheng") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="选择" ShowSelectButton="True"   />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        </td>

    </tr>
    </table>
    </div>
    </form>
</body>
</html>
