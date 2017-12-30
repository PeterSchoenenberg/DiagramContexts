using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjektArbeit.utils.util;
using ProjektArbeit.parser.parse;
using ProjektArbeit.anzeige.panel;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;

namespace ProjektArbeit
{
    public partial class Funktion : Form
    {
        private List<Kurve> curves = new List<Kurve>();
        Diagramm diag = null;
        Diagramm mm = null;

        Kurve curve1 = null;
        Kurve curve2 = null;
        Kurve curve3 = null;

        DiagParam mp;

        RadioButton btnRadLast = null;

        public Funktion()
        {
            InitializeComponent();
        }
        private void StartingRoutine(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            btnRadLast = radKeine;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            //toolTip1.SetToolTip(this.button1, "My button1");
            toolTip1.SetToolTip(this.chkParameter,
                "Funktion 1 und Funktion 2 werden als" +
                "\nParameterkurve aufgefasst (x(t), y(t))" +
                "\nFunktion 3 ist inaktiv ");



            curves = new List<Kurve>();

            curve1 = new Kurve();
            curve1.setKurvenart(Punktform.DICKER_PUNKT);
            curve1.setKurvenfarbe(Color.Cyan);
            curve1.setSteps(100);
            curve1.setXEinheit("mm");
            curve1.setYEinheit("cm^2");
            mp = new DiagParam("", "");
            curve1.setFktText("e(x/2)/(x**4+0.2)");
            

            curve2 = new Kurve();
            curve2.setKurvenart(Punktform.KREUZ);
            curve2.setKurvenfarbe(Color.Gray);
            curve2.setSteps(100);
            curve2.setXEinheit("");
            curve2.setYEinheit("");
            curve2.setFktText("((4.0)/(((x-1)**4)+1))");

            curve3 = new Kurve();
            curve3.setKurvenart(Punktform.RECHTECK_HOHL);
            curve3.setKurvenfarbe(Color.Red);
            curve3.setSteps(100);
            curve3.setXEinheit("");
            curve3.setYEinheit("");
            curve3.setFktText("(0.5*x)**(3)");

            tbCurve1.Text = "e(x/2)/(x**4+0.2)";
            tbCurve2.Text = "((4.0)/(((x - 1)**4) + 1))";
            tbCurve3.Text = "(0.5*x)**(3)";

            diag = new Diagramm(-8, 8, -10, 10, curves, mp);
            diag.WithShowString = true;
            btnRahmenfarbe.BackColor = Color.Green;
            mp.setcRahmenfarbe(Color.Green);

            Color col = Color.Blue;
            btnHintergrundfarbe.BackColor = col;
            btnHintergrundfarbe.ForeColor = Color.Yellow;
            diag.BackColor = col;
            chkAktiv1.Checked = true;
            chkAktiv2.Checked = true;
            chkAktiv3.Checked = true;

            panDiag.Controls.Add(diag);
            //pan.Refresh();
            diag.Refresh();



            /*

            Color col = Color.BLUE;
            btnHintergrund.setBackground(col);
            btnHintergrund.setForeground(Color.YELLOW);

            String err = "";

            //fkt = "3.0*(x*x)";
            fkt = "e(x/2)/(x**4+0.2)";
            err = addFunktionToCurves(fkt, Punktform.DICKER_PUNKT,
                Color.CYAN, "mm", "cm^2", curve1);
            if (DEBUG)
                System.out.println("1.te Funktion: " + (err.isEmpty() ? "Kein Fehler" : err));

            fkt = "(x)**(0.5)";
            err = addFunktionToCurves(fkt, Punktform.KREUZ,
                Color.GRAY, "", "", curve2);
            if (DEBUG)
                System.out.println("2.te Funktion: " + (err.isEmpty() ? "Kein Fehler" : err));

            fkt = "(0.5*x)**(3)";
            err = addFunktionToCurves(fkt, Punktform.RECHTECK_HOHL,
                Color.RED, "", "", curve3);
            if (DEBUG)
                System.out.println("3.te Funktion: " + (err.isEmpty() ? "Kein Fehler" : err));

            if (curves.size() == 0)
            {
                if (DEBUG)
                    System.out.println("Keine Funktion (nur Fehler?)");
                return;
            }
            curve1.setSteps(100);
            curve2.setSteps(100);
            curve3.setSteps(100);

            mm = new Diagramm(-8, 8, -10, 10, curves, mp);
            this.add(mm, BorderLayout.CENTER);
            mm.setOpaque(true);
            mm.setBackground(col);


            */

            //curve1.setFktText("e(x/2)/(tan(x)+0.2)");
            //curve1.setFktText("(x)**(0.5)");
            //            curve1.setFktText("(0.5 * x) * *(3)");

            /*
            Parser ps = new Parser();
            string err = ps.parsen(curve1.getFktText());
            curve1.setParser(ps);
            Parser ps0 = curve1.getParser();
            Kurve cur = ps0.bestimmeKurve(
                -8.0,8.0,
                curve1.getSteps());
            /* Werte der alten Kurve curve1 zuweisen*/
            /*
            curve1.setWerte(cur.getWerte());
            // Minimum und Maximumwerte bestimmen
            curve1.bestimmeMinMaxWerte();
            curves.Add(curve1);
            diag = new Diagramm(-2, 2, -10, 10, curves, mp);

            panDiag.Controls.Add(diag);
            //pan.Refresh();
            diag.Refresh();

            */
        }

