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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }
        int ID;
        public Form20(int id)
        {
            ID = id;
            InitializeComponent();

        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form20_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            SqlCommand exe = new SqlCommand("select * from Assessment where Id = '" + ID + "'", connection);
            var read = exe.ExecuteReader();
            read.Read();
            txtTitle.Text = read[1].ToString();
            dtCreatedAssessment.Text = read[2].ToString();
            txtTotalMarks.Text = read[3].ToString();
            txtTotalWeightage.Text = read[4].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conn);

            SqlCommand exe = new SqlCommand("Update Assessment  set Title='" + txtTitle.Text.ToString() + "',DateCreated='" + dtCreatedAssessment.Value.Date + "',TotalMarks='"+txtTotalMarks.Text.ToString()+"',TotalWeightage='"+txtTotalWeightage.Text.ToString()+"' where id ='" + ID + "'", connection);
            connection.Open();
            exe.CommandType = CommandType.Text;
            exe.ExecuteNonQuery();
            MessageBox.Show("UPdated Successfully!!");

            Form19 frm6 = new Form19();
            this.Hide();
            frm6.Show();
        }
    }
}
