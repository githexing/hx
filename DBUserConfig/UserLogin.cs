using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace DBUserConfig
{
    public class UserLogin
    {
        private static readonly string pAdmin = System.Configuration.ConfigurationManager.ConnectionStrings["MSSQLConnectionString_Admin"].ToString();
        private static readonly string pLogin = System.Configuration.ConfigurationManager.ConnectionStrings["MSSQLConnectionString_Login"].ToString();
         //<summary>
         //系统管理
         //</summary>
        public string User_Admin
        {
            get { return pAdmin; }
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        public string User_Login
        {
            get { return pLogin; }
        }
    }
}
