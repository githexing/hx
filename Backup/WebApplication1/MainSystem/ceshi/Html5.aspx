<%@ Page Title="" Language="C#" MasterPageFile="~/MainSystem/Master/111.Master" AutoEventWireup="true"
    CodeBehind="Html5.aspx.cs" Inherits="WebApplication1.MainSystem.ceshi.Html5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <textarea class="link3" name="txtSiteInfo" id="txtSiteInfo" runat="server"></textarea>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </div>
    <div>
        <input type="text" name="text" id="id" runat="server" /></input>
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <p>
                        一打有 <del>二十</del> <ins>十二</ins> 件。 大多数浏览器会改写为删除文本和下划线文本。 一些老式的浏览器会把删除文本和下划线文本显示为普通文本。</p>
                </td>
            </tr>
            <tr>
                <td>
                    <select>
                        <option value="volvo">Volvo</option>
                        <option value="saab">Saab</option>
                        <option value="opel">Opel</option>
                        <option value="audi">Audi</option>
                    </select>
                    <select>
                        <option runat="server" value='<%# Eval("daihao") %>'>11</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <select id="dlOrg" name="D1" runat="server" onchange="function1()">
                        <option></option>
                    </select><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MSSQLConnectionString_Admin %>"
                        SelectCommand="SELECT daihao FROM yonghu "></asp:SqlDataSource>
                    <script type="text/javascript">
                        function function1() {
                            alert(document.all.dlOrg.options[document.all.objSelect.selectedIndex].text);
                        }
                    </script>
                </td>
            </tr>
        </table>
    </div>
    <div>
    <script type="text/javascript">
        var xmlHttp;
        var sendType = ""; //提交方式
        function createXMLHttpRequest() {
            if (window.ActiveXObject) {
                xmlHttp = new ActiveXObject("Microsoft.XMLHttp");
            } else if (window.XMLHttpRequest) {
                xmlHttp = new XMLHttpRequest();
            }
        }
        function btnSendPost() {
            createXMLHttpRequest();
            var url = "Html5.aspx?timeStamp=" + new Date().getTime();
            var queryString = createQueryString();
            xmlHttp.open("POST", url, true);
            xmlHttp.onreadystatechange = handleStateChange;
            xmlHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded;");
            xmlHttp.send(queryString);
        }

        function createQueryString() {
            var fname = document.getElementById("txtfname").value;
            var mname = document.getElementById("txtmname").value;
            var birthday = document.getElementById("txtbirthday").value;
            var queryString = "fname=" + fname + "&mname=" + mname + "&birthday=" + birthday;
            return queryString;
        }
        function handleStateChange() {
            if (xmlHttp.readyState == 4) {
                if (xmlHttp.status == 200) {
                    parseResults();
                }
            }
        }
        function parseResults() {
            var responseDiv = document.createElement("h4");
            var responseText = document.createTextNode(xmlHttp.responseText);
            responseDiv.appendChild(responseText);
        }
</script>

<form>姓：<input type="text" id="txtfname" width="100"/>
<br />
名：<input type="text" id="txtmname" width="100"/>
<br />
生日：<input type="text" id="txtbirthday" width="100"/>
<br />
<input type="button" id="btnGet" value="Send parameters using POST" onclick="btnSendPost();" width="100"/>
</form>

    
    </div>
    <div>
    
    </div>
</asp:Content>
