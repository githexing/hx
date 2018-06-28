using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Text;
using Model;

namespace WebApplication1.MainSystem.ceshi
{

    public partial class Html5 : System.Web.UI.Page
    {
        BLL_Yonghu bYonghu = new BLL_Yonghu();
        yonghu mYonghu=new yonghu();
        public string daihao;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            a();
            k();
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ID = txtSiteInfo.Value;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string ID = id.Value;

        }
        public void g()
        { 
            //List<yonghu> List = new List<yonghu>();
            DataTable dt = bYonghu.getData(); 
           
            foreach (DataRow row in dt.Rows)
            {
                daihao = row["daihao"].ToString(); 
            }

        }
        public void a()
        {
            dlOrg.DataSourceID = "SqlDataSource2";
            dlOrg.DataTextField = "daihao";
            dlOrg.DataValueField = "daihao"; 
        }

        public void k()
        {
            
            string name = Request["fname"];
            string birthday = Request["birthday"];
        }
    }
}