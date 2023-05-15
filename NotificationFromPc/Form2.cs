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
        public ListScreen()
        {
            InitializeComponent();
            //一覧データを取得表示
            MessageDto messageDto = new MessageDto();
            DbAccess dbAccess = new DbAccess();
            dbAccess.Select();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1件だけ取得するSQL
            //画面を閉じる
            this.Close();
        }
    }
}
