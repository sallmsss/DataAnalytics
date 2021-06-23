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
    public partial class Form4 : Form
    {
        public static DataTable dt4 = new DataTable();
        public Form4()
        {


            InitializeComponent();
            DataRow[] rows = dt4.Select();
            // initialiser les compteurs du chart 1
            int cmp13 = 0; int cmp14 = 0; int cmp15 = 0; int cmp16 = 0; int cmp17 = 0;
            // chart2 COD PRV
            int cmpPrv0 = 0; int cmpPrv1 = 0; int cmpPrv2 = 0; int cmpPrv3 = 0;
            int cmpPrv4 = 0; int cmpPrv5 = 0; int cmpPrv6 = 0; int cmpPrv7 = 0; int cmpPrv8 = 0;

            // initialiser les compteurs du chart 2
            int cmpHomme = 0; int cmpFemme = 0;

            //MessageBox.Show("" +dt4.Rows.Count);
            foreach (DataRow row in dt4.Rows)
            {
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
                switch ("" + row["COD_PRf"])
                {
                    case "1.0":
                        cmpPrv0++;
                        break;
                    case "2.0":
                        cmpPrv1++;
                        break;
                    case "3.0":
                        cmpPrv2++;
                        break;
                    case "4.0":
                        cmpPrv3++;
                        break;
                    case "5.0":
                        cmpPrv4++;
                        break;
                    case "6.0":
                        cmpPrv5++;
                        break;
                    case "7.0":
                        cmpPrv6++;
                        break;
                    case "8.0":
                        cmpPrv7++;
                        break;
                    case "9.0":
                        cmpPrv8++;
                        break;

                        break;
                    default:
                        MessageBox.Show("" + row["COD_PRF"]);
                        break;
                }
                if ("" + row["SEX"] == "2.0")
                {
                    cmpFemme++;
                }
                else
                    cmpHomme++;

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

            //chart2 code prv
            chart3.Series["cod_prf"].Points.AddXY("2013", cmpPrv0);
            chart3.Series["cod_prf"].Points.AddXY("2014", cmpPrv1);
            chart3.Series["cod_prf"].Points.AddXY("2015", cmpPrv2);
            chart3.Series["cod_prf"].Points.AddXY("2016", cmpPrv3);
            chart3.Series["cod_prf"].Points.AddXY("2016", cmpPrv4);
            chart3.Series["cod_prf"].Points.AddXY("2016", cmpPrv5);
            chart3.Series["cod_prf"].Points.AddXY("2016", cmpPrv6);
            chart3.Series["cod_prf"].Points.AddXY("2017", cmpPrv7);
            chart3.Series["cod_prf"].Points.AddXY("2017", cmpPrv8);

            chart3.Series["cod_prf"].Label = "#PERCENT";

            int[] cmpPrv = { cmpPrv0, cmpPrv1, cmpPrv2, cmpPrv3, cmpPrv4, cmpPrv5, cmpPrv6, cmpPrv7, cmpPrv8 };
            string[] prvLabel = { "Scientifique", "Commerciale", "Direct. ou cadre admin.", "Travailleur", "Agricole", "Ouvrier", "Etudiant", "Sans profession", "Autre" };
            for (int i = 0; i < 9; i++)
            {
                chart3.Series["cod_prf"].Points[i].LegendText = "" + cmpPrv[i] + " -" + prvLabel[i];
            }

            //chart2
            chart2.Series["sexe"].Points.AddXY("Homme", cmpHomme);
            chart2.Series["sexe"].Points.AddXY("Femme", cmpFemme);

            chart2.Series["sexe"].Label = "#PERCENT";
            chart2.Series["sexe"].Points[0].LegendText = "" + cmpHomme + " - H";
            chart2.Series["sexe"].Points[1].LegendText = "" + cmpFemme + " - F";





        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
