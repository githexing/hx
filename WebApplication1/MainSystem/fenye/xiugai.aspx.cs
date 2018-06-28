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

namespace WebZm
{
    public partial class xiugai : System.Web.UI.Page
    {
        BLL.hx_yonghu qyonghu = new BLL.hx_yonghu();
        BLL.BLL_zm_cjzm1 yonghu = new BLL.BLL_zm_cjzm1();
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable dt = yonghu.getallDate("%");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void xiugai_Click(object sender, EventArgs e)
        {
            //    string pzh = tb_zhanghao.Text;
            //    string pmm = tb_mima.Text;
            //    string xmm = tb_Newmima.Text;
            //    string xxmm = tb_Newmima1.Text;
            //    if (pzh != "" && pmm != "" && xmm != "" && xxmm != "")
            //    {
            //        if (xmm == xxmm)
            //        {
            //            int dr = qyonghu.updataData(pzh, xmm, pmm);
            //            if (dr > 0)
            //            {
            //                Response.Write("<script>alert('修改成功！')</script>");
            //            }
            //            else
            //            {
            //                Response.Write("<script>alert('修改失败，请重新输入！')</script>");
            //            }
            //        }
            //        else
            //        {
            //            Response.Write("<script>alert('修改的密码不同')</script>");
            //        }
            //    }
            //    else
            //    {
            //        Response.Write("<script>alert('账号密码不能为空')</script>");
            //    }
        }

        protected void chaxun_Click(object sender, EventArgs e)
        {
            //DataTable dt = yonghu.getallDate("%");
            GridView1.DataSource = "";
            GridView1.DataBind();




            Model.zm_cjzm p = new Model.zm_cjzm();
            p.Xingming = tb_xm.Text;
            p.Shenfenzheng = tb_sfz.Text;
            p.Xuhao = tb_xh.Text;

            DataTable d = yonghu.chaxun("%" + p.Xingming + "%", "%" + p.Shenfenzheng + "%", "%" + p.Xuhao + "%");
            if (d.Rows.Count > 0)
            {
                //DataTable dt = yonghu.chaxun("%");
                GridView2.DataSource = d;
                GridView2.DataBind();
            }
            else
            {
                Response.Write("<script>alert('错误信息，请重新输入！')</script>");
                GridView1.DataSource = "";
                GridView1.DataBind();
                GridView2.DataSource = "";
                GridView2.DataBind();


            }

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView2.DataSource = "";
            GridView2.DataBind();
            tb_xhh.Text = GridView1.SelectedRow.Cells[0].Text.ToString();
            tb_ksh.Text = GridView1.SelectedRow.Cells[1].Text.ToString();
            tb_xmm.Text = GridView1.SelectedRow.Cells[2].Text.ToString();
            tb_xbb.Text = GridView1.SelectedRow.Cells[3].Text.ToString();
            tb_sfzz.Text = GridView1.SelectedRow.Cells[4].Text.ToString();
            tb_mzz.Text = GridView1.SelectedRow.Cells[5].Text.ToString();

        }



        protected void tb_gx_Click(object sender, EventArgs e)
        {
            string xh = tb_xhh.Text;
            string ksh = tb_ksh.Text;
            string xm = tb_xmm.Text;
            string xb = tb_xbb.Text;
            string sfz = tb_sfzz.Text;
            string mz = tb_mzz.Text;
            int dr = yonghu.updataData(xh, ksh, xm, xb, sfz, mz);

            if (dr > 0)
            {
                Response.Write("<script>alert('修改成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败，请重新输入！')</script>");
            }

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridView1.DataSource = "";
            GridView1.DataBind();
            tb_xhh.Text = GridView2.SelectedRow.Cells[0].Text.ToString();
            tb_ksh.Text = GridView2.SelectedRow.Cells[1].Text.ToString();
            tb_xmm.Text = GridView2.SelectedRow.Cells[2].Text.ToString();
            tb_xbb.Text = GridView2.SelectedRow.Cells[3].Text.ToString();
            tb_sfzz.Text = GridView2.SelectedRow.Cells[4].Text.ToString();
            tb_mzz.Text = GridView2.SelectedRow.Cells[5].Text.ToString();
        }

    }
}