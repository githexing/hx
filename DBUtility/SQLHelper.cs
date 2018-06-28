using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace DBUtility
{
    public class SQLHelper
    {
        // Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        #region 通用方法
        /// <summary>
        /// 返回数据库连接
        /// </summary>
        /// <returns>string,连接字符串</returns>
        public static string GetSqlConnectionString()
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["MSSQLConnectionString"].ToString();
            return conn;
        }
        #endregion
        #region 执行sql字符串
        /// <summary>
        /// 执行SqlCommand.ExecuteNonQuery()
        /// </summary>
        /// <param name="connstr">连接串</param>
        /// <param name="cmdText">数据库命令(字符串)</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>影响行数:大于等于1,成功；小于等于0,失败</returns>
        public static int ExecuteNonQuery(string connstr, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = CreateConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, connection, null, CommandType.Text, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 执行SqlCommand.ExecuteNonQuery()
        /// </summary>
        /// <param name="connstr">连接串</param>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>影响行数:大于等于1,成功；小于等于0,失败</returns>
        public static int ExecuteNonQuery(string connstr,CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = CreateConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 执行SqlCommand.ExecuteNonQuery()
        /// </summary>
        /// <param name="connstr">连接串</param>
        /// <param name="cmdTimeOut">连接超时，秒，长时间操作的任务应设置此参数</param>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>影响行数:大于等于1,成功；小于等于0,失败</returns>
        public static int ExecuteNonQuery(string connstr,int cmdTimeOut, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = CreateConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = cmdTimeOut;

                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 执行SqlCommand.ExecuteNonQuery()
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>影响行数:大于等于1,成功；小于等于0,失败</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="trans">SqlTransaction对象</param>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>影响行数:大于等于1,成功；小于等于0,失败</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        /// <summary>
        /// 执行SqlCommand.ExecuteScalar()
        /// </summary>
        /// <param name="connstr">连接串</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(string connstr, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlConnection connection = CreateConnection(connstr);
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, CommandType.Text, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            connection.Close();
            cmd.Parameters.Clear();
            return val;
        }
        /// <summary>
        /// 执行SqlCommand.ExecuteScalar()
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(string connstr,CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlConnection connection = CreateConnection(connstr);
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            connection.Close();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 执行SqlCommand.ExecuteScalar()
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            connection.Close();
            cmd.Parameters.Clear();
            return val;
        }
        /// <summary>
        /// 执行SqlCommand.ExecuteReader。注意要关闭SqlDataReader
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">SqlParameter[],参数对象数组</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string connstr, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connstr);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        /// <summary>
        /// 执行SqlCommand.ExecuteReader。注意要关闭SqlDataReader
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">SqlParameter[],参数对象数组</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string connstr,CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connstr);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of SqlParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }
        /// <summary>
        /// 用SqlDataAdapter填充DataTable
        /// </summary>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDt(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.Parameters.Clear();
                return dt;
            }
        }
        /// <summary>
        /// 用SqlDataAdapter填充DataTable
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDt(string connstr, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = CreateConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, connection, null, CommandType.Text, cmdText, commandParameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.Parameters.Clear();
                return dt;
            }
        }
        /// <summary>
        /// 用SqlDataAdapter填充DataTable
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDt(string connstr,CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = CreateConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.Parameters.Clear();
                return dt;
            }
        }
        /// <summary>
        /// 用SqlDataAdapter填充DataSet
        /// </summary>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDs(string connstr, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = CreateConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, connection, null, CommandType.Text, cmdText, commandParameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }
        /// <summary>
        /// 用SqlDataAdapter填充DataSet
        /// </summary>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDs(string connstr,CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = CreateConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }
        /// <summary>
        /// 用SqlDataAdapter填充DataSet
        /// </summary>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDs(string connstr, CommandType cmdType, string cmdText,int timeOut, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = CreateConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

                cmd.CommandTimeout = timeOut;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }
        /// <summary>
        /// 用SqlDataAdapter填充DataSet
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="cmdType">数据库命令类型</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDs(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }

        /// <summary>
        /// 操作SqlCommand
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <param name="conn">SqlConnection</param>
        /// <param name="trans">SqlTransaction</param>
        /// <param name="cmdType">CommandType</param>
        /// <param name="cmdText">数据库命令</param>
        /// <param name="cmdParms">SqlParameter</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        public static SqlConnection CreateConnection(string connstr)
        {
            SqlConnection conn = new SqlConnection(connstr);
            return conn;
        }


        /// <summary>
        /// 用SqlDataAdapter批量更新单个表的数据
        /// </summary>
        /// <param name="cmdText">要更新表的查询语句</param>
        /// <param name="liststr">要更新的数据用，分隔</param>
        /// <param name="fields">要更新的字段</param>
        /// <returns>整数</returns>
        public static int BatchUpdata( string connstr, string cmdText, ArrayList liststr, ArrayList fields)
        {
            try
            {
                using (SqlConnection connection = CreateConnection(connstr))
                {
                    SqlCommand cmd = new SqlCommand(cmdText, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < liststr.Count; i++)
                    {
                        string str = liststr[i].ToString();
                        string[] strarry = str.Split(',');

                        for (int j = 0; j < fields.Count; j++)
                        {

                            Type t = dt.Rows[i][fields[j].ToString()].GetType();
                            string converstr = strarry[j].ToString();
                            object ostr = new object();


                            ostr = (object)converstr;
                            dt.Rows[i][fields[j].ToString()] = ostr;


                        }
                    }
                    SqlCommandBuilder scb = new SqlCommandBuilder(da);
                    da.Update(dt.GetChanges());
                    dt.AcceptChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {
               
                return -1;
            }
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="connstr">连接字符串</param>
        /// <param name="insertText">插入语句</param>
        /// <param name="liststr">待插入数据</param>
        /// <param name="commandParameters">自定义的parameters</param>
        /// <returns></returns>
        public static int BatchInsert(string connstr, string insertText, ArrayList liststr, SqlParameter[] commandParameters)
        {
            try
            {
                using (SqlConnection connection = CreateConnection(connstr))
                {

                    //   SqlCommand cmd = new SqlCommand(cmdText, connection);
                    SqlDataAdapter da = new SqlDataAdapter();
                    //  da.SelectCommand = new SqlCommand(selectText, conn);

                    da.InsertCommand = new SqlCommand(insertText, connection);
                    PrepareCommand(da.InsertCommand, connection, null, CommandType.Text, insertText, commandParameters);
                    DataTable dt = new DataTable();
                    for (int i = 0; i < commandParameters.Length; i++)
                    {
                        System.Type dctypt = ChangeType(commandParameters[i].SqlDbType);
                        string dcname = commandParameters[i].SourceColumn;
                        DataColumn dc = new DataColumn(dcname, dctypt);
                        dt.Columns.Add(dc);
                    }
                    da.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
                    da.UpdateBatchSize = 0;


                    for (int j = 0; j < liststr.Count; j++)
                    {


                    }
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);

                    for (int i = 0; i < liststr.Count; i++)
                    {
                        string str = liststr[i].ToString();
                        string[] strarry = str.Split(',');
                        DataRow row = dt.NewRow();
                        for (int j = 0; j < commandParameters.Length; j++)
                        {

                            //Type t = dt.Rows[i][fields[j].ToString()].GetType();
                            string converstr = strarry[j].ToString();
                            object ostr = new object();
                            ostr = (object)converstr;

                            row[commandParameters[j].SourceColumn] = ostr;
                        }
                        dt.Rows.Add(row);
                    }

                    DataSet dataset = new DataSet();
                    dataset.Tables.Add(dt);

                    SqlCommandBuilder scb = new SqlCommandBuilder(da);
                    da.Update(dataset.Tables[0]);
                    //dt.AcceptChanges();
                    da.Dispose();
                    dt.Dispose();
                    dataset.Dispose();
                    return 1;
                }
            }
            catch (Exception e)
            {

                return -1;
            }
           
            
        }

        private   static   System .Type   ChangeType(   SqlDbType    type   ) 
        { 
       

            if (type.Equals(SqlDbType.NVarChar))
            {
                return typeof(System.String);
                
            }
            if (type.Equals(SqlDbType.Date))
            {
                return typeof(System.DateTime);
            }
            if (type.Equals(SqlDbType.DateTime))
            {
                return typeof(System.DateTime);
            }
            if (type.Equals(SqlDbType.Float))
            {
                return typeof(System.Double);
            }
            if (type.Equals(SqlDbType.Int))
            {
                return typeof(System.Int32);
            }
            if (type.Equals(SqlDbType.Money))
            {
                return typeof(System.Decimal);
            }
            else
            {
                return typeof(System.String);
            }
        }
        public static int BatchInsert(string connstr, string selectText, DataTable dt)
        {

            try
            {
                using (SqlConnection connection = CreateConnection(connstr))
                {

                SqlCommand cmd = new SqlCommand(selectText, connection); 
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
                Builder.GetInsertCommand();
                sda.Update(dt);
                cmd.Dispose();
                sda.Dispose();
                return 1;
                }
            }
            catch (Exception e)
            {
                
                return -1;
                
            }
           
        }
        
        //private static SqlDbType ChangeType(Type type)
        //{
        //    if (type.Equals(typeof(System.String)))
        //        return SqlDbType.VarChar;
        //    if (type.Equals(typeof(System.Int32)))
        //        return SqlDbType.Int ;
        //    if (type.Equals(typeof(System.DateTime)))
        //        return SqlDbType.DateTime ;
        //    if (type.Equals(typeof(System.Decimal)))
        //        return SqlDbType.Decimal;
        //    return SqlDbType.VarChar;
        //} 

 


    }
}
