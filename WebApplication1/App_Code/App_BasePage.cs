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
using System.IO;

namespace WebApplication1.App_Code
{
    public class App_BasePage : App_Code.App_UtilityPage
    {
        /// <summary>
        /// 页面初始化时检查 session，失效时自动跳转到登录页面
        /// </summary>
        /// <param name="O"></param>
        protected override void OnInit(EventArgs O)
        {
            Hashtable htUser = new Hashtable();
            string pBianhao = "000000";
            if (Request.QueryString["bianhao"] != null)
            {
                pBianhao = Request.QueryString["bianhao"].ToString();
                pBianhao = pBianhao.Replace("?","&");
            }
            if (base.Session["daihao"] == null)
            {

                Response.Redirect("~/Index.aspx?bianhao=" + Server.UrlEncode(pBianhao) + "&BakupUrl=" + Server.UrlEncode(Request.FilePath), true);
            }
            if (base.Session["daihao"].ToString().Equals(""))
            {
                Response.Redirect("~/Index.aspx?bianhao=" + Server.UrlEncode(pBianhao) + "&BakupUrl=" + Server.UrlEncode( Request.FilePath), true);
            }

            ////更新在线时间
            //htUser = (Hashtable)Application["User_Online"];
            //pDaihao = Session["daihao"].ToString();
            //if (htUser.ContainsKey(Session.SessionID))
            //{
            //    htUser[Session.SessionID] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "_" + Session["daihao"].ToString();
            //}
            //else
            //{
            //    htUser.Add(Session.SessionID, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "_" + Session["daihao"].ToString());
            //}

            base.OnInit(O);
        }
        
        
    }
}
