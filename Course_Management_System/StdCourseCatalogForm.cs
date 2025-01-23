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
    public partial class StdCourseCatalogForm : Form
    {
        public StdCourseCatalogForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StdLoginForm stdlogin = new StdLoginForm();
            this.Hide();
            stdlogin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StdEnrollmentForm stdenroll = new StdEnrollmentForm();
            this.Hide();
            stdenroll.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
