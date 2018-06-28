using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using DAL;

namespace BLL
{
    public class BLL_ZM_Zuce : DBUserConfig.UserLogin
    {
        DAL_ZM_Zuce Zuce = new DAL_ZM_Zuce();
          /// <summary>
        /// 注册
        /// </summary>
        /// <param name="yonghu"></param>
        /// <param name="mima"></param>
        /// <param name="xingming"></param>
        /// <param name="dizhi"></param>
        /// <param name="dianhua"></param>
        /// <param name="youjian"></param>
        /// <returns></returns>
        public int zengjia(string yonghu, string mima, string xingming, string dizhi, string dianhua, string youjian ,string daihao,string shenfenzheng)
        {
            return Zuce.zengjia(yonghu, mima, xingming, dizhi, dianhua, youjian,daihao ,shenfenzheng);
        }
         /// <summary>
        ///  查询账户
        /// </summary>
        /// <param name="yonghu"></param>
        /// <param name="mima"></param>
        /// <returns></returns>
        public DataTable getData(string yonghu, string mima)
        {
            return Zuce.getData(yonghu, mima);

        }
        public DataTable getData1(string yonghu, string pWhere)
        {
            return Zuce.getData1(yonghu, pWhere);
        }
        /// <summary>
        ///  查询账户
        /// </summary>
        /// <param name="yonghu"></param>
        /// <param name="mima"></param>
        /// <returns></returns>
        public DataTable getData(string yonghu)
        {
            return Zuce.getData(yonghu);
        }
         /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="yonghu"></param>
        /// <param name="mima"></param>
        /// <param name="mima1"></param>
        /// <returns></returns>
        public int UpdataData(string yonghu, string mima, string mima1)
        {
            return Zuce.UpdataData(yonghu, mima, mima1);
        }


    }
}
