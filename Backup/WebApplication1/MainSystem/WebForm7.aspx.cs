using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1.MainSystem
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取传递过来的参数
            string city = Request.QueryString["city"];
            Response.Clear();
            //判断城市名
            switch (city)
            {
                case "beijing":
                    //填充相关的区域
                    Response.Write("朝阳,海淀,东城,西城");
                    break;
                case "shanghai":
                    Response.Write("浦东,静安,虹口,徐汇");
                    break;
                case "jinan":
                    Response.Write("历下,历城,市中,天桥");
                    break;
            }
        }

    }
}
 