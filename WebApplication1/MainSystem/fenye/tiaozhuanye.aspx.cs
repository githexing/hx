using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebZm
{
    public partial class tiaozhuanye : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void xiugaimima_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href ='xiugai.aspx'</script>");
        }

        protected void chaxun_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href ='Chaxun.aspx'</script>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href ='WebForm1.aspx'</script>");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>window.location.href ='shanchu.aspx'</script>");
            Response.Write("<script>window.location.href ='../fenye/WebForm1.aspx'</script>");
        }
    }
}