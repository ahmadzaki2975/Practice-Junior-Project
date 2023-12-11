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

        private void LoadData()
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

        private void InsertData()
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
                    LoadData();
                }
                else if (statusCode == 401)
                {
                    throw new Exception("Username already exist");
                }
                else
                {
                    throw new Exception("An error occured");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void UpdateData()
        {
            if (row == null)
            {
                MessageBox.Show("Select a row to edit");
                return;
            }
            string username = row.Cells["username"].Value.ToString();
            string password = tbPassword.Text;
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                string sql = "SELECT * FROM edit_user(@in_username, @in_password)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@in_username", username);
                cmd.Parameters.AddWithValue("@in_password", password);

                int statusCode = (int)cmd.ExecuteScalar();

                if (statusCode == 200)
                {
                    MessageBox.Show("Update data success", "Success");
                    LoadData();
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void DeleteData()
        {
            if (row == null)
            {
                MessageBox.Show("Select row to delete");
            }
            try
            {
                string username = row.Cells["username"].Value.ToString();
                conn = new NpgsqlConnection(connString);
                string sql = "SELECT * FROM delete_user(@in_username)";

                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@in_username", username);

                int statusCode = (int)cmd.ExecuteScalar();
                if (statusCode == 200)
                {
                    MessageBox.Show($"Deleted user with username {username}", "Success");
                    LoadData();
                }
                else if (statusCode == 404)
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                row = dataGridView1.Rows[e.RowIndex];
                tbUsername.Text = row.Cells["username"].Value.ToString();
                tbPassword.Text = row.Cells["password"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
    }
}