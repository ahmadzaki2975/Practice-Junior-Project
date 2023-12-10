using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_Junior_Project
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void RegisterUser()
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            MessageBox.Show(username + "\n" + password);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }
    }
}
