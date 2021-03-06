﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using AppCommon;
using System.IO;

namespace WebApplication1.MainSystem.Master
{
    public partial class _111 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getData(); 
            createMenu();
 
        }
        /// <summary>
        /// 禁止登陆
        /// </summary>
        public void getData()
        {

            if (Session["zubie"] != "99")
            {
                 Response.Redirect("~/Index.aspx", true);
            }
            return;
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void onExitClicked(object sender, EventArgs e)
        {
            string pCommandArgument = ((LinkButton)sender).CommandArgument;
            //清除浏览器缓存
            Session.Abandon();
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            Response.Cache.SetNoStore();

            switch (pCommandArgument)
            {
                case "Index":
                    Response.Redirect("~/Index.aspx", true);
                    break;
                case "Exit":
                    Response.Redirect("~/Index.aspx", true);
                    break;
            }
        }
        /// <summary>
        /// 生成菜单组
        /// </summary>
        /// <param name="dt1">数据源</param>
        /// <param name="Li">菜单容器</param>
        protected void createMenu()
        {
            //首页
            HtmlGenericControl serverLi00 = new HtmlGenericControl();
            serverLi00.TagName = "li";
            ul_menu.Controls.Add(serverLi00);

            LinkButton pButton00 = new LinkButton();
            pButton00.Text = "首页";
            pButton00.CommandArgument = "Index";
            pButton00.Click += new EventHandler(onExitClicked);
            pButton00.Attributes["onclick"] = "javascript: return window.confirm('确定要返回首页吗？');";
            serverLi00.Controls.Add(pButton00);
            //
            DataTable dt = (DataTable)Session["caidan"];//主页的 session=dt
            DataView dv1 = new DataView(dt);
            dv1.RowFilter = "zu2='0000'";
            foreach (DataRowView Row in dv1)
            {
                string pBinhao = Row["bianhao"].ToString();
                string pMingcheng = Row["mingcheng"].ToString();
                string pZu = Row["zu1"].ToString();
                //if (Session["zubie"].ToString() != "00" && pBinhao == "950000")
                //{
                //    continue;
                //}
                //if (Session["zubie"].ToString() != "00" && pBinhao == "980000")
                //{
                //    continue;
                //}
                //if (Session["zubie"].ToString() == "00" && pBinhao == "010000")
                //{
                //    continue;
                //}

                //菜单组
                HtmlGenericControl serverLi = new HtmlGenericControl();
                serverLi.TagName = "li";
                ul_menu.Controls.Add(serverLi);
                serverLi.InnerHtml = "<a href=\"#\">" + pMingcheng + "<span class=\"arrow\"></span></a>";

                createSubMenu(dt, pZu, serverLi);
            }
            ////退出系统
            //HtmlGenericControl serverLi01 = new HtmlGenericControl();
            //serverLi01.TagName = "li";

            //LinkButton pButton99 = new LinkButton();
            //pButton99.Text = "退出系统";
            //pButton99.CommandArgument = "Exit";
            //pButton99.Click += new EventHandler(onClicked);
            //pButton99.Attributes["onclick"] = "javascript: return window.confirm('确定要退出系统吗？');";
            //serverLi01.Controls.Add(pButton99);
            //ul_menu.Controls.Add(serverLi01);
        }
        /// <summary>
        /// 生成菜单项
        /// </summary>
        /// <param name="dt1">数据源</param>
        /// <param name="pZu">菜单组</param>
        /// <param name="serverUl">菜单组</param>
        protected void createSubMenu(DataTable dt, string pZu, HtmlGenericControl serverLi)
        {
            DataRow[] rows = dt.Select("zu1='" + pZu + "' and zu2<>'0000'");
            if (rows.Length < 1)
            {
                return;
            }
            DataView dv = new DataView(rows.CopyToDataTable());

            //菜单项
            HtmlGenericControl serverUL = new HtmlGenericControl();
            serverUL.TagName = "ul";
            serverLi.Controls.Add(serverUL);

            foreach (DataRowView Row in dv)
            {
                string pBianhao = Row["bianhao"].ToString();
                string pMingcheng = Row["mingcheng"].ToString();
                string pUrl = Row["url"].ToString();
                string pCanshu = "?";
                if (pUrl.IndexOf("?") > 0)
                {
                    pCanshu = "&";
                }
                HtmlGenericControl serverLi1 = new HtmlGenericControl();
                serverLi1.TagName = "li";
                serverUL.Controls.Add(serverLi1);

                HyperLink pLink = new HyperLink();
                pLink.Text = pMingcheng;
                pUrl = pUrl + pCanshu + "bianhao=" + Server.UrlEncode(MySecurity.DESEncrypt(pBianhao, MySecurity.GetDESKey.DESKeyMenu));
                pLink.NavigateUrl = pUrl;
                serverLi1.Controls.Add(pLink);
            }
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Logout(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            Response.Cache.SetNoStore();
            Response.Redirect("~/Index.aspx", true);
        }
    }
}