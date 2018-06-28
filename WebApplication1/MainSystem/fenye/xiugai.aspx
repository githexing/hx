<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xiugai.aspx.cs" Inherits="WebZm.xiugai" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #Table1
        {
            height: 155px;
            width: 1048px;
        }
        .style6
        {
            height: 38px;
            width: 193px;
        }
        .style7
        {
        }
        .style26
        {
            height: 38px;
            width: 413px;
        }
        .style27
        {
            width: 413px;
        }
        .style28
        {
            height: 38px;
            width: 446px;
        }
        .style29
        {
            width: 446px;
        }
        .style41
        {
            width: 1039px;
        }
        .style44
        {
            height: 38px;
            width: 334px;
        }
        .style45
        {
            width: 334px;
        }
        .style46
        {
            height: 38px;
            width: 289px;
        }
        .style47
        {
            width: 289px;
        }
        .style48
        {
            height: 38px;
            width: 344px;
        }
        .style49
        {
            width: 344px;
        }
        .style52
        {
            height: 79px;
        }
        .style53
        {
            height: 79px;
            width: 446px;
        }
        .style54
        {
            height: 79px;
            width: 334px;
        }
        .style55
        {
            height: 79px;
            width: 413px;
        }
        .style58
        {
            height: 38px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <Table ID="Table1">
        <tr>
        <td class="style28">
            此处查询：</td>
        <td class="style44">&nbsp;</td>
        <td class="style6"></td>
        <td class="style48" colspan="2">&nbsp;</td>
        <td class="style46"></td>
        <td class="style26">&nbsp;</td>
        <td class="style26">&nbsp;</td>
        </tr>

        <tr>
        <td class="style29">&nbsp;</td>
        <td class="style45">&nbsp;&nbsp;&nbsp;&nbsp;姓名：</td>
        <td class="style7">
            <asp:TextBox ID="tb_xm" runat="server"></asp:TextBox>
            </td>
        <td class="style49" colspan="2">&nbsp;身份证：</td>
        <td class="style47">
            <asp:TextBox ID="tb_sfz" runat="server"></asp:TextBox>
            </td>
        <td class="style27">
            &nbsp;&nbsp;&nbsp;
            考生序号：</td>
        <td class="style27">
            <asp:TextBox ID="tb_xh" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
        <td class="style29">&nbsp;</td>
        <td class="style45">&nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td class="style49" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        <td class="style47">
            &nbsp;</td>
        <td class="style27">
            &nbsp;</td>
        <td class="style27">
            &nbsp;</td>
        </tr>

        <tr>
        <td class="style28"></td>
        <td class="style44"></td>
        <td class="style58" colspan="4">&nbsp;&nbsp;
            <asp:Button ID="chaxun" runat="server" onclick="chaxun_Click" Text="查询" 
                Width="279px" />
            </td>
        <td class="style26"></td>
        <td class="style26"></td>
        </tr>

        <tr>
        <td class="style53">&nbsp;</td>
        <td class="style54">&nbsp;</td>
        <td class="style52" colspan="4">&nbsp;</td>
        <td class="style55">&nbsp;</td>
        <td class="style55">&nbsp;</td>
        </tr>

        <tr>
        <td class="style29">
            <asp:TextBox ID="tb_xhh" runat="server"></asp:TextBox>
            </td>
        <td class="style45">
            <asp:TextBox ID="tb_ksh" runat="server"></asp:TextBox>
            </td>
        <td class="style7" colspan="2">
            <asp:TextBox ID="tb_xmm" runat="server" style="margin-bottom: 0px"></asp:TextBox>
            </td>
        <td class="style7" colspan="2">
            <asp:TextBox ID="tb_xbb" runat="server"></asp:TextBox>
            </td>
        <td class="style27">
            <asp:TextBox ID="tb_sfzz" runat="server"></asp:TextBox>
            </td>
        <td class="style27">
            <asp:TextBox ID="tb_mzz" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
        <td class="style29">&nbsp;</td>
        <td class="style45">&nbsp;</td>
        <td class="style7" colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="tb_gx" runat="server" onclick="tb_gx_Click" Text="更新" 
                Width="191px" />
            </td>
        <td class="style27">&nbsp;</td>
        <td class="style27">&nbsp;</td>
        </tr>

        </Table>
        
        <table style="height: 390px">
        <tr>
        <td class="style41">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                Height="56px" onselectedindexchanged="GridView2_SelectedIndexChanged" 
                Width="899px">
                <Columns>
                    <asp:BoundField DataField="xuhao" HeaderText="序号" />
                    <asp:BoundField DataField="kaoshenghao" HeaderText="考生号" />
                    <asp:BoundField DataField="xingming" HeaderText="姓名" />
                    <asp:BoundField DataField="xingbie" HeaderText="性别" />
                    <asp:BoundField DataField="shenfenzheng" HeaderText="身份证" />
                    <asp:BoundField DataField="minzu" HeaderText="民族" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                Width="903px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
                BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" 
                onselectedindexchanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
               
                    <asp:BoundField DataField="xuhao" HeaderText="序号" 
                        ApplyFormatInEditMode="True" />
                    <asp:BoundField DataField="kaoshenghao" HeaderText="考生号" />
                    <asp:BoundField DataField="xingming" HeaderText="姓名" />
                    <asp:BoundField HeaderText="性别" DataField="xingbie" />
                    <asp:BoundField DataField="shenfenzheng" HeaderText="身份证" />
                    <asp:BoundField DataField="minzu" HeaderText="名族" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            </td>

        </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
