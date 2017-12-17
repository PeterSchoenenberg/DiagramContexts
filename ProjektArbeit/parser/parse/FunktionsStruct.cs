using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit.parser.parse
{
    public class FunktionsStruct
    {
        private Object Ptr;
        private String Text;

        public FunktionsStruct()
        {
            Ptr = null;
            Text = "";
        }

        public Object getPtr()
        {
            return Ptr;
        }

        public void setPtr(Object ptr)
        {
            Ptr = ptr;
        }

        public String getText()
        {
            return Text;
        }

        public void setText(String text)
        {
            Text = text;
        }

    }
}
