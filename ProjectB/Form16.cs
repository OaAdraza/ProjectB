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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }
        public int row;
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form16_Load(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand command = new SqlCommand("select * from RubricLevel", con);

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form15 f = new Form15();
            this.Hide();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();

            int id = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());

            SqlCommand command = new SqlCommand("delete from RubricLevel where Id = '" + id + "'", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Deleted sucesfully!");
            Form16 frm = new Form16();
            this.Hide();
            
            frm.Show();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();

            int id = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
            Form17 frm = new Form17(id);
            this.Hide();

            frm.Show();
        }
    }
}
