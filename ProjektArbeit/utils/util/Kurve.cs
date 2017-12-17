using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektArbeit.parser.parse;

namespace ProjektArbeit.utils.util
{
    public class Kurve
    {

        private double xMin, xMax;
        private double yMin, yMax;
        private List<XYPoint> werte = new List<XYPoint>();
        private Punktform kurvenart;
        private Color kurvenfarbe;
        private Parser parser;
        private String fktText;

        private String xEinheit;
        private String yEinheit;

        private XYPoint xy;

        private int steps;
        public bool isDatum = false;
        private Datumart datumart;

        public Kurve()
        {
            xMin = 0.0;
            xMax = 0.0;
            yMin = 0.0;
            yMax = 0.0;
        }

        public Kurve(List<XYPoint> werte)
        {
            //super();
            setWerte(werte);
        }

        public void setWerte(List<XYPoint> werte)
        {
            if (werte == null)
            {
                this.werte = null;
                return;
            }
            this.werte.Clear();
            for (int i = 0; i < werte.Count; i++)
            {
                xy = new XYPoint(werte[i].getX(), werte[i].getY(), werte[i].getstr(), werte[i].getIx(), werte[i].getIy());
                this.werte.Add(xy);
            }
            bestimmeMinMaxWerte();
        }

        public List<XYPoint> getWerte()
        {
            List<XYPoint> ret = new List<XYPoint>();
            if (this.werte == null)
            {
                this.werte = ret;
                return ret;
            }
            for (int i = 0; i < this.werte.Count; i++)
            {
                xy = new XYPoint(werte[i].getX(), werte[i].getY(), werte[i].getstr(), werte[i].getIx(), werte[i].getIy());
                ret.Add(xy);
            }
            return ret;
        }

        public void bestimmeMinMaxWerte()
        {
            if (this.werte.Count == 0)
                return;
            xy = this.werte[0];
            xMin = xy.getX();
            xMax = xy.getX();
            yMin = xy.getY();
            yMax = xy.getY();
            for (int i = 1; i < this.werte.Count; i++)
            {
                xy = this.werte[i];
                if (xMin > xy.getX())
                    xMin = xy.getX();
                if (xMax < xy.getX())
                    xMax = xy.getX();
                if (yMin > xy.getY())
                    yMin = xy.getY();
                if (yMax < xy.getY())
                    yMax = xy.getY();
            }

        }

        public double getxMin()
        {
            return xMin;
        }

        public double getxMax()
        {
            return xMax;
        }

        public double getyMin()
        {
            return yMin;
        }

        public double getyMax()
        {
            return yMax;
        }

        public Punktform getKurvenart()
        {
            return kurvenart;
        }

        public void setKurvenart(Punktform kurvenart)
        {
            this.kurvenart = kurvenart;
        }

        public Color getKurvenfarbe()
        {
            return kurvenfarbe;
        }

        public void setKurvenfarbe(Color kurvenfarbe)
        {
            this.kurvenfarbe = kurvenfarbe;
        }

        public Parser getParser()
        {
            return parser;
        }

        public void setParser(Parser parser)
        {
            this.parser = parser;
        }

        public String getXEinheit()
        {
            return xEinheit;
        }

        public void setXEinheit(String xEinheit)
        {
            this.xEinheit = xEinheit;
        }

        public String getYEinheit()
        {
            return yEinheit;
        }

        public void setYEinheit(String yEinheit)
        {
            this.yEinheit = yEinheit;
        }

        public String getFktText()
        {
            return fktText;
        }

        public void setFktText(String fktText)
        {
            this.fktText = fktText;
        }

        public int getSteps()
        {
            return steps;
        }

        public void setSteps(int steps)
        {
            this.steps = steps;
        }

       // public bool isDatum()
        //{
          //  return isDatum;
        //}

        public void setisDatum(bool isDatum)
        {
            this.isDatum = isDatum;
        }

        public Datumart getDatumart()
        {
            return datumart;
        }

        public void setDatumart(Datumart datumart)
        {
            this.datumart = datumart;
        }

    }
}
