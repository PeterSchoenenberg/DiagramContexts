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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.cmdFunktionen = new System.Windows.Forms.Button();
            this.cmdSqlite = new System.Windows.Forms.Button();
            this.btnAccessShowForm = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programmBeendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.werkzeugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funktionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.punktwolkenAusSqliteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.punktwolkenAusAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdImport = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdFunktionen
            // 
            this.cmdFunktionen.Image = ((System.Drawing.Image)(resources.GetObject("cmdFunktionen.Image")));
            this.cmdFunktionen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFunktionen.Location = new System.Drawing.Point(27, 59);
            this.cmdFunktionen.Name = "cmdFunktionen";
            this.cmdFunktionen.Size = new System.Drawing.Size(132, 39);
            this.cmdFunktionen.TabIndex = 0;
            this.cmdFunktionen.Text = "         Funktionen";
            this.cmdFunktionen.UseVisualStyleBackColor = true;
            this.cmdFunktionen.Click += new System.EventHandler(this.cmdFunktionen_Click);
            // 
            // cmdSqlite
            // 
            this.cmdSqlite.Location = new System.Drawing.Point(27, 149);
            this.cmdSqlite.Name = "cmdSqlite";
            this.cmdSqlite.Size = new System.Drawing.Size(132, 72);
            this.cmdSqlite.TabIndex = 1;
            this.cmdSqlite.Text = "Punktwolken aus Sqlite";
            this.cmdSqlite.UseVisualStyleBackColor = true;
            this.cmdSqlite.Click += new System.EventHandler(this.cmdSqlite_Click);
            // 
            // btnAccessShowForm
            // 
            this.btnAccessShowForm.Location = new System.Drawing.Point(27, 247);
            this.btnAccessShowForm.Name = "btnAccessShowForm";
            this.btnAccessShowForm.Size = new System.Drawing.Size(132, 72);
            this.btnAccessShowForm.TabIndex = 2;
            this.btnAccessShowForm.Text = "Punktwolken aus Access";
            this.btnAccessShowForm.UseVisualStyleBackColor = true;
            this.btnAccessShowForm.Click += new System.EventHandler(this.btnAccessShowForm_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.werkzeugeToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(492, 24);
            this.menu.TabIndex = 3;
            this.menu.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programmBeendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // programmBeendenToolStripMenuItem
            // 
            this.programmBeendenToolStripMenuItem.Name = "programmBeendenToolStripMenuItem";
            this.programmBeendenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.programmBeendenToolStripMenuItem.Text = "Programm beenden";
            this.programmBeendenToolStripMenuItem.Click += new System.EventHandler(this.programmBeendenToolStripMenuItem_Click);
            // 
            // werkzeugeToolStripMenuItem
            // 
            this.werkzeugeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funktionenToolStripMenuItem,
            this.punktwolkenAusSqliteToolStripMenuItem,
            this.punktwolkenAusAccessToolStripMenuItem});
            this.werkzeugeToolStripMenuItem.Name = "werkzeugeToolStripMenuItem";
            this.werkzeugeToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.werkzeugeToolStripMenuItem.Text = "Werkzeuge";
            // 
            // funktionenToolStripMenuItem
            // 
            this.funktionenToolStripMenuItem.Name = "funktionenToolStripMenuItem";
            this.funktionenToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.funktionenToolStripMenuItem.Text = "Funktionen";
            this.funktionenToolStripMenuItem.Click += new System.EventHandler(this.funktionenToolStripMenuItem_Click);
            // 
            // punktwolkenAusSqliteToolStripMenuItem
            // 
            this.punktwolkenAusSqliteToolStripMenuItem.Name = "punktwolkenAusSqliteToolStripMenuItem";
            this.punktwolkenAusSqliteToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.punktwolkenAusSqliteToolStripMenuItem.Text = "Punktwolken aus Sqlite";
            this.punktwolkenAusSqliteToolStripMenuItem.Click += new System.EventHandler(this.punktwolkenAusSqliteToolStripMenuItem_Click);
            // 
            // punktwolkenAusAccessToolStripMenuItem
            // 
            this.punktwolkenAusAccessToolStripMenuItem.Name = "punktwolkenAusAccessToolStripMenuItem";
            this.punktwolkenAusAccessToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.punktwolkenAusAccessToolStripMenuItem.Text = "Punktwolken aus Access";
            this.punktwolkenAusAccessToolStripMenuItem.Click += new System.EventHandler(this.punktwolkenAusAccessToolStripMenuItem_Click);
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(326, 50);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(106, 39);
            this.cmdImport.TabIndex = 4;
            this.cmdImport.Text = "xml - gpx - Import";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 400);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.btnAccessShowForm);
            this.Controls.Add(this.cmdSqlite);
            this.Controls.Add(this.cmdFunktionen);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "FrmMain";
            this.Text = "Darstellung von Daten in verschiedenen Kontexten";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdFunktionen;
        private System.Windows.Forms.Button cmdSqlite;
        private System.Windows.Forms.Button btnAccessShowForm;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programmBeendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem werkzeugeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funktionenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem punktwolkenAusSqliteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem punktwolkenAusAccessToolStripMenuItem;
        private System.Windows.Forms.Button cmdImport;
    }
}