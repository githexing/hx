<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true"CodeBehind="Gridview.aspx.cs" Inherits="WebApplication1.MainSystem.ceshi.Gridview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:LinkButton ID="LinkButton_fanxuan" runat="server" OnClick="LinkButton_fanxuan_Click">反选当前页</asp:LinkButton>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="通过啦" />
    </div>
    <div>
        &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            onselectedindexchanging="GridView1_SelectedIndexChanging" 
            AllowPaging="True" AllowSorting="True" 
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowdatabound="GridView1_RowDataBound" onsorting="GridView1_Sorting" 
            PageSize="1" ShowFooter="True">
            <Columns>
                <asp:TemplateField HeaderText="代号">
                 <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("daihao") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="名称">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("mingcheng") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="图片">
                    <ItemTemplate>
                        <img alt="" id="images" src='<%#Eval("images")%>' style="border: 0" width="100" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="单个审核">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_shenhe" runat="server" CommandArgument='<%# Eval("daihao") %>'
                            OnClick="LinkButton_shenhe_Click">审核考生</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="批量审核">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
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
    <asp:Image ID="Image1" runat="server"  src="../../images/tab-left.jpg" />  
</asp:Content>
