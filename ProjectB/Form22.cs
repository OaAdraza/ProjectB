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
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        public int row;
        private void button1_Click(object sender, EventArgs e)
        {
            Form21 frm5 = new Form21();
            this.Hide();
            frm5.Show();
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand command = new SqlCommand("select * from AssessmentComponent", con);

                command.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(command);

                DataSet ds = new DataSet();

                da.Fill(ds, "ss");

                AssessmentDetail.DataSource = ds.Tables["ss"];

            }

            catch

            {

                MessageBox.Show("No Record Found");

            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();

            int id = int.Parse(AssessmentDetail.Rows[row].Cells[0].Value.ToString());

            SqlCommand command = new SqlCommand("delete from AssessmentComponent where Id = '" + id + "'", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Deleted sucesfully!");
            Form22 frm = new Form22();
            this.Hide();

            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();

            int id = int.Parse(AssessmentDetail.Rows[row].Cells[0].Value.ToString());
            Form23 frm = new Form23(id);
            this.Hide();

            frm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();

            frm.Show();
        }
    }
}
