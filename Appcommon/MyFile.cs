using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace AppCommon
{
    public class MyFile
    {
        #region 拷贝文件 
        /**************************************** 
        * 函数名称：FileCoppy 
        * 功能说明：拷贝文件 
        * 参 数：OrignFile:原始文件,NewFile:新文件路径 
        * 调用示列： 
        * string orignFile = Server.MapPath("Default2.aspx"); 
        * string NewFile = Server.MapPath("Default3.aspx"); 
        * EC.FileObj.FileCoppy(OrignFile, NewFile); 
        *****************************************/ 
        /// <summary> 
        /// 拷贝文件 
        /// </summary> 
        /// <param name="OrignFile">原始文件</param> 
        /// <param name="NewFile">新文件路径</param> 
        public static void FileCoppy(string orignFile, string newFile) 
        { 
              File.Copy(orignFile, newFile, true); 
        }
        #endregion
        #region 获取文件列表
        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <param name="pDir">完整路径</param>
        /// <param name="pExt">扩展名， .*</param>
        /// <returns>返回 DataTable</returns>
        public static DataTable GetFileList(string pDir, string pExt)
        {
            pExt = pExt.ToLower();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Extension", typeof(string));
            dt.Columns.Add("Length", typeof(int));
            dt.Columns.Add("LastWriteTime", typeof(DateTime));
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("DirectoryName", typeof(string));
            dt = getList(pDir, pExt, dt);
            return dt;

        }
        /// <summary>
        /// 文件列表
        /// </summary>
        /// <param name="pDir"></param>
        /// <param name="pExt"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected static DataTable getList(string pDir, string pExt,DataTable dt)
        {
            if (Directory.Exists(Path.GetDirectoryName(pDir)))
            {
                FileInfo fi;
                DirectoryInfo dir;
                DirectoryInfo dirInfo = new DirectoryInfo(pDir);
                foreach (FileSystemInfo fsi in dirInfo.GetFileSystemInfos())
                {
                    DataRow dr = dt.NewRow();
                    ///如果是文件
                    if (fsi is FileInfo)
                    {
                        fi = (FileInfo)fsi;
                        dr["Name"] = fi.Name;
                        dr["Extension"] = fi.Extension;
                        dr["Length"] = fi.Length;
                        dr["LastWriteTime"] = fi.LastWriteTime;
                        dr["FullName"] = fi.FullName;
                        dr["DirectoryName"] = fi.DirectoryName;
                        if (pExt == "*.*")
                        {
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            if (fi.Extension.ToLower().Equals(pExt))
                            {
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                    ///否则是目录
                    else
                    {
                        dir = (DirectoryInfo)fsi;
                        dr["Name"] = dir.Name;
                        dr["Extension"] = "";
                        dr["Length"] = 0;
                        dr["LastWriteTime"] = dir.LastWriteTime;
                        dr["FullName"] = dir.FullName;
                        dr["DirectoryName"] = dir.FullName;
                        dt = getList(dir.FullName, pExt, dt);
                    }
                }
            }
            return dt;
        }
        #endregion 



    }
}
