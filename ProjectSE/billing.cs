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
    public partial class billing : Form
    {
        public billing()
        {
            InitializeComponent();
            DisplayProduct();
            GetCustomers();

        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nadun\OneDrive\Documents\PetShopDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void GetCustomers()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select CustID from CustomerTable", conn);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustID", typeof(int));
            dt.Load(Rdr);
            comboBox1.ValueMember = "CustID";
            comboBox1.DataSource = dt;
            conn.Close();
        }

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

        private void GetCustName()
        {
            /* conn.Open();
             string Query = "SELECT * FROM CustomerTable WHERE CustID ='" + comboBox1.SelectedValue.ToString + "' ";
             SqlCommand cmd = new SqlCommand(Query, conn);
             DataTable dt = new DataTable();
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             sda.Fill(dt);

             foreach (DataRow dr in dt.Rows)
             {
                 textBox4.Text = dr["CustName"].ToString();
             }
             conn.Close();*/
        }

        int Stock = 0;
        private void UpdateStock()
        {
            try
            {
                int newQty = Stock - Convert.ToInt32(textBox7.Text);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update ProductTable set PrQty=@PQ where PrName=@Pname", conn);
                cmd.Parameters.AddWithValue("@PQ", newQty);
                cmd.Parameters.AddWithValue("@Pname", textBox5.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                DisplayProduct();
            }
            catch
            {
                MessageBox.Show("Ex.Message");
            }

        }

        int n = 0, GrdTotal = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || Convert.ToInt32(textBox7.Text) > Stock)
            {
                MessageBox.Show("No Enough In House");
            }
            else if (textBox7.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Missng Information");
            }
            else
            {
                int total = Convert.ToInt32(textBox7.Text) * Convert.ToInt32(textBox6.Text);
                DataGridViewRow NewRow = new DataGridViewRow();
                NewRow.CreateCells(dataGridView2);
                NewRow.Cells[0].Value = n + 1;
                NewRow.Cells[0].Value = textBox5.Text;
                NewRow.Cells[0].Value = textBox7.Text;
                NewRow.Cells[0].Value = textBox6.Text;
                NewRow.Cells[0].Value = textBox6.Text;
                GrdTotal = GrdTotal + total;
                dataGridView2.Rows.Add(NewRow);
                n++;
                label19.Text = "Rs" + GrdTotal;
                UpdateStock();
                Reset();
            }
        }


        public void Reset()
        {
            textBox5.Text = "";
            textBox7.Text = "";
            Stock = 0;

        }


        private void label5_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {
        }

        private void label17_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GetCustName();
        }


        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label17_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Reset();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Products obj = new Products();
            obj.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Employees obj = new Employees();
            obj.Show();
            this.Hide();
        }
    }
}
