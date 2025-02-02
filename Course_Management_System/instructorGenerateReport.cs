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
    public partial class instructorGenerateReport : Form
    {
        private DatabaseHelper _dbHelper;
        private ReportDataAccess _reportDataAccess;
        private CourseDataAccess _courseDataAccess;
        public instructorGenerateReport()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("localhost", "CourseManagementSystem", "root", "");
            _reportDataAccess = new ReportDataAccess(_dbHelper);
            _courseDataAccess = new CourseDataAccess(_dbHelper);
            LoadCourses();
        }
        private void LoadCourses()
        {
            comboBox1.DataSource = _courseDataAccess.GetAllCourses();
            comboBox1.DisplayMember = "CourseName";
            comboBox1.ValueMember = "CourseID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstructorDashboard dashboard = new InstructorDashboard();
            this.Hide();
            dashboard.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                int courseId = (int)comboBox1.SelectedValue;
                DateTime fromDate = dateTimePicker1.Value;
                DateTime toDate = dateTimePicker2.Value;
                dataGridView1.DataSource = _reportDataAccess.GenerateCourseReport(courseId, fromDate, toDate);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Export data to csv or pdf.
        }

        private void instructorGenerateReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}