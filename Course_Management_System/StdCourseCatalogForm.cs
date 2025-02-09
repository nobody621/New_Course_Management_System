﻿using System;
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
            // Setting the autosize mode
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Make the form open up in maximized view
            this.WindowState = FormWindowState.Maximized;
            LoadCourses();
        }

        private void LoadCourses()
        {
            dataGridView1.AutoGenerateColumns = false;
            // Clear existing columns
            dataGridView1.Columns.Clear();
            // Add columns with specific headers
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "CourseName", HeaderText = "Course Name", DataPropertyName = "CourseName" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Description", DataPropertyName = "Description" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Duration", HeaderText = "Duration", DataPropertyName = "Duration" });
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Enroll",
                HeaderText = "Select Course"
            });

            dataGridView1.DataSource = _courseDataAccess.GetAllCourses();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StdLoginForm stdlogin = new StdLoginForm(_student); // Pass the Student object
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
                    if (row.DataBoundItem is Course course)
                    {
                        selectedCourses.Add(course.CourseID);
                    }
                }
            }
            if (selectedCourses.Count == 0)
            {
                MessageBox.Show("Please select at least one course to enroll", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                if (_enrollmentDataAccess.AddEnrollment(enrollment))
                {
                    MessageBox.Show("Enrollment request submitted", "Confirmation", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Error submitting enrollment request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void StdCourseCatalogForm_Load(object sender, EventArgs e)
        {
        }
    }
}