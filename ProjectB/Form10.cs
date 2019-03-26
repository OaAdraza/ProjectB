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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        int ID;
        public Form10(int id)
        {
            ID = id;
            InitializeComponent();

        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";


        private void Form10_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            SqlCommand exe = new SqlCommand("select * from Rubric where Id = '" + ID + "'", connection);
            var read = exe.ExecuteReader();
            read.Read();
          
            txtDetail.Text = read[1].ToString();
            clocmbox.Text = read[2].ToString();

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
        }

        private void txtDetail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            string id = "Select * from clo where name='" + clocmbox.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(id, con);
            var r = cmd.ExecuteReader();
            r.Read();
            int idno = r.GetInt32(0);
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand exe = new SqlCommand("Update RUbric set Details = '" + txtDetail.Text.ToString() + "',CloId = '" + idno + "' where id='"+ID+"' ", connection);
            connection.Open();
            exe.CommandType = CommandType.Text;
            exe.ExecuteNonQuery();
            MessageBox.Show("UPdated Successfully!!");
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
    }
}
