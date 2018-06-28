using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;
using DBUtility;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_Procedure : DBUserConfig.UserLogin
    {
        /// <summary>
        /// 导入名册
        /// </summary>
        /// <param name="pYonghu"></param>
        /// <param name="pBiaozhi"></param>
        /// <returns></returns>
        public xt_result ImportMingce(string pYonghu, string pBiaozhi, string pProcedure,string path)
        {
            SqlParameter[] param = new SqlParameter[] {  new SqlParameter("@yonghu", SqlDbType.VarChar,20),
                                                         new SqlParameter("@biaozhi", SqlDbType.VarChar,2),
                                                         new SqlParameter("@path", SqlDbType.VarChar,100),
                                                         new SqlParameter("@ReturnValue", SqlDbType.Int) };
            param[0].Value = pYonghu;
            param[1].Value = pBiaozhi;
            param[2].Value = path;
            param[3].Direction = ParameterDirection.ReturnValue;

            xt_result result = new xt_result();
            switch (pProcedure)
            {

                case "pro_daoru_kaochangmingce_01":
                    result.Message = "导入考场临时表成功";
                    break;
                case "pro_daoru_kaochangmingce_02":
                    result.Message = "导入考场信息成功";
                    break;
                case "pro_daoru_chengji_01":
                    result.Message = "导入新生成绩临时表成功";
                    break;
                case "pro_daoru_chengji_02":
                    result.Message = "生成新生成绩库成功";
                    break;
                case "pro_daoru_mingce_01":
                    result.Message = "导入新生名册临时表成功";
                    break;
                case "pro_daoru_mingce_02":
                    result.Message = "生成新生名册库成功";
                    break;

                case "pro_daoru_jiaofei_01":
                    result.Message = "导入缴费清单临时表成功";
                    break;
                case "pro_daoru_jiaofei_02":
                    result.Message = "生成缴费清单库成功";
                    break;

                case "pro_daoru_kaoshizhuanye_01":
                    result.Message = "导入考试专业临时表成功";
                    break;
                case "pro_daoru_kaoshizhuanye_02":
                    result.Message = "生成考试专业库成功";
                    break;
                case "pro_daoru_kaodian_01":
                    result.Message = "导入考点临时表成功";
                    break;
                case "pro_daoru_kaodian_02":
                    result.Message = "生成考点库成功";
                    break;
                case "pro_daoru_kaikaozhuanye_01":
                    result.Message = "导入开考专业成功";
                    break;
                case "pro_daoru_kaikaozhuanye_02":
                    result.Message = "生成开考专业成功";
                    break;

                case "pro_daoru_bmxxShenhe_01":
                    result.Message = "导入统考审核临时表成功";
                    break;
                case "pro_daoru_bmxxShenhe_02":
                    result.Message = "生成统考审核结果成功";
                    break;



            }
            try
            {
                result.ReturnInt = SQLHelper.ExecuteNonQuery(base.User_Login, CommandType.StoredProcedure, pProcedure, param);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Message = result.Message.Replace("\r\n", "\\n");
                result.Message = result.Message.Replace("'", "");
            }
            if (param[3].Value == null)
                result.ReturnValue = -99;
            else
                result.ReturnValue = (int)param[3].Value;

            switch (result.ReturnValue)
            {
                case -1:
                    switch (pProcedure)
                    {
                        case "pro_daoru_jiaofei_02":
                            result.Message = "更新缴费金额失败";
                            break;
                    }
                    break;
            }

            return result;
        }
        /// <summary>
        /// ceshi1
        /// </summary>
        /// <param name="pProcedure"></param>
        /// <returns></returns>
           public DataSet ceshi1(string pProcedure)
           {
                      return SQLHelper.ExecuteDs(base.User_Admin, CommandType.StoredProcedure, "ceshi1", 10000, null);
            }

    }
}
