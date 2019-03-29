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
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";


        private void Form21_Load(object sender, EventArgs e)
        {
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
            cmbRubricId.Text = "select here";
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            SqlCommand exe = new SqlCommand("select Max(id) from Assessment", connection);
            var read = exe.ExecuteReader();
            read.Read();
            cmbAssessmentId.Text = read[0].ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f2 = new Form1();
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connn = new SqlConnection(conn);
            connn.Open();
            string idd = "Select id from Rubric where Details='" + cmbRubricId.Text.ToString() + "'";
            SqlCommand cmdd = new SqlCommand(idd, connn);
            var rd = cmdd.ExecuteReader();
            rd.Read();
            int iddno = rd.GetInt32(0);

            SqlConnection con = new SqlConnection(conn);
            con.Open();
            string id = "Select Max(id) from Assessment ";
            SqlCommand cmd = new SqlCommand(id, con);
            var r = cmd.ExecuteReader();
            r.Read();
            int idno = r.GetInt32(0);

            string Query = "insert into AssessmentComponent(Name ,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) values('" + txtName.Text.ToString() + "','"+ iddno + "','"+txtTotalMarks.Text.ToString()+"','" + dtCreated.Value.Date + "','" + dtCreated.Value.Date + "','"+ idno + "')";
            SqlConnection myconnection2 = new SqlConnection(conn);
            SqlCommand MyCommand2 = new SqlCommand(Query, myconnection2);
            SqlDataReader MyReader2;
            myconnection2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data inserted Successfully!");
            Form21 frm5 = new Form21();
            this.Hide();
            frm5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form22 frm5 = new Form22();
            this.Hide();
            frm5.Show();
        }
    }
}
