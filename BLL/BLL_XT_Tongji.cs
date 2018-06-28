using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;
namespace BLL
{
   public  class BLL_XT_Tongji
    {
      protected DAL_XT_Tongji Tongji = new DAL_XT_Tongji();
       /// <summary>
       /// 查询xt_tongji表数据
       /// </summary>
       /// <returns></returns>
      public DataTable getData()
      {
          return Tongji.getData();
      }
       /// <summary>
        /// 更新xt_tongji中的人数
        /// </summary>
        /// <param name="renshu"></param>
        /// <returns></returns>
      public xt_result UpData(int renshu)
      {
          return Tongji.UpData(renshu);
      }

    }
}
