namespace NguyenHuuKhoa_6551071049_VP101_28_LTTQ
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
            groupBox1 = new GroupBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            btnThem = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(296, 21);
            label1.Name = "label1";
            label1.Size = new Size(328, 38);
            label1.TabIndex = 0;
            label1.Text = "DANH MỤC CÔNG VIỆC";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlLight;
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(37, 83);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(882, 206);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Công Việc";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(322, 139);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(231, 27);
            textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(322, 92);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(231, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(322, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(231, 27);
            textBox1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(173, 139);
            label4.Name = "label4";
            label4.Size = new Size(96, 20);
            label4.TabIndex = 2;
            label4.Text = "Lương Tháng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(173, 95);
            label3.Name = "label3";
            label3.Size = new Size(103, 20);
            label3.TabIndex = 1;
            label3.Text = "Tên Công Việc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(173, 51);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã Công Việc";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(37, 313);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(893, 201);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Công Việc";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(893, 188);
            dataGridView1.TabIndex = 0;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(155, 527);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(119, 46);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // button2
            // 
            button2.Location = new Point(325, 526);
            button2.Name = "button2";
            button2.Size = new Size(119, 46);
            button2.TabIndex = 4;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnSua_Click;
            // 
            // button3
            // 
            button3.Location = new Point(495, 529);
            button3.Name = "button3";
            button3.Size = new Size(119, 46);
            button3.TabIndex = 5;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnXoa_Click;
            // 
            // button4
            // 
            button4.Location = new Point(665, 529);
            button4.Name = "button4";
            button4.Size = new Size(119, 46);
            button4.TabIndex = 6;
            button4.Text = "Thoát";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnThoat_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 597);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btnThem);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Button btnThem;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
