namespace Course_Management_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StdLoginForm stdLogin = new StdLoginForm();
            this.Hide();
            stdLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           InstructorDashboard dashboard = new InstructorDashboard();
            this.Hide();
            dashboard.Show();
        }
    }
}
