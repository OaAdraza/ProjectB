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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string  con = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        string n;
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboStatus.Text == "Active")
            {
                n = "5";

            }
            else
            {
                n = "6";
            }
            string Query = "insert into student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) values('" + txtFirstName.Text.ToString() + "','" + txtLastName.Text.ToString() + "','" + txtContact.Text.ToString() + "', '" + txtEmail.Text.ToString() + "' , '" + txtRegNo.Text.ToString() + "' ,'" + n+ "')";
            SqlConnection myconnection2 = new SqlConnection(con); 
            SqlCommand MyCommand2 = new SqlCommand(Query, myconnection2);
            SqlDataReader MyReader2;
            myconnection2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data inserted Successfully!");
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.Show();
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

       
        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStdDetail_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
