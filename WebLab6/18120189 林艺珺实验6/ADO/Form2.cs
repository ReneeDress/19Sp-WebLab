using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebLab6
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\jxgl.mdf;Integrated Security=True;Connect Timeout=30";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from [User]";
            SqlDataReader myreader = cmd.ExecuteReader();

            bool isTrue = false;
            while(myreader.Read())
            {
                if (myreader["LoginName"].ToString() == username && myreader["LoginPwd"].ToString() == password )
                {
                    isTrue = true;
                }
            }

            if (isTrue == true)
            {
                Data fm = new Data();
                this.Hide();
                fm.ShowDialog();
                this.Dispose();
            }

            conn.Close();
        }
    }
}
