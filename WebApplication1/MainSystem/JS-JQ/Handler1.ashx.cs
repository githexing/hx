using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Text;



namespace WebApplication1.MainSystem.JS_JQ
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
          

            if (context.Request["checkValue"]!=null)
            {
                string one = context.Request["checkValue"];
                pTable = "dm_sheng";

            }
            if (context.Request["qwe"]!=null)
            {
                string qw = context.Request["qwe"];
                string qwe = qw.Substring(0,2)+"__"+"00";
                
                pTable = "dm_shiqu where daihao like '"+qwe+"'";
             
            }
            if (context.Request["asd"] != null)
            {
                string one = context.Request["asd"];
                string asd = one.Substring(0, 4)  + "%";
                pTable = "dm_xianqu where daihao like '"+ asd+"'";

            }
            if (context.Request["hx"] != null)
            {
                string one = context.Request["hx"]; 
            }
           
            SqlConnection conn = new SqlConnection(sconn);
            conn.Open();
            string sql = string.Format("select distinct * from "+pTable+"");
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
                context.Response.Write(sb.ToString());
            }
            //int id = int.Parse(context.Request["id"]); 
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