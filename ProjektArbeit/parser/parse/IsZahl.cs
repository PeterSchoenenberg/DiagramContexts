using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    /**
    * // ob eine eingebene Zeichenfolge eine Zahl ist
    */
    public class IsZahl
    {
        private bool isZahl;

        public IsZahl(bool isZahl)
        {
            this.setIsZahl(isZahl);
        }

        public bool getIsZahl()
        {
            return isZahl;
        }

        public void setIsZahl(bool isZahl)
        {
            this.isZahl = isZahl;
        }

    }
}
