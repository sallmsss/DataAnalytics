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
    public partial class Form2 : Form
    {
        public static DataTable dt2 = new DataTable();
        public static String aucuneSignif;
        public static String bcpValManq;
        public static String linesValManq;

        private bool isCollapsed;
        public Form2()
        {
            InitializeComponent();
            dgvnettoyage.DataSource = dt2;
            tbAucuneSignif.Text = aucuneSignif;
            tbBcpValManq.Text = bcpValManq;
            tbLinesValManq.Text = linesValManq;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
