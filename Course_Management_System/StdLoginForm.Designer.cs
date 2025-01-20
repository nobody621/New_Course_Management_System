namespace Course_Management_System
{
    partial class StdLoginForm
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
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(160, 28);
            label2.Name = "label2";
            label2.Size = new Size(483, 46);
            label2.TabIndex = 1;
            label2.Text = "WELCOME \"[Student Name]\"";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.Location = new Point(244, 117);
            button1.Name = "button1";
            button1.Size = new Size(297, 38);
            button1.TabIndex = 2;
            button1.Text = "View Courses";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(699, 12);
            button2.Name = "button2";
            button2.Size = new Size(89, 35);
            button2.TabIndex = 3;
            button2.Text = "Logout";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic);
            button3.Location = new Point(244, 243);
            button3.Name = "button3";
            button3.Size = new Size(297, 38);
            button3.TabIndex = 4;
            button3.Text = "Submit Assignments";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.None;
            button4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic);
            button4.Location = new Point(244, 178);
            button4.Name = "button4";
            button4.Size = new Size(297, 38);
            button4.TabIndex = 4;
            button4.Text = "My Enrollments/Progress";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.None;
            button5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic);
            button5.Location = new Point(244, 303);
            button5.Name = "button5";
            button5.Size = new Size(297, 38);
            button5.TabIndex = 5;
            button5.Text = "Manage Account";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // StdLoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.WhatsApp_Image_2025_01_19_at_14_12_29_e20950cf;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "StdLoginForm";
            Text = "StudentLoginFrom";
            Load += StudentLoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}