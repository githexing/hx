<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true"
    CodeBehind="tianjiadaohang.aspx.cs" Inherits="WebApplication1.MainSystem.Xitong.tianjiadaohang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <div>
        <asp:RadioButtonList ID="RadioButtonList2" runat="server">
        </asp:RadioButtonList>
    </div>
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="AjaxTab"
            Height="530px" Width="100%" ScrollBars="Auto">
            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="批量上传名单并发送">
                <HeaderTemplate>
                    查看菜单
                </HeaderTemplate>
                <ContentTemplate>
                 <div>
        <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="True" 
                         onselectedindexchanged="RadioButtonList3_SelectedIndexChanged" 
                         RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Selected="True">Admin</asp:ListItem>
            <asp:ListItem>Kaosheng</asp:ListItem>
        </asp:RadioButtonList>
    </div><div>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" PageSize="20" SkinID="GridViewSkin" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                        OnSorting="GridView1_Sorting" ShowFooter="True">
                        <Columns>
                            <asp:BoundField DataField="bianhao" HeaderText="编号" />
                            <asp:BoundField DataField="xuhao" HeaderText="序号" />
                            <asp:BoundField DataField="fuxuhao" HeaderText="副序号" />
                            <asp:BoundField DataField="mingcheng" HeaderText="名称" />
                            <asp:BoundField DataField="url" HeaderText="URL" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <PagerTemplate>
                            <div>
                                第<asp:Label ID="lblPageIndex" runat="server" Text="<%#((GridView)Container.Parent.Parent).PageIndex + 1 %>"></asp:Label>
                                页 共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount %>"></asp:Label>
                                页
                                <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                    CommandName="Page" Text="首页"></asp:LinkButton>
                                <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                    CommandName="Page" Text="上一页"></asp:LinkButton>
                                <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                    CommandName="Page" Text="下一页"></asp:LinkButton>
                                <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                    CommandName="Page" Text="尾页"></asp:LinkButton>
                                <asp:TextBox ID="txtNewPageIndex1" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1%>"
                                    Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                    CommandName="Page" Text="GO"></asp:LinkButton>
                            </div>
                        </PagerTemplate>
                    </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                    修改/添加菜单
                </HeaderTemplate>
                <ContentTemplate>
                    <div align="center">
                        <table>
                            <tr>
                                <td>
                                    请选择应用：
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Selected="True">Admin</asp:ListItem>
                                        <asp:ListItem>Kaosheng</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    请输入编号：
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    请输入序号：
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    请输入副序号：
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    请输入名称：
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    请输入url：
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    &nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" OnClientClick="return confirm('确定要更改吗？');"
                                        Text="更改" />
                                    &nbsp;
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="return confirm('确定要添加吗？');"
                                        Text="添加" />
                                    &nbsp;
                                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" OnClientClick="return confirm('确定要删除吗？');" Text="删除" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="清空" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
    </div>
</asp:Content>
