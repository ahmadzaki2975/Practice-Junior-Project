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

        private void Login()
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Login successful");
            }
            else
            {

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
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