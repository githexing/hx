using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BLL;
using Model;
using AjaxControlToolkit;
using AppCommon;
namespace WebApplication1.MainSystem.Xitong
{
    public partial class tianjiadaohang : App_Code.App_UtilityPage
    {
        protected caidan mCaidan = new caidan();
        protected xt_result result = new xt_result();
        protected BLL_Caidan bCaidan = new BLL_Caidan();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData("xuhao", "ASC");
                TabContainer1.ActiveTabIndex = 0;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pDaihao = "";
            mCaidan.Yingyong = RadioButtonList1.SelectedValue;
            mCaidan.Bianhao = TextBox1.Text.Trim().ToString();
            mCaidan.Xuhao = TextBox2.Text.Trim().ToString();
            mCaidan.Fuxuhao = TextBox3.Text.Trim().ToString();
            mCaidan.Mingcheng = TextBox4.Text.Trim().ToString();
            mCaidan.Jiancheng = "";
            mCaidan.Url = TextBox5.Text.Trim().ToString();
            mCaidan.Image = "";
            switch (mCaidan.Yingyong)
            {
                case "Admin":
                    pDaihao = "99";
                    break;
                case "Kaosheng":
                    pDaihao = "01";
                    break;
                default:
                    pDaihao = "99";
                    break;

            }
            xt_result result = bCaidan.getCharucaidan(mCaidan,pDaihao);
            if (result.ReturnInt < 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert(' 保存菜单失败！" + result.Message + " ！')</script>", false);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('保存菜单成功！ " + result.Message + " ！')</script>", false);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            mCaidan.Yingyong = RadioButtonList1.SelectedValue;
            mCaidan.Bianhao = TextBox1.Text.Trim().ToString();
            mCaidan.Xuhao = TextBox2.Text.Trim().ToString();
            mCaidan.Fuxuhao = TextBox3.Text.Trim().ToString();
            mCaidan.Mingcheng = TextBox4.Text.Trim().ToString();
            mCaidan.Jiancheng = "";
            mCaidan.Url = TextBox5.Text.Trim().ToString();
            mCaidan.Image = "";
            xt_result result = bCaidan.getGengaicaidan(mCaidan);
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert(' " + result.Message + " ！')</script>", false);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            setGridViewPageIndexChanging(GridView1, e.NewPageIndex, "txtNewPageIndex1");
            getData("", "");
        }
        /// <summary>
        /// 提取数据
        /// </summary>
        protected void getData(string pSortExpression, string pSortDirection)
        {
            string pYingyong=RadioButtonList3.SelectedValue;
            DataTable dt = bCaidan.getYingyong(pYingyong);
            Session["Chaxun"] = dt.DefaultView;
            getGridViewData(GridView1, "Chaxun", pSortExpression, pSortDirection);

        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            getGridViewData(GridView1, "Chaxun", e.SortExpression, "");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = 1;
            string pXuhao = GridView1.SelectedRow.Cells[0].Text.ToString();

            DataTable dt = bCaidan.getDataWhere("xuhao", pXuhao);

          TextBox1.Text   = dt.Rows[0]["bianhao"].ToString();
          TextBox2.Text = dt.Rows[0]["xuhao"].ToString();
          TextBox3.Text = dt.Rows[0]["fuxuhao"].ToString();
          TextBox4.Text = dt.Rows[0]["mingcheng"].ToString();
          TextBox5.Text = dt.Rows[0]["url"].ToString();
         


        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            setGridViewRowDataBound("Chaxun", e, " 项");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
          
            mCaidan.Yingyong = RadioButtonList1.SelectedValue;
            mCaidan.Bianhao = TextBox1.Text.Trim().ToString();
            mCaidan.Xuhao = TextBox2.Text.Trim().ToString();
            mCaidan.Fuxuhao = TextBox3.Text.Trim().ToString();
            mCaidan.Mingcheng = TextBox4.Text.Trim().ToString();
            mCaidan.Jiancheng = "";
            mCaidan.Url = TextBox5.Text.Trim().ToString();
            mCaidan.Image = ""; 
            xt_result result = bCaidan.getShanchucaidan(mCaidan);
            if (result.ReturnInt < 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert(' 删除失败！" + result.Message + " ！')</script>", false);
                return;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('删除成功！ " + result.Message + " ！')</script>", false);
        }

        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData("xuhao", "ASC");
        }
    }
}