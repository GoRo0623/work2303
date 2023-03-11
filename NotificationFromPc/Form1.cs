using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotificationFromPc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public async Task Send_Line_Notify()
        {
            string str = textBox1.Text;
            string token = "accessToken";
            using (HttpClient client = new HttpClient())
            {
                FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string> { { "message", "\r\n" + str } });
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponseMessage = await client.PostAsync("https://notify-api.line.me/api/notify", content);
                textBox2.Text = await httpResponseMessage.Content.ReadAsStringAsync();
                _ = httpResponseMessage;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "sending..........";
            textBox2.Refresh();
            _ = Send_Line_Notify();
        }
    }
}