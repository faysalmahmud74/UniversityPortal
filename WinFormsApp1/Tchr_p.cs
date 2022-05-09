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
    public partial class Tchr_p : Form
    {
        public Tchr_p()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update teacher_info set name = @name,course = @course where id = @id", conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@id", textBox2.Text);
            cmd.Parameters.AddWithValue("@course", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data updated successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into teacher_info values (@name,@id,@course)", conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@id", textBox2.Text);
            cmd.Parameters.AddWithValue("@course", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data inserted successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete teacher_info where id  =@id", conn);
            cmd.Parameters.AddWithValue("@id", textBox2.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Delated successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM teacher_info", conn);
            DataTable dt = new DataTable();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();

            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