        private void pan_Resize(object sender, EventArgs e)
        {
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pan.Refresh();
            //if (diag != null)
            //  diag.Refresh();
        }

        private void btnSqlite_Click(object sender, EventArgs e)
        {

            /*
            List<XYPoint> werte = null;
            DiagParam mp = new DiagParam("", "");
            Kurve curve4 = new Kurve();
            // SQLiteConnection.CreateFile("MyDatabase.sqlite");
            SQLiteConnection m_dbConnection;
            SQLiteDataReader reader = null;
            m_dbConnection = new SQLiteConnection("Data Source=meinedatenbank.db");
            m_dbConnection.Open();
            String xf = "select Breite, Laenge  from geos order by breite";
            SQLiteCommand command = new SQLiteCommand(xf, m_dbConnection);
            try
            {
                //                command.ExecuteNonQuery();
                reader = command.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            String[] columnNames = new String[2];
            columnNames[0] = "Breite";
            columnNames[1] = "Laenge";
            //werte = curve.getWerte();
            //if (werte != null)
              //  werte.Clear();
            //else
                werte = new List<XYPoint>();


            while (reader.Read())
            {
                XYPoint p = new XYPoint();

                p.setX(reader.GetDouble(1));
                p.setY(reader.GetDouble(0));
                if (!(((p.getX() < 1) || (p.getX() > 40) || (p.getY() < 40)
                || (p.getY() > 60))))
                     werte.Add(p);

            }

            
            curve4.setParser(null);
            curve4.setKurvenart(Punktform.RECHTECK_HOHL);
            curve4.setKurvenfarbe(Color.Black);
            curve4.setXEinheit("");
            curve4.setYEinheit("");
            curve4.setFktText("");
            curve4.setWerte(werte);
            curve4.bestimmeMinMaxWerte();


            /*
            if (radNurDatum.isSelected())
                curve4.setDatumart(Datumart.NurDatum);
            else if (radNurZeit.isSelected())
                curve4.setDatumart(Datumart.NurZeit);
            else if (radZeitDatum.isSelected())
                curve4.setDatumart(Datumart.DatumUndZeit);
            */
            /*
            curves = new List<Kurve>();

            curves.Add(curve4);
            diag = new Diagramm(5, 16, 47, 56,  curves, mp);

            //pan.Refresh();

            double dxmin = curve4.getxMin();
            double dxmax = curve4.getxMax();
            double dymin = curve4.getyMin();
            double dymax = curve4.getyMin();

            diag.setxRaster(true);
            diag.setyRaster(true);
//            curve4.bestimmeMinMaxWerte();
            diag.setxMin(curve4.getxMin());
            diag.setxMax(curve4.getxMax());
            diag.setyMin(curve4.getyMin());
            diag.setyMax(curve4.getyMax());
            
            //diag.Refresh();
            panDiag.Controls.Add(diag);
            */
        }

