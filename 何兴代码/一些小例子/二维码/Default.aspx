<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title>二维码工具测试</title>  
    <script type="text/javascript" src="js/jquery-1.6.2.min.js"></script>  
    <script type="text/javascript" src="js/jquery.form.js"></script>      
    <script type="text/javascript" src="js/test.js"></script>  
    <style type="text/css">  
        .style1  
        {  
            width: 100%;  
        }  
        #txt_qr  
        {  
            width: 632px;  
        }  
    </style>  
</head>  
<body>  
    <div>  
        <table class="style1">  
            <tr>  
                <td>  
                    输入文字：  
                </td>  
                <td>  
                    <input type="text" id="txt_qr" name="txt_qr" />  
                </td>  
            </tr>  
            <tr>  
                <td>  
                    二维码图片  
                </td>  
                <td>  
                    <img id="qrimg" alt="二维码图片" />  
                </td>  
            </tr>  
            <tr>  
                <td>  
                    生成选项  
                </td>  
                <td>  
                    Encoding:<select id="Encoding">  
                        <option value="Byte">Byte</option>  
                        <option value="AlphaNumeric">AlphaNumeric</option>  
                        <option value="Numeric">Numeric</option>  
                    </select>  
                    Correction Level:<select id="Level">  
                        <option value="M">M</option>  
                        <option value="L">L</option>  
                        <option value="Q">Q</option>  
                        <option value="H">H</option>  
                    </select>  
                    Version:<input id="txt_ver" type="text" value="7" />(1-40) Size:<input id="txt_size"  
                        type="text" value="4" />  
                </td>  
            </tr>  
            <tr>  
                <td colspan="4">  
                    <input type="button" onclick="getQrImg();" value="生成二维码" />  
                </td>  
            </tr>  
            <tr>  
                <td>  
                    <form id="qrForm" action="Ashx/test.ashx" method="post" enctype="multipart/form-data">  
                    <input type="file" id="file_qr" name="file_qr" /><input type="submit" value="读取二维码" />  
                    </form>  
                </td>  
                <td colspan="1">  
                    <img id="img_qr" alt="要读取的图片" /><br />  
                    <input id="txt_readqr" type="text" />  
                </td>  
            </tr>  
        </table>  
    </div>  
</body>  
</html>