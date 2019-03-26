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
    public partial class Form4 : Form
    {
        int ID;
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(int id)
        {
            ID = id;
            InitializeComponent();

        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            SqlCommand exe = new SqlCommand("select * from Student where Id = '"+ID+"'",connection);
            var read = exe.ExecuteReader();
            read.Read();
            string s;
            if(read.GetInt32(6) == 5)
            {
                s = "Active";
            }
            else
            {
                s = "InActive";
            }
            txtFirstName.Text = read[1].ToString();
            txtLastName.Text = read[2].ToString();
            txtContact.Text = read[3].ToString();
            txtEmail.Text = read[4].ToString();
            txtRegNo.Text = read[5].ToString();
            comboStatus.Text = s;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conn);
            int s;
            if (comboStatus.Text == "Active")
            {
                s = 5;
            }
            else
            {
                s = 6;
            }
            SqlCommand exe = new SqlCommand("Update student  set FirstName='"+txtFirstName.Text.ToString()+ "',LastName='" + txtLastName.Text.ToString() + "',Contact='" + txtContact.Text.ToString() + "',Email='" + txtEmail.Text.ToString() + "',RegistrationNumber='" + txtRegNo.Text.ToString() + "',Status='" + s + "' where id ='"+ ID +"'", connection);
            connection.Open();
            exe.CommandType = CommandType.Text;
            exe.ExecuteNonQuery();
            MessageBox.Show("UPdated Successfully!!");
            Form3 frm3 = new Form3();
            this.Hide();
            frm3.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
