using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;

namespace WebApplication1.MainSystem.ceshi
{
    public partial class IP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
   

            GetRealIP();
            GetViaIP();
            GetIPAddress();
            //GetHttpWebRequest("http://city.ip138.com/ip2city.ASP");
            IpAddress();
            //GetIP1();
            a();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string i = Request.UserHostAddress;
            //string IP   =   (Request.ServerVariables["HTTP_VIA"]!=null)?
            string ipAddress = System.Web.HttpContext.Current.Request.UserHostAddress;

            HttpBrowserCapabilities bc = Request.Browser;
            string aa = bc.Browser + "   " + bc.Version;//得到浏览器版本   
            string aaa = bc.Platform;//得到操作系统   
            string aaaa = Dns.GetHostName();
            IPHostEntry jj = Dns.GetHostByName(aaaa);//得到IP   
            //IPAddress   ip=Dns.Resolve(hostname);   
            string aaaaaa = jj.AddressList[0].ToString();
        }

        //public static string GetRealIP()
        public void GetRealIP()
        {
            string ip;
            try
            {
                HttpRequest request = HttpContext.Current.Request;

                if (request.ServerVariables["HTTP_VIA"] != null)
                {
                    ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
                }
                else
                {
                    ip = request.UserHostAddress;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            Label1.Text = ip;

        }
        //public static string GetViaIP()
        public void GetViaIP()
        {
            string viaIp = null;

            try
            {
                HttpRequest request = HttpContext.Current.Request;

                if (request.ServerVariables["HTTP_VIA"] != null)
                {
                    viaIp = request.UserHostAddress;
                }

            }
            catch (Exception e)
            {

                throw e;
            }
            Label2.Text = viaIp;
            //return viaIp;
        }
        //public static string GetIPAddress()
        public void GetIPAddress()
        {

            string user_IP = string.Empty;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    user_IP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    user_IP = System.Web.HttpContext.Current.Request.UserHostAddress;
                }
            }
            else
            {
                user_IP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            Label3.Text = user_IP;
        }
        public string IpAddress()
        {
            string strIpAddress;
            strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIpAddress == null)
            {
                strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            return strIpAddress;
        }
        string GetIp()
        {
            //string userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];  
            //if (userIP == null || userIP == "")  
            //{  
            //userIP = Request.ServerVariables["REMOTE_ADDR"];  

            //}  
            //  return userIP;        
            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            if (string.IsNullOrEmpty(result))
            {
                return "127.0.0.1";
            }

            return result;

        }

        public void a()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

            
            string tt = "";
            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    tt = ip.ToString();
                    break;
                }
            }
            //divx.InnerHtml = tt;
            Label5.Text = tt;
        }
        public long ip2long(String ip)
        {
            System.Net.IPAddress ipaddress = System.Net.IPAddress.Parse(ip);
            byte[] bytes = ipaddress.GetAddressBytes();
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }

        //static string GetIP1()
        //{
        //    string strUrl = "http://www.ip138.com/ip2city.asp"; //获得IP的网址了
        //    Uri uri = new Uri(strUrl);
        //    WebRequest wr = WebRequest.Create(uri);
        //    Stream s = wr.GetResponse().GetResponseStream();
        //    StreamReader sr = new StreamReader(s, Encoding.Default);
        //    string all = sr.ReadToEnd(); //读取网站的数据
        //    int i = all.IndexOf("[") + 1;
        //    string tempip = all.Substring(i, 15);
        //    string ip = tempip.Replace("]", "").Replace(" ", "");
        //    return ip;
        //}
    }
}