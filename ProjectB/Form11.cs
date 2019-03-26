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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        int ID;
        public Form11(int id)
        {
            ID = id;
            InitializeComponent();

        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand scmd = new SqlCommand("select RegistrationNumber From Student where status='5' ", con);
            SqlDataReader reader;
            reader = scmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("Id", typeof(string));
            tbl.Load(reader);
            comboBox1.DisplayMember = "RegistrationNumber";
            comboBox1.DataSource = tbl;
            comboBox1.Text = "select here Registration Number";
        }
        string status;
        private void Add_Click(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true)
            {
                status = "1";
            }
            else if(checkBox2.Checked == true){
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
            string id = "Select * from student where RegistrationNumber='" + comboBox1.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(id, con);
            var r = cmd.ExecuteReader();
            r.Read();
            int idno = r.GetInt32(0);

            string Query = "insert into StudentAttendance(attendanceId,StudentId,AttendanceStatus) values('"+ID+"','" + idno + "','"+status+"')";
            SqlConnection myconnection2 = new SqlConnection(conn);
            SqlCommand MyCommand2 = new SqlCommand(Query, myconnection2);
            SqlDataReader MyReader2;
            myconnection2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data inserted Successfully!");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
