using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NotificationFromPc
{
    internal class TimerNotify
    {
        public DataTable _data { set; get; }
        public DataTable _exeData { set; get; }
        public string _token { set; get; }

        private System.Timers.Timer _tm;
        public TimerNotify()
        {
            _data = new DataTable();
        }
        public void runTimer(int msec)
        {
            try
            {
                _tm = new System.Timers.Timer(msec);
                _tm.Elapsed += timerEventMethod;
                _tm.AutoReset = true;
                _tm.Enabled = true;
                _tm.Start();
            }catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void stopTimer()
        {
            try
            {
                _tm.Stop();
            }catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void timerEventMethod(Object source, System.Timers.ElapsedEventArgs e)
        {
            _ = Send_Line_Notify();
        }

        public async Task Send_Line_Notify()
        {
            try {
                int index = 0;
                while (_data.Rows.Count > index)
                {
                    DateTime date = _data.Rows[index].Field<DateTime>("schedule_date");
                    if (checkTime(date))
                    {
                        string str = _data.Rows[index].Field<string>("message") ?? "";
                        var sendLog = "";
                        using (HttpClient client = new HttpClient())
                        {
                            FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string> { { "message", "\r\n" + str } });
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                            HttpResponseMessage httpResponseMessage = await client.PostAsync("https://notify-api.line.me/api/notify", content);
                            sendLog = await httpResponseMessage.Content.ReadAsStringAsync();
                            _ = httpResponseMessage;
                        }
                        if(sendLog.IndexOf("200") > 0)
                        {
                            //成功
                            string id = _data.Rows[index].Field<string>("id") ?? "";
                            deleteSendData(id);
                            _data.Rows.RemoveAt(index);
                        }
                    }
                    else
                    {
                        index++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private bool checkTime(DateTime scheduleDate)
        {
            if(scheduleDate <= DateTime.Now)
            {
                return true;
            }
            return false;
        }

        private bool deleteSendData(string id)
        {
            DbAccess dbAccess = new DbAccess();
            bool success = dbAccess.Delete(id);
            if (success)
            {
                return true;
            }
            return false;
        }
    }
}
