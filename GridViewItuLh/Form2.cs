using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridViewItuLh
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        public static string GenerateQR(string username)
        {
            return $"#{username}";
        }

        //public static string GenerateQR(string username, string password, out Bitmap bitmap)
        //{

        //}

        private void Form2_Load(object sender, EventArgs e)
        {
            lbUsername.Text = form1.Row.Cells["username"].Value.ToString();
        }

    }
}
