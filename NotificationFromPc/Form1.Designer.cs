namespace NotificationFromPc
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 69);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "Message";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Yu Gothic UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(12, 87);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(379, 212);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 305);
            button1.Name = "button1";
            button1.Size = new Size(180, 66);
            button1.TabIndex = 2;
            button1.Text = "送信";
            button1.UseVisualStyleBackColor = true;
            button1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 396);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 3;
            label2.Text = "Responce";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 414);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(379, 111);
            textBox2.TabIndex = 4;
            // 
            // button2
            // 
            button2.Font = new Font("Yu Gothic UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(211, 305);
            button2.Name = "button2";
            button2.Size = new Size(180, 66);
            button2.TabIndex = 5;
            button2.Text = "保存";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(288, 23);
            button3.Name = "button3";
            button3.Size = new Size(98, 34);
            button3.TabIndex = 6;
            button3.Text = "リスト";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(218, 23);
            button4.Name = "button4";
            button4.Size = new Size(48, 34);
            button4.TabIndex = 7;
            button4.Text = "削除";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Yu Gothic UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(12, 23);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 25);
            dateTimePicker1.TabIndex = 8;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 5);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 9;
            label3.Text = "Schedule Date";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 535);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "NotificationFromPc";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private TextBox textBox2;
        private Button button2;
        private Button button3;
        private Button button4;
        private DateTimePicker dateTimePicker1;
        private Label label3;
    }
}