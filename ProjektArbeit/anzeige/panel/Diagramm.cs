using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ProjektArbeit.utils.util;
using ProjektArbeit.parser.parse;

namespace ProjektArbeit.anzeige.panel
{

    /**
     * Diagramm wird auf JPanel-Print gemalt, könnte beliebig viele
     * Diagramme erzeugen und dort Kurven darstellen, jedes
     * JPanel unabhängig von Rest
     * 
     * @author PS
     *
     */
    public class Diagramm : PictureBox   // schneller als von panel ableiten
    {
        private double xMin;
        private double xMax;
        private double yMin;
        private double yMax;
        private double xMinB;
        private double xMaxB;
        private double yMinB;
        private double yMaxB;
        public List<XYPoint> psp = null;
        List<Kurve> curves = null;
        DiagParam mp;

        private bool xRaster;
        private bool yRaster;

        public double XPointValue { get; set; }
        public double YPointValue { get; set; }

        public bool CanGetPoint { get; set; }

        public Color HintColor { get; set; }


        public bool ShowSpecialValues { get; set; }
        public string ShowSpecialValuesString { get; set; }
        public Color ShowSpecialValuesColor { get; set; }



        private bool bWithShowString = false;
        public bool WithShowString
        {
            get { return bWithShowString; }
            set { bWithShowString = value; }
        }

        public string MouseDownString { get; set; }


        private string sMouseOverString = "";
        public string MouseOverString
        {
            get { return sMouseOverString; }
            set { sMouseOverString = value; }
        }

    public Diagramm()
    {
            XPointValue = 0.0;
            YPointValue = 0.0;
            CanGetPoint = false;
            ShowSpecialValues = false;
            ShowSpecialValuesColor = Color.Blue;
            ShowSpecialValuesString = "yyy";
    }

    /**
     *
     * @param xMin
     * @param xMax
     * @param yMin
     * @param yMax
     * @param curves
     *          - Liste von Kurven mit jeweils eigenen Parser
     *          bzw. geparste Funktion, könnte aber auch
     *          Datenbankfeld sein, dann kein Parser - Objekt
     * @param mp
     */
    public Diagramm(double xMin, double xMax,
        double yMin, double yMax,
        List<Kurve> curves, DiagParam mp)
    {
        HintColor = Color.Green;
        this.curves = curves;
        this.xMin = xMin;
        this.xMax = xMax;
        this.yMin = yMin;
        this.yMax = yMax;
        // xMin bis yMax können sich ändern, die B- Werte davon
        // bleiben
        this.xMinB = xMin;
        this.xMaxB = xMax;
        this.yMinB = yMin;
        this.yMaxB = yMax;

            //this.setBorder(BorderFactory.createLineBorder(Color.GRAY));
            this.Dock = System.Windows.Forms.DockStyle.Fill;
        this.mp = mp;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(pb_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(pb_MouseDown);
        }

        private int mx = 0;
        private int my = 0;
        private int mmove = 0;
        private bool bPaintmousePos;

    public double getxMin()
    {
        return xMin;
    }

    public void setxMin(double xMin)
    {
        this.xMin = xMin;
        this.xMinB = xMin;
    }

    public double getxMax()
    {
        return xMax;
    }

    public void setxMax(double xMax)
    {
        this.xMax = xMax;
        this.xMaxB = xMax;
    }

    public double getyMin()
    {
        return yMin;
    }

    public void setyMin(double yMin)
    {
        this.yMin = yMin;
        this.yMinB = yMin;
    }

    public double getyMax()
    {
        return yMax;
    }

    public void setyMax(double yMax)
    {
        this.yMax = yMax;
        this.yMaxB = yMax;
    }

    public bool isxRaster()
    {
        return xRaster;
    }

    public void setxRaster(bool xRaster)
    {
        this.xRaster = xRaster;
    }

    public bool isyRaster()
    {
        return yRaster;
    }

    public void setyRaster(bool yRaster)
    {
        this.yRaster = yRaster;
    }

    private void pb_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
            psp = new List<XYPoint>();
            psp.Clear();
            for (int i = 0; i < curves.Count; i++)
            { // malen der Punkte fuer jede Kurve
                Kurve curve = (Kurve)(curves[i]);
                if ((curve.getParser() != null) && (!(curve.isDatum)))
                { // wenn Parser vorhanden, dann Werte bestimmen fuer
                  // eingestellten x_Bereich (umweg ueber weitere Kurve)
                    for (int k = 0; k < curve.getWerte().Count; k++)
                    {
                        psp.Add(curve.getWerte()[k]);

                    }
                }
                else
                {
                    // bei DB - Werten direkt nur die
                    // importierten Daten darstellen
                    psp = curve.getWerte();
                    break;
                }
            }

            //g.setColor(curve.getKurvenfarbe());
            for (int j = 0; j < psp.Count; j++)
            { // Punkt bestimmen
                XYPoint xp = psp[j];
                if ((Math.Abs(xp.getIx() - e.X) < 4) && (Math.Abs(xp.getIy() - e.Y) < 4))
                {
                    CanGetPoint = false;
                    MouseDownString = xp.getstr();
                    XPointValue = xp.getX();
                    YPointValue = xp.getY();
                    CanGetPoint = true;
                    break;
                }
                else
                    MouseDownString = "";

            }

        

    }


