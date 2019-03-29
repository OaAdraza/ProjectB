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
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }
        int ID;
        public Form23(int id)
        {
            ID = id;
            InitializeComponent();

        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form23_Load(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            SqlCommand exe = new SqlCommand("select * from AssessmentComponent where Id = '" + ID + "'", connection);
            var read = exe.ExecuteReader();
            read.Read();
            txtName.Text = read[1].ToString();
      
            cmbRubricId.Text = read[2].ToString();

            txtTotalMarks.Text = read[3].ToString();
            cmbAssessmentId.Text = read[5].ToString();

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
            cmbRubricId.DisplayMember = "id";
            cmbRubricId.DataSource = tbl;

            SqlConnection connn = new SqlConnection(conn);
            connn.Open();
            SqlCommand scmdi = new SqlCommand("select id from Assessment", connn);
            SqlDataReader reade;
            reade = scmdi.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Columns.Add("Id", typeof(string));
            tb.Load(reade);
            cmbAssessmentId.ValueMember = "id";
            cmbAssessmentId.DisplayMember = "id";
            cmbAssessmentId.DataSource = tb;
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm5 = new Form1();
            this.Hide();
            frm5.Show();
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
            SqlConnection connection = new SqlConnection(conn);

            SqlCommand exe = new SqlCommand("Update AssessmentComponent  set Name='" + txtName.Text.ToString() + "',RubricId='"+ iddno + "',TotalMarks='"+txtTotalMarks.Text.ToString()+"',DateUpdated='"+dtUpdate.Value.Date+ "',AssessmentId='"+cmbAssessmentId.Text.ToString()+"' where id ='" + ID + "'", connection);
            connection.Open();
            exe.CommandType = CommandType.Text;
            exe.ExecuteNonQuery();
            MessageBox.Show("UPdated Successfully!!");

            Form22 frm6 = new Form22();
            this.Hide();
            frm6.Show();
        }
    }
}
