using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using AppCommon;
using Model;

namespace WebApplication1.App_Code
{
    public class App_UserPage : App_Code.App_BasePage
    {
        /// <summary>
        /// 页面初始化时检查组别
        /// </summary>
        /// <param name="O"></param>
        protected override void OnInit(EventArgs O)
        {
            
            string pBianhao = "000000";
            if (Request.QueryString["bianhao"] != null)
            {
                pBianhao = Request.QueryString["bianhao"].ToString();
            }
            if (base.Session["zubie"] == null)
            {

                Response.Redirect("~/Index.aspx?bianhao=" + Server.UrlEncode(pBianhao) + "&BakupUrl=" + Server.UrlEncode(Request.FilePath), true);
            }
            base.OnInit(O);
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="O"></param>
        protected override void OnLoad(EventArgs O)
        {
            if (Request.QueryString["bianhao"] == null)
            {
                Session.Abandon();
                throw new Exception("菜单编号空，禁止调用本页面！");
            }
            string pBianhao = Request.QueryString["bianhao"].ToString();
            int i = pBianhao.IndexOf("?");
            if (i > 0)
            {
                pBianhao = pBianhao.Substring(0, i);
            }
            pBianhao = MySecurity.DESDecrypt(pBianhao, MySecurity.GetDESKey.DESKeyMenu);
            Hashtable htGongneng = (Hashtable)Session["gongneng"];
            if (!htGongneng.Contains(pBianhao))
            {
                Session.Abandon();
                throw new Exception("当前户无此设置功能分配，禁止调用本页面！");
            }
            string pGongneng = (string)htGongneng[pBianhao];
            if (pGongneng.Substring(1, 1).Equals("0")) //查询功能
            {
                Button bButton = (Button)Page.FindControl("Button_chaxun");
                if (bButton != null)
                {
                    bButton.Enabled = false;
                }
            }
            if (pGongneng.Substring(2, 1).Equals("0")) //修改功能
            {
                Button bButton = (Button)Page.FindControl("Button_xiugai");
                if (bButton != null)
                {
                    bButton.Enabled = false;
                }
            }
            if (pGongneng.Substring(3, 1).Equals("0")) //增加功能
            {
                Button bButton = (Button)Page.FindControl("Button_zengjia");
                if (bButton != null)
                {
                    bButton.Enabled = false;
                }
            }
            if (pGongneng.Substring(4, 1).Equals("0")) //删除功能
            {
                Button bButton = (Button)Page.FindControl("Button_shanchu");
                if (bButton != null)
                {
                    bButton.Enabled = false;
                }
            }
            if (pGongneng.Substring(5, 1).Equals("0")) //打印功能
            {
                Button bButton = (Button)Page.FindControl("Button_dayin");
                if (bButton != null)
                {
                    bButton.Enabled = false;
                }
            }
            if (pGongneng.Substring(6, 1).Equals("0")) //导出功能
            {
                Button bButton = (Button)Page.FindControl("Button_daochu");
                if (bButton != null)
                {
                    bButton.Enabled = false;
                }
            }
            if (pGongneng.Substring(7, 1).Equals("0")) //统计功能
            {
                Button bButton = (Button)Page.FindControl("Button_tongji");
                if (bButton != null)
                {
                    bButton.Enabled = false;
                }
            }
            if (pGongneng.Substring(8, 1).Equals("0")) //审核
            {
                Button bButton = (Button)Page.FindControl("Button_shenhe");
                if (bButton != null)
                {
                    bButton.Enabled = false;
                }
            }
            if (pGongneng.Substring(9, 1).Equals("0")) //系统保留
            {
                Button bButton = (Button)Page.FindControl("Button_0");
                if (bButton != null)
                {
                    bButton.Enabled = false;
                }
            }
            //默认按钮
            Button bButton_save = new Button();
            bButton_save = (Button)Page.FindControl("ctl00$ContentPlaceHolder1$TabContainer1$TabPanel1$Button_save");
            if (bButton_save != null)
            {
                Page.Form.DefaultButton = bButton_save.UniqueID;
            }
            bButton_save = (Button)Page.FindControl("ctl00$ContentPlaceHolder1$TabContainer1$TabPanel2$Button_save");
            if (bButton_save != null)
            {
                Page.Form.DefaultButton = bButton_save.UniqueID;
            }
            bButton_save = (Button)Page.FindControl("ctl00$ContentPlaceHolder1$Button_save");
            if (bButton_save != null)
            {
                Page.Form.DefaultButton = bButton_save.UniqueID;
            }

            base.OnLoad(O);
        }
        /// <summary>
        /// 检查用户组别
        /// </summary>
        /// <param name="pZubie"></param>
        public void CheckYonghuZubie(string pZubie1, string pZubie2)
        {
            string pZubie = Session["zubie"].ToString();
            if (pZubie.CompareTo(pZubie1) < 0 || pZubie.CompareTo(pZubie2) > 0)
            {
                string pBianhao = Request.QueryString["bianhao"].ToString();
                Response.Redirect("~/MainSystem/Help/Stop.aspx?bianhao=" + Server.UrlEncode(pBianhao), true);
            }
        }
        /// <summary>
        /// 院系组别
        /// </summary>
        /// <param name="pZubie"></param>
        /// <returns></returns>
        public void YuanxiZubie(DropDownList pDropDownList)
        {
            if (Application["Zubie_yuanxi"].ToString() == Session["zubie"].ToString())
            {
                pDropDownList.Enabled = false;
                pDropDownList.SelectedValue = Session["danwei"].ToString();
            }
        }
        
    }
}