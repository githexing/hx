<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="WebApplication1.MainSystem.WebForm7" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript">
        function FormHeadler() {
            var url = document.YQform.site.options[document.YQform.site.selectedIndex].value;
            window.location.href = url;

        }
</script>
</head>
<body>
   <form name="YQform">
  <select name="site" size="1" onChange="FormHeadler()">
    <option value="#">请选择</option>
    <option value="caidan1.aspx">选项1</option>
    <option value="url地址2">选项2</option>
    <option value="url地址n">选项n</option>
  </select>
</form> 
<div>
<script type="text/javascript">
    var xmlhttp;
    function getData() {
        //获取用户填写的名称
        var city = document.getElementByIdx("txt").value;
        //创建异步调用对象
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        //将对象状态与事件相关联
        xmlhttp.onreadystatechange = statechange;
        //加载要链接的页面
        xmlhttp.Open("POST", "WebForm7.aspx?city=" + city, true);
        //发送请求
        xmlhttp.Send();
    }
    function statechange() {
        //判断异步调用是否已经完成
        if (xmlhttp.readystate == 4) {
            //判断完成的提示代码是否是OK状态
            if (xmlhttp.status == 200) {
                //将返回数据作为参数，传递给填充方法
                FillData(xmlhttp.responseText);
            }
        }
    }
    function FillData(strcity) {
        document.getElementByIdx("DropDownList1").options.length = 0;
        var indexofcity;
        var city;
        //切割传递来的字符串
        while (strcity.length > 0) {
            //判断是否是最后一个字符串
            indexofcity = strcity.indexOf(",");
            if (indexofcity > 0) {
                city = strcity.substring(0, indexofcity);
                strcity = strcity.substring(indexofcity + 1);
                //填充下拉框
                document.getElementByIdx("DropDownList1").add(new Option(city, city));
            }
            else {
                // 如果是最后一个字符串
                lastcity = strcity.substring(0, 2);
                document.getElementByIdx("DropDownList1").add(new Option(lastcity, lastcity));
                break;
            }
        };
    }
    </script>
</div>  
<div>

</div>           
</body>
</html>
