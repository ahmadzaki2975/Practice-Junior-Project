using Npgsql;
using System.Data;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace GridViewItuLh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connString = "Host=localhost;Port=5433;Database=postgres;Username=postgres;Password=postgres";
        NpgsqlConnection conn;
        public DataTable dt;
        private DataGridViewRow row;


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                string sql = "SELECT * FROM users;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = dt;
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string username = tbPassword.Text;
            string password = tbPassword.Text;

            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                string sql = "SELECT * FROM register_user(@username, @password);";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int statusCode = (int)cmd.ExecuteScalar();

                if (statusCode == 201)
                {
                    MessageBox.Show("Insert user success");
                }
                else if (statusCode == 401)
                {
                    throw new Exception("Username already exist");
                }
                else
                {
                    throw new Exception("An error occured");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}