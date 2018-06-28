<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true" CodeBehind="wenbenduxie.aspx.cs" Inherits="WebApplication1.MainSystem.ceshi.wenbenduxie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
<table>
<tr>
<td>
    <asp:Button ID="Button1" runat="server" Text="读取" onclick="Button1_Click" /></td>
<td>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    </td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td>
    <asp:Button ID="Button2" runat="server" Text="写入" onclick="Button2_Click" /></td>
<td>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    </td>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
</tr>
</table>
</div>
</asp:Content>
