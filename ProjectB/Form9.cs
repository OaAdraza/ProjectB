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


namespace ProjectB
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        public int row;
        private void Form9_Load(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand command = new SqlCommand("select * from Rubric", con);

                command.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(command);

                DataSet ds = new DataSet();

                da.Fill(ds, "ss");

                dataGridView1.DataSource = ds.Tables["ss"];

            }

            catch

            {

                MessageBox.Show("No Record Found");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();

            int id = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());

            SqlCommand command = new SqlCommand("delete from Rubric where Id = '" + id + "'", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Deleted sucesfully!");
            this.Hide();
            Form9 frm9 = new Form9();
            frm9.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();

            int id = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
            Form10 frm10 = new Form10(id);
            this.Hide();
            frm10.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
