namespace ProjektArbeit
{
    partial class Hilfe
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
            this.lblHilfe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHilfe
            // 
            this.lblHilfe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHilfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHilfe.Location = new System.Drawing.Point(12, 9);
            this.lblHilfe.Name = "lblHilfe";
            this.lblHilfe.Size = new System.Drawing.Size(525, 591);
            this.lblHilfe.TabIndex = 0;
            // 
            // Hilfe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 625);
            this.Controls.Add(this.lblHilfe);
            this.Name = "Hilfe";
            this.Text = "Hilfe";
            this.Load += new System.EventHandler(this.Hilfe_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHilfe;
    }
}