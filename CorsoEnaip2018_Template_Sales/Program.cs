using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Template_Sales
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            try
            {
                conn = new SqlConnection("");
                conn.Open();
                cmd = conn.CreateCommand();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn != null) conn.Dispose();
                if (cmd != null) cmd.Dispose();
                if (reader != null) reader.Dispose();
            }

            reader.Dispose();

            cmd.Dispose();

            conn.Dispose();

            using (var conn2 = new SqlConnection("connection string"))
            {
                conn2.Open();

                using (var cmd2 = conn2.CreateCommand())
                {
                    cmd2.CommandText = "select ...";

                    using (var reader2 = cmd2.ExecuteReader())
                    {

                    }
                }
            }

            using (var conn2 = new SqlConnection("connection string"))
            using (var cmd2 = conn2.CreateCommand())
            {

            }

            //using (var workbook = EPPlus.CreateWorkbook("\Deskotop\file1"))
            //{

            //}

        }
    }

    class Sale
    {
        // ...
    }

    class FlatReport { }

    class DateReport { }

    class EmployeeReport { }
}
