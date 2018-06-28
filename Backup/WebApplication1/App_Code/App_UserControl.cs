﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WebApplication1.App_Code
{
    public class App_UserControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// 页面初始化时检查 session，失效时自动跳转到登录页面
        /// </summary>
        /// <param name="O"></param>
        protected override void OnInit(EventArgs O)
        {
            
            base.OnInit(O);
        }
        /// <summary>
        /// 设置DropDownList
        /// </summary>
        /// <param name="pDropDownList">DropDownList</param>
        /// <param name="dt">数据源</param>
        /// <param name="pText">文本</param>
        /// <param name="pValue">值</param>
        /// <param name="pNewItemText">新增项文本</param>
        /// <param name="pNewItemValue">新增项值</param>
        public void setDropDownList(DropDownList pDropDownList, DataTable dt, string pText, string pValue, string pNewItemText, string pNewItemValue)
        {
            pDropDownList.DataSource = dt;
            pDropDownList.DataTextField = pText;
            pDropDownList.DataValueField = pValue;
            pDropDownList.DataBind();
            if (pNewItemText != "")
            {
                pDropDownList.Items.Insert(0, new ListItem(pNewItemText, pNewItemValue));
            }
        }
        /// <summary>
        /// 设置RadioButtonList
        /// </summary>
        /// <param name="pRadioButtonList">RadioButtonList</param>
        /// <param name="dt">数据源</param>
        /// <param name="pText">文本</param>
        /// <param name="pValue">值</param>
        /// <param name="pNewItemText">新增项文本</param>
        /// <param name="pNewItemValue">新增项值</param>
        public void setRadioButtonList(RadioButtonList pRadioButtonList, DataTable dt, string pText, string pValue, string pNewItemText, string pNewItemValue)
        {
            pRadioButtonList.DataSource = dt;
            pRadioButtonList.DataTextField = pText;
            pRadioButtonList.DataValueField = pValue;
            pRadioButtonList.DataBind();
            if (pNewItemText != "")
            {
                pRadioButtonList.Items.Insert(0, new ListItem(pNewItemText, pNewItemValue));
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
                case "zhuangtai":
                    pResult = "zhuangtai " + pSortDirection + ",kaoshenghao";
                    break;
                case "dongzuoshijian":
                    pResult = "dongzuoshijian " + pSortDirection + ",kaoshenghao";
                    break;
                default:
                    pResult = pSortExpression + " " + pSortDirection;
                    break;
            }

            return pResult;
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
