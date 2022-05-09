using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //static SqlConnection con = new SqlConnection("Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");
        //static SqlCommand cmd;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SU83VOT;Initial Catalog=LogIn;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from multi_login where Username='" + textBox1.Text + "'and Password= '" + textBox2.Text + "' ", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            string cmbItemValue = comboBox2.SelectedItem.ToString();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["usertype"].ToString() == cmbItemValue)
                        if (dt.Rows[i]["usertype"].ToString() == cmbItemValue)

                        {
                            MessageBox.Show("You are login as" + dt.Rows[i][2]);

                            if (comboBox2.SelectedIndex == 0)
                            {
                                Form3 f3 = new Form3();
                                f3.Show();
                                this.Hide();
                            }

                            else
                            {
                                this.Hide();
                                std_dashbord sd = new std_dashbord();
                                sd.Show();
                            }

                        }
                }
            }
            else
            {
                MessageBox.Show("Error Login");
            }

            /*bool isUserOk = false, isPassOk = false;
            if (Authenticate() == false)
            {
                MessageBox.Show("Require fields can not be empty");
                return;
            }

            string query = "SELECT * FROM LogIn WHERE username=@username";
            con.Open();
            cmd = new SqlCommand(query, con);

            //adding parameter
            cmd.Parameters.Add("@username", SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = textBox1.Text;

            SqlDataReader sda = cmd.ExecuteReader();
            if (sda.HasRows)
            {
                isUserOk = true;
            }
            con.Close();

            con.Open();

            query = "SELECT * FROM LogIn WHERE username=@username and password=@password";

            cmd = new SqlCommand(query, con);

            //adding parameter
            cmd.Parameters.Add("@username", SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = textBox1.Text;

            cmd.Parameters.Add("@password", SqlDbType.VarChar);
            cmd.Parameters["@password"].Value = textBox2.Text;

            sda = cmd.ExecuteReader();
            if (sda.HasRows)
            {
                isPassOk = true;
            }

            if (isUserOk == false)
            {
                MessageBox.Show("User doesn't exist");
            }
            else if (isUserOk == true && isPassOk == false)
            {
                MessageBox.Show("Your password is incorrect");
            }
            else
            {
                this.Hide();
                Form3 f3 = new Form3();
                f3.Show();
            }
            con.Close();


            
        }

        bool Authenticate()
        {
            if (
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text)
                )
            {
                return false;
            }
            else
                return true;
            */
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
            //textBox2.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
