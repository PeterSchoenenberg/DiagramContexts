namespace ProjektArbeit
{
    partial class BildAnalyse
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panLeft = new System.Windows.Forms.Panel();
            this.panClient = new System.Windows.Forms.Panel();
            this.panTop = new System.Windows.Forms.Panel();
            this.panPicture = new System.Windows.Forms.Panel();
            this.oPic = new System.Windows.Forms.PictureBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lv = new System.Windows.Forms.ListView();
            this.btnAbstract = new System.Windows.Forms.Button();
            this.btnMinimumFarbe = new System.Windows.Forms.Button();
            this.btnKontur = new System.Windows.Forms.Button();
            this.btnFilterRed = new System.Windows.Forms.Button();
            this.btnFilterGreen = new System.Windows.Forms.Button();
            this.btnFilterBlue = new System.Windows.Forms.Button();
            this.panLeft.SuspendLayout();
            this.panClient.SuspendLayout();
            this.panTop.SuspendLayout();
            this.panPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dChart)).BeginInit();
            this.SuspendLayout();
            // 
            // panLeft
            // 
            this.panLeft.Controls.Add(this.btnLoad);
            this.panLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panLeft.Location = new System.Drawing.Point(0, 0);
            this.panLeft.Name = "panLeft";
            this.panLeft.Size = new System.Drawing.Size(156, 603);
            this.panLeft.TabIndex = 0;
            // 
            // panClient
            // 
            this.panClient.Controls.Add(this.panPicture);
            this.panClient.Controls.Add(this.panTop);
            this.panClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panClient.Location = new System.Drawing.Point(156, 0);
            this.panClient.Name = "panClient";
            this.panClient.Size = new System.Drawing.Size(913, 603);
            this.panClient.TabIndex = 1;
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnFilterBlue);
            this.panTop.Controls.Add(this.btnFilterGreen);
            this.panTop.Controls.Add(this.btnFilterRed);
            this.panTop.Controls.Add(this.btnKontur);
            this.panTop.Controls.Add(this.btnMinimumFarbe);
            this.panTop.Controls.Add(this.btnAbstract);
            this.panTop.Controls.Add(this.lv);
            this.panTop.Controls.Add(this.dChart);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(913, 358);
            this.panTop.TabIndex = 0;
            // 
            // panPicture
            // 
            this.panPicture.Controls.Add(this.oPic);
            this.panPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPicture.Location = new System.Drawing.Point(0, 358);
            this.panPicture.Name = "panPicture";
            this.panPicture.Size = new System.Drawing.Size(913, 245);
            this.panPicture.TabIndex = 1;
            // 
            // oPic
            // 
            this.oPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oPic.Location = new System.Drawing.Point(0, 0);
            this.oPic.Name = "oPic";
            this.oPic.Size = new System.Drawing.Size(913, 245);
            this.oPic.TabIndex = 0;
            this.oPic.TabStop = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(12, 22);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(127, 35);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Bild laden";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dChart
            // 
            chartArea1.Name = "ChartArea1";
            this.dChart.ChartAreas.Add(chartArea1);
            this.dChart.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.dChart.Legends.Add(legend1);
            this.dChart.Location = new System.Drawing.Point(0, 0);
            this.dChart.Name = "dChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.dChart.Series.Add(series1);
            this.dChart.Size = new System.Drawing.Size(913, 217);
            this.dChart.TabIndex = 0;
            this.dChart.Text = "chart1";
            // 
            // lv
            // 
            this.lv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv.Dock = System.Windows.Forms.DockStyle.Left;
            this.lv.Location = new System.Drawing.Point(0, 217);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(532, 141);
            this.lv.TabIndex = 1;
            this.lv.UseCompatibleStateImageBehavior = false;
            // 
            // btnAbstract
            // 
            this.btnAbstract.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbstract.Location = new System.Drawing.Point(553, 239);
            this.btnAbstract.Name = "btnAbstract";
            this.btnAbstract.Size = new System.Drawing.Size(169, 33);
            this.btnAbstract.TabIndex = 2;
            this.btnAbstract.Text = "Maximum - Farbe";
            this.btnAbstract.UseVisualStyleBackColor = true;
            this.btnAbstract.Click += new System.EventHandler(this.btnAbstract_Click);
            // 
            // btnMinimumFarbe
            // 
            this.btnMinimumFarbe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimumFarbe.Location = new System.Drawing.Point(553, 278);
            this.btnMinimumFarbe.Name = "btnMinimumFarbe";
            this.btnMinimumFarbe.Size = new System.Drawing.Size(169, 33);
            this.btnMinimumFarbe.TabIndex = 3;
            this.btnMinimumFarbe.Text = "Minimum - Farbe";
            this.btnMinimumFarbe.UseVisualStyleBackColor = true;
            this.btnMinimumFarbe.Click += new System.EventHandler(this.btnMinimumFarbe_Click);
            // 
            // btnKontur
            // 
            this.btnKontur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKontur.Location = new System.Drawing.Point(553, 319);
            this.btnKontur.Name = "btnKontur";
            this.btnKontur.Size = new System.Drawing.Size(169, 33);
            this.btnKontur.TabIndex = 4;
            this.btnKontur.Text = "Kontur";
            this.btnKontur.UseVisualStyleBackColor = true;
            this.btnKontur.Click += new System.EventHandler(this.btnKontur_Click);
            // 
            // btnFilterRed
            // 
            this.btnFilterRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterRed.Location = new System.Drawing.Point(730, 239);
            this.btnFilterRed.Name = "btnFilterRed";
            this.btnFilterRed.Size = new System.Drawing.Size(169, 33);
            this.btnFilterRed.TabIndex = 5;
            this.btnFilterRed.Text = "Rot-Filter";
            this.btnFilterRed.UseVisualStyleBackColor = true;
            this.btnFilterRed.Click += new System.EventHandler(this.btnFilterRed_Click);
            // 
            // btnFilterGreen
            // 
            this.btnFilterGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterGreen.Location = new System.Drawing.Point(732, 278);
            this.btnFilterGreen.Name = "btnFilterGreen";
            this.btnFilterGreen.Size = new System.Drawing.Size(169, 33);
            this.btnFilterGreen.TabIndex = 6;
            this.btnFilterGreen.Text = "Grün-Filter";
            this.btnFilterGreen.UseVisualStyleBackColor = true;
            this.btnFilterGreen.Click += new System.EventHandler(this.btnFilterGreen_Click);
            // 
            // btnFilterBlue
            // 
            this.btnFilterBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterBlue.Location = new System.Drawing.Point(732, 317);
            this.btnFilterBlue.Name = "btnFilterBlue";
            this.btnFilterBlue.Size = new System.Drawing.Size(169, 33);
            this.btnFilterBlue.TabIndex = 7;
            this.btnFilterBlue.Text = "Blau-Filter";
            this.btnFilterBlue.UseVisualStyleBackColor = true;
            this.btnFilterBlue.Click += new System.EventHandler(this.btnFilterBlue_Click);
            // 
            // BildAnalyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 603);
            this.Controls.Add(this.panClient);
            this.Controls.Add(this.panLeft);
            this.Name = "BildAnalyse";
            this.Text = "BildAnalyse";
            this.panLeft.ResumeLayout(false);
            this.panClient.ResumeLayout(false);
            this.panTop.ResumeLayout(false);
            this.panPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panLeft;
        private System.Windows.Forms.Panel panClient;
        private System.Windows.Forms.Panel panPicture;
        private System.Windows.Forms.PictureBox oPic;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataVisualization.Charting.Chart dChart;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.Button btnAbstract;
        private System.Windows.Forms.Button btnMinimumFarbe;
        private System.Windows.Forms.Button btnKontur;
        private System.Windows.Forms.Button btnFilterRed;
        private System.Windows.Forms.Button btnFilterGreen;
        private System.Windows.Forms.Button btnFilterBlue;
    }
}