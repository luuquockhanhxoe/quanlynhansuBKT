using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNhanSuBanChuan.DataAccess
{
   public class Data_Access
    {
        SqlConnection connection;
        DataTable dt;
        SqlDataAdapter da;
        string strPath = @"Data Source=DESKTOP-PC8NIRQ\SQLEXPRESS01;Initial Catalog=QuanLyNhanSuBKT;Integrated Security=True";
               
         public DataTable CreateTable(string commantext,byte[] anhluu=null)
        {
            connection = new SqlConnection(strPath);
            connection.Open();
            SqlCommand cmd;
            if (anhluu!=null)
            {
                cmd = new SqlCommand(commantext, connection);
                cmd.Parameters.AddWithValue("@anhluu",anhluu);
            }
            else
            {
                cmd = new SqlCommand(commantext, connection);
            }
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            return dt;            
        }
    }
}
