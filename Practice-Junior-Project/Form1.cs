using RestSharp;

namespace Practice_Junior_Project
{
    public partial class Form1 : Form
    {
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
            Register register = new Register();
            register.Show();
            //Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}