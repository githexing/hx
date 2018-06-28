using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using model;
using System.Data;
using DAL;
namespace BLL
{
    public class BLL_zm_cjzm1 : DBUserConfig.UserLogin
    {
        DAL.zm_cjzm cjzm = new DAL.zm_cjzm();
        /// <summary>
        /// getDate
        /// </summary>
        /// <param name="xingming"></param>
        /// <param name="shenfenzheng"></param>
        /// <returns></returns>
        public DataTable getDate(string xingming, string shenfenzheng)
        {
            return cjzm.getDate(xingming, shenfenzheng);
        }
        /// <summary>
        /// getallDate
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public DataTable getallDate(string p)
        {
            return cjzm.getalldate(p);
        }
        /// <summary>
        /// chaxun
        /// </summary>
        /// <param name="xingming"></param>
        /// <param name="shenfenzheng"></param>
        /// <param name="xuhao"></param>
        /// <returns></returns>
        public DataTable chaxun(string xingming, string shenfenzheng, string xuhao)
        {
            return cjzm.chaxun(xingming, shenfenzheng, xuhao);
        }
        /// <summary>
        /// updataData
        /// </summary>
        /// <param name="xuhao"></param>
        /// <param name="kaoshenghao"></param>
        /// <param name="xingming"></param>
        /// <param name="xinbie"></param>
        /// <param name="shenfenzheng"></param>
        /// <param name="mingzu"></param>
        /// <returns></returns>
        public int updataData(string xuhao, string kaoshenghao, string xingming, string xingbie, string shenfenzheng, string minzu)
        {
            return cjzm.updataData(xuhao, kaoshenghao, xingming, xingbie, shenfenzheng, minzu);
        }
        /// <summary>
        /// shanchu
        /// </summary>
        /// <param name="kaoshenghao"></param>
        /// <param name="xingming"></param>
        /// <param name="shenfenzheng"></param>
        /// <returns></returns>
        public int shanchu(string kaoshenghao, string xingming, string shenfenzheng)
        {
            return cjzm.shanchu(kaoshenghao, xingming, shenfenzheng);
        }
        /// <summary>
        /// zengjia
        /// </summary>
        /// <param name="kaoshenghao"></param>
        /// <param name="xingming"></param>
        /// <param name="shenfenzheng"></param>
        /// <param name="minzu"></param>
        /// <param name="xingbie"></param>
        /// <returns></returns>
        public int zengjia(string kaoshenghao, string xingming, string shenfenzheng, string minzu, string xingbie)
        {
            return cjzm.zengjia(kaoshenghao, xingming, shenfenzheng, minzu, xingbie);


        }
        /// <summary>
        /// chaxunxuhao
        /// </summary>
        /// <param name="xuhao"></param>
        /// <param name="xingming"></param>
        /// <returns></returns>
        public DataTable chaxunxuhao(string xuhao, string xingming)
        {
            return cjzm.chaxunxuhao(xuhao, xingming);


        }
        ///// <summary>
        ///// 修改（更新）成绩
        ///// </summary>
        ///// <param name="genxin"></param>
        ///// <returns></returns>
        //public int upData_gengxin(Model.hx_cjzm genxin)
        //{
        //    return cjzm.upData_gengxin(genxin);
        //}
        /// <summary>
        /// GV显示3
        /// </summary>
        /// <param name="xuhao"></param>
        /// <returns></returns>
       
        public DataTable xianshi(string xuhao)
        {
            return cjzm.xianshi(xuhao);
        }
        
        
        
        
        }
}
