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
    public partial class zuce : System.Web.UI.Page
    {
        protected BLL_ZM_Zuce Zuce = new BLL_ZM_Zuce();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href ='Index.aspx'</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!YanZhengMa())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('登录失败：验证码错误！')</script>", false);
                this.TextBox_yanzhengma.Text = "";
                return;
            }
            
            string yonghu = TextBox_yonghu.Text.Trim().ToString();
            string mima = TextBox_mima.Text.Trim().ToString();
            string mima1 = TextBox_mima1.Text.Trim().ToString();
            string xingming = TextBox_xingming.Text.Trim().ToString();
            string dizhi = TextBox_dizhi.Text.Trim().ToString();
            string dianhua = TextBox_dianhua.Text.Trim().ToString();
            string youjian = TextBox_youjian.Text.Trim().ToString();
            string sfz = TextBox_sfz.Text.Trim().ToString();
            string pDaihao = "0";
            if (mima==mima1)
            {
                int dt = Zuce.zengjia(yonghu, mima,xingming,dizhi,dianhua,youjian,pDaihao,sfz);
                Response.Write("<script>alert('注册成功 ！')</script>");
            }
            else
            {
                Response.Write("<script>alert('注册失败,密码不相符 ！')</script>");
            }
        }
        /// <summary>
        /// 验证码输入校验
        /// </summary>
        /// <returns></returns>
        protected bool YanZhengMa()
        {
            bool re = false;
            string pYanzhengma = this.TextBox_yanzhengma.Text.ToString();//获得用户输入的验证码
            string chkcode = Session["yanzhengma"].ToString();//获得系统生成的验证码
            if (!string.IsNullOrEmpty(pYanzhengma) && !string.IsNullOrEmpty(chkcode))
            {
                if (!chkcode.Equals(chkcode.ToUpper()))//如果系统生成的不为大写则转换成大写形式
                    chkcode.ToUpper();
                if (pYanzhengma.ToUpper().Trim().Equals(chkcode.Trim())) //将输入的验证码转换成大写并与系统生成的比较
                    re = true;
            }
            return re;

        }
    }
}