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
    public partial class Std_p : Form
    {
        public Std_p()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Std_info values (@Name,@Id,@CGPA)", conn);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Id", textBox2.Text);
            cmd.Parameters.AddWithValue("@CGPA", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data inserted successfully");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Std_info", conn);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            //sda.Fill(dt);
            conn.Close();

            dataGridView1.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Std_info set Name = @Name,CGPA  =@CGPA where Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Id", textBox2.Text);
            cmd.Parameters.AddWithValue("@CGPA", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data updated successfully");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete Std_info where Id  =@Id", conn);
            cmd.Parameters.AddWithValue("@Id", textBox2.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Delated successfully");

        }
    }
}
