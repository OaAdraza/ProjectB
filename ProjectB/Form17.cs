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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        int ID;
        public Form17(int id)
        {
            ID = id;
            InitializeComponent();

        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form17_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            SqlCommand exe = new SqlCommand("select * from RubricLevel where Id = '" + ID + "'", connection);
            var read = exe.ExecuteReader();
            read.Read();
            cmbRubricId.Text = read[1].ToString();
            txtDetail.Text = read[2].ToString();
            cmbMeasurementLevel.Text = read[3].ToString();
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand scmd = new SqlCommand("select id,details from rubric", con);
            SqlDataReader reader;
            reader = scmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Details", typeof(string));
            tbl.Columns.Add("Id", typeof(string));
            tbl.Load(reader);
            cmbRubricId.ValueMember = "id";
            cmbRubricId.DisplayMember = "Details";
            cmbRubricId.DataSource = tbl;
        



        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            string id = "Select id from Rubric where Details='" + cmbRubricId.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(id, con);
            var r = cmd.ExecuteReader();
            r.Read();
            int idno = r.GetInt32(0);
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand exe = new SqlCommand("Update RubricLevel  set RubricId='"+ idno + "' , Details='"+txtDetail.Text.ToString()+"',MeasurementLevel='"+cmbMeasurementLevel.Text.ToString()+ "' where Id='"+ID+"'",connection);
            connection.Open();
            exe.CommandType = CommandType.Text;
            exe.ExecuteNonQuery();
            MessageBox.Show("UPdated Successfully!!");
            Form16 frm3 = new Form16();
            this.Hide();
            frm3.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm3 = new Form1();
            this.Hide();
            frm3.Show();
        }
    }
}
