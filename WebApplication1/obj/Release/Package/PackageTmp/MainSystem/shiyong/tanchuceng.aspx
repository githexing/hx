﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true"
    CodeBehind="tanchuceng.aspx.cs" Inherits="WebApplication1.MainSystem.shiyong.tanchuceng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <div>
        <style type="text/css">
            html, body
            {
                height: 100%;
                overflow: hidden;
            }
            bodydiv, h2
            {
                margin: 0;
                padding: 0;
            }
            body
            {
                font: 12px/1.5 Tahoma;
            }
            center
            {
                padding-top: 10px;
            }
            button
            {
                cursor: pointer;
            }
            #win
            {
                position: absolute;
                top: 50%;
                left: 50%;
                width: 400px;
                height: 200px;
                background: #fff;
                border: 4px solid #f90;
                margin: -102px 0 0 -202px;
                display: none;
            }
            h2
            {
                font-size: 12px;
                height: 18px;
                text-align: right;
                background: #FC0;
                border-bottom: 3px solid #f90;
                padding: 5px;
                cursor: move;
            }
            h2 span
            {
                color: #f90;
                cursor: pointer;
                background: #fff;
                border: 1px solid #f90;
                padding: 0 2px;
            }
        </style>
    </div>
    <script type="text/jscript">
        window.onload = function () {
            var oWin = document.getElementById("win");
//            var oBtn = document.getElementsByTagName("button")[0];
            var oBtn = document.getElementById("aa");
            var oClose = document.getElementById("close");
            var oH2 = oWin.getElementsByTagName("h2")[0];
            var bDrag = false;
            var disX = disY = 0;
            oBtn.onclick = function () {
                oWin.style.display = "block"
            };
            oClose.onclick = function () {
                oWin.style.display = "none"

            };
            oClose.onmousedown = function (event) {
                (event || window.event).cancelBubble = true;
            };
            oH2.onmousedown = function (event) {
                var event = event || window.event;
                bDrag = true;
                disX = event.clientX - oWin.offsetLeft;
                disY = event.clientY - oWin.offsetTop;
                this.setCapture && this.setCapture();
                return false
            };
            document.onmousemove = function (event) {
                if (!bDrag) return;
                var event = event || window.event;
                var iL = event.clientX - disX;
                var iT = event.clientY - disY;
                var maxL = document.documentElement.clientWidth - oWin.offsetWidth;
                var maxT = document.documentElement.clientHeight - oWin.offsetHeight;
                iL = iL < 0 ? 0 : iL;
                iL = iL > maxL ? maxL : iL;
                iT = iT < 0 ? 0 : iT;
                iT = iT > maxT ? maxT : iT;

                oWin.style.marginTop = oWin.style.marginLeft = 0;
                oWin.style.left = iL + "px";
                oWin.style.top = iT + "px";
                return false
            };
            document.onmouseup = window.onblur = oH2.onlosecapture = function () {
                bDrag = false;
                oH2.releaseCapture && oH2.releaseCapture();
            };
        };
    </script>
    <div id="win">
        <h2>
            <span id="close">请关闭×</span></h2>
        <table>
            <tr>
                <td>
                    我我啊啊啊啊啊啊啊啊啊啊啊啊啊啊
                </td>
            </tr>
        </table>
    </div>
    <center>
    <%--  <a id="aa"  href="javascript:void(0);">弹出层</a>--%>
    <input type="button" id="aa"  value="弹出层"/>
    </center>

     <div>
        请输入内容：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>请输入手机号码：<asp:TextBox ID="TextBox2"
            runat="server"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="发送短信"  BackColor="White" BorderStyle="Groove" CssClass="sbbtn"  OnClientClick="return confirm('您确认要发送短信吗?')" onclick="Button2_Click" />
    </div>
</asp:Content>
