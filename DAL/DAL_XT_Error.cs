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
    public class DAL_XT_Error : DBUserConfig.UserLogin
    {
        /// <summary>
        /// 记录应用系统错误消息
        /// </summary>
        /// <param name="mError">错误实体</param>
        /// <returns>xt_result</returns>
        public xt_result SaveError(IList<xt_error> lError)
        {
            //错误消息
            string sql = "";
            int i = lError.Count;
            for (int j = 0; j<i; j ++)
            {
                if (lError[j].Message.Length > 500)
                {
                    lError[j].Message = lError[j].Message.Substring(0, 498);
                }
                sql = sql + "insert into xt_error (application,message) values ('"+lError[j].Application+"','"+lError[j].Message+"') ;";
            }
            //开始事务
            xt_result result = new xt_result();
            SqlTransaction Trans;
            SqlConnection conn = SQLHelper.CreateConnection(base.User_Admin);
            conn.Open();
            Trans = conn.BeginTransaction("trans1");
            try
            {
                result.ReturnInt = SQLHelper.ExecuteNonQuery(base.User_Admin, CommandType.Text, sql, null);
                if (result.ReturnInt > 0)
                {
                    Trans.Commit();
                }
            }
            catch (Exception e)
            {

                result.Message = e.Message;
                result.Message = result.Message.Replace("\r\n", "\\n");
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
