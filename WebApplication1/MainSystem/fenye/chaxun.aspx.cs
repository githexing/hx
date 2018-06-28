using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BLL;
using Model;

namespace WebZm.MainSystem.fenye
{
    public partial class chaxun : System.Web.UI.Page
    {
        BLL.BLL_zm_cjzm1 qwe = new BLL.BLL_zm_cjzm1();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Chaxun1_Click(object sender, EventArgs e)
        {

            //string pxm = tb_xm.Text;
            //string psfz = tb_sfz.Text;
            //BLL.zm_cjzm r = new BLL.zm_cjzm();
            //DataTable i = qwe.getDate(pxm, psfz);
            //if (i.Rows.Count > 0)
            //{
            //    DataTable dt = r.getDate(pxm, psfz);
            //    GridView1.DataSource = dt;
            //    GridView1.DataBind();
            //}
            //else
            //{
            //    Response.Write("<script>alert('您输入的信息有误！')</script>");
            //}





        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string pxm = tb_xm.Text;
            string psfz = tb_sfz.Text;
            BLL.BLL_zm_cjzm1 r = new BLL.BLL_zm_cjzm1();
            DataTable i = qwe.getDate(pxm, psfz);
            if (i.Rows.Count > 0)
            {
                DataTable dt = r.getDate(pxm, psfz);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('您输入的信息有误！')</script>");
            }


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}