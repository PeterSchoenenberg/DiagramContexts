using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit.parser.parse
{
    /**
     * nKlammerungstiefe nKT
     * 
     * @author Alfa
     *
     */

    public class NKT
    {

        private int nkt;

        public NKT(int nkt)
        {
            this.setNkt(nkt);
        }

        public int getNkt()
        {
            return nkt;
        }

        public void setNkt(int nkt)
        {
            this.nkt = nkt;
        }

    }
}
