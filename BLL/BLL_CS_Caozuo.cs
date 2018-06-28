using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using DAL;
namespace BLL
{
    public class BLL_CS_Caozuo : DBUserConfig.UserLogin
    {
        DAL.DAL_CS_Caozuo yonghu = new DAL_CS_Caozuo();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public DataTable chaxun(string p)
        {
            return yonghu.chaxun(p);
        }
        public DataTable aa(string p)
        {
            return yonghu.aa(p);
        }
        public int qq(string xingming, string shijian)
        {
            return yonghu.qq(xingming ,shijian );
        }
    }
}
