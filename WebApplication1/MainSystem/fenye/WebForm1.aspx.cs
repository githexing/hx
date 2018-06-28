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
using AppCommon;
using Model;
using BLL;

namespace WebZm.MainSystem.fenye
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Model.hx_neirong aaa = new Model.hx_neirong();
        BLL.hx_yonghu Byonghu = new BLL.hx_yonghu();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tijiao_Click(object sender, EventArgs e)
        {
            aaa.Neirong = textbox_neirong.Text;
            aaa.Riqi = DateTime.Now;
            int dr = Byonghu.tijiao(aaa);
            if (dr > 0)
            {
                Response.Write("<script>alert('提交成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('提交失败！')</script>");  
            }
        }
    }
}