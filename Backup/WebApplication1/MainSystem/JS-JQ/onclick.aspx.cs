using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient; 

namespace WebApplication1.MainSystem.JS_JQ
{
    public partial class onclick : System.Web.UI.Page
    {
        static string sconn = @"Data Source=.;Initial Catalog=my;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            rbl_leixing.Items[0].Attributes.Add("onclick", "return aa()");
            rbl_leixing.Items[1].Attributes.Add("onclick", "return aa()");
             

            SqlConnection conn = new SqlConnection(sconn);
            conn.Open();
            string sql = string.Format("select * from dm_sheng");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (!IsPostBack)// 只有首次加载时，执行此方法，回传页面不执行此方法            
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "update();", true);
            }
        }
    }
}