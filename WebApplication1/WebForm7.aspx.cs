using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private static readonly string pLogin = System.Configuration.ConfigurationManager.ConnectionStrings["MSSQLConnectionString_Login"].ToString();
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["MSSQLConnectionString"];
        protected void Page_Load(object sender, EventArgs e)
        {
            //TextBox1.DataBindings.Add("Text", dataset.table[0], "字段名"); 
            if (!IsPostBack)
            {
                //this.select.Visible = false;
            }
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string Time= this.time.Value.Trim();
            string User = DropDownList1.SelectedItem.Text.Trim();
            string Jine = jine.Text.Trim();
            string Shijian = shijian.Text.Trim();
            string a = DropDownList2.SelectedValue;
            if (a == "0")
            {
                Jine = "-" + Jine;
            } 
            SqlConnection conn = new SqlConnection(pLogin);
            conn.Open();
            string sql = "insert into Shenghuo(UserID,Jine,shijian,DateTime)values('" + User + "'," + Jine + ",'" + Shijian + "','" + Time + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int reInt = cmd.ExecuteNonQuery();
            conn.Close();
            if (reInt > 0)
            {
                Response.Write("<script>alert('添加成功!')</script>");
               
            }
            else
                Response.Write("<script>alert('添加失败!')</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Response.Write("<script> window.close();</script>");
            Response.Write("windows.close()");
        }
    }
}