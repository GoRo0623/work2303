using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Data;

namespace NotificationFromPc
{
    enum SqlType
    {
        Select = 0,
        SelectMany = 1,
        Insert = 2,
        Update = 3,
        Delete = 4,
    }
    class DbAccess
    {
        private DataTable _table = new DataTable();
        private DataGridViewRow _selectData = new DataGridViewRow();
        private string _id = "";
        public DataTable Select()
        {
            _table = new DataTable();
            //削除以外取得
            ConnectDb(@"SELECT * FROM dbo.notifymessage WHERE delflg = 0", SqlType.SelectMany);
            return _table;
        }
        public string Update(DataGridViewRow selectData)
        {
            //削除フラグ以外更新
            if(selectData == null || selectData.Cells == null || selectData.Cells.Count == 0)
            {
                return "";
            }
            _selectData = selectData;
            //idが存在するか確認する
            string id = (string)selectData.Cells[0].Value;
            if(id == null || id == "")
            {
                //新規登録
                _selectData.Cells[0].Value = DateTime.Now.ToString("yyyyMMddhhmmss");
                string sql = @"INSERT INTO dbo.notifymessage (id, message, delflg, schedule_date) VALUES (@id, @message, 0, @schedule_date)";
                bool success = ConnectDb(sql, SqlType.Insert);
                if(success)
                {
                    return (string)_selectData.Cells[0].Value;
                }
            }
            else
            {
                //更新
                string sql = @"UPDATE dbo.notifymessage SET message = @message, schedule_date = @schedule_date WHERE id = @id;";
                bool success = ConnectDb(sql, SqlType.Update);
                if (success)
                {
                    return (string)_selectData.Cells[0].Value;
                }
            }
            return "";
        }
        public bool Delete(string id)
        {
            if (id == null || id == "")
            {
                return false;
            }
            //存在を確認する
            _id = id;
            bool exist = ConnectDb(@"SELECT * FROM dbo.notifymessage WHERE delflg = 0 AND id = @id", SqlType.Select);
            if (!exist)
            {
                return false;
            }
            //存在した場合のみ削除フラグを立てる
            string sql = @"UPDATE dbo.notifymessage SET delflg = 1 WHERE id = @id;";
            bool success = ConnectDb(sql, SqlType.Delete);

            return success;
        }
        private bool ConnectDb(String sqlCommand, SqlType type)
        {
            bool successFlag = false;
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

                    using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                    {
                        connection.Open();
                        
                        switch (type)
                        {
                            case SqlType.SelectMany:
                                {
                                    var adapter = new SqlDataAdapter(command);
                                    adapter.Fill(_table);
                                    successFlag = true;
                                }
                                break;
                            case SqlType.Select:
                                {
                                    command.Parameters.Add(new SqlParameter("@id", _id));
                                    var adapter = new SqlDataAdapter(command);
                                    DataTable dt = new DataTable();
                                    adapter.Fill(dt);
                                    if (dt.Rows.Count > 0)
                                    {
                                        successFlag = true;
                                    }
                                }
                                break;
                            case SqlType.Insert:
                                {
                                    command.Parameters.Add(new SqlParameter("@id", (string)_selectData.Cells[0].Value));
                                    command.Parameters.Add(new SqlParameter("@message", (string)_selectData.Cells[1].Value));
                                    command.Parameters.Add(new SqlParameter("@schedule_date", (DateTime)_selectData.Cells[4].Value));
                                    int success = command.ExecuteNonQuery();
                                    if (success > 0) 
                                    {
                                        successFlag = true;
                                    }
                                }
                                break;
                            case SqlType.Update:
                                {
                                    command.Parameters.Add(new SqlParameter("@message", (string)_selectData.Cells[1].Value));
                                    command.Parameters.Add(new SqlParameter("@schedule_date", (DateTime)_selectData.Cells[4].Value));
                                    command.Parameters.Add(new SqlParameter("@id", (string)_selectData.Cells[0].Value));
                                    int success = command.ExecuteNonQuery();
                                    if (success > 0)
                                    {
                                        successFlag = true;
                                    }
                                }
                                break;
                            case SqlType.Delete: 
                                {
                                    command.Parameters.Add(new SqlParameter("@id", _id));
                                    int success = command.ExecuteNonQuery();
                                    if (success > 0)
                                    {
                                        successFlag = true;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            Console.ReadLine();
            return successFlag;
        }
    }
}
