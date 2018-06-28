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
    public class DAL_ZM_Zuce : DBUserConfig.UserLogin
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="yonghu"></param>
        /// <param name="mima"></param>
        /// <param name="xingming"></param>
        /// <param name="dizhi"></param>
        /// <param name="dianhua"></param>
        /// <param name="youjian"></param>
        /// <returns></returns>
       public int zengjia(string yonghu, string mima, string xingming, string dizhi, string dianhua,string youjian,string daihao,string shenfenzheng)
       {
           string sql = "insert into zuce(yonghu, mima,xingming,dizhi,dianhua,youjian,daihao,shenfenzheng)values(@yonghu,@mima,@xingming,@dizhi,@dianhua,@youjian ,@daihao,@shenfenzheng);";
           sql = sql + "insert into xinxi(shenfenzheng,xingming)values(@shenfenzheng,@xingming);";
            
           SqlParameter[] param = new SqlParameter[] 
            { 
              new SqlParameter("@yonghu", SqlDbType.VarChar,20),
              new SqlParameter("@mima", SqlDbType.VarChar,20) ,
              new SqlParameter("@xingming", SqlDbType.VarChar,20),
              new SqlParameter("@dizhi", SqlDbType.VarChar,20) ,
              new SqlParameter("@dianhua", SqlDbType.VarChar,20) ,
             new SqlParameter("@youjian", SqlDbType.VarChar,20) ,
             new SqlParameter("@daihao", SqlDbType.VarChar,20), 
               new SqlParameter("@shenfenzheng", SqlDbType.VarChar,18) 
            };
           param[0].Value = yonghu;
           param[1].Value = mima;
           param[2].Value = xingming;
           param[3].Value = dizhi;
           param[4].Value = dianhua;
           param[5].Value = youjian;
           param[6].Value = daihao;
           param[7].Value = shenfenzheng;
           int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
           return dt;
       }
        /// <summary>
        ///  查询账户
        /// </summary>
        /// <param name="yonghu"></param>
        /// <param name="mima"></param>
        /// <returns></returns>
       public DataTable getData(string yonghu, string mima)
       {
           string sql = "select * from zuce where yonghu=@yonghu and mima=@mima";
           SqlParameter[] param = new SqlParameter[] 
            { 
              new SqlParameter("@yonghu", SqlDbType.VarChar,20),
              new SqlParameter("@mima", SqlDbType.VarChar,20) 
            };
           param[0].Value = yonghu;
           param[1].Value = mima;
           DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
           return dt;
       }
          /// <summary>
        ///  查询账户
        /// </summary>
        /// <param name="yonghu"></param>
        /// <param name="mima"></param>
        /// <returns></returns>
       public DataTable getData(string yonghu)
       {
           string sql = "select * from zuce where yonghu= @yonghu";
            
           SqlParameter[] param = new SqlParameter[] 
            { 
              new SqlParameter("@yonghu", SqlDbType.VarChar,20)
             
            };
             param[0].Value = yonghu;
             DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
           return dt;
       }
       public DataTable getData1(string yonghu, string pWhere)
       {
           string sql = "select * from zuce where yonghu=@yonghu and mima=@mima";
           SqlParameter[] param = new SqlParameter[] 
            { 
              new SqlParameter("@yonghu", SqlDbType.VarChar,20),
              new SqlParameter("@mima", SqlDbType.VarChar,20) 
            };
           param[0].Value = yonghu;
           param[1].Value = pWhere;
           DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
           return dt;

       }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="yonghu"></param>
        /// <param name="mima"></param>
        /// <param name="mima1"></param>
        /// <returns></returns>
       public int UpdataData( string yonghu ,string mima, string mima1)
       {
           string sql = "update zuce set mima=@mima1 where yonghu=@yonghu and  mima=@mima";
           SqlParameter[] param = new SqlParameter[] 
            { 
              new SqlParameter("@yonghu", SqlDbType.VarChar,20),
              new SqlParameter("@mima", SqlDbType.VarChar,20) ,
              new SqlParameter("@mima1", SqlDbType.VarChar,20)
            };
               param[0].Value = yonghu;
               param[1].Value = mima;
               param[2].Value = mima1;
           int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
           return dt;
       }
       public int guiji(string shijian)
       {
           string sql = "insert into guiji select " +
                           "getdate()";
           SqlParameter[] param = new SqlParameter[] {  
                                                          new SqlParameter("@shijian", SqlDbType.DateTime) };
           param[0].Value = shijian;
           int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
           return dt;
       }

    }
}
