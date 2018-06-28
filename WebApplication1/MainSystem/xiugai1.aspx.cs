using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using BLL;

namespace WebApplication1
{
    public partial class xiugai : System.Web.UI.Page
    {
        BLL_ZM_Zuce Zuce = new BLL_ZM_Zuce();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ii = Request.QueryString["id"];
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string mima = TextBox1.Text.Trim();
            string mima1 = TextBox1.Text.Trim();
            string mima2 = TextBox3.Text.Trim();
            string yonghu = TextBox4.Text.Trim();
            
            //if (mima1==mima2)
            //{
            //    if (mima != mima1)
            //    {
            //        int dt = Zuce.UpdataData(yonghu, mima, mima1);
            //        Response.Write("<script>alert('修改成功 ！')</script>");
            //    }
            //    else
            //    {
            //        Response.Write("<script>alert('新旧密码不能相同 ！')</script>");
            //    }
            //}
            //else
            //{
            //    Response.Write("<script>alert('新密码输入不相同 ！')</script>");
            //}
         
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string ii = Request.QueryString["id"];

            DataTable dt = Zuce.getData(ii);
            string pDaihao=dt.Rows[0]["daihao"].ToString();
             if (int.Parse(pDaihao) == 0)
            {
                Response.Write("<script>window.location.href ='./tiaozhuanye1.aspx?id=" + Request.QueryString["id"] + "'</script>");
            }
             if (int.Parse(pDaihao) == 1)
            {
                Response.Write("<script>window.location.href ='./tiaozhuanye.aspx?id=" + Request.QueryString["id"] + "'</script>");
            }
        }

    }
}