<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebApplication1.MainSystem.ceshi.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </ItemTemplate>
    </asp:DataList>
    <div>
    
    <asp:DataList ID="UserList" DataKeyField="Uid" OnItemCreated="UserList_ItemCreated" 
            OnUpdateCommand="UserList_OnUpdateCommand" 
            OnDeleteCommand="UserList_OnDeleteCommand" runat="server" Width="100%" 
            RepeatColumns="6" OnEditCommand="UserList_OnEditCommand" 
            OnCancelCommand="UserList_OnCancelCommand" 
            onselectedindexchanged="UserList_SelectedIndexChanged">
    <HeaderTemplate>
     <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#E2EEF5" >
    <tr>
      <td width="17%" height="25" align="center" bgcolor="#E8F0F7">登陆名称</td>
      <td width="15%" align="center" bgcolor="#E8F0F7">真实姓名</td>
      <td width="17%" align="center" bgcolor="#E8F0F7">所属用户组</td>
      <td width="25%" align="center" bgcolor="#E8F0F7">拥有权限</td>
      <td width="14%" align="center" bgcolor="#E8F0F7">创建时间</td>
      <td width="12%" align="center" bgcolor="#E8F0F7">操作</td>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
     <tr>
      <td height="25" bgcolor="#FFFFFF"><img src="images/FriendICO.gif" width="15" height="15" style="margin-left:5px;" /> [<%#Eval("Uname")%>]<asp:Image ID="StateICO" ImageUrl='<%#GetUserState(Eval("uState").ToString()) %>' width="12" height="12" runat="server" /></td>
      <td align="center" bgcolor="#FFFFFF"><%#Eval("Rname")%></td>
      <td align="center" bgcolor="#FFFFFF"><%#Eval("UserGroup")%></td>
      <td align="center" bgcolor="#FFFFFF"><%#Eval("Purview")%></td>
      <td align="center" bgcolor="#FFFFFF"><%#Eval("Ctimes","{0:d}")%></td>
      <td align="center" bgcolor="#FFFFFF"><img src="images/Edit_ICOS.gif" width="14" height="15" border="0" align="absmiddle" /><asp:LinkButton CommandName="Edit"
              ID="Edit_But" ForeColor="#003366" runat="server">编辑</asp:LinkButton> <img src="images/DEL_ICOS.gif" width="14" height="15" border="0" align="absmiddle" /><asp:LinkButton CommandName="Delete"
              ID="Del_But" ForeColor="#003366" runat="server" >删除</asp:LinkButton></td>
    </tr>
    </ItemTemplate>
    <EditItemTemplate>
    <tr>
      <td height="25" bgcolor="#E8F0F7"><img src="images/FriendICO.gif" width="15" height="15" style="margin-left:5px;" /> <%#Eval("Uname")%><asp:CheckBox ID="User_State" Checked='<%#GetBoxState(Eval("uState").ToString().Trim()) %>' runat="server" Text="启用账户" />
      </td>
          <td align="center" bgcolor="#E8F0F7"><asp:TextBox ID="User_Rname" runat="server" CssClass="inputX"
                  Text='<%#Eval("Rname")%>' Width="80px"></asp:TextBox>
          </td>
          <td align="center" bgcolor="#E8F0F7">
              <asp:DropDownList ID="User_Group" runat="server" CssClass="FontBlue12">
                  <asp:ListItem Value="Guest">来宾组</asp:ListItem>
                  <asp:ListItem Value="Editor">编辑组</asp:ListItem>
                  <asp:ListItem Value="System">系统组</asp:ListItem>
              </asp:DropDownList>
          </td>
          <td align="center" bgcolor="#E8F0F7">
              <asp:CheckBoxList ID="User_Priv" runat="server" CssClass="FontBlue12"
                  RepeatDirection="Horizontal">
                  <asp:ListItem Value="r">读</asp:ListItem>
                  <asp:ListItem Value="w">写</asp:ListItem>
                  <asp:ListItem Value="e">编辑</asp:ListItem>
                  <asp:ListItem Value="d">删除</asp:ListItem>
              </asp:CheckBoxList>
          </td>
           <td align="center" bgcolor="#E8F0F7"><%#Eval("Ctimes","{0:d}")%></td>
          <td align="center" bgcolor="#E8F0F7">
              <img align="absmiddle" border="0" height="15" src="images/Update_ICOS.gif"
                  width="14" /><asp:LinkButton ID="Update_But" runat="server"
                  CommandName="Update" ForeColor="#003366">更新</asp:LinkButton> <img align="absmiddle" border="0" height="15" src="images/Cancel_ICOS.gif"
                  width="14" /><asp:LinkButton ID="Cancel_But" runat="server"
                  CommandName="Cancel" ForeColor="#003366">取消</asp:LinkButton>
          </td>
        
    </tr>
    </EditItemTemplate>
    <FooterTemplate>
    </table>
        1
    </FooterTemplate>
        <SeparatorTemplate>
            --------------------
        </SeparatorTemplate>
    </asp:DataList>
    </div>
</asp:Content>
