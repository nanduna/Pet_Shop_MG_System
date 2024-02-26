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
using System.Xml.Linq;


namespace ProjectSE
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            DisplayProduct();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nadun\OneDrive\Documents\PetShopDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayProduct()
        {
            conn.Open();
            string Query = "SELECT * FROM ProductTable";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

        }

        private void clear()
        {

            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void Products_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.SelectedIndex == -1 || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO ProductTable (PrName, PrCat, PrQty, PrPrice) VALUES (@PN, @PC, @PQ, @PP);", conn);
                    cmd.Parameters.AddWithValue("@PN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@PC", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PQ", textBox3.Text);
                    cmd.Parameters.AddWithValue("@PP", textBox4.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Added");
                    conn.Close();
                    DisplayProduct();
                    clear();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE ProductTable SET PrName=@PN, PrCat=@PC, PrQty=@PQ, PrPrice=@PP WHERE PrName =@PN", conn);
                    cmd.Parameters.AddWithValue("@PN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@PC", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PQ", textBox3.Text);
                    cmd.Parameters.AddWithValue("@PP", textBox4.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Added");
                    conn.Close();
                    DisplayProduct();
                    clear();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from [ProductTable] where PrName = '" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    textBox1.Text = "";
                    comboBox1.SelectedIndex = 0;
                    textBox3.Text = "";
                    textBox4.Text = "";
                    MessageBox.Show("Data Delete Successfully");

                    MessageBox.Show("Your Data Deleted Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }


        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees obj = new Employees();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            billing obj = new billing();
            obj.Show();
            this.Hide();
        }
    }
}
