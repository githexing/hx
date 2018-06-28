using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;
using DAL;
using DBUserConfig;

namespace BLL
{
    public class hx_yonghu : DBUserConfig.UserLogin
    {
        DAL.hx_yonghu ayonghu = new DAL.hx_yonghu();

        /// <summary>
        /// selectData
        /// </summary>
        /// <param name="pzh"></param>
        /// <param name="pmm"></param>
        /// <returns></returns>
        public DataTable selectData(string zhanghao, string mima)
        {
            return ayonghu.selectData(zhanghao, mima);
        }
        /// <summary>
        /// updataDtat
        /// </summary>
        /// <param name="zhanghao"></param>
        /// <param name="mima"></param>
        /// <param name="xmima"></param>
        /// <returns></returns>
        public int updataData(string zhanghao, string mima, string xmima)
        {
            return ayonghu.updataData(zhanghao, xmima, mima);
        }
        ///// <summary>
        ///// 提交
        ///// </summary>
        ///// <param name="?"></param>
        ///// <returns></returns>
        //public int tijiao(Model.hx_neirong aaa)
        //{
        //    return ayonghu.tijiao (aaa);
        //}
    }
}