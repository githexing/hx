<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true" CodeBehind="IP.aspx.cs" Inherits="WebApplication1.MainSystem.ceshi.IP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    <table>
    <tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
    <td>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
         <td>
        <asp:Label ID="Label4" runat="server" Text="Label4"></asp:Label></td>
          <td>
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
    </tr>
    </table>
    <div>
   您的IP地址是：<span id="keleyivisitorip"></span>
<%--<script type="text/javascript" src="http://tool.keleyi.com/ip/visitoriphost/"></script>--%> 
        <script type="text/javascript" src="http://www.ip138.com/ip2city.asp"></script> 
<script>
    function a() {
        var asd = $("#keleyivisitorip").text(); 
        alert(asd); 
    }
</script>
<input  value="asdasdas" onclick="a()" type="button"/>
 
    </div>
    <div>
    <script>
        function ff() {
            var x = document.getElementById("demo").innerHTML="ASD";
           alert(x);
        }
        $(function () { 
        $("#qwe").click(function(){}
        });
    </script>
    <div id="demo">asdasda</div>
    <input type="button" onclick ="ff()" id="qwe" value="ASDD"/>
    </div>
    <div>

         <asp:Button ID="Button2" runat="server" Text="IP的例子" OnClick="Button2_Click" />
        <asp:TextBox ID="extBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
   

    </div>
</asp:Content>
