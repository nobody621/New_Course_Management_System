namespace Course_Management_System
{
    partial class InstructorDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructorDashboard));
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(234, 50);
            label1.Name = "label1";
            label1.Size = new Size(143, 37);
            label1.TabIndex = 0;
            label1.Text = "Welcome ";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(274, 116);
            button1.Name = "button1";
            button1.Size = new Size(239, 47);
            button1.TabIndex = 1;
            button1.Text = "Manage Courses";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Control;
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(274, 169);
            button2.Name = "button2";
            button2.Size = new Size(239, 45);
            button2.TabIndex = 1;
            button2.Text = "Manage Enrollment";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.Control;
            button3.Font = new Font("Segoe UI", 12F);
            button3.Location = new Point(274, 220);
            button3.Name = "button3";
            button3.Size = new Size(239, 44);
            button3.TabIndex = 1;
            button3.Text = "Assignments";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.Control;
            button4.Font = new Font("Segoe UI", 12F);
            button4.Location = new Point(274, 318);
            button4.Name = "button4";
            button4.Size = new Size(239, 43);
            button4.TabIndex = 1;
            button4.Text = "Generate Report";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.Control;
            button5.Font = new Font("Segoe UI", 12F);
            button5.Location = new Point(274, 270);
            button5.Name = "button5";
            button5.Size = new Size(239, 42);
            button5.TabIndex = 1;
            button5.Text = "Track Student Performance";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(706, 416);
            button6.Name = "button6";
            button6.Size = new Size(91, 31);
            button6.TabIndex = 1;
            button6.Text = "Logout";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(574, 416);
            button7.Name = "button7";
            button7.Size = new Size(126, 31);
            button7.TabIndex = 1;
            button7.Text = "Manage Account";
            button7.UseVisualStyleBackColor = true;
            // 
            // InstructorDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "InstructorDashboard";
            Text = "InstructorDashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}