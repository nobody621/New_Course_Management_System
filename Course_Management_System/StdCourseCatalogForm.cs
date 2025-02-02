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
    public partial class StdCourseCatalogForm : Form
    {
        private DatabaseHelper _dbHelper;
        private CourseDataAccess _courseDataAccess;
        private EnrollmentDataAccess _enrollmentDataAccess;
        private Student _student;  // Use Student instead of int userId

        public StdCourseCatalogForm(Person student)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("localhost", "CourseManagementSystem", "root", "");
            _courseDataAccess = new CourseDataAccess(_dbHelper);
            _enrollmentDataAccess = new EnrollmentDataAccess(_dbHelper);
            _student = (Student)student;
            LoadCourses();
        }
        private void LoadCourses()
        {
            dataGridView1.DataSource = _courseDataAccess.GetAllCourses();
            dataGridView1.Columns["CourseID"].Visible = false;
            dataGridView1.Columns["Syllabus"].Visible = false;
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Enroll",
                HeaderText = "Select Course"
            });
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StdLoginForm stdlogin = new StdLoginForm(_student); // Pass the student object
            this.Hide();
            stdlogin.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<int> selectedCourses = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Enroll"].Value != null && (bool)row.Cells["Enroll"].Value == true)
                {
                    selectedCourses.Add((int)row.Cells["CourseID"].Value);
                }
            }
            foreach (int courseId in selectedCourses)
            {
                Enrollment enrollment = new Enrollment()
                {
                    CourseID = courseId,
                    UserID = _student.UserID,  // Use the Student UserID
                    RequestDate = DateTime.Now,
                    Status = "pending"
                };
                _enrollmentDataAccess.AddEnrollment(enrollment);
            }
            MessageBox.Show("Enrollment request submitted", "Confirmation", MessageBoxButtons.OK);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void StdCourseCatalogForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}