<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true"
    CodeBehind="Yonghu.aspx.cs" Inherits="WebApplication1.MainSystem.Xitong.Yonghu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" onpageindexchanging="GridView1_PageIndexChanging" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            onsorting="GridView1_Sorting" SkinID="GridViewSkin" 
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowEditing="GridView1_RowEditing" 
            OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:BoundField DataField="daihao" HeaderText="代号" ReadOnly="True" />
                <asp:TemplateField HeaderText="名称">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox_mingcheng" runat="server" Text='<%# Bind("mingcheng") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label_mingcheng" runat="server" Text='<%# Bind("mingcheng") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="zubie" HeaderText="组别" ReadOnly="True" />
                <asp:CommandField ShowEditButton="True" />
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
    <div>
        <asp:Button ID="Button1" runat="server" Text="数据库导出表数据" 
            onclick="Button1_Click" />
    &nbsp;
        </div>
    <div>
    
    
    &nbsp;&nbsp;
        <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;
        <asp:Button ID="Button2" runat="server" Text="上传图片" onclick="Button2_Click" />
    &nbsp;
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
            Text="上传Excel" />
&nbsp;
        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
            Text="exce导入零时表" />
&nbsp;
        <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
            Text="生成数据到数据库" />
    
    
    &nbsp;
        <asp:Button ID="Button6" runat="server" onclick="Button6_Click" 
            Text="批量插入并生成数据表" />
    
    
    </div>
</asp:Content>
