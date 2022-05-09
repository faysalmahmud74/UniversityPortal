using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT name, course FROM teacher_info WHERE Id=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", textBox1.Text);

            DataTable dt = new DataTable();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            std_dashbord sd1 = new std_dashbord();
            sd1.Show();
        }
    }
}
