using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit.parser.parse
{
    public class Params
    {
        private double v1;
        private double v2;
        private double result;

        public Params()
        {
            v1 = 0.0;
            v2 = 0.0;
            result = 0.0;
        }

        public double getV1()
        {
            return v1;
        }

        public void setV1(double v1)
        {
            this.v1 = v1;
        }

        public double getV2()
        {
            return v2;
        }

        public void setV2(double v2)
        {
            this.v2 = v2;
        }

        public double getResult()
        {
            return result;
        }

        public void setResult(double result)
        {
            this.result = result;
        }

    }
}
