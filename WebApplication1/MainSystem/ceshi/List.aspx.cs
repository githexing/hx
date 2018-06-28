using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient; 
using System.Drawing;
using System.Runtime.Remoting;
using System.Data.OleDb;
 
 

namespace WebApplication1.MainSystem.ceshi
{
    public partial class List : System.Web.UI.Page
    {
        static string sconn = @"Data Source=.;Initial Catalog=my;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(sconn);
            conn.Open();
            string sql = string.Format("select * from caidan");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            List<string> list = new List<string>();
           
        

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                 string a=dt.Rows[i]["bianhao"].ToString();
                string b=dt.Rows[i]["xuhao"].ToString();
                 list.Add(""+a+"  "+b+"");
            }
            string aa="";

            for (int i = 0; i < list.Count; i++)
            {
                 aa += list[i].ToString();
                
            }


           ///list填充dataset
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("bianhao", typeof(string));//创建字段头
            //dt.Columns.Add("Age", typeof(int));

          
            for (int i = 0; i < list.Count; i++)
            {
                DataRow dr = dt1.NewRow();
                dr[0] = list[i].ToString();
                //dr[1] = tList[i].Age;
                dt1.Rows.Add(dr);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
           
        }

         

    //    //取消编辑

    //    protected void UserList_OnCancelCommand(object sender, DataListCommandEventArgs e)
    //    {
    //        this.UserList.EditItemIndex = -1;
    //        GetUserList();
    //    }

    //    //DataList编辑

    //    protected void UserList_OnEditCommand(object sender, DataListCommandEventArgs e)
    //    {
    //        this.UserList.EditItemIndex = e.Item.ItemIndex;
    //        GetUserList();
    //    }

    //    //DataList更新

    //    protected void UserList_OnUpdateCommand(object sender, DataListCommandEventArgs e)
    //    {
    //        string id = this.UserList.DataKeys[e.Item.ItemIndex].ToString(); //使用前需先设置DataList的DataKeyField="Uid"       
    //        string Rname = ((TextBox)e.Item.FindControl("User_Rname")).Text.Trim();//取得DataList中ID为"User_Rname"的TextBox中的值
    //        string UserGroup = ((DropDownList)e.Item.FindControl("User_Group")).SelectedValue.Trim();
    //        string UserPurview = "";
    //        for (int i = 0; i < ((CheckBoxList)e.Item.FindControl("User_Priv")).Items.Count; i++)
    //        {
    //            if (((CheckBoxList)e.Item.FindControl("User_Priv")).Items[i].Selected == true)
    //            {
    //                UserPurview += ((CheckBoxList)e.Item.FindControl("User_Priv")).Items[i].Value + ",";
    //            }

    //        }
    //        if (UserPurview != "")
    //        {
    //            UserPurview = UserPurview.Substring(0, UserPurview.Length - 1);
    //        }
    //        int usstate = 0;
    //        if (((CheckBox)e.Item.FindControl("User_State")).Checked == true)
    //        {
    //            usstate = 1;
    //        }
    //        string sql = "update SystemUser set uState =" + usstate + ",UserGroup='" + UserGroup + "',Rname='" + Rname + "',Purview='" + UserPurview + "' where uid=" + id + "";
    //        ConnDB db = new ConnDB();
    //        if (db.EditDatabase(sql))
    //        {
    //            msgBox.Alert("编辑成功！", "SysUser_Admin.aspx");
    //        }
    //        else
    //        {
    //            msgBox.Alert("编辑失败！" + ((CheckBox)e.Item.FindControl("User_State")).ToString());
    //        }

    //    }

    //    //DataList删除对话框

    //    protected void UserList_ItemCreated(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        LinkButton lbDelete = (LinkButton)e.Item.FindControl("Del_But"); lbDelete.Attributes.Add("onclick", "return confirm(""确定删除这个用户吗？"");");
    //    }
    //}

    //    //DataList删除


    //    protected void UserList_OnDeleteCommand(object sender, DataListCommandEventArgs e)
    //    {
    //        string id = this.UserList.DataKeys[e.Item.ItemIndex].ToString(); //使用前需先设置DataList的DataKeyField="Uid"
    //        string sql = "delete from SystemUser where Uid=" + id + "";
    //        ConnDB db = new ConnDB();
    //        if (db.EditDatabase(sql))
    //        {
    //            msgBox.Alert("已删除！", "SysUser_Admin.aspx");
    //        }
    //        else
    //        {
    //            msgBox.Alert("删除失败！", "SysUser_Admin.aspx");
    //        }
    //        GetUserList();
    //    }

    //    //DataList数据绑定

    //    private void DataListDataBind()
    //    {
    //        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["DataBaseCon"].ToString());
    //        SqlDataAdapter da = new SqlDataAdapter("select * from Employees", conn);
    //        DataSet ds = new DataSet();
    //        try
    //        {
    //            da.Fill(ds, "testTable");
    //            dlEditItem.DataSource = ds.Tables["testTable"];
    //            dlEditItem.DataBind();
    //        }
    //        catch (Exception error)
    //        {
    //            Response.Write(error.ToString());
    //        }
    //    }

    }
}