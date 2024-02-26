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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;

namespace ProjectSE
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nadun\OneDrive\Documents\PetShopDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName, Password;
            userName = textBox1.Text;
            Password = textBox2.Text;

            try
            {
                conn.Open();
                String quarry = "SELECT * FROM EmployeeTable WHERE EmpName = '" + textBox1.Text + "' AND EmpPass = '" + textBox2.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(quarry, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    userName = textBox1.Text;
                    Password = textBox2.Text;

                    Homes wellcome = new Homes();
                    wellcome.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid username or Password");
                    textBox1.Clear();
                    textBox2.Clear();

                    textBox1.Focus();

                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
