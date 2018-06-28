using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using DAL;
namespace BLL
{
   public  class BLL_Gongneng : DBUserConfig.UserLogin
    {
        DAL_Gongneng bGongneng = new DAL_Gongneng();
         /// <summary>
        /// 查询应用
        /// </summary>
        /// <returns></returns>
        public DataTable chaxun()
        {
            return bGongneng.chaxun();
        }
        /// <summary>
        /// 用户菜单
        /// </summary>
        /// <param name="pYingyong"></param>
        /// <returns></returns>
        public DataTable getDataCaidan(string pYingyong)
        {
            return bGongneng.getDataCaidan(pYingyong);
        }
       /// <summary>
        /// 查询应用
        /// </summary>
        /// <returns></returns>
        public DataTable getChaxun( string pZubie)
        {
            return bGongneng.getChaxun(pZubie);
        }
        /// <summary>
        /// 查询应用
        /// </summary>
        /// <returns></returns>
        public DataTable chaxun(string Table)
        {
            return bGongneng.chaxun(Table);
        }
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="mGongneng"></param>
        /// <returns></returns>
        public xt_result DelGongneng(gongneng mGongneng)
        {
            return bGongneng.DelGongneng(mGongneng);
        }
        /// <summary>
        /// 插入功能
        /// </summary>
        /// <param name="mXt_gongneng"></param>
        /// <returns></returns>
        public xt_result InsertGongneng(gongneng mGongneng)
        {
            return bGongneng.InsertGongneng(mGongneng);
        }
        /// <summary>
        /// 获取用户功能
        /// </summary>
        /// <param name="pYonghu">用户代号</param>
        /// <param name="pBianhao">菜单编号</param>
        /// <returns>DataTable</returns>
        public DataTable getGongneng_Bianhao(gongneng mGongneng)
        {
            return bGongneng.getGongneng_Bianhao(mGongneng);
        }
        /// <summary>
        /// 获取用户功能菜单
        /// </summary>
        /// <param name="pYonghu">用户代号</param>
        /// <param name="pCanshu">参数</param>
        /// <returns>返回DataTable</returns>
        public DataTable getGongneng_Yonghu(gongneng mGongneng)
        {
            return bGongneng.getGongneng_Yonghu(mGongneng);
        }
    }
}
