using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using Model;
namespace DAL
{
    public class DAL_CS_Caozuo : DBUserConfig.UserLogin
    {
        public DataTable chaxun(string p)
        {
            string sql = "select *from zm_cjzm";// where xingming=@xingming
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@xingming", SqlDbType.VarChar) };
            param[0].Value = p;

            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;
        }
        public DataTable aa(string p)
        {
            string sql = "select *from zm_cjzm where xuhao like @xuhao";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@xuhao", SqlDbType.VarChar) };
            param[0].Value = p;

            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;

        }

        public int qq(string xingming,string shijian )
        {
        //    string sql = "insert into xingming(xingming,shijian) valuse(@xingming,getdate())";
            string sql = "insert into xingming select " +
                           "@xingming,getdate()";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@xingming", SqlDbType.VarChar),
                                                          new SqlParameter("@shijian", SqlDbType.DateTime) };
            param[0].Value = xingming;
            param[1].Value = shijian;
            int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
            return dt;
        }
    }
}
