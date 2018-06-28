using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace WebApplication1.MainSystem.ceshi
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //string name = Request["td"];
            //k();
            //Response.Write(Request.Form["sel"]);
            //string q = Request["sel"];
        
        }
        [WebMethod]
        public static string GetJson(string RID)
        {
            return "{'ID':'" + RID + "'}";
        }
        //private string GetDate()
        //{
        //    return DateTime.Now.ToShortDateString();
        //}

        //private string GetTime() 
        //{
        //    return DateTime.Now.ToShortTimeString();
        //}
          
            //string action = Request.QueryString["action"];
            //if (action!=null)
            //{
            //    Response.Clear(); //清除所有之前生成的Response内容
            //    if (!string.IsNullOrEmpty(action))
            //    {
            //        switch (action)
            //        {
            //            case "getTime":
            //                Response.Write(GetTime());
            //                break;
            //            case "getDate":
            //                Response.Write(GetDate());
            //                break;
            //        }
            //    }
            //    Response.End(); //停止Response后续写入动作，保证Response内只有我们写入内容
            //}
        /// <summary>
        /// WebService1 的摘要说明
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
        [System.Web.Script.Services.ScriptService]
        public class WebService1 : System.Web.Services.WebService
        {

            [WebMethod]
            public string HelloWorld()
            {
                return "Hello World" + System.DateTime.Now.ToLongTimeString();
            }

            [WebMethod]
            public string HelloWorld2(string name)
            {
                return "Hello World" + name + System.DateTime.Now.ToLongTimeString();
            }
        }
        /// <summary>
        /// 2
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string SayHello()
        {
            return "Hello";
        }

        [WebMethod]
        public static string SayHello2(string name)
        {
            return "Hello" + name;
        }

       

    }
}