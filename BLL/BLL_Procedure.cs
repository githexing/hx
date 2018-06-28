using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class BLL_Procedure
    {
        protected DAL_Procedure dProcedure = new DAL_Procedure();
        /// <summary>
        /// 导入新生名册
        /// </summary>
        /// <param name="pYonghu"></param>
        /// <param name="pBiaozhi"></param>
        /// <returns></returns>
        public xt_result ImportMingce(string pYonghu, string pBiaozhi, string pProcedure, string path)
        {
            return dProcedure.ImportMingce(pYonghu, pBiaozhi, pProcedure, path);
        }
         /// <summary>
        /// ceshi1
        /// </summary>
        /// <param name="pProcedure"></param>
        /// <returns></returns>
        public DataSet ceshi1(string pProcedure)
        {
            return dProcedure.ceshi1(pProcedure);
        }
    }
}
