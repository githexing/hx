using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using AppCommon;
using BLL;
using Model;


namespace WebApplication1.App_Code
{
    // Create our own utility for exceptions
    public sealed class ExceptionUtility
    {
        // All methods are static, so this can be private
        private ExceptionUtility()
        { }
        // Log an Exception
        /// <summary>
        /// 记录错误日志到文本
        /// </summary>
        /// <param name="exc">错误实体</param>
        /// <param name="source">错误源</param>
        public static void LogException(Exception exc, string source)
        {
            // Include enterprise logic for logging exceptions
            // Get the absolute path to the log file
            string logFile = "App_Data/ErrorLog.txt";
            logFile = HttpContext.Current.Server.MapPath(logFile);

            // Open the log file for append and write the log
            StreamWriter sw = new StreamWriter(logFile, true);
            sw.Write("******************** " + DateTime.Now);
            sw.WriteLine(" ********************");
            if (exc.InnerException != null)
            {
                sw.Write("Inner Exception Type: ");
                sw.WriteLine(exc.InnerException.GetType().ToString());
                sw.Write("Inner Exception: ");
                sw.WriteLine(exc.InnerException.Message);
                sw.Write("Inner Source: ");
                sw.WriteLine(exc.InnerException.Source);
                if (exc.InnerException.StackTrace != null)
                    sw.WriteLine("Inner Stack Trace: ");
                sw.WriteLine(exc.InnerException.StackTrace);
            }
            sw.Write("Exception Type: ");
            sw.WriteLine(exc.GetType().ToString());
            sw.WriteLine("Exception: " + exc.Message);
            sw.WriteLine("Source: " + source);
            sw.WriteLine("Stack Trace: ");
            if (exc.StackTrace != null)
                sw.WriteLine(exc.StackTrace);
            sw.WriteLine();
            sw.Close();
        }

        // Notify System Operators about an exception
        /// <summary>
        /// 通知系统管理员关于错误消息
        /// </summary>
        /// <param name="exc"></param>
        public static void NotifySystemOps(Exception exc, string pSource)
        {
            //发件人邮箱地址
            MailAddress MessageFrom = new MailAddress("linshubo@163.com");
            //收件人邮箱地址
            string MessageTo = "linshubo@163.com";
            //邮件主题
            string MessageSubject = "Error：" + pSource + "_" + DateTime.Now.ToString();
            //邮件内容
            string MessageBody = "系统出错啦：\r\n  ";
            if (exc.InnerException != null)
            {
                MessageBody = MessageBody + "Inner Exception Type: " + exc.InnerException.GetType().ToString() + "\r\n  ";
                MessageBody = MessageBody + "Inner Exception: " + exc.InnerException.Message + "\r\n  ";
                MessageBody = MessageBody + "Inner Source: " + exc.InnerException.Source + "\r\n  ";
                if (exc.InnerException.StackTrace != null)
                {
                    MessageBody = MessageBody + "Inner Stack Trace: " + exc.InnerException.StackTrace + "\r\n  ";
                }
            }
            MessageBody = MessageBody + "Exception Type: " + exc.GetType().ToString() + "\r\n  ";
            MessageBody = MessageBody + "Exception: " + exc.Message + "\r\n  ";
            MessageBody = MessageBody + "Source: " + pSource + "\r\n  ";
            if (exc.StackTrace != null)
            {
                MessageBody = MessageBody + "Stack Trace: " + exc.StackTrace;
            }
            MyEmail.Send(MessageFrom, MessageTo, MessageSubject, MessageBody);
        }
        /// <summary>
        /// 记录到数据库
        /// </summary>
        /// <param name="exc">错误消息</param>
        /// <param name="source">错误源</param>
        public static void DatabaseException(Exception exc, string source)
        {
            xt_error mError = new xt_error();
            IList<xt_error> lError = new List<xt_error>();
            
            mError.Application = source;
            mError.Message = "****" + DateTime.Now.ToString() + "****";
            lError = AddError(lError,mError);
            if (exc.InnerException != null)
            {
                mError.Message = "Inner Exception Type: " + exc.InnerException.GetType().ToString();
                lError = AddError(lError, mError);
                mError.Message = "Inner Exception: " + exc.InnerException.Message;
                lError = AddError(lError, mError);
                mError.Message = "Inner Source: " + exc.InnerException.Source;
                lError = AddError(lError, mError);
                if (exc.InnerException.StackTrace != null)
                {
                    mError.Message = "Inner Stack Trace: " + exc.InnerException.StackTrace;
                    lError = AddError(lError, mError);

                }
            }
            mError.Message = "Exception Type: " + exc.GetType().ToString();
            lError = AddError(lError, mError);
            mError.Message = "Exception: " + exc.Message;
            lError = AddError(lError, mError);
            mError.Message = "Source: " + source;
            lError = AddError(lError, mError);
            if (exc.StackTrace != null)
            {
                mError.Message = "Stack Trace: "+exc.StackTrace;
                lError = AddError(lError, mError);
            }
            BLL_XT_Error bError = new BLL_XT_Error();
            bError.SaveError(lError);
        }
        /// <summary>
        /// 错误列表
        /// </summary>
        /// <param name="lError">错误列表</param>
        /// <param name="mError">错误实体</param>
        /// <returns>错误列表</returns>
        public static IList<xt_error> AddError(IList<xt_error> lError, xt_error mError)
        {
            mError.Message = mError.Message.Replace("'","");
            string[] pMessage = Regex.Split(mError.Message, "\r\n   ");
            int j = pMessage.Length;
            for (int i = 0; i < j; i++)
            {
                xt_error pError = new xt_error();

                pError.Application = mError.Application;
                pError.Message = pMessage[i];
                lError.Add(pError);
            }
            return lError;
        }
    }
}
