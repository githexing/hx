using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Model;
namespace BLL
{
   public class BLL_Caidan
    {
       protected DAL_Caidan dCaidan = new DAL_Caidan();
       /// <summary>
       /// 用户菜单
       /// </summary>
       /// <param name="pYingyong"></param>
       /// <returns></returns>
       public DataTable getData(string pYingyong)
       {
           return dCaidan.getData(pYingyong);
       }
       /// <summary>
       /// 查询用户菜单
       /// </summary>
       /// <param name="daihao"></param>
       /// <returns></returns>
       public DataTable getCaidan(string pYingyong, string pYonghu)
       {
           return dCaidan.getCaidan(pYingyong, pYonghu);
       }
       /// <summary>
       /// 按应用查询
       /// </summary>
       /// <param name="pYingyong"></param>
       /// <returns></returns>
       public DataTable  getYingyong(string pYingyong)
       {
           return dCaidan.getYingyong(pYingyong);
       }
       public DataTable getGongneng()
       {
           return dCaidan.getGongneng();
       }
       /// <summary>
       /// 插入菜单
       /// </summary>
       /// <param name="mCaidan"></param>
       /// <returns></returns>
       public xt_result getCharucaidan(caidan mCaidan, string pDaihao)
       {
           return dCaidan.getCharucaidan(mCaidan, pDaihao);
       }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
       public xt_result getShanchucaidan(caidan mCaidan)
       {
           return dCaidan.getShanchucaidan(mCaidan);
       }
        /// <summary>
       /// 更新菜单
       /// </summary>
       /// <param name="mCaidan"></param>
       /// <returns></returns>
       public xt_result getGengaicaidan(caidan mCaidan)
       {
           return dCaidan.getGengaicaidan(mCaidan);
       }
        /// <summary>
        /// 按条件提取数据
        /// </summary>
        /// <param name="pWhere"></param>
        /// <param name="pData"></param>
        /// <returns></returns>
       public DataTable getDataWhere(string pWhere, string pData)
       {
           return dCaidan.getDataWhere(pWhere, pData);
       }
    }
}
