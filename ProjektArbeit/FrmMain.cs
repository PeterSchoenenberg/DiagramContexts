using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjektArbeit.utils.util;
using ProjektArbeit.parser.parse;
using ProjektArbeit.anzeige.panel;

namespace ProjektArbeit
{

    public enum DatabaseKind { dbSqlite, dbAccess };
    public partial class FrmMain : Form
    {
        List<XYPoint> werte = null;

        Kurve curve;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void cmdFunktionen_Click(object sender, EventArgs e)
        {
            Funktion frmFunktion = new Funktion();

            frmFunktion.Show();

            // int n = 3;
            // cmdFunktionen.Text = n.ToString();

        }

        private void cmdSqlite_Click(object sender, EventArgs e)
        {
            FrmPunktwolkenSqlite frmPunktwolkenSqlite = new FrmPunktwolkenSqlite();
            frmPunktwolkenSqlite.dbKind = DatabaseKind.dbSqlite;
            frmPunktwolkenSqlite.AdjustDB();

            frmPunktwolkenSqlite.Show();

        }

        private void programmBeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void funktionenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdFunktionen_Click(null, null);
        }

        private void punktwolkenAusSqliteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdSqlite_Click(null, null);
        }

        private void punktwolkenAusAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAccessShowForm_Click(object sender, EventArgs e)
        {
            FrmPunktwolkenSqlite frmPunktwolkenSqlite = new FrmPunktwolkenSqlite();
            frmPunktwolkenSqlite.dbKind = DatabaseKind.dbAccess;
            frmPunktwolkenSqlite.AdjustDB();

            frmPunktwolkenSqlite.Show();

        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            XmlGpxImport frmXmlGpx = new XmlGpxImport();
            

            frmXmlGpx.ShowDialog();


        }
    }
}
