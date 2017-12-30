namespace ProjektArbeit
{
    partial class FrmMain
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programmBeendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.werkzeugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funktionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.punktwolkenAusSqliteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.punktwolkenAusAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.xMLGPXImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bildanalyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panPunktSqlite = new System.Windows.Forms.Panel();
            this.lblSqlite = new System.Windows.Forms.Label();
            this.panAccessClouds = new System.Windows.Forms.Panel();
            this.lblAccessClouds = new System.Windows.Forms.Label();
            this.panShowFunctions = new System.Windows.Forms.Panel();
            this.lblShowFunctions = new System.Windows.Forms.Label();
            this.panXmlGpxImport = new System.Windows.Forms.Panel();
            this.lblXmlGpxImport = new System.Windows.Forms.Label();
            this.oTree = new System.Windows.Forms.TreeView();
            this.oSplit = new System.Windows.Forms.Splitter();
            this.panMain = new System.Windows.Forms.Panel();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.panPunktSqlite.SuspendLayout();
            this.panAccessClouds.SuspendLayout();
            this.panShowFunctions.SuspendLayout();
            this.panXmlGpxImport.SuspendLayout();
            this.panMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.werkzeugeToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(621, 40);
            this.menu.TabIndex = 3;
            this.menu.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programmBeendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(82, 36);
            this.dateiToolStripMenuItem.Text = "Program";
            // 
            // programmBeendenToolStripMenuItem
            // 
            this.programmBeendenToolStripMenuItem.Name = "programmBeendenToolStripMenuItem";
            this.programmBeendenToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.programmBeendenToolStripMenuItem.Text = "Close Program";
            this.programmBeendenToolStripMenuItem.Click += new System.EventHandler(this.programmBeendenToolStripMenuItem_Click);
            // 
            // werkzeugeToolStripMenuItem
            // 
            this.werkzeugeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funktionenToolStripMenuItem,
            this.punktwolkenAusSqliteToolStripMenuItem,
            this.punktwolkenAusAccessToolStripMenuItem,
            this.toolStripSeparator1,
            this.xMLGPXImportToolStripMenuItem,
            this.bildanalyseToolStripMenuItem});
            this.werkzeugeToolStripMenuItem.Name = "werkzeugeToolStripMenuItem";
            this.werkzeugeToolStripMenuItem.Size = new System.Drawing.Size(58, 36);
            this.werkzeugeToolStripMenuItem.Text = "Tools";
            // 
            // funktionenToolStripMenuItem
            // 
            this.funktionenToolStripMenuItem.Name = "funktionenToolStripMenuItem";
            this.funktionenToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.funktionenToolStripMenuItem.Text = "Functions Diagram";
            this.funktionenToolStripMenuItem.Click += new System.EventHandler(this.lblShowFunctions_Click);
            // 
            // punktwolkenAusSqliteToolStripMenuItem
            // 
            this.punktwolkenAusSqliteToolStripMenuItem.Name = "punktwolkenAusSqliteToolStripMenuItem";
            this.punktwolkenAusSqliteToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.punktwolkenAusSqliteToolStripMenuItem.Text = "Sqlite Clouds";
            this.punktwolkenAusSqliteToolStripMenuItem.Click += new System.EventHandler(this.lblSqlite_Click);
            // 
            // punktwolkenAusAccessToolStripMenuItem
            // 
            this.punktwolkenAusAccessToolStripMenuItem.Name = "punktwolkenAusAccessToolStripMenuItem";
            this.punktwolkenAusAccessToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.punktwolkenAusAccessToolStripMenuItem.Text = "Access Clouds";
            this.punktwolkenAusAccessToolStripMenuItem.Click += new System.EventHandler(this.lblAccessClouds_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // xMLGPXImportToolStripMenuItem
            // 
            this.xMLGPXImportToolStripMenuItem.Name = "xMLGPXImportToolStripMenuItem";
            this.xMLGPXImportToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.xMLGPXImportToolStripMenuItem.Text = "XML-GPX Import";
            this.xMLGPXImportToolStripMenuItem.Click += new System.EventHandler(this.lblXmlGpxImport_Click);
            // 
            // bildanalyseToolStripMenuItem
            // 
            this.bildanalyseToolStripMenuItem.Name = "bildanalyseToolStripMenuItem";
            this.bildanalyseToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.bildanalyseToolStripMenuItem.Text = "Bildanalyse";
            this.bildanalyseToolStripMenuItem.Click += new System.EventHandler(this.bildanalyseToolStripMenuItem_Click);
            // 
            // panPunktSqlite
            // 
            this.panPunktSqlite.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panPunktSqlite.Controls.Add(this.lblSqlite);
            this.panPunktSqlite.Location = new System.Drawing.Point(102, 35);
            this.panPunktSqlite.Name = "panPunktSqlite";
            this.panPunktSqlite.Size = new System.Drawing.Size(120, 45);
            this.panPunktSqlite.TabIndex = 5;
            this.panPunktSqlite.MouseLeave += new System.EventHandler(this.panPunktSqlite_MouseLeave);
            this.panPunktSqlite.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panPunktSqlite_MouseMove);
            // 
            // lblSqlite
            // 
            this.lblSqlite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSqlite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSqlite.ForeColor = System.Drawing.Color.Indigo;
            this.lblSqlite.Location = new System.Drawing.Point(0, 0);
            this.lblSqlite.Name = "lblSqlite";
            this.lblSqlite.Size = new System.Drawing.Size(120, 45);
            this.lblSqlite.TabIndex = 0;
            this.lblSqlite.Text = " Sqlite \r\nClouds";
            this.lblSqlite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSqlite.Click += new System.EventHandler(this.lblSqlite_Click);
            this.lblSqlite.MouseLeave += new System.EventHandler(this.lblSqlite_MouseLeave);
            this.lblSqlite.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSqlite_MouseMove);
            // 
            // panAccessClouds
            // 
            this.panAccessClouds.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panAccessClouds.Controls.Add(this.lblAccessClouds);
            this.panAccessClouds.Location = new System.Drawing.Point(27, 87);
            this.panAccessClouds.Name = "panAccessClouds";
            this.panAccessClouds.Size = new System.Drawing.Size(120, 45);
            this.panAccessClouds.TabIndex = 6;
            // 
            // lblAccessClouds
            // 
            this.lblAccessClouds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAccessClouds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccessClouds.ForeColor = System.Drawing.Color.Indigo;
            this.lblAccessClouds.Location = new System.Drawing.Point(0, 0);
            this.lblAccessClouds.Name = "lblAccessClouds";
            this.lblAccessClouds.Size = new System.Drawing.Size(120, 45);
            this.lblAccessClouds.TabIndex = 0;
            this.lblAccessClouds.Text = " Access \r\nClouds";
            this.lblAccessClouds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAccessClouds.Click += new System.EventHandler(this.lblAccessClouds_Click);
            this.lblAccessClouds.MouseLeave += new System.EventHandler(this.lblAccessClouds_MouseLeave);
            this.lblAccessClouds.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblAccessClouds_MouseMove);
            // 
            // panShowFunctions
            // 
            this.panShowFunctions.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panShowFunctions.Controls.Add(this.lblShowFunctions);
            this.panShowFunctions.Location = new System.Drawing.Point(135, 138);
            this.panShowFunctions.Name = "panShowFunctions";
            this.panShowFunctions.Size = new System.Drawing.Size(120, 45);
            this.panShowFunctions.TabIndex = 7;
            // 
            // lblShowFunctions
            // 
            this.lblShowFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShowFunctions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowFunctions.ForeColor = System.Drawing.Color.Indigo;
            this.lblShowFunctions.Location = new System.Drawing.Point(0, 0);
            this.lblShowFunctions.Name = "lblShowFunctions";
            this.lblShowFunctions.Size = new System.Drawing.Size(120, 45);
            this.lblShowFunctions.TabIndex = 0;
            this.lblShowFunctions.Text = " Functions\r\nDiagram";
            this.lblShowFunctions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblShowFunctions.Click += new System.EventHandler(this.lblShowFunctions_Click);
            this.lblShowFunctions.MouseLeave += new System.EventHandler(this.lblShowFunctions_MouseLeave);
            this.lblShowFunctions.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblShowFunctions_MouseMove);
            // 
            // panXmlGpxImport
            // 
            this.panXmlGpxImport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panXmlGpxImport.Controls.Add(this.lblXmlGpxImport);
            this.panXmlGpxImport.Location = new System.Drawing.Point(126, 226);
            this.panXmlGpxImport.Name = "panXmlGpxImport";
            this.panXmlGpxImport.Size = new System.Drawing.Size(120, 45);
            this.panXmlGpxImport.TabIndex = 8;
            // 
            // lblXmlGpxImport
            // 
            this.lblXmlGpxImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblXmlGpxImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXmlGpxImport.ForeColor = System.Drawing.Color.Indigo;
            this.lblXmlGpxImport.Location = new System.Drawing.Point(0, 0);
            this.lblXmlGpxImport.Name = "lblXmlGpxImport";
            this.lblXmlGpxImport.Size = new System.Drawing.Size(120, 45);
            this.lblXmlGpxImport.TabIndex = 0;
            this.lblXmlGpxImport.Text = "XML-GPX\r\n  Import";
            this.lblXmlGpxImport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblXmlGpxImport.Click += new System.EventHandler(this.lblXmlGpxImport_Click);
            this.lblXmlGpxImport.MouseLeave += new System.EventHandler(this.lblXmlGpxImport_MouseLeave);
            this.lblXmlGpxImport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblXmlGpxImport_MouseMove);
            // 
            // oTree
            // 
            this.oTree.BackColor = System.Drawing.Color.Cornsilk;
            this.oTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.oTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oTree.ForeColor = System.Drawing.Color.Indigo;
            this.oTree.Location = new System.Drawing.Point(0, 40);
            this.oTree.Name = "oTree";
            this.oTree.Size = new System.Drawing.Size(202, 360);
            this.oTree.TabIndex = 9;
            this.oTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.oTree_BeforeSelect);
            this.oTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.oTree_MouseClick);
            // 
            // oSplit
            // 
            this.oSplit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.oSplit.Location = new System.Drawing.Point(202, 40);
            this.oSplit.Name = "oSplit";
            this.oSplit.Size = new System.Drawing.Size(5, 360);
            this.oSplit.TabIndex = 10;
            this.oSplit.TabStop = false;
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.panPunktSqlite);
            this.panMain.Controls.Add(this.panShowFunctions);
            this.panMain.Controls.Add(this.panXmlGpxImport);
            this.panMain.Controls.Add(this.panAccessClouds);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(207, 40);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(414, 360);
            this.panMain.TabIndex = 11;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 36);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(621, 400);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.oSplit);
            this.Controls.Add(this.oTree);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "FrmMain";
            this.Text = "Display Datas in different contexts";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panPunktSqlite.ResumeLayout(false);
            this.panAccessClouds.ResumeLayout(false);
            this.panShowFunctions.ResumeLayout(false);
            this.panXmlGpxImport.ResumeLayout(false);
            this.panMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programmBeendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem werkzeugeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funktionenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem punktwolkenAusSqliteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem punktwolkenAusAccessToolStripMenuItem;
        private System.Windows.Forms.Panel panPunktSqlite;
        private System.Windows.Forms.Label lblSqlite;
        private System.Windows.Forms.Panel panAccessClouds;
        private System.Windows.Forms.Label lblAccessClouds;
        private System.Windows.Forms.Panel panShowFunctions;
        private System.Windows.Forms.Label lblShowFunctions;
        private System.Windows.Forms.Panel panXmlGpxImport;
        private System.Windows.Forms.Label lblXmlGpxImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem xMLGPXImportToolStripMenuItem;
        private System.Windows.Forms.TreeView oTree;
        private System.Windows.Forms.Splitter oSplit;
        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.ToolStripMenuItem bildanalyseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}