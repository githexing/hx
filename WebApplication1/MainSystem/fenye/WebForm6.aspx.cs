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
    public partial class WebForm6 : System.Web.UI.Page
    {
        BLL_CS_Caozuo bZm=new BLL_CS_Caozuo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            getData();
        }
        protected void getData( )
        {
            string xuhao = tb_xuhao.Text;

            DataTable dt = bZm.aa(xuhao);
            ReportViewer1.Reset();
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/fenye/Report1.rdlc");

            ReportDataSource rds = new ReportDataSource("DataSet5", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            //ReportParameter[] parameters = new ReportParameter[2];
            //parameters[0] = new ReportParameter("sheng", "广西壮族自治区");
            //parameters[1] = new ReportParameter("shi", "广西");

            //ReportViewer1.LocalReport.SetParameters(parameters);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();

        }
    }
}