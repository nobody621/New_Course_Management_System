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
    public partial class InstructorDashboard : Form
    {
        public InstructorDashboard()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoginPage login = new LoginPage();
            this.Hide();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstructorManageCourses manageCourses = new InstructorManageCourses();
            this.Hide();
            manageCourses.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InstructorManageEnrollment enrollment = new InstructorManageEnrollment();
            this.Hide();
            enrollment.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InstructorAssignments assignment = new InstructorAssignments();
            this.Hide();
            assignment.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InstructorTrackStudentPerformance performance = new InstructorTrackStudentPerformance();
            this.Hide();
            performance.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            instructorGenerateReport report = new instructorGenerateReport();
            this.Hide();
            report.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            InstructorManageAccount account = new InstructorManageAccount();
            this.Hide();
            account.Show();
        }

        private void InstructorDashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
