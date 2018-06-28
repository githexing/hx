using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;
namespace BLL
{
   public class BLL_Yonghu
    {
       DAL_Yonghu dyonghu=new DAL_Yonghu();
         /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
       public DataTable getData()
       {
           return dyonghu.getData();
       }
       /// <summary>
       /// 查询
       /// </summary>
       /// <returns></returns>
       public DataTable getData9(string a)
       {
           return dyonghu.getData9(a);
       }
       /// <summary>
       /// 查询
       /// </summary>
       /// <returns></returns>
       public DataTable getData1()
       {
           return dyonghu.getData1();
       }
         /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
       public DataTable getData2(string s)
       {
           return dyonghu.getData2(s);
       }
       public DataTable getData3(string d, string m, string r, string b)
       {
           return dyonghu.getData3(d,m,r,b);
       }

       public DataTable getData4(string a)
       {
           return dyonghu.getData4(a);
       }
       public DataTable getData5(string a)
       {
           return dyonghu.getData5(a);
       }
         /// <summary>
        /// 更新参数值
        /// </summary>
        /// <param name="pDaihao">参数名</param>
        /// <param name="pCanshu">参数值</param>
        /// <returns>返回影响行数</returns>
       public xt_result Update_Canshu(string pDaihao, string pCanshu)
       {
           return dyonghu.Update_Canshu(pDaihao, pCanshu);
       }
    }
}
