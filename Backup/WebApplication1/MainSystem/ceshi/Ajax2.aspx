<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true" CodeBehind="Ajax2.aspx.cs" Inherits="WebApplication1.MainSystem.ceshi.Ajax2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
<div>
    <asp:Button ID="Button1" runat="server" Text="调用存储过程" onclick="Button1_Click" />
    <br />
</div>
<div>

    &nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button2" runat="server" Text="MD5加密密码" 
        onclick="Button2_Click" />
    <asp:Label ID="Label1" runat="server"></asp:Label>
</div>

</asp:Content>
