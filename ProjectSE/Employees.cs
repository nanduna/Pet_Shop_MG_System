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


namespace ProjectSE
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            DisplayEmployees();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nadun\OneDrive\Documents\PetShopDB.mdf;Integrated Security=True;Connect Timeout=30");


        private void label11_Click(object sender, EventArgs e)
        {

        }



        private void DisplayEmployees()
        {
            conn.Open();
            string Query = "SELECT * FROM EmployeeTable";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

        }

        private void clear()
        {
            EmpName.Text = "";
            EmpAddress.Text = "";
            EmpPhone.Text = "";
            EmpPassword.Text = "";
        }

        int key = 0;
        private void AveBtn_Click(object sender, EventArgs e)
        {
            if (EmpName.Text == "" || EmpAddress.Text == "" || EmpPhone.Text == "" || EmpPassword.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeTable (EmpName, EmpAdd, EmpDOB, EmpPhone, EmpPass)\r\nVALUES (@EN, @EA, @ED, @EP, @EPa);\r\n", conn);
                    cmd.Parameters.AddWithValue("@EN", EmpName.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddress.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpDob.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhone.Text);
                    cmd.Parameters.AddWithValue("@Epa", EmpPassword.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added");
                    conn.Close();
                    DisplayEmployees();
                    clear();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void emp_Paint(object sender, PaintEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*EmpName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            EmpAddress.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            EmpDob.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            EmpPhone.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            EmpPassword.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            if (EmpName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }*/
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (EmpName.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE EmployeeTable SET EmpAdd=@EA, EmpDOB=@ED, EmpPhone=@EP, EmpPass=@EPa WHERE EmpName =@EN", conn);
                    cmd.Parameters.AddWithValue("@EN", EmpName.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddress.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpDob.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhone.Text);
                    cmd.Parameters.AddWithValue("@Epa", EmpPassword.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    conn.Close();
                    DisplayEmployees();
                    clear();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

            if (EmpName.Text == "")
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
                    cmd.CommandText = "delete from [EmployeeTable] where EmpName = '" + EmpName.Text + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    EmpName.Text = "";
                    EmpAddress.Text = "";
                    EmpPhone.Text = "";
                    EmpPassword.Text = "";
                    DisplayEmployees();
                    MessageBox.Show("Data Delete Successfully");

                    MessageBox.Show("Your Data Deleted Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }



        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Products obj = new Products();
            obj.Show();
            this.Hide();
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

        private void label5_Click(object sender, EventArgs e)
        {
            billing obj = new billing();
            obj.Show();
            this.Hide();
        }
    }
}
