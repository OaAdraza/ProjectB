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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string con = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            this.Hide();
            frm5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            this.Hide();
            frm8.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 frm11 = new Form12();
            this.Hide();
            frm11.Show();

        }
    }
}
