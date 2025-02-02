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
    public partial class LoginPage : Form
    {
        private DatabaseHelper _dbHelper;
        private UserDataAccess _userDataAccess;
        public LoginPage()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("localhost", "CourseManagementSystem", "root", "");
            _userDataAccess = new UserDataAccess(_dbHelper);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox4.Text; //Student username
            string password = textBox3.Text; //Student password

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Person user = _userDataAccess.GetUserByUsername(username);


            if (user != null && _userDataAccess.ValidateUser(password, user.Password))
            {
                if (user is Student)
                {
                    StdLoginForm stdForm = new StdLoginForm(user);
                    this.Hide();
                    stdForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid User Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text; //Instructor username
            string password = textBox1.Text; //Instructor password

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Person user = _userDataAccess.GetUserByUsername(username);

            if (user != null && _userDataAccess.ValidateUser(password, user.Password))
            {
                if (user is Instructor)
                {
                    InstructorDashboard dashboard = new InstructorDashboard();
                    this.Hide();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid User Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StartPage start = new StartPage();
            this.Hide();
            start.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegisterPage register = new RegisterPage();
            register.Show();
            this.Hide();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}