﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace WebZm.MainSystem.fenye
{
    public partial class WebForm2 : App_Code.App_UtilityPage//System.Web.UI.Page
    {
       BLL.BLL_CS_Caozuo yonghu=new BLL_CS_Caozuo();
       protected void Page_Load(object sender, EventArgs e)
       {
           if (!IsPostBack)
           {
               getData("xuhao", "ASC");
           }
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

           DataTable dt = yonghu.chaxun("%");
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

       }

       protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
       {
           setGridViewRowDataBound("Chaxun", e, " 人");
       }

      


    }
}