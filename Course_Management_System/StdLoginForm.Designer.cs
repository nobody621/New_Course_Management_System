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
            button7 = new Button();
            button6 = new Button();
            button2 = new Button();
            button5 = new Button();
            button8 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button7
            // 
            button7.Location = new Point(738, 584);
            button7.Margin = new Padding(4, 4, 4, 4);
            button7.Name = "button7";
            button7.Size = new Size(162, 43);
            button7.TabIndex = 6;
            button7.Text = "Manage Account";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Location = new Point(908, 584);
            button6.Margin = new Padding(4, 4, 4, 4);
            button6.Name = "button6";
            button6.Size = new Size(117, 43);
            button6.TabIndex = 7;
            button6.Text = "Logout";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Control;
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(350, 379);
            button2.Margin = new Padding(4, 4, 4, 4);
            button2.Name = "button2";
            button2.Size = new Size(307, 62);
            button2.TabIndex = 9;
            button2.Text = "Submit Assignments";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.Control;
            button5.Font = new Font("Segoe UI", 12F);
            button5.Location = new Point(350, 288);
            button5.Margin = new Padding(4, 4, 4, 4);
            button5.Name = "button5";
            button5.Size = new Size(307, 63);
            button5.TabIndex = 10;
            button5.Text = "My Enrollment/Progress";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button8
            // 
            button8.BackColor = SystemColors.Control;
            button8.Font = new Font("Segoe UI", 12F);
            button8.Location = new Point(350, 199);
            button8.Margin = new Padding(4, 4, 4, 4);
            button8.Name = "button8";
            button8.Size = new Size(307, 66);
            button8.TabIndex = 11;
            button8.Text = "View Courses";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(302, 62);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(176, 46);
            label1.TabIndex = 8;
            label1.Text = "Welcome ";
            // 
            // StdLoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.WhatsApp_Image_2025_01_19_at_14_12_29_e20950cf;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1029, 631);
            Controls.Add(button2);
            Controls.Add(button5);
            Controls.Add(button8);
            Controls.Add(label1);
            Controls.Add(button7);
            Controls.Add(button6);
            Name = "StdLoginForm";
            Text = "StudentLoginFrom";
            Load += StudentLoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button7;
        private Button button6;
        private Button button2;
        private Button button5;
        private Button button8;
        private Label label1;
    }
}