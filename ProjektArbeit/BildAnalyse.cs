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

namespace ProjektArbeit
{
    public partial class BildAnalyse : Form
    {
        public BildAnalyse()
        {
            InitializeComponent();
        }
        Bitmap objBitmap;
        string filename;
        private void btnLoad_Click(object sender, EventArgs e)
        {
            lv.View = View.Details;
            lv.FullRowSelect = true;

            /*
            ListViewItem eintrag1 = new ListViewItem("Farbanteile", 0);
            eintrag1.SubItems.Add("Oben links");
            eintrag1.SubItems.Add("Oben rechts");
            eintrag1.SubItems.Add("Unten links");
            eintrag1.SubItems.Add("Unten rechts");
            lv.Items.Add(eintrag1);
            */
            /*
            ListViewItem eintrag2 = new ListViewItem("Berlin.txt", 1);
            eintrag2.SubItems.Add("130 KB");
            eintrag2.SubItems.Add("05.07.2017");
            lv.Items.Add(eintrag2);

            ListViewItem eintrag3 = new ListViewItem("Berlin.txt", 2);
            eintrag3.SubItems.Add("100 KB");
            eintrag3.SubItems.Add("24.07.2017");
            lv.Items.Add(eintrag3);
            */
            lv.Columns.Add("", 100);
            lv.Columns.Add("Rot", 100);
            lv.Columns.Add("Grün", 100);
            lv.Columns.Add("Blau", 100);

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Multiselect = false;
            ofd.InitialDirectory = ".\\";
            ofd.Filter =
                " Bilder (*.bmp; *jpg; *jpeg; *png)|*.bmp;*.jpg;*.jpeg;*.png|" +
                " Alle Dateien (*.*)|*.*";
            ofd.Title = "Bild zum Laden auswählen";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                objBitmap = new Bitmap(Image.FromFile(filename), new Size(1000, 750));
                oPic.Image = objBitmap;
                this.WindowState = FormWindowState.Maximized;
            }
            else
                MessageBox.Show("Abbruch");

            int nRed = 0;
            int nGreen = 0;
            int nBlue = 0;
            for (int ix = 0; ix < 500; ix++)
            {
                for (int iy = 0; iy < 375; iy++)
                {
                    nRed += objBitmap.GetPixel(ix, iy).R;
                    nGreen += objBitmap.GetPixel(ix, iy).G;
                    nBlue += objBitmap.GetPixel(ix, iy).B;
                }
            }

            nRed = nRed / (375000 / 2);
            nGreen = nGreen / (375000 / 2);
            nBlue = nBlue / (375000 / 2);

            dChart.Series.Clear();

            dChart.Series.Add(new Series("Farbverteilung"));
            dChart.Series[0].Points.AddXY("R_LO", nRed);
            dChart.Series[0].Points.AddXY("G_LO", nGreen);
            dChart.Series[0].Points.AddXY("B_LO", nBlue);
            var axeX = dChart.ChartAreas[0].AxisX;
            var axeY = dChart.ChartAreas[0].AxisY;

            ListViewItem eintrag1 = new ListViewItem("Links oben", 0);
            eintrag1.SubItems.Add(nRed.ToString());
            eintrag1.SubItems.Add(nGreen.ToString());
            eintrag1.SubItems.Add(nBlue.ToString());
            lv.Items.Add(eintrag1);


            nRed = 0;
            nGreen = 0;
            nBlue = 0;

            for (int ix = 500; ix < 1000; ix++)
            {
                for (int iy = 0; iy < 375; iy++)
                {
                    nRed += objBitmap.GetPixel(ix, iy).R;
                    nGreen += objBitmap.GetPixel(ix, iy).G;
                    nBlue += objBitmap.GetPixel(ix, iy).B;
                }
            }

            nRed = nRed / (375000 / 2);
            nGreen = nGreen / (375000 / 2);
            nBlue = nBlue / (375000 / 2);


            dChart.Series[0].Points.AddXY("-", 0);
            dChart.Series[0].Points.AddXY("R_RO", nRed);
            dChart.Series[0].Points.AddXY("G_RO", nGreen);
            dChart.Series[0].Points.AddXY("B_RO", nBlue);

