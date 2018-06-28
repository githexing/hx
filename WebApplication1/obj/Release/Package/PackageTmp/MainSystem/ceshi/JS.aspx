<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true"
    CodeBehind="JS.aspx.cs" Inherits="WebApplication1.MainSystem.ceshi.JS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <script type="text/javascript" language="javascript">
            function testAjax2() {
                var a = $("#SoftName").val(); ///获取id为qq 的东西的值
                var checkText = $("#impower").find("option:selected").text();
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "Ajax.aspx/GetJson",
                    data: "{'RID':'" + checkText + "'}",
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
        <input id="SoftName" size="4" name="SoftName" type="text" />
        当SoftName填写了"非常好的软件下载";
        <select id="impower" name="impower" onchange="document.getElementById('SoftName').value += '' + this.options[this.selectedIndex].text">
            <option value="1">免费版</option>
            <option value="2">破解版</option>
            <option value="3">1</option>
        </select>
        <input type="button" value="查询" onclick="testAjax2()" />
    </div>
    <div>
        <script type="text/javascript" language="javascript">
            function testAjax4() {
                var checkText = $("#Select1").find("option:selected").text();
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "JS.aspx/GetJson",
                    data: "{'RID':'" + checkText + "'}",
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
        <select id="Select1" name="impower">
            <option value="1">免费版</option>
            <option value="2">破解版</option>
            <option value="3">1</option>
        </select>
        <input type="button" value="查询" onclick="testAjax4()" />
        //静态查询成功！</div>
    <div>
        <script language="JavaScript" type="text/JavaScript">
<!--
            function showit() {
                showarea.innerHTML = A0103.value;
            }

//-->
        </script>
        <select name="A0103" id="A0103" onchange="showit()">
            <option value="张">张</option>
            <option value="李">李</option>
            <option value="羊">羊</option>
            <option value="管">管</option>
        </select>
        <span id="showarea"><input/></span>
    </div>
    <div>
      <select id="dlOrg" name="D1" runat="server" onchange="function1()">
                        <option></option>
                    </select>//动态查询成功！<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MSSQLConnectionString_Admin %>"
                        SelectCommand="SELECT daihao FROM yonghu "></asp:SqlDataSource>
                         
                    <script type="text/javascript">
                        function function1() {
                            alert(document.all.dlOrg.options[document.all.objSelect.selectedIndex].text);
                        }
                    </script>
                    <input type="button" value="查询" onclick="testAjax6()" />
                     <script type="text/javascript" language="javascript">
                         function testAjax6() {
                             var checkValue = $("#ctl00_ContentPlaceHolder1_dlOrg").val(); 
                             $.ajax({
                                 type: "POST",
                                 contentType: "application/json; charset=utf-8",
                                 dataType: "json",
                                 url: "JS.aspx/GetJson",
                                 data: "{'RID':'" + checkValue + "'}",
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
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>
    <div>
    <span style="font-size: 14px;"><script type="text/javascript">
                                       $(document).ready(function () {
                                           alert("<%=str %>");
                                       });
</script>
 
</span>
    </div>
</asp:Content>
