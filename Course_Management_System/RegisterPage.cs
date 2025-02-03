using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace Course_Management_System
{
    public partial class RegisterPage : Form
    {
        private DatabaseHelper _dbHelper;
        private UserDataAccess _userDataAccess;
        public RegisterPage()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("localhost", "CourseManagementSystem", "root", "");
            _userDataAccess = new UserDataAccess(_dbHelper);
            this.WindowState = FormWindowState.Maximized;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Student student = new Student(username, password, email);
            if (_userDataAccess.AddStudent(student))
            {
                MessageBox.Show("User Created", "Confirmation", MessageBoxButtons.OK);
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error creating user", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage login = new LoginPage();
            login.Show();
            this.Hide();
        }
        private void RegisterPage_Load(object sender, EventArgs e)
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
    }
}