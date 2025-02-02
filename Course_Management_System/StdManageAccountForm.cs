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
    public partial class StdManageAccountForm : Form
    {
        private DatabaseHelper _dbHelper;
        private UserDataAccess _userDataAccess;
        private Student _student;
        public StdManageAccountForm(Person student)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("localhost", "CourseManagementSystem", "root", "");
            _userDataAccess = new UserDataAccess(_dbHelper);
            _student = (Student)student;
            LoadUserInformation();
        }
        private void LoadUserInformation()
        {
            textBox1.Text = _student.Username;
            textBox2.Text = _student.Email;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            StdLoginForm stdLogin = new StdLoginForm(_student);
            this.Hide();
            stdLogin.Show();
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
        private void button2_Click(object sender, EventArgs e)
        {
            // Update the student account information
            string newUsername = textBox1.Text;
            string newEmail = textBox2.Text;
            string newPassword = textBox3.Text;
            if (!string.IsNullOrEmpty(newPassword))
            {
                _student.Password = newPassword;
            }
            _student.Username = newUsername;
            _student.Email = newEmail;
            if (_userDataAccess.UpdateStudent(_student))
            {
                MessageBox.Show("Account Updated Successfully", "Confirmation", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error updating account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StdManageAccountForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}