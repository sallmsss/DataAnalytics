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
        public static DataTable dt = new DataTable();

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
//                BindDataCSV(txtFilePath.Text);
            }

            
        }
        void BindDataCSV(string filePath)
        {
            DataTable dt2 = new DataTable();

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
                    dt2.Columns.Add(new DataColumn(headerWord));
                }
                //for data
                for (int r = 1; r < lines.Length; r++)
                {
                    string[] dataWords = lines[r].Split(',');
                    DataRow dr = dt2.NewRow();
                    int columnIndex = 0;
                    foreach (string headerWord in headerLabels)
                    {
                        //.........
                        if (dataWords[columnIndex] == "")
                            numNULL[columnIndex]++;
                        //.........
                        dr[headerWord] = dataWords[columnIndex++];


                    }
                    dt2.Rows.Add(dr);
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
            if (dt2.Rows.Count > 0)
            {
                dgvEmployees.DataSource = dt2;
            }


        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            BindDataCSV(txtFilePath.Text);


        }
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath2.Text = openDialog.FileName.ToString();
                //BindDataCSV(txtFilePath2.Text);
            }
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            dt.Columns.Clear();
            dt.Rows.Clear();
            if (txtFilePath.Text == "Aucun fichier selectionné." || txtFilePath2.Text == "Aucun fichier selectionné.")
                MessageBox.Show("Fichier CSV non sélectionné.");
            else
            {
                String aucuneSignif = "", bcpValManq = "", linesValManq = "";

                string filePath = txtFilePath.Text;
                string significationPath = txtFilePath2.Text;



                string[] lines = System.IO.File.ReadAllLines(filePath);
                string[] lines2 = System.IO.File.ReadAllLines(significationPath);

                if (lines.Length > 0 && lines2.Length > 0)
                {
                    //firstLine to create Header
                    string firstLine = lines[0];
                    string[] headerLabels = firstLine.Split(',');
                    string firstLine2 = lines2[0];
                    string[] headerLabels2 = firstLine2.Split(',');

                    //**********
                    int[] colNonSignif = new int[headerLabels.Length];
                    int[] colNumNULL = new int[headerLabels.Length];
                    int[] colAlittleNumNULL = new int[headerLabels.Length];
                    int[] numNULL = new int[headerLabels.Length];
                    for (int i = 0; i < numNULL.Length; i++) numNULL[i] = 0;
                    for (int i = 0; i < colNumNULL.Length; i++) colNumNULL[i] = 0;
                    for (int i = 0; i < colAlittleNumNULL.Length; i++) colAlittleNumNULL[i] = 0;
                    //**********

                    //col non signif
                    int columnIndex = 0;
                    foreach (string headerWord in headerLabels)
                    {
                        foreach (string headerWord2 in headerLabels2)
                        {
                            if (String.Equals(headerWord, headerWord2))
                            {
                                colNonSignif[columnIndex] = 1;
                                break;
                            }
                        }
                        columnIndex++;
                    }


                    for (int r = 1; r < lines.Length; r++)
                    {
                        string[] dataWords = lines[r].Split(',');
                        columnIndex = 0;
                        foreach (string headerWord in headerLabels)
                        {
                            //.........
                            if (dataWords[columnIndex] == "")
                                numNULL[columnIndex]++;
                            columnIndex++;
                            //.........

                        }
                    }
                    //determiner le nombre des col qu'ont pas de sgnification 
                    //determiner les col qu'ont beaucoup de val null et les stoker dans un tableau


                    int col = 0;
                    for (int i = 0; i < headerLabels.Length; i++)
                    {
                        if (colNonSignif[i] == 0) col++;
                        if (numNULL[i] > 10) colNumNULL[i]++;
                        else if (numNULL[i] > 0) colAlittleNumNULL[i]++;
                    }

                    // ********* aucuneSignif aucuneSignif linesValManq
                    for (int i = 0; i < colNonSignif.Length; i++)
                    {
                        if (colNonSignif[i] == 0)
                        {

                            aucuneSignif = aucuneSignif + headerLabels[i] + ", ";
                        }
                        if (colNumNULL[i] == 1)
                        {
                            bcpValManq = bcpValManq + headerLabels[i] + ", ";

                        }
                        if (colAlittleNumNULL[i] == 1)
                        {
                            linesValManq = linesValManq + headerLabels[i] + ", ";

                        }

                    }

                    ///.....................
                    ///
                    int h = 0, n = 0;
                    String[] newHeader = new String[headerLabels.Length];

                    foreach (string headerWord in headerLabels)
                    {
                        if (colNonSignif[h] != 0 && colNumNULL[h] != 1)
                        {
                            dt.Columns.Add(new DataColumn(headerWord));
                            newHeader[n] = headerWord;
                            n++;
                        }
                        h++;

                    }
                    String[] newHeaderLabels = newHeader.Take(n + 1).ToArray();


                    //for data
                    for (int r = 1; r < lines.Length; r++)
                    {
                        string[] dataWords = lines[r].Split(',');
                        String[] newDataWords = new String[dataWords.Length];

                        //eliminate the col that contain alot of null or non signif
                        int k = 0;
                        for (int j = 0; j < headerLabels.Length; j++)
                        {
                            if (colNonSignif[j] == 0 || colNumNULL[j] == 1)
                                continue;
                            newDataWords[k] = dataWords[j];
                            k++;
                        }
                        // pass to the next line if this one contains null var
                        Boolean flag = false;
                        for (int j = 0; j < newDataWords.Length; j++)
                        {
                            if (newDataWords[j] == "")
                            {
                                flag = true;
                                break;

                            }

                        }
                        if (flag == true)
                            continue;
                        //****************** add to the new table   ************



                        DataRow dr = dt.NewRow();
                        columnIndex = 0;

                        foreach (string headerWord in newHeaderLabels)
                        {
                            if (headerWord == null)
                                break;
                            dr[headerWord] = newDataWords[columnIndex++];
                            if (columnIndex == newHeaderLabels.Length)
                                break;


                        }
                        dt.Rows.Add(dr);
                    }
                    //.........

                    //.........
                }
                if (dt.Rows.Count > 0)
                {
                    Form2.dt2 = dt;
                    Form2.aucuneSignif = aucuneSignif;
                    Form2.bcpValManq = bcpValManq;
                    Form2.linesValManq = linesValManq;
                    Form3.dt3 = dt;
                }

                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();


            }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text == "Aucun fichier selectionné." || txtFilePath2.Text == "Aucun fichier selectionné.")
                MessageBox.Show("Fichier CSV non sélectionné.");
            else
            {
                if (dt.Rows.Count > 0)
                {
                    Form2.dt2 = dt;
                    Form3.dt3 = dt;
                }
                this.Hide();
                Form3 f3 = new Form3();
                f3.Show();
            }
                
        }

        /** void BindDataCSV(string filePath)
{
    DataTable dt2 = new DataTable();

    string[] lines2 = System.IO.File.ReadAllLines(filePath);
    if (lines2.Length > 0)
    {
        //firstLine to create Header
        string firstLine = lines2[0];
        string[] headerLabels = firstLine.Split(',');

        foreach (string headerWord in headerLabels)
        {
            dt2.Columns.Add(new DataColumn(headerWord));
        }
        //for data
        for (int r = 1; r < lines2.Length; r++)
        {
            string[] dataWords = lines2[r].Split(',');
            DataRow dr = dt2.NewRow();
            int columnIndex = 0;
            foreach (string headerWord in headerLabels)
            {
                dr[headerWord] = dataWords[columnIndex++];
            }
            dt2.Rows.Add(dr);
        }
    }
    if (dt2.Rows.Count > 0)
    {
        dgvEmployees.DataSource = dt2;
    }


}*/


    }
}
