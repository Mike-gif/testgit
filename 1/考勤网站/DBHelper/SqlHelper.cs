using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DBHelper
{
    public class SqlHelper
    {/// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["DataConnectionString"].ConnectionString;
        /// <summary>
        /// 执行查询的方法（SQL语句或存储过程，有参数）
        /// </summary>
        /// <param name="cmdType">命令类型，如果是sql语句，则为CommandType.Text,否则为CommandType.StoredProcdure</param>
        /// <param name="cmdText">SQL语句或存储过程</param>
        /// <param name="commandParameters">参数，如果没有参数，则为Null</param>
        /// <returns></returns>
        /// 
        #region ExecuteDataTable
        public static DataTable ExecuteDataTable(string cmdtext)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                using (SqlCommand cmd = new SqlCommand())
                {
                    DataTable retrunDataTable = new DataTable();
                    PrepareCommand(con, cmd, CommandType.Text, cmdtext, null);
                    adapter.SelectCommand = cmd;
                    adapter.Fill(retrunDataTable);

                    return retrunDataTable;
                }
            }
        }
        //没有参数
        public static DataTable Read_TABLE(string prcname)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataTable retrunDataTable = new DataTable();
                SqlCommand cmd = new SqlCommand(prcname, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //输入参数
                //SqlParameter spvoteid = new SqlParameter("@pVoteID", SqlDbType.Int);
                //spvoteid.Value = vbid;
                //cmd.Parameters.Add(spvoteid);
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = cmd;
                    sda.Fill(retrunDataTable);
                }
                conn.Close();
                return retrunDataTable;
            }
        }
        //一个参数
        public static DataTable Read_TABLE(string prcname, string canshu)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataTable retrunDataTable = new DataTable();
                SqlCommand cmd = new SqlCommand(prcname, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //输入参数
                SqlParameter spvoteid = new SqlParameter("@" + canshu + "", SqlDbType.VarChar);
                spvoteid.Value = canshu;
                cmd.Parameters.Add(spvoteid);
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = cmd;
                    sda.Fill(retrunDataTable);
                }
                conn.Close();
                return retrunDataTable;
            }
        }
        //输入两个参数
        public static DataTable Read_TABLE(string prcname, string canshu1, string canshu2, string name1, string name2)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataTable retrunDataTable = new DataTable();
                SqlCommand cmd = new SqlCommand(prcname, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //输入参数
                SqlParameter spvoteid = new SqlParameter("@" + name1 + "", SqlDbType.VarChar);
                spvoteid.Value = canshu1;
                cmd.Parameters.Add(spvoteid);
                SqlParameter spvoteid2 = new SqlParameter("@" + name2 + "", SqlDbType.VarChar);
                spvoteid2.Value = canshu2;
                cmd.Parameters.Add(spvoteid2);
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = cmd;
                    sda.Fill(retrunDataTable);
                }
                conn.Close();
                return retrunDataTable;
            }
        }
        //更新数据
        public static int updateData(string prcname, string canshu1, string name1)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                int val;
                conn.Open();
                SqlCommand cmd = new SqlCommand(prcname, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //输入参数
                cmd.Parameters.Add("@" + name1 + "", SqlDbType.Char);
                cmd.Parameters["@" + name1 + ""].Value = canshu1;
                val = cmd.ExecuteNonQuery();
                conn.Close();
                return val;
            }
        }



        #endregion

        #region ExecuteNonQuery

        /// <summary>
        /// 执行增删改的方法（存储过程或SQL语句/参数）
        /// </summary>
        /// <param name="cmdType">命令类型，如果是sql语句，则为CommandType.Text,否则为CommandType.StoredProcdure</param>
        /// <param name="cmdText">SQL语句或者存储过程名称</param>
        /// <param name="commandParams">SQL参数，如果没有参数，则为null</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParams)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    PrepareCommand(con, cmd, cmdType, cmdText, commandParams);
                    int val = cmd.ExecuteNonQuery();
                    
                    cmd.Parameters.Clear();
                    return val;
                   
                }
            }
        }

        /// <summary>
        /// 执行增删改的方法（SQL语句+参数）
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParams">SQL参数，如果没有参数，则为Null</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] commandParams)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    PrepareCommand(con, cmd, CommandType.Text, cmdText, commandParams);
                   int val = cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }

        /// <summary>
        /// 执行增、删、改的方法（SQL语句，没有参数）
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    con.Open();
                    int val = cmd.ExecuteNonQuery();
                    return val;
                }
            }
        }

        #endregion

        #region ExecuteReader
        public static SqlConnection sqlCon;

        // <summary>
        // 定义一个SqlCommand对象
        // </summary>
        public static SqlCommand sCmd;
        // <summary>
        // 定义一个SqlDataReader对象
        // </summary>
        public static SqlDataReader sDr;

        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            sqlCon = new SqlConnection(connectionString);
            sCmd = new SqlCommand();
            try
            {
                PrepareCommand(sqlCon, sCmd, cmdType, cmdText, commandParameters);
                sDr = sCmd.ExecuteReader(CommandBehavior.CloseConnection);
                sCmd.Parameters.Clear();
                return sDr;
            }
            catch
            {
                sqlCon.Close();
                throw;
            }


        }
        #endregion
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        #region Close
        public static void Close()
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }


        #endregion
        #region ExecuteDataSet

        /// <summary>
        /// 执行查询的方法，支持存储过程
        /// </summary>
        /// <param name="cmdType">命令类型，如果是sql语句，则为CommandType.Text,否则为CommandType.StoredProcdure</param>
        /// <param name="cmdText">SQL语句或存储过程</param>
        /// <param name="para">SQL参数，如果没有参数，则为null</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params SqlParameter[] para)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                using (SqlCommand cmd = new SqlCommand())
                {
                    DataSet ds = new DataSet();
                    PrepareCommand(con, cmd, cmdType, cmdText, para);
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);

                    return ds;
                }
            }
        }


        /// <summary>
        /// 执行查询过程（没有存储过程和参数）
        /// </summary>
        /// <param name="cmdtext">SQL语句</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string cmdtext)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                using (SqlCommand cmd = new SqlCommand())
                {
                    DataSet ds = new DataSet();
                    PrepareCommand(con, cmd, CommandType.Text, cmdtext, null);
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);

                    return ds;
                }
            }
        }

        /// <summary>
        /// 根据指定的SQL语句,返回DATASET
        /// </summary>
        /// <param name="cmdtext">要执行带参的SQL语句</param>
        /// <param name="para">参数</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string cmdtext, params SqlParameter[] para)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                using (SqlCommand cmd = new SqlCommand())
                {
                    DataSet ds = new DataSet();
                    PrepareCommand(con, cmd, CommandType.Text, cmdtext, para);
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);

                    return ds;
                }
            }
        }


        #endregion

        #region ExecuteScalar

        /// <summary>
        /// 执行查询单个值的方法，支持存储过程
        /// </summary>
        /// <param name="cmdType">命令类型，如果是sql语句，则为CommandType.Text,否则为CommandType.StoredProcdure</param>
        /// <param name="cmdText">SQL语句或者存储过程名称</param>
        /// <param name="commandParameters">SQL参数，如果没有参数，则为null</param>
        /// <returns>单个值</returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    PrepareCommand(con, cmd, cmdType, cmdText, commandParameters);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }

        /// <summary>
        /// 执行查询单个值的方法(没有存储过程和语句)
        /// </summary>
        /// <param name="cmdText">SQL语句或者存储过程名称</param>
        /// <returns>单个值</returns>
        public static object ExecuteScalar(string cmdText)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 执行指定参数和语句的查询方法
        /// </summary>
        /// <param name="cmdText">SQL语句或者存储过程名称</param>
        /// <param name="commandParameters">参数，如果没有参数，则为Null</param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    PrepareCommand(con, cmd, CommandType.Text, cmdText, commandParameters);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }
        #endregion



        #region 建立SqlCommand
        /// <summary>
        /// 建立SqlCommand
        /// </summary>
        /// <param name="con">SqlConnection　对象</param>
        /// <param name="cmd">要建立的Command</param>
        /// <param name="cmdType">CommandType</param>
        /// <param name="cmdText">执行的SQL语句</param>
        /// <param name="cmdParms">参数</param>
        private static void PrepareCommand(SqlConnection con, SqlCommand cmd, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (con.State != ConnectionState.Open)
                con.Open();

            cmd.Connection = con;
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;

            if (cmdParms != null)
                foreach (SqlParameter para in cmdParms)
                    cmd.Parameters.Add(para);
        }

        #endregion

    }
}
