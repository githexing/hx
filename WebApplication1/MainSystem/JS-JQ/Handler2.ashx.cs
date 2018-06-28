using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.MainSystem.JS_JQ
{
    /// <summary>
    /// Handler2 的摘要说明
    /// </summary>
    public class Handler2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string one = context.Request["today"];
            
            context.Response.Write("Hello World");
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