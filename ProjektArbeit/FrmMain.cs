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
        TreeNode nodeClose = null;
        TreeNode nodeFunctions = null;
        TreeNode SqliteClouds = null;
        TreeNode AccessClouds = null;
        TreeNode XmlGpxImport = null;
        
        TreeNode nodeLast = null;

        public FrmMain()
        {
            InitializeComponent();
            menu.Renderer = new MyRenderer();

            panPunktSqlite.Location = new Point(3, 03);
            panAccessClouds.Location = new Point(126, 03);
            panShowFunctions.Location = new Point(249, 03);
            panXmlGpxImport.Location = new Point(3, 51);
            menu.ForeColor = Color.Indigo;
            funktionenToolStripMenuItem.ForeColor = Color.Indigo;
            funktionenToolStripMenuItem.BackColor = Color.FromArgb(224,224,224);
            punktwolkenAusSqliteToolStripMenuItem.ForeColor = Color.Indigo;
            punktwolkenAusSqliteToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);
            punktwolkenAusAccessToolStripMenuItem.ForeColor = Color.Indigo;
            punktwolkenAusAccessToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);
            bildanalyseToolStripMenuItem.ForeColor = Color.Indigo;
            bildanalyseToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);
            xMLGPXImportToolStripMenuItem.ForeColor = Color.Indigo;
            xMLGPXImportToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);
            toolStripSeparator1.ForeColor = Color.Indigo;
            //toolStripSeparator1.BackColor = Color.FromArgb(224, 224, 224);
            programmBeendenToolStripMenuItem.ForeColor = Color.Indigo;
            programmBeendenToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
            // Set the accept button of the form to button1.
            //this.AcceptButton = button1;
            // Set the cancel button of the form to button2.
            //this.CancelButton = button2;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            TreeNode nodeProgramm = oTree.Nodes.Add("Program");
            nodeClose = nodeProgramm.Nodes.Add("Close Programm");
            TreeNode nodeTools = oTree.Nodes.Add("Tools");
            nodeFunctions =nodeTools.Nodes.Add("Functions Diagramm");
            
            SqliteClouds = nodeTools.Nodes.Add("Sqlite Clouds"); ;
            AccessClouds = nodeTools.Nodes.Add("Access Clouds"); ;
            XmlGpxImport = nodeTools.Nodes.Add("XML-GPX Import"); ;

            oTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(oTree_AfterSelect);
        }

        private void cmdFunktionen_Click(object sender, EventArgs e)
        {

        }

        private void programmBeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void funktionenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblShowFunctions_Click(null, null);
        }

        private void punktwolkenAusSqliteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblSqlite_Click(sender, e);
        }

        private void btnAccessShowForm_Click(object sender, EventArgs e)
        {

        }

        private void cmdImport_Click(object sender, EventArgs e)
        {

        }

        private void panPunktSqlite_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void panPunktSqlite_MouseLeave(object sender, EventArgs e)
        {
        }

        private void lblSqlite_MouseLeave(object sender, EventArgs e)
        {
            panPunktSqlite.BackColor = SystemColors.InactiveCaption;
        }

        private void lblSqlite_MouseMove(object sender, MouseEventArgs e)
        {
            panPunktSqlite.BackColor = SystemColors.ActiveCaption;
        }

        private void lblSqlite_Click(object sender, EventArgs e)
        {
            FrmPunktwolkenSqlite frmPunktwolkenSqlite = new FrmPunktwolkenSqlite();
            frmPunktwolkenSqlite.dbKind = DatabaseKind.dbSqlite;
            frmPunktwolkenSqlite.AdjustDB();

            frmPunktwolkenSqlite.Show();

        }

        private void lblAccessClouds_MouseLeave(object sender, EventArgs e)
        {
            panAccessClouds.BackColor = SystemColors.InactiveCaption;
        }

        private void lblAccessClouds_MouseMove(object sender, MouseEventArgs e)
        {
            panAccessClouds.BackColor = SystemColors.ActiveCaption;
        }

        private void lblAccessClouds_Click(object sender, EventArgs e)
        {
            FrmPunktwolkenSqlite frmPunktwolkenSqlite = new FrmPunktwolkenSqlite();
            frmPunktwolkenSqlite.dbKind = DatabaseKind.dbAccess;
            frmPunktwolkenSqlite.AdjustDB();

            frmPunktwolkenSqlite.Show();

        }

        private void lblShowFunctions_MouseLeave(object sender, EventArgs e)
        {
            panShowFunctions.BackColor = SystemColors.InactiveCaption;
        }

        private void lblShowFunctions_MouseMove(object sender, MouseEventArgs e)
        {
            panShowFunctions.BackColor = SystemColors.ActiveCaption;
        }

        private void lblShowFunctions_Click(object sender, EventArgs e)
        {
            Funktion frmFunktion = new Funktion();

            frmFunktion.Show();

            // int n = 3;
            // cmdFunktionen.Text = n.ToString();

        }

        private void lblXmlGpxImport_MouseLeave(object sender, EventArgs e)
        {
            panXmlGpxImport.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void lblXmlGpxImport_MouseMove(object sender, MouseEventArgs e)
        {
            panXmlGpxImport.BackColor = SystemColors.GradientActiveCaption;
        }

        private void lblXmlGpxImport_Click(object sender, EventArgs e)
        {
            XmlGpxImport frmXmlGpx = new XmlGpxImport();
            frmXmlGpx.ShowDialog();
        }

        private void oTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            

            if (oTree.SelectedNode.Text == nodeClose.Text)
            {
                Application.Exit();
                return;
            }
            else if (oTree.SelectedNode.Text == nodeFunctions.Text)
            {
                lblShowFunctions_Click(null, null);
            }
            else if (oTree.SelectedNode.Text == SqliteClouds.Text)
            {
                lblSqlite_Click(null, null);
            }
            else if (oTree.SelectedNode.Text == AccessClouds.Text)
            {
                lblAccessClouds_Click(null, null);
            }
            else if (oTree.SelectedNode.Text == XmlGpxImport.Text)
            {
                lblXmlGpxImport_Click(null, null);
            }



        }

        private void oTree_MouseClick(object sender, MouseEventArgs e)
        {

            /*
            if (nodeLast == oTree.SelectedNode)
                oTree_AfterSelect(null, null);
            else
                nodeLast = oTree.SelectedNode;
                */
        }

        private void oTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
        }

        private void bildanalyseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BildAnalyse frmBild = new BildAnalyse();
            frmBild.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hilfe frmHilfe = new Hilfe();
            frmHilfe.ShowDialog();
        }
    }
    class MyRenderer : ToolStripProfessionalRenderer
    {


        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {

            Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(224, 224, 224)), bounds);

            Pen pen = new Pen(Color.Blue);
            e.Graphics.DrawLine(pen, 0, bounds.Top + 1, bounds.Width, bounds.Top + 1);
            pen.Dispose();
        }
    }

}
