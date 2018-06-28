using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;


namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = "http://1212.ip138.com/ic.asp";//设置你要访问的网址。

            WebClient wc = new WebClient();//创建WebClient对象

            Stream s = wc.OpenRead(url);//访问网址并用一个流对象来接受返回的流

            StreamReader sr = new StreamReader(s, Encoding.UTF8);//把流对象转换为                                                                                        StreamReader对象

            extBox1.Text = sr.ReadToEnd();//把流转换为字符串并显示在文本框中

            sr.Close();//关闭资源

            s.Close();
          
            string a = GetData(extBox1.Text);
        }



        protected string  GetIP()
        {
            string tempip = "";
            try
            {
                WebRequest wr = WebRequest.Create("http://www.ip138.com/");
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd(); //读取网站的数据

                int start = all.IndexOf("[") + 1;
                int end = all.IndexOf("]", start);
                tempip = all.Substring(start, end - start);
                sr.Close();
                s.Close();
            }
            catch
            {
            }
            return tempip;
        }
        public string GetHttpData(string Url)
        {
            string sException = null;
            string sRslt = null;
            WebResponse oWebRps = null;
            Thread.Sleep(5000);
            WebRequest oWebRqst = WebRequest.Create(Url);
            Thread.Sleep(5000);
            oWebRqst.Timeout = 60000;
            try
            {
                oWebRps = oWebRqst.GetResponse();
            }
            catch (WebException e)
            {
                sException = e.Message.ToString();
                Response.Write(sException);
            }
            catch (Exception e)
            {
                sException = e.ToString();
                Response.Write(sException);
            }
            finally
            {
                if (oWebRps != null)
                {
                   
                    StreamReader oStreamRd = new StreamReader(oWebRps.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                    sRslt = oStreamRd.ReadToEnd();
                    oStreamRd.Close();
                    oWebRps.Close();
                }
            }
            return sRslt;
        }
        public string GetData(string Html)
        {
            string rS ;
            string s = Html;
            s = Regex.Replace(s, "s{3,}", "");
            s = s.Replace("\r", "");
            s = s.Replace("\n", "");
            string[] b = s.Split('[');
            string[] c = b[1].Split(']');
            string a = c[0].ToString();
            rS = a;
            return rS;
        }
    }
}