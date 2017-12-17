using System;
using System.IO;
using System.Xml;
using System.Data.SQLite;
using System.Globalization;
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
    public partial class XmlGpxImport : Form
    {
        public XmlGpxImport()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

            if (!File.Exists("Landesgrenzen.gpx"))
                return;

            int nidx = 0;
            string dbname = tbDatabaseName.Text.Trim();
            dbname = dbname + ".db";
            if (!File.Exists(dbname))
            {
                SQLiteConnection.CreateFile(dbname);
                SQLiteConnection m_dbConnection;
                m_dbConnection = new SQLiteConnection("Data Source=" + dbname + ";Version=3;");
                m_dbConnection.Open();
                string sql = "create table laendergrenzen (idx int,breite double, laenge double)";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            else
            {
                SQLiteConnection m_dbConnection;
                m_dbConnection = new SQLiteConnection("Data Source=" + dbname + ";Version=3;");
                m_dbConnection.Open();
                string sql = "delete from laendergrenzen";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }

            
            XmlReader xr = new XmlTextReader("Landesgrenzen.gpx");






            string sx = "";
            string sy = "";

            SQLiteConnection m_dbConnection2;
            m_dbConnection2 = new SQLiteConnection("Data Source=" + dbname + ";Version=3;");
            m_dbConnection2.Open();
            SQLiteCommand command2 = null;
            while (xr.Read())
            {

                if (xr.NodeType == XmlNodeType.Element)
                {
                    if ((xr.Name == "trkpt") && (xr.AttributeCount > 0))
                    {
                        while (xr.MoveToNextAttribute())
                        {
                            if (xr.Name == "lat")
                            {
                                sy = xr.Value;
                            }
                            xr.MoveToNextAttribute();
                            if (xr.Name == "lon")
                            {
                                sx = xr.Value;
                            }
                            nidx++;
                            string sql = "insert into laendergrenzen (idx, breite, laenge) values ("+nidx+","+sy+","+sx+")";
                            command2 = new SQLiteCommand(sql, m_dbConnection2);
                            command2.ExecuteNonQuery();


                        }
                    }
                }

            }

            xr.Close();

            MessageBox.Show("Import erfolgreich beendet");
    
        }
    }
}
