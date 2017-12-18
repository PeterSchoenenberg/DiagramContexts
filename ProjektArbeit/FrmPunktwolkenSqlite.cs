using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.IO;
using System.Data.OleDb;
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

namespace ProjektArbeit
{

    public partial class FrmPunktwolkenSqlite : Form
    {
        enum EPoint { ePoint1, ePoint2 };

        private List<Kurve> curves = new List<Kurve>();
        private List<Kurve> curvesht = new List<Kurve>();
        private List<Kurve> curveslg = new List<Kurve>();
        Diagramm diag = null;
        Diagramm diaght = null;
        Diagramm diaglg = null;
        Diagramm mm = null;

        EPoint ePoint = EPoint.ePoint1;

        public DatabaseKind dbKind = DatabaseKind.dbSqlite;

        public FrmPunktwolkenSqlite()
        {
            InitializeComponent();

            grdView_Resize(null, null);

        }

        public void AdjustDB()
        {

            if (dbKind == DatabaseKind.dbSqlite)
            {
                this.Text = "Auslesen aus sqlite - Datenbanken";
                btnGPX.Visible = true;
                btnPostleitzahlen.Visible = true;
                btnLaendergrenzensqlite.Visible = true;
            }
            else if (dbKind == DatabaseKind.dbAccess)
            {
                this.Text = "Auslesen aus Access - Datenbanken";
                btnGPX.Visible = false;
                btnPostleitzahlen.Visible = false;
                btnLaendergrenzensqlite.Visible = false;
            }
            else
                this.Text = "Fehler: dbKind nicht richtig gesetzt";


        }


        private void btnPostleitzahlen_Click(object sender, EventArgs e)
        {
            grdView.Rows.Clear();

            diaght = null;
            diaglg = null;
            panRight.Controls.Clear();

            List<XYPoint> werte = null;
            DiagParam mp = new DiagParam("", "");
            Kurve curve4 = new Kurve();
            // SQLiteConnection.CreateFile("MyDatabase.sqlite");
            SQLiteConnection m_dbConnection;
            SQLiteDataReader reader = null;
            m_dbConnection = new SQLiteConnection("Data Source=meinedatenbank.db");
            m_dbConnection.Open();
            String xf = "select Breite, Laenge, ort  from geos order by breite";
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
                p.setstr(reader.GetString(2));
                p.setX(reader.GetDouble(1));
                p.setY(reader.GetDouble(0));
                if (!(((p.getX() < 1) || (p.getX() > 40) || (p.getY() < 40)
                || (p.getY() > 60))))
                {
                    werte.Add(p);
                    /*
                    int nRow = grdView.Rows.Add();
                    DataGridViewRow grdRow = grdView.Rows[nRow];
                    DataGridViewCellCollection grdCell = grdRow.Cells;
                    grdCell[0].Value = nRow.ToString();
                    grdCell[1].Value = p.getstr();
                    grdCell[2].Value = p.getX();
                    grdCell[3].Value = p.getY();
                    */
                }

            }


            curve4.setParser(null);
            curve4.setKurvenart(Punktform.RECHTECK_HOHL);
            curve4.setKurvenfarbe(Color.Red);
            curve4.setXEinheit("");
            curve4.setYEinheit("");
            curve4.setFktText("");
            curve4.setWerte(werte);
            curve4.bestimmeMinMaxWerte();
            mp.setcRahmenfarbe(Color.Black);

            /*
            if (radNurDatum.isSelected())
                curve4.setDatumart(Datumart.NurDatum);
            else if (radNurZeit.isSelected())
                curve4.setDatumart(Datumart.NurZeit);
            else if (radZeitDatum.isSelected())
                curve4.setDatumart(Datumart.DatumUndZeit);
            */
            curves = new List<Kurve>();

            curves.Add(curve4);
            diag = new Diagramm(5, 16, 47, 56, curves, mp);

            diag.ShowSpecialValuesString = "dorf";
            diag.ShowSpecialValuesColor = Color.Blue;
            diag.ShowSpecialValues = true;


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
            diag.BackColor = Color.LightGreen;
            diag.HintColor = Color.Black;
            diag.WithShowString = true;

            //diag.Refresh();
            panRight.Controls.Add(diag);

        }

