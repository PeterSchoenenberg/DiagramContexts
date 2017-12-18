namespace ProjektArbeit
{
    partial class FrmPunktwolkenSqlite
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
            this.components = new System.ComponentModel.Container();
            this.panLeft = new System.Windows.Forms.Panel();
            this.btnLaendergrenzensqlite = new System.Windows.Forms.Button();
            this.btnGPX = new System.Windows.Forms.Button();
            this.lblDistance = new System.Windows.Forms.Label();
            this.tbLongitude2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLatitude2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.tbLongitude1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLatitude1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnHaltestellen = new System.Windows.Forms.Button();
            this.btnPostleitzahlen = new System.Windows.Forms.Button();
            this.panMainRight = new System.Windows.Forms.Panel();
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panRight = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grdView = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oTimer = new System.Windows.Forms.Timer(this.components);
            this.panLeft.SuspendLayout();
            this.panMainRight.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.SuspendLayout();
            // 
            // panLeft
            // 
            this.panLeft.BackColor = System.Drawing.Color.Cornsilk;
            this.panLeft.Controls.Add(this.btnLaendergrenzensqlite);
            this.panLeft.Controls.Add(this.btnGPX);
            this.panLeft.Controls.Add(this.lblDistance);
            this.panLeft.Controls.Add(this.tbLongitude2);
            this.panLeft.Controls.Add(this.label4);
            this.panLeft.Controls.Add(this.tbLatitude2);
            this.panLeft.Controls.Add(this.label5);
            this.panLeft.Controls.Add(this.lbl2);
            this.panLeft.Controls.Add(this.tbLongitude1);
            this.panLeft.Controls.Add(this.label3);
            this.panLeft.Controls.Add(this.tbLatitude1);
            this.panLeft.Controls.Add(this.label2);
            this.panLeft.Controls.Add(this.lbl1);
            this.panLeft.Controls.Add(this.btnHaltestellen);
            this.panLeft.Controls.Add(this.btnPostleitzahlen);
            this.panLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panLeft.Location = new System.Drawing.Point(0, 0);
            this.panLeft.Name = "panLeft";
            this.panLeft.Size = new System.Drawing.Size(200, 593);
            this.panLeft.TabIndex = 0;
            // 
            // btnLaendergrenzensqlite
            // 
            this.btnLaendergrenzensqlite.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnLaendergrenzensqlite.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaendergrenzensqlite.ForeColor = System.Drawing.Color.Indigo;
            this.btnLaendergrenzensqlite.Location = new System.Drawing.Point(24, 520);
            this.btnLaendergrenzensqlite.Name = "btnLaendergrenzensqlite";
            this.btnLaendergrenzensqlite.Size = new System.Drawing.Size(142, 64);
            this.btnLaendergrenzensqlite.TabIndex = 14;
            this.btnLaendergrenzensqlite.Text = "Ländergrenzen über Sqlite - Datenbank";
            this.btnLaendergrenzensqlite.UseVisualStyleBackColor = false;
            this.btnLaendergrenzensqlite.Click += new System.EventHandler(this.btnLaendergrenzensqlite_Click);
            // 
            // btnGPX
            // 
            this.btnGPX.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnGPX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGPX.ForeColor = System.Drawing.Color.Indigo;
            this.btnGPX.Location = new System.Drawing.Point(24, 452);
            this.btnGPX.Name = "btnGPX";
            this.btnGPX.Size = new System.Drawing.Size(142, 62);
            this.btnGPX.TabIndex = 13;
            this.btnGPX.Text = "Ländergrenzen über GPX - Datei";
            this.btnGPX.UseVisualStyleBackColor = false;
            this.btnGPX.Click += new System.EventHandler(this.btnGPX_Click);
            // 
            // lblDistance
            // 
            this.lblDistance.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblDistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistance.ForeColor = System.Drawing.Color.Indigo;
            this.lblDistance.Location = new System.Drawing.Point(18, 360);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(175, 23);
            this.lblDistance.TabIndex = 12;
            this.lblDistance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLongitude2
            // 
            this.tbLongitude2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLongitude2.Location = new System.Drawing.Point(37, 317);
            this.tbLongitude2.Name = "tbLongitude2";
            this.tbLongitude2.Size = new System.Drawing.Size(156, 24);
            this.tbLongitude2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Cornsilk;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Indigo;
            this.label4.Location = new System.Drawing.Point(34, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Longitude";
            // 
            // tbLatitude2
            // 
            this.tbLatitude2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLatitude2.Location = new System.Drawing.Point(37, 262);
            this.tbLatitude2.Name = "tbLatitude2";
            this.tbLatitude2.Size = new System.Drawing.Size(156, 24);
            this.tbLatitude2.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Cornsilk;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(34, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Latitude";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.Color.Cornsilk;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.Indigo;
            this.lbl2.Location = new System.Drawing.Point(21, 212);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(65, 18);
            this.lbl2.TabIndex = 7;
            this.lbl2.Text = "Punkt 2";
            // 
            // tbLongitude1
            // 
            this.tbLongitude1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLongitude1.Location = new System.Drawing.Point(37, 179);
            this.tbLongitude1.Name = "tbLongitude1";
            this.tbLongitude1.Size = new System.Drawing.Size(156, 24);
            this.tbLongitude1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Cornsilk;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(34, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Longitude";
            // 
            // tbLatitude1
            // 
            this.tbLatitude1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLatitude1.Location = new System.Drawing.Point(37, 124);
            this.tbLatitude1.Name = "tbLatitude1";
            this.tbLatitude1.Size = new System.Drawing.Size(156, 24);
            this.tbLatitude1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Cornsilk;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(34, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Latitude";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.Cornsilk;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.Indigo;
            this.lbl1.Location = new System.Drawing.Point(21, 74);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(65, 18);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Punkt 1";
            // 
            // btnHaltestellen
            // 
            this.btnHaltestellen.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnHaltestellen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHaltestellen.ForeColor = System.Drawing.Color.Indigo;
            this.btnHaltestellen.Location = new System.Drawing.Point(24, 13);
            this.btnHaltestellen.Name = "btnHaltestellen";
            this.btnHaltestellen.Size = new System.Drawing.Size(142, 50);
            this.btnHaltestellen.TabIndex = 1;
            this.btnHaltestellen.Text = "Haltestellen";
            this.btnHaltestellen.UseVisualStyleBackColor = false;
            this.btnHaltestellen.Click += new System.EventHandler(this.btnHaltestellen_Click);
            // 
            // btnPostleitzahlen
            // 
            this.btnPostleitzahlen.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnPostleitzahlen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostleitzahlen.ForeColor = System.Drawing.Color.Indigo;
            this.btnPostleitzahlen.Location = new System.Drawing.Point(24, 399);
            this.btnPostleitzahlen.Name = "btnPostleitzahlen";
            this.btnPostleitzahlen.Size = new System.Drawing.Size(142, 47);
            this.btnPostleitzahlen.TabIndex = 0;
            this.btnPostleitzahlen.Text = "Postleitzahlen";
            this.btnPostleitzahlen.UseVisualStyleBackColor = false;
            this.btnPostleitzahlen.Click += new System.EventHandler(this.btnPostleitzahlen_Click);
            // 
            // panMainRight
            // 
            this.panMainRight.Controls.Add(this.tabPage);
            this.panMainRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMainRight.Location = new System.Drawing.Point(200, 0);
            this.panMainRight.Name = "panMainRight";
            this.panMainRight.Size = new System.Drawing.Size(448, 593);
            this.panMainRight.TabIndex = 1;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.tabPage1);
            this.tabPage.Controls.Add(this.tabPage2);
            this.tabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage.Location = new System.Drawing.Point(0, 0);
            this.tabPage.Name = "tabPage";
            this.tabPage.SelectedIndex = 0;
            this.tabPage.Size = new System.Drawing.Size(448, 593);
            this.tabPage.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panRight);
            this.tabPage1.ForeColor = System.Drawing.Color.Indigo;
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(440, 562);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Diagramm";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panRight
            // 
            this.panRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panRight.Location = new System.Drawing.Point(0, 0);
            this.panRight.Name = "panRight";
            this.panRight.Padding = new System.Windows.Forms.Padding(40);
            this.panRight.Size = new System.Drawing.Size(440, 562);
            this.panRight.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdView);
            this.tabPage2.ForeColor = System.Drawing.Color.Indigo;
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(440, 562);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DataGrid";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grdView
            // 
            this.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            this.grdView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdView.Location = new System.Drawing.Point(3, 3);
            this.grdView.Name = "grdView";
            this.grdView.Size = new System.Drawing.Size(434, 556);
            this.grdView.TabIndex = 0;
            this.grdView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdView_CellClick);
            this.grdView.Resize += new System.EventHandler(this.grdView_Resize);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ID";
            this.Column4.Name = "Column4";
            this.Column4.Width = 55;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ort";
            this.Column1.Name = "Column1";
            this.Column1.Width = 140;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Longitude";
            this.Column2.Name = "Column2";
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Latitude";
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // oTimer
            // 
            this.oTimer.Enabled = true;
            this.oTimer.Interval = 500;
            this.oTimer.Tick += new System.EventHandler(this.oTimer_Tick);
            // 
            // FrmPunktwolkenSqlite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(648, 593);
            this.Controls.Add(this.panMainRight);
            this.Controls.Add(this.panLeft);
            this.Name = "FrmPunktwolkenSqlite";
            this.Text = "FrmPunktwolkenSqlite";
            this.Resize += new System.EventHandler(this.FrmPunktwolkenSqlite_Resize);
            this.panLeft.ResumeLayout(false);
            this.panLeft.PerformLayout();
            this.panMainRight.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panLeft;
        private System.Windows.Forms.Button btnHaltestellen;
        private System.Windows.Forms.Button btnPostleitzahlen;
        private System.Windows.Forms.Panel panMainRight;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.TextBox tbLongitude2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLatitude2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox tbLongitude1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLatitude1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Timer oTimer;
        private System.Windows.Forms.TabControl tabPage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panRight;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnGPX;
        private System.Windows.Forms.Button btnLaendergrenzensqlite;
    }
}