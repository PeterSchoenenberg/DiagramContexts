using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektArbeit.utils.util;

namespace ProjektArbeit.parser.parse
{
    public class Parser
    {
        private String oldParseText;
        private List<ParsPart> liste = new List<ParsPart>();
        public List<String> parseText = new List<String>();

        private List<XYPoint> werte = new List<XYPoint>();

        public Kurve fkt;

        public Parser()
        {

            oldParseText = "";

        }

        //---------------------------------------------------------------------------
        /**
         *
         * @param xMin
         *          : Unterer Grenzwert
         * @param xMax
         *          : Oberer Grenzwert
         * @param steps
         *          : Anzahl der Zwischenwerte - 2
         * @return
         *         Bestimmt die Werte einer Funktion
         */
        public Kurve bestimmeKurve(double xMin, double xMax, int steps)
        {
            Kurve ret = null;
            double xStep = 0.0;
            werte.Clear();
            // Hier wird ein Array uebergeben,
            // weil sich in Java uebergebene
            // Werte nicht aendern, nur Objektwerte (brauche nur den Ersten wert
            Double[] ergebnis = new Double[1];
            String[] errorText = new String[1];

            xStep = ((xMax - xMin) / steps);
            for (int i = 0; i <= steps; i++)
            {
                double x = xMin + xStep * i;
                try
                {
                    errorText[0] = "";
                    int error = doubleFktValue(x, ergebnis, errorText);
                    if ((error == 0) && (String.IsNullOrEmpty(errorText[0])))
                    {
                        //        XYPoint xy = new XYPoint( Math.round( x * 1000.0 ) / 1000.0, Math.round( ergebnis[0] * 1000.0 ) / 1000.0 );
                        XYPoint xy = new XYPoint(x, ergebnis[0]);
                        xy.setstr("("+xy.getX().ToString("0.##",CultureInfo.InvariantCulture)
                                  +","+xy.getY().ToString("0.##", CultureInfo.InvariantCulture) + ")");
                        werte.Add(xy);
                    }
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }
            // neue Kurve aus den Werte erzeugen
            ret = new Kurve(werte);
            return ret;
        }

        //---------------------------------------------------------------------------
        /**
         * Dies ist die eigentliche Parser - Funktion. Hier wird Funktion analysiert
         * und geparst und in eine Auswertbare Form übertragen (Item in Liste)
         * hier werden keine Funktionswerte bestimmt, nur der
         * Funktionstext geparst
         * Die Vorgehnsweise ist rekursivin pr wird or an
         * verschiedenen Stellen neu aufgerufen
         */
        private int pr(String q)
        {
            // Vorbereitungen
            int i, error, anzahl;
            String ca, cb, c1 = "", c2 = "", s;
            Double param;
            // NKT bedeutet nKlammertiefe
            NKT kt = new NKT(0);
            IsZahl isz = new IsZahl(false);

            q = q.Trim();

            // wenn leer, dann gibts nichts zu parsen (Fehler)
            if (String.IsNullOrEmpty(q))
                 return 21;

            
            // Kann ein x sein
            if (q.ToUpper() == "X")
                return addItem(0, 0.0, -1, "x");
            // kann ein pi sein
            if (q.ToUpper() =="PI")
            {

                try
                {
                    param = Math.PI;
                }
                catch (Exception ex)
                {
                    return 1;
                }
                return addItem(3, param, -1, "Pi");
            }
            // kann die Eulerzahl sein
            if (q.ToUpper() == "E")
            {

                try
                {
                    param = Math.E;
                }
                catch (Exception ex)
                {
                    return 1;
                }
                return addItem(3, param, -1, "e");
            }

            // Leerzeichen eleminieren
            s = "";
            for (i = 0; i < q.Length; i++)
            {
                if (q[i] != ' ')
                    s = s + q[i];
            }
            q = s;

            // zuviele Vorzeichen reduzieren auf das
            // eigentliche Vorzeichen
            while ((q.IndexOf("++") > 0) || (q.IndexOf("+-") > 0) ||
                (q.IndexOf("-+") > 0) || (q.IndexOf("--") > 0))
            {
                if (q.IndexOf("++") > 0)
                    q = q.Substring(0, q.IndexOf("++") + 1)
                    + q.Substring(q.IndexOf("++") + 2);
                if (q.IndexOf("-+") > 0)
                    q = q.Substring(0, q.IndexOf("-+") + 1)
                    + q.Substring(q.IndexOf("-+") + 2);
                if (q.IndexOf("+-") > 0)
                    q = q.Substring(0, q.IndexOf("+-"))
                    + q.Substring(q.IndexOf("+-") + 1);
                if (q.IndexOf("--") > 0)
                    q = q.Substring(0, q.IndexOf("--"))
                    + "+" + q.Substring(q.IndexOf("--") + 2);
            }

            // Pluszeichen am Anfang hat keine Bedeutung
            if (q[0] == '+')
                return pr(q.Substring(1));

            // Minuszeichen - den positiven teil analysieren und
            // zum Schluss mal (-1.0) nehmen
            if (q[0] == '-')
            {
                q = q.Substring(1);

                q = pMinusFlip(q);

                addItem(1, 0.0, -1, "(");
                // Rekursives Weitergehen nach Innen
                error = pr(q);
                if (error != 0)
                    return error;
                addItem(2, 0.0, -1, ")");
                addItem(4, 0.0, 9, "*(-1.0)");
                return 0;
            }

            // Mal und geteilt am Anfang ist Boedsinn - Fehler
            // '**' auch enthalten
            if ((q[0] == '*') ||
                (q[0] == '/'))
                // kein mathematischer Ausdruck
                return 3;

            // Feststellen, ob es einfach nur ein Zahlenwert ist,
            // kein mathematischer Ausdruck (Term)
            error = pIsZahl(q, isz);
            if (error != 0)
                return error;
            else
            {
                if (isz.getIsZahl())
                {
                    // Punkt muss durch Komma ersetzt werden
                    // q = changePointToKomma( q );

                    try
                    {
                        // versuchen, aus dem Zahlenwert ein Double zu machen
                        
                        param = Double.Parse(q,  CultureInfo.InvariantCulture);
                    }
                    catch (Exception ex)
                    {
                        return 1;
                    }
                    addItem(3, param, -1, q);
                    return 0;
                }
            }

            // inn kt werden die Anzahl der offenen Klammer gezaehlt
            for (i = 0; i < q.Length; i++)
            {

                if (changeN(q[i], kt))
                {
                    continue;
                }
                // nur wenn kt gleich 0 ist, dann laesst sich Term
                // weiter analysieren in binäre oder mono - Operationen
                // erst + - Zeichen (Punktrechnugn vor Strichrechnung)
                // von Aussen nach Innen !!
                if ((kt.getNkt() == 0) && (q[i] == '+')
                    && (q[i - 1] != '*')
                    && (q[i - 1] != '/'))
                {
                    if (i == 0)
                        return 3;
                    ca = q.Substring(0, i);
                    cb = q.Substring(i + 1);
                    if (String.IsNullOrEmpty(cb.Trim()))
                        // kein mathematischer Ausdruck
                        return 3;
                    addItem(1, 0.0, -1, "(");
                    // Rekursives Weitergehen nach Innen
                    error = pr(ca);
                    if (error != 0)
                        return error;
                    // Rekursives Weitergehen nach Innen
                    error = pr(cb);
                    if (error != 0)
                        return error;
                    addItem(2, 0.0, -1, ")");
                    addItem(4, 0.0, 0, "+");
                    return 0;
                }
            }
            if (kt.getNkt() != 0)
                return 2;

            for (i = 0; i < q.Length; i++)
            {

                if (changeN(q[i], kt))
                {

                    continue;
                }
                // - Zeichen wwie + Zeichen
                if ((kt.getNkt() == 0) && (q[i] == '-')
                    && (q[i - 1] != '*')
                    && (q[i - 1] != '/'))
                {
                    if (i == 0)
                        return 3;
                    ca = q.Substring(0, i);
                    cb = q.Substring(i + 1);
                    if (String.IsNullOrEmpty(cb.Trim()))
                        // kein mathematischer Ausdruck
                        return 3;
                    cb = pMinusFlip(cb);
                    addItem(1, 0.0, -1, "(");
                    error = pr(ca);
                    if (error != 0)
                        return error;
                    error = pr(cb);
                    if (error != 0)
                        return error;
                    addItem(2, 0.0, -1, ")");
                    addItem(4, 0.0, 1, "-");
                    return 0;
                }
            }
            if (kt.getNkt() != 0)
                return 2;

            for (i = 0; i < q.Length; i++)
            {

                if (changeN(q[i], kt))
                {
                    continue;
                }
                // * - Zeichen wie + Zeichen (kein Exponentieren!!)
                if ((kt.getNkt() == 0) && (q[i] == '*')
                    && ((q.Substring(i,  2)) != "**")
                    && ((q.Substring(i - 1, 2)) != "**"))
                {
                    if (i == 0)
                        return 3;
                    ca = q.Substring(0, i);
                    cb = q.Substring(i + 1);
                    if (String.IsNullOrEmpty(cb.Trim()))
                        // kein mathematischer Ausdruck
                        return 3;
                    addItem(1, 0.0, -1, "(");
                    error = pr(ca);
                    if (error != 0)
                        return error;
                    error = pr(cb);
                    if (error != 0)
                        return error;
                    addItem(2, 0.0, -1, ")");
                    addItem(4, 0.0, 2, "*");
                    return 0;
                }
            }
            if (kt.getNkt() != 0)
                return 2;

            for (i = 0; i < q.Length; i++)
            {

                if (changeN(q[i], kt))
                {
                    continue;
                }
                // 'geteilt' Zeichen wie + Zeichen
                if ((kt.getNkt() == 0) && (q[i] == '/'))
                {
                    if (i == 0)
                        return 3;
                    ca = q.Substring(0, i);
                    cb = q.Substring(i + 1);
                    if (String.IsNullOrEmpty(cb.Trim()))
                        // kein mathematischer Ausdruck
                        return 3;

                    cb = pDivFlip(cb);
                    addItem(1, 0.0, -1, "(");
                    error = pr(ca);
                    if (error != 0)
                        return error;
                    error = pr(cb);
                    if (error != 0)
                        return error;
                    addItem(2, 0.0, -1, ")");
                    addItem(4, 0.0, 3, "/");
                    return 0;
                }
            }
            if (kt.getNkt() != 0)
                return 2;

            for (i = 0; i < q.Length; i++)
            {

                if (changeN(q[i], kt))
                {
                    continue;
                }
                // Exponentieren wwie + Zeichen
                if ((kt.getNkt() == 0)
                    && (q.Substring(i,2) == "**"))
                {
                    if (i == 0)
                        return 3;
                    ca = q.Substring(0, i);
                    cb = q.Substring(i + 2);
                    if (String.IsNullOrEmpty(cb.Trim()))
                        // kein mathematischer Ausdruck
                        return 3;

                    addItem(1, 0.0, -1, "(");
                    error = pr(ca);
                    if (error != 0)
                        return error;
                    error = pr(cb);
                    if (error != 0)
                        return error;
                    addItem(2, 0.0, -1, ")");
                    addItem(4, 0.0, 10, "**");
                    return 0;
                }
            } // for ( i = 1; i<= q.Length(); i++)

            // kann nur eingeklammerter Bereich sein
            if ((q[0] == '(')
                && (q[q.Length - 1] == ')'))
            {

                ca = q.Substring(1, q.Length - 2);
                if (String.IsNullOrEmpty(ca.Trim()))
                    return 6;
                error = pr(ca);
                if (error != 0)
                    return error;
                return 0;
            }

            // ab hier kann sich nur noch um Funktion handeln
            if (kt.getNkt() != 0)
                return 2;

            if ((q[q.Length - 1] != ')') ||
                (q.IndexOf('(') < 0))
                return 8;

            ca = q.Substring(q.IndexOf('(') + 1);
            ca = ca.Substring(0, ca.Length - 1);
            if (String.IsNullOrEmpty(ca.Trim()))
                return 6;
            addItem(1, 0.0, -1, "(");
            cb = q.Substring(0, q.IndexOf('('));
            if (String.IsNullOrEmpty(cb.Trim()))
                return 5;
            anzahl = anzahlParameter(ca);
            if (anzahl > 1)
                return 9;
            if (anzahlParameter(ca) == 1)
            { // 2parametrige Funktion
                for (i = 0; i < ca.Length; i++)
                {

                    if (changeN(ca[i], kt))
                    {
                        continue;
                    }
                    if ((kt.getNkt() == 0) && (ca[i] == ','))
                    {
                        c1 = ca.Substring(0, i);
                        c2 = ca.Substring(i + 1);
                        if ( (String.IsNullOrEmpty(c1.Trim())) ||  (String.IsNullOrEmpty(c2.Trim())))
                            // kein mathematischer Ausdruck
                            return 4;
                        break;
                    }
                } // for ( i = 1; i<= q.Length(); i++)
                if (kt.getNkt() != 0)
                    return 2;
                if (cb.ToUpper() == "NK")
                { // jedesmal extra, da auch verschachtelte Funtionen möglich sind!
                    error = pr(c1);
                    if (error != 0)
                        return error;
                    error = pr(c2);
                    if (error != 0)
                        return error;
                    addItem(2, 0.0, -1, ")");
                    addItem(4, 0.0, 11, "nk");
                    return 0;
                }

                // Error - unbekannte einparametrige Funktion
                return 10;

            } // if (ca.Pos(",")>0)

            error = pr(ca);
            if (error != 0)
                return error;
            addItem(2, 0.0, -1, ")");
            if (cb.ToUpper() == "SIN")
            {
                addItem(4, 0.0, 4, "sin");
                return 0;
            }
            else if (cb.ToUpper() == "COS")
            {
                addItem(4, 0.0, 5, "cos");
                return 0;
            }
            else if (cb.ToUpper() == "TAN")
            {
                addItem(4, 0.0, 6, "tan");
                return 0;
            }
            else if (cb.ToUpper() == "E")
            {
                addItem(4, 0.0, 7, "e");
                return 0;
            }
            else if (cb.ToUpper() == "LN")
            {
                addItem(4, 0.0, 8, "ln");
                return 0;
            }
            else if (cb.ToUpper() == "ASIN")
            {
                addItem(4, 0.0, 12, "asin");
                return 0;
            }
            else if (cb.ToUpper() == "ACOS")
            {
                addItem(4, 0.0, 13, "acos");
                return 0;
            }
            else if (cb.ToUpper() == "ATAN")
            {
                addItem(4, 0.0, 14, "atan");
                return 0;
            }

            return 5;

        }

        //---------------------------------------------------------------------------
        private int parse(String FktText)

        {
            ParsPart Item;
            int i;
            int Error;

            if (FktText == oldParseText)
                return 0;
            parseText = new List<String>();
            // damit, wenn auf Fehler läuft, bei einer
            // weiteren Berechnugn geparst wird
            oldParseText = "";
            // bisherige Liste löschen;

            liste = new List<ParsPart>();
            //delListe();
            // Jetzt ist Liste leer
            Error = pr(FktText);
            if (Error != 0)
            {
                liste = new List<ParsPart>();
                return Error;
            }

            for (i = 0; i < liste.Count; i++)
            {
                Item = (ParsPart)(liste[i]);
                parseText.Add(Item.getText());
            }

            // Neuen FktText merken
            oldParseText = FktText;

            return 0;
        }

        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------

        /**
         * In dieser Funktion wird die Parserliste 'liste'
         * der Reihe nach durch alle Items durchgegangen
         * die rekursivitaet im Parsen drueckt sich hier in der
         * Reihenfolge der Items aus. Jedes Item enthaellt einen
         * Satz von Vorschriften uzur Auswertung
         * 
         * @param wert
         * @param ergebnis
         * @param index
         * @return
         */
        private int calc(Double wert, Double[] ergebnis, int[] index)
        {
            Double[] yy = new Double[1];
            yy[0] = 0.0;
            Double y = 0.0;
            ParsPart item;
            Params p;
            int Error = 0;

            item = (ParsPart)(liste[index[0]]);
            // Typ = 0   "x"
            // Typ = 1   "("
            // Typ = 2   ")"
            // Typ = 3   "Double"
            // Typ = 4   "Funktion"
            if ((index[0] == 0) && (liste.Count == 1))
            { // nur ein Item in Liste
                switch (item.getTyp())
                {
                    case 0: // x muss durch den konkreten Wert ersetzt werden
                        ergebnis[0] = wert;
                        return 0;
                    case 1:
                        Error = 7;
                        return Error;
                    case 2:
                        Error = 7;
                        return Error;
                    case 3: // Koennte auch ein konkreter Wert in der Funktion sein
                        ergebnis[0] = item.getValue();
                        return 0;
                    case 4:
                        Error = 7;
                        return Error;
                    default:
                        Error = 7;
                        return Error;
                }
            }
            switch (item.getTyp())
            { // ab hier mehrere Items
                case 0:
                    Error = 7;
                    return Error;
                case 1: // !!!! Klammer auf
                    break;
                case 2:
                    Error = 7;
                    return Error;
                case 3:
                    ergebnis[0] = item.getValue();
                    return 0;
                case 4:
                    Error = 7;
                    return Error;
                default:
                    Error = 7;
                    return Error;
            }
            // nur noch Klammer auf!
            // in der Liste einen Weiter gehen  (1 Parameter)
            index[0]++; // Index um einen erhoehen
            item = (ParsPart)(liste[index[0]]);
            p = new Params();
            switch (item.getTyp())
            {
                case 0:
                    p.setV1(wert);
                    break;
                case 1: // erneute Klammerauf
                        // Rekursiv
                    yy[0] = y;
                    Error = calc(wert, yy, index);
                    y = yy[0];
                    if (Error != 0)
                        return Error;
                    p.setV1(y);
                    break;
                case 2:
                    p = null;
                    Error = 7;
                    return Error;
                case 3:
                    p.setV1(item.getValue());
                    ;
                    break;
                case 4:
                    p = null;
                    Error = 7;
                    return Error;
                default:
                    p = null;
                    Error = 7;
                    return Error;
            }
            // in der Liste einen Weiter gehen   (2 Parameter)
            index[0]++;
            item = (ParsPart)(liste[index[0]]);
            switch (item.getTyp())
            {
                case 0:
                    p.setV2(wert);
                    break;
                case 1:
                    // Rekursiv
                    yy[0] = y;
                    Error = calc(wert, yy, index);
                    y = yy[0];
                    if (Error != 0)
                        return Error;
                    p.setV2(y);
                    break;
                case 2:
                    // kann ja auch eine einparametrige Funktion sein
                    break;
                case 3:
                    p.setV2(item.getValue());
                    break;
                case 4:
                    p = null;
                    Error = 7;
                    return Error;
                default:
                    p = null;
                    Error = 7;
                    return Error;
            }

            // in der Liste einen Weiter gehen normalerweise >Klammer zu<
            index[0]++;
            item = (ParsPart)(liste[index[0]]);
            // Typ = 0   "x"
            // Typ = 1   "("
            // Typ = 2   ")"
            // Typ = 3   "Double"
            // Typ = 4   "Funktion"
            switch (item.getTyp())
            {
                case 0:
                    p = null;
                    return Error;
                case 1:
                    p = null;
                    Error = 7;
                    return Error;
                case 2:
                    break;
                case 3:
                    p = null;
                    Error = 7;
                    return Error;
                case 4:
                    Error = invokeFkt(p, item.getToken());
                    if (Error != 0)
                        return Error;
                    ergebnis[0] = p.getResult();
                    p = null;
                    return 0;
                default:
                    p = null;
                    Error = 7;
                    return Error;
            }

            // in der Liste einen Weiter gehen normalerweise >Funktion<
            index[0]++;
            item = (ParsPart)(liste[index[0]]);
            // Typ = 0   "x"
            // Typ = 1   "("
            // Typ = 2   ")"
            // Typ = 3   "Double"
            // Typ = 4   "Funktion"
            switch (item.getTyp())
            {
                case 0:
                    p = null;
                    Error = 7;
                    return Error;
                case 1:
                    p = null;
                    Error = 7;
                    return Error;
                case 2:
                    p = null;
                    Error = 7;
                    return Error;
                case 3:
                    p = null;
                    Error = 7;
                    return Error;
                case 4:
                    Error = invokeFkt(p, item.getToken());
                    if (Error != 0)
                        return Error;
                    ergebnis[0] = p.getResult();
                    p = null;
                    return 0;
                default:
                    p = null;
                    Error = 7;
                    return Error;
            }

        }

        //---------------------------------------------------------------------------
        private int pIsZahl(String q, IsZahl isz)
        {
            //int i, n;
            double d = 0.0;
            try
            {
                d = Double.Parse(q) ;
                isz.setIsZahl(true);
            }
            catch (Exception ex)
            {
                isz.setIsZahl(false);
                return 0;
            }
            return 0;
            /*
            n = 0;
            if ( ( String.valueOf( q.charAt( 0 ) ).equals( "+" ) ) ||
                ( String.valueOf( q.charAt( 0 ) ).equals( "-" ) ) )
              return pIsZahl( q.substring( 1, q.length() ) );
            for( i = 0; i < q.length(); i++ )
            {
              if ( String.valueOf( q.charAt( i ) ).equals( "." ) )
                n++;
              else
                if ( ( !String.valueOf( q.charAt( i ) ).equals( "1" ) )
                    && ( !String.valueOf( q.charAt( i ) ).equals( "2" ) )
                    && ( !String.valueOf( q.charAt( i ) ).equals( "3" ) )
                    && ( !String.valueOf( q.charAt( i ) ).equals( "4" ) )
                    && ( !String.valueOf( q.charAt( i ) ).equals( "5" ) )
                    && ( !String.valueOf( q.charAt( i ) ).equals( "6" ) )
                    && ( !String.valueOf( q.charAt( i ) ).equals( "7" ) )
                    && ( !String.valueOf( q.charAt( i ) ).equals( "8" ) )
                    && ( !String.valueOf( q.charAt( i ) ).equals( "9" ) )
                    && ( !String.valueOf( q.charAt( i ) ).equals( "0" ) ) )
                {
                  isZahl = false;
                  return 0;
                }
              }
            }
            if ( n > 1 )
              return 2;

            isZahl = true;
            return 0;
             */
        }

        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private String changePointToKomma(String q)
        {
            int i;
            for (i = 0; i < q.Length; i++)
            {
                if (q[i] == '.')
                {
                    q = q.Substring(0, i) + "," + q.Substring(i + 1);
                    // return 0
                    continue;
                }
            }
            return q;
        }

        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private String pMinusFlip(String q)
        {
            int i;
            NKT kt = new NKT(0);
            for (i = 0; i < q.Length; i++)
            {
                if (changeN(q[i], kt))
                    continue;
                if ((kt.getNkt() == 0) && (q[i] == '+'))
                {
                    q = q.Substring(0, i) + "-" + q.Substring(i + 1);
                    continue;
                }
                if ((kt.getNkt() == 0) && (q[i] == '-'))
                {
                    q = q.Substring(0, i) + "+" + q.Substring(i + 1);
                    continue;
                }
            }
            return q;
        }

        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private String pDivFlip(String q)
        {
            int i;
            NKT kt = new NKT(0);
            for (i = 0; i < q.Length; i++)
            {
                if (changeN(q[i], kt))
                    continue;

                if ((kt.getNkt() == 0) && (q[i] == '/'))
                {
                    q = q.Substring(0, i) + "*" + q.Substring(i + 1);
                    continue;
                }
            }
            return q;
        }

        //---------------------------------------------------------------------------

        //---------------------------------------------------------------------------
        private int anzahlParameter(String q)
        {
            int i, Anzahl;
            NKT kt = new NKT(0);
            Anzahl = 0;

            for (i = 0; i < q.Length; i++)
            {
                if (changeN(q[i], kt))
                    continue;
                if ((kt.getNkt() == 0) && (q[i] ==','))
                    Anzahl++;
            }

            return Anzahl;

        }

        //---------------------------------------------------------------------------

        /*
         *  Invoke Funktion
         */
        private int invokeFkt(Params p, int index)
        {
            switch (index)
            {
                case 0:
                    return fnAdd(p);
                case 1:
                    return fnMinus(p);
                case 2:
                    return fnMul(p);
                case 3:
                    return fnDiv(p);
                case 4:
                    return fnSin(p);
                case 5:
                    return fnCos(p);
                case 6:
                    return fnTan(p);
                case 7:
                    return fnExp(p);
                case 8:
                    return fnLn(p);
                case 9:
                    return fnFlip(p);
                case 10:
                    return fnPot(p);
                case 11:
                    return fnNueberK(p);
                case 12:
                    return fnASin(p);
                case 13:
                    return fnACos(p);
                case 14:
                    return fnATan(p);

            }
            return 0;
        }

        private int transformMathErr()
        {

            return 0;
        }

        private int fnAdd(Params p)
        {
            try
            {
                p.setResult(p.getV1() + p.getV2());
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return transformMathErr();
        }

        //---------------------------------------------------------------------------

        private int fnMinus(Params p)
        {
            try
            {
                p.setResult(p.getV1() - p.getV2());
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return transformMathErr();
        }

        //---------------------------------------------------------------------------

        private int fnMul(Params p)
        {
            try
            {
                p.setResult(p.getV1() * p.getV2());
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return transformMathErr();
        }

        //---------------------------------------------------------------------------
        private int fnDiv(Params p)
        {

            if (Math.Abs(p.getV2()) >= 0.000000000000000001)
            {
                try
                {
                    p.setResult(p.getV1() / p.getV2());
                }
                catch (ArithmeticException ex)
                {
                    return 22;
                }
                return transformMathErr();
            }
            else
            {
                p.setResult(0.0);
                return 13;
            }
        }

        //---------------------------------------------------------------------------
        private int fnSin(Params p)
        {
            try
            {
                p.setResult(Math.Sin(p.getV1()));
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return transformMathErr();
        }

        //---------------------------------------------------------------------------

        private int fnCos(Params p)
        {
            try
            {
                p.setResult(Math.Cos(p.getV1()));
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return transformMathErr();
        }

        //---------------------------------------------------------------------------
        private int fnTan(Params p)
        {
            try
            {
                p.setResult(Math.Tan(p.getV1()));
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return 0;
        }

        //---------------------------------------------------------------------------
        private int fnExp(Params p)
        {
            try
            {
                p.setResult(Math.Exp(p.getV1()));
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return transformMathErr();
        }

        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private int fnLn(Params p)
        {

            try
            {
                p.setResult(Math.Log(p.getV1()));
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return transformMathErr();
        }

        //---------------------------------------------------------------------------
        private int fnFlip(Params p)
        {

            try
            {
                p.setResult((-1.0) * p.getV1());
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return transformMathErr();
        }

        //---------------------------------------------------------------------------
        private int fnPot(Params p)
        {
            try
            {
                double y = Math.Pow(p.getV1(), p.getV2());
                if ((y > -1000000000000.0) && (y < 1000000000000.0))
                    p.setResult(y);
                else
                {
                    p.setResult(0.0);
                    //return 22;
                }
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return transformMathErr();
        }

        //---------------------------------------------------------------------------
        private int fnASin(Params p) // 12
        {
            try
            {
                p.setResult(Math.Asin(p.getV1()));
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return transformMathErr();
        }

        //---------------------------------------------------------------------------
        private int fnACos(Params p) // 13
        {
            try
            {
                p.setResult(Math.Acos(p.getV1()));
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return transformMathErr();
        }

        //---------------------------------------------------------------------------
        private int fnATan(Params p) // 14
        {
            try
            {
                p.setResult(Math.Atan(p.getV1()));
            }
            catch (ArithmeticException ex)
            {
                return 22;
            }
            return transformMathErr();
        }

        //---------------------------------------------------------------------------

        private int fnNueberK(Params p)
        { // 11
            int n, k, i, wert;
            n = (int)(p.getV1());
            k = (int)(p.getV2());
            if (n < k)
            {
                p.setResult(0.0);
                return 20;
            }
            else if ((k == 0) || (k == n))
            {
                p.setResult(1.0);
                return transformMathErr();
            }
            wert = 1;
            try
            {
                for (i = 1; i <= k; i++)
                {
                    wert = wert * (n - i + 1) / i;
                }
            }
            catch (ArithmeticException ex)
            {
                p.setResult((double)0.0);
                return 22;
            }
            p.setResult((double)wert);
            return transformMathErr();

        }

        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private String errorTextIs(int Error)
        {

            switch (Error)
            {
                case 0:
                    return "";
                case 1:
                    return "Fehler: Zahlen-Zeichenfolge nicht konvertierbar!";
                case 2:
                    return "Fehler: Klammerung falsch!";
                case 3:
                    return "Fehler: Alleinstehendes mathematisches Zeichen!";
                case 4:
                    return "Fehler: Fehlende Parameterangabe!";
                case 5:
                    return "Fehler: Unbekannte Funktion, bzw unbekannter Ausdruck!";
                case 6:
                    return "Fehler: Eingeklammerter Bereich ohne weiteren Term!";
                case 7:
                    return "Fehler: Parserfolge nicht interpretierbar!";
                case 8:
                    return "Fehler: Nicht definierter Ausdruck (Falsche Variable?)!";
                case 9:
                    return "Fehler: Falsche Parameteranzahl!";
                case 10:
                    return "Fehler: Unbekannte 2-parametrige Funktion!";
                case 11:
                    return "Fehler: Argument der Exponentialfunktion zu groß (>700)!";
                case 12:
                    return "Fehler: Das Argument des natürlichen Logarythmus muss größer null sein!";
                case 13:
                    return "Fehler: Divsion durch null ist nicht definiert!";
                case 14:
                    return "Fehler: Das Argument liegt außerhalb des gültigen Definitionsbereichs für die Funktion.";
                case 15:
                    return "Fehler: Der Rückgabewert wäre eine mathematische Singularität.";
                case 16:
                    return "Fehler: Das Argument würde einen Rückgabewert erzeugen, dessen Wert größer als der größtzulässige Wert ist!";
                case 17:
                    return "Fehler: Das Argument würde einen Rückgabewert erzeugen, dessen Wert kleiner als der kleinstzulässige Wert ist!";
                case 18:
                    return "Fehler: Das Argument würde einen Rückgabewert erzeugen, bei dem sämtliche Dezimalstellen ungenau sind.";
                case 19:
                    return "Fehler: Falsches Funktions-Argument oder unzulässiger Funktionswert!";
                case 20:
                    return "Fehler: Bei der Funktion 'n über k' darf n nicht kleiner als k sein!!";
                case 21:
                    return "Fehler: Unbekannter Fehler - Leerer Text zu parsen?!";
                case 22:
                    return "Fehler: Arithmetischer Fehler ";
                default:
                    return "Unbekannter Fehler";
            }
        }

        //---------------------------------------------------------------------------
        private bool changeN(char c, NKT kt)
        {
            if (c == '(')
            {
                kt.setNkt(kt.getNkt() + 1);
                return true;
            }
            if (c == ')')
            {
                kt.setNkt(kt.getNkt() - 1);
                return true;
            }
            return false;
        }

        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        private int addItem(int typ, Double value, int token, String text)
        {
            ParsPart Item = new ParsPart();
            Item.setTyp(typ);
            Item.setValue(value);
            Item.setToken(token);
            Item.setText(text);
            liste.Add(Item);
            return 0;
        }

        //---------------------------------------------------------------------------
        private int berechne(Double wert, Double[] ergebnis )
        {
            int[] index = new int[1];
            index[0] = 0;

            return calc(wert, ergebnis, index);
        }

        //---------------------------------------------------------------------------
        public String parsen(String FktText)
        {
            int Error;
            //char sep;
            //sep = DecimalSeparator;
            //DecimalSeparator = ',' ;
            Error = parse(FktText);
            //DecimalSeparator = sep;
            return errorTextIs(Error);
        }

        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        public int doubleFktValue(Double x, Double[] ergebnis,
            String[] errorText)
        {
            int Error;
            //char sep;
            //sep = DecimalSeparator;
            //DecimalSeparator = ',' ;
            Error = berechne(x, ergebnis);
            //DecimalSeparator = sep;
            errorText[0] = errorTextIs(Error);
            return Error;
        }
        //---------------------------------------------------------------------------
    }
}
