using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data.SqlClient;
using System.Data;

namespace WebZm.MainSystem.fenye
{
    public partial class zengjia : System.Web.UI.Page
    {
        BLL.BLL_zm_cjzm1 yonghu = new BLL.BLL_zm_cjzm1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tianjia_Click(object sender, EventArgs e)
        {
            string ksh = tb_ksh.Text;
            string xm = tb_xm.Text;
            string sfz = tb_sfz.Text;
            string mz = tb_mz.Text;
            string xb = tb_xb.Text;
            int dr = yonghu.zengjia(ksh, xm, sfz, mz, xb);
            if (dr > 0)
            {
                Response.Write("<script>alert('添加成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！')</script>");
            }

        }
    }
}