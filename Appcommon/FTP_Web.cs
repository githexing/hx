using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using model;
using System.Data;

namespace AppCommon
{
    public class FTP_Web
    {
        ///<summary>
        ///上传文件到FTP服务器
        ///</summary>
        ///<param name="pServer">服务器地址</param>
        ///<param name="pUser">FTP用户</param>
        ///<param name="pPass">FTP密码</param>
        ///<param name="oldFile">原文件</param>
        ///<param name="newFile">新文件</param>
        ///<returns></returns>
        public int UploadFile(string pServer,string pUser,string pPass,string oldFile,string newFile)
        {

            
            
            WebClient request = new WebClient();

            string ftpUser = pUser;
            string ftpPassWord = pPass;
            request.Credentials = new NetworkCredential(ftpUser, ftpPassWord);
            
            FileStream myStream = new FileStream(@oldFile, FileMode.Open, FileAccess.Read);
            byte[] dataByte = new byte[myStream.Length];
            myStream.Read(dataByte, 0, dataByte.Length);  //写到2进制数组中
            myStream.Close();
            request.UploadData(pServer + "/" +newFile, dataByte);
            return 1;
        }
         ///<summary>
         ///从FTP服务器下载文件
         ///</summary>
         ///<param name="pServer">服务器地址</param>
         ///<param name="pUser">FTP用户</param>
         ///<param name="pPass">FTP密码</param>
         ///<param name="oldFile">原文件</param>
         ///<param name="newFile">新文件</param>
         ///<returns></returns>
        public int DownLoadFile(string pServer, string pUser, string pPass, string oldFile, string newFile)
        {
            Uri uri = new Uri(pServer+"/"+oldFile);

            WebClient request = new WebClient();

            string ftpUser = pUser;
            string ftpPassWord = pPass;
            request.Credentials = new NetworkCredential(ftpUser, ftpPassWord);

            byte[] newFileData = request.DownloadData(uri.ToString());
            FileStream fs = new FileStream(@newFile, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Write(newFileData, 0, newFileData.Length);
            fs.Close();
            return 1;
        }
        /// <summary>
        /// 列出FTP服务器目录
        /// </summary>
        /// <param name="pUri">FTP 地址</param>
        /// <param name="pUser">FTP 用户</param>
        /// <param name="pPass">FTP 密码</param>
        /// <returns>目录 Table</returns>
        public DataTable ListDirectoryDetails(string pUri,string pUser,string pPass)
        {
            DataTable dt = new DataTable();
            if (pUri.Equals("none"))
                return dt;

            FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(pUri);

            listRequest.Credentials = new NetworkCredential(pUser, pPass);
            listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse();
            Stream responseStream = listResponse.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, System.Text.Encoding.Default);

            string dataString = readStream.ReadToEnd();
            listResponse.Close();
            responseStream.Close();
            readStream.Close();

            DirectoryListParser parser = new DirectoryListParser(dataString);
            FileStruct[] fs = parser.FullListing;
            

            dt.Columns.Add("Name",typeof(string));
            dt.Columns.Add("Flags",typeof(string));
            dt.Columns.Add("CreateTime",typeof(string));
            dt.Columns.Add("IsDirectory", typeof(string));
            dt.Columns.Add("Url",typeof(string));
            foreach(FileStruct dir in fs )
            {
                DataRow row = dt.NewRow();
                row["Name"] = dir.Name;
                row["Flags"] = dir.Flags;
                row["CreateTime"] = dir.CreateTime;
                row["IsDirectory"] = dir.IsDirectory;
                if (dir.IsDirectory)
                    row["Url"] = "";
                else
                    row["Url"] = "ftp://" + pUser + ":" + pPass + "@"+pUri.Substring(6)+"/" + dir.Name;
                dt.Rows.Add(row);
            }
            return dt;
        }
        /// <summary>
        /// 显示欢迎
        /// </summary>
        /// <param name="pUri">FTP 地址</param>
        /// <param name="pUser">FTP 用户</param>
        /// <param name="pPass">FTP 密码</param>
        /// <returns></returns>
        public DataTable WelcomeMessage(string pUri, string pUser, string pPass)
        {
            DataTable dt = new DataTable();
            if (pUri.Equals("none"))
                return dt;

            FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(pUri);
            listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            listRequest.Credentials = new NetworkCredential(pUser, pPass);
            FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse();
            
            dt.Columns.Add("Name",typeof(string));
            DataRow row0 = dt.NewRow(); 
            row0["name"] = listResponse.ResponseUri;
            dt.Rows.Add(row0);
            DataRow row1 = dt.NewRow();
            row1["name"] = listResponse.StatusCode;
            dt.Rows.Add(row1);
            DataRow row2 = dt.NewRow();
            row2["name"] = listResponse.StatusDescription;
            dt.Rows.Add(row2);
            DataRow row3 = dt.NewRow();
            row3["name"] = listResponse.BannerMessage;
            dt.Rows.Add(row3);
            DataRow row4 = dt.NewRow();
            row4["name"] = listResponse.WelcomeMessage;
            dt.Rows.Add(row4);

            return dt;

        }
    }
}
