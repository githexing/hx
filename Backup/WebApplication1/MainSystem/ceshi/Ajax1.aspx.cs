using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.MainSystem.ceshi
{
    public partial class Ajax1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            a();
            
        }

         public void a()
        {

            dlOrg.DataSourceID = "SqlDataSource2";
            dlOrg.DataTextField = "daihao";
            dlOrg.DataValueField = "daihao";
        }
    }
}