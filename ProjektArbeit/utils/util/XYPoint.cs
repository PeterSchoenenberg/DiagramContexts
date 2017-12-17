using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit.utils.util
{
    public class XYPoint
    {
        private double x;
        private double y;
        private string str;
        private int ix;
        private int iy;

        public XYPoint()
        {
            setX(0.0);
            setY(0.0);
            setstr("");
            this.setIx(0);
            this.setIy(0);

        }

        public XYPoint(double x, double y)
        {
            this.setX(x);
            this.setY(y);
            this.setstr("");
            this.setIx(0);
            this.setIy(0);
        }

        public XYPoint(double x, double y, string str)
        {
            this.setX(x);
            this.setY(y);
            this.setstr(str);
            this.setIx(0);
            this.setIy(0);
        }
        public XYPoint(double x, double y, string str,int ix, int iy)
        {
            this.setX(x);
            this.setY(y);
            this.setstr(str);
            this.setIx(ix);
            this.setIy(iy);
        }

        public double getX()
        {
            return x;
        }

        public void setX(double x)
        {
            this.x = x;
        }

        public double getY()
        {
            return y;
        }

        public void setY(double y)
        {
            this.y = y;
        }
        public string getstr()
        {
            return str;
        }

        public void setstr(string str)
        {
            this.str = str;
        }

        public int getIx()
        {
            int ret = ix;
            return ret;
        }

        public int getIy()
        {
            int ret = iy;
            return ret;
        }
        public void setIx(int nx)
        {
            this.ix = nx;
        }
        public void setIy(int ny)
        {
            this.iy = ny;
        }


    }
}
