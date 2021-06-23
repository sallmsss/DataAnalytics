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
    public partial class Form5 : Form
    {
        public static DataTable dt5 = new DataTable();
        public Form5()
        {
            InitializeComponent();
            DataRow[] rows = dt5.Select();
            // initialiser les compteurs du chart 1
            int cmp13 = 0; int cmp14 = 0; int cmp15 = 0; int cmp16 = 0; int cmp17 = 0;
            // chart2 COD PRV
            int cmpPrv0 = 0; int cmpPrv1 = 0; int cmpPrv2 = 0; int cmpPrv3 = 0;
            int cmpPrv4 = 0; int cmpPrv5 = 0; int cmpPrv6 = 0; int cmpPrv7 = 0; int cmpPrv8 = 0;

            int cmpTue0 = 0; int cmpTue1 = 0; int cmpTue2 = 0; int cmpTue3 = 0;
            int cmpTue4 = 0; int cmpTue5 = 0; int cmpTue6 = 0; int cmpTue7 = 0; int cmpTue8 = 0;
            foreach (DataRow row in dt5.Rows)
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
                switch ("" + row["COD_TYP_VEH"])
                {
                    case "0":
                        cmpPrv0++;
                        break;
                    case "1":
                        cmpPrv1++;
                        break;
                    case "2":
                        cmpPrv2++;
                        break;
                    case "3":
                        cmpPrv3++;
                        break;
                    case "4":
                        cmpPrv4++;
                        break;
                    case "5":
                        cmpPrv5++;
                        break;
                    case "6":
                        cmpPrv6++;
                        break;
                    case "7":
                        cmpPrv6++;
                        break;
                    case "8":
                        cmpPrv6++;
                        break;
                    case "9":
                        cmpPrv7++;
                        break;
                    case "10":
                        cmpPrv6++;
                        break;
                    case "11":
                        cmpPrv6++;
                        break;
                    case "12":
                        cmpPrv6++;
                        break;
                    case "14":
                        cmpPrv8++;
                        break;
                    case "99":
                        cmpPrv8++;
                        break;

                    default:
                        MessageBox.Show("" + row["COD_TYP_VEH"]);
                        break;
                }

            }
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

            chart2.Series["type_veh"].Points.AddXY("2013", cmpPrv0);
            chart2.Series["type_veh"].Points.AddXY("2014", cmpPrv1);
            chart2.Series["type_veh"].Points.AddXY("2015", cmpPrv2);
            chart2.Series["type_veh"].Points.AddXY("2016", cmpPrv3);
            chart2.Series["type_veh"].Points.AddXY("2016", cmpPrv4);
            chart2.Series["type_veh"].Points.AddXY("2016", cmpPrv5);
            chart2.Series["type_veh"].Points.AddXY("2016", cmpPrv6);
            chart2.Series["type_veh"].Points.AddXY("2017", cmpPrv7);
            chart2.Series["type_veh"].Points.AddXY("2017", cmpPrv8);

            chart2.Series["type_veh"].Label = "#PERCENT";

            int[] cmpPrv = { cmpPrv0, cmpPrv1, cmpPrv2, cmpPrv3, cmpPrv4, cmpPrv5, cmpPrv6, cmpPrv7, cmpPrv8 };
            string[] prvLabel = { "Bike", "moteur", "Faut handicape ", "Voiture Tour", "Bus", "Autocar", "Autre" };
            for (int i = 0; i < 7; i++)
            {
                chart2.Series["type_veh"].Points[i].LegendText = "" + cmpPrv[i] + " -" + prvLabel[i];
            }



            

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
