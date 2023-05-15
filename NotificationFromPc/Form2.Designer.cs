namespace NotificationFromPc
{
    partial class ListScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Message = new DataGridViewTextBoxColumn();
            Update = new DataGridViewTextBoxColumn();
            NotifyDate = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(211, 372);
            button1.Name = "button1";
            button1.Size = new Size(180, 66);
            button1.TabIndex = 3;
            button1.Text = "編集";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Message, Update, NotifyDate });
            dataGridView1.Location = new Point(12, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(439, 345);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Message
            // 
            Message.HeaderText = "Message";
            Message.Name = "Message";
            Message.ReadOnly = true;
            // 
            // Update
            // 
            Update.HeaderText = "Update";
            Update.Name = "Update";
            Update.ReadOnly = true;
            // 
            // NotifyDate
            // 
            NotifyDate.HeaderText = "NotifyDate";
            NotifyDate.Name = "NotifyDate";
            NotifyDate.ReadOnly = true;
            // 
            // ListScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "ListScreen";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Message;
        private DataGridViewTextBoxColumn Update;
        private DataGridViewTextBoxColumn NotifyDate;
    }
}