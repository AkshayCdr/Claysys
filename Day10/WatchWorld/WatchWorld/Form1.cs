using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WatchWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void ContactUS_Click(object sender, EventArgs e)
        {
            ContactUs contactUs = new ContactUs();
            contactUs.Show();
        }

        private void Registration_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration(); 
            registration.Show();
        }
    }
}
