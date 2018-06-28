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
    public partial class shanchu : System.Web.UI.Page
    {
        BLL.BLL_zm_cjzm1 yonghu = new BLL.BLL_zm_cjzm1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void shanchu1_Click(object sender, EventArgs e)
        {
            string ksh = tb_ksh.Text;
            string xm = tb_xm.Text;
            string sfz = tb_sfz.Text;
            int dr = yonghu.shanchu(ksh, xm, sfz);
            if (dr > 0)
            {
                Response.Write("<script>alert('删除成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('删除的信息不存在！')</script>");
            }



        }
    }
}