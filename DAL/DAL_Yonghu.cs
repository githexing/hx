using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AppCommon;
using DBUtility;
using Model;



namespace DAL
{
    public class DAL_Yonghu : DBUserConfig.UserLogin
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable getData()
        {
            string sql = "select * from yonghu   ;";

            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, null);
            return dt;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable getData9(string a)
        {

            string sql = "select * from yonghu where daihao= " + a + "";
            DataTable dt = SQLHelper.ExecuteDt(base.User_Admin, sql, null);
            return dt;
        }
        /// <summary>
        /// 查询表字段
        /// </summary>
        /// <returns></returns>
        public DataTable getData1()
        {
            string sql = "Select name FROM SysColumns Where id=Object_Id('yonghu');";

            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, null);
            return dt;
        }
        public DataTable getData3(string d, string m, string r, string b)
        {
            string sql = "insert into temp4(daihao,mingcheng,renshu,baoming)values(@d,@m,@r,@b)";
            SqlParameter[] param = new SqlParameter[] {  new SqlParameter("@d", SqlDbType.VarChar,50),
                                                         new SqlParameter("@m", SqlDbType.VarChar,50),
                                                          new SqlParameter("@r", SqlDbType.VarChar,50),
                                                         new SqlParameter("@b", SqlDbType.VarChar,50) };
            param[0].Value = d;
            param[1].Value = m;
            param[2].Value = r;
            param[3].Value = b;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;
        }
        /// <summary>
        /// 更新参数值
        /// </summary>
        /// <param name="pDaihao">参数名</param>
        /// <param name="pCanshu">参数值</param>
        /// <returns>返回影响行数</returns>
        public xt_result Update_Canshu(string pDaihao, string pCanshu)
        {
            string sql = "update yonghu set mingcheng=@mingcheng where daihao=@daihao";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@daihao", SqlDbType.VarChar, 50),
                                   new SqlParameter("@mingcheng", SqlDbType.VarChar, 50)};
            param[0].Value = pDaihao;
            param[1].Value = pCanshu;
            xt_result sult = new xt_result();
            sult.Message = "更新成功！";
            try
            {
                sult.ReturnInt = SQLHelper.ExecuteNonQuery(base.User_Login, CommandType.Text, sql, param);
            }
            catch (Exception e)
            {
                sult.Message = e.Message;
                sult.Message = sult.Message.Replace("\r\n", "");
                sult.Message = sult.Message.Replace("'", "");
            }
            return sult;
        }
         /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable getData2(string s)
        {

            string sql = "select * into temp4 from " + s + "";
            DataTable dt = SQLHelper.ExecuteDt(base.User_Admin, sql, null);
            return dt;
        }
           /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable getData4(string a)
        {
            //[自动编号字段] int IDENTITY (1,1) PRIMARY KEY ,
            string sql = " create table [temp5] ( ["+a+"] nVarChar(50) default '默认值' null )";
            DataTable dt = SQLHelper.ExecuteDt(base.User_Admin, sql, null);
            return dt;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable getData5(string a)
        {
            string sql = "ALTER TABLE [temp5] ADD ";
                switch(a)
                {
                    //case "学校代号":
                    //    sql=sql+" ["+a+"] NVARCHAR (50) NULL ;";
                    //    break;
                    //case "学校名称":
                    //    sql = sql + " [" + a + "] NVARCHAR (50) NULL ;";
                    //    break;
                    //case "专业序号":
                    //    sql = sql + " [" + a + "] NVARCHAR (50) NULL ;";
                    //    break;
                    //case "招生专业名称":
                    //    sql = sql + " [" + a + "] NVARCHAR (50) NULL ;";
                    //    break;
                    //case "科类":
                    //    sql = sql + " [" + a + "] NVARCHAR (50) NULL ;";
                    //    break;
                    //case "层次":
                    //    sql = sql + " [" + a + "] NVARCHAR (50) NULL ;";
                    //    break;
                    //case "学制":
                    //    sql = sql + " [" + a + "] NVARCHAR (50) NULL ;";
                    //    break;
                    //case "学费":
                    //    sql = sql + " [" + a + "] NVARCHAR (50) NULL ;";
                    //    break;
                    //case "计划数":
                    //    sql = sql + " [" + a + "] NVARCHAR (50) NULL ;";
                    //    break;
                    //case "备注":
                    //    sql = sql + " [" + a + "] NVARCHAR (50) NULL ;";
                    //    break;
                    case "daihao":
                        sql = sql + " [" + a + "] NVARCHAR (50) NULL ;";
                        break;
                    case "mingcheng":
                        sql = sql + " [" + a + "] NVARCHAR (50) NULL ;";
                        break;


                }
            DataTable dt = SQLHelper.ExecuteDt(base.User_Admin, sql, null);
            return dt;
        }
        
    }
}
