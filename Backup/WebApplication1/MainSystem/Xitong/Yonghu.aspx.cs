using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Model;
using AppCommon;
using System.Data.OleDb;
using System.Data.SqlClient;




namespace WebApplication1.MainSystem.Xitong
{
    public partial class Yonghu : App_Code.App_UserPage
    {
        BLL_Yonghu bYonghu = new BLL_Yonghu();
        BLL_Procedure bProcedure = new BLL_Procedure();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData("daihao", "ASC");
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

            DataTable dt = bYonghu.getData();
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

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    setGridViewRowDataBound("Chaxun", e, " 人");
        //}

        /// <summary>
        /// 行更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string pDaihao = GridView1.Rows[e.RowIndex].Cells[0].Text;
            string pCanshu = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].FindControl("TextBox_mingcheng")).Text;
            xt_result result = new xt_result();
            result = bYonghu.Update_Canshu(pDaihao, pCanshu);
            if (result.ReturnInt < 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('保存参数失败！')</script>", false);
                return;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('保存参数成功！')</script>", false);
            GridView1.EditIndex = -1;
            getData("", "");
        }


        /// <summary>
        /// 行修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            
            getData("", "");
        }
        /// <summary>
        /// 行取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getData("", "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            DataTable dt = bYonghu.getData();
            DataTable dt1 = bYonghu.getData1();
            List<string> list = new List<string>();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string s = dt1.Rows[i][0].ToString();
                //string s = list[i].ToString();
                list.Add("" + s + "");
            }

            //list.Add("yonghu");


            //study.Excel.DownToExcel(dt, list);
            study.Excel.ExplorerExcel(dt, list);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            bool fileOK = false;
            //判断upload是否有文件
            if (FileUpload1.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" }; //防止垃圾上传
                for (int i = 0; i < allowedExtensions.Length; i++)
                    if (fileExtension == allowedExtensions[i])
                    { fileOK = true; }
            }
            else if (FileUpload1.HasFile == false)
            {//upload有文件但是垃圾文件不是图片
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('请选择要上传的文件！ ')</script>", false);
            }
            if (fileOK)
            { //有文件且是图片
                string path = Server.MapPath("~/images/");
                string postaddpath = DateTime.Now.ToString("yyyyMMddhhmmss");
                FileUpload1.PostedFile.SaveAs(path + postaddpath + ".jpg");
                //FileUpload1.SaveAs(path);
                FileUpload1.Dispose();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('上传成功！ ')</script>", false);
                //allpath = "image/BBspost/" + postaddpath + ".jpg";
                //write();
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string pSavePath = Server.MapPath("~/XLS/");
            if (!FileUpload1.HasFile)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('请选择要上传的文件！ ')</script>", false);
                return;
            }
            string pFileName = FileUpload1.FileName;
            pSavePath += pFileName;
            FileUpload1.SaveAs(pSavePath);
            FileUpload1.Dispose();
            int i = pFileName.Length - 4;
            if (pFileName.Substring(i) == ".zip")
            {
                CompresssFiles.UnZip(pSavePath, Server.MapPath("~/XLS/"));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('上传成功！ 文件名为：" + FileUpload1.FileName + "  文件类型为：" + FileUpload1.PostedFile.ContentType + "  文件大小为：" + FileUpload1.PostedFile.ContentLength + "')</script>", false);

        }
        /// <summary>
        /// 获取表地址并且导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = Server.MapPath("~/XLS/kaodian.xls");
            GetExcelData(str); 
            //string path = Server.MapPath("~/XLS/");
            ////string path = "C:/Users/hexing/Desktop/何兴测试/动态导航/hexing/WebApplication1/";
            //xt_result result = bProcedure.ImportMingce(Session["daihao"].ToString(), "1", "pro_daoru_kaodian_01", path);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('系统信息：" + result.Message + "')</script>", false);
            //if (result.ReturnValue == 1)
            //{
            //    //getDataTemp("shenfenzheng", "ASC");
            //}
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string path = "C:/Users/hexing/Desktop/何兴测试/动态导航/hexing/WebApplication1/";
            xt_result result = bProcedure.ImportMingce(Session["daihao"].ToString(), "1", "pro_daoru_kaodian_01", path);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('系统信息：" + result.Message + "')</script>", false);
        }
        /// <summary>
        /// 一次一次插入
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private DataSet GetExcelData(string str)
        {
            string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + str + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = " SELECT * FROM [kaodian$];";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            DataSet myDataSet = new DataSet();
            myCommand.Fill(myDataSet, "[kaodian$]");
            DataTable dt = myDataSet.Tables[0];
            if (dt.Rows.Count>0)
            {
                  for (int i = 0; i < dt.Rows.Count; i++)
            {
                string d = dt.Rows[i]["daihao"].ToString();
                string m = dt.Rows[i]["mingcheng"].ToString();
                string r = dt.Rows[i]["renshu"].ToString();
                string b = dt.Rows[i]["baoming"].ToString();
                DataTable dt1 = bYonghu.getData3(d,m,r,b);
                
            }
                
            }
            myConn.Close();

            return myDataSet;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string str = Server.MapPath("~/XLS/a.xls"); 
            ///还得写个除空值
            GetExcelData1(str);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('系统信息： 导入成功')</script>", false);
          
        }
        /// <summary>
        /// 只是负责批量导入 不看字段名
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private DataSet GetExcelData1(string str)
        {
            string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + str + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = " SELECT * FROM [a$];";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            DataSet myDataSet = new DataSet();
            myCommand.Fill(myDataSet, "[a$]");
            DataTable dt = myDataSet.Tables[0];
            GetColumnsByDataTable(dt); 
            ///打开数据库 直接批量插入
            string str1 = "Data Source=.;Initial Catalog=my;Pooling=true; min pool size=5; max pool size=600;Persist Security Info=True;User ID=sa;Password=swlk_2011";
            using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(str1))
            {

                bcp.BatchSize = 100;//每次传输的行数 
                bcp.DestinationTableName = "temp5";//目标表



                bcp.WriteToServer(dt);

            }

            myConn.Close();

            return myDataSet;
        }
        /// <summary>
        /// 根据datatable获得列名
        /// </summary>
        /// <param name="dt">表对象</param>
        /// <returns>返回结果的数据列数组</returns>
        public string[] GetColumnsByDataTable(DataTable dt)
        {
            string[] strColumns = null;

           
            if (dt.Columns.Count > 0)
            {
                int columnNum = 0;
                columnNum = dt.Columns.Count; 
                strColumns = new string[columnNum];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    strColumns[i] = dt.Columns[i].ColumnName;
                    string a = dt.Columns[i].ColumnName;
                    ///创建表字段
                    if (i < 1)
                    {
                        DataTable dt2 = bYonghu.getData4(a);
                    }
                    else
                    {
                        
                        DataTable dt3 = bYonghu.getData5(a);

                    }
                }
                
            }


            return strColumns;
        }
        

        }
    }
