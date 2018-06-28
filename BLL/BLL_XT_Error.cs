using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class BLL_XT_Error
    {
        protected DAL_XT_Error dError = new DAL_XT_Error();
        /// <summary>
        /// 记录应用系统错误消息
        /// </summary>
        /// <param name="mError">错误实体</param>
        /// <returns>xt_result</returns>
        public xt_result SaveError(IList<xt_error> lError)
        {
            return dError.SaveError(lError);
        }
    }
}
