﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caidan2J.aspx.cs" Inherits="WebApplication1.caidan2J" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<style>
#menu {
    width: 200px;
    margin: auto;
}
    #menu h1 {
    cursor: pointer;
    color: #FFF;
    font-size: 12px;
    padding: 5px 0 3px 10px;
    border: #C60 1px solid;
    margin-top: 1px;
    background-color: #F93;
}
#menu ul {
    padding-left: 15px;
    height: 100px;
    border: #E7E7E7 1px solid;
    border-top: none;
    overflow: auto;
}
#menu ul li {
    padding: 5px 0 3px 10px;
}
.no {
    display: none;
}
    
}
</style>
<script>
    function ShowMenu(obj, noid) {
        var block = document.getElementById(noid);
        var n = noid.substr(noid.length - 1);
        if (noid.length == 4) {
            var ul = document.getElementById(noid.substring(0, 3)).getElementsByTagName("ul");
            var h2 = document.getElementById(noid.substring(0, 3)).getElementsByTagName("h2");
            for (var i = 0; i < h2.length; i++) {
                h2[i].innerHTML = h2[i].innerHTML.replace("+", "-");
                h2[i].style.color = "";
            }
            obj.style.color = "#FF0000";
            for (var i = 0; i < ul.length; i++) {
                if (i != n) {
                    ul[i].className = "no";
                }
            }
        } else {
            var span = document.getElementById("menu").getElementsByTagName("span");
            var h1 = document.getElementById("menu").getElementsByTagName("h1");
            for (var i = 0; i < h1.length; i++) {
                h1[i].innerHTML = h1[i].innerHTML.replace("+", "-");
                h1[i].style.color = "";
            }
            obj.style.color = "#0000FF";
            for (var i = 0; i < span.length; i++) {
                if (i != n) {
                    span[i].className = "no";
                }
            }
        }
        if (block.className == "no") {
            block.className = "";
            obj.innerHTML = obj.innerHTML.replace("-", "+");
        } else {
            block.className = "no";
            obj.style.color = "";
        }
    }
</script>
<body>
    <form id="form1" runat="server">
    <div id="menu">
        <h1 onclick="javascript:ShowMenu(this,'NO0')">
            - 一级菜单A</h1>
        <span id="NO0" class="no">
            <h2 onclick="javascript:ShowMenu(this,'NO00')">
                - 一级菜单A_1</h2>
            <ul id="NO00" class="no">
                <li>一级菜单A_0</li>
                <li>一级菜单A_1</li>
                <li>一级菜单A_2</li>
                <li>一级菜单A_3</li>
                <li>一级菜单A_4</li>
                <li>一级菜单A_5</li>
            </ul>
            <h2 onclick="javascript:ShowMenu(this,'NO01')">
                - 一级菜单A_2</h2>
            <ul id="NO01" class="no">
                <li>一级菜单A_0</li>
                <li>一级菜单A_1</li>
                <li>一级菜单A_2</li>
                <li>一级菜单A_3</li>
                <li>一级菜单A_4</li>
            </ul>
            <h2 onclick="javascript:ShowMenu(this,'NO02')">
                - 一级菜单A_3</h2>
            <ul id="NO02" class="no">
                <li>一级菜单A_0</li>
                <li>一级菜单A_1</li>
                <li>一级菜单A_2</li>
                <li>一级菜单A_3</li>
                <li>一级菜单A_4</li>
                <li>一级菜单A_5</li>
                <li>一级菜单A_6</li>
            </ul>
            <h2 onclick="javascript:ShowMenu(this,'NO03')">
                - 一级菜单A_4</h2>
            <ul id="NO03" class="no">
                <li>一级菜单A_0</li>
                <li>一级菜单A_1</li>
                <li>一级菜单A_2</li>
                <li>一级菜单A_3</li>
                <li>一级菜单A_4</li>
                <li>一级菜单A_5</li>
                <li>一级菜单A_6</li>
                <li>一级菜单A_7</li>
            </ul>
        </span>
        <h1 onclick="javascript:ShowMenu(this,'NO1')">
            - 二级菜单B</h1>
        <span id="NO1" class="no">
            <h2 onclick="javascript:ShowMenu(this,'NO10')">
                - 二级菜单B_1</h2>
            <ul id="NO10" class="no">
                <li>二级菜单B_0</li>
                <li>二级菜单B_1</li>
                <li>二级菜单B_2</li>
                <li>二级菜单B_3</li>
                <li>二级菜单B_4</li>
                <li>二级菜单B_5</li>
                <li>二级菜单B_6</li>
                <li>二级菜单B_7</li>
            </ul>
            <h2 onclick="javascript:ShowMenu(this,'NO11')">
                - 二级菜单B_2</h2>
            <ul id="NO11" class="no">
                <li>二级菜单B_0</li>
                <li>二级菜单B_1</li>
                <li>二级菜单B_2</li>
                <li>二级菜单B_3</li>
                <li>二级菜单B_4</li>
                <li>二级菜单B_5</li>
                <li>二级菜单B_6</li>
                <li>二级菜单B_7</li>
            </ul>
        </span>
        <h1 onclick="javascript:ShowMenu(this,'NO2')">
            - 三级菜单C</h1>
        <span id="NO2" class="no">
            <h2 onclick="javascript:ShowMenu(this,'NO20')">
                - 三级菜单C_1</h2>
            <ul id="NO20" class="no">
                <li>三级菜单C_0</li>
                <li>三级菜单C_1</li>
                <li>三级菜单C_2</li>
                <li>三级菜单C_3</li>
                <li>三级菜单C_4</li>
                <li>三级菜单C_5</li>
                <li>三级菜单C_6</li>
                <li>三级菜单C_7</li>
                <li>三级菜单C_8</li>
                <li>三级菜单C_9</li>
            </ul>
            <h2 onclick="javascript:ShowMenu(this,'NO21')">
                - 三级菜单C_2</h2>
            <ul id="NO21" class="no">
                <li>三级菜单C_0</li>
                <li>三级菜单C_1</li>
                <li>三级菜单C_2</li>
                <li>三级菜单C_3</li>
                <li>三级菜单C_4</li>
            </ul>
        </span>
        <h1 onclick="javascript:ShowMenu(this,'NO3')">
            - 四级菜单D</h1>
        <span id="NO3" class="no">
            <h2 onclick="javascript:ShowMenu(this,'NO30')">
                - 四级菜单D_1</h2>
            <ul id="NO30" class="no">
                <li>四级菜单D_0</li>
                <li>四级菜单D_1</li>
                <li>四级菜单D_2</li>
                <li>四级菜单D_3</li>
            </ul>
            <h2 onclick="javascript:ShowMenu(this,'NO31')">
                - 四级菜单D_2</h2>
            <ul id="NO31" class="no">
                <li>四级菜单D_0</li>
                <li>四级菜单D_1</li>
                <li>四级菜单D_2</li>
                <li>四级菜单D_3</li>
                <li>四级菜单D_4</li>
                <li>四级菜单D_5</li>
            </ul>
        </span>
    </div>
    </form>
</body>
</html>
