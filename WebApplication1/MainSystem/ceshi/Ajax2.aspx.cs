using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace WebApplication1.MainSystem.ceshi
{
    public partial class Ajax2 : System.Web.UI.Page, ICallbackEventHandler 
    {
        BLL_Procedure pro = new BLL_Procedure();
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }
 //定义一个存储变量
    string result = string.Empty;
    public string GetCallbackResult() {
        return result;
    }
    public void RaiseCallbackEvent(string eventArgument) {
        //将计算的结果赋值给result变量
        //这里你也可以直接调用bll，或者直接在这里进行读取数据库....
        result = "前台有逗号的源值：" + eventArgument + "\n后台去掉逗号的值：" + myReplace(eventArgument) + "\n";
    }
    /*-----------------------------------------------------------------------*/
    string myReplace(string str) {
        return str.Replace(",", "");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ds = pro.ceshi1("ceshi1");
        DataTable dt = ds.Tables[0];

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
       string PNun;
       string Mima= TextBox1.Text;
       PNun = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Mima, "MD5");
       Label1.Text = PNun;
    }
}
}