        private void FrmPunktwolkenSqlite_Resize(object sender, EventArgs e)
        {
            //diag.Invalidate();
            panRight.Refresh();
        }

        private void btnHaltestellen_Click(object sender, EventArgs e)
        {
            grdView.Rows.Clear();


            diag = null;
            diaglg = null;
            panRight.Controls.Clear();
            List<XYPoint> werte = null;
            DiagParam mp = new DiagParam("", "");
            mp.setcRahmenfarbe(Color.Black);
            Kurve curve4 = new Kurve();
            // SQLiteConnection.CreateFile("MyDatabase.sqlite");

            if (dbKind == DatabaseKind.dbSqlite)
            {

                SQLiteConnection m_dbConnection;
                SQLiteDataReader reader = null;
                m_dbConnection = new SQLiteConnection("Data Source=bahnhoefe.db");
                m_dbConnection.Open();
                String xf = "select name,breite,laenge  from haltestellen";
                SQLiteCommand command = new SQLiteCommand(xf, m_dbConnection);
                try
                {
                    reader = command.ExecuteReader();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                String[] columnNames = new String[2];
                columnNames[0] = "Breite";
                columnNames[1] = "Laenge";
                werte = new List<XYPoint>();
                while (reader.Read())
                {
                    XYPoint p = new XYPoint();
                    string sname = reader.GetString(0);
                    p.setstr(sname);
                    string sx = reader.GetString(2);
                    string sy = reader.GetString(1);
                    sx.Replace(',', '.');
                    sy.Replace(',', '.');
                    double dx = Convert.ToDouble(sx);
                    double dy = Convert.ToDouble(sy);

                    p.setX(dx);
                    p.setY(dy);
                    if (!(((p.getX() < 1) || (p.getX() > 40) || (p.getY() < 40)
                    || (p.getY() > 60))))
                    {
                        werte.Add(p);
                        int nRow = grdView.Rows.Add();
                        DataGridViewRow grdRow = grdView.Rows[nRow];
                        DataGridViewCellCollection grdCell = grdRow.Cells;
                        grdCell[0].Value = nRow.ToString();
                        grdCell[1].Value = sname;
                        grdCell[2].Value = sx;
                        grdCell[3].Value = sy;

                    }
                }
                reader.Close();

            }
            else if (dbKind == DatabaseKind.dbAccess)
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataReader reader;


                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                    "Data Source=Haltestellen.accdb";

                cmd.Connection = con;
                cmd.CommandText = "SELECT name,breite,laenge  FROM D_Bahnhof_2017_09";

                try
                {
                    con.Open();

                    reader = cmd.ExecuteReader();
                    werte = new List<XYPoint>();

                    while (reader.Read())
                    {
                        XYPoint p = new XYPoint();
                        string sname = reader.GetString(0);
                        p.setstr(sname);
                        double dx = reader.GetDouble(2);
                        double dy = reader.GetDouble(1);
                        //sx.Replace(',', '.');
                        //sy.Replace(',', '.');
                        //double dx = Convert.ToDouble(sx);
                        //double dy = Convert.ToDouble(sy);

                        p.setX(dx);
                        p.setY(dy);
                        if (!(((p.getX() < 1) || (p.getX() > 40) || (p.getY() < 40)
                        || (p.getY() > 60))))
                        {
                            werte.Add(p);
                            int nRow = grdView.Rows.Add();
                            DataGridViewRow grdRow = grdView.Rows[nRow];
                            DataGridViewCellCollection grdCell = grdRow.Cells;
                            grdCell[0].Value = nRow.ToString();
                            grdCell[1].Value = sname;
                            grdCell[2].Value = dx.ToString();
                            grdCell[3].Value = dy.ToString(); ;

                        }
                    }
                    reader.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

            curve4.setParser(null);
            curve4.setKurvenart(Punktform.DICKER_PUNKT);
            curve4.setKurvenfarbe(Color.Red);
            curve4.setXEinheit("Längengrade");
            curve4.setYEinheit("Breitengrade");
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
            curvesht = new List<Kurve>();

            curvesht.Add(curve4);
            diaght = new Diagramm(5, 16, 47, 56, curvesht, mp);
            diaght.ShowSpecialValuesString = "Hbf";
            diaght.ShowSpecialValuesColor = Color.Blue;
            diaght.ShowSpecialValues = true;



            //pan.Refresh();

            double dxmin = curve4.getxMin();
            double dxmax = curve4.getxMax();
            double dymin = curve4.getyMin();
            double dymax = curve4.getyMax();

            diaght.setxRaster(true);
            diaght.setyRaster(true);

            //diaght.set
            curve4.bestimmeMinMaxWerte();
            /*
            diaght.setxMin(0.0);
            diaght.setxMax(20);
            diaght.setyMin(40);
            diaght.setyMax(70);
            */
            diaght.setxMin(curve4.getxMin());
            diaght.setxMax(curve4.getxMax());
            diaght.setyMin(curve4.getyMin());
            diaght.setyMax(curve4.getyMax());
            diaght.BackColor = Color.LightGreen;
            diaght.HintColor = Color.Black;


            diaght.WithShowString = true;

            //diag.Refresh();
            panRight.Controls.Add(diaght);

        }

        private void oTimer_Tick(object sender, EventArgs e)
        {
            Diagramm dia = null;
            if ((diag != null) || (diaght != null) || (diaglg != null))
            {
                if (diag != null)
                {
                    dia = diag;
                }
                else if (diaght != null)
                {
                    dia = diaght;
                }
                else if (diaglg != null)
                {
                    dia = diaglg;
                }


                if (dia.CanGetPoint)
                {
                    if (ePoint == EPoint.ePoint1)
                    {
                        lbl1.Text = dia.MouseDownString;

                        tbLatitude1.Text = dia.YPointValue.ToString("0.###",
                            CultureInfo.InvariantCulture);
                        tbLongitude1.Text = dia.XPointValue.ToString("0.###",
                            CultureInfo.InvariantCulture);
                        ePoint = EPoint.ePoint2;
                        lbl2.Text = "";
                        tbLatitude2.Text = "";
                        tbLongitude2.Text = "";
                        lblDistance.Text = "";

                    }
                    else if (ePoint == EPoint.ePoint2)
                    {
                        lbl2.Text = dia.MouseDownString;
                        tbLatitude2.Text = dia.YPointValue.ToString("0.###",
                            CultureInfo.InvariantCulture);
                        tbLongitude2.Text = dia.XPointValue.ToString("0.###",
                            CultureInfo.InvariantCulture);
                        ePoint = EPoint.ePoint1;
                        double lat1, lat2, lon1, lon2;
                        lon1 = double.Parse(tbLongitude1.Text.Replace('.', ','));
                        lon2 = double.Parse(tbLongitude2.Text.Replace('.', ','));
                        lat1 = double.Parse(tbLatitude1.Text.Replace('.', ','));
                        lat2 = double.Parse(tbLatitude2.Text.Replace('.', ','));

                        double lat = (lat1 + lat2) / 2 * 0.01745;
                        double dx = 111.3 * Math.Cos(lat) * (lon1 - lon2);
                        double dy = 111.3 * (lat1 - lat2);
                        double distance = Math.Sqrt(dx * dx + dy * dy);
                        lblDistance.Text = "Abstand: " + distance.ToString("0.##",
                            CultureInfo.InvariantCulture) + " km";
                    }
                    dia.CanGetPoint = false;
                }
            }
        }
    


        private void grdView_Resize(object sender, EventArgs e)
        {
            grdView.Columns[1].Width = grdView.Width - 300;
        }

        private void grdView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((diag == null) && (diaght != null))
            {
                diaght.ShowSpecialValues = true;
                diaght.ShowSpecialValuesColor = Color.Blue;
                diaght.ShowSpecialValuesString = 
                    grdView.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
                panRight.Refresh();
            }
        }

        private void btnGPX_Click(object sender, EventArgs e)
        {
            grdView.Rows.Clear();


            diag = null;
            diaght = null;
            panRight.Controls.Clear();
            List<XYPoint> werte = null;
            DiagParam mp = new DiagParam("", "");
            mp.setcRahmenfarbe(Color.Black);
            Kurve curve4 = new Kurve();


            // #######################################################

            if (!File.Exists("Landesgrenzen.gpx"))
                return;

            XmlReader xr = new XmlTextReader("Landesgrenzen.gpx");


 

            // #################################################################


            werte = new List<XYPoint>();

            string sx = "";
            string sy = "";
            while (xr.Read())
            {

                if (xr.NodeType == XmlNodeType.Element)
                {
                    if ((xr.Name == "trkpt") && (xr.AttributeCount > 0))
                    {
                        while (xr.MoveToNextAttribute())
                        {
                            if (xr.Name == "lat")
                            {
                                sy = xr.Value;
                            }
                            xr.MoveToNextAttribute();
                            if (xr.Name == "lon")
                            {
                                sx = xr.Value;
                            }


                            XYPoint p = new XYPoint();

                            


                            sx.Replace('.', ',');
                            sy.Replace('.', ',');
                            double dx = Convert.ToDouble(sx, CultureInfo.InvariantCulture);
                            double dy = Convert.ToDouble(sy, CultureInfo.InvariantCulture);

                            p.setX(dx);
                            p.setY(dy);
                            if (!(((p.getX() < 1) || (p.getX() > 40) || (p.getY() < 40)
                            || (p.getY() > 60))))
                            {
                                werte.Add(p);
                                int nRow = grdView.Rows.Add();
                                DataGridViewRow grdRow = grdView.Rows[nRow];
                                DataGridViewCellCollection grdCell = grdRow.Cells;
                                grdCell[0].Value = nRow.ToString();
                                grdCell[1].Value = "";
                                grdCell[2].Value = sx;
                                grdCell[3].Value = sy;

                            }

                        }
                    }
                }

            }

            xr.Close();

            curve4.setParser(null);
            curve4.setKurvenart(Punktform.PUNKT);
            curve4.setKurvenfarbe(Color.Black);
            curve4.setXEinheit("Längengrade");
            curve4.setYEinheit("Breitengrade");
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
            curveslg = new List<Kurve>();

            curveslg.Add(curve4);
            diaglg = new Diagramm(5, 16, 47, 56, curveslg, mp);
            //diaght.ShowSpecialValuesString = "Hbf";
            //diaght.ShowSpecialValuesColor = Color.Blue;
            //diaght.ShowSpecialValues = true;



            //pan.Refresh();

            double dxmin = curve4.getxMin();
            double dxmax = curve4.getxMax();
            double dymin = curve4.getyMin();
            double dymax = curve4.getyMax();

            diaglg.setxRaster(true);
            diaglg.setyRaster(true);

            //diaght.set
            curve4.bestimmeMinMaxWerte();
            /*
            diaght.setxMin(0.0);
            diaght.setxMax(20);
            diaght.setyMin(40);
            diaght.setyMax(70);
            */
            diaglg.setxMin(curve4.getxMin());
            diaglg.setxMax(curve4.getxMax());
            diaglg.setyMin(curve4.getyMin());
            diaglg.setyMax(curve4.getyMax());
            diaglg.BackColor = Color.LightGreen;
            diaglg.HintColor = Color.Black;


            //diaght.WithShowString = true;

            //diag.Refresh();
            panRight.Controls.Add(diaglg);

        }

        private void btnLaendergrenzensqlite_Click(object sender, EventArgs e)
        {
            grdView.Rows.Clear();


            diag = null;
            diaglg = null;
            panRight.Controls.Clear();
            List<XYPoint> werte = null;
            DiagParam mp = new DiagParam("", "");
            mp.setcRahmenfarbe(Color.Black);
            Kurve curve4 = new Kurve();
            // SQLiteConnection.CreateFile("MyDatabase.sqlite");

            if (dbKind == DatabaseKind.dbSqlite)
            {

                SQLiteConnection m_dbConnection;
                SQLiteDataReader reader = null;
                m_dbConnection = new SQLiteConnection("Data Source=SqliteLaendergrenzen.db");
                m_dbConnection.Open();
                String xf = "select idx,breite,laenge  from laendergrenzen order by breite";
                SQLiteCommand command = new SQLiteCommand(xf, m_dbConnection);
                try
                {
                    reader = command.ExecuteReader();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                String[] columnNames = new String[2];
                columnNames[0] = "Breite";
                columnNames[1] = "Laenge";
                werte = new List<XYPoint>();
                while (reader.Read())
                {
                    XYPoint p = new XYPoint();
                    int sname = reader.GetInt32(0);
                    p.setstr(sname.ToString());
                    double dx = reader.GetDouble(2);
                    double dy = reader.GetDouble(1);

                    /*
                    string sx = reader.GetString(2);
                    string sy = reader.GetString(1);
                    sx.Replace(',', '.');
                    sy.Replace(',', '.');
                    double dx = Convert.ToDouble(sx);
                    double dy = Convert.ToDouble(sy);
                    */
                    p.setX(dx);
                    p.setY(dy);
                    if (!(((p.getX() < 1) || (p.getX() > 40) || (p.getY() < 40)
                    || (p.getY() > 60))))
                    {
                        werte.Add(p);
                        int nRow = grdView.Rows.Add();
                        DataGridViewRow grdRow = grdView.Rows[nRow];
                        DataGridViewCellCollection grdCell = grdRow.Cells;
                        grdCell[0].Value = nRow.ToString();
                        grdCell[1].Value = sname;
                        grdCell[2].Value = dx.ToString();
                        grdCell[3].Value = dy.ToString();

                    }
                }
                reader.Close();

            }
            else if (dbKind == DatabaseKind.dbAccess)
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataReader reader;


                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                    "Data Source=Haltestellen.accdb";

                cmd.Connection = con;
                cmd.CommandText = "SELECT name,breite,laenge  FROM D_Bahnhof_2017_09";

                try
                {
                    con.Open();

                    reader = cmd.ExecuteReader();
                    werte = new List<XYPoint>();

                    while (reader.Read())
                    {
                        XYPoint p = new XYPoint();
                        string sname = reader.GetString(0);
                        p.setstr(sname);
                        double dx = reader.GetDouble(2);
                        double dy = reader.GetDouble(1);
                        //sx.Replace(',', '.');
                        //sy.Replace(',', '.');
                        //double dx = Convert.ToDouble(sx);
                        //double dy = Convert.ToDouble(sy);

                        p.setX(dx);
                        p.setY(dy);
                        if (!(((p.getX() < 1) || (p.getX() > 40) || (p.getY() < 40)
                        || (p.getY() > 60))))
                        {
                            werte.Add(p);
                            int nRow = grdView.Rows.Add();
                            DataGridViewRow grdRow = grdView.Rows[nRow];
                            DataGridViewCellCollection grdCell = grdRow.Cells;
                            grdCell[0].Value = nRow.ToString();
                            grdCell[1].Value = sname;
                            grdCell[2].Value = dx.ToString();
                            grdCell[3].Value = dy.ToString(); ;

                        }
                    }
                    reader.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

            curve4.setParser(null);
            curve4.setKurvenart(Punktform.PUNKT);
            curve4.setKurvenfarbe(Color.Black);
            curve4.setXEinheit("Längengrade");
            curve4.setYEinheit("Breitengrade");
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
            curvesht = new List<Kurve>();

            curvesht.Add(curve4);
            diaght = new Diagramm(5, 16, 47, 56, curvesht, mp);
            /*
            diaght.ShowSpecialValuesString = "Hbf";
            diaght.ShowSpecialValuesColor = Color.Blue;
            diaght.ShowSpecialValues = true;
            */


            //pan.Refresh();

            double dxmin = curve4.getxMin();
            double dxmax = curve4.getxMax();
            double dymin = curve4.getyMin();
            double dymax = curve4.getyMax();

            diaght.setxRaster(true);
            diaght.setyRaster(true);

            //diaght.set
            curve4.bestimmeMinMaxWerte();
            /*
            diaght.setxMin(0.0);
            diaght.setxMax(20);
            diaght.setyMin(40);
            diaght.setyMax(70);
            */
            diaght.setxMin(curve4.getxMin());
            diaght.setxMax(curve4.getxMax());
            diaght.setyMin(curve4.getyMin());
            diaght.setyMax(curve4.getyMax());
            diaght.BackColor = Color.LightGreen;
            diaght.HintColor = Color.Black;


            diaght.WithShowString = false;

            //diag.Refresh();
            panRight.Controls.Add(diaght);


        }
    }
}
