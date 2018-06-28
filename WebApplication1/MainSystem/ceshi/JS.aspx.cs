using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BLL;
using Model;
using AppCommon;
using System.Data;
namespace WebApplication1.MainSystem.ceshi
{ 
   
    public partial class JS : System.Web.UI.Page
    {
        protected string str;
         BLL_Yonghu bYonghu = new BLL_Yonghu();
        protected void Page_Load(object sender, EventArgs e)
        {
            str = "hello";
            a();
            c();
            string aaa = Request.QueryString["RID"];
             string aa=Request.QueryString["A0103"];
            //request[""] request.querystring[""] requst.form[""] request.params[""]
        }
        [WebMethod]
        public static string GetJson(string RID)
        {
            //string str = RID;
            //return str;
          
            return "{'ID':'" + RID + "'}";
          

        }
        public void a()
        {

            dlOrg.DataSourceID = "SqlDataSource2";
            dlOrg.DataTextField = "daihao";
            dlOrg.DataValueField = "daihao";
        }
        public void bind(string RID)
        {
        }

        public void c()
        {
            //string aa = GetJson(aaa);
            //BLL_Yonghu bYonghu = new BLL_Yonghu();
            //DataTable dt = bYonghu.getData9(aa);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            
                //ID:'aaaa'
        }
    }
}