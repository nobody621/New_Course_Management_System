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
            // Setting up the DataGridView here
            dataGridView1.AutoGenerateColumns = false;
            // Clear existing columns
            dataGridView1.Columns.Clear();
            // Add columns with specific headers
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "CourseName", HeaderText = "Course Name", DataPropertyName = "CourseName" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Description", DataPropertyName = "Description" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Duration", HeaderText = "Duration", DataPropertyName = "Duration" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Syllabus", HeaderText = "Syllabus", DataPropertyName = "Syllabus" });
            // Setting the action button
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "Actions";
            buttonColumn.Text = "Delete";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);
            dataGridView1.DataSource = _courseDataAccess.GetAllCourses();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.WindowState = FormWindowState.Maximized;

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
            // Check if the click event happened on the button
            if (e.ColumnIndex == dataGridView1.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                // Get course ID from the selected row
                int courseId = (int)dataGridView1.Rows[e.RowIndex].Cells["CourseID"].Value;

                // Delete the course
                if (_courseDataAccess.DeleteCourse(courseId))
                {
                    MessageBox.Show("Course deleted", "Confirmation", MessageBoxButtons.OK);
                    dataGridView1.DataSource = _courseDataAccess.GetAllCourses();
                }
                else
                {
                    MessageBox.Show("Error deleting course", "Error", MessageBoxButtons.OK);
                }

            }
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
                dataGridView1.DataSource = _courseDataAccess.GetAllCourses();
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
        private void InstructorManageCourses_Load(object sender, EventArgs e)
        {

        }
    }
}