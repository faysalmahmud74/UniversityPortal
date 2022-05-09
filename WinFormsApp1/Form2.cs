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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static SqlConnection con = new SqlConnection("Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");
        static SqlCommand cmd;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Authenticate() == false)
            {
                MessageBox.Show("Do not keep any field empty");
                return;
            }
            string query = "INSERT INTO LogIn VALUES(@username,@password,@confirmpassword)";
            con.Open();
            cmd = new SqlCommand(query, con);

            //Adding parameters
            cmd.Parameters.Add("@username", SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = textBox1.Text;

            cmd.Parameters.Add("@password", SqlDbType.VarChar);
            cmd.Parameters["@password"].Value = textBox2.Text;

            cmd.Parameters.Add("@confirmpassword", SqlDbType.VarChar);
            cmd.Parameters["@confirmpassword"].Value = textBox3.Text;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully register");
            con.Close();


            bool Authenticate()
            {
                if (
                    string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text)
                    )
                {
                    return false;
                }
                else
                    return true;
               
            }
        }
    }
}
