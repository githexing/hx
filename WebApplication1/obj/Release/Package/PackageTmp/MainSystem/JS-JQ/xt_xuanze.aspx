<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true" CodeBehind="xt_xuanze.aspx.cs" Inherits="WebApplication1.MainSystem.JS_JQ.xt_xuanze" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    <div id ="num1">1。问题
    <input type="radio" value="A1" name="answer1"/>A
    <input type="radio" value="B1" name="answer1"/>B
    <input type="radio" value="C1" name="answer1"/>C
    <input type="radio" value="D1" name="answer1"/>D
</div>

<div id ="num2">2。问题
    <input type="radio" value="A2" name="answer2"/>A
    <input type="radio" value="B2" name="answer2"/>B
    <input type="radio" value="C2" name="answer2"/>C
    <input type="radio" value="D2" name="answer2"/>D
</div>
<div id ="num3">3。问题
    <input type="radio" value="A3" name="answer3"/>A
    <input type="radio" value="B3" name="answer3"/>B
    <input type="radio" value="C3" name="answer3"/>C
    <input type="radio" value="D3" name="answer3"/>D
</div>
<div id="show1">？</div>
<div id="show2">？</div>
<div id="show3">？</div>
<script>
    $(function () {
        $("input").click(function () {
            var quesnum = $(this).parent().attr("id");
            var num = quesnum.replace("num", "");
            $("#show" + num).html("第" + num + "题答案：" + $(this).val().substr(0, 1));
        })
    })
</script>

    </div>
</asp:Content>
