<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caidan1.aspx.cs" Inherits="WebApplication1.caidan1" %>
 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" />
<meta http-equiv="Content-Type" mrc="text/html; charset=gb2312">
<title>后台专用树型菜单，可刷新-www.mb5u.com </title>
<style type="text/css">
<!--
*{margin:0;padding:0;border:0;}
body {
 font-size:12px;
}
#nav {
 width:190px;
 line-height: 18px;
 list-style-type: none;
 text-align:left;
}
#nav a {
 width: 190px;
 display: block;
 padding-left:20px;
 /*Width(一定要)，否则下面的Li会变形*/
}
#nav li {
 background:#bbde79; /*一级目录的背景色*/
 float:left;
 BORDER-RIGHT: #8c8c8c 1px solid;
 BORDER-TOP: #dbfe99 1px solid;
 FONT-WEIGHT: bold;
 FONT-SIZE: 11px;
 PADDING-BOTTOM: 2px;
 BORDER-LEFT: #dbfe99 1px solid;
 CURSOR: hand;
 COLOR: black;
 PADDING-TOP: 4px;
 BORDER-BOTTOM: #8c8c8c 1px solid;
background: #BBDE78 url('/images/default/star.gif') no-repeat left center;
 /*float：left,本不应该设置，但由于在Firefox不能正常显示
 继续Nav的width,限制宽度，li自动向下延伸*/
}
#nav li a:hover{
 url('/images/default/star.gif') no-repeat left center; /*一级目录onMouseOver显示的背景色*/
}
#nav a:link  {
 color:#666; text-decoration:none;
}
#nav a:visited  {
 color:#666;text-decoration:none;
}
#nav a:hover  {
 color:#FFF;text-decoration:none;font-weight:bold;
}
/*====www.mb5u.com=====二级目录=========*/
#nav li ul {
 list-style:none;
 text-align:left;
}
#nav li ul li{ 
 BORDER-RIGHT: #cccccc 1px solid;
 BORDER-TOP: white 1px solid;
 FONT-SIZE: 11px;
 PADDING-BOTTOM: 2px;
 BORDER-LEFT: white 1px solid;
 CURSOR: hand;
 PADDING-TOP: 2px;
 BORDER-BOTTOM: #cccccc 1px solid;
 BACKGROUND-COLOR: #eeeeee; /*二级目录的背景色*/
}
#nav li ul a{
         padding-left:20px;
         width:188px;
 /* padding-left二级目录中文字向右移动，但Width必须重新设置=(总宽度-padding-left)*/
}
/*下面是二级目录的链接样式*/
#nav li ul a:link  {
 color:#666; text-decoration:none;
}
#nav li ul a:visited  {
 color:#666;text-decoration:none;
}
#nav li ul li a:hover {
 background:#d5d5d5;
 text-decoration:none;
 font-weight:normal;
}
/* www.mb5u.com */
#nav li:hover ul {
 left: auto;
}
#nav li.sfhover ul {
 left: auto;
}
#mrc {
 clear: left;
}
#nav ul.collapsed {
 display: none;
}
-->
#PARENT{
 width:300px;
 padding-left:20px;
}
</style>
<script type=text/javascript><!--
    var LastLeftID = "";
    function menuFix() {
        var obj = document.getElementById("Nav").getElementsByTagName("li");

        for (var i = 0; i < obj.length; i++) {
            obj[i].onmouseover = function () {
                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
            }
            obj[i].onMouseDown = function () {
                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
            }
            obj[i].onMouseUp = function () {
                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
            }
            obj[i].onmouseout = function () {
                this.className = this.className.replace(new RegExp("( ?|^)sfhover\\b"), "");
            }
        }
    }
    function DoMenu(emid) {
        var obj = document.getElementById(emid);
        obj.className = (obj.className.toLowerCase() == "expanded" ? "collapsed" : "expanded");
        if ((LastLeftID != "") && (emid != LastLeftID)) //封闭上一个Menu
        {
            document.getElementById(LastLeftID).className = "collapsed";
        }
        LastLeftID = emid;
    }
    function GetMenuID() {
        var MenuID = "";
        var _paramStr = new String(window.location.href);
        var _sharpPos = _paramStr.indexOf("#");

        if (_sharpPos >= 0 && _sharpPos < _paramStr.length - 1) {
            _paramStr = _paramStr.substring(_sharpPos + 1, _paramStr.length);
        }
        else {
            _paramStr = "";
        }

        if (_paramStr.length > 0) {
            var _paramArr = _paramStr.split("&");
            if (_paramArr.length > 0) {
                var _paramKeyVal = _paramArr[0].split("=");
                if (_paramKeyVal.length > 0) {
                    MenuID = _paramKeyVal[1];
                }
            }
        }

        if (MenuID != "") {
            DoMenu(MenuID)
        }
    }
    GetMenuID(); //*function顺序要留意，否则在Firefox里GetMenuID()不起效果。
    menuFix();
-->
</script>
</head>
<body>
<div id="PARENT">
<ul id="nav">
<li><a href="#Menu=ChildMenu1"  onclick="DoMenu('ChildMenu1')">我的网站</a>
<ul id="ChildMenu1" class="collapsed">
 <li><a href="/" target="_blank">www.mb5u.com</a></li>
 <li><a href="/" target="_blank">www.mb5u.com</a></li>
 <li><a href="/" target="_blank">www.mb5u.com</a></li>
 </ul>
</li>
<li><a href="#Menu=ChildMenu2" onclick="DoMenu('ChildMenu2')">我的帐务</a>
 <ul id="ChildMenu2" class="collapsed">
 <li><a href="/" target="_blank">支付</a></li>
 <li><a href="/">网上支付</a></li>
 <li><a href="/">登记汇款</a></li>
 <li><a href="/">历史帐务</a></li>
 </ul>
</li>
<li><a href="#Menu=ChildMenu3" onclick="DoMenu('ChildMenu3')">网站治理</a>
 <ul id="ChildMenu3" class="collapsed">
 <li><a href="#">登录</a></li>
 <li><a href="/" target="_blank">治理</a></li>
 <li><a href="#">治理</a></li>
 <li><a href="#">治理</a></li>
 </ul>
</li>
<li><a href="#Menu=ChildMenu4" onclick="DoMenu('ChildMenu4')">网站治理</a>
 <ul id="ChildMenu4" class="collapsed">
 <li><a href="caidan2J.aspx">登录</a></li>
 <li><a href="www.mb5u.com" target="_blank">治理</a></li>
 <li><a href="/">治理</a></li>
 <li><a href="/">治理</a></li>
 </ul>
</li>
</ul>
</div>
</body>
</html>
