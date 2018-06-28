<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true" CodeBehind="caidan1.aspx.cs" Inherits="WebApplication1.MainSystem.JS_JQ.caidan1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>
<style>

nav a {
text-decoration: none;
}
nav > ul > li {
float: left;
text-align: center;
padding: 0 0.5em;
}

nav li ul.sub-menu {
display: none;
padding-left: 0 !important;
}

.sub-menu li {
color: white;
}

.sub-menu li:hover {
background-color: black;
}

.sub-menu li:hover a {
color: white;
}

ul {
list-style: none;
}
</style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<nav>
<ul>
<li><a href="#">Home
<ul class="sub-menu">
<li><a href="#">sub1</a></li>
<li><a href="#">sub2</a></li>
<li><a href="#">sub3</a></li>
</ul>
</li>
<li><a href="#">Programming
<ul class="sub-menu">
<li><a href="#">sub1</a></li>
<li><a href="#">sub2</a></li>
<li><a href="#">sub3</a></li>
</ul>
</li>
<li><a href="#">Japanese
<ul class="sub-menu">
<li><a href="#">sub1</a></li>
<li><a href="#">sub2</a></li>
<li><a href="#">sub3</a></li>
</ul>
</li>
</ul>
</nav> 
<script type="text/javascript">
    $(document).ready(function () {
        $('nav li').hover(function () {
            $(this).find('.sub-menu').css('display', 'block');
        }, function () {
            $(this).find('.sub-menu').css('display', 'none');
        });
    });
</script>
<div>

 <script type="text/javascript">
     $(document).ready(function () {
         $(".flip").mouseover(function () {
             $(this).next("div").slideDown(1);
         });
         $(".content").mouseleave(function () {
             $(this).children("div").slideUp(1);
         });
     });
</script>
   
<style type="text/css"> 
div.panel,p.flip
{
  
margin:0px;
padding:5px;
text-align:center;

border:solid 1px #c3c3c3;
}
div.panel
{
  
height:120px;
display:none;
}
</style>
   
 
 <div class="content" style="float:left;display:block;width:300px;">
<p class="flip">滑过这里</p>
<div class="panel">
<p >11111111111111111</p>
<p>2222222222222222222222</p>
</div>
 </div>
<div class="content" style="float:left;display:block;width:300px;">
<p class="flip" >滑过这里</p>
<div class="panel">
<p >11111111111111111</p>
<p>2222222222222222222222</p>
</div>
 </div>
</div> 
</asp:Content>