        private void ShowSettingsCurve(object sender, EventArgs e)
        {
            Kurve cAktuell = null;
            TextBox tbAktuell = null;
            CheckBox chkAktuell = null;

            if (sender is Label)
            {
                if (((Label)sender).Text == "Funktion 1")
                {
                    cAktuell = curve1;
                    tbAktuell = tbCurve1;
                    chkAktuell = chkAktiv1;
                }
                else if (((Label)sender).Text == "Funktion 2")
                {
                    cAktuell = curve2;
                    tbAktuell = tbCurve2;
                    chkAktuell = chkAktiv2;
                }
                else if (((Label)sender).Text == "Funktion 3")
                {
                    cAktuell = curve3;
                    tbAktuell = tbCurve3;
                    chkAktuell = chkAktiv3;
                }

            }
            else
            {
                if (sender is Panel)
                {
                    if (((Panel)sender).Name == "panFunktion1")
                    {
                        cAktuell = curve1;
                        tbAktuell = tbCurve1;
                        chkAktuell = chkAktiv1;
                    }
                    else if (((Panel)sender).Name == "panFunktion2")
                    {
                        cAktuell = curve2;
                        tbAktuell = tbCurve2;
                        chkAktuell = chkAktiv2;
                    }
                    else if (((Panel)sender).Name == "panFunktion3")
                    {
                        cAktuell = curve3;
                        tbAktuell = tbCurve3;
                        chkAktuell = chkAktiv3;
                    }

                }


            }



            SettingsCurve frmSetCurve = new SettingsCurve();

            frmSetCurve.Funktion = cAktuell.getFktText();
            frmSetCurve.XEinheit = cAktuell.getXEinheit();
            frmSetCurve.YEinheit = cAktuell.getYEinheit();
            frmSetCurve.PunkteFarbe = cAktuell.getKurvenfarbe();
            frmSetCurve.AnzahlPunkte = cAktuell.getSteps();
            frmSetCurve.IndexPunkteArt = (int)cAktuell.getKurvenart();

            frmSetCurve.SetParameters();



            DialogResult dr = frmSetCurve.ShowDialog();

            if (dr == DialogResult.Cancel)
                return;
            else if (dr == DialogResult.OK)
            {
                chkAktuell.Checked = false;
                tbAktuell.Text = frmSetCurve.Funktion;
                cAktuell.setKurvenart((Punktform)frmSetCurve.IndexPunkteArt);
                cAktuell.setSteps(frmSetCurve.AnzahlPunkte);
                cAktuell.setKurvenfarbe(frmSetCurve.PunkteFarbe);
                cAktuell.setYEinheit(frmSetCurve.YEinheit);
                cAktuell.setXEinheit(frmSetCurve.XEinheit);
                cAktuell.setFktText(frmSetCurve.Funktion);
                chkAktuell.Checked = true;
                chkAktuell.Checked = true;
                chkAktuell.Checked = true;
            }
        }

        private void Funktion_Load(object sender, EventArgs e)
        {
            StartingRoutine(sender, e);
        }

        private void chkAktiv1_CheckedChanged(object sender, EventArgs e)
        {
            maleDiagramm();
        }

        private void chkAktiv2_CheckedChanged(object sender, EventArgs e)
        {
            maleDiagramm();
        }

