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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form8_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand scmd = new SqlCommand("select name,id from clo", con);
            SqlDataReader reader;
            reader = scmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("Id", typeof(string));
            tbl.Load(reader);
            clocmbox.ValueMember = "id";
            clocmbox.DisplayMember = "Name";
            clocmbox.DataSource = tbl;
            clocmbox.Text = "select here";
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            string id = "Select * from clo where name='"+ clocmbox.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(id,con);
            var r = cmd.ExecuteReader();
            r.Read();
            int idno = r.GetInt32(0);

            string Query = "insert into Rubric(Details,CloId) values('" + txtDetail.Text.ToString() + "','" + idno + "')";
            SqlConnection myconnection2 = new SqlConnection(conn);
            SqlCommand MyCommand2 = new SqlCommand(Query, myconnection2);
            SqlDataReader MyReader2;
            myconnection2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data inserted Successfully!");
            Form8 frm8 = new Form8();
            this.Hide();
            frm8.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 frm9 = new Form9();
            this.Hide();
            frm9.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void clocmbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
