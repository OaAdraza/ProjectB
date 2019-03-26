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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public string con = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Query = "insert into Clo(Name ,DateCreated,DateUpdated) values('" + txtName.Text.ToString()+ "','" + dtCreateDate.Value.Date +"','"+dtCreateDate.Value.Date +"')";
            SqlConnection myconnection2 = new SqlConnection(con);
            SqlCommand MyCommand2 = new SqlCommand(Query, myconnection2);
            SqlDataReader MyReader2;
            myconnection2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data inserted Successfully!");
            Form5 frm5 = new Form5();
            this.Hide();
            frm5.Show();
        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();

            this.Hide();


            frm6.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtCreateDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
