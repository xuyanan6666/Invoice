using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;


namespace Invoice
{
    class SqlHelp
    {

        [DllImport("GetConn.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetConnstr();

        static string ConnStr = Getstr();

        private static string Getstr()
        {
            string conn = "";
            IntPtr c = GetConnstr();
            conn = Marshal.PtrToStringAnsi(c);
            return conn;
        }

        private static string Getstrnew()
        {
            string lingname = "";
            Ini ini = new Ini(System.Environment.CurrentDirectory + "/xtpz.ini");
            string fwq = ini.ReadIni("数据库登录", "服务器名");
            string sjk = ini.ReadIni("数据库登录", "数据库名");
            string yh = ini.ReadIni("数据库登录", "用户名称");
            string pass = ini.ReadIni("数据库登录", "用户口令");
          
            lingname = "server=" + fwq.Trim() + ";uid=" + yh.Trim() + ";pwd=" + pass.Trim() + ";database=" + sjk.Trim();

            return lingname;
        }

        public static string Conncs()
        {
           string msg="";
           try
           {
               using (SqlConnection conn = new SqlConnection(ConnStr))
               {
                   conn.Open();
                   if (conn.State == ConnectionState.Closed)
                   {
                       msg = "数据库连接不成功";
                   }
               }
           }
           catch(Exception ex)
           {
               throw ex;
           }
           return msg;
        }



        //his服务器
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);                    
                    i = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            return i;
        }

    
     

        public static DataTable HisTable(string ls_sql, params SqlParameter[] parameter)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlDataAdapter ad = new SqlDataAdapter(ls_sql, conn))
                {
                    foreach (SqlParameter s in parameter)
                    {
                        ad.SelectCommand.Parameters.Add(s);
                    }
                    ad.Fill(dt);
                    ad.SelectCommand.Parameters.Clear();
                }
            }
            return dt;
        }

     


        public static DataTable ProcTable(string procname, params SqlParameter[] parameter)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.Connection = conn;
                        da.SelectCommand.CommandText = procname;
                        da.SelectCommand.Parameters.AddRange(parameter);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.Fill(dt);
                        da.SelectCommand.Parameters.Clear();
                        return dt;
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

      

        public static string ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            string result;
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                    result = Convert.ToString(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();
                    if (result == null)
                    {
                        result = "";
                    }
                    
                    return result;
                }
            }
        }

       

       


    }


    
 
}
