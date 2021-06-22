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
    public partial class Form3 : Form
    {
        public static DataTable dt3 = new DataTable();

        private bool isCollapsed;
        public Form3()
        {
            InitializeComponent();
            dtgstatic.DataSource = dt3;
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
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
