using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Management_System
{
    public partial class StdSubmitAssignmentForm : Form
    {
        private DatabaseHelper _dbHelper;
        private AssignmentDataAccess _assignmentDataAccess;
        private SubmissionDataAccess _submissionDataAccess;
        private CourseDataAccess _courseDataAccess;
        private Student _student;
        private string _filePath;

        public StdSubmitAssignmentForm(Person student)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("localhost", "CourseManagementSystem", "root", "");
            _assignmentDataAccess = new AssignmentDataAccess(_dbHelper);
            _submissionDataAccess = new SubmissionDataAccess(_dbHelper);
            _courseDataAccess = new CourseDataAccess(_dbHelper);
            _student = (Student)student;
            // Setting up the DataGridView here
            dataGridView1.AutoGenerateColumns = false;
            // Clear existing columns
            dataGridView1.Columns.Clear();
            // Add columns with specific headers
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "CourseName", HeaderText = "Course Name", DataPropertyName = "CourseName" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "AssignmentTitle", HeaderText = "Assignment Title", DataPropertyName = "AssignmentTitle" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "DueDate", HeaderText = "Due Date", DataPropertyName = "DueDate" });
            LoadAssignments();
            this.WindowState = FormWindowState.Maximized;

        }
        private void LoadAssignments()
        {
            List<Enrollment> enrollments = new EnrollmentDataAccess(_dbHelper).GetAllEnrollmentRequests();
            enrollments = enrollments.Where(enrollment => enrollment.UserID == _student.UserID && enrollment.Status == "approved").ToList();
            List<Assignment> assignments = new List<Assignment>();
            foreach (Enrollment enrollment in enrollments)
            {
                List<Assignment> courseAssignments = _assignmentDataAccess.GetAllAssignments().Where(assignment => assignment.CourseID == enrollment.CourseID).ToList();
                assignments.AddRange(courseAssignments);
            }

            // Create a list to show only specific information in UI.
            List<AssignmentDisplay> displayAssignments = new List<AssignmentDisplay>();
            foreach (Assignment assignment in assignments)
            {
                Course course = _courseDataAccess.GetAllCourses().FirstOrDefault(course => course.CourseID == assignment.CourseID);
                displayAssignments.Add(new AssignmentDisplay
                {
                    AssignmentTitle = assignment.Title,
                    DueDate = assignment.DueDate,
                    CourseName = course.CourseName,
                    AssignmentId = assignment.AssignmentID

                });
            }
            dataGridView1.DataSource = displayAssignments;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StdLoginForm stdLogin = new StdLoginForm(_student);
            this.Hide();
            stdLogin.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _filePath = openFileDialog.FileName;
                MessageBox.Show("File Uploaded", "Confirmation", MessageBoxButtons.OK);
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            //Get selected assignment id
            if (dataGridView1.SelectedRows.Count > 0)
            {
                AssignmentDisplay selectedAssignment = (AssignmentDisplay)dataGridView1.SelectedRows[0].DataBoundItem;
                Submission submission = new Submission()
                {
                    AssignmentID = selectedAssignment.AssignmentId,
                    UserID = _student.UserID,
                    SubmissionDate = DateTime.Now,
                    FilePath = _filePath
                };
                if (_submissionDataAccess.AddSubmission(submission))
                {
                    MessageBox.Show("Assignment Submitted", "Confirmation", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Error submitting assignment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Select a assignment to submit", "Confirmation", MessageBoxButtons.OK);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void StdSubmitAssignmentForm_Load(object sender, EventArgs e)
        {

        }
    }
    public class AssignmentDisplay
    {
        public string CourseName { get; set; }
        public string AssignmentTitle { get; set; }
        public DateTime DueDate { get; set; }
        public int AssignmentId { get; set; }
    }
}