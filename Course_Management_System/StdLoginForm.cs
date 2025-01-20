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

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); 
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StdEnrollmentForm enrollment = new StdEnrollmentForm();
            enrollment.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StdSubmitAssignmentForm submitAssignment = new StdSubmitAssignmentForm();
            submitAssignment.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StdManageAccountForm manageAccount = new StdManageAccountForm();
            manageAccount.Show();
        }
    }
}
