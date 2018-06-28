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
using AjaxControlToolkit;
 

namespace WebApplication1
{
    public partial class Index : System.Web.UI.Page
    {
        protected BLL_ZM_Zuce Zuce = new BLL_ZM_Zuce();
        protected BLL_ZM_Chaxun Chaxun = new BLL_ZM_Chaxun();
        protected BLL_Caidan bCaidan = new BLL_Caidan();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
            this.Label1.Text = Application["CurrentUserCount"].ToString();
        }
        /// <summary>
        /// 用户功能表
        /// </summary>
        protected void getGongneng()
        {
            //DataTable dt2 = bCaidan.getGongneng();
            Application["yingyong"] = "Admin";
            Session["zubie"] = "99";
            DataTable dt = bCaidan.getCaidan(Application["yingyong"].ToString(), Session["zubie"].ToString());
            
            Session["caidan"] = dt;
            //用户功能控制
            Hashtable htGongneng = new Hashtable();
            foreach (DataRow row in dt.Rows)
            {
                //保存功能信息
                string pBianhao = row["bianhao"].ToString().Trim();
                string pGongneng = row["canshu0"].ToString().Trim() + row["canshu1"].ToString().Trim() + row["canshu2"].ToString().Trim() + row["canshu3"].ToString().Trim() + row["canshu4"].ToString().Trim() + row["canshu5"].ToString().Trim() + row["canshu6"].ToString().Trim() + row["canshu7"].ToString().Trim() + row["canshu8"].ToString().Trim() + row["canshu9"].ToString().Trim();
                htGongneng.Add(pBianhao, pGongneng);
            }
            Session["gongneng"] = htGongneng;
        }
        /// <summary>
        /// 动态增加菜单功能
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected DataTable addGongneng(DataTable dt, string pDaihao, string pBianhao, string pMingcheng, string pUrl)
        {
            DataRow row = dt.NewRow();
            row["daihao"] = "Admin";
            row["bianhao"] = pBianhao;
            row["xuhao"] = pBianhao;
            row["mingcheng"] = pMingcheng;
            row["canshu0"] = "1";
            row["canshu1"] = "1";
            row["canshu2"] = "1";
            row["canshu3"] = "1";
            row["canshu4"] = "1";
            row["canshu5"] = "1";
            row["canshu6"] = "1";
            row["canshu7"] = "1";
            row["canshu8"] = "1";
            row["canshu9"] = "1";
            row["zu1"] = pBianhao.Substring(0, 2);
            row["zu2"] = pBianhao.Substring(3);
            row["url"] = pUrl;
            dt.Rows.Add(row);
            return dt;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!YanZhengMa())
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('登录失败：验证码错误！')</script>", false);
                //this.TextBox_yanzhengma.Text = "";
                //return;
            }


            string pDaihao = RadioButtonList_xuanze.SelectedValue;

            Session["daihao"] = pDaihao;

            if (int.Parse(pDaihao) == 0)
            {
                string yonghu = TextBox1.Text.Trim().ToString();
                string mima = TextBox2.Text.Trim().ToString();
                DataTable dt = Zuce.getData(yonghu, mima);
                if (pDaihao != "0")
                {
                    Response.Write("<script>alert('登录失败，账号或密码错误 ！')</script>");
                    return;
                }

                if (dt.Rows.Count > 0)
                {
                    Session["xingming"] = dt.Rows[0]["xingming"].ToString();
                    Session["yonghu"] = dt.Rows[0]["yonghu"].ToString();
                    string xingming = dt.Rows[0]["xingming"].ToString();
                    string ID = dt.Rows[0]["yonghu"].ToString();
                    Response.Write("<script>alert('欢迎你," + xingming + "登录成功 ！')</script>");
                    //     Response.Write("<script>window.location.href ='./MainSystem/tiaozhuanye1.aspx' '? id' =" +xingming + "</script>");
                    //Response.Write("<script>window.location.href ='./MainSystem/xueshengye.aspx'</script>");
                    Response.Redirect("./MainSystem/xueshengye.aspx?id=" + yonghu, true);
                    //Session["daihao"] = Daihao;

                }

                else
                {
                    Response.Write("<script>alert('登录失败，账号或密码错误 ！')</script>");
                }
            }
            else
            {


                if (int.Parse(pDaihao) == 1)
                {
                    string yonghu = TextBox1.Text.Trim().ToString();
                    string mima = TextBox2.Text.Trim().ToString();
                    DataTable dt = Zuce.getData(yonghu, mima);
                    if (dt.Rows.Count<1)
                    {
                        Response.Write("<script>alert('登录失败 ！')</script>");
                        return;
                    }
                    string a = dt.Rows[0]["daihao"].ToString();
                    Session["xingming"] = dt.Rows[0]["xingming"].ToString();
                    Session["yonghu"] = dt.Rows[0]["yonghu"].ToString();
                    if (a != pDaihao)
                    {
                        Response.Write("<script>alert('登录失败，账号或密码错误 ！')</script>");
                        return;
                    }
                    if (dt.Rows.Count > 0)
                    {
                        string xingming = dt.Rows[0]["xingming"].ToString();
                        string ID = dt.Rows[0]["yonghu"].ToString();
                        Response.Write("<script>alert('欢迎你," + xingming + "登录成功 ！')</script>");
                        getGongneng();
                        //Response.Write("<script>window.location.href ='./MainSystem/tiaozhuanye.aspx?id='" + yonghu + "</script>");
                        //Response.Redirect("WebForm2.aspx?id=" + yonghu, true);
                        Response.Redirect("WebForm2.aspx");
                        
                        //Session["daihao"] = Daihao;
                        return;
                    } 
                }
                //Response.Write("<script>alert('登录失败,请重新输入账号密码 ！')</script>");

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

        protected void Button2_Click(object sender, EventArgs e)
        {
        //    Response.Write("<script>window.location.href ='zuce.aspx'</script>");
            Response.Redirect("zuce.aspx");
        }

        protected void RadioButtonList_xuanze_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pDaihao = RadioButtonList_xuanze.SelectedValue;
        }

        //protected void TextBox3_TextChanged(object sender, EventArgs e)
        //{
        //    string ii = TextBox3.Text.Trim();

        //    DataTable dt = Chaxun.selectData("shenfenzheng", ii);


        //}

    }
}
