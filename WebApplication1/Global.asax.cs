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
            //getMenu();
            Application["CurrentUserCount"] = 0;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 6000;//执行间隔时间,单位为毫秒  
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);

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
        private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            // 得到 hour minute second  如果等于某个值就开始执行某个程序。  
            int intHour = e.SignalTime.Hour;
            int intMinute = e.SignalTime.Minute;
            int intSecond = e.SignalTime.Second;
            // 定制时间； 比如 在10：30 ：00 的时候执行某个函数  
            int iHour = 16;
            int iMinute = 06;
            int iSecond = 00;
            // 设置　 每秒钟的开始执行一次  
            //if (intSecond == iSecond)
            //{
            //    Console.WriteLine("每秒钟的开始执行一次！");
            //}
            // 设置　每个小时的３０分钟开始执行  
            if (intMinute == iMinute  ) /*intSecond == iSecond*/
            {
                Console.WriteLine("每个小时的３０分钟开始执行一次！");
            }

            // 设置　每天的１０：３０：００开始执行程序  
            if (intHour == iHour && intMinute == iMinute && intSecond == iSecond)
            {
                Console.WriteLine("在每天１０点３０分开始执行！");
            }
        }


    }
}
