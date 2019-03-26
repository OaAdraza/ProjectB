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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        int ID;
        public Form7(int id)
        {
            ID = id;
            InitializeComponent();

        }
        private void Form7_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            SqlCommand exe = new SqlCommand("select * from clo where Id = '" + ID + "'", connection);
            var read = exe.ExecuteReader();
            read.Read();
            
            txtName.Text = read[1].ToString();
            dtCreateDate.Text = read[2].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conn);

            SqlCommand exe = new SqlCommand("Update Clo  set Name='" + txtName.Text.ToString() + "',DateUpdated='" + dtCreateDate.Value.Date + "' where id ='" + ID + "'", connection);
            connection.Open();
            exe.CommandType = CommandType.Text;
            exe.ExecuteNonQuery();
            MessageBox.Show("UPdated Successfully!!");

            Form6 frm6 = new Form6();
            this.Hide();
            frm6.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
