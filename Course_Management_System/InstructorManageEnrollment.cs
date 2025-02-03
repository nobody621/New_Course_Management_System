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
        public InstructorManageEnrollment()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("localhost", "CourseManagementSystem", "root", "");
            _enrollmentDataAccess = new EnrollmentDataAccess(_dbHelper);
            // Setting up the DataGridView here
            dataGridView1.AutoGenerateColumns = false;
            // Clear existing columns
            dataGridView1.Columns.Clear();
            // Add columns with specific headers
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "EnrollmentID", HeaderText = "Enrollment ID", DataPropertyName = "EnrollmentID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "UserID", HeaderText = "User ID", DataPropertyName = "UserID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "CourseID", HeaderText = "Course ID", DataPropertyName = "CourseID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "RequestDate", HeaderText = "Request Date", DataPropertyName = "RequestDate" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status" });
            dataGridView1.DataSource = _enrollmentDataAccess.GetAllEnrollmentRequests();
            this.WindowState = FormWindowState.Maximized;

        }

        private void LoadEnrollments()
        {

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
                dataGridView1.DataSource = _enrollmentDataAccess.GetAllEnrollmentRequests(); ;
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
                dataGridView1.DataSource = _enrollmentDataAccess.GetAllEnrollmentRequests(); ;
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
    }
}