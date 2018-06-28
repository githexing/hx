﻿using System;
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
using System.IO;


namespace WebApplication1.MainSystem.ceshi
{
    public partial class Excel : System.Web.UI.Page
    {
        BLL_Yonghu bYonghu = new BLL_Yonghu();
        protected void Page_Load(object sender, EventArgs e)
        {

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
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            string pSavePath = Server.MapPath("~/XLS/");
            if (!FileUpload1.HasFile)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('请选择要上传的文件！ ')</script>", false);
                return;
            }
            string pFileName = FileUpload1.FileName;
            Session["mingcheng"] = pFileName.ToString();
            pSavePath += pFileName;
            FileUpload1.SaveAs(pSavePath);
            FileUpload1.Dispose();
            int i = pFileName.Length - 4;
            if (pFileName.Substring(i) == ".zip")
            {
                CompresssFiles.UnZip(pSavePath, Server.MapPath("~/XLS/"));
            }
            //Session.Clear();

           string a= Session["mingcheng"].ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('上传成功！ 文件名为：" + FileUpload1.FileName + "  文件类型为：" + FileUpload1.PostedFile.ContentType + "  文件大小为：" + FileUpload1.PostedFile.ContentLength + "')</script>", false);
         

         //    string name = GetFiles.FileName;//获取已上传文件的名字
         //string size = GetFiles.PostedFile.ContentLength.ToString();//获取已上传文件的大小
         //string type = GetFiles.PostedFile.ContentType;//获取已上传文件的MIME
         //string postfix = name.Substring(name.LastIndexOf(".") + 1);//获取已上传文件的后缀
         //string ipath = Server.MapPath("upimg") +"\\"+ name;//获取文件的实际路径
         //string fpath = Server.MapPath("upfile") + "\\" + name;
         //string dpath = "upimg\\" + name;//判断写入数据库的虚拟路径

         //ShowPic.Visible = true;//激活
         //ShowText.Visible = true;//激活

         ////判断文件格式
         //if (name == "") {
         //  Response.Write("<script>alert('上传文件不能为空')</script>");
         //}

         //else{

         //    if (postfix == "jpg" || postfix == "gif" || postfix == "bmp" || postfix == "png")
         //    {
         //        GetFiles.SaveAs(ipath);
         //        ShowPic.ImageUrl = dpath;
         //        ShowText.Text = "你上传的图片名称是:" + name + "<br>" + "文件大小:" + size + "KB" + "<br>" + "文件类型:" + type + "<br>" + "存放的实际路径为:" + ipath;

         //    }

         //    else
         //    {
         //        ShowPic.Visible = false;//隐藏图片
         //        GetFiles.SaveAs(fpath);//由于不是图片文件,因此转存在upfile这个文件夹
         //        ShowText.Text = "你上传的文件名称是:" + name + "<br>" + "文件大小:" + size + "KB" + "<br>" + "文件类型:" + type + "<br>" + "存放的实际路径为:" + fpath;

         //    }
        }
        /// <summary>
        /// 导入数据库并且选导入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button6_Click(object sender, EventArgs e)
        {
            string a = Session["mingcheng"].ToString();
            string str = Server.MapPath("~/XLS/"+a+"");
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
            string strCom = " SELECT * FROM [chengji$];";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            DataSet myDataSet = new DataSet();
            myCommand.Fill(myDataSet, "[chengji$]");
            DataTable dt = myDataSet.Tables[0];
            //创建数据库
            //GetColumnsByDataTable(dt);
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

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Server.MapPath("~/upimg/hufu")) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(Server.MapPath("~/upimg/hufu"));
            }

            //Directory.Delete(Server.MapPath("~/upimg/hufu"), true);//删除文件夹以及文件夹中的子目录，文件    

            //判断文件的存在

            //if (File.Exists(Server.MapPath("~/upimg/Data.html")))
            //{
            //    Response.Write("Yes");

            //    //存在文件

            //}

            //else
            //{
            //    Response.Write("No");
            //    //不存在文件
            //    File.Create(MapPath("~/upimg/Data.html"));//创建该文件

            }
        }
    }
