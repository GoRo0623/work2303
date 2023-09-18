using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotificationFromPc
{
    public partial class ListScreen : Form
    {
        public Form1 _f1;

        public DataGridViewRow selectData { set; get; }
        public DataTable _table { set; get; }
        private bool _init = false;
        public ListScreen(Form1 form)
        {
            //初期化
            InitializeComponent();
            selectData = new DataGridViewRow();
            _f1 = form;
            _init = true;
            //一覧データを取得表示
            DbAccess dbAccess = new DbAccess();
            _table = dbAccess.Select();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = _table;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            //ヘッダー
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Message";
            dataGridView1.Columns[4].HeaderText = "ScheduleDate";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //選択状態にする
                selectData = new DataGridViewRow();
                //選択データをセットする
                selectData = dataGridView1.Rows[e.RowIndex];
            }
            catch (Exception ex)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //情報の更新
            _f1.setSelectedData();
            //画面を閉じる
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //一覧データを取得表示
            DbAccess dbAccess = new DbAccess();
            _table = dbAccess.Select();
            dataGridView1.DataSource = _table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //新規作成画面を表示する
            //選択データを初期化する
            selectData = new DataGridViewRow();
            //情報の更新
            _f1.setSelectedData();
            //画面を閉じる
            this.Close();
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (_init)
            {
                //初期選択データを消去する
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = null;
                _init = false;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //log
            Console.WriteLine(e.ToString());
        }
    }
}
