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
    public partial class StdEnrollmentForm : Form
    {
        public StdEnrollmentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StdCourseCatalogForm stdcourse = new StdCourseCatalogForm();
            this.Hide();
            stdcourse.Show();
        }
    }
}
