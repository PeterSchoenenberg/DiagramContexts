using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit.parser.parse
{
    public class ParsPart
    {
        private int typ;
        private double value;
        private int token;
        private String text;

        public ParsPart()
        {
            typ = 0;
            value = 0.0;
            token = 0;
            text = "";
        }

        public int getTyp()
        {
            return typ;
        }

        public void setTyp(int typ)
        {
            this.typ = typ;
        }

        public double getValue()
        {
            return value;
        }

        public void setValue(double value)
        {
            this.value = value;
        }

        public int getToken()
        {
            return token;
        }

        public void setToken(int token)
        {
            this.token = token;
        }

        public String getText()
        {
            return text;
        }

        public void setText(String text)
        {
            this.text = text;
        }

    }
}
