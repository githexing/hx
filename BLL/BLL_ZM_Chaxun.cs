using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using model;
using System.Data;
using DAL;

namespace BLL
{
    public class BLL_ZM_Chaxun : DBUserConfig.UserLogin
    {
        DAL_ZM_Chaxun Chaxun = new DAL_ZM_Chaxun();
         /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
       public DataTable getData()
       {
           return Chaxun.getData();
       }
           /// <summary>
        /// 选择查询
        /// </summary>
        /// <param name="pWhere"></param>
        /// <returns></returns>
       public DataTable selectData(string pWhere, string pData)
       {
           return Chaxun.selectData(pWhere, pData);
       }
    }
}
