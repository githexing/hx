﻿using System;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string url = "http://1212.ip138.com/ic.asp";//设置你要访问的网址。

            WebClient wc = new WebClient();//创建WebClient对象

            Stream s = wc.OpenRead(url);//访问网址并用一个流对象来接受返回的流

            StreamReader sr = new StreamReader(s, Encoding.UTF8);//把流对象转换为                                                                                        StreamReader对象

            extBox1.Text = sr.ReadToEnd();//把流转换为字符串并显示在文本框中


            sr.Close();//关闭资源

            s.Close();

            string a = GetData(extBox1.Text);
            Label6.Text = a;

            GetAddressByIp(a);




            string url1 = "http://php.weather.sina.com.cn/widget/weather.php";//设置你要访问的网址。

            WebClient wc1 = new WebClient();//创建WebClient对象

            Stream s1 = wc1.OpenRead(url1);//访问网址并用一个流对象来接受返回的流

            StreamReader sr1 = new StreamReader(s1, Encoding.UTF8);//把流对象转换为                                                                                        StreamReader对象

            extBox1.Text = sr1.ReadToEnd();//把流转换为字符串并显示在文本框中


            sr1.Close();//关闭资源

            s1.Close();


        }
        public string GetData(string Html)
        {
            string rS;
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

        /// <summary>
        /// 根据IP获取省市
        /// </summary>
        public void GetAddressByIp( string XX)
        {
            string ip = XX;
            string PostUrl = "http://int.dpool.sina.com.cn/iplookup/iplookup.php?ip=" + ip;
            string res = GetDataByPost(PostUrl);//该条请求返回的数据为：res=1\t115.193.210.0\t115.194.201.255\t中国\t浙江\t杭州\t电信

            string[] arr = getAreaInfoList(res);
            Label6.Text += arr[0] + arr[1];
            //GetWetheaerByCity(arr[1]);
        }
        /// <summary>
        /// Post请求数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetDataByPost(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            string s = "anything";
            byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(s);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = requestBytes.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
            string backstr = sr.ReadToEnd();
            sr.Close();
            res.Close();
            return backstr;
        }

        /// <summary>
        /// 处理所要的数据
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string[] getAreaInfoList(string ipData)
        {
            //1\t115.193.210.0\t115.194.201.255\t中国\t浙江\t杭州\t电信
            string[] areaArr = new string[10];
            string[] newAreaArr = new string[2];
            try
            {
                //取所要的数据，这里只取省市
                areaArr = ipData.Split('\t');
                newAreaArr[0] = areaArr[4];//省
                newAreaArr[1] = areaArr[5];//市
                
            }
            catch (Exception e)
            {
                // TODO: handle exception
            }
            return newAreaArr;
        }

        public void GetWetheaerByCity(string cityName)
        {
            string city = cityName;
            string mycity = HttpUtility.UrlEncode(city, System.Text.Encoding.GetEncoding("GB2312"));
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://www.sina.com/index.php?city=" + cityName);
            //HttpWebRequest 对象 获取GetResponse 转换成HttpWebResponse
            System.Net.HttpWebResponse response = request.GetResponse() as System.Net.HttpWebResponse;
            //通过HttpWebResponse response.GetResponseStream()获取输出流
            Stream str = response.GetResponseStream();
            StreamReader reader = new StreamReader(str, System.Text.Encoding.GetEncoding("GB2312"));
            string weathhtml = reader.ReadToEnd();
            str.Close();
            reader.Close();
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