    private void pb_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {
            if (WithShowString)
            {
                psp = new List<XYPoint>();
                psp.Clear();
                for (int i = 0; i < curves.Count; i++)
                { // malen der Punkte fuer jede Kurve
                    Kurve curve = (Kurve)(curves[i]);
                    if ((curve.getParser() != null) && (!(curve.isDatum)))
                    { // wenn Parser vorhanden, dann Werte bestimmen fuer
                      // eingestellten x_Bereich (umweg ueber weitere Kurve)
                        for (int k = 0; k < curve.getWerte().Count; k++)
                        {
                            psp.Add(curve.getWerte()[k]);

                        }
                    }
                    else
                    {
                        // bei DB - Werten direkt nur die
                        // importierten Daten darstellen
                        psp = curve.getWerte();
                        break;
                    }
                }
                
                //g.setColor(curve.getKurvenfarbe());
                for (int j = 0; j < psp.Count; j++)
                    { // Punkt bestimmen
                        XYPoint xp = psp[j];
                    if ((Math.Abs(xp.getIx() - e.X) < 3) && (Math.Abs(xp.getIy() - e.Y) < 3))
                    {
                        
                        MouseOverString = xp.getstr();
                        break;
                    }
                    else
                        MouseOverString = "";

                    }
                



                if (mmove > 1)
                {
                    mx = e.X;
                    my = e.Y;
                    bPaintmousePos = true;
                    mmove = 0;
                    this.Invalidate();
                }
                else
                {
                    mmove++;
                    bPaintmousePos = false;
                }
            }

    }



        //@Override
        //    public void paint(Graphics g0)
        protected override  void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

            //Graphics g = CreateGraphics();

            Rectangle r = this.ClientRectangle;

