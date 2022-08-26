using Microsoft.Data.SqlClient;

namespace Dashboard_DW.Connection
{
    public class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=BAYYA-LAPTOP;Database=DWH_DataBase;Trusted_Connection=True;");

        }

    }
}
