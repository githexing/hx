using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        static string sconn = @"Data Source=.;Initial Catalog=my;Integrated Security=True";
        StringBuilder sb = new StringBuilder();
        JavaScriptSerializer jss = new JavaScriptSerializer();
        static string strJson { get; set; }
        static string pTable = "";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["qwe"] != null)
            {
                string one = context.Request["qwe"]; 
                SqlConnection conn = new SqlConnection(sconn);
                conn.Open();
                string sql = string.Format("select distinct * from dm_sheng where mingcheng like '%" + one + "%'");
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                List<string> list = new List<string>();
                if (dt.Rows.Count == 1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Model.dm_sheng yh = RowToModel(dt.Rows[i]);
                        strJson = jss.Serialize(yh);
                        if (i == 0)
                        {
                            sb.Append("[" + strJson + "]");
                            continue;
                        }
                    }
                }
                if (dt.Rows.Count != 1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Model.dm_sheng yh = RowToModel(dt.Rows[i]);
                        strJson = jss.Serialize(yh);
                        if (i == 0)
                        {
                            sb.Append("[" + strJson + ",");
                            //list.Add(strJson);
                            continue;
                        }
                        if (i + 1 == dt.Rows.Count)
                        {
                            sb.Append(strJson + "]");
                            continue;
                        }
                        sb.Append(strJson + ",");
                        //list.Add(strJson);
                    }
                  
                }
                context.Response.Write(sb.ToString());
            }


            //context.Response.Write("Hello World");
        }
        private Model.dm_sheng RowToModel(DataRow dr)
        {
            Model.dm_sheng yh = new Model.dm_sheng();
            yh.Daihao = int.Parse(dr["Daihao"].ToString());
            yh.Mingcheng = dr["Mingcheng"].ToString();
            return yh;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}