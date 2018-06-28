using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppCommon;
using Model;
using BLL;
using System.IO;
using Microsoft.Reporting.WebForms;


namespace WebZm.MainSystem.fenye
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        BLL.BLL_CS_Caozuo bZm = new BLL_CS_Caozuo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void getData()
        {
            DataTable dt = bZm.getdata("%");
            ReportViewer1.Reset();
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/fenye/Report11.rdlc");
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            //ReportParameter[] parameters = new ReportParameter[2];
            //parameters[0] = new ReportParameter("sheng", "广西壮族自治区");
            //parameters[1] = new ReportParameter("shi", "广西");

            //ReportViewer1.LocalReport.SetParameters(parameters);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}