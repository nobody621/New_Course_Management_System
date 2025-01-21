using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Management_System
{
    public partial class StdLoginForm : Form
    {
        public StdLoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StdCourseCatalogForm courseCatalog = new StdCourseCatalogForm();
            courseCatalog.Show();
        }

        private void StudentLoginForm_Load(object sender, EventArgs e)
        {

        }


        private void button8_Click(object sender, EventArgs e)
        {
            StdCourseCatalogForm course = new StdCourseCatalogForm();
            this.Hide();
            course.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StdEnrollmentForm enrollmentForm = new StdEnrollmentForm();
            enrollmentForm.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            StdSubmitAssignmentForm assignment = new StdSubmitAssignmentForm();
            this.Hide();
            assignment.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StdManageAccountForm manage = new StdManageAccountForm();
            this.Hide();
            manage.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoginPage LoginPage = new LoginPage();  
            LoginPage.Show();
            this.Hide();
        }
    }
}
