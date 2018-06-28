<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true"
    CodeBehind="Gongneng.aspx.cs" Inherits="WebApplication1.MainSystem.Xitong.Gongneng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                请选择用户：
            </td>
            <td>
                <asp:DropDownList ID="DropDownList_zubie" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                请选择系统：
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList_Yingyong" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow" AutoPostBack="True" 
                    onselectedindexchanged="RadioButtonList_Yingyong_SelectedIndexChanged">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                请选择功能：
            </td>
            <td colspan="3">
                <asp:CheckBoxList ID="CheckBoxList_canshu" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="0">显示</asp:ListItem>
                    <asp:ListItem Value="1">查询</asp:ListItem>
                    <asp:ListItem Value="2">修改</asp:ListItem>
                    <asp:ListItem Value="3">增加</asp:ListItem>
                    <asp:ListItem Value="4">删除</asp:ListItem>
                    <asp:ListItem Value="5">打印</asp:ListItem>
                    <asp:ListItem Value="6">导出</asp:ListItem>
                    <asp:ListItem Value="7">统计</asp:ListItem>
                    <asp:ListItem Value="8">选择院校</asp:ListItem>
                    <asp:ListItem Value="9">轨迹</asp:ListItem>
                </asp:CheckBoxList>
            </td>
             <td>
                                    <asp:RadioButtonList ID="RadioButtonList_canshu" runat="server" AutoPostBack="True"
                                        RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="RadioButtonList_canshu_SelectedIndexChanged">
                                        <asp:ListItem Value="1">全选</asp:ListItem>
                                        <asp:ListItem Value="2">反选</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:Button ID="Button_save" runat="server" OnClick="Button_save_Click" Text="授权功能" />
                                </td>
        </tr>
    </table>
    <div>
    
        <div style="float: none; min-height: 300px;">
            <div style="float: left">
                组别菜单：<asp:TreeView ID="TreeView1" runat="server" 
                    OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ShowCheckBoxes="All" 
                    ShowLines="True">
                </asp:TreeView>
            </div>
            <div style="float: left">
                组别用户： 用户代号：<asp:Label ID="yonghuLabel" runat="server" ForeColor="Red"></asp:Label>
                <asp:TreeView ID="TreeView3" runat="server" 
                    OnSelectedNodeChanged="TreeView3_SelectedNodeChanged" ShowCheckBoxes="All">
                </asp:TreeView>
            </div>
            <div style="float: left">
                <asp:RadioButtonList ID="RadioButtonList_shouquan" runat="server" 
                    AutoPostBack="True" 
                    OnSelectedIndexChanged="RadioButtonList_shouquan_SelectedIndexChanged" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">已授权菜单</asp:ListItem>
                    <asp:ListItem Value="0">未授权菜单</asp:ListItem>
                </asp:RadioButtonList>
                <asp:TreeView ID="TreeView2" runat="server" 
                    OnSelectedNodeChanged="TreeView2_SelectedNodeChanged" ShowLines="True">
                </asp:TreeView>
            </div>
        </div>
    
    </div>
</asp:Content>
