using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace AppCommon
{
    public class SQLZhuRu
    {
        //过滤危险字符
        public static string GuoLvString(string str)
        {
            str = str.ToLower();
            str = str.Replace("&", "");
            str = str.Replace("--", "");
            str = str.Replace(" <", "");
            str = str.Replace("> ", "");
            str = str.Replace("'", "");
            str = str.Replace("*", "");
            str = str.Replace("\n", "");
            str = str.Replace("\r\n", "");
            str = str.Replace("?", "");
            str = str.Replace("select", "");
            str = str.Replace("insert", "");
            str = str.Replace("update", "");
            str = str.Replace("delete", "");
            str = str.Replace("create", "");
            str = str.Replace("drop", "");
            str = str.Replace("declare", "");
            str = str.Replace("script", "");
            str = str.Replace("SELECT", "");
            str = str.Replace("INSERT", "");
            str = str.Replace("UPDATE", "");
            str = str.Replace("DELETE", "");
            str = str.Replace("CREATE", "");
            str = str.Replace("DROP", "");
            str = str.Replace("DECLARE", "");
            str = str.Replace("SCRIPT", "");
            str = str.Replace(" ", "");
            str = System.Text.RegularExpressions.Regex.Replace(str, "DECLARE", "EXEC", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            str = str.Trim();
            return str;

        }
        /// <summary>
        /// SQL脚本检测
        /// </summary>
        /// <param name="FormNV">POST：Form键值对</param>
        /// <param name="QueryNV">GET：Query键值对</param>
        /// <returns></returns>
        public bool checksql(NameValueCollection FormNV, NameValueCollection QueryNV)
        {
            string Fy_getIn, Fy_postIn;
            int i;
            bool SqlIn = false;
            Fy_getIn = "#|exec|insert|select|delete|update|%|chr|mid|master|truncate|declare|*|--|'|''|;";//get方法要过滤的
            Fy_postIn = "exec|insert|select|delete|update|master|truncate|declare|--|'|''|;";//post方法要过滤的
            string[] Fy_postInf = Fy_postIn.Split('|');//分离攻击post字符
            string[] Fy_getInf = Fy_getIn.Split('|');//分离攻击get字符
            //=============================post=================
            if (FormNV.Count != 0)
            {
                foreach (string Fy_Post in FormNV.Keys)
                {
                    for (i = 0; i < Fy_postInf.GetUpperBound(0); i++)//判断是否为sql注入单词
                        if (FormNV[Fy_Post].IndexOf(Fy_postInf[i].ToLower()) != -1)
                        {
                            SqlIn = true; break;//POST方法存在SQL关键字
                        }
                }
            }
            //================get====
            if (QueryNV.Count != 0 && !SqlIn)
            {
                foreach (string Fy_Get in QueryNV.Keys)
                {
                    for (i = 0; i < Fy_getInf.GetUpperBound(0); i++)//判断是否为sql注入单词,如果是则保存攻击信息
                        if (QueryNV[Fy_Get].IndexOf(Fy_getInf[i].ToLower()) != -1)
                        {
                            SqlIn = true; break;//GET方法存在SQL关键字
                        }
                }
            }
            return SqlIn;
        }



    }
}
