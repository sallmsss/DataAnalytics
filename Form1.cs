using DataAnalytics.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAnalytics
{
    public partial class Form1 : Form
    {
        private bool isCollapsed;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                button1.Image = Resources.lasthaut;
                panelDrop.Height += 10;

                if (panelDrop.Size == panelDrop.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }

            else
            {
                button1.Image = Resources.lastbas;
                panelDrop.Height -= 10;

                if (panelDrop.Size == panelDrop.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openDialog.FileName.ToString();
                BindDataCSV(txtFilePath.Text);
            }

            void BindDataCSV(string filePath)
            {
                DataTable dt = new DataTable();

                string[] lines = System.IO.File.ReadAllLines(filePath);
                if (lines.Length > 0)
                {
                    //firstLine to create Header
                    string firstLine = lines[0];
                    string[] headerLabels = firstLine.Split(',');
                    //.....................
                    tbLines.Text = (lines.Length - 1).ToString();
                    tbColonnes.Text = headerLabels.Length.ToString();

                    int[] numNULL = new int[headerLabels.Length];
                    for (int i = 0; i < numNULL.Length; i++) numNULL[i] = 0;
                    ///.....................
                    foreach (string headerWord in headerLabels)
                    {
                        dt.Columns.Add(new DataColumn(headerWord));
                    }
                    //for data
                    for (int r = 1; r < lines.Length; r++)
                    {
                        string[] dataWords = lines[r].Split(',');
                        DataRow dr = dt.NewRow();
                        int columnIndex = 0;
                        foreach (string headerWord in headerLabels)
                        {
                            //.........
                            if (dataWords[columnIndex] == "")
                                numNULL[columnIndex]++;
                            //.........
                            dr[headerWord] = dataWords[columnIndex++];


                        }
                        dt.Rows.Add(dr);
                    }
                    //.........
                    tbColonnes.Text = headerLabels.Length.ToString();
                    int sumNULL = numNULL.Sum();

                    double p = (double)sumNULL * 100 / ((double)(lines.Length - 1) * (double)headerLabels.Length);

                    tbpourcent.Text = Math.Round(p, 2).ToString();
                    int col = 0;
                    for (int i = 0; i < numNULL.Length; i++)
                        if (numNULL[i] != 0) col++;
                    tbCol.Text = col.ToString();

                    //.........


                }
                if (dt.Rows.Count > 0)
                {
                    dgvEmployees.DataSource = dt;
                }


            }
        }
    }
}
