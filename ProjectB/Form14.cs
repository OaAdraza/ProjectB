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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }
        int ID;
        public Form14(int id)
        {
            ID = id;
            InitializeComponent();

        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form14_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            SqlCommand exe = new SqlCommand("select * from StudentAttendance where StudentId = '" + ID + "'", connection);
            var read = exe.ExecuteReader();
            read.Read();
            cmbRegNo.Text = read[2].ToString();

            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand scmd = new SqlCommand("select RegistrationNumber From Student where status='5' and id='"+ID+"' ", con);
            SqlDataReader reader;
            reader = scmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("Id", typeof(string));
            tbl.Load(reader);
            cmbRegNo.DisplayMember = "RegistrationNumber";
            cmbRegNo.DataSource = tbl;
        }
        public string status;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                status = "1";
            }
            else if (checkBox2.Checked == true)
            {
                status = "2";

            }
            else if (checkBox3.Checked == true)
            {
                status = "3";

            }
            else
            {
                status = "4";
            }
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            string id = "Select * from student where RegistrationNumber='" + cmbRegNo.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(id, con);
            var r = cmd.ExecuteReader();
            r.Read();
            int idno = r.GetInt32(0);
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand exe = new SqlCommand("Update StudentAttendance set AttendanceStatus= '" + status + "' where StudentId='"+idno+ "' and attendanceId='" + ID + "' ", connection);
            connection.Open();
            exe.CommandType = CommandType.Text;
            exe.ExecuteNonQuery();
            MessageBox.Show("UPdated Successfully!!");
            Form13 f = new Form13();
            this.Hide();
            f.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
