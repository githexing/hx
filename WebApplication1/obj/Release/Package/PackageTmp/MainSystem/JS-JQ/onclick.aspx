<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true" CodeBehind="onclick.aspx.cs" Inherits="WebApplication1.MainSystem.JS_JQ.onclick" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<script>
    function aa() { 
        var aa = $('input[name="ctl00$ContentPlaceHolder1$rbl_leixing"]:checked');
        alert(aa.val());
    };

    function as() {
        alert(1);
        var as = $('input[name="ass"]:checked');
        alert(as.val());
    }
</script>
 <asp:RadioButtonList ID="rbl_leixing" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">招生服务范围内学生</asp:ListItem>
                            <asp:ListItem Value="2">非招生服务范围内学生</asp:ListItem>
                        </asp:RadioButtonList>
     

</div>
<div> 
 <input id="a" name="ass"  type="radio" value="哈哈" onclick="as()"/><label>哈哈 </label>
    <input id="aaa" name="ass"  type="radio" value="哦哦" onclick="as()"/>
</div>

<div>
<script type="text/javascript">
    $(function () {

        var Annuals = $("#Select1");
        var today = new Date();
        var year = today.getFullYear();
        Annuals.empty();
        for (var i = year - 1; i <= year + 1; i++) {
            var option = $("<option>").text(i + '年').val(i)
            Annuals.append(option);
        };
    });
    $(function () {
        $("#Select1 option").click(function () {
            alert($(this).text());
        });
    });

    </script>
    <select id="Select1">
        <option></option>
    </select>
    
    </div>


    <div>
    <script type="text/javascript">
        $(function () { 
            $("#province").change(function () {
                var qwe = $(this).val();
                var jqhr = jQuery.ajax({
                    url: "Handler1.ashx?qwe=" + qwe,
                    dataType: 'json',
                    data: {},
                    type: 'post',
                    success: function (data) { 
                        var piclist = eval(data);
                        var html = "<option>请选择市</option>";
                        for (var i = 0; i < piclist.length; i++) {
                            html += "<option value='" + piclist[i]['Daihao'] + "'>" + piclist[i]['Mingcheng'] + "</option>";
                        }
                        $("#city").html(html);
                    },
                    error: function (err) {
                        alert("err:" + err);
                    }
                });
            });
        });
        $(function () {
            $("#city").change(function () {
                var asd = $(this).val();
            var jqhr = jQuery.ajax({
                url: "Handler1.ashx?asd=" + asd,
                dataType: 'json',
                data: { id: $(this).val() },
                type: 'post',
                success: function (data) {
                  var piclist = eval(data);
                        var html = "<option>请选择县区</option>";
                        for (var i = 0; i < piclist.length; i++) {
                            html += "<option value='" + piclist[i]['Daihao'] + "'>" + piclist[i]['Mingcheng'] + "</option>";
                        }
                        $("#xianqu").html(html);
                    },
                    error: function (err) {
                        alert("err:" + err);
                    }
                });
            });
        });

        $(function () {
            var checkValue = 1;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "Handler1.ashx?checkValue=" + checkValue,
                data: {},
                success: function (data) { 
                    var piclist = eval(data);
                var outputhtml="<option>请选择省</option>";
                for (var i = 0; i < piclist.length; i++) {
                    outputhtml += "<option value='" + piclist[i]['Daihao'] + "'>" + piclist[i]['Mingcheng'] + "</option>";
                }
                $("#province").html(outputhtml);
            },
                error: function (err) {
                    alert("err:" + err);
                }
            });
        });


        $(function () {
            $("#hx").keyup(function () {
                var hx = $(this).val();
                var jqhr = jQuery.ajax({
                    url: "Handler1.ashx?hx=" + hx,
                    dataType: 'json',
                    data: {},
                    type: 'post',
                    success: function (data) {
                        alert(hx);

                    },
                    error: function (err) {
                        alert("err:" + err);
                    }
                });
            });
        });
    </script>
        <select id="province" ruant = "server" name ="xx">
            <option></option>
        </select>
        <select id="city"  ruant = "server">
            <option></option>
        </select>
        <select id="xianqu" ruant = "server" >
            <option></option>
        </select>
         <input id="hx" type="text" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </div>


    <div id="qweqwe" >
    <script type="text/javascript">

        function showtime() {
            var today, hour, second, minute, year, month, date;
            var strDate;
            today = new Date();
            var n_day = today.getDay();
            switch (n_day) {
                case 0:
                    {
                        strDate = "星期日"
                    } break;
                case 1:
                    {
                        strDate = "星期一"
                    } break;
                case 2:
                    {
                        strDate = "星期二"
                    } break;
                case 3:
                    {
                        strDate = "星期三"
                    } break;
                case 4:
                    {
                        strDate = "星期四"
                    } break;
                case 5:
                    {
                        strDate = "星期五"
                    } break;
                case 6:
                    {
                        strDate = "星期六"
                    } break;
                case 7:
                    {
                        strDate = "星期日"
                    } break;
            }
            year = today.getFullYear();
            month = today.getMonth() + 1;
            date = today.getDate();
            hour = today.getHours();
            minute = today.getMinutes();
            second = today.getSeconds();
            if (second<=9) {
            second="0"+second; 
            }
                    document.getElementById('qweqwe').innerHTML = year + "年" + month + "月" + date + "日" + strDate + " " + hour + ":" + minute + ":" + second; //显示时间
//        $("#jjj").html(minute + ":" + second); //显示时间
            setTimeout("showtime();", 1000); //设定函数自动执行时间为 1000 ms(1 s)
        }

//        function testAjax6() {
//            var minute = 29;
//            var second = 59;
//            if (minute == 00 && second == 00) {
//                alert(1);
//            }
//            else {
//                second = second - 1;
//                if (second <= 00) {
//                    second = 60;
//                    minute = minute - 1
//                }
//                if (second <= 9) {
//                    second = "0" + second;
//                }
//                if (minute <= 9) {
//                    minute = "0" + minute;
//                }
//                $("#jjj").html(minute + ":" + second); //显示时间

//            }
//            setTimeout("testAjax6();", 1000); //设定函数自动执行时间为 1000 ms(1 s)
//        }

        $(function () {
            var m = 29;
            var s = 59;
            setInterval(function () {
                if (s < 10) {
                    $('#time').html(m + ':0' + s);
                } else {
                    $('#time').html(m + ':' + s);
                }
                s--;
                if (s < 0) {
                    s = 59;
                    m--;
                }
            }, 1000)
        })

    </script>
    <script language="javascript">        testAjax6();</script>
   <script language="javascript">       showtime();</script>
    
    </div>
   <p id="time">30:00</p>


   <div>
    <script language=javascript>
        var sec = 0; var min = 0; var hou = 0; flag = 0; idt = window.setTimeout("update();", 1000);
        function update() {
            if (min == 19 && sec == 59) { alert("还剩10分钟，请抓紧时间答卷！"); }
            if (min == 30) { alert("考试时间结束！"); } // document.getElementById("Button1").click(); //规定时间结束后自动提交按钮
            sec++;
            if (sec == 60) { sec = 0; min += 1; }
            if (min == 60) { min = 0; hou += 1; }
            if ((min > 0) && (flag == 0)) { flag = 1; }
            document.getElementById("Text1").value = "已用时间：" + hou + "时" + min + "分" + sec + "秒";
            idt = window.setTimeout("update();", 2000);

        }
</script>
<input type="text" id="Text1" />
   </div>
</asp:Content>
