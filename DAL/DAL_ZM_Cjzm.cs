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
    public class DAL_ZM_Cjzm : DBUserConfig.UserLogin
    {
       /// <summary>
       /// 获取证书
       /// </summary>
       /// <param name="pXuhao"></param>
       /// <param name="pKaoshenghao"></param>
       /// <returns></returns>
        public DataTable getData(string pXuhao, string pShenfenzheng)
        {
            string sql = "select * from zm_cjzm where xuhao=@xuhao and shenfenzheng=@shenfenzheng;";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@xuhao", SqlDbType.VarChar ),
                                                        new SqlParameter("@shenfenzheng", SqlDbType.VarChar)};
            param[0].Value = pXuhao;
            param[1].Value = pShenfenzheng;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;
        }
        /// <summary>
        /// 查询方式
        /// </summary>
        /// <param name="pWhere"></param>
        /// <param name="pData"></param>
        /// <returns></returns>
        public DataTable getData_Where(string pWhere, string pData)
        {
            string sql = "select * from zm_cjzm ";
            switch (pWhere)
            {
                case "xuhao":
                    sql = sql + " where xuhao=@data ";
                    break;
                case "xingming":
                    pData = pData + "%";
                    sql = sql + " where xingming like @data ";
                    break;
                default:
                    sql = sql + " where xuhao=@data ";
                    break;

            }
            sql=sql+" order by xuhao;";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@data", SqlDbType.VarChar )};
            param[0].Value = pData;

            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;
        }

       

        /// <summary>
        /// 提取上传数据
        /// </summary>
        /// <returns></returns>
        public DataTable getData_Import()
        {
            string sql = "select * from zm_cjzm where xuhao in (select xh from temp_data) order by xuhao ;";
            
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, null);
            return dt;
        }
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="pLeixing"></param>
        /// <returns></returns>
        public xt_result ImportFile(string pLeixing)
        {
            SqlParameter[] param = new SqlParameter[] {new SqlParameter("@leixing", SqlDbType.VarChar),
                                                        new SqlParameter("@ReturnValue", SqlDbType.Int)};
            param[0].Value = pLeixing;
            param[1].Direction = ParameterDirection.ReturnValue;
            xt_result sult = new xt_result();
            sult.Message = "数据导入完毕！";
            try
            {
                sult.ReturnInt = SQLHelper.ExecuteNonQuery(base.User_Login, CommandType.StoredProcedure, "pro_import", param);
            }
            catch (Exception e)
            {
                sult.Message = e.Message;
                sult.Message = sult.Message.Replace("\r\n", "");
                sult.Message = sult.Message.Replace("'", "");
                return sult;
            }
            if (param[1].Value == null)
                sult.ReturnValue = -1;
            else
                sult.ReturnValue = (int)param[1].Value;
            return sult;
        }
    }
}
