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
    public partial class InstructorManageEnrollment : Form
    {
        private DatabaseHelper _dbHelper;
        private EnrollmentDataAccess _enrollmentDataAccess;
        private CourseDataAccess _courseDataAccess;
        private UserDataAccess _userDataAccess;

        public InstructorManageEnrollment()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("localhost", "CourseManagementSystem", "root", "");
            _enrollmentDataAccess = new EnrollmentDataAccess(_dbHelper);
            _courseDataAccess = new CourseDataAccess(_dbHelper);
            _userDataAccess = new UserDataAccess(_dbHelper);
            // Setting up the DataGridView here
            dataGridView1.AutoGenerateColumns = false;
            // Clear existing columns
            dataGridView1.Columns.Clear();
            // Add columns with specific headers
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "StudentName", HeaderText = "Student Name", DataPropertyName = "StudentName" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "CourseName", HeaderText = "Course Name", DataPropertyName = "CourseName" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "RequestDate", HeaderText = "Request Date", DataPropertyName = "RequestDate" });
            // Setting the action button
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "Action";
            buttonColumn.Text = "Enroll";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);

            LoadEnrollments();
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadEnrollments()
        {
            List<Enrollment> enrollments = _enrollmentDataAccess.GetAllEnrollmentRequests();
            var displayEnrollments = new List<EnrollmentDisplay>();
            foreach (Enrollment enrollment in enrollments)
            {
                Course course = _courseDataAccess.GetAllCourses().FirstOrDefault(c => c.CourseID == enrollment.CourseID);
                Person user = _userDataAccess.GetUserById(enrollment.UserID);
                if (course != null && user != null)
                {
                    displayEnrollments.Add(new EnrollmentDisplay
                    {
                        EnrollmentID = enrollment.EnrollmentID,
                        CourseName = course.CourseName,
                        RequestDate = enrollment.RequestDate,
                        Status = enrollment.Status,
                        StudentName = user.Username,
                        CourseID = enrollment.CourseID,
                        UserID = enrollment.UserID

                    });
                }
                else
                {
                    MessageBox.Show($"Error loading enrollment with enrollment ID = {enrollment.EnrollmentID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dataGridView1.DataSource = displayEnrollments;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InstructorDashboard dashboard = new InstructorDashboard();
            this.Hide();
            dashboard.Show();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Action"].Index && e.RowIndex >= 0)
            {
                EnrollmentDisplay enrollmentDisplay = (EnrollmentDisplay)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                if (enrollmentDisplay.Status == "pending")
                {
                    // Get the Enrollment object based on the EnrollmentId.
                    Enrollment enrollment = _enrollmentDataAccess.GetAllEnrollmentRequests().FirstOrDefault(enrollment => enrollment.EnrollmentID == enrollmentDisplay.EnrollmentID);
                    if (dataGridView1.Rows[e.RowIndex].Cells["Action"].Value.ToString().ToLower() == "enroll")
                    {
                        enrollment.Status = "approved";
                        if (_enrollmentDataAccess.UpdateEnrollment(enrollment))
                        {
                            MessageBox.Show("Enrollment Approved", "Confirmation", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Error approving Enrollment", "Error", MessageBoxButtons.OK);
                        }

                    }
                    else if (dataGridView1.Rows[e.RowIndex].Cells["Action"].Value.ToString().ToLower() == "deny")
                    {
                        enrollment.Status = "rejected";
                        if (_enrollmentDataAccess.UpdateEnrollment(enrollment))
                        {
                            MessageBox.Show("Enrollment Rejected", "Confirmation", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Error rejecting Enrollment", "Error", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter either 'enroll' or 'deny'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadEnrollments();
                }
                else
                {
                    MessageBox.Show("This enrollment is not in a pending state.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Approve all logic
            if (dataGridView1.DataSource != null)
            {
                var enrollments = dataGridView1.DataSource as List<Enrollment>;
                foreach (var enrollment in enrollments)
                {
                    if (enrollment.Status != "approved")
                    {
                        enrollment.Status = "approved";
                        _enrollmentDataAccess.UpdateEnrollment(enrollment);
                    }
                }
                LoadEnrollments();
                MessageBox.Show("All enrollments are approved", "Confirmation", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("There are no enrollments to approve.", "Confirmation", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Reject all logic
            if (dataGridView1.DataSource != null)
            {
                var enrollments = dataGridView1.DataSource as List<Enrollment>;
                foreach (var enrollment in enrollments)
                {
                    if (enrollment.Status != "rejected")
                    {
                        enrollment.Status = "rejected";
                        _enrollmentDataAccess.UpdateEnrollment(enrollment);
                    }

                }
                LoadEnrollments();
                MessageBox.Show("All enrollments are rejected", "Confirmation", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("There are no enrollments to reject.", "Confirmation", MessageBoxButtons.OK);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            InstructorDashboard instructorDashboard = new InstructorDashboard();
            instructorDashboard.Show();
            this.Hide();
        }
        private void InstructorManageEnrollment_Load(object sender, EventArgs e)
        {
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
        }
    }
    public class EnrollmentDisplay
    {
        public int EnrollmentID { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
    }
}