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
        public LoginPage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StdLoginForm stdLogin = new StdLoginForm();
            this.Hide();
            stdLogin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InstructorDashboard dashboard = new InstructorDashboard();
            this.Hide();
            dashboard.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartPage start = new StartPage();
            this.Hide();
            start.Show();
        }
    }
}
