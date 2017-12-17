namespace ProjektArbeit
{
    partial class SettingsCurve
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbFunktion = new System.Windows.Forms.TextBox();
            this.cmbPunktArt = new System.Windows.Forms.ComboBox();
            this.btnPunkteFarbe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbXEinheit = new System.Windows.Forms.TextBox();
            this.tbYEinheit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numAnzahlPunkte = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAnzahlPunkte)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFunktion
            // 
            this.tbFunktion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFunktion.Location = new System.Drawing.Point(11, 15);
            this.tbFunktion.Multiline = true;
            this.tbFunktion.Name = "tbFunktion";
            this.tbFunktion.Size = new System.Drawing.Size(158, 242);
            this.tbFunktion.TabIndex = 0;
            // 
            // cmbPunktArt
            // 
            this.cmbPunktArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPunktArt.FormattingEnabled = true;
            this.cmbPunktArt.Location = new System.Drawing.Point(184, 15);
            this.cmbPunktArt.Name = "cmbPunktArt";
            this.cmbPunktArt.Size = new System.Drawing.Size(198, 26);
            this.cmbPunktArt.TabIndex = 1;
            // 
            // btnPunkteFarbe
            // 
            this.btnPunkteFarbe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPunkteFarbe.ForeColor = System.Drawing.Color.White;
            this.btnPunkteFarbe.Location = new System.Drawing.Point(184, 47);
            this.btnPunkteFarbe.Name = "btnPunkteFarbe";
            this.btnPunkteFarbe.Size = new System.Drawing.Size(198, 30);
            this.btnPunkteFarbe.TabIndex = 2;
            this.btnPunkteFarbe.Text = "Punktefarbe";
            this.btnPunkteFarbe.UseVisualStyleBackColor = true;
            this.btnPunkteFarbe.Click += new System.EventHandler(this.btnPunkteFarbe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(181, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "X-Einheit";
            // 
            // tbXEinheit
            // 
            this.tbXEinheit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbXEinheit.Location = new System.Drawing.Point(184, 113);
            this.tbXEinheit.Name = "tbXEinheit";
            this.tbXEinheit.Size = new System.Drawing.Size(198, 24);
            this.tbXEinheit.TabIndex = 4;
            // 
            // tbYEinheit
            // 
            this.tbYEinheit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbYEinheit.Location = new System.Drawing.Point(184, 174);
            this.tbYEinheit.Name = "tbYEinheit";
            this.tbYEinheit.Size = new System.Drawing.Size(198, 24);
            this.tbYEinheit.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(181, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y-Einheit";
            // 
            // numAnzahlPunkte
            // 
            this.numAnzahlPunkte.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAnzahlPunkte.Location = new System.Drawing.Point(184, 233);
            this.numAnzahlPunkte.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAnzahlPunkte.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAnzahlPunkte.Name = "numAnzahlPunkte";
            this.numAnzahlPunkte.Size = new System.Drawing.Size(198, 24);
            this.numAnzahlPunkte.TabIndex = 7;
            this.numAnzahlPunkte.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(182, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Anzahl der Punkte";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(63, 273);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(122, 33);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(233, 273);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 33);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 322);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numAnzahlPunkte);
            this.Controls.Add(this.tbYEinheit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbXEinheit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPunkteFarbe);
            this.Controls.Add(this.cmbPunktArt);
            this.Controls.Add(this.tbFunktion);
            this.Name = "SettingsCurve";
            this.Text = "SettingsCurve";
            this.Load += new System.EventHandler(this.SettingsCurve_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAnzahlPunkte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFunktion;
        private System.Windows.Forms.ComboBox cmbPunktArt;
        private System.Windows.Forms.Button btnPunkteFarbe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbXEinheit;
        private System.Windows.Forms.TextBox tbYEinheit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAnzahlPunkte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}