        private void chkAktiv3_CheckedChanged(object sender, EventArgs e)
        {
            maleDiagramm();
        }
        private void maleDiagramm()
        {

            if (!chkParameter.Checked)
            {

                string err = "";
                curves.Clear();
                if (chkAktiv1.Checked)
                {
                    Parser ps = new Parser();
                    err = ps.parsen(curve1.getFktText());
                    if (err.Trim() == "")
                    {
                        ps.bestimmeKurve((double)numericUpDown1.Value,
                            (double)numericUpDown2.Value, curve1.getSteps());
                        curve1.setParser(ps);
                        
                        curves.Add(curve1);
                    }
                    else
                    {
                        tbCurve1.Text += " - " + err;
                        chkAktiv1.Checked = false;
                    }
                }
                if (chkAktiv2.Checked)
                {
                    Parser ps = new Parser();
                    err = ps.parsen(curve2.getFktText());

                    if (err.Trim() == "")
                    {
                        ps.bestimmeKurve((double)numericUpDown1.Value,
                            (double)numericUpDown2.Value, curve2.getSteps());
                        curve2.setParser(ps);
                        curves.Add(curve2);
                    }
                    else
                    {
                        tbCurve2.Text += " - " + err;
                        chkAktiv2.Checked = false;
                    }
                }
                if (chkAktiv3.Checked)
                {
                    Parser ps = new Parser();
                    err = ps.parsen(curve3.getFktText());

                    if (err.Trim() == "")
                    {
                        ps.bestimmeKurve((double)numericUpDown1.Value,
                            (double)numericUpDown2.Value, curve3.getSteps());
                        curve3.setParser(ps);
                        curves.Add(curve3);
                    }
                    else
                    {
                        tbCurve3.Text += " - " + err;
                        chkAktiv3.Checked = false;
                    }
                }

            }
            else
            {
                string err = "";
                curves.Clear();
                Parser ps1 = new Parser();
                string str = curve1.getFktText();
                err = ps1.parsen(curve1.getFktText());
                if (err.Trim() != "")
                {
                    tbCurve1.Text = err;
                    return;
                }
                //curve1.setParser(ps1);

                Kurve curvea = ps1.bestimmeKurve(diag.getxMin(), diag.getxMax(), curve1.getSteps());
                err = "";
                Parser ps2 = new Parser();
                err = ps2.parsen(curve2.getFktText());
                if (err.Trim() != "")
                {
                    tbCurve2.Text = err;
                    return;
                }
                //curve2.setParser(ps2);
                Kurve curveb = ps2.bestimmeKurve(diag.getxMin(), diag.getxMax(), curve2.getSteps());

                List<XYPoint> lx1 = curvea.getWerte();
                List<XYPoint> lx2 = curveb.getWerte();
                Kurve ka = new Kurve();
                List<XYPoint> pk = new List<XYPoint>();
                pk.Clear();
                for (int i = 0; i < lx1.Count; i++)
                {
                    XYPoint pxy = new XYPoint(lx1[i].getY(), lx2[i].getY());
                    pxy.setstr("("+pxy.getX().ToString("0.##",CultureInfo.InvariantCulture)+
                                ","+ pxy.getY().ToString("0.##", CultureInfo.InvariantCulture)+")") ;
                    pk.Add(pxy);

                }
                ka.setParser(null);
                ka.setKurvenart(Punktform.DICKER_PUNKT);
                ka.setKurvenfarbe(Color.Yellow);
                ka.setXEinheit("");
                ka.setYEinheit("");
                ka.setFktText("");

                ka.setWerte(pk);
                curves.Add(ka);


            }

            this.Refresh();

        }

        private void updownminx_ValueChanged(object sender, EventArgs e)
        {
            diag.setxMin(Convert.ToDouble(updownminx.Value));
            numericUpDown1.Value = updownminx.Value;
            pan.Refresh();
        }

        private void updownmaxx_ValueChanged(object sender, EventArgs e)
        {
            diag.setxMax(Convert.ToDouble(updownmaxx.Value));
            numericUpDown2.Value = updownmaxx.Value;
            pan.Refresh();
        }

        private void updownminy_ValueChanged(object sender, EventArgs e)
        {
            diag.setyMin(Convert.ToDouble(updownminy.Value));
            numericUpDown3.Value = updownminy.Value;
            pan.Refresh();
        }

