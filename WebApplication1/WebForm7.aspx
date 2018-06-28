<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="WebApplication1.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="Scripts/jquery-1.4.1.js"></script>
    <script src="Scripts/jquery-1.8.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>选择当前时间：<input type="text" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"  id="time" runat="server"/>

                    </td>
                </tr>
                <tr>
                    <td>请选择：<asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                        <asp:ListItem Value="1">何兴</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>请输入今天<asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem Selected="True" Value="0">消费</asp:ListItem>
                        <asp:ListItem Value="1">收入</asp:ListItem>
                        </asp:DropDownList>的金额：<asp:TextBox ID="jine" runat="server" Width="50px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>备注： 
                        <asp:TextBox ID="shijian" name="shijian" runat="server"></asp:TextBox></td>
                        
                       <%-- <select id="select" onclick="ccc()" runat="server"   style="display:none; width:150px" size="3" >  <%--//onkeyup='ddd()' onkeydown="ddd()" --%>
                          <%--  <option></option>--%>
                       <%-- </select>--%> 

                </tr>

            </table>
            <div>
                <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
            </div>
            <script>
                function aaa() {

                    var qq = ($("#TextBox2").val()).trim();

                    var jqhr = jQuery.ajax({
                        url: "Handler1.ashx?qwe=" + qq,
                        dataType: 'json',
                        data: {},
                        type: 'post',
                        success: function (data) { 
                            var piclist = eval(data);
                            var html = "";
                            for (var i = 0; i < piclist.length; i++) {
                                html += "<option value='" + piclist[i]['Mingcheng'] + "'>" + piclist[i]['Mingcheng'] + "</option>";
                            }
                            $("#select").html(html);
                            document.all['TextBox2'].style.display = 'block';
                            document.all['select'].style.display = 'block';
                            if (piclist=null) {
                                document.all['select'].style.display = 'none';
                            }
                        },
                        error: function (err) {
                            alert("err:" + err);
                        }
                    });
               
              
                    //var html = "<option>" + qq + "</option>";
                    //for (var i = 0; i < piclist.length; i++) {
                    //    html += "<option value='" + piclist[i]['Daihao'] + "'>" + piclist[i]['Mingcheng'] + "</option>";
                    //}
                    //$("#select").html(html);
                   

                }
                function bbb() {
                 var aa=($("#TextBox2").val());
                 if (aa = "") {
                     //document.getElementById("TextBox2"). = true
                     document.all['TextBox2'].style.display='none';
                    }
                 if (aa != "") {
                     document.all['TextBox2'].style.display = 'none';
                 }


                }
              
                function ccc() {
                    //alert(1);
                    $("#select").change(function () {
                        var qwe = $(this).val();
                        //alert(qwe);
                        //document.getElementById("TextBox2").innerHTML = qwe;
                        $("#TextBox2").val(qwe);
                        });
                    //var aa = ($("#select").change.val());
                    //alert(aa);
                
                  
                    //document.all['select'].style.display = 'none';
                    //document.all['TextBox2'].style.display = 'block';
                  
                }
                function ddd() {
                    document.all['select'].style.display = 'none';
                    document.all['TextBox2'].style.display = 'block';
                    var aa = ($("#select").val());
                    document.getElementById("TextBox2").innerText = aa;
                

                }
            </script>
        </div>

         
    </form>
</body>
</html>
