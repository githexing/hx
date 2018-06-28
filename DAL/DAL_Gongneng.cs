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
    public class DAL_Gongneng : DBUserConfig.UserLogin
    {
        /// <summary>
        /// 查询应用
        /// </summary>
        /// <returns></returns>
        public DataTable chaxun()
        {
            string sql = "select distinct yingyong from gongneng";// where xingming=@xingming 
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, null);
            return dt;
        }
        /// <summary>
        /// 查询应用
        /// </summary>
        /// <returns></returns>
        public DataTable getChaxun(string  pZubie)
        {
            string sql = "select daihao ,mingcheng  from  yonghu where  zubie=@zubie ";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@zubie", pZubie);
            DataTable dt = SQLHelper.ExecuteDt(base.User_Admin, sql, para);
            return dt;
        }
        /// <summary>
        /// 查询应用
        /// </summary>
        /// <returns></returns>
        public DataTable chaxun(string Table)
        {
            string sql = "select  *  from " + Table + "";// 
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@xingming", SqlDbType.VarChar) };
            param[0].Value = Table;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;

        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="mGongneng"></param>
        /// <returns></returns>
        public xt_result DelGongneng(gongneng mGongneng)
        {

            string sql = "delete from gongneng where daihao=@daihao and yingyong=@yingyong and  bianhao=@bianhao ";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@daihao", SqlDbType.VarChar,20) ,
                                                        new SqlParameter("@yingyong", SqlDbType.VarChar,20),
                                                        new SqlParameter("@bianhao", SqlDbType.VarChar, 6)};
            param[0].Value = mGongneng.Daihao;
            param[1].Value = mGongneng.Yingyong;
            param[2].Value = mGongneng.Bianhao;
            xt_result result = new xt_result();
            result.ReturnInt = SQLHelper.ExecuteNonQuery(base.User_Admin, sql, param);
            return result;

        }
        /// <summary>
        /// 插入功能
        /// </summary>
        /// <param name="mXt_gongneng"></param>
        /// <returns></returns>
        public xt_result InsertGongneng(gongneng mGongneng)
        {


            string sql = "insert into  gongneng values (@daihao,@yingyong,@bianhao,@xuhao,@mingcheng,@canshu0,@canshu1,@canshu2,@canshu3,@canshu4,@canshu5,@canshu6,@canshu7,@canshu8,@canshu9 )";

            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@daihao", SqlDbType.NVarChar,20),
                                                        new SqlParameter("@yingyong", SqlDbType.NVarChar,20),
                                                        new SqlParameter("@bianhao", SqlDbType.NVarChar,6),
                                                        new SqlParameter("@xuhao", SqlDbType.NVarChar,6),
                                                        new SqlParameter("@mingcheng", SqlDbType.NVarChar,10),
                                                        new SqlParameter("@canshu0", SqlDbType.NVarChar,1),
                                                        new SqlParameter("@canshu1", SqlDbType.NVarChar,1),
                                                        new SqlParameter("@canshu2", SqlDbType.NVarChar,1),
                                                        new SqlParameter("@canshu3", SqlDbType.NVarChar,1),
                                                        new SqlParameter("@canshu4", SqlDbType.NVarChar,1),
                                                        new SqlParameter("@canshu5", SqlDbType.NVarChar,1),
                                                        new SqlParameter("@canshu6", SqlDbType.NVarChar,1),
                                                        new SqlParameter("@canshu7", SqlDbType.NVarChar,1),
                                                        new SqlParameter("@canshu8", SqlDbType.NVarChar,1),
                                                        new SqlParameter("@canshu9", SqlDbType.NVarChar,1)
                                                        };

            param[0].Value = mGongneng.Daihao;
            param[1].Value = mGongneng.Yingyong;
            param[2].Value = mGongneng.Bianhao;
            param[3].Value = mGongneng.Xuhao;
            param[4].Value = mGongneng.Mingcheng;
            param[5].Value = mGongneng.Canshu0;
            param[6].Value = mGongneng.Canshu1;
            param[7].Value = mGongneng.Canshu2;
            param[8].Value = mGongneng.Canshu3;
            param[9].Value = mGongneng.Canshu4;
            param[10].Value = mGongneng.Canshu5;
            param[11].Value = mGongneng.Canshu6;
            param[12].Value = mGongneng.Canshu7;
            param[13].Value = mGongneng.Canshu8;
            param[14].Value = mGongneng.Canshu9;

            //开始事务
            xt_result result = new xt_result();
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
        /// <summary>
        /// 获取用户功能
        /// </summary>
        /// <param name="pYonghu">用户代号</param>
        /// <param name="pBianhao">菜单编号</param>
        /// <returns>DataTable</returns>
        public DataTable getGongneng_Bianhao(gongneng mGongneng)
        {
            string sql = "select * from gongneng where daihao=@daihao and yingyong=@yingyong and bianhao=@bianhao; ";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@daihao", SqlDbType.VarChar,20) ,
                                                        new SqlParameter("@yingyong", SqlDbType.VarChar,20),
                                                        new SqlParameter("@bianhao", SqlDbType.VarChar, 6)};
            param[0].Value = mGongneng.Daihao;
            param[1].Value = mGongneng.Yingyong;
            param[2].Value = mGongneng.Bianhao;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Admin, sql, param);
            return dt;
        }
        /// <summary>
        /// 获取用户功能菜单
        /// </summary>
        /// <param name="pYonghu">用户代号</param>
        /// <param name="pCanshu">参数</param>
        /// <returns>返回DataTable</returns>
        public DataTable getGongneng_Yonghu(gongneng mGongneng)
        {

            string sql = "select *,left(bianhao,2)+'0000' fuxuhao from gongneng a where a.daihao=@daihao and yingyong=@yingyong and a.canshu0=@canshu order by a.xuhao ;";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@daihao", SqlDbType.VarChar,20) ,
                                                        new SqlParameter("@yingyong", SqlDbType.VarChar,20),
                                                        new SqlParameter("@canshu", SqlDbType.VarChar, 1)};
            param[0].Value = mGongneng.Daihao;
            param[1].Value = mGongneng.Yingyong;
            param[2].Value = mGongneng.Canshu0;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Admin, sql, param);
            return dt;
        }
        /// <summary>
        /// 用户菜单
        /// </summary>
        /// <param name="pYingyong"></param>
        /// <returns></returns>
        public DataTable getDataCaidan(string pYingyong)
        {
            string sql = "select *,left(bianhao,2) zu1,right(bianhao,4) zu2 from caidan where yingyong=@yingyong  order by bianhao;";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@yingyong", SqlDbType.VarChar) };
            param[0].Value = pYingyong;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, CommandType.Text, sql, param);
            return dt;
        }
    }
}
