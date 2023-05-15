using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;

namespace NotificationFromPc
{
    class MessageDto
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public int Delflg { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime NotifyDate { get; set; }
    }
    class DbAccess
    {
        public void Select()
        {
            //削除以外取得
            ConnectDb("SELECT * FROM dbo.notifymessage WHERE dbo.delflg = 0");

        }
        public void Update()
        {
            //削除以外取得
            ConnectDb("SELECT * FROM dbo.notifymessage WHERE dbo.delflg <> 1");

        }
        void ConnectDb(String sqlCommand )
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "notifyserver0623.database.windows.net";
                builder.UserID = "notifyuser0623";
                builder.Password = "Nlineuser0623";
                builder.InitialCatalog = "notify-server0623";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT * FROM dbo.notifymessage";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));

                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
