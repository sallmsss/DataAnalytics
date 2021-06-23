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
using System.Windows.Forms.DataVisualization.Charting;

namespace DataAnalytics
{
    public partial class Form3 : Form
    {
        public static DataTable dt3 = new DataTable();
        public static string fileName;

        private bool isCollapsed;
        public Form3()
        {
            InitializeComponent();
            if (fileName.Contains("pietons")) {
                if (dt3.Rows.Count == 0)
                {
                    MessageBox.Show("il faut faire un nettoyage d'abord");
                }

                // CHART 1 : Accident par annee :
                //
                DataRow[] rows = dt3.Select();
                // initialiser les compteurs du chart 1
                int cmp13 = 0; int cmp14 = 0; int cmp15 = 0; int cmp16 = 0; int cmp17 = 0;
                // initialiser les compteurs du chart 2
                int cmpHomme = 0; int cmpFemme = 0;

                // initialiser les compteurs du chart 3
                int cmpPrf0 = 0; int cmpPrf1 = 0; int cmpPrf2 = 0; int cmpPrf3 = 0;
                int cmpPrf4 = 0; int cmpPrf5 = 0; int cmpPrf6 = 0; int cmpPrf7 = 0; int cmpPrf8 = 0;

                int cmpTue0 = 0; int cmpTue1 = 0; int cmpTue2 = 0; int cmpTue3 = 0;
                int cmpTue4 = 0; int cmpTue5 = 0; int cmpTue6 = 0; int cmpTue7 = 0; int cmpTue8 = 0;

                int cmpBle0 = 0; int cmpBle1 = 0; int cmpBle2 = 0; int cmpBle3 = 0;
                int cmpBle4 = 0; int cmpBle5 = 0; int cmpBle6 = 0; int cmpBle7 = 0; int cmpBle8 = 0;

                foreach (DataRow row in dt3.Rows)
                {
                    // Annes




                    if (Convert.ToInt32(row["ANN_ACC"]) == 2013)
                    {
                        cmp13++;
                    }
                    if (Convert.ToInt32(row["ANN_ACC"]) == 2014)
                    {
                        cmp14++;
                    }
                    if (Convert.ToInt32(row["ANN_ACC"]) == 2015)
                    {
                        cmp15++;
                    }
                    if (Convert.ToInt32(row["ANN_ACC"]) == 2016)
                    {
                        cmp16++;
                    }
                    if (Convert.ToInt32(row["ANN_ACC"]) == 2017)
                    {
                        cmp17++;
                    }

                    //Sexe
                    //MessageBox.Show("-"+row["SEX"]+"-");
                    if ("" + row["SEX"] == "2.0")
                    {
                        cmpFemme++;
                    }
                    else
                        cmpHomme++;
                    // Professiom
                    switch ("" + row["COD_PRF"])
                    {
                        case "1.0":
                            cmpPrf0++;
                            break;
                        case "2.0":
                            cmpPrf1++;
                            break;
                        case "3.0":
                            cmpPrf2++;
                            break;
                        case "4.0":
                            cmpPrf3++;
                            break;
                        case "5.0":
                            cmpPrf4++;
                            break;
                        case "6.0":
                            cmpPrf5++;
                            break;
                        case "7.0":
                            cmpPrf6++;
                            break;
                        case "8.0":
                            cmpPrf7++;
                            break;
                        case "9.0":
                            cmpPrf8++;
                            break;
                        default:
                            MessageBox.Show("" + row["COD_PRF"]);
                            break;
                    }





                    // cod tue
                    switch ("" + row["COD_TUE"])
                    {
                        case "0":
                            cmpTue0++;
                            break;
                        case "1":
                            cmpTue1++;
                            break;
                        case "2":
                            cmpTue2++;
                            break;
                        case "3":
                            cmpTue3++;
                            break;
                        case "4":
                            cmpTue4++;
                            break;
                        case "5":
                            cmpTue5++;
                            break;
                        case "6":
                            cmpTue6++;
                            break;
                        case "8.0":
                            cmpTue7++;
                            break;
                        case "9.0":
                            cmpTue8++;
                            break;
                        default:
                            MessageBox.Show("" + row["COD_TUE"]);
                            break;
                    }


                    // Blessure
                    switch ("" + row["COD_BLE"])
                    {
                        case "0":
                            cmpBle0++;
                            break;
                        case "1":
                            cmpBle1++;
                            break;
                        case "2":
                            cmpBle2++;
                            break;
                        case "3":
                            cmpBle3++;
                            break;
                        case "4":
                            cmpBle4++;
                            break;
                        case "5":
                            cmpBle5++;
                            break;
                        case "7.0":
                            cmpBle6++;
                            break;
                        case "8.0":
                            cmpBle7++;
                            break;
                        case "9.0":
                            cmpBle8++;
                            break;
                        default:
                            MessageBox.Show("" + row["COD_BLE"]);
                            break;
                    }
                    


                }

                // Inserer dans la chart1 ( annees)
                chart1.Series["ann_acc"].Points.AddXY("2013", cmp13);
                chart1.Series["ann_acc"].Points.AddXY("2014", cmp14);
                chart1.Series["ann_acc"].Points.AddXY("2015", cmp15);

                chart1.Series["ann_acc"].Points.AddXY("2016", cmp16);

                chart1.Series["ann_acc"].Points.AddXY("2017", cmp17);
                chart1.Series["ann_acc"].Label = "#PERCENT";
                //chart1.Series[0].LegendText = "#VALX";
                int[] cmpAnn = { cmp13, cmp14, cmp15, cmp16, cmp17 };
                int annee = 2012;
                for (int i = 0; i < 5; i++)
                {
                    annee++;
                    chart1.Series["ann_acc"].Points[i].LegendText = "" + cmpAnn[i] + " - " + annee;
                }

                // chart 2 sexe
                chart2.Series["sexe"].Points.AddXY("Homme", cmpHomme);
                chart2.Series["sexe"].Points.AddXY("Femme", cmpFemme);

                chart2.Series["sexe"].Label = "#PERCENT";
                chart2.Series["sexe"].Points[0].LegendText = "" + cmpHomme + " - H";
                chart2.Series["sexe"].Points[1].LegendText = "" + cmpFemme + " - F";

                //chart3 prf
                chart3.Series["cod_prf"].Points.AddXY("2013", cmpPrf0);
                chart3.Series["cod_prf"].Points.AddXY("2014", cmpPrf1);
                chart3.Series["cod_prf"].Points.AddXY("2015", cmpPrf2);
                chart3.Series["cod_prf"].Points.AddXY("2016", cmpPrf3);
                chart3.Series["cod_prf"].Points.AddXY("2016", cmpPrf4);
                chart3.Series["cod_prf"].Points.AddXY("2016", cmpPrf5);
                chart3.Series["cod_prf"].Points.AddXY("2016", cmpPrf6);
                chart3.Series["cod_prf"].Points.AddXY("2017", cmpPrf7);
                chart3.Series["cod_prf"].Points.AddXY("2017", cmpPrf8);

                chart3.Series["cod_prf"].Label = "#PERCENT";

                int[] cmpPrf = { cmpPrf0, cmpPrf1, cmpPrf2, cmpPrf3, cmpPrf4, cmpPrf5, cmpPrf6, cmpPrf7, cmpPrf8 };
                string[] prfLabel = { "Scientifique", "Commerciale", "Direct. ou cadre admin.", "Travailleur", "Agricole", "Ouvrier", "Etudiant", "Sans profession", "Autre" };
                for (int i = 0; i < 9; i++)
                {
                    chart3.Series["cod_prf"].Points[i].LegendText = "" + cmpPrf[i] + " -" + prfLabel[i];
                }


                // chart 4 cod tue
                chart4.Series["cod_tue"].Points.AddXY("2013", cmpTue0);
                chart4.Series["cod_tue"].Points.AddXY("2014", cmpTue1);
                chart4.Series["cod_tue"].Points.AddXY("2015", cmpTue2);
                chart4.Series["cod_tue"].Points.AddXY("2016", cmpTue3);
                chart4.Series["cod_tue"].Points.AddXY("2016", cmpTue4);
                chart4.Series["cod_tue"].Points.AddXY("2016", cmpTue5);


                chart4.Series["cod_tue"].Label = "#PERCENT";

                int[] cmpTue = { cmpTue0, cmpTue1, cmpTue2, cmpTue3, cmpTue4, cmpTue5, cmpTue6, cmpTue7, cmpTue8 };
                string[] tueLabel = { "Non Tue", "Tue sur champ", "Tue transfert Hop", "Tue 1er 7 jours", "Tue les 30 jours", "Autres" };
                for (int i = 0; i < 6; i++)
                {
                    chart4.Series["cod_tue"].Points[i].LegendText = "" + cmpTue[i] + " -" + tueLabel[i];
                }

                // chart 5 Blessure
                chart5.Series["cod_ble"].Points.AddXY("2013", cmpBle0);
                chart5.Series["cod_ble"].Points.AddXY("2014", cmpBle1);
                chart5.Series["cod_ble"].Points.AddXY("2015", cmpBle2);
                chart5.Series["cod_ble"].Points.AddXY("2016", cmpBle3);



                chart5.Series["cod_ble"].Label = "#PERCENT";

                int[] cmpBle = { cmpBle0, cmpBle1, cmpBle2, cmpBle3 + cmpBle4 + cmpBle5 + cmpBle6 + cmpBle7 + cmpBle8 };
                string[] bleLabel = { "Non Ble", "B.Grave", "B.leger", "autre" };
                for (int i = 0; i < 4; i++)
                {
                    chart5.Series["cod_ble"].Points[i].LegendText = "" + cmpBle[i] + " -" + bleLabel[i];
                }
                // chart 6
                chart6.Series["annee"].Points.AddXY("2013", cmp13);
                chart6.Series["annee"].Points.AddXY("2014", cmp14);
                chart6.Series["annee"].Points.AddXY("2015", cmp15);
                chart6.Series["annee"].Points.AddXY("2016", cmp16);
                chart6.Series["annee"].Points.AddXY("2017", cmp17);
            }
            if (fileName.Contains("passagers"))
            {
                //this.Hide();
                Form4 f4 = new Form4();
                Form4.dt4 = dt3;
                f4.Show();
            }
            if (fileName.Contains("vehicules"))
            {
                //MessageBox.Show("File incorrect");
                Form5 f5 = new Form5();
                Form5.dt5 = dt3;
                f5.Show();


            }
                

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
            Application.Exit();
        }

        private void chart6_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
