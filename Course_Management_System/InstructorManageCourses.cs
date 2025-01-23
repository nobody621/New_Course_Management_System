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
    public partial class InstructorManageCourses : Form
    {
        private DatabaseHelper _dbHelper;
        private CourseDataAccess _courseDataAccess;
        public InstructorManageCourses()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("localhost", "CourseManagementSystem", "root", "");
            _courseDataAccess = new CourseDataAccess(_dbHelper);
            LoadCourses();
        }

        private void LoadCourses()
        {
            dataGridView1.DataSource = _courseDataAccess.GetAllCourses();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            InstructorDashboard dashboard = new InstructorDashboard();
            this.Hide();
            dashboard.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string courseName = textBox1.Text;
            string courseDescription = textBox2.Text;
            string courseDuration = textBox3.Text;
            string courseSyllabus = richTextBox1.Text;

            if (string.IsNullOrEmpty(courseName) || string.IsNullOrEmpty(courseDescription) || string.IsNullOrEmpty(courseDuration) || string.IsNullOrEmpty(courseSyllabus))
            {
                MessageBox.Show("Please Fill all the fields", "Error", MessageBoxButtons.OK);
                return;
            }

            Course course = new Course { CourseName = courseName, Description = courseDescription, Duration = courseDuration, Syllabus = courseSyllabus };
            if (_courseDataAccess.AddCourse(course))
            {
                MessageBox.Show("Course Saved", "Confirmation", MessageBoxButtons.OK);
                LoadCourses();
            }
            else
            {
                MessageBox.Show("Error saving Course", "Error", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            richTextBox1.Text = "";
        }
    }
}