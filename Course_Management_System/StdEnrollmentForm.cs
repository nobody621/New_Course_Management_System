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
    public partial class StdEnrollmentForm : Form
    {
        private DatabaseHelper _dbHelper;
        private EnrollmentDataAccess _enrollmentDataAccess;
        private GradeDataAccess _gradeDataAccess;
        private CourseDataAccess _courseDataAccess;
        private Student _student; // Use Student Object
        public StdEnrollmentForm(Person student)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("localhost", "CourseManagementSystem", "root", "");
            _enrollmentDataAccess = new EnrollmentDataAccess(_dbHelper);
            _gradeDataAccess = new GradeDataAccess(_dbHelper);
            _courseDataAccess = new CourseDataAccess(_dbHelper);
            _student = (Student)student;
            this.WindowState = FormWindowState.Maximized;
            LoadEnrollments();
        }
        private void LoadEnrollments()
        {
            List<Enrollment> enrollments = _enrollmentDataAccess.GetAllEnrollmentRequests();
            if (enrollments == null)
            {
                MessageBox.Show("There was an issue loading the enrollments", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            enrollments = enrollments.Where(enrollment => enrollment.UserID == _student.UserID && enrollment.Status == "approved").ToList();

            var enrolledCourses = new List<EnrolledCourseDisplay>();

            foreach (var enrollment in enrollments)
            {
                Course course = _courseDataAccess.GetAllCourses().FirstOrDefault(course => course.CourseID == enrollment.CourseID);
                if (course != null)
                {
                    List<Grade> grades = _gradeDataAccess.GetGradesByStudent(null); // TODO: implement a method to get grades by userID
                    grades = grades.Where(grade => grade.UserID == _student.UserID && grade.CourseName == course.CourseName).ToList();


                    double progress = 0;
                    if (grades != null && grades.Count() > 0)
                    {
                        progress = grades.Average(grade => grade.GradeValue);
                    }

                    enrolledCourses.Add(new EnrolledCourseDisplay
                    {
                        CourseName = course.CourseName,
                        StartDate = enrollment.RequestDate,
                        Progress = progress
                    });
                }
                else
                {
                    MessageBox.Show($"Error Loading Course with id = {enrollment.CourseID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            dataGridView1.DataSource = enrolledCourses;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StdCourseCatalogForm stdcourse = new StdCourseCatalogForm(_student);
            this.Hide();
            stdcourse.Show();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void StdEnrollmentForm_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StdLoginForm stdLoginForm = new StdLoginForm(_student);
            stdLoginForm.Show();
            this.Hide();
        }
    }
    public class EnrolledCourseDisplay
    {
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public double Progress { get; set; }
    }
}