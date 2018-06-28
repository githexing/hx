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
    public class DAL_XT_Tongji : DBUserConfig.UserLogin
    {
        /// <summary>
        /// 查询xt_tongji
        /// </summary>
        /// <returns></returns>
        public DataTable getData()
      {
          string sql = "select * from xt_tongji";
          DataTable dt = SQLHelper.ExecuteDt(base.User_Login, CommandType.Text, sql, null);
          return dt;
      }
        /// <summary>
        /// 更新xt_tongji中的人数
        /// </summary>
        /// <param name="renshu"></param>
        /// <returns></returns>
        public xt_result UpData(int renshu)
        {
            string sql = "update xt_tongji set renshu=@renshu;";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@renshu", SqlDbType.VarChar),
                                                         };
            param[0].Value = renshu; 
            //开始事务
            xt_result result = new xt_result();
            result.Message = "更新数据 成功";
            SqlTransaction Trans;
            SqlConnection conn = SQLHelper.CreateConnection(base.User_Admin);
            conn.Open();
            Trans = conn.BeginTransaction("trans1");
            try
            {
                result.ReturnInt = SQLHelper.ExecuteNonQuery(Trans, CommandType.Text, sql, param);
                if (result.ReturnInt > 0)
                {
                    Trans.Commit();
                }
                else
                {
                    result.Message = "更新数据  失败";
                }
            }
            catch (Exception e)
            {

                result.Message = e.Message;
                result.Message = result.Message.Replace("\r\n", "");
                result.Message = result.Message.Replace("'", "");
                Trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
