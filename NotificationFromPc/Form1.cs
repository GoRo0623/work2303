using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NotificationFromPc
{
    public partial class Form1 : Form
    {
        private ListScreen _f2;
        private TimerNotify _timerNotify;
        private string _token = "";
        private int timerSec = 10000;
        public Form1()
        {
            //������
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd hh:mm:ss";
            _f2 = new ListScreen(this);
            _timerNotify = new TimerNotify();
            _timerNotify._token = _token;
            _timerNotify._data = _f2._table;
            _timerNotify.runTimer(timerSec);
        }
        public async Task Send_Line_Notify()
        {
            string str = textBox1.Text;
            string token = _token;
            using (HttpClient client = new HttpClient())
            {
                FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string> { { "message", "\r\n" + str } });
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponseMessage = await client.PostAsync("https://notify-api.line.me/api/notify", content);
                textBox2.Text = await httpResponseMessage.Content.ReadAsStringAsync();
                _ = httpResponseMessage;
            }
        }

        public void setSelectedData()
        {
            DataGridViewRow data = _f2.selectData;
            if (data == null || data.Cells == null || data.Cells.Count == 0)
            {
                dateTimePicker1.Value = DateTime.Now;
                textBox1.Text = "";
            }
            else
            {
                dateTimePicker1.Value = (DateTime)data.Cells[4].Value;
                textBox1.Text = (string)data.Cells[1].Value;
            }
            this.Visible = true;
            this.TopMost = true;
            this.TopMost = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "sending..........";
            textBox2.Refresh();
            _ = Send_Line_Notify();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            if (_f2.selectData == null || _f2.selectData.Cells == null || _f2.selectData.Cells.Count < 5)
            {
                _f2.selectData = new DataGridViewRow();
            }

            for (int i = _f2.selectData.Cells.Count; i < 5; i++)
            {
                _f2.selectData.Cells.Add(new DataGridViewTextBoxCell());
            }
            _f2.selectData.Cells[4].ValueType = typeof(DateTime);
            _f2.selectData.Cells[4].Value = dateTimePicker1.Value;
            _f2.selectData.Cells[1].ValueType = typeof(string);
            _f2.selectData.Cells[1].Value = textBox1.Text;
            _f2.selectData.Cells[0].ValueType = typeof(string);
            //
            DbAccess dbAccess = new DbAccess();
            string id = dbAccess.Update(_f2.selectData);
            if (id != null)
            {
                _f2.selectData.Cells[0].Value = id;
                MessageBox.Show("�ۑ��ł��܂����B");
            }
            else
            {
                MessageBox.Show("�ۑ��ł��܂���ł����B");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //�ύX�`�F�b�N�������Ȃ�
            DataGridViewRow data = _f2.selectData;
            DialogResult result = new DialogResult();
            if ((textBox1.Text.Length > 0 && (data == null || data.Cells == null || data.Cells.Count == 0 || data.Cells[0].Value == null || (string)data.Cells[0].Value == "")))
            {
                //�V�K�Ŗ��ۑ��̏ꍇ
                result = MessageBox.Show("�ύX��j�����܂����A��낵���ł����H", null, MessageBoxButtons.YesNo);
            }
            else if (!(data == null || data.Cells == null || data.Cells.Count == 0 || data.Cells[0].Value == null || (string)data.Cells[0].Value == ""))
            {
                //�l��ύX���Ė��ۑ��̏ꍇ
                if (!textBox1.Text.Equals((string)_f2.selectData.Cells[1].Value) || !dateTimePicker1.Value.Equals((DateTime)_f2.selectData.Cells[4].Value))
                {
                    result = MessageBox.Show("�ύX��j�����܂����A��낵���ł����H", null, MessageBoxButtons.YesNo);
                }
            }

            //�ύX�j���`�F�b�N�̉�
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                callListScreen();
                return;
            }
            else if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            // �G���[�`�F�b�N�Ɉ���������Ȃ����ꍇ
            callListScreen();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DataGridViewRow data = _f2.selectData;
            if (data == null || data.Cells == null || data.Cells.Count == 0)
            {
                MessageBox.Show("�V�K�f�[�^�͍폜�ł��܂���B");
                return;
            }
            DbAccess dbAccess = new DbAccess();
            bool success = dbAccess.Delete((string)_f2.selectData.Cells[0].Value);
            if (success)
            {
                MessageBox.Show("�폜���܂����B");
                callListScreen();
            }
            else
            {
                MessageBox.Show("�폜�ł��܂���ł����B");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //
        }
        private void callListScreen()
        {
            _timerNotify.stopTimer();
            Thread.Sleep(1000);
            _f2 = new ListScreen(this);
            _f2.Show();
            this.Visible = false;
            _timerNotify._data = _f2._table;
            _timerNotify.runTimer(timerSec);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timerNotify.stopTimer();
        }
    }
}