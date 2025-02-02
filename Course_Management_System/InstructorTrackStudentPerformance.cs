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
    public partial class InstructorTrackStudentPerformance : Form
    {
        private DatabaseHelper _dbHelper;
        private GradeDataAccess _gradeDataAccess;
        public InstructorTrackStudentPerformance()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("localhost", "CourseManagementSystem", "root", "");
            _gradeDataAccess = new GradeDataAccess(_dbHelper);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstructorDashboard dashboard = new InstructorDashboard();
            this.Hide();
            dashboard.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = _gradeDataAccess.GetGradesByStudent(textBox1.Text);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TODO: view detailed student performance
        }

        private void InstructorTrackStudentPerformance_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}