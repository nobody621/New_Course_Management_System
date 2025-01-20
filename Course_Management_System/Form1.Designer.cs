namespace Course_Management_System
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button2 = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(356, 28);
            label1.Name = "label1";
            label1.Size = new Size(171, 62);
            label1.TabIndex = 0;
            label1.Text = "LOGIN";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.Location = new Point(90, 196);
            label2.Name = "label2";
            label2.Size = new Size(121, 31);
            label2.TabIndex = 0;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label3.Location = new Point(90, 300);
            label3.Name = "label3";
            label3.Size = new Size(114, 31);
            label3.TabIndex = 0;
            label3.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(90, 334);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(302, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(162, 385);
            button1.Name = "button1";
            button1.Size = new Size(155, 40);
            button1.TabIndex = 2;
            button1.Text = "Instructor Login";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(90, 230);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(302, 27);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(46, 164);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(394, 283);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(484, 164);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(394, 283);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label4.Location = new Point(528, 300);
            label4.Name = "label4";
            label4.Size = new Size(114, 31);
            label4.TabIndex = 0;
            label4.Text = "Password";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(528, 334);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(302, 27);
            textBox3.TabIndex = 1;
            textBox3.TextChanged += textBox1_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(528, 230);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(302, 27);
            textBox4.TabIndex = 1;
            textBox4.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(592, 385);
            button2.Name = "button2";
            button2.Size = new Size(155, 40);
            button2.TabIndex = 2;
            button2.Text = "Student Login";
            button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label5.Location = new Point(528, 196);
            label5.Name = "label5";
            label5.Size = new Size(121, 31);
            label5.TabIndex = 0;
            label5.Text = "Username";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(920, 525);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button2;
        private Label label5;
    }
}
