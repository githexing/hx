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
   public class DAL_Caidan : DBUserConfig.UserLogin
    {
        /// <summary>
        /// 用户菜单
        /// </summary>
        /// <param name="pYingyong"></param>
        /// <returns></returns>
        public DataTable getData(string pYingyong)
        {
            string sql = "select *,left(bianhao,2) zu1,right(bianhao,4) zu2 from caidan where yingyong=@yingyong  order by bianhao;";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@yingyong", SqlDbType.VarChar) };
            param[0].Value = pYingyong;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, CommandType.Text, sql, param);
            return dt;
        }

        /// <summary>
        /// 查询用户菜单
        /// </summary>
        /// <param name="daihao"></param>
        /// <returns></returns>
        public DataTable getCaidan(string pYingyong, string pYonghu)
        {
            string sql = "select a.*,left(a.bianhao,2) zu1,right(a.bianhao,4) zu2,b.jiancheng,b.url,b.image from gongneng a,caidan b " +
                "where (a.yingyong=b.yingyong and  a.bianhao=b.bianhao) and a.yingyong=@yingyong and a.daihao=@daihao and a.canshu0='1'  " +
                " order by left(b.bianhao,2),b.xuhao;";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@yingyong", SqlDbType.VarChar),
                                                        new SqlParameter("@daihao", SqlDbType.VarChar)};
            param[0].Value = pYingyong;
            param[1].Value = pYonghu;

            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);

            return dt;
        }
        public DataTable  getYingyong(string pYingyong)
        {
            string sql = "select * from caidan where yingyong=@pYingyong ";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@pYingyong", SqlDbType.VarChar) };
            param[0].Value = pYingyong;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);

            return dt;
        }
        public DataTable getGongneng()
        {
            string sql = "select * from gongneng ";
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, null);
            return dt;
        }
       /// <summary>
       /// 插入菜单
       /// </summary>
       /// <param name="?"></param>
       /// <returns></returns>
        public xt_result getCharucaidan(caidan mCaidan, string pDaihao)
       {
           string sql="insert into caidan(yingyong,bianhao,xuhao,fuxuhao,mingcheng,jiancheng,url,image) values(@yingyong,@bianhao,@xuhao,@fuxuhao,@mingcheng,@jiancheng,@url,@image);";
           sql = sql + "insert into gongneng(daihao,yingyong,bianhao,xuhao,mingcheng,canshu0,canshu1,canshu2,canshu3,canshu4,canshu5,canshu6,canshu7,canshu8,canshu9)values( @pDaihao,@yingyong,@bianhao,@xuhao,@mingcheng,'0','0','0','0','0','0','0','0','0','0')";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@yingyong", SqlDbType.VarChar),
                                                           new SqlParameter("@bianhao", SqlDbType.NVarChar),
                                                           new SqlParameter("@xuhao", SqlDbType.NVarChar),
                                                           new SqlParameter("@fuxuhao", SqlDbType.VarChar),
                                                           new SqlParameter("@mingcheng", SqlDbType.VarChar),
                                                           new SqlParameter("@jiancheng", SqlDbType.VarChar),
                                                           new SqlParameter("@url", SqlDbType.VarChar),
                                                           new SqlParameter("@image", SqlDbType.VarChar),
                                                           new SqlParameter("@pDaihao", SqlDbType.VarChar),};
            param[0].Value = mCaidan.Yingyong;
            param[1].Value = mCaidan.Bianhao;
            param[2].Value = mCaidan.Xuhao;
            param[3].Value = mCaidan.Fuxuhao;
            param[4].Value = mCaidan.Mingcheng;
            param[5].Value = mCaidan.Jiancheng;
            param[6].Value = mCaidan.Url;
            param[7].Value = mCaidan.Image;
            param[8].Value = pDaihao;
            xt_result result = new xt_result();
            result.Message = "插入 成功";
            try
            {
                result.ReturnInt = SQLHelper.ExecuteNonQuery(base.User_Login, CommandType.Text, sql, param);
                if (result.ReturnInt < 1)
                {
                    result.Message = "插入 失败";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Message = result.Message.Replace("\r\n", "\\n");
                result.Message = result.Message.Replace("'", "");
            }
            return result;
       
       }
       /// <summary>
       /// 更新菜单
       /// </summary>
       /// <param name="mCaidan"></param>
       /// <returns></returns>
        public xt_result getGengaicaidan(caidan mCaidan)
        {
            string sql = "update caidan set yingyong=@yingyong,xuhao=@xuhao,fuxuhao=@fuxuhao,mingcheng=@mingcheng,jiancheng=@jiancheng,url=@url,image=@image where bianhao=@bianhao ";
              SqlParameter[] param = new SqlParameter[] { new SqlParameter("@yingyong", SqlDbType.VarChar),
                                                           new SqlParameter("@bianhao", SqlDbType.NVarChar),
                                                           new SqlParameter("@xuhao", SqlDbType.NVarChar),
                                                           new SqlParameter("@fuxuhao", SqlDbType.VarChar),
                                                           new SqlParameter("@mingcheng", SqlDbType.VarChar),
                                                           new SqlParameter("@jiancheng", SqlDbType.VarChar),
                                                           new SqlParameter("@url", SqlDbType.VarChar),
                                                           new SqlParameter("@image", SqlDbType.VarChar),};
            param[0].Value = mCaidan.Yingyong;
            param[1].Value = mCaidan.Bianhao;
            param[2].Value = mCaidan.Xuhao;
            param[3].Value = mCaidan.Fuxuhao;
            param[4].Value = mCaidan.Mingcheng;
            param[5].Value = mCaidan.Jiancheng;
            param[6].Value = mCaidan.Url;
            param[7].Value = mCaidan.Image;

            //开始事务
            xt_result result = new xt_result();
            result.Message = "更新 成功";
            try
            {
                result.ReturnInt = SQLHelper.ExecuteNonQuery(base.User_Login, CommandType.Text, sql, param);
                if (result.ReturnInt < 1)
                {
                    result.Message = "更新 失败";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Message = result.Message.Replace("\r\n", "\\n");
                result.Message = result.Message.Replace("'", "");
            }
            return result;
        }
        /// <summary>
        /// 按条件提取数据
        /// </summary>
        /// <param name="pWhere"></param>
        /// <param name="pData"></param>
        /// <returns></returns>
        public DataTable getDataWhere(string pWhere, string pData)
        {
            string sql = "select * from caidan ";
            switch (pWhere)
            {
                case "yonghu":
                    sql = sql + " where yonghu=@data ";
                    break;
                case "xuhao":
                    sql = sql + " where xuhao=@data ";
                    break;
                default:
                    sql = sql + " where xuhao=@data ";
                    break;
            }
            sql = sql + " order by xuhao;";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@data", SqlDbType.VarChar) };
            param[0].Value = pData;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public xt_result getShanchucaidan(caidan mCaidan)
        {
            string sql = " delete caidan where xuhao=@xuhao and yingyong=@yingyong;";
            sql = sql + "delete gongneng where xuhao=@xuhao and yingyong=@yingyong;"; 
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@yingyong", SqlDbType.VarChar),
                                                           
                                                           new SqlParameter("@xuhao", SqlDbType.NVarChar) };
            param[0].Value = mCaidan.Yingyong; 
            param[1].Value = mCaidan.Xuhao; 
            xt_result result = new xt_result();
            result.Message = "删除 成功";
            try
            {
                result.ReturnInt = SQLHelper.ExecuteNonQuery(base.User_Login, CommandType.Text, sql, param);
                if (result.ReturnInt < 1)
                {
                    result.Message = "删除 失败";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Message = result.Message.Replace("\r\n", "\\n");
                result.Message = result.Message.Replace("'", "");
            }
            return result;

        }
        }
    }

