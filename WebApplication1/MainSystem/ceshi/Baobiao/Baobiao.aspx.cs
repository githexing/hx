using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Reflection;
//using Microsoft.Reporting.WebForms;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.MainSystem.ceshi.Baobiao
{
    public partial class Baobiao : System.Web.UI.Page
    {
        static string con = @"Data Source=.;Initial Catalog=yishu10;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData();
            }

        }
        /// <summary>
        /// 绑定数据
        /// </summary>        
        protected void getData()
        {
            //string pNian = Application["Nian"].ToString().Trim();
            //string pDanwei = Application["DanweiMingcheng"].ToString().Trim();
            //string pTitle = pNian + "年" + pDanwei + "考点代码表";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            string sql = string.Format("select * from dm_kaodian");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();


            //    //各单位报到单格式不同
            //    ReportViewer1.Reset();
            //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report2.rdlc");
            //    //ReportViewer1.LocalReport.DisplayName = pTitle + "_" + Application["danwei"].ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmssff");
            //    //ReportParameter[] parameters = new ReportParameter[2];
            //    //parameters[0] = new ReportParameter("pTitle", pTitle);
            //    //parameters[1] = new ReportParameter("pDanwei", "单位：" + pDanwei);
            //    ReportDataSource rds1 = new ReportDataSource("DataSet1", dt);
            //    ReportViewer1.LocalReport.DataSources.Clear();
            //    ReportViewer1.LocalReport.DataSources.Add(rds1);

            //    //ReportViewer1.LocalReport.SetParameters();
            //    //getReportViewr();
            //    ReportViewer1.LocalReport.Refresh();
            //}
            /// <summary>
            /// 屏蔽掉excel pdf和word类似
            /// </summary>
            //protected void getReportViewr()
            //{
            //    ReportViewer rw = this.ReportViewer1 as ReportViewer;
            //    if (rw == null)
            //    {
            //        return;
            //    }
            //    foreach (RenderingExtension re in rw.LocalReport.ListRenderingExtensions())
            //    {
            //        //屏蔽掉你需要取消的导出功能 Excel PDF Word  
            //        if (re.Name == "Excel" || re.Name == "WORD")//屏蔽掉excel pdf和word类似
            //        {
            //            FieldInfo fi = re.GetType().GetField("m_isVisible", BindingFlags.Instance | BindingFlags.NonPublic);
            //            fi.SetValue(re, false);
            //        }
            //    }
            //}
        }
    }
}