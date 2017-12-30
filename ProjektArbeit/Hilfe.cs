using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektArbeit
{
    public partial class Hilfe : Form
    {
        public Hilfe()
        {
            InitializeComponent();
        }

        private void Hilfe_Load(object sender, EventArgs e)
        {
            lblHilfe.Text =
                    "1.) Der Buchstabe 'x' ist die allgemeine Funktionsvariable.\n\n"
            + "2.) Funktionen sind immer in der Form fkt(x).\n\n"
            + "3.) Minimumwerte müssen immer kleiner als Maximumwerte sein. "
            + "Ein Verstoß gegen diese Regel führt zur Rücksetzung "
            + "auf die alten Werte!\n\n"
            + "4.) Die Funktionsausdrücke können beliebig verschachtelt sein.\n\n"
            + "5.) Man sollte binäre Verknüpfungen immer in Klammern setzen. "
            + " Lieber die Ausdrücke in Klammern setzen.\n\n"
            + "6.) Folgende Funktionen sind bis jetzt eingebaut:\n"
            + " +, -, /, *, sin(), cos(), tan(), e(), ln(), nk(,) (n über k), "
            + "** (Potenzieren), asin(), acos(), atan() \n\n"
            + "7.) Konkrete Zahlen haben einen Punkt "
            + "(z.B. 3.14) als Dezimaltrenner!\n\n"
            + "8.) Zuerst gilt die direkte Achsenbeschriftung. Wenn diese "
            + "leer ist, so gilt die Achsenbeschriftung in den "
            + "Funktionsdefinitionen. Allerdings wird die Beschriftung aus "
            + "der Funktionsdefinition  "
            + "nur dann angezeigt, wenn genau nur diese Funktion aktiv ist!\n\n";
            
        }

    }
}

