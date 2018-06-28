using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.MainSystem.shiyong
{
    /// <summary>
    /// Dingshi1 的摘要说明
    /// </summary>
    public class Dingshi1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string one = context.Request["minute"];
            string a = one;
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