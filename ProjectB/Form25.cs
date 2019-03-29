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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using iTextSharp.text.pdf;

using iTextSharp.text;
namespace ProjectB
{
    public partial class Form25 : Form
    {
        public Form25()
        {
            InitializeComponent();
        }
        int IDAS;
        int IDSTD;
        int IDRL;
        public Form25(int idstd, int idAC,int idRL)
        {
            IDSTD = idstd;
            IDAS = idAC;
            IDRL = idRL;
            InitializeComponent();

        }
        public string conn = "Data Source=DESKTOP-C1VV4DS;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form25_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            try
            {

                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand command = new SqlCommand("select AssessmentComponent.Name, Rubric.Details,AssessmentComponent.TotalMarks,RubricLevel.Details,(count(RubricLevel.Details) * AssessmentComponent.TotalMarks)/4 as Total  From(((StudentResult inner join AssessmentComponent on IDAS = AssessmentComponent.Id) inner join RubricLevel on idRL = RubricLevel.Id) inner join Rubric on idRL = RubricLevel.Id and RubricLevel.RubricId = Rubric.Id)Group by AssessmentComponent.Name, Rubric.Details,AssessmentComponent.TotalMarks,RubricLevel.Details", con);

                command.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(command);

                DataSet ds = new DataSet();

                da.Fill(ds, "ss");

                dataGridView1.DataSource = ds.Tables["ss"];
            }
            catch
            {
                MessageBox.Show("NO record Found");
            }

            

      
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm5 = new Form1();
            this.Hide();
            frm5.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form26 frm5 = new Form26();
            this.Hide();
            frm5.Show();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {

            PdfPTable pdftbl = new PdfPTable(dataGridView1.ColumnCount);
            pdftbl.DefaultCell.Padding = 3;
            pdftbl.WidthPercentage = 30;
            pdftbl.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftbl.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cl = new PdfPCell(new Phrase(column.HeaderText));
                pdftbl.AddCell(cl);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cl in row.Cells)
                {
                    pdftbl.AddCell(cl.Value.ToString());
                }
            }

            //Exporting to PDF
            string folderPath = @"C:\PDFs\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdftbl);
                pdfDoc.Close();
                stream.Close();
            }
            MessageBox.Show("Done");
        }
    }
}
