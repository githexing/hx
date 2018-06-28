using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.Data;

namespace WebApplication1.MainSystem.ceshi
{
    /// <summary>
    /// Test 的摘要说明
    /// </summary>
    public class Test : IHttpHandler
    {
        BLL_Yonghu bYonghu = new BLL_Yonghu();
        public void ProcessRequest(HttpContext context)
        {

            DataTable dt = bYonghu.getData(); 
            context.Response.ContentType = "text/plain";
            string one = context.Request["one"];
            string two = context.Request["two"];
            string three = (Convert.ToInt32(one) + Convert.ToInt32(two)).ToString();
            context.Response.Write(three);
           
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}