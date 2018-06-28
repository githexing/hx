<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true" CodeBehind="Dingshi.aspx.cs" Inherits="WebApplication1.MainSystem.shiyong.Dingshi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="javascript">
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
            year = today.getYear();
            month = today.getMonth() + 1;
            date = today.getDate();
            hour = today.getHours();
            minute = today.getMinutes();
            second = today.getSeconds();
            document.getElementById('time').innerHTML = year + "年" + month + "月" + date + "日" + strDate + " " + hour + ":" + minute + ":" + second; //显示时间
            setTimeout("showtime();", 1000); //设定函数自动执行时间为 1000 ms(1 s)
        }
</script>

<span id="time"></span>
<script language="javascript">    showtime();</script>
    </div>
    <div>
    <script type="text/javascript" language="javascript">
        function testAjax6() {
            var today = new Date();
            var hour = today.getHours();
            var minute = today.getMinutes();
            var second = today.getSeconds(); 
            if (minute == 30 && second == 25) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "Dingshi.ashx?minute=" + minute,
                    data: {},
                    success: function (data) {
                        alert(2);
                    },
                    error: function (err) {

                        alert("err:" + err);

                    }
                });
                setTimeout("testAjax6();", 1000)
            }
            else {
                setTimeout("testAjax6();", 1000)
            }
        }    
    </script>                            
    </div>
    
    <script language="javascript">        testAjax6();</script>
</asp:Content>
