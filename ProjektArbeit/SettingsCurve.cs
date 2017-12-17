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
    public partial class SettingsCurve : Form
    {
        public SettingsCurve()
        {
            InitializeComponent();

            String[] ka = { "PUNKT",
                    "DICKER_PUNKT",
                    "KREUZ",
                    "PLUSZEICHEN",
                    "RECHTECK_HOHL",
                    "RECHTECK_GEFUELLT" };
            cmbPunktArt.Items.AddRange(ka);

            cmbPunktArt.SelectedIndex = 0;

            tbFunktion.Text = "x*x";
            tbXEinheit.Text = "mm";
            tbYEinheit.Text = "mm";
            btnPunkteFarbe.BackColor = Color.Blue;
            numAnzahlPunkte.Value = 100;



        }

        public string Funktion { get; set; }
        public int IndexPunkteArt { get; set; }
        public Color PunkteFarbe { get; set; }
        public string XEinheit { get; set; }
        public string YEinheit { get; set; }
        public int AnzahlPunkte { get; set; }




        private void btnOK_Click(object sender, EventArgs e)
        {
            Funktion = tbFunktion.Text;
            IndexPunkteArt = cmbPunktArt.SelectedIndex;
            PunkteFarbe = btnPunkteFarbe.BackColor;
            XEinheit = tbXEinheit.Text;
            YEinheit = tbYEinheit.Text;
            AnzahlPunkte = Convert.ToInt32(numAnzahlPunkte.Value);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SettingsCurve_Load(object sender, EventArgs e)
        {


        }

        public void SetParameters()
        {

            cmbPunktArt.SelectedIndex = IndexPunkteArt;

            tbFunktion.Text = Funktion;
            tbXEinheit.Text = XEinheit;
            tbYEinheit.Text = YEinheit;
            btnPunkteFarbe.BackColor = PunkteFarbe;
            numAnzahlPunkte.Value = AnzahlPunkte;


        }


        private void btnPunkteFarbe_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnPunkteFarbe.BackColor = cd.Color;
                btnPunkteFarbe.ForeColor = Color.FromArgb(255 - cd.Color.R, 
                         255 - cd.Color.G, 255 - cd.Color.B);
            }
            else
                MessageBox.Show("Abbruch");
        }



    }
}
