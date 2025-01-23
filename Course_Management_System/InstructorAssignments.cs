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
    public partial class InstructorAssignments : Form
    {
        private DatabaseHelper _dbHelper;
        private AssignmentDataAccess _assignmentDataAccess;
        private CourseDataAccess _courseDataAccess;
        public InstructorAssignments()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("localhost", "CourseManagementSystem", "root", "");
            _assignmentDataAccess = new AssignmentDataAccess(_dbHelper);
            _courseDataAccess = new CourseDataAccess(_dbHelper);
            LoadAssignments();
            LoadCourses();
        }
        private void LoadAssignments()
        {
            dataGridView1.DataSource = _assignmentDataAccess.GetAllAssignments();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string assignmentTitle = textBox1.Text;
            string assignmentDescription = textBox2.Text;
            DateTime dueDate = dateTimePicker1.Value;
            int courseId = (int)comboBox1.SelectedValue;

            if (string.IsNullOrEmpty(assignmentTitle) || string.IsNullOrEmpty(assignmentDescription))
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK);
                return;
            }
            Assignment assignment = new Assignment { CourseID = courseId, Title = assignmentTitle, Description = assignmentDescription, DueDate = dueDate };
            if (_assignmentDataAccess.AddAssignment(assignment))
            {
                MessageBox.Show("Assignment Saved", "Confirmation", MessageBoxButtons.OK);
                LoadAssignments();
            }
            else
            {
                MessageBox.Show("Error saving Assignment", "Error", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;

        }
    }
}