            //e.Graphics.FillRectangle(new SolidBrush(Color.Blue), r);
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), r);
           
            e.Graphics.DrawRectangle(Pens.Gray, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);

            Kurve curve_intern = null;
        // ausprobiert - soviel, dass für doe beschriftung genug Platz
        int nRandxu = 60;
        int nRandyu = 60;


        
            
        // weitere Hilfsgroessen festlegen

        // Diagramm wird in 10 Unterabschnitte eingeteilt
        // jeweils in Breite und Hoehe
        int nDx = (this.Width - 2 * nRandxu) / 10;
        int nRandxo = this.Width - nRandxu - 10 * nDx;
        int nWidth = this.Width - nRandxu - nRandxo;
        int nDy = (this.Height - 2 * nRandyu) / 10;
        int nRandyo = this.Height - nRandyu - 10 * nDy;
        int nHeight = this.Height - nRandyu - nRandyo;

            // super.paint(g);
            // der Rand wird gemalt


            //g.setColor(mp.getcRahmenfarbe());
            Pen pe = new Pen(mp.getcRahmenfarbe());
            Brush br = new SolidBrush(Color.Red);
            //mp.setcRahmenfarbe(Color.Red);
            e.Graphics.DrawLine(pe,nRandxu, nRandyu,
            this.Width - nRandxo, nRandyu);
            e.Graphics.DrawLine(pe,nRandxu, nRandyu, nRandxu,
            this.Height - nRandyo);
            e.Graphics.DrawLine(pe,nRandxu, this.Height - nRandyo,
            this.Width - nRandxo, this.Height - nRandyo);
            e.Graphics.DrawLine(pe, this.Width - nRandxo, nRandyu,
            this.Width - nRandxo, this.Height - nRandyo);

        if (this.yRaster)
        { // yRaster auf true, dann wird 10er Unterteilung gemalt
          // Führungslinien
            for (int i = 1; i < 10; i++)
            {
                    e.Graphics.DrawLine(pe,nRandxu, nRandyu + i * nDy,
                    this.Width - nRandxo, nRandyu + i * nDy);
            }
        }
        if (this.xRaster)
        { // xRaster auf true, dann wird 10er Unterteilung gemalt
          // Führungslinien
            for (int i = 1; i < 10; i++)
            {
                    e.Graphics.DrawLine(pe,nRandxu + i * nDx, nRandyu,
                    nRandxu + i * nDx, this.Height - nRandyo);
            }
        }

        if ((curves.Count == 1) && ((Kurve)(curves[0])).isDatum)
        { // nur wenn Datenbank x - Feld ein Datum ist und wenn nur 
          // eine Kurve naemlich die Datenbankkurve gemalt werden soll
          // Datumwerte sind eigentlich Double - Werte (sehr grosse)
          // neue Minimal und Maximalwerte bestimmen
            ((Kurve)(curves[0])).bestimmeMinMaxWerte();
            psp = ((Kurve)(curves[0])).getWerte();
            xMin = (((Kurve)(curves[0])).getxMin());
            xMax = (((Kurve)(curves[0])).getxMax());
            yMin = ((Kurve)(curves[0])).getyMin();
            yMax = ((Kurve)(curves[0])).getyMax(); ;
        }
        double diffx = xMax - xMin;
        double diffy = yMax - yMin;
        // wenn Werte (x oder y) sehr gross sind, dann werden
        // statt Dezimalwertdarstellung eine Exponentendarstellung
        // gewaehlt, dazu wird die Potenz der Differenzen zwischen
        // Minimal und Maximalwert bestimmt
        int nPotx = bestimmePotenz(diffx);
        //System.out.println( "nPotx: " + nPotx );

        double w10x = 1.0;
        int wnPotx = nPotx;
        if (wnPotx > 0)
        {
            while (wnPotx > 0)
            {
                w10x = 10 * w10x;
                wnPotx--;
            }
        }
        else if (wnPotx < 0)
        {
            while (wnPotx < 0)
            {
                w10x = w10x / 10;
                wnPotx++;
            }
        }

        int nPoty = bestimmePotenz(diffy);
        //System.out.println( "nPoty: " + nPoty );
        double w10y = 1.0;
        int wnPoty = nPoty;
        if (wnPoty > 0)
        {
            while (wnPoty > 0)
            {
                w10y = 10 * w10y;
                wnPoty--;
            }
        }
        else if (wnPoty < 0)
        {
            while (wnPoty < 0)
            {
                w10y = w10y / 10;
                wnPoty++;
            }
        }
        // alten Werte merken - beachte Unterschied zu BWerten
        double xMinAlt = xMin;
        double xMaxAlt = xMax;
        double yMinAlt = yMin;
        double yMaxAlt = yMax;
        if ((nPotx < -2) || (2 < nPotx))
        {
            xMin = Math.Round((xMin / w10x) * 100) / 100.0;
            xMax = Math.Round((xMax / w10x) * 100) / 100.0;
        }
        if ((nPoty < -2) || (2 < nPoty))
        {
            yMin = Math.Round((yMin / w10y) * 100) / 100.0;
            yMax = Math.Round((yMax / w10y) * 100) / 100.0;
        }
        drawRaster(nRandxu, nRandxo, nRandyu, nRandyo, nDx, nDy, e.Graphics);
            /*
                    if ((curves.Count == 1) && ((Kurve)(curves[0])).isDatum)
                    { // hier wieder nur wenn Datum angezeigt
                        xMin = xMinAlt;
                        xMax = xMaxAlt;
                        psp = ((Kurve)(curves[0])).getWerte();
                        double xDatumDiff = 1.0 * (xMax - xMin) / 10;

                        if ((((Kurve)(curves[0])).getDatumart() == Datumart.NurDatum) ||
                            (((Kurve)(curves[0])).getDatumart() == Datumart.DatumUndZeit))
                        { // verschiedene Darstellungen des Datums wie im MainTool festgelegt
                            for (int i = 0; i < 11; i = i + 2)
                            { // aus Platzgruenden nur 6 Datumswerte
                                e.Graphics.DrawString(new DateTime((xMin + xDatumDiff * i)).ToShortDateString,
                                    nRandxu - 30 + i * nDx, this.Height - nRandyo + 30);
                            }
                        }
                        if ((((Kurve)(curves.get(0))).getDatumart() == Datumart.DatumUndZeit))
                        {
                            for (int i = 0; i < 11; i = i + 2)
                            {
                                g.drawString(new Time(new Double(xMin + xDatumDiff * i).longValue()).toString(),
                                    nRandxu - 30 + i * nDx, this.getHeight() - nRandyo + 45);
                            }
                        }
                        if ((((Kurve)(curves.get(0))).getDatumart() == Datumart.NurZeit))
                        {
                            for (int i = 0; i < 11; i = i + 2)
                            {
                                g.drawString(new Time(new Double(xMin + xDatumDiff * i).longValue()).toString(),
                                    nRandxu - 30 + i * nDx, this.getHeight() - nRandyo + 30);
                            }
                        }
                        for (int i = 0; i < 11; i++)
                        { // bei der y-Achse normale Zahlendarstellung
                          // hier die linke Achse
                            g.drawString(NumberFormat.getInstance().
                                format(yMin + (yMax - yMin) / 10 * i),
                                nRandxu - 30, this.getHeight() - nRandyo - i * nDy);
                        }
                        for (int i = 0; i < 11; i++)
                        { // Beide Achsen (hier die rechte)
                            g.drawString(NumberFormat.getInstance().
                                format(yMin + (yMax - yMin) / 10 * i),
                                this.getWidth() - nRandxo + 20, this.getHeight() - nRandxo - i * nDy);
                        }

                    }
                    else

                */

            // hier die normale Beschriftung (kein Datum, ..
            drawBezeichnung(xMin, xMax, yMin, yMax,
                nRandxu, nRandxo, nRandyu, nRandyo, nDx, nDy, e.Graphics);

        if (!(String.IsNullOrEmpty(mp.getxAchse().Trim()) && String.IsNullOrEmpty(mp.getyAchse().Trim())))
        { // Achsenbeschriftung (z.B. Einheiten)
            e.Graphics.DrawString(mp.getxAchse(),this.Font,br,
                nRandxu + 10 * nDx - 30, this.Height - nRandyo + 45);
                e.Graphics.DrawString(mp.getyAchse(), this.Font, br,
                nRandxu - 55, this.Height - nRandxo - 10 * nDy - 40);
        }
        else if (curves.Count == 1)
        { // Achsenbeschriftung (z.B. Einheiten)
            Kurve curve = (Kurve)(curves[0]);
                e.Graphics.DrawString(curve.getXEinheit(), this.Font, br,
                nRandxu + 10 * nDx - 30, this.Height - nRandyo + 45);
                e.Graphics.DrawString(curve.getYEinheit(), this.Font, br,
                nRandxu - 55, this.Height - nRandxo - 10 * nDy - 40);
        }

        if ((nPoty > 2) || (nPoty < -2))
        { // nur bei Potenzialdarstellung
                e.Graphics.DrawString("* 10", this.Font, br,
                nRandxu - 50, nRandyu + 37);
                e.Graphics.DrawString(nPoty.ToString(),this.Font, br,
                nRandxu - 30, nRandyu + 27);
        }

        if (!((curves.Count == 1) && ((Kurve)(curves[0])).isDatum))
        {
            // nur bei Potenzialdarstellung (und kein Datum)
            if ((nPotx > 2) || (nPotx < -2))
            {
                    e.Graphics.DrawString("* 10", this.Font, br,
                    nRandxu + 10 * nDx + 20, this.Height - nRandyo + 45);
                    e.Graphics.DrawString(nPotx.ToString(), this.Font, br,
                    nRandxu + 10 * nDx + 42, this.Height - nRandyo + 35);
            }
        }
        
        xMin = xMinAlt;
        xMax = xMaxAlt;
        yMin = yMinAlt;
        yMax = yMaxAlt;
        
        for (int i = 0; i < curves.Count; i++)
        { // malen der Punkte fuer jede Kurve
            Kurve curve = (Kurve)(curves[i]);
            if ((curve.getParser() != null) && (!(curve.isDatum)))
            { // wenn Parser vorhanden, dann Werte bestimmen fuer
              // eingestellten x_Bereich (umweg ueber weitere Kurve)
                Parser p = curve.getParser();
                curve_intern = p.bestimmeKurve(xMin, xMax, curve.getSteps());
                psp = curve_intern.getWerte();
                curve.setWerte(psp);
            }
            else
                // bei DB - Werten direkt nur die
                // importierten Daten darstellen
                psp = curve.getWerte();

                //g.setColor(curve.getKurvenfarbe());
            Pen penKurvenfarbe = new Pen(curve.getKurvenfarbe());
            Punktform ka = curve.getKurvenart();
            for (int j = 0; j < psp.Count; j++)
            { // Punkt bestimmen
                XYPoint xp = psp[j];
                    //int nj = 0;
                    //if (j == 200)
                      //  nj++;
                // x und y - Wert bestimmen
                int xx = (int)((nWidth) *
                    (xp.getX() - xMin) / (xMax - xMin));
                int yy = (int)((nHeight) - (nHeight) *
                    (xp.getY() - yMin) / (yMax - yMin));
                // Falls ausserhalb des Randes, dann nicht plotten
                if ((nRandxu + xx) > (this.Width - nRandxo))
                    continue;
                if ((nRandxu + xx) < (nRandxu))
                    continue;
                if ((nRandyu + yy) > (this.Height - nRandyo))
                    continue;
                if ((nRandyu + yy) < (nRandyu))
                    continue;
                xp.setIx(nRandxu + xx);
                xp.setIy(nRandyu + yy);
                    // alle Werte werden angezeigt
                  male(nRandxu + xx, nRandyu + yy, e.Graphics, ka, penKurvenfarbe);
            }
                curve.setWerte(psp);


        }
            // Nur die besonderen Werte werden angezeigt
            if (ShowSpecialValues)
            {

                for (int i = 0; i < curves.Count; i++)
                { // malen der Punkte fuer jede Kurve
                    Kurve curve = (Kurve)(curves[i]);
                    if ((curve.getParser() != null) && (!(curve.isDatum)))
                    { // wenn Parser vorhanden, dann Werte bestimmen fuer
                      // eingestellten x_Bereich (umweg ueber weitere Kurve)
                        Parser p = curve.getParser();
                        curve_intern = p.bestimmeKurve(xMin, xMax, curve.getSteps());
                        psp = curve_intern.getWerte();
                        curve.setWerte(psp);
                    }
                    else
                        // bei DB - Werten direkt nur die
                        // importierten Daten darstellen
                        psp = curve.getWerte();

                    //g.setColor(curve.getKurvenfarbe());
                    Pen penKurvenfarbe = new Pen(curve.getKurvenfarbe());
                    Punktform ka = curve.getKurvenart();
                    for (int j = 0; j < psp.Count; j++)
                    { // Punkt bestimmen
                        XYPoint xp = psp[j];
                        //int nj = 0;
                        //if (j == 200)
                        //  nj++;
                        // x und y - Wert bestimmen
                        int xx = (int)((nWidth) *
                            (xp.getX() - xMin) / (xMax - xMin));
                        int yy = (int)((nHeight) - (nHeight) *
                            (xp.getY() - yMin) / (yMax - yMin));
                        // Falls ausserhalb des Randes, dann nicht plotten
                        if ((nRandxu + xx) > (this.Width - nRandxo))
                            continue;
                        if ((nRandxu + xx) < (nRandxu))
                            continue;
                        if ((nRandyu + yy) > (this.Height - nRandyo))
                            continue;
                        if ((nRandyu + yy) < (nRandyu))
                            continue;
                        xp.setIx(nRandxu + xx);
                        xp.setIy(nRandyu + yy);
                        if (xp.getstr().Contains(ShowSpecialValuesString))
                        {
                            e.Graphics.FillRectangle(new SolidBrush(ShowSpecialValuesColor),
                                nRandxu + xx - 2, nRandyu + yy - 2, 5, 5);
                        }
                    }
                    curve.setWerte(psp);
                }
            }


            //Graphics2D g = (Graphics2D)g0;
            if (WithShowString)
            {
                if (bPaintmousePos)
                //            if (false)
                {
                    Font fn = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold);
                    e.Graphics.DrawString(MouseOverString, fn, 
                        new SolidBrush(this.HintColor), mx+12, my);
                    bPaintmousePos = false;
                }
            }

            



        xMin = xMinB;
        xMax = xMaxB;
        yMin = yMinB;
        yMax = yMaxB;
    }

    private void drawBezeichnung(double xMin2, double xMax2,
        double yMin2, double yMax2, int nRandxu, int nRandxo,
        int nRandyu, int nRandyo, int nDx, int nDy, Graphics g)
    { // nur zwei Dezimale anzeigen
        //NumberFormat nF = NumberFormat.getInstance();
        //nF.setRoundingMode(RoundingMode.HALF_DOWN);
        //nF.setMinimumFractionDigits(2);
        //nF.setMaximumFractionDigits(2);
        for (int i = 0; i < 11; i++)
        {
            g.DrawString((xMin2 + (xMax2 - xMin2) / 10 * i).ToString("0.00"),this.Font, 
                 new SolidBrush(mp.getcRahmenfarbe()),
                nRandxu + i * nDx - 5, this.Height - nRandyo + 20);
        }
        for (int i = 0; i < 11; i++)
        {
            g.DrawString((xMin2 + (xMax2 - xMin2) / 10 * i).ToString("0.00"), this.Font,
                 new SolidBrush(mp.getcRahmenfarbe()),
                nRandxu + i * nDx - 5, nRandyu - 20);
        }
        for (int i = 0; i < 11; i++)
        {
            g.DrawString((yMin2 + (yMax2 - yMin2) / 10 * i).ToString("0.00"), this.Font,
                 new SolidBrush(mp.getcRahmenfarbe()),
                nRandxu - 40, this.Height - nRandxo - i * nDy);
        }
        for (int i = 0; i < 11; i++)
        {
            g.DrawString((yMin2 + (yMax2 - yMin2) / 10 * i).ToString("0.00"), this.Font,
                 new SolidBrush(mp.getcRahmenfarbe()),
                this.Width - nRandxo + 20, this.Height - nRandxo - i * nDy);
        }
    }

    private void drawRaster(int nRandxu, int nRandxo,
        int nRandyu, int nRandyo,
        int nDx, int nDy, Graphics g)
    {
        // hier ist mit Raster die kleine Unterlinien auf der x - und
        // y - Achse gemeint
        for (int i = 0; i < 11; i++)
        {
            g.DrawLine(new Pen(mp.getcRahmenfarbe()),nRandxu + i * nDx, nRandyu - 5,
                nRandxu + i * nDx, nRandyu);
            g.DrawLine(new Pen(mp.getcRahmenfarbe()), nRandxu + i * nDx, this.Height - nRandyo + 5,
                nRandxu + i * nDx, this.Height - nRandyo);
            g.DrawLine(new Pen(mp.getcRahmenfarbe()), nRandxu - 5, nRandyu + i * nDy,
                nRandxu, nRandyu + i * nDy);
            g.DrawLine(new Pen(mp.getcRahmenfarbe()), this.Width - nRandxo + 5, nRandyu + i * nDy,
                this.Width - nRandxo, nRandyu + i * nDy);
        }
        int dxh = nDx / 2;
        int dyh = nDy / 2;

        for (int i = 0; i < 10; i++)
        {
            g.DrawLine(new Pen(mp.getcRahmenfarbe()), nRandxu + i * nDx + dxh, nRandyu - 2,
                nRandxu + i * nDx + dxh, nRandyu);
            g.DrawLine(new Pen(mp.getcRahmenfarbe()), nRandxu + i * nDx + dxh,
                this.Height - nRandyo + 2,
                nRandxu + i * nDx + dxh, this.Height - nRandyo);
            g.DrawLine(new Pen(mp.getcRahmenfarbe()), nRandxu - 2, nRandyu + i * nDy + dyh,
                nRandxu, nRandyu + i * nDy + dyh);
            g.DrawLine(new Pen(mp.getcRahmenfarbe()), this.Width - nRandxo + 2, nRandyu + i * nDy + dyh,
                this.Width - nRandxo, nRandyu + i * nDy + dyh);
        }

        //g.setColor(Color.RED);

        // wenn der 0 - Punkt innerhalb der Achse dann
        // Linie durchzeichnen
        if ((xMin < 0.0) && (0.0 < xMax))
        {
            int xx = (int)((this.Width - nRandxu - nRandxo) *
                (0.0 - xMin) / (xMax - xMin));
            g.DrawLine(new Pen(mp.getcRahmenfarbe()), nRandxu + xx, nRandyu,
                nRandxu + xx, this.Height - nRandyo);
        }

        if ((yMin < 0.0) && (0.0 < yMax))
        {
            int yy = (int)((this.Height - nRandyu - nRandyo) -
                (this.Height - nRandyu - nRandyo) *
                (0 - yMin) / (yMax - yMin));
            g.DrawLine(new Pen(mp.getcRahmenfarbe()), nRandxu, nRandyu + yy,
                this.Width - nRandxo, nRandyu + yy);
        }

    }

    private int bestimmePotenz(double diff)
    {
        int result = 0;
        if (diff >= 1)
        {
            while (!((1 <= diff) && (diff <= 10)))
            {
                diff = diff / 10.0;
                result++;
            }
        }
        else
        {
            while (!((1 <= diff) && (diff <= 10)))
            {
                diff = diff * 10.0;
                result--;
            }
        }
        return result;
    }

    private void male(int x, int y, Graphics g, Punktform ka, Pen pKurve)
    {
    

        switch (ka)
        {
            case Punktform.PUNKT:
                g.FillRectangle(new SolidBrush(pKurve.Color), x, y, 1, 1);
                break;
            case Punktform.DICKER_PUNKT:
                g.DrawLine(pKurve, x - 1, y - 1, x + 1, y - 1);
                g.DrawLine(pKurve, x - 1, y + 1, x + 1, y + 1);
                g.DrawLine(pKurve, x - 1, y, x + 1, y);
                g.DrawLine(pKurve, x - 2, y - 2, x + 2, y + 2);
                g.DrawLine(pKurve, x - 2, y + 2, x + 2, y - 2);
                break;
            case Punktform.KREUZ:
                g.DrawLine(pKurve, x - 1, y - 1, x + 1, y + 1);
                g.DrawLine(pKurve, x - 1, y + 1, x + 1, y - 1);
                break;
            case Punktform.PLUSZEICHEN:
                g.DrawLine(pKurve, x - 1, y, x + 1, y);
                g.DrawLine(pKurve, x, y + 1, x, y - 1);
                break;
            case Punktform.RECHTECK_HOHL:
                g.DrawLine(pKurve, x - 1, y - 1, x + 1, y - 1);
                g.DrawLine(pKurve, x - 1, y + 1, x + 1, y + 1);
                g.DrawLine(pKurve, x - 1, y, x - 1, y);
                g.DrawLine(pKurve, x + 1, y, x + 1, y);
                break;
            case Punktform.RECHTECK_GEFUELLT:
                g.DrawLine(pKurve, x - 1, y - 1, x + 1, y - 1);
                g.DrawLine(pKurve, x - 1, y + 1, x + 1, y + 1);
                g.DrawLine(pKurve, x - 1, y, x + 1, y);
                break;

        }
    }

}
}
