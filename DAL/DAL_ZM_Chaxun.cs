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
    public class DAL_ZM_Chaxun : DBUserConfig.UserLogin
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable getData()
        {
            string sql = "select a.*,b.* from zuce a join xinxi b on a.shenfenzheng=b.shenfenzheng";
           
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, null);
            return dt;
        }
        /// <summary>
        /// 选择查询
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
        public DataTable selectData( string pWhere,string pData)
        {
            string sql = "select a.*,b.* from zuce a join xinxi b on a.shenfenzheng=b.shenfenzheng";
            switch (pWhere)
            {
                case "shenfenzheng":
                    sql = sql + " where a.shenfenzheng=@data";
                    break;
                case "xingming":
                    pData = "%" + pData + "%";
                    sql = sql + " where b.xingming like @data";
                    break;
                default:
                   sql = sql + " where a.shenfenzheng=@data";
                    break;
            }
                    SqlParameter[] param = new SqlParameter[] 
            { 
              new SqlParameter("@data", SqlDbType.VarChar,20)
            };
                param[0].Value = pData;
              DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;
            }
        
    }
}
