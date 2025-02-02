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
        private Person _student;
        public StdLoginForm(Person student)
        {
            InitializeComponent();
            _student = student;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            StdCourseCatalogForm courseCatalog = new StdCourseCatalogForm(_student);
            this.Hide(); // Hiding the StdLoginForm so that it does not linger in the background
            courseCatalog.Show();
        }
        private void StudentLoginForm_Load(object sender, EventArgs e)
        {
        }
        private void button8_Click(object sender, EventArgs e)
        {
            StdCourseCatalogForm course = new StdCourseCatalogForm(_student);
            this.Hide();
            course.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            StdEnrollmentForm enrollmentForm = new StdEnrollmentForm(_student);
            this.Hide();
            enrollmentForm.Show();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            StdSubmitAssignmentForm assignment = new StdSubmitAssignmentForm(_student);
            this.Hide();
            assignment.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            StdManageAccountForm manage = new StdManageAccountForm(_student);
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