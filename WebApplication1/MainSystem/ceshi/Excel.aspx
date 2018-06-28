<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true" CodeBehind="Excel.aspx.cs" Inherits="WebApplication1.MainSystem.ceshi.Excel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>


       <div>
               <asp:FileUpload ID="FileUpload1" runat="server" />


       &nbsp;
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
            Text="上传Excel" />
              

    
       </div>


        <asp:Button ID="Button1" runat="server" Text="指定表导出表数据" 
            onclick="Button1_Click" />
              

    
&nbsp;
      
    
    
    
</div>
<div>
  <asp:Button ID="Button6" runat="server" onclick="Button6_Click" 
            Text="导入-》找到Excel-datatable-数据表" />
</div>
<div>

    <asp:Button ID="Button7" runat="server" onclick="Button7_Click" 
        Text="判断目录是否存在" />

</div>
</asp:Content>
