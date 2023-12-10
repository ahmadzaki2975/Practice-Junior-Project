using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

            if(username == "" || password == "")
            {
                MessageBox.Show("Username or password cannot be empty", "Error");
                return;
            }

            if(username.Length < 4 || password.Length < 4)
            {
                MessageBox.Show("Username or password must be at least 4 characters long", "Error");
                return;
            }
            
            try
            {
                conn.Open();
                string sql = "SELECT register_user(@in_username, @in_password) AS http_status_code;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                // Add params
                cmd.Parameters.AddWithValue("@in_username", username);
                cmd.Parameters.AddWithValue("@in_password", password);
                int httpStatusCode = (int)cmd.ExecuteScalar();

                if (httpStatusCode == 201)
                {
                    MessageBox.Show("User registered successfully");
                }
                else if (httpStatusCode == 409)
                {
                    MessageBox.Show("Username already exists");
                }
                else if (httpStatusCode == 500)
                {
                    MessageBox.Show("An error occurred during registration");
                }
                else
                {
                    MessageBox.Show("Unknown error code");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }
    }
}
