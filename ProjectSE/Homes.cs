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
    public partial class Homes : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nadun\OneDrive\Documents\PetShopDB.mdf;Integrated Security=True;Connect Timeout=30");
        public Homes()
        {
            InitializeComponent();
            countDogs();
            countCats();
            countBirds();
        }

        private void countDogs()
        {
            string cat = "Dogs";
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT (*) FROM ProductTable WHERE PrCat= '" + cat + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label12.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }

        private void countCats()
        {
            string cat = "Cats";
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT (*) FROM ProductTable WHERE PrCat= '" + cat + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label14.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }

        private void countBirds()
        {
            string cat = "Birds";
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT (*) FROM ProductTable WHERE PrCat= '" + cat + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label13.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Homes_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Products wellcome = new Products();
            wellcome.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
            billing wellcome = new billing();
            wellcome.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Employees obj = new Employees();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
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
    }
}