            ListViewItem eintrag2 = new ListViewItem("Rechts oben", 0);
            eintrag2.SubItems.Add(nRed.ToString());
            eintrag2.SubItems.Add(nGreen.ToString());
            eintrag2.SubItems.Add(nBlue.ToString());
            lv.Items.Add(eintrag2);

            nRed = 0;
            nGreen = 0;
            nBlue = 0;

            for (int ix = 0; ix < 500; ix++)
            {
                for (int iy = 375; iy < 750; iy++)
                {
                    nRed += objBitmap.GetPixel(ix, iy).R;
                    nGreen += objBitmap.GetPixel(ix, iy).G;
                    nBlue += objBitmap.GetPixel(ix, iy).B;
                }
            }

            nRed = nRed / (375000 / 2);
            nGreen = nGreen / (375000 / 2);
            nBlue = nBlue / (375000 / 2);



            dChart.Series[0].Points.AddXY("-", 0);
            dChart.Series[0].Points.AddXY("R_LU", nRed);
            dChart.Series[0].Points.AddXY("G_LU", nGreen);
            dChart.Series[0].Points.AddXY("B_LU", nBlue);

            ListViewItem eintrag3 = new ListViewItem("Links unten", 0);
            eintrag3.SubItems.Add(nRed.ToString());
            eintrag3.SubItems.Add(nGreen.ToString());
            eintrag3.SubItems.Add(nBlue.ToString());
            lv.Items.Add(eintrag3);

            nRed = 0;
            nGreen = 0;
            nBlue = 0;

            for (int ix = 500; ix < 1000; ix++)
            {
                for (int iy = 375; iy < 750; iy++)
                {
                    nRed += objBitmap.GetPixel(ix, iy).R;
                    nGreen += objBitmap.GetPixel(ix, iy).G;
                    nBlue += objBitmap.GetPixel(ix, iy).B;
                }
            }

            nRed = nRed / (375000 / 2);
            nGreen = nGreen / (375000 / 2);
            nBlue = nBlue / (375000 / 2);


            dChart.Series[0].Points.AddXY("-", 0);
            dChart.Series[0].Points.AddXY("R_RU", nRed);
            dChart.Series[0].Points.AddXY("G_RU", nGreen);
            dChart.Series[0].Points.AddXY("B_RU", nBlue);


            ListViewItem eintrag4 = new ListViewItem("Rechts unten", 0);
            eintrag4.SubItems.Add(nRed.ToString());
            eintrag4.SubItems.Add(nGreen.ToString());
            eintrag4.SubItems.Add(nBlue.ToString());
            lv.Items.Add(eintrag4);



            axeX.Minimum = 0;
            axeX.Maximum = 16;
            //axeX.IsInterlaced = true;
            axeX.LabelStyle.Interval = 1;
            axeX.MajorGrid.Interval = 1;
            axeY.Minimum = 0;
            axeY.Maximum = 300;
            axeY.LabelStyle.Interval = 50;

            dChart.Series[0].Color = Color.Red;
            dChart.Series[0].BorderWidth = 3;
            dChart.Series[0].XAxisType = AxisType.Primary;
            dChart.Series[0].XValueType = ChartValueType.String;

            dChart.Series[0].ChartType = SeriesChartType.Column;







        }

        private void btnAbstract_Click(object sender, EventArgs e)
        {
            objBitmap = new Bitmap(Image.FromFile(filename), new Size(1000, 750));
            oPic.Image = objBitmap;
            for (int ix = 0; ix < 1000; ix++)
            {
                for (int iy = 0; iy < 750; iy++)
                {
                    int nRed = objBitmap.GetPixel(ix, iy).R;
                    int nGreen = objBitmap.GetPixel(ix, iy).G;
                    int nBlue = objBitmap.GetPixel(ix, iy).B;

                    if ((nRed >= nGreen) && (nRed >= nBlue))
                    {
                        objBitmap.SetPixel(ix, iy, Color.Red);

                    }
                    else if ((nGreen >= nRed) && (nGreen >= nBlue))
                    {
                        objBitmap.SetPixel(ix, iy, Color.Green);

                    }
                    else if ((nBlue >= nRed) && (nBlue >= nGreen))
                    {
                        objBitmap.SetPixel(ix, iy, Color.Blue);

                    }

                }
            }
            this.Refresh();

        }

