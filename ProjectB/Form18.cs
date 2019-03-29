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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form18_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm3 = new Form1();
            this.Hide();
            frm3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Query = "insert into Assessment(Title ,DateCreated,TotalMarks,TotalWeightage) values('" + txtTitle.Text.ToString() + "','" + dtDateCreated.Value.Date + "','" + txtTotalMarks.Text.ToString() + "','"+txtTotalWeightage.Text.ToString()+"')";
            SqlConnection myconnection2 = new SqlConnection(conn);
            SqlCommand MyCommand2 = new SqlCommand(Query, myconnection2);
            SqlDataReader MyReader2;
            myconnection2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data inserted Successfully!");
            Form18 frm5 = new Form18();
            this.Hide();
            frm5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form19 frm5 = new Form19();
            this.Hide();
            frm5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form21 frm5 = new Form21();
            this.Hide();
            frm5.Show();
        }
    }
}
