﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.Data;
using System.Web.Script.Serialization;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq; 
namespace WebApplication1.MainSystem.ceshi
{
    /// <summary>
    /// Ajax11 的摘要说明
    /// </summary>
    public class Ajax11 : IHttpHandler
    {
        BLL_Yonghu bYonghu = new BLL_Yonghu();
        StringBuilder sb = new StringBuilder();
        JavaScriptSerializer jss = new JavaScriptSerializer();
        static string strJson { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string one = context.Request["checkValue"]; 
            DataTable dt = bYonghu.getData9(one);
            if (dt.Rows.Count==1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Model.yonghu yh = RowToModel(dt.Rows[i]);
                    strJson = jss.Serialize(yh);
                    if (i == 0)
                    {
                        sb.Append("[" + strJson + "]");
                        continue;
                    }
                }
            }
            if (dt.Rows.Count!=1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Model.yonghu yh = RowToModel(dt.Rows[i]);
                    strJson = jss.Serialize(yh);
                    if (i == 0)
                    {
                        sb.Append("[" + strJson + ",");
                        continue;
                    }
                    if (i + 1 == dt.Rows.Count)
                    {
                        sb.Append( strJson + "]");
                        continue;
                    }
                    sb.Append(strJson + ",");
                }
            }
           
            ////context.Response.Write(sb.ToString());
            ////获取前台传递过来的授课JSON字符串数组  
            //string ss = sb.ToString();
            ////反序列化获取的JSON字符串数组  
            //JArray javascript = (JArray)JsonConvert.DeserializeObject(ss);
            //List<string> list = new List<string>();
            ////DataTable da = new DataTable("dt_AddStudentTeaherCourse");
            //for (int i = 0; i < javascript.Count; i++)
            //{
            //    JObject obj = (JObject)javascript[i];
            //    string Daihao = obj["Daihao"].ToString();
            //    string Mingcheng = obj["Mingcheng"].ToString();
            //    string Zubie = obj["Zubie"].ToString();
            //    string Images = obj["Images"].ToString();

            //    list.Add(" " + Daihao + " " + Mingcheng + " " + Zubie + " " + Images + "");

            //}
            //DataRow drAddStudentTeaherCourse = da.NewRow();//注意这边创建dt的新行的方法。指定类型是DataRow而不是TableRow，然后不用new直接的用创建的DataTable下面的NewRow方法。  
            context.Response.Write(sb.ToString());
        }

        private Model.yonghu RowToModel(DataRow dr)
        {
            Model.yonghu yh = new Model.yonghu();
            yh.Daihao = dr["Daihao"].ToString();
            yh.Images = dr["Images"].ToString();
            yh.Mingcheng = dr["Mingcheng"].ToString();
            yh.Zubie = dr["Zubie"].ToString();
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