using RestSharp;
using Npgsql;

namespace Practice_Junior_Project
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection conn;
        private string connString = "Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=postgres";   

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoginUser()
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            
            conn = new NpgsqlConnection(connString);

            if(username == "" || password == "")
            {
                MessageBox.Show("Username or password cannot be empty", "Error");
                return;
            }   

            try
            {
                conn.Open();
                string sql = "SELECT login_user(@in_username, @in_password) AS http_status_code;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@in_username", username);
                cmd.Parameters.AddWithValue("@in_password", password);

                int httpStatusCode = (int)cmd.ExecuteScalar();

                if(httpStatusCode == 200)
                {
                    MessageBox.Show("Login successful");
                }
                else if(httpStatusCode == 401)
                {
                    throw new Exception("Username or password is incorrect");
                }
                else if(httpStatusCode == 500)
                {
                    throw new Exception("Internal server error");
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginUser();
        }

        private void btnToRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register(this);
            register.Show();
            Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}