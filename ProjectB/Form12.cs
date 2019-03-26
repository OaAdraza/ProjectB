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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        public string con = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        private void btnAdd_Click(object sender, EventArgs e)
        {
        
           
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            string Query = "insert into ClassAttendance(AttendanceDate) values('" + dtCreateDate.Value.Date + "')";
            SqlConnection myconnection2 = new SqlConnection(con);
            SqlCommand MyCommand2 = new SqlCommand(Query, myconnection2);
            SqlDataReader MyReader2;
            myconnection2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data inserted Successfully!");
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            string idd = "Select * from ClassAttendance where AttendanceDate='" + dtCreateDate.Value.Date + "'";
            SqlCommand cmd = new SqlCommand(idd, conn);
            var r = cmd.ExecuteReader();
            r.Read();
            int id = r.GetInt32(0);
            Form11 frm6 = new Form11(id);

            this.Hide();
            frm6.Show();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
