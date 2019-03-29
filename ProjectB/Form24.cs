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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form24_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand scmd = new SqlCommand("select id,Name from AssessmentComponent", con);
            SqlDataReader reader;
            reader = scmd.ExecuteReader();
            DataTable tbl = new DataTable();
           tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("Id", typeof(string));
            tbl.Load(reader);
            cmbAssComponentId.ValueMember = "id";
            cmbAssComponentId.DisplayMember = "Name";
            cmbAssComponentId.DataSource = tbl;
            cmbAssComponentId.Text = "select here";


            SqlConnection connecion = new SqlConnection(conn);
            connecion.Open();
            SqlCommand scmdi = new SqlCommand("select id ,Details from RubricLevel", connecion);
            SqlDataReader reade;
            reade = scmdi.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Columns.Add("Details", typeof(string));
            tb.Columns.Add("Id", typeof(string));
            tb.Load(reade);
            cmbRubricLevelId.ValueMember = "id";
            cmbRubricLevelId.DisplayMember = "Details";
            cmbRubricLevelId.DataSource = tb;
            cmbRubricLevelId.Text = "select here";

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            SqlCommand scm = new SqlCommand("select id,RegistrationNumber from Student", connection);
            SqlDataReader read;
            read = scm.ExecuteReader();
            DataTable tab = new DataTable();
            tb.Columns.Add("RegistrationNumber", typeof(string));
            tab.Columns.Add("Id", typeof(string));
            tab.Load(read);
            cmbStudentId.ValueMember = "id";
            cmbStudentId.DisplayMember = "RegistrationNumber";
            cmbStudentId.DataSource = tab;
            cmbStudentId.Text = "select here";



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            SqlConnection conmm = new SqlConnection(conn);
            conmm.Open();
            string iddd = "Select id from RubricLevel where Details='" + cmbRubricLevelId.Text.ToString() + "'";
            SqlCommand cmddd = new SqlCommand(iddd, conmm);
            var rdd = cmddd.ExecuteReader();
            rdd.Read();
            int idddno = rdd.GetInt32(0);

            SqlConnection conm = new SqlConnection(conn);
            conm.Open();
            string idd = "Select id from AssessmentComponent where Name='" + cmbAssComponentId.Text.ToString() + "'";
            SqlCommand cmdd = new SqlCommand(idd, conm);
            var rd = cmdd.ExecuteReader();
            rd.Read();
            int iddno = rd.GetInt32(0);

            SqlConnection con = new SqlConnection(conn);
            con.Open();
            string id = "Select id from student where RegistrationNumber='" + cmbStudentId.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(id, con);
            var r = cmd.ExecuteReader();
            r.Read();
            int idno = r.GetInt32(0);
            string Query = "insert into StudentResult(StudentId,AssessmentComponentId ,RubricMeasurementId,EvaluationDate) values('"+ idno + "','" + iddno + "','" + idddno + "','" + dtEvaluationDate.Value.Date + "')";
            SqlConnection myconnection2 = new SqlConnection(conn);
            SqlCommand MyCommand2 = new SqlCommand(Query, myconnection2);
            SqlDataReader MyReader2;
            myconnection2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data inserted Successfully!");
            Form24 frm5 = new Form24();
            this.Hide();
            frm5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int idstd = Convert.ToInt32(cmbStudentId.Text.ToString());
            int idAC = Convert.ToInt32(cmbAssComponentId.Text.ToString());
            int idRL = Convert.ToInt32(cmbRubricLevelId.Text.ToString());
            Form25 frm5 = new Form25(idstd,idAC,idRL);
           // Form25 frm5 = new Form25();
            this.Hide();
            frm5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form26 frm5 = new Form26();
            this.Hide();
            frm5.Show();
        }
    }
}
