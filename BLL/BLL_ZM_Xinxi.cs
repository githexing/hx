using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AppCommon;
using DBUtility;
using Model;
using DAL;
namespace BLL
{
   public  class BLL_ZM_Xinxi
    {
       DAL_ZM_Xinxi Xinxi=new DAL_ZM_Xinxi();
          /// <summary>
        /// 信息
        /// </summary>
        /// <param name="yonghu"></param>
        /// <param name="mima"></param>
        /// <param name="xingming"></param>
        /// <param name="dizhi"></param>
        /// <param name="dianhua"></param>
        /// <param name="youjian"></param>
        /// <returns></returns>
       public int zengjia(string shenfenzheng, string xingming, string xingbie, string dizhi, string daxue, string zhongxue, string shouji)
       {
           return Xinxi.zengjia(shenfenzheng ,xingming,xingbie,dizhi,daxue,zhongxue,shouji);
       }
           /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="yonghu"></param>
        /// <param name="mima"></param>
        /// <param name="mima1"></param>
        /// <returns></returns>
       public int UpdataData(string shenfenzheng, string xingming, string xingbie, string dizhi, string daxue, string zhongxue, string shouji)
       {
           return Xinxi.UpdataData(shenfenzheng, xingming,xingbie,  dizhi, daxue, zhongxue, shouji);
       }
           /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
       public DataTable getData(string yonghu)
       {
           return Xinxi.getData(yonghu);
       }
    }
}
