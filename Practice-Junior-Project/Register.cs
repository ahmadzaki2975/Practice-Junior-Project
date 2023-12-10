using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Practice_Junior_Project
{
    public partial class Register : Form
    {
        private NpgsqlConnection conn;
        private string connString = "Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=postgres";
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
            //MessageBox.Show(username + "\n" + password);

            conn = new NpgsqlConnection(connString);
            
            try
            {
                conn.Open();
                conn.Close();
                MessageBox.Show("Connection successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }
    }
}