        private void btnMinimumFarbe_Click(object sender, EventArgs e)
        {
            objBitmap = new Bitmap(Image.FromFile(filename), new Size(1000, 750));
            oPic.Image = objBitmap;
            for (int ix = 0; ix < 1000; ix++)
            {
                for (int iy = 0; iy < 750; iy++)
                {
                    int nRed = objBitmap.GetPixel(ix, iy).R;
                    int nGreen = objBitmap.GetPixel(ix, iy).G;
                    int nBlue = objBitmap.GetPixel(ix, iy).B;

                    if ((nRed <= nGreen) && (nRed <= nBlue))
                    {
                        objBitmap.SetPixel(ix, iy, Color.Red);

                    }
                    else if ((nGreen <= nRed) && (nGreen <= nBlue))
                    {
                        objBitmap.SetPixel(ix, iy, Color.Green);

                    }
                    else if ((nBlue <= nRed) && (nBlue <= nGreen))
                    {
                        objBitmap.SetPixel(ix, iy, Color.Blue);

                    }

                }
            }
            this.Refresh();

        }

        private void btnKontur_Click(object sender, EventArgs e)
        {
            objBitmap = new Bitmap(Image.FromFile(filename), new Size(1000, 750));
            oPic.Image = objBitmap;
            for (int ix = 0; ix < 1000; ix++)
            {
                for (int iy = 0; iy < 750; iy++)
                {
                    int nRed = objBitmap.GetPixel(ix, iy).R;
                    int nGreen = objBitmap.GetPixel(ix, iy).G;
                    int nBlue = objBitmap.GetPixel(ix, iy).B;

                    if ((nRed <= nGreen) && (nRed <= nBlue))
                    {
                        objBitmap.SetPixel(ix, iy, Color.FromArgb(nRed, nGreen / 3, nBlue / 3));

                    }
                    else if ((nGreen <= nRed) && (nGreen <= nBlue))
                    {
                        objBitmap.SetPixel(ix, iy, Color.FromArgb(nRed / 3, nGreen, nBlue / 3));

                    }
                    else if ((nBlue <= nRed) && (nBlue <= nGreen))
                    {
                        objBitmap.SetPixel(ix, iy, Color.FromArgb(nRed / 3, nGreen / 3, nBlue));

                    }

                }
            }
            this.Refresh();


        }

        private void btnFilterRed_Click(object sender, EventArgs e)
        {
            objBitmap = new Bitmap(Image.FromFile(filename), new Size(1000, 750));
            oPic.Image = objBitmap;
            for (int ix = 0; ix < 1000; ix++)
            {
                for (int iy = 0; iy < 750; iy++)
                {
                    int nRed = objBitmap.GetPixel(ix, iy).R;
                    int nGreen = objBitmap.GetPixel(ix, iy).G / 8;
                    int nBlue = objBitmap.GetPixel(ix, iy).B / 8;

                    objBitmap.SetPixel(ix, iy, Color.FromArgb(nRed , nGreen , nBlue));
                }

            }
            this.Refresh();
        }

        private void btnFilterGreen_Click(object sender, EventArgs e)
        {
            objBitmap = new Bitmap(Image.FromFile(filename), new Size(1000, 750));
            oPic.Image = objBitmap;
            for (int ix = 0; ix < 1000; ix++)
            {
                for (int iy = 0; iy < 750; iy++)
                {
                    int nRed = objBitmap.GetPixel(ix, iy).R/8;
                    int nGreen = objBitmap.GetPixel(ix, iy).G ;
                    int nBlue = objBitmap.GetPixel(ix, iy).B / 8;

                    objBitmap.SetPixel(ix, iy, Color.FromArgb(nRed, nGreen, nBlue));
                }

            }
            this.Refresh();

        }

        private void btnFilterBlue_Click(object sender, EventArgs e)
        {
            objBitmap = new Bitmap(Image.FromFile(filename), new Size(1000, 750));
            oPic.Image = objBitmap;
            for (int ix = 0; ix < 1000; ix++)
            {
                for (int iy = 0; iy < 750; iy++)
                {
                    int nRed = objBitmap.GetPixel(ix, iy).R / 10;
                    int nGreen = objBitmap.GetPixel(ix, iy).G / 10;
                    int nBlue = objBitmap.GetPixel(ix, iy).B ;

                    objBitmap.SetPixel(ix, iy, Color.FromArgb(nRed, nGreen, nBlue));
                }

            }
            this.Refresh();

        }
    }
    



        
    
}
