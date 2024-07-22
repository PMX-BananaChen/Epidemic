
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GuardDispatchSystem
{
    public class DataBase
    {
      //Database db;
      //  db = DatabaseFactory.CreateDatabase("ITRepairSystem");
        string connstr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;

        //public static int staticVar;
        //public int instanceVar;
        
        public DataSet GetRows(string sql)
        {
            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();
            return ds;
        }



        public int GetcountsInt(string sql)
        {
            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            int b = Convert.ToInt32(com.ExecuteNonQuery ());
            con.Close();
            return b;
        }



        public SqlDataReader ExecuteReader(string sql)
        {
            SqlConnection con = new SqlConnection(connstr);
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader myReader = com.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
        }




        public DataSet SendMail(string AcountMan, string AssignUser, string CreateDate, string Subject, string PhoneNum)
        {
            // DbCommand cmd = db . GetStoredProcCommand("Pro_Apply");
            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Pro_StationAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //  SqlDataReader sdr = new SqlDataReader();
            cmd.Parameters.Add(new SqlParameter("@AcountMan", SqlDbType.VarChar, 50, AcountMan));//操作的人
            cmd.Parameters.Add(new SqlParameter("@AssignUser", SqlDbType.VarChar, 50, AssignUser));//核准的人(即接收郵件的人)
            cmd.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.VarChar, 50, CreateDate));//操作時間
            cmd.Parameters.Add(new SqlParameter("@Subject", SqlDbType.VarChar, 50, Subject));//操作項目類型
            cmd.Parameters.Add(new SqlParameter("@PhoneNum", SqlDbType.VarChar, 50, PhoneNum));//操作人分機號
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close(); 
            return ds;

         

          
        }
    


    }
}