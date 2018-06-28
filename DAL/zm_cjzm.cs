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
    public class zm_cjzm : DBUserConfig.UserLogin
    {
        public DataTable getDate(string xingming, string shenfenzheng)
        {
            string sql = "select *from zm_cjzm where xingming=@xingming and shenfenzheng=@shenfenzheng";
            SqlParameter[] param = new SqlParameter[] 
            { new SqlParameter("@xingming", SqlDbType.VarChar,20),
              new SqlParameter("@shenfenzheng", SqlDbType.VarChar,20)};
            param[0].Value = xingming;
            param[1].Value = shenfenzheng;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;

        }
        /// <summary>
        /// getalldate
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public DataTable getalldate(string p)
        {
            string sql = "select *from zm_cjzm where xuhao like @xuhao";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@xuhao", SqlDbType.VarChar, 20) };
            param[0].Value = p;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;
        }
        public DataTable chaxun(string xingming, string shenfenzheng, string xuhao)
        {
            string sql = "select * from zm_cjzm where  xingming like @xingming and shenfenzheng like @shenfenzheng and xuhao like @xuhao";
            SqlParameter[] param = new SqlParameter[] 
            { new SqlParameter("@xingming", SqlDbType.VarChar,20),
             new SqlParameter("@shenfenzheng", SqlDbType.VarChar,20),
              new SqlParameter("@xuhao", SqlDbType.VarChar,20)
            };
            param[0].Value = xingming;
            param[1].Value = shenfenzheng;
            param[2].Value = xuhao;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;
        }
        /// <summary>
        /// gengxin
        /// </summary>
        /// <param name="zhanghao"></param>
        /// <param name="mima"></param>
        /// <param name="xmima"></param>
        /// <returns></returns>
        public int updataData(string xuhao, string kaoshenghao, string xingming, string xingbie, string shenfenzheng, string minzu)
        {
            string sql = "update zm_cjzm set xuhao=@xuhao , xingming=@xingming , xingbie=@xingbie , shenfenzheng=@shenfenzheng , minzu=@minzu where kaoshenghao=@kaoshenghao";
            SqlParameter[] param = new SqlParameter[] 
            { new SqlParameter("@xuhao", SqlDbType.VarChar,20),
              new SqlParameter("@xingming", SqlDbType.VarChar,20),
              new SqlParameter("@xingbie", SqlDbType.VarChar,20) ,
              new SqlParameter("@shenfenzheng", SqlDbType.VarChar,20) ,
              new SqlParameter("@minzu", SqlDbType.VarChar,20),
               new SqlParameter("@kaoshenghao", SqlDbType.VarChar,20)
            };
            param[0].Value = xuhao;
            param[1].Value = xingming;
            param[2].Value = xingbie;
            param[3].Value = shenfenzheng;
            param[4].Value = minzu;
            param[5].Value = kaoshenghao;
            int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
            return dt;

        }
        public int shanchu(string kaoshenghao, string xingming, string shenfenzheng)
        {
            string sql = "delete zm_cjzm where kaoshenghao=@kaoshenghao and xingming=@xingming and shenfenzheng=@shenfenzheng";

            SqlParameter[] param = new SqlParameter[] 
            { 
              new SqlParameter("@kaoshenghao", SqlDbType.VarChar,20),
              new SqlParameter("@xingming", SqlDbType.VarChar,20) ,
              new SqlParameter("@shenfenzheng", SqlDbType.VarChar,20)
            };
            param[0].Value = kaoshenghao;
            param[1].Value = xingming;
            param[2].Value = shenfenzheng;
            int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
            return dt;


        }

        public int zengjia(string kaoshenghao, string xingming, string shenfenzheng, string minzu, string xingbie)
        {
            string sql = "insert into zm_cjzm(kaoshenghao, xingming,shenfenzheng,minzu,xingbie)values(@kaoshenghao,@xingming,@shenfenzheng,@minzu,@xingbie)";
            SqlParameter[] param = new SqlParameter[] 
            { 
              new SqlParameter("@kaoshenghao", SqlDbType.VarChar,20),
              new SqlParameter("@xingming", SqlDbType.VarChar,20) ,
              new SqlParameter("@shenfenzheng", SqlDbType.VarChar,20),
              new SqlParameter("@minzu", SqlDbType.VarChar,20) ,
              new SqlParameter("@xingbie", SqlDbType.VarChar,20) 
            
            };
            param[0].Value = kaoshenghao;
            param[1].Value = xingming;
            param[2].Value = shenfenzheng;
            param[3].Value = minzu;
            param[4].Value = xingbie;
            int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
            return dt;
        }
        public DataTable chaxunxuhao(string xuhao, string xingming)
        {
            string sql = "select *from zm_cjzm where xuhao like @xuhao and xingming like @xingming";
            SqlParameter[] param = new SqlParameter[] 
            { 
              new SqlParameter("@xuhao", SqlDbType.VarChar,20),
              new SqlParameter("@xingming", SqlDbType.VarChar,20)
            };
            param[0].Value = xuhao;
            param[1].Value = xingming;
            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;
        }
        public int gengxin(string yuwen, string shuxue, string yingyu, string shengwu, string wuli, string huaxue, string lishi, string dili, string zhengzhi, string kelei, string zongfen, string wenlizong, string xuhao)
        {
            string sql = "update zm_cjzm set kemu1=@yuwen , kemu2=@shuxue , kemu3=@yingyu , kemu4=@shengwu , kemu5=@wuli , kemu6=@huaxue , kemu7=@lishi , kemu8=@dili , kemu9=@zhengzhi , kelei=@kelei , zongfen=@zongfen  , kemu0=@wenlizong where xuhao=@xuhao ";
            SqlParameter[] param = new SqlParameter[] 
            { 
              new SqlParameter("@yuwen", SqlDbType.VarChar,20),
              new SqlParameter("@shuxue", SqlDbType.VarChar,20),
              new SqlParameter("@yingyu", SqlDbType.VarChar,20),
              new SqlParameter("@shengwu", SqlDbType.VarChar,20),
              new SqlParameter("@wuli", SqlDbType.VarChar,20),
              new SqlParameter("@huaxue", SqlDbType.VarChar,20),
              new SqlParameter("@lishi", SqlDbType.VarChar,20),
              new SqlParameter("@dili", SqlDbType.VarChar,20),
              new SqlParameter("@zhengzhi", SqlDbType.VarChar,20),
              new SqlParameter("@kelei", SqlDbType.VarChar,20),
              new SqlParameter("@zongfen", SqlDbType.VarChar,20),
              new SqlParameter("@wenlizong", SqlDbType.VarChar,20),
              new SqlParameter("@xuhao", SqlDbType.VarChar,20)
            };
            param[0].Value = yuwen;
            param[1].Value = shuxue;
            param[2].Value = yingyu;
            param[3].Value = shengwu;
            param[4].Value = wuli;
            param[5].Value = huaxue;
            param[6].Value = lishi;
            param[7].Value = dili;
            param[8].Value = zhengzhi;
            param[9].Value = kelei;
            param[10].Value = zongfen;
            param[11].Value = wenlizong;
            param[12].Value = xuhao;

            int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
            return dt;
        }

        public DataTable xianshi(string xuhao)
        {
            string sql = "select *from zm_cjzm where xuhao=@xuhao ";
            SqlParameter[] param = new SqlParameter[] 
            { 
             
              new SqlParameter("@xuhao", SqlDbType.VarChar,20)
            };

            param[0].Value = xuhao;

            DataTable dt = SQLHelper.ExecuteDt(base.User_Login, sql, param);
            return dt;

        }
        ///// <summary>
        ///// 修改（更新）成绩
        ///// </summary>
        ///// <param name="genxin"></param>
        ///// <returns></returns>
        //public int upData_gengxin(Model.hx_cjzm genxin)
        //{
        //    string sql = "update zm_cjzm set kemu1=@yuwen , kemu2=@shuxue , kemu3=@yingyu , kemu4=@shengwu , kemu5=@wuli , kemu6=@huaxue , kemu7=@lishi , kemu8=@dili , kemu9=@zhengzhi , kelei=@kelei , zongfen=@zongfen  , kemu0=@wenlizong where xuhao=@xuhao; ";
        //    sql = sql + "update zm_cjzm set zongfen=kemu1+kemu2+kemu3+kemu4+kemu5+kemu6+kemu7+kemu8+kemu9+kemu0 where xuhao=@xuhao; ";
        //    SqlParameter[] param = new SqlParameter[] 
        //    { 
        //      new SqlParameter("@yuwen", SqlDbType.VarChar,20),
        //      new SqlParameter("@shuxue", SqlDbType.VarChar,20),
        //      new SqlParameter("@yingyu", SqlDbType.VarChar,20),
        //      new SqlParameter("@shengwu", SqlDbType.VarChar,20),
        //      new SqlParameter("@wuli", SqlDbType.VarChar,20),
        //      new SqlParameter("@huaxue", SqlDbType.VarChar,20),
        //      new SqlParameter("@lishi", SqlDbType.VarChar,20),
        //      new SqlParameter("@dili", SqlDbType.VarChar,20),
        //      new SqlParameter("@zhengzhi", SqlDbType.VarChar,20),
        //      new SqlParameter("@kelei", SqlDbType.VarChar,20),
        //      new SqlParameter("@zongfen", SqlDbType.VarChar,20),
        //      new SqlParameter("@wenlizong", SqlDbType.VarChar,20),
        //      new SqlParameter("@xuhao", SqlDbType.VarChar,20)
        //    };
        //    param[0].Value = genxin.Yuwen;
        //    param[1].Value = genxin.Shuxue;
        //    param[2].Value = genxin.Yingyu;
        //    param[3].Value = genxin.Shengwu;
        //    param[4].Value = genxin.Wuli;
        //    param[5].Value = genxin.Huaxue;
        //    param[6].Value = genxin.Lishi;
        //    param[7].Value = genxin.Dili;
        //    param[8].Value = genxin.Zhengzhi;
        //    param[9].Value = genxin.Kelei;
        //    param[10].Value = genxin.Zongfen;
        //    param[11].Value = genxin.Wenlizong;
        //    param[12].Value = genxin.Xuhao;

        //    int dt = SQLHelper.ExecuteNonQuery(base.User_Login, sql, param);
        //    return dt;

        //}
       
    }
}