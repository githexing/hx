using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        BLL_Procedure p = new BLL_Procedure();
        static string sconn = @"Data Source=.;Initial Catalog=my;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
           
                Button2.Visible = false;
                Button3.Visible = false;
                string pTable = "xt_huiyuan where huiyuan='张三'";
                SqlConnection conn = new SqlConnection(sconn);
                conn.Open();
                string sql = string.Format("select distinct * from " + pTable + "");
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                int jine = int.Parse(dt.Rows[0]["jine"].ToString());
                int dengji = int.Parse(dt.Rows[0]["dengji"].ToString());

                SqlConnection conn1 = new SqlConnection(sconn);
                conn1.Open();
                string sql1 = string.Format("select distinct * from dm_huiyuan");
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, conn1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                conn1.Close();
                int jine1 = int.Parse(dt1.Rows[0]["jine"].ToString());
                int dengji1 = int.Parse(dt1.Rows[0]["daihao"].ToString());


                if (dengji == 0)
                {
                    if (jine >= jine1)
                    {
                        Button2.Visible = true;
                        Button2.Enabled = true;
                        Button3.Visible = false;
                        Session["dengji"] = dengji;
                        
                    }

                }
                if (dengji == 1)
                {
                    if (jine >= jine1)
                    {
                        Button2.Visible = true;
                        Button2.Enabled = true;
                        Button3.Visible = false;
                        Session["dengji"] = dengji;
                    }

                }
                if (dengji == 2)
                {
                    if (jine >= jine1)
                    {
                        Button2.Visible = true;
                        Button2.Enabled = true;
                        Button3.Visible = false;
                        Session["dengji"] = dengji;
                    }

                }
                if (dengji == 3)
                {
                    if (jine >= jine1)
                    {
                        Button2.Visible = true;
                        Button2.Enabled = true;
                        Button3.Visible = false;
                        Session["dengji"] = dengji;
                    }

                }
                if (dengji == 4)
                {
                    if (jine >= jine1)
                    {
                        Button2.Visible = true;
                        Button2.Enabled = true;
                        Button3.Visible = false;
                        Session["dengji"] = dengji;
                    }

                }
            }
           


        

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = p.ceshi1("");

            DataTable dt = ds.Tables[0];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string pTable = "xt_huiyuan where huiyuan='张三'";
            SqlConnection conn = new SqlConnection(sconn);
            conn.Open();
            string sql = string.Format("select distinct * from " + pTable + "");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            int jine = int.Parse(dt.Rows[0]["jine"].ToString());
            int dengji = int.Parse(dt.Rows[0]["dengji"].ToString());

            SqlConnection conn1 = new SqlConnection(sconn);
            conn1.Open();
            string sql1 = string.Format("select distinct * from dm_huiyuan");
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, conn1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            conn1.Close();
            int a = int.Parse(Session["dengji"].ToString());
            int jine1 = int.Parse(dt1.Rows[int.Parse(Session["dengji"].ToString())]["jine"].ToString());
            int dengji1 = int.Parse(dt1.Rows[int.Parse(Session["dengji"].ToString())]["daihao"].ToString());
            if (jine>=jine1)
            { 
            SqlConnection conn2 = new SqlConnection(sconn);
            conn2.Open();
            string sql2 = "update xt_huiyuan set dengji="+dengji1+" where huiyuan='张三'";
            SqlCommand cmd = new SqlCommand(sql2, conn2);
            int reInt = cmd.ExecuteNonQuery();
            conn2.Close();
            if (reInt > 0)
            {
                Response.Write("<script>alert('添加成功!')</script>");
                if (jine > jine1)
                {
                    Button2.Visible = true;
                    Button2.Enabled = true;
                    Button3.Visible = false; 
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('该会员还可升级！')</script>", false);

                }
                else
                {
                    Button2.Visible = false;
                    Button3.Enabled = false;
                    Button3.Visible = true;
                }
               
            }
            else
                Response.Write("<script>alert('添加失败!')</script>");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}