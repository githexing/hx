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
using AppCommon;

namespace WebApplication1.MainSystem.ceshi
{
    public partial class Gridview : System.Web.UI.Page
    {
        BLL_Yonghu bYonghu = new BLL_Yonghu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData("daihao", "ASC");
                g();
              
            }
            
        }
        public void g()
        {
            DataTable dt = bYonghu.getData(); 
            GridView1.DataSource = dt;
            Image1.ImageUrl = "D:/22.jpg";//dt.Rows[0]["images"].ToString();
            GridView1.DataBind();


        }
        /// <summary>
        /// 获取LinkButton值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_shenhe_Click(object sender, EventArgs e)
        {
            LinkButton lbButton = (LinkButton)sender;
            string pSfzh = lbButton.CommandArgument.ToString();
           string a= lbButton.CommandName.ToString();
         
            //string pShenhe = DropDownList_shenhe.SelectedValue;
            //xt_result result = bBmxx.setShenhe(pSfzh, pShenhe);
            //getData("shenfenzheng", "ASC");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('" + result.Message + "！')</script>", false);
        }
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                ((CheckBox)GridView1.Rows[i].FindControl("CheckBox1")).Checked = ((CheckBox)this.GridView1.HeaderRow.FindControl("chkAll")).Checked ;
            }
        }
        /// <summary>
        /// 反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_fanxuan_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                ((CheckBox)GridView1.Rows[i].FindControl("CheckBox1")).Checked = ((CheckBox)GridView1.Rows[i].FindControl("CheckBox1")).Checked ? false : true;
            }
        }
        /// <summary>
        /// 获取label值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label lbSfzh = (Label)row.FindControl("Label1") ;
                Label a = (Label)row.FindControl("Label2");
                string q = lbSfzh.Text;
                string w = a.Text;
            } 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string pShenhe = DropDownList_shenhe.SelectedValue;
            //string pShenhe1 = DropDownList_shenhe.SelectedItem.Text;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox myCheck = (CheckBox)row.FindControl("CheckBox1");
                if (myCheck == null)
                {
                    continue;
                }
                if (myCheck.Checked == true)
                {
                    Label lbSfzh = (Label)row.FindControl("Label2");
                    Label a = (Label)row.FindControl("Label2");
                    string w = a.Text;
                    
                }
            }
            //getData("shenfenzheng", "ASC");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('当前页审核完毕！')</script>", false);
        }
        ///// <summary>
        ///// 审核当前页
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void Button_ye_Click(object sender, EventArgs e)
        //{
        //    string pShenhe = DropDownList_shenhe.SelectedValue;
        //    string pShenhe1 = DropDownList_shenhe.SelectedItem.Text;
        //    foreach (GridViewRow row in GridView1.Rows)
        //    {
        //        CheckBox myCheck = (CheckBox)row.FindControl("CheckBox1");
        //        if (myCheck == null)
        //        {
        //            continue;
        //        }
        //        if (myCheck.Checked == true)
        //        {
        //            Label lbSfzh = (Label)row.FindControl("Label_sfzh");
        //            xt_result result = bBmxx.setShenhe(lbSfzh.Text, pShenhe);
        //            if (result.ReturnInt > 0)
        //            {
        //                Label lbShenhe = (Label)row.FindControl("Label_shenhe");
        //                lbShenhe.Text = pShenhe1;
        //            }
        //        }
        //    }
        //    //getData("shenfenzheng", "ASC");
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('当前页审核完毕！')</script>", false);
        //}

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            getGridViewData(GridView1, "Chaxun", e.SortExpression, "");
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

            DataTable dt = bYonghu.getData(); 
            Session["Chaxun"] = dt.DefaultView;
            getGridViewData(GridView1, "Chaxun", pSortExpression, pSortDirection);
            
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            setGridViewRowDataBound("Chaxun", e, " 人");
        }

        /// <summary>
        /// 翻页或排序（Session）
        /// </summary>
        /// <param name="gw"></param>
        /// <param name="pSession"></param>
        /// <param name="pSortExpression"></param>
        /// <param name="pSortDirection"></param>
        public void getGridViewData(GridView gw, string pSession, string pSortExpression, string pSortDirection)
        {
            DataView dv = (DataView)Session[pSession];
            dv.Sort = getGridViewSort(pSortExpression, pSortDirection);
            gw.DataSource = dv;
            gw.DataBind();
        }
        /// <summary>
        /// 绑定行编辑
        /// </summary>
        public void setGridViewRowDataBound(string pSession, GridViewRowEventArgs e, string pDanwei)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标停留时更改背景色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#CCDDFF'");
                //当鼠标移开时还原背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //以跨栏的方式合并单元格
                e.Row.Cells[0].ColumnSpan = e.Row.Cells.Count;
                //隐藏除第一个单元格之后的所有单元格
                for (int index = 1; index <= e.Row.Cells.Count - 1; index++)
                {
                    e.Row.Cells[index].Visible = false;
                }
            
                DataView dv = (DataView)Session[pSession];

                e.Row.Cells[0].Text = "合计：" + dv.Count.ToString() + " " + pDanwei;
                e.Row.Cells[0].CssClass = "cssGridviewFooter";
            }
        }
        /// <summary>
        /// 绑定行编辑
        /// </summary>
        /// <param name="e"></param>
        /// <param name="pHeji"></param>
        public void setGridViewRowDataBound(GridViewRowEventArgs e, string pHeji)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标停留时更改背景色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#CCDDFF'");
                //当鼠标移开时还原背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //以跨栏的方式合并单元格
                e.Row.Cells[0].ColumnSpan = e.Row.Cells.Count;
                //隐藏除第一个单元格之后的所有单元格
                for (int index = 1; index <= e.Row.Cells.Count - 1; index++)
                {
                    e.Row.Cells[index].Visible = false;
                }

                e.Row.Cells[0].Text = pHeji;
                e.Row.Cells[0].CssClass = "cssGridviewFooter";
            }
        }

        /// <summary>
        /// 排序方式
        /// </summary>
        /// <param name="pSortExpression"></param>
        /// <returns></returns>
        protected string getGridViewSort(string pSortExpression, string pSortDirection)
        {
            if (pSortExpression == "" && pSortDirection == "")
            {
                //默认排序：分页
                pSortExpression = Session["SortExpression"].ToString();
                pSortDirection = Session["SortDirection"].ToString();
            }
            else if (pSortExpression != "" && pSortDirection != "")
            {
                Session["SortExpression"] = pSortExpression;
                Session["SortDirection"] = pSortDirection;
            }
            else
            {
                //反向排序
                Session["SortExpression"] = pSortExpression;
                if (Session["SortDirection"].ToString() == "ASC")
                {
                    Session["SortDirection"] = "DESC";
                }
                else
                {
                    Session["SortDirection"] = "ASC";
                }
                pSortDirection = Session["SortDirection"].ToString();
            }
            string pResult = "";
            switch (pSortExpression)
            {
                case "dongzuoshijian":
                    pResult = "dongzuoshijian " + pSortDirection + ",xuhao";
                    break;
                default:
                    pResult = pSortExpression + " " + pSortDirection;
                    break;
            }

            return pResult;
        }
        

        /// <summary>
        /// GridView分页
        /// </summary>
        /// <param name="pGridView"></param>
        /// <param name="pIndex"></param>
        /// <param name="pTextBoxPageNumber"></param>
        public void setGridViewPageIndexChanging(GridView pGridView, int pIndex, string pTextBoxPageNumber)
        {
            if (pIndex < 0)
            {
                TextBox pageNum = (TextBox)pGridView.BottomPagerRow.FindControl(pTextBoxPageNumber);
                int Pa = int.Parse(pageNum.Text);

                if (Pa <= 0)
                {
                    pGridView.PageIndex = 0;
                }
                else
                {
                    pGridView.PageIndex = Pa - 1;
                }
            }
            else
            {
                pGridView.PageIndex = pIndex;
            }
        }

       

       
    }
}