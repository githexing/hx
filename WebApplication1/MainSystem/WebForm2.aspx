<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebZm.MainSystem.fenye.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onsorting="GridView1_Sorting" AllowPaging="True" AllowSorting="True" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" 
        onrowdatabound="GridView1_RowDataBound" PageSize="20" ShowFooter="True" 
        SkinID="GridViewSkin">
        <Columns>
            <asp:BoundField DataField="xuhao" HeaderText="序号" SortExpression="xuhao" />
            <asp:BoundField DataField="xingming" HeaderText="姓名" 
                SortExpression="xingming" />
            <asp:BoundField DataField="xingbie" HeaderText="性别" SortExpression="xingbie" />
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
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="20px" 
        RepeatDirection="Horizontal">
        <asp:ListItem Value="男" Checked="True"></asp:ListItem>
        <asp:ListItem Value="女"></asp:ListItem>
    </asp:RadioButtonList>
    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" />
    </form>
</body>
</html>