        private void updownmaxy_ValueChanged(object sender, EventArgs e)
        {
            diag.setyMax(Convert.ToDouble(updownmaxy.Value));
            numericUpDown4.Value = updownmaxy.Value;
            pan.Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            diag.setxMin(Convert.ToDouble(updownminx.Value));
            updownminx.Value = numericUpDown1.Value;
            pan.Refresh();

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            diag.setxMax(Convert.ToDouble(updownmaxx.Value));
            updownmaxx.Value = numericUpDown2.Value;
            pan.Refresh();

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            diag.setyMin(Convert.ToDouble(updownminy.Value));
            updownminy.Value = numericUpDown3.Value;
            pan.Refresh();

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            diag.setyMax(Convert.ToDouble(updownmaxy.Value));
            updownmaxy.Value = numericUpDown4.Value;
            pan.Refresh();

        }

        private void chkParameter_CheckedChanged(object sender, EventArgs e)
        {

            maleDiagramm();
        }

        private void btnHintergrundfarbe_Click(object sender, EventArgs e)
        {

            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnHintergrundfarbe.BackColor = cd.Color;
                btnHintergrundfarbe.ForeColor =
                    Color.FromArgb(255 - cd.Color.R, 255 - cd.Color.G, 255 - cd.Color.B);
                diag.BackColor = cd.Color;
            }
            else
                MessageBox.Show("Abbruch");


            pan.Refresh();


        }

