using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using model;
using System.Data;
using System.Data.SqlClient;
using DBUtility;



namespace DAL
{
    public class hx_yonghu : DBUserConfig.UserLogin
    {
        public DataTable selectData(string zhanghao, string mima)
        {
            string sql = "select *from hx_yonghu where zhanghao=@zhanghao and mima=@mima";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@zhanghao", SqlDbType.VarChar,20),
 new SqlParameter("@mima", SqlDbType.VarChar,20) };
            param[0].Value = zhanghao;
            param[1].Value = mima;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;
        }
        public int updataData(string zhanghao, string mima, string xmima)
        {
            string sql = "update hx_yonghu set mima=@xmima where zhanghao=@zhanghao and mima=@mima";
            SqlParameter[] param = new SqlParameter[] 
            { new SqlParameter("@zhanghao", SqlDbType.VarChar,20),
              new SqlParameter("@xmima", SqlDbType.VarChar,20),
              new SqlParameter("@mima", SqlDbType.VarChar,20) };
            param[0].Value = zhanghao;
            param[1].Value = xmima;
            param[2].Value = mima;
            int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
            return dt;
        }
        ///// <summary>
        ///// 增加数据
        ///// </summary>
        ///// <param name="mJianyi"></param>
        ///// <returns>xt_result</returns>
        //public int tijiao(Model.hx_neirong aaa)
        //{
        //    string sql = "insert into a vasues(@neirong,getdate());";
        //    SqlParameter[] param = new SqlParameter[] {new SqlParameter("@xuhao", SqlDbType.Int),
        //                                                new SqlParameter("@neirong", SqlDbType.NText),
        //                                                new SqlParameter("@riqi", SqlDbType.DateTime)
        //                                                 };


        //    param[0].Value = aaa.Xuhao;
        //    param[1].Value = aaa.Neirong;
        //    param[2].Value = aaa.Riqi;
        //    int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
        //    return dt;


            //xt_result result = new xt_result();
            //result.Message = "用户建议 提交成功！";
            //try
            //{
            //    result.ReturnInt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
            //    if (result.ReturnInt < 1)
            //    {
            //        result.Message = "提交 用户建议 失败！";
            //    }
            //}
            //catch (Exception e)
            //{
            //    result.Message = e.Message;
            //    result.Message = result.Message.Replace("\r\n", "\\n");
            //    result.Message = result.Message.Replace("'", "");

            //}

            //return dt;
        }
    }

