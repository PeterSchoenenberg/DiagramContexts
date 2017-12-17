using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit.anzeige.panel
{
    public class DiagParam
    {
        String xAchse;
        String yAchse;
        Color cRahmenfarbe;

        public Color getcRahmenfarbe()
        {
            return cRahmenfarbe;
        }

        public void setcRahmenfarbe(Color cRahmenfarbe)
        {
            this.cRahmenfarbe = cRahmenfarbe;
        }

        public DiagParam(String xAchse, String yAchse)
        {
            this.xAchse = xAchse;
            this.yAchse = yAchse;

        }

        public String getxAchse()
        {
            return xAchse;
        }

        public void setxAchse(String xAchse)
        {
            this.xAchse = xAchse;
        }

        public String getyAchse()
        {
            return yAchse;
        }

        public void setyAchse(String yAchse)
        {
            this.yAchse = yAchse;
        }

    }
}