        private void btnRahmenfarbe_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnRahmenfarbe.BackColor = cd.Color;
                mp.setcRahmenfarbe(cd.Color);
                btnRahmenfarbe.ForeColor =
                    Color.FromArgb(255 - cd.Color.R, 255 - cd.Color.G, 255 - cd.Color.B);
            }
            else
                MessageBox.Show("Abbruch");


            pan.Refresh();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            chkAktiv1.Checked = false;
            chkAktiv2.Checked = false;
            chkAktiv3.Checked = false;
            curves.Clear();
            updownminx.Value = -8.0m;
            updownmaxx.Value = +8.0m;
            updownminy.Value = -10.0m;
            updownmaxy.Value = 10.0m;
            chkParameter.Checked = false;
            chkAktiv1.Checked = true;
            chkAktiv2.Checked = true;
            chkAktiv3.Checked = true;
            updownminx_ValueChanged(null, null);
            updownmaxx_ValueChanged(null, null);
            updownminy_ValueChanged(null, null);
            updownmaxy_ValueChanged(null, null);

            numericUpDown1_ValueChanged(null, null);
            numericUpDown2_ValueChanged(null, null);
            numericUpDown3_ValueChanged(null, null);
            numericUpDown4_ValueChanged(null, null);



            btnRahmenfarbe.BackColor = Color.Green;
            mp.setcRahmenfarbe(Color.Green);

            Color col = Color.Blue;
            btnHintergrundfarbe.BackColor = col;
            btnHintergrundfarbe.ForeColor = Color.Yellow;
            diag.BackColor = col;

            pan.Refresh();
        }

        private void btnImageErstellen_Click(object sender, EventArgs e)
        {
            //diag.Image.Save("c:\\temp\\testbild.bmp");
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = "C:\\Temp";
            sfd.Filter = 
                " Bilder (*.bmp; *jpg;*jpeg;*png;*gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif|" +
                " Alle Dateien (*.*)|*.*";
            sfd.Title = "Bild zum Speichern auswählen und mit ok bestätigen ...";

            if (sfd.ShowDialog() == DialogResult.OK)
                ExportToBmp(sfd.FileName);
            else
                MessageBox.Show("Abbruch");

            

        }
        public void ExportToBmp(string path)
        {
            using (var bitmap = new Bitmap(diag.Width, diag.Height))
            {
                diag.DrawToBitmap(bitmap, diag.ClientRectangle);
                ImageFormat imageFormat = null;

                var extension = Path.GetExtension(path);
                switch (extension)
                {
                    case ".bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;
                    case ".png":
                        imageFormat = ImageFormat.Png;
                        break;
                    case ".jpeg":
                    case ".jpg":
                        imageFormat = ImageFormat.Jpeg;
                        break;
                    case ".gif":
                        imageFormat = ImageFormat.Gif;
                        break;
                    default:
                        throw new NotSupportedException("Dateiendung wird nicht unterstützt!");
                }

                try
                {
                    bitmap.Save(path, imageFormat);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bild kann nicht abgespeichert werden!");
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintImage();
        }
        private void PrintImage()
        {
            PrintDocument pd = new PrintDocument();

            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            pd.OriginAtMargins = false;
            pd.DefaultPageSettings.Landscape = true;

            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            PrintDialog pddiag = new PrintDialog();
            pddiag.Document = pd;
            pddiag.ShowDialog();
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dokument kann nicht gedruckt werden!");
            }
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Querformat
            var bitmap = new Bitmap(diag.Width, diag.Height);
            diag.DrawToBitmap(bitmap, diag.ClientRectangle);
            double cmToUnits = 100 / 2.54;
            // PapierPhotoGroesse
            e.Graphics.DrawImage(bitmap, 0, 0, (float)(15 * cmToUnits), (float)(10 * cmToUnits));
           // Din A4
            // e.Graphics.DrawImage(bitmap, 0, 0, (float)(29.7 * cmToUnits), (float)(21 * cmToUnits));
        }
        private void radEinpassen_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radBtn = (RadioButton)sender;

            if ((radBtn == radFkt1)&&(radBtn != btnRadLast))
            {
                if (chkAktiv1.Checked)
                {

                    curve1.bestimmeMinMaxWerte();

                    diag.setxMin(curve1.getxMin());
                    diag.setxMax(curve1.getxMax());
                    diag.setyMin(curve1.getyMin());
                    diag.setyMax(curve1.getyMax());

                    maleDiagramm();

                }
            }
            else if ((radBtn == radFkt2) && (radBtn != btnRadLast))
            {
                if (chkAktiv2.Checked)
                {
                    curve2.bestimmeMinMaxWerte();

                    diag.setxMin(curve2.getxMin());
                    diag.setxMax(curve2.getxMax());
                    diag.setyMin(curve2.getyMin());
                    diag.setyMax(curve2.getyMax());

                    maleDiagramm();
                }
            }
            else if ((radBtn == radFkt3) && (radBtn != btnRadLast))
            {
                if (chkAktiv3.Checked)
                {
                    curve3.bestimmeMinMaxWerte();

                    diag.setxMin(curve3.getxMin());
                    diag.setxMax(curve3.getxMax());
                    diag.setyMin(curve3.getyMin());
                    diag.setyMax(curve3.getyMax());

                    maleDiagramm();
                }
            }
            else if ((radBtn == radKeine) && (radBtn != btnRadLast))
            {
                cmdReset_Click(null,null);
            }

            btnRadLast = radBtn;
        }

        private void cmdRandom_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            curves.Clear();
            Kurve ka = new Kurve();
            List<XYPoint> pk = new List<XYPoint>();
            pk.Clear();
            ka.setParser(null);
            ka.setKurvenart(Punktform.DICKER_PUNKT);
            ka.setKurvenfarbe(Color.Yellow);
            ka.setXEinheit("");
            ka.setYEinheit("");
            ka.setFktText("");

            ka.setWerte(pk);
            curves.Add(ka);
            for (int i = 0; i < 1000; i++)
            {
                double r1 = r.NextDouble();
                double r2 = r.NextDouble();
                XYPoint pxy = new XYPoint(r1* 18 -9, r2  * 20 - 10);
                pk.Add(pxy);
                curves.Clear();
                ka.setWerte(pk);
                curves.Add(ka);
               
                //if ((i % 100) == 0)
                    panDiag.Refresh();
                Thread.Sleep(1);
            }
            this.Refresh();

        }
    }
}
