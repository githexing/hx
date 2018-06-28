using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState; 
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using AppCommon;
using System.IO;
using BLL;
using Model;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {
        protected BLL_XT_Tongji Tongji = new BLL_XT_Tongji();
        protected xt_result result = new xt_result();
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            //应用系统代号
            getMenu();
            Application["CurrentUserCount"] = 0;

        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码
            Application.Lock(); 
            Application["CurrentUserCount"] = (int)Application["CurrentUserCount"] + 1; 
            Application.UnLock();
        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。
            Application.Lock();
            Application["CurrentUserCount"] = (int)Application["CurrentUserCount"] - 1;
            //DataTable dt = new DataTable();
            //dt = Tongji.getData();
            //int renshu = int.Parse(dt.Rows[0]["renshu"].ToString());
            //renshu = renshu + 1;
            //xt_result dt1 = Tongji.UpData(renshu);
            Application.UnLock();
        }
        /// <summary>
        /// 导航菜单
        /// </summary>
        public void getMenu()
        {
            BLL_Caidan bCaidan = new BLL_Caidan();

            DataTable dt = bCaidan.getData("Admin");
            Application.Lock();
            Application["dtHelp"] = dt;
            Application.UnLock();

        }

    }
}
