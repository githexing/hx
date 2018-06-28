<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true"
    CodeBehind="Ajax.aspx.cs" Inherits="WebApplication1.MainSystem.ceshi.Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <script type="text/javascript" language="javascript">
            function testAjax() {

            }
        </script>
        <div>
            <button>
                用button测试ajax</button>
            <input type="button" value="testAjax" onclick="testAjax()" />
        </div>
    </div>
    <%--<div>
        <script src="../../Scripts/jquery-1.8.0.min.js" type="text/javascript"></script>
        <script type="text/javascript" language="javascript">
            function testAjax1() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "Test.ashx",
                    data: "{'RID':'123'}",
                    success: function (data) {
                        var result = eval("(" + data.d + ")"); //这句话是将json语句对象化
                        alert(result.ID);
                    },
                    error: function (err) {
                        alert("err:" + err);
                    }
                });
            }                                                          
        
        </script>
        <input type="button" value="testAjax" onclick="testAjax1()" />
    </div>--%>
    <div>
        <script type="text/javascript" language="javascript">
            function testAjax2() {
                var a = $("#qq").val(); ///获取id为qq 的东西的值
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "Ajax.aspx/GetJson",
                    data: "{'RID':'" + a + "'}",
                    success: function (data) {
                        //                        var result = eval("(" + data.d + ")"); //这句话是将json语句对象
                        alert(data);
                    },
                    error: function (err) {
                        alert("err:" + err);
                    }
                });
            }                                                          
        
        </script>
        <input type="text" id="qq" />
        <input type="button" value="testAjax" onclick="testAjax2()" />
    </div>
    <div>
        <select>
            <option value="volvo">Volvo</option>
            <option value="saab">Saab</option>
            <option value="opel">Opel</option>
            <option value="1">1</option>
        </select>
        <script type="text/javascript" language="javascript">
            function testAjax3() {
                var a = $("#qq").val(); ///获取id为qq 的东西的值
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "Ajax.aspx/GetJson",
                    data: "{'RID':'" + a + "'}",
                    success: function (data) {
                        var result = eval("(" + data.d + ")"); //这句话是将json语句对象化
                        alert(result.ID);
                    },
                    error: function (err) {
                        alert("err:" + err);
                    }
                });
            }                                                          
        
        </script>
    </div>
    <div>
        <script type="text/javascript">

            function StaticMethod() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Ajax.aspx/SayHello2",
                    data: "{name:'2'}",
                    dataType: 'json',
                    success: function (result) {
                        alert(result.d);
                    }
                });

            }


            //        }

        </script>
        <div>
            <input id="Button2" type="button" value="jquery调用aspx页面静态方法" onclick="StaticMethod()" />
        </div>
    </div>
    <div>
        <select name="sel">
            <option>1</option>
            <option>2</option>
            <option>3</option>
            <option>4</option>
        </select>
        <input type="submit" value="submit" />
    </div>
</asp:Content>
