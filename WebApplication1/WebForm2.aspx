<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true"
    CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="AjaxTab"
            Height="530px" Width="100%" ScrollBars="Auto">
            <asp:TabPanel runat="server" HeaderText="提取考生列表并群发短信" ID="TabPanel1">
                <HeaderTemplate>
                    添加乐器代码表
                </HeaderTemplate>
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Button" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="批量上传名单并发送">
                <HeaderTemplate>
                    删除乐器代码表
                </HeaderTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
    </div>
    <title>DIV CSS遮罩层</title>
    <script language="javascript" type="text/javascript">
 function showdiv() { 
 document.getElementById("bg").style.display ="block";
 document.getElementById("show").style.display ="block"; }
 function hidediv() {
 document.getElementById("bg").style.display ='none';
 document.getElementById("show").style.display ='none';
 } </script>
    
    <style type="text/css">
 #bg{ display: none; position: absolute; top: 0%; left: 0%; width: 100%; height: 100%; background-color: black; z-index:1001; -moz-opacity: 0.7; opacity:.70; filter: alpha(opacity=70);}
 #show{display: none; position: absolute; top: 25%; left: 22%; width: 53%; height: 49%; padding: 8px; border: 8px solid #E8E9F7; background-color: white; z-index:1002; overflow: auto;}
 </style>
     </head> 
    <body>
        
        <input id="btnshow" type="button" value="Show" onclick="showdiv();" />
        
        <div id="bg">
        </div>
        
        <div id="show">
           
            <input id="btnclose" type="button" value="关闭" onclick="hidediv();" />
            
        </div>
</asp:Content>
