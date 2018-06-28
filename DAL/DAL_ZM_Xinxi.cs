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
    public class DAL_ZM_Xinxi : DBUserConfig.UserLogin
    {
        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="yonghu"></param>
        /// <param name="mima"></param>
        /// <param name="xingming"></param>
        /// <param name="dizhi"></param>
        /// <param name="dianhua"></param>
        /// <param name="youjian"></param>
        /// <returns></returns>
        public int zengjia(string shenfenzheng, string xingming, string xingbie, string dizhi, string daxue ,string zhongxue ,string shouji)
        {
            string sql = "insert into xinxi(shenfenzheng,xingming,xingbie,dizhi,daxue,zhongxue,shouji)values(@shenfenzheng,@xingming,@xingbie,@dizhi,@daxue,@zhongxue,@shouji)";
            SqlParameter[] param = new SqlParameter[] 
            { 
              new SqlParameter("@shenfenzheng", SqlDbType.VarChar,20),
              new SqlParameter("@xingming", SqlDbType.VarChar,20) ,
              new SqlParameter("@xingbie", SqlDbType.VarChar,20),
               new SqlParameter("@dizhi", SqlDbType.VarChar,20) ,
               new SqlParameter("@daxue", SqlDbType.VarChar,20) ,
              new SqlParameter("@zhongxue", SqlDbType.VarChar,20) ,
               new SqlParameter("@shouji", SqlDbType.VarChar,20) 
           
            };
            param[0].Value = shenfenzheng;
            param[1].Value = xingming;
            param[2].Value = xingbie;
            param[3].Value = dizhi;
            param[4].Value = daxue;
            param[5].Value = zhongxue;
            param[6].Value = shouji;
            int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
            return dt;
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="yonghu"></param>
        /// <param name="mima"></param>
        /// <param name="mima1"></param>
        /// <returns></returns>
        public int UpdataData(string shenfenzheng, string xingming, string xingbie, string dizhi, string daxue, string zhongxue, string shouji)
        {
            string sql = "update xinxi set xingming=@xingming,xingbie=@xingbie,dizhi=@dizhi,daxue=@daxue,zhongxue=@zhongxue,shouji=@shouji where shenfenzheng=@shenfenzheng";
            SqlParameter[] param = new SqlParameter[] 
            { 
               
              new SqlParameter("@xingming", SqlDbType.VarChar,20) ,
              new SqlParameter("@xingbie", SqlDbType.VarChar,20),
               new SqlParameter("@dizhi", SqlDbType.VarChar,20) ,
               new SqlParameter("@daxue", SqlDbType.VarChar,20) ,
              new SqlParameter("@zhongxue", SqlDbType.VarChar,20) ,
               new SqlParameter("@shouji", SqlDbType.VarChar,20) ,
               new SqlParameter("@shenfenzheng", SqlDbType.VarChar,20)
            };
           
            param[0].Value = xingming;
            param[1].Value = xingbie;
            param[2].Value = dizhi;
            param[3].Value = daxue;
            param[4].Value = zhongxue;
            param[5].Value = shouji;
            param[6].Value = shenfenzheng;
            int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
            return dt;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable getData(string yonghu)
        {
            string sql = "select a.*,b.* from zuce a join xinxi b on a.shenfenzheng=b.shenfenzheng where a.yonghu=@yonghu";
            SqlParameter[] param = new SqlParameter[] 
            { 
              new SqlParameter("@yonghu", SqlDbType.VarChar,20) 
            };
             param[0].Value = yonghu;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;
        }
    }
}
