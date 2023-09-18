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
            ScheduleDate = new DataGridViewTextBoxColumn();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(278, 484);
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
            dataGridView1.CausesValidation = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Message, Update, ScheduleDate });
            dataGridView1.Location = new Point(12, 58);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(439, 420);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.Paint += dataGridView1_Paint;
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
            // ScheduleDate
            // 
            ScheduleDate.HeaderText = "ScheduleDate";
            ScheduleDate.Name = "ScheduleDate";
            ScheduleDate.ReadOnly = true;
            // 
            // button2
            // 
            button2.Font = new Font("Yu Gothic UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(389, 12);
            button2.Name = "button2";
            button2.Size = new Size(62, 40);
            button2.TabIndex = 5;
            button2.Text = "更新";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Yu Gothic UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(12, 484);
            button3.Name = "button3";
            button3.Size = new Size(180, 66);
            button3.TabIndex = 6;
            button3.Text = "新規";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 7;
            label1.Text = "task list";
            // 
            // ListScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 562);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "ListScreen";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Message;
        private DataGridViewTextBoxColumn Update;
        private DataGridViewTextBoxColumn ScheduleDate;
        private Button button2;
        private Button button3;
        private Label label1;
    }
}