<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true" CodeBehind="Ajax1.aspx.cs" Inherits="WebApplication1.MainSystem.ceshi.Ajax1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
      <select id="dlOrg" name="dlOrg" runat="server" onchange="function1()"> 
                        <option></option>
                    </select>//动态查询成功！ <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MSSQLConnectionString_Admin %>"
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
//                             alert(checkValue);
                             $.ajax({
                                 type: "POST",
                                 contentType: "application/json; charset=utf-8",
                                 dataType: "json",
                                 url: "Ajax1.ashx?checkValue=" + checkValue,
                                 data: {},
                                 success: function (data) {
                                     alert(2);
                                     var b = data[0].Mingcheng;
                                     $("#s_name").val(b);
                                     var piclist = eval(data);
                                     $("#Text1").val(piclist[0]["Daihao"]);
                                     //                                     var i;
                                     //                                   for(int i=0;i < piclist.length;i++){
                                     //                                        <table><tr><td>+ piclist[i]["Mingcheng"] + </td></tr><table>
                                     //                                        }
                                     //                                    
                                     //                                     for (var i = 0; i < piclist.length; i++) {

                                     //                                         //      document.getElementById("a").innerHTML("<table> <tr><td> " + piclist[i].Daihao + " </td></tr></table>");
                                     //                                         $("#a").append("<table Class=table2> <tr><td> " + piclist[i].Daihao + " </td> <td> " + piclist[i].Mingcheng + " </td></tr></table>");
                                     //                                         //                                         document.getElementById("a").innerHTML(1)
                                     //                                     }
                                     $('#aa').remove();
                                     $("#a").append("<table Class='table2' id = 'aa'> <tr><td> " + piclist[piclist.length - 1].Daihao + " </td> <td> " + piclist[piclist.length - 1].Mingcheng + " </td></tr></table>");
                                


                                     //                                     $("s_name").append(""+ b + "");
                                     //                                     $("#s_name").text("" + b + ""); 
//                                     document.getElementById("aaa").innerHTML = b; 
//                                     document.getElementById("bbb").innerHTML = b;

                                 },
                                 error: function (err) {

                                     alert("err:" + err);

                                 }
                             });
                         }                                                         
        
                     </script>
        <br /> 
        </div>
        <div id="a">
       <table>
       <tr>
       <td>
       <input type="text" id="s_name" />
       <input type="text" id="Text1" />
           
           <br />
           时间选择的textbox： <asp:TextBox ID="TextBox_riqi1" runat="server" MaxLength="8" Width="60px" ></asp:TextBox><asp:CalendarExtender
                            ID="CalendarExtender1" runat="server" DaysModeTitleFormat="yyyy年MM月dd日" TargetControlID="TextBox_riqi1"
                            TodaysDateFormat="yyyyMMdd" DefaultView="Days" Format="yyyyMMdd">
                        </asp:CalendarExtender>  &nbsp; 
                          <asp:TextBox ID="tb_chushengnianyue" runat="server" class="Wdate" type="text" onClick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                            Style="width: 90%"></asp:TextBox> </td>
       </tr>
       </table>
       <%-- </div>
        <table class="table2" >
        <tr>
        <td><div id="aaa"> </div></td>
        <td  ><div id="bbb"></div></td>
        </tr>
        </table>--%>
        
         
    </div>
</asp:Content>
