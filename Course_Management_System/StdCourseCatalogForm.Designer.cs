namespace Course_Management_System
{
    partial class StdCourseCatalogForm
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
            panel1 = new Panel();
            label2 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 125);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(277, 9);
            label2.Name = "label2";
            label2.Size = new Size(261, 46);
            label2.TabIndex = 2;
            label2.Text = "Course Catalog";
            label2.Click += label2_Click;
            // 
            // StdCourseCatalogForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.WhatsApp_Image_2025_01_19_at_14_12_29_e20950cf;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(835, 450);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "StdCourseCatalogForm";
            Text = "StdCourseCatalogForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
    }
}