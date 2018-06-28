using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.IO;
using System.Globalization;
using System.Security.Cryptography;

namespace WebApplication1.MainSystem.shiyong
{
    public partial class tanchuceng : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sendurl = "http://smsapi.c123.cn/OpenPlatform/OpenApi";
            string ac = "1001@501325260001";			//用户名
            string authkey = "8FC158B071E6BBBE8F0A011BE3DDE159";	//密钥
            string cgid = "52";  //通道组编号
            string csid = "0";
            string m = "" + TextBox2.Text + "";  //发送号码
            string c = "" + TextBox1.Text + "";  //签名编号 ,可以为空时，使用系统默认的编号
            string action = "sendOnce";
            StringBuilder sbTemp = new StringBuilder();
            //POST 传值
            sbTemp.Append("action=" + action + "&ac=" + ac + "&authkey=" + authkey + "&m=" + m + "&cgid=" + cgid + "&csid=" + csid + "&c=" + c);
            byte[] bTemp = System.Text.Encoding.GetEncoding("utf-8").GetBytes(sbTemp.ToString());
            string postReturn = doPostRequest(sendurl, bTemp);
            Regex linkReg = new Regex("result=(.+)/>");
            MatchCollection linkCollection = linkReg.Matches(postReturn);
            string str = linkCollection[0].Groups[1].Value;
            str = str.Replace(">", "");
            Response.Write("Post response is:" + str.Replace("\"", "")); //测试返回结果
        }
        //POST方式发送得结果
        private static String doPostRequest(string url, byte[] bData)
        {
            System.Net.HttpWebRequest hwRequest;
            System.Net.HttpWebResponse hwResponse;

            string strResult = string.Empty;
            try
            {
                hwRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                hwRequest.Timeout = 5000;
                hwRequest.Method = "POST";
                hwRequest.ContentType = "application/x-www-form-urlencoded";
                hwRequest.ContentLength = bData.Length;

                System.IO.Stream smWrite = hwRequest.GetRequestStream();
                smWrite.Write(bData, 0, bData.Length);
                smWrite.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
                return strResult;
            }

            //get response
            try
            {
                hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
                strResult = srReader.ReadToEnd();
                srReader.Close();
                hwResponse.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
            }

            return strResult;
        }
        private static void WriteErrLog(string strErr)
        {
            Console.WriteLine(strErr);
            System.Diagnostics.Trace.WriteLine(strErr);
        }
